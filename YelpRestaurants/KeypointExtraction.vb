Option Explicit On

Imports System.Data.SqlClient
Imports Accord.Imaging

Public Class KeypointExtraction

    Dim SqlConn As SqlConnection = Nothing
    Dim SQLConnectionString As String = My.Settings.SQLConnectionString1

    Dim SqlFunctions1 As New SqlFunctions()

    Public Progress As Integer
    Public ProgressMax As Integer
    Public SQLError As String = ""

    Dim SourceTableName1 As String
    Dim DestTableName1 As String

    Dim _PhotoSetType1 As ModelMode
    Dim _BusinessCount1 As Integer
    Dim _PhotosCount1 As Integer
    Dim _KeypointCount1 As Integer
    Dim _SurfThreshold1 As Double
    Dim _ImagesPath1 As String

    Sub New(ByVal PhotoSetType1 As ModelMode, ByVal BusinessCount1 As Integer, ByVal PhotosCount1 As Integer,
            ByVal KeypointCount1 As Integer, ByVal SurfThreshold As Double, ByVal ImagesPath1 As String)
        SqlConn = New SqlConnection(SQLConnectionString)
        SqlConn.Open()

        Me._PhotoSetType1 = PhotoSetType1
        Me._BusinessCount1 = BusinessCount1
        Me._PhotosCount1 = PhotosCount1
        Me._KeypointCount1 = KeypointCount1
        Me._SurfThreshold1 = SurfThreshold
        Me._ImagesPath1 = ImagesPath1

        Select Case PhotoSetType1
            Case ModelMode.Train
                SourceTableName1 = "train_photo_to_biz"
                DestTableName1 = "train_photo_keypoint_vectors"
            Case ModelMode.Test
                SourceTableName1 = "test_photo_to_biz"
                DestTableName1 = "test_photo_keypoint_vectors"
        End Select

        'Getting the number of rows (effectively the number of photos) that will be used from the train_photo_to_biz table
        Dim SqlStr1 As String =
            <SQL>
                DECLARE @business_count INT = '<%= BusinessCount1 %>'
                DECLARE @photo_count INT = '<%= PhotosCount1 %>'

                SELECT COUNT(*) AS RowsCount
                FROM (   SELECT [id], [photo_id],
                            ROW_NUMBER() OVER(PARTITION BY business_id ORDER BY business_id, photo_id) business_row_number
                         FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %>
                         WHERE business_id IN (
				                                  SELECT DISTINCT TOP (@business_count)
					                                  [business_id]
				                                  FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %>
				                                  ORDER BY business_id
			                                  )
                     ) AS Table1
                WHERE business_row_number &lt;= @photo_count
            </SQL>.Value
        Using SqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(SqlStr1, SQLError)
            If SQLError.Length = 0 Then
                ProgressMax = CInt(SqlDTable1.Rows(0).Item("RowsCount"))
            End If
        End Using
    End Sub

    Public Sub ExtractKeypointVectors()
        Try
            'Selecting which photos will be used for the process
            'Process is subject to the nud values of "Number of Businesses", "Photos per business"
            'SQL Query ensures that at most %intPhotosPerPbusiness% photos are used per business by the ROW_NUMBER() OVER(PARTITION
            'And that the top %intBusinessesToBeUSed% businesses are used by the SELECT DISTINCT TOP
            'And sets which photos to be used by the UPDATE Table2

            ''''''''''''''''''''Perhaps randomise the Business ID selection? Though Randomisation will make any "resume" operation infeasible and needing further implementation
            Dim SqlStr1 As String =
                <SQL>
                DECLARE @business_count INT = '<%= _BusinessCount1 %>'
                DECLARE @photo_count INT = '<%= _PhotosCount1 %>'
                DECLARE @Table1 AS TABLE (id INT)

                INSERT INTO @Table1
	                (id)
                SELECT
	                id
                FROM (
		                 SELECT
			                 [id]
			                 ,[photo_id]
			                 ,ROW_NUMBER() OVER(PARTITION BY business_id ORDER BY business_id, photo_id) business_row_number
		                 FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %>
		                 WHERE business_id IN (
								                  SELECT DISTINCT TOP (@business_count)
									                  [business_id]
								                  FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %>
								                  ORDER BY business_id
							                  )
	                 ) AS Table1
                WHERE business_row_number &lt;= @photo_count
                ORDER BY photo_id

                UPDATE Table2
                SET Table2.to_be_used = '1'
                FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %> AS Table2
                INNER JOIN @Table1 AS Table1
	                ON Table1.id = Table2.id
            </SQL>.Value
            SqlFunctions1.ExecuteSQLQuery(SqlStr1, SQLError)

            If SQLError.Length > 0 Then
                Exit Sub
            End If

            'Creating a tmp datatable with the Photo and Business IDs used to get the photo and keypoints, colour vector
            Dim SqlStr2 As String =
                <SQL>
                SELECT
	                [photo_id]
	                ,[business_id]
                FROM [YelpRestaurants].[dbo].<%= SourceTableName1 %>
                WHERE to_be_used = '1'
                ORDER BY business_id, photo_id
            </SQL>.Value
            Dim dtPhotoBusinessIDs As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(SqlStr2, SQLError)

            If SQLError.Length > 0 Then
                Exit Sub
            End If

            Dim SurfEngine As New SpeededUpRobustFeaturesDetector()
            Dim SurfPointsLst As List(Of SpeededUpRobustFeaturePoint) = Nothing

            Dim CurBusinessID, CurPhotoID As String
            Dim CurXKeypoint, CurYKeypoint, CurKeypointRadius, CurKeypointDiameter As Integer

            Dim CurPhotoPath As String = ""
            Dim CurPhotoBitmap As Bitmap = Nothing

            Dim CurPhotoCounter As Integer = 0
            Dim CurRowIndex As Integer = 0
            Dim CurKeypointColourVector As String = ""

            Dim ImageDTable1 As DataTable = Nothing

            Dim TempSurfThreshold1 As Double

            For i As Integer = 0 To dtPhotoBusinessIDs.Rows.Count - 1
                Progress = i + 1

                ImageDTable1 = GetImageDataTableSchema1(_PhotoSetType1)
                CurBusinessID = dtPhotoBusinessIDs.Rows(i).Item("business_id").ToString
                CurPhotoID = dtPhotoBusinessIDs.Rows(i).Item("photo_id").ToString
                CurPhotoPath = _ImagesPath1 & dtPhotoBusinessIDs.Rows(i).Item("photo_id").ToString & ".jpg"
                CurPhotoBitmap = CType(Image.FromFile(CurPhotoPath), Bitmap)

                SurfEngine.Threshold = _SurfThreshold1
                TempSurfThreshold1 = _SurfThreshold1

                'Getting the threshold right - practically setting it to capture the number of keypoints we want as close as possible
                Do
                    SurfPointsLst = SurfEngine.ProcessImage(CurPhotoBitmap)
                    TempSurfThreshold1 -= 0.0001
                    SurfEngine.Threshold = TempSurfThreshold1
                Loop Until (SurfPointsLst.Count >= _KeypointCount1 Or TempSurfThreshold1 <= 0)

                CurPhotoCounter = 1

                'Capturing all the necessary info in the local datatable
                For j As Integer = SurfPointsLst.Count - 1 To 0 Step -1
                    If CurPhotoCounter <= _KeypointCount1 Then
                        CurPhotoCounter += 1

                        ImageDTable1.Rows.Add(ImageDTable1.NewRow)
                        CurRowIndex = ImageDTable1.Rows.Count - 1
                        ImageDTable1.Rows(CurRowIndex).Item("business_id") = CurBusinessID
                        ImageDTable1.Rows(CurRowIndex).Item("photo_id") = CurPhotoID

                        CurXKeypoint = CInt(SurfPointsLst(j).X)
                        CurYKeypoint = CInt(SurfPointsLst(j).Y)
                        CurKeypointRadius = CInt((2 * Int((2.5 * SurfPointsLst(j).Scale))) / 2.0)
                        CurKeypointDiameter = CurKeypointRadius * 2

                        CurKeypointColourVector = GetKeypointHistogram1(_PhotoSetType1, CurBusinessID, CurPhotoID, j, CurPhotoBitmap, CurXKeypoint, CurYKeypoint, CurKeypointRadius, CurKeypointDiameter)

                        ImageDTable1.Rows(CurRowIndex).Item("keypoint_id") = j
                        ImageDTable1.Rows(CurRowIndex).Item("keypoint_x") = CurXKeypoint
                        ImageDTable1.Rows(CurRowIndex).Item("keypoint_y") = CurYKeypoint
                        ImageDTable1.Rows(CurRowIndex).Item("keypoint_radius") = CurKeypointRadius
                        ImageDTable1.Rows(CurRowIndex).Item("keypoint_color_vector") = CurKeypointColourVector
                    Else
                        'and copying it back to the SQL Server when finished (table test_photo_keypoint_vectors)
                        '''''''''''''''''''''''''''''''''''''''' Perhaps copy back to the server when a while i iteration is finished?
                        Using NewSqlBulkCopy As New SqlBulkCopy(SqlConn)
                            NewSqlBulkCopy.DestinationTableName = DestTableName1
                            CreateImageDataTableColumnMapping1(NewSqlBulkCopy)
                            NewSqlBulkCopy.WriteToServer(ImageDTable1)
                            NewSqlBulkCopy.Close()
                        End Using

                        Exit For
                    End If
                Next
            Next

            dtPhotoBusinessIDs.Dispose()
        Catch ex As Exception
            MsgBox("Failed to extract keypoint values on " & _PhotoSetType1.ToString & vbCrLf & ex.ToString)
        End Try

    End Sub

    Private Function GetKeypointHistogram1(ByVal PhotoSetType1 As ModelMode, ByVal Business_id1 As String, ByVal Photo_id1 As String, ByVal Keypoint_id1 As Integer,
                                           ByVal Image1 As Bitmap, ByVal Keypoint_X1 As Integer, ByVal Keypoint_Y1 As Integer, ByVal Keypoint_Radius1 As Integer,
                                           ByVal Keypoint_Diameter1 As Integer) As String
        Dim Result1 As String
        Dim Rectangle1 As New Rectangle(Keypoint_X1 - Keypoint_Radius1, Keypoint_Y1 - Keypoint_Radius1, Keypoint_Diameter1, Keypoint_Diameter1)
        Dim Filter1 As New AForge.Imaging.Filters.Crop(Rectangle1)
        Dim RegionImage1 As Bitmap = Filter1.Apply(Image1)

        Dim ImageStatistics1 As New AForge.Imaging.ImageStatistics(RegionImage1)

        Dim TempCombinedValues1() As Integer = Nothing

        TempCombinedValues1 = ImageStatistics1.Red.Values.Concat(ImageStatistics1.Green.Values).ToArray
        TempCombinedValues1 = TempCombinedValues1.Concat(ImageStatistics1.Blue.Values).ToArray

        Result1 = String.Join(" ", GetNormalizedVector1(TempCombinedValues1, 256))

        Return Result1
    End Function

    Private Function GetNormalizedVector1(ByVal Vector1() As Integer, ByVal MaxValue1 As Integer) As Integer()
        Dim Result1(Vector1.Count - 1) As Integer
        Dim Ratio1 As Double = MaxValue1 / Vector1.Max

        For i1 As Integer = 0 To Vector1.Count - 1
            Result1(i1) = CInt(Math.Round(Ratio1 * Vector1(i1)))
        Next

        Return Result1
    End Function

    Private Function GetImageDataTableSchema1(ByVal PhotoSetType1 As ModelMode) As DataTable
        Dim Result1 As New DataTable

        Select Case PhotoSetType1
            Case ModelMode.Train
                Result1.Columns.Add("business_id", GetType(Integer))
            Case ModelMode.Test
                Result1.Columns.Add("business_id", GetType(String))
        End Select

        Result1.Columns.Add("photo_id", GetType(Integer))
        Result1.Columns.Add("keypoint_id", GetType(Integer))
        Result1.Columns.Add("keypoint_x", GetType(Integer))
        Result1.Columns.Add("keypoint_y", GetType(Integer))
        Result1.Columns.Add("keypoint_radius", GetType(Integer))
        Result1.Columns.Add("keypoint_color_vector", GetType(String))

        Return Result1
    End Function

    Private Sub CreateImageDataTableColumnMapping1(ByVal SqlBulkCopy1 As SqlBulkCopy)
        SqlBulkCopy1.ColumnMappings.Add("business_id", "business_id")
        SqlBulkCopy1.ColumnMappings.Add("photo_id", "photo_id")
        SqlBulkCopy1.ColumnMappings.Add("keypoint_id", "keypoint_id")
        SqlBulkCopy1.ColumnMappings.Add("keypoint_x", "keypoint_x")
        SqlBulkCopy1.ColumnMappings.Add("keypoint_y", "keypoint_y")
        SqlBulkCopy1.ColumnMappings.Add("keypoint_radius", "keypoint_radius")
        SqlBulkCopy1.ColumnMappings.Add("keypoint_color_vector", "keypoint_color_vector")
    End Sub

    Sub Dispose()
        If Not SqlConn Is Nothing Then
            SqlConn.Dispose()
            SqlConn.Dispose()
        End If
    End Sub

End Class
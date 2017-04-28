Imports System.Data.SqlClient

Public Class VectorExtractionLevel2

    Dim SqlConn As SqlConnection = Nothing
    Dim SQLConnectionString As String = My.Settings.SQLConnectionString1

    Dim SqlFunctions1 As New SqlFunctions()

    Public Progress As Integer
    Public ProgressMax As Integer
    Public SQLError As String = ""

    Dim _SourceTableName1 As String
    Dim _DestTableName1 As String
    Dim _PhotoSetType1 As ModelMode

    Sub New(ByVal PhotoSetType1 As ModelMode)
        SqlConn = New SqlConnection(SQLConnectionString)
        SqlConn.Open()

        Me._PhotoSetType1 = PhotoSetType1

        Select Case PhotoSetType1
            Case ModelMode.Train
                _SourceTableName1 = "train_photo_vectors_cluster_level1"
                _DestTableName1 = "train_single_instances"
            Case ModelMode.Test
                _SourceTableName1 = "test_photo_vectors_cluster_level1"
                _DestTableName1 = "test_single_instances"
        End Select

        Dim BusinessesCountSqlStr1 As String =
            <SQL>
                SELECT
	                COUNT(DISTINCT business_id) AS business_count
                FROM [YelpRestaurants].[dbo].<%= _SourceTableName1 %>
                WHERE cluster_number IS NOT NULL
            </SQL>.Value
        Using PhotosCountDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(BusinessesCountSqlStr1, SQLError)
            If SQLError.Length = 0 Then
                ProgressMax = CInt(PhotosCountDTable1.Rows(0).Item("business_count"))
            End If
        End Using
    End Sub

    Public Sub ExtractVectors()
        Dim BusinessSqlStr1 As String =
            <SQL>
                SELECT DISTINCT
	                business_id
                FROM [YelpRestaurants].[dbo].<%= _SourceTableName1 %>
                WHERE cluster_number IS NOT NULL
                ORDER BY business_id
            </SQL>.Value
        Dim BusinessSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(BusinessSqlStr1, SQLError)

        If SQLError.Length > 0 Then
            Exit Sub
        End If

        Dim ClustersSqlStr1 As String =
            <SQL>
                SELECT
	                MAX(cluster_number) + 1 AS clusters
                FROM [YelpRestaurants].[dbo].<%= _SourceTableName1 %>
            </SQL>.Value
        Dim ClustersSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(ClustersSqlStr1, SQLError)

        If SQLError.Length > 0 Then
            Exit Sub
        End If

        Dim Clusters1 As Integer = CInt(ClustersSqlDTable1.Rows(0).Item("clusters"))
        ClustersSqlDTable1.Dispose()

        Dim Business_id1 As String
        Dim InsertVectorSqlStr1 As String

        For i1 As Integer = 0 To BusinessSqlDTable1.Rows.Count - 1
            Progress += 1
            Business_id1 = BusinessSqlDTable1.Rows(i1).Item("business_id").ToString

            InsertVectorSqlStr1 =
                <SQL>
                    DECLARE @NumbersTable AS TABLE (number INT);
                    DECLARE @VectorTable AS TABLE
	                    (
		                    RowNumber INT
		                    ,Value INT
	                    );

                    WITH NumberSequence(number) AS
	                    (
		                    SELECT
			                    0 AS number
		                    UNION ALL
		                    SELECT
			                    number + 1
                            FROM NumberSequence
                            WHERE number &lt; <%= Clusters1 - 1 %>
	                    )
	
                    INSERT INTO @NumbersTable
	                    (number)
                    SELECT
	                    number
                    FROM NumberSequence OPTION (MaxRecursion <%= Clusters1 - 1 %>)

                    INSERT INTO @VectorTable
	                    (
		                    RowNumber
		                    ,Value
	                    )
                    SELECT
	                    '1' as RowNumber
	                    ,(
		                    CASE WHEN cluster_count IS NOT NULL
			                    THEN cluster_count
			                    ELSE '0'
		                    END
	                    ) AS Value
                    FROM @NumbersTable AS Table1
                    LEFT OUTER JOIN (
					                    SELECT
						                    cluster_number
						                    ,COUNT(cluster_number) AS cluster_count
					                    FROM [YelpRestaurants].[dbo].<%= _SourceTableName1 %>
					                    WHERE business_id = '<%= Business_id1 %>'
					                    GROUP BY cluster_number
				                    ) AS Table2
	                    ON Table1.number = Table2.cluster_number
                    ORDER BY Table1.number
	
                    INSERT INTO [YelpRestaurants].[dbo].<%= _DestTableName1 %>
	                    (
		                    business_id
		                    ,vector
	                    )
                    SELECT
	                    '<%= Business_id1 %>' AS business_id
	                    ,(
                             SELECT DISTINCT
                                 STUFF((
                                           SELECT
                                               ' ' + CONVERT(VARCHAR, Table2.value)
                                           FROM @VectorTable AS Table2
                                           WHERE Table2.RowNumber = Table1.RowNumber
                                           FOR XML PATH ('')
                                       ), 1, 1, '') AS Vector
                             FROM @VectorTable AS Table1
	                    )
                </SQL>.Value
            SqlFunctions1.ExecuteSQLQuery(InsertVectorSqlStr1, SQLError)

            If SQLError.Length > 0 Then
                Exit Sub
            End If
        Next

        BusinessSqlDTable1.Dispose()
    End Sub

    Sub Dispose()
        If Not SqlConn Is Nothing Then
            SqlConn.Dispose()
            SqlConn.Dispose()
        End If
    End Sub

End Class
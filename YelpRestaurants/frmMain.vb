Imports System.IO
Imports System.Threading
Imports System.Data.SqlClient

Imports Accord.Imaging
Imports Accord.MachineLearning
Imports Accord.MachineLearning.VectorMachines
Imports Accord.MachineLearning.VectorMachines.Learning
Imports Accord.Statistics.Kernels
Imports Accord.Statistics.Analysis

Public Class frmMain

#Region "Variables, Structures, Enums"

    Dim DatabaseResetNeeded As Boolean = False
    Dim SurfThreshold As Double = 0.0008

    Dim isProcessInProgress As Boolean
    Dim Stopwatches As List(Of Stopwatch)
    Dim isStepXInProgress As List(Of Boolean)

    Dim Step1TrainCompleted, Step1TestCompleted, Step2Completed,
        Step3TrainCompleted, Step3TestCompleted, Step4Completed,
        Step5TrainCompleted, Step5TestCompleted, Step6Completed As Boolean

    Dim Step1TrainThread, Step1TestThread, Step2Thread,
        Step3TrainThread, Step3TestThread, Step4Thread,
        Step5TrainThread, Step5TestThread, Step6Thread As Thread

    Dim isStep2Counting As Boolean
    Dim Step2PBValue As Integer

    Dim isStep4Counting As Boolean
    Dim Step4PBValue As Integer

    Dim isStep6Counting As Boolean
    Dim Step6PBValue As Integer

    Dim TrainKeypointExtraction, TestKeypointExtraction As KeypointExtraction
    Dim TrainVectorExtractionLevel1, TestVectorExtractionLevel1 As VectorExtractionLevel1
    Dim TrainVectorExtractionLevel2, TestVectorExtractionLevel2 As VectorExtractionLevel2

    Dim TruePositives, FalsePositives, TrueNegatives, FalseNegatives As Integer

    Dim TrainInputVector()() As Double
    Dim TrainOutputVector()() As Integer
    Dim TrainInputVectorLength As Integer
    Dim TrainOutputVectorLength As Integer

    Dim SQLError1 As String
    Dim SQLErrorLogPath As String = My.Application.Info.DirectoryPath

#End Region

#Region "Events"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        If My.Settings.TrainImagesPath1 = "" Then
            FolderBrowserDialog1.Description = "Specify the Train Images Path"

            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                My.Settings.TrainImagesPath1 = FolderBrowserDialog1.SelectedPath & "\"
            Else
                MessageBox.Show("The application can't start without the Test Images path setting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If
        End If

        If My.Settings.TestImagesPath1 = "" Then
            FolderBrowserDialog1.Description = "Specify the Test Images Path"

            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                My.Settings.TestImagesPath1 = FolderBrowserDialog1.SelectedPath & "\"
            Else
                MessageBox.Show("The application can't start without the Test Images path setting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If
        End If

        If My.Settings.SQLConnectionString1 = "" Then
            Dim SQLConnectionString1 As String = InputBox("Specify the SQL Server connection string", "Connection string")

            If SQLConnectionString1 <> "" Then
                Try
                    Dim SqlConn As New SqlConnection(SQLConnectionString1)
                    SqlConn.Open()
                    My.Settings.SQLConnectionString1 = SQLConnectionString1
                    SqlConn.Close()
                    SqlConn.Dispose()
                Catch ex As Exception
                    MessageBox.Show("There is a problem with the provided connection string", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End
                End Try
            Else
                MessageBox.Show("The application can't start without the SQL connection string", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If
        End If

        My.Settings.Save()
        FolderBrowserDialog1.Dispose()

        If My.Settings.SQLErrorLogPath = "" Then
            My.Settings.SQLErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        End If

        ResetInterface1()
        ResetVariables1()
        ResetDatabaseTables1(False)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isProcessInProgress = True Then
            If MessageBox.Show("There is a process in progress, do you really want to close the programm?", "Confirm exit", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tmrUpdateStopwatches_Tick(sender As Object, e As EventArgs) Handles tmrUpdateStopwatches.Tick
        If isProcessInProgress = True Then
            If isStepXInProgress(0) = True Then
                Step1_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(0))

                If Not TrainKeypointExtraction Is Nothing Then
                    Step1_TrainPBr1.Value = TrainKeypointExtraction.Progress
                    Step1_TrainLbl2.Text = TrainKeypointExtraction.Progress & "/" & TrainKeypointExtraction.ProgressMax
                End If

                If Not TestKeypointExtraction Is Nothing Then
                    Step1_TestPBr1.Value = TestKeypointExtraction.Progress
                    Step1_TestLbl2.Text = TestKeypointExtraction.Progress & "/" & TestKeypointExtraction.ProgressMax
                End If
            End If

            If isStepXInProgress(1) = True Then
                Step2_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(1))

                If isStep2Counting = True Then
                    Step2_PBr1.Value = Step2PBValue
                    Step2_ProgressLbl2.Text = Step2PBValue & "/" & Step2_PBr1.Maximum
                End If
            End If

            If isStepXInProgress(2) = True Then
                Step3_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(2))

                If Not TrainVectorExtractionLevel1 Is Nothing Then
                    Step3_TrainPBr1.Value = TrainVectorExtractionLevel1.Progress
                    Step3_TrainLbl2.Text = TrainVectorExtractionLevel1.Progress & "/" & TrainVectorExtractionLevel1.ProgressMax
                End If

                If Not TestVectorExtractionLevel1 Is Nothing Then
                    Step3_TestPBr1.Value = TestVectorExtractionLevel1.Progress
                    Step3_TestLbl2.Text = TestVectorExtractionLevel1.Progress & "/" & TestVectorExtractionLevel1.ProgressMax
                End If
            End If

            If isStepXInProgress(3) = True Then
                Step4_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(3))

                If isStep4Counting = True Then
                    Step4_PBr1.Value = Step4PBValue
                    Step4_ProgressLbl2.Text = Step4PBValue & "/" & Step4_PBr1.Maximum
                End If
            End If

            If isStepXInProgress(4) = True Then
                Step5_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(4))

                If Not TrainVectorExtractionLevel2 Is Nothing Then
                    Step5_TrainPBr1.Value = TrainVectorExtractionLevel2.Progress
                    Step5_TrainLbl2.Text = TrainVectorExtractionLevel2.Progress & "/" & TrainVectorExtractionLevel2.ProgressMax
                End If

                If Not TestVectorExtractionLevel2 Is Nothing Then
                    Step5_TestPBr1.Value = TestVectorExtractionLevel2.Progress
                    Step5_TestLbl2.Text = TestVectorExtractionLevel2.Progress & "/" & TestVectorExtractionLevel2.ProgressMax
                End If
            End If

            If isStepXInProgress(5) = True Then
                Step6_TimerLbl1.Text = GetStopWatchElapsed1(Stopwatches(5))

                If isStep6Counting = True Then
                    Step6_PBr1.Value = Step6PBValue
                    Step6_ProgressLbl2.Text = Step6PBValue & "/" & Step6_PBr1.Maximum
                End If
            End If
        End If
    End Sub

    Private Sub ResetDBBtn1_Click(sender As Object, e As EventArgs) Handles btnResetDatabase.Click
        If MessageBox.Show("Are you sure you want to reset the Database?" & vbCrLf & "All the processed information will be lost", "Warning",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ResetDatabaseTables1()
            ResetVariables1()
            ResetInterface1()
        End If
    End Sub

    Private Sub StartBtn1_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If isProcessInProgress = True Then
            StopProcess1()
        Else
            StartProcess1()
        End If
    End Sub

    Private Sub ExportBtn1_Click(sender As Object, e As EventArgs) Handles btnExportPredictions.Click
        Dim SqlFunctions1 As New SqlFunctions
        Dim PredictionsSqlStr1 As String =
            <SQL>
                SELECT
	                [business_id] + ',' + [labels] AS business_id_and_labels
                FROM [YelpRestaurants].[dbo].[test_biz_to_labels]
                ORDER BY business_id
            </SQL>.Value
        Dim PredictionsDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(PredictionsSqlStr1, SQLError1)

        If SQLError1.Length > 0 Then
            MessageBox.Show(SQLError1, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AppendSQLErrorLOG()
            Exit Sub
        End If

        Dim StringToWrite1 As String

        sfdSaveToCSV.ShowDialog()

        If sfdSaveToCSV.FileName <> "" Then
            If File.Exists(sfdSaveToCSV.FileName) = True Then
                File.Delete(sfdSaveToCSV.FileName)
            End If

            Using StreamWriter1 As New StreamWriter(sfdSaveToCSV.FileName)
                StreamWriter1.WriteLine("business_id,labels")

                For i1 As Integer = 0 To PredictionsDTable1.Rows.Count - 1
                    StringToWrite1 = PredictionsDTable1.Rows(i1).Item("business_id_and_labels").ToString
                    StreamWriter1.WriteLine(StringToWrite1)
                Next

                StreamWriter1.Close()
            End Using

            MessageBox.Show("The export completed successfully", "Predictions export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        SqlFunctions1.Dispose()
    End Sub

    Private Sub StatisticsBtn1_Click(sender As Object, e As EventArgs) Handles btnViewStatistics.Click
        Me.Cursor = Cursors.WaitCursor

        If CrossValidationRBtn1.Checked = True Then
            If StatsFoldsNUpDn1.Value > nudTrainNumOfBusinesses.Value Then
                MessageBox.Show("The number of folds are greater than the number of instances", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                CrossValidation1()
            End If
        Else
            PercentageSplit1()
        End If

        Dim frmStatistics1 As New frmStatistics(TruePositives, FalsePositives, TrueNegatives, FalseNegatives)

        If CrossValidationRBtn1.Checked = True Then
            frmStatistics1.Text = "Statistics for [" & StatsFoldsNUpDn1.Value & " fold cross-validation]"
        Else
            frmStatistics1.Text = "Statistics for [" & StatsPercentageNUpDn1.Value & "% percentage split]"
        End If

        Me.Cursor = Cursors.Default

        frmStatistics1.ShowDialog()
        frmStatistics1.Dispose()
    End Sub

    Private Sub TestImagesPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mniSetTrainDirectory.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        FolderBrowserDialog1.Description = "Specify the Train Images Path"

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            My.Settings.TrainImagesPath1 = FolderBrowserDialog1.SelectedPath & "\"
        End If

        My.Settings.Save()
        FolderBrowserDialog1.Dispose()
    End Sub

    Private Sub SetTestImagesPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mniSetTestDirectory.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        FolderBrowserDialog1.Description = "Specify the Test Images Path"

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            My.Settings.TestImagesPath1 = FolderBrowserDialog1.SelectedPath & "\"
        End If

        My.Settings.Save()
        FolderBrowserDialog1.Dispose()
    End Sub

    Private Sub SetTheSqlServerConnectionStringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mniSetSQLConnectionString.Click
        Dim SQLConnectionString1 As String = InputBox("Specify the SQL Server connection string", "Connection string")

        If SQLConnectionString1 <> "" Then

            Try
                Dim SqlConn As New SqlConnection(SQLConnectionString1)
                SqlConn.Open()
                My.Settings.SQLConnectionString1 = SQLConnectionString1
                SqlConn.Close()
                SqlConn.Dispose()
            Catch ex As Exception
                MessageBox.Show("There is a problem with the provided connection string", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("The application can't start without the SQL connection string", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        My.Settings.Save()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mniExit.Click
        Me.Close()
    End Sub

#End Region

#Region "Subs - Functions"

#Region "Other"

    Private Sub StartProcess1()
        ResetVariables1()
        ResetInterface1()
        If DatabaseResetNeeded Then ResetDatabaseTables1(False)
        ParametersControlsEnabled1(False)
        btnResetDatabase.Enabled = False
        tmrUpdateStopwatches.Enabled = True
        isProcessInProgress = True

        btnStart.Text = "Stop"
        Call PerformStep1()
    End Sub

    Private Sub StopProcess1()
        If MessageBox.Show("Are you sure you want to stop the process?", "Algorithm execution", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Step2_PBr1.Style = ProgressBarStyle.Continuous
            Step4_PBr1.Style = ProgressBarStyle.Continuous
            Step6_PBr1.Style = ProgressBarStyle.Continuous

            AbortActiveThreads()

            For i1 As Integer = 0 To 5
                isStepXInProgress(i1) = False

                If Not Stopwatches(i1) Is Nothing Then
                    Stopwatches(i1).Stop()
                End If
            Next

            ParametersControlsEnabled1(True)
            btnResetDatabase.Enabled = True
            tmrUpdateStopwatches.Enabled = False
            isProcessInProgress = False
            btnStart.Text = "Start"
        End If
    End Sub

    Private Sub ResetInterface1()
        gbKeypointExtraction.ForeColor = Color.Black
        gbLevel1Clustering.ForeColor = Color.Black
        gbFormingSingleVectorPerPhoto.ForeColor = Color.Black
        gbLevel2Clustering.ForeColor = Color.Black
        gbFormingSingleVectorPerRestaurant.ForeColor = Color.Black
        gbClassification.ForeColor = Color.Black

        Step1_TimerLbl1.Text = "00:00:00"
        Step2_TimerLbl1.Text = "00:00:00"
        Step3_TimerLbl1.Text = "00:00:00"
        Step4_TimerLbl1.Text = "00:00:00"
        Step5_TimerLbl1.Text = "00:00:00"
        Step6_TimerLbl1.Text = "00:00:00"

        Step1_TrainLbl2.Text = ""
        Step1_TestLbl2.Text = ""
        Step2_ProgressLbl2.Text = ""
        Step3_TrainLbl2.Text = ""
        Step3_TestLbl2.Text = ""
        Step4_ProgressLbl2.Text = ""
        Step5_TrainLbl2.Text = ""
        Step5_TestLbl2.Text = ""
        Step6_ProgressLbl2.Text = ""

        Step1_TrainPBr1.Value = 0
        Step1_TestPBr1.Value = 0
        Step2_PBr1.Value = 0
        Step3_TrainPBr1.Value = 0
        Step3_TestPBr1.Value = 0
        Step4_PBr1.Value = 0
        Step5_TrainPBr1.Value = 0
        Step5_TestPBr1.Value = 0
        Step6_PBr1.Value = 0

        Step2_PBr1.Style = ProgressBarStyle.Continuous
        Step4_PBr1.Style = ProgressBarStyle.Continuous
        Step6_PBr1.Style = ProgressBarStyle.Continuous

        btnExportPredictions.Enabled = False
        btnViewStatistics.Enabled = False
        btnResetDatabase.Enabled = True
    End Sub

    Private Sub ResetVariables1()
        isProcessInProgress = False
        Step1TrainCompleted = False
        Step1TestCompleted = False
        Step2Completed = False
        Step3TrainCompleted = False
        Step3TestCompleted = False
        Step4Completed = False
        Step5TrainCompleted = False
        Step5TestCompleted = False
        Step6Completed = False

        isStep2Counting = False
        Step2PBValue = 0

        isStep4Counting = False
        Step4PBValue = 0

        isStep6Counting = False
        Step6PBValue = 0

        Stopwatches = New List(Of Stopwatch)
        isStepXInProgress = New List(Of Boolean)

        For i1 = 0 To 5
            Stopwatches.Add(New Stopwatch)
            isStepXInProgress.Add(False)
        Next

        TruePositives = 0
        FalsePositives = 0
        TrueNegatives = 0
        FalseNegatives = 0

        TrainInputVector = Nothing
        TrainOutputVector = Nothing
        TrainInputVectorLength = 0
        TrainOutputVectorLength = 0

        SQLError1 = ""
    End Sub

    Private Sub ResetDatabaseTables1(Optional ByVal ShowMessage As Boolean = True)
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Dim SqlFunctions1 As New SqlFunctions
        Dim SqlStr1 As String =
            <SQL>
                TRUNCATE TABLE [YelpRestaurants].[dbo].[test_photo_keypoint_vectors];
                TRUNCATE TABLE [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1];
                TRUNCATE TABLE [YelpRestaurants].[dbo].[test_single_instances];
                TRUNCATE TABLE [YelpRestaurants].[dbo].[test_biz_to_labels];

                UPDATE [YelpRestaurants].[dbo].[test_photo_to_biz]
                SET to_be_used = '0';

                TRUNCATE TABLE [YelpRestaurants].[dbo].[train_photo_keypoint_vectors];
                TRUNCATE TABLE [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1];
                TRUNCATE TABLE [YelpRestaurants].[dbo].[train_single_instances];

                UPDATE [YelpRestaurants].[dbo].[train_photo_to_biz]
                SET to_be_used = '0'
            </SQL>.Value


        SqlFunctions1.ExecuteSQLQuery(SqlStr1, SQLError1)

        If ShowMessage Then
            If SQLError1.Length = 0 Then
                MessageBox.Show("The reset process completed successfully", "Database reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("The reset process failed", "Database reset", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        SqlFunctions1.Dispose()

        Me.Cursor = Cursors.Default
        Me.Enabled = True
    End Sub

    Private Sub PerformNextStep()
        If Step1TrainCompleted AndAlso Step1TestCompleted AndAlso Not Step2Completed Then
            PerformStep2()
        ElseIf Step2Completed = True AndAlso Not Step3TrainCompleted AndAlso Not Step3TestCompleted Then
            PerformStep3()
        ElseIf Step3TrainCompleted AndAlso Step3TestCompleted AndAlso Not Step4Completed Then
            PerformStep4()
        ElseIf Step4Completed AndAlso Not Step5TrainCompleted AndAlso Not Step5TestCompleted Then
            PerformStep5()
        ElseIf Step5TrainCompleted And Step5TestCompleted AndAlso Not Step6Completed Then
            PerformStep6()
        End If
    End Sub

    Private Sub AbortActiveThreads()
        If Not Step1TrainThread Is Nothing AndAlso Step1TrainThread.IsAlive = True Then
            Step1TrainThread.Abort()
        End If

        If Not Step1TestThread Is Nothing AndAlso Step1TestThread.IsAlive = True Then
            Step1TestThread.Abort()
        End If

        If Not Step2Thread Is Nothing AndAlso Step2Thread.IsAlive = True Then
            Step2Thread.Abort()
        End If

        If Not Step3TrainThread Is Nothing AndAlso Step3TrainThread.IsAlive = True Then
            Step3TrainThread.Abort()
        End If

        If Not Step3TestThread Is Nothing AndAlso Step3TestThread.IsAlive = True Then
            Step3TestThread.Abort()
        End If

        If Not Step4Thread Is Nothing AndAlso Step4Thread.IsAlive = True Then
            Step4Thread.Abort()
        End If

        If Not Step5TrainThread Is Nothing AndAlso Step5TrainThread.IsAlive = True Then
            Step5TrainThread.Abort()
        End If

        If Not Step5TestThread Is Nothing AndAlso Step5TestThread.IsAlive = True Then
            Step5TestThread.Abort()
        End If

        If Not Step6Thread Is Nothing AndAlso Step6Thread.IsAlive = True Then
            Step6Thread.Abort()
        End If
    End Sub

    Private Sub SetControlStyles1(ByVal GroupBox1 As GroupBox)
        GroupBox1.ForeColor = Color.Green

        For Each Control1 As Control In GroupBox1.Controls
            Control1.ForeColor = Color.Black
        Next
    End Sub

    Private Sub ParametersControlsEnabled1(ByVal Enabled1 As Boolean)
        doMT(Sub()
                 nudTrainNumOfBusinesses.Enabled = Enabled1
                 nudTrainPhotosPerBusiness.Enabled = Enabled1

                 nudTestNumOfBusinesses.Enabled = Enabled1
                 nudTestPhotosPerBusiness.Enabled = Enabled1

                 nudKeypointsPerPicture.Enabled = Enabled1

                 nudLevel1Centres.Enabled = Enabled1
                 L1_PercentageNUpDn1.Enabled = Enabled1
                 L2_CentersNUpDn1.Enabled = Enabled1
                 L2_PercentageNUpDn1.Enabled = Enabled1

                 StatsFoldsNUpDn1.Enabled = Enabled1
                 StatsPercentageNUpDn1.Enabled = Enabled1
                 CrossValidationRBtn1.Enabled = Enabled1
                 PercentageSplitRBtn1.Enabled = Enabled1
             End Sub, Me)
    End Sub

    Private Sub AppendSQLErrorLOG()
        Dim FilePath1 As String = SQLErrorLogPath & "\SQLErrorLOG.txt"

        If File.Exists(FilePath1) = False Then
            File.Create(FilePath1)
        End If

        Using StreamWriter1 As New StreamWriter(FilePath1)
            StreamWriter1.WriteLine("DateTime = " & Now.ToString)
            StreamWriter1.WriteLine(SQLError1)

            StreamWriter1.Close()
        End Using
    End Sub

    Private Sub TrainModel1(ByVal InputVector1()() As Double, ByVal OutputVector1()() As Integer, ByVal InputVectorLength1 As Integer,
                            ByVal OutputVectorLength1 As Integer, ByRef Machine1 As MultilabelSupportVectorMachine)
        Dim Kernel1 As New Linear()
        'Dim Kernel1 As New Polynomial(2)

        Machine1 = New MultilabelSupportVectorMachine(InputVectorLength1, Kernel1, OutputVectorLength1)
        Dim SVMLearner1 As New MultilabelSupportVectorLearning(Machine1, InputVector1, OutputVector1)

        SVMLearner1.Algorithm = Function(svm, classInputs, classOutputs, i, j) New SequentialMinimalOptimization(svm, classInputs, classOutputs)

        Dim Error1 As Double = SVMLearner1.Run
    End Sub

    Private Sub CrossValidation1()
        If TrainInputVector.Length = 0 And TrainOutputVector.Length = 0 Then
            Exit Sub
        End If

        TruePositives = 0
        FalsePositives = 0
        TrueNegatives = 0
        FalseNegatives = 0

        Dim TrainPartLength1 As Integer = CInt(TrainInputVector.Length / StatsFoldsNUpDn1.Value)
        Dim TrainInputVectorPart1()() As Double
        Dim TrainOutputVectorPart1()() As Integer
        Dim TestInputVectorPart1()() As Double
        Dim TestOutputVectorPart1()() As Integer

        For i1 As Integer = 1 To CInt(StatsFoldsNUpDn1.Value)
            ReDim TrainInputVectorPart1(0)
            ReDim TrainOutputVectorPart1(0)

            ReDim TestInputVectorPart1(0)
            ReDim TestOutputVectorPart1(0)

            For i2 As Integer = 0 To TrainInputVector.Length - 1
                If i2 >= (i1 - 1) * TrainPartLength1 And i2 < i1 * TrainPartLength1 Then
                    TestInputVectorPart1(TestInputVectorPart1.Length - 1) = TrainInputVector(i2)
                    TestOutputVectorPart1(TestOutputVectorPart1.Length - 1) = TrainOutputVector(i2)

                    ReDim Preserve TestInputVectorPart1(TestInputVectorPart1.Length)
                    ReDim Preserve TestOutputVectorPart1(TestOutputVectorPart1.Length)
                Else
                    TrainInputVectorPart1(TrainInputVectorPart1.Length - 1) = TrainInputVector(i2)
                    TrainOutputVectorPart1(TrainOutputVectorPart1.Length - 1) = TrainOutputVector(i2)

                    ReDim Preserve TrainInputVectorPart1(TrainInputVectorPart1.Length)
                    ReDim Preserve TrainOutputVectorPart1(TrainOutputVectorPart1.Length)
                End If
            Next

            ReDim Preserve TestInputVectorPart1(TestInputVectorPart1.Length - 2)
            ReDim Preserve TestOutputVectorPart1(TestOutputVectorPart1.Length - 2)
            ReDim Preserve TrainInputVectorPart1(TrainInputVectorPart1.Length - 2)
            ReDim Preserve TrainOutputVectorPart1(TrainOutputVectorPart1.Length - 2)

            Dim Machine1 As MultilabelSupportVectorMachine = Nothing
            TrainModel1(TrainInputVectorPart1, TrainOutputVectorPart1, TrainInputVectorLength, TrainOutputVectorLength, Machine1)

            Dim TrainOutputPredictionsVector1(TestInputVectorPart1.Count - 1)() As Integer

            For i2 As Integer = 0 To TestInputVectorPart1.Count - 1
                TrainOutputPredictionsVector1(i2) = Machine1.Compute(TestInputVectorPart1(i2))
            Next

            For i2 As Integer = 0 To TestInputVectorPart1.Count - 1
                Dim ConfusionMatrix1 As New ConfusionMatrix(TrainOutputPredictionsVector1(i2), TestOutputVectorPart1(i2), 1, -1)

                TruePositives += ConfusionMatrix1.TruePositives
                FalsePositives += ConfusionMatrix1.FalsePositives
                TrueNegatives += ConfusionMatrix1.TrueNegatives
                FalseNegatives += ConfusionMatrix1.FalseNegatives
            Next
        Next

    End Sub

    Private Sub PercentageSplit1()
        If TrainInputVector.Length = 0 And TrainOutputVector.Length = 0 Then
            Exit Sub
        End If

        TruePositives = 0
        FalsePositives = 0
        TrueNegatives = 0
        FalseNegatives = 0

        Dim TrainPartLength1 As Integer = CInt(TrainInputVector.Length * StatsPercentageNUpDn1.Value / 100)
        Dim TrainInputVectorPart1(TrainPartLength1 - 1)() As Double
        Dim TrainOutputVectorPart1(TrainPartLength1 - 1)() As Integer

        For i1 As Integer = 0 To TrainPartLength1 - 1
            TrainInputVectorPart1(i1) = TrainInputVector(i1)
            TrainOutputVectorPart1(i1) = TrainOutputVector(i1)
        Next

        Dim TestPartLength1 As Integer = TrainInputVector.Length - TrainPartLength1
        Dim TestInputVectorPart1(TrainInputVector.Length - TrainPartLength1 - 1)() As Double
        Dim TestOutputVectorPart1(TrainInputVector.Length - TrainPartLength1 - 1)() As Integer

        For i1 As Integer = TrainPartLength1 To TrainInputVector.Length - 1
            TestInputVectorPart1(i1 - TrainPartLength1) = TrainInputVector(i1)
            TestOutputVectorPart1(i1 - TrainPartLength1) = TrainOutputVector(i1)
        Next

        Dim Machine1 As MultilabelSupportVectorMachine = Nothing
        TrainModel1(TrainInputVectorPart1, TrainOutputVectorPart1, TrainInputVectorLength, TrainOutputVectorLength, Machine1)

        Dim TrainOutputPredictionsVector1(TestInputVectorPart1.Count - 1)() As Integer

        For i1 As Integer = 0 To TestInputVectorPart1.Count - 1
            TrainOutputPredictionsVector1(i1) = Machine1.Compute(TestInputVectorPart1(i1))
        Next

        For i1 As Integer = 0 To TestInputVectorPart1.Count - 1
            Dim ConfusionMatrix1 As New ConfusionMatrix(TrainOutputPredictionsVector1(i1), TestOutputVectorPart1(i1), 1, -1)

            TruePositives += ConfusionMatrix1.TruePositives
            FalsePositives += ConfusionMatrix1.FalsePositives
            TrueNegatives += ConfusionMatrix1.TrueNegatives
            FalseNegatives += ConfusionMatrix1.FalseNegatives
        Next
    End Sub

    Private Function UpdateClusterNumber1(ByVal id1 As Integer, ByVal TableName1 As String, ByVal kMeans1 As KMeans, ByVal VectorStr1 As String, ByVal SqlFunctions1 As SqlFunctions) As String
        Dim Result1 As String = ""
        Dim VectorLength1 As Integer = CountSpaces1(VectorStr1) + 1
        Dim Vector1() As Double = VectorToDoubleArray1(VectorStr1, VectorLength1)
        Dim Cluster_number1 As Integer = kMeans1.Clusters.Nearest(Vector1)
        Dim SqlStr1 As String =
            <SQL>
                UPDATE [YelpRestaurants].[dbo].<%= TableName1 %>
                SET cluster_number = '<%= Cluster_number1 %>'
                WHERE id = '<%= id1 %>'
            </SQL>.Value
        SqlFunctions1.ExecuteSQLQuery(SqlStr1, Result1)

        Return Result1
    End Function

    Private Function GetStopWatchElapsed1(ByVal StopWatch1 As Stopwatch) As String
        Dim Result1 As String = String.Format("{0:00}:{1:00}:{2:00}",
                                StopWatch1.Elapsed.Hours,
                                StopWatch1.Elapsed.Minutes,
                                StopWatch1.Elapsed.Seconds)
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

    Private Function VectorToDoubleArray1(ByVal Vector1 As String, ByVal Length1 As Integer) As Double()
        Dim Result1(Length1 - 1) As Double
        Dim DataArray1 As String() = Vector1.Split(" "c)

        For i1 As Integer = 0 To Length1 - 1
            Result1(i1) = CDbl(DataArray1(i1))
        Next

        Return Result1
    End Function

    Private Function VectorToIntegerArray1(ByVal Vector1 As String, ByVal Length1 As Integer) As Integer()
        Dim Result1(Length1 - 1) As Integer
        Dim DataArray1 As String() = Vector1.Split(" "c)

        For i1 As Integer = 0 To Length1 - 1
            Result1(i1) = CInt(DataArray1(i1))
        Next

        Return Result1
    End Function

    Private Function CountSpaces1(ByVal Vector1 As String) As Integer
        Dim Result1 As Integer = 0

        For Each Char1 As Char In Vector1
            If Char1 = " " Then
                Result1 += 1
            End If
        Next

        Return Result1
    End Function

#End Region

#Region "Algorithm steps"

#Region "Step1"

    Private Sub PerformStep1()
        Step1TrainThread = New Thread(Sub() Step1_TrainPart1()) With {.IsBackground = True}
        Step1TestThread = New Thread(Sub() Step1_TestPart1()) With {.IsBackground = True}

        Step1TrainThread.Start()
        Step1TestThread.Start()

        Stopwatches(0).Start()
        isStepXInProgress(0) = True
    End Sub

    Private Sub Step1_TrainPart1()
        TrainKeypointExtraction = New KeypointExtraction(ModelMode.Train, CInt(nudTrainNumOfBusinesses.Value), CInt(nudTrainPhotosPerBusiness.Value),
                                                          CInt(nudKeypointsPerPicture.Value), SurfThreshold, My.Settings.TrainImagesPath1)

        doMT(Sub() Step1_TrainPBr1.Maximum = TrainKeypointExtraction.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TrainKeypointExtraction.ExtractKeypointVectors()
        TrainKeypointExtraction.Dispose()
        '---------------------------------------------------------------------------------------------

        Step1TrainCompleted = True
        Step1_ProcessComplete1()
    End Sub

    Private Sub nudLevel1Centres_ValueChanged(sender As Object, e As EventArgs) Handles nudLevel1Centres.ValueChanged
        Try
            If Not isStepXInProgress(1) AndAlso Not isStepXInProgress(3) Then
                nudLevel1Centres.ForeColor = Color.Black
                DatabaseResetNeeded = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub L2_CentersNUpDn1_ValueChanged(sender As Object, e As EventArgs) Handles L2_CentersNUpDn1.ValueChanged
        DatabaseResetNeeded = True
    End Sub

    Private Sub nudTrainNumOfBusinesses_ValueChanged(sender As Object, e As EventArgs) Handles nudTrainNumOfBusinesses.ValueChanged
        DatabaseResetNeeded = True
    End Sub

    Private Sub nudTrainPhotosPerBusiness_ValueChanged(sender As Object, e As EventArgs) Handles nudTrainPhotosPerBusiness.ValueChanged
        DatabaseResetNeeded = True
    End Sub

    Private Sub nudTestNumOfBusinesses_ValueChanged(sender As Object, e As EventArgs) Handles nudTestNumOfBusinesses.ValueChanged
        DatabaseResetNeeded = True
    End Sub

    Private Sub nudTestPhotosPerBusiness_ValueChanged(sender As Object, e As EventArgs) Handles nudTestPhotosPerBusiness.ValueChanged
        DatabaseResetNeeded = True
    End Sub

    Private Sub nudKeypointsPerPicture_ValueChanged(sender As Object, e As EventArgs) Handles nudKeypointsPerPicture.ValueChanged

    End Sub

    Private Sub Step1_TestPart1()
        TestKeypointExtraction = New KeypointExtraction(ModelMode.Test, CInt(nudTestNumOfBusinesses.Value), CInt(nudTestPhotosPerBusiness.Value),
                                                         CInt(nudKeypointsPerPicture.Value), SurfThreshold, My.Settings.TestImagesPath1)
        doMT(Sub() Step1_TestPBr1.Maximum = TestKeypointExtraction.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TestKeypointExtraction.ExtractKeypointVectors()
        TestKeypointExtraction.Dispose()
        '---------------------------------------------------------------------------------------------

        Step1TestCompleted = True
        Step1_ProcessComplete1()
    End Sub

    Private Sub Step1_ProcessComplete1()
        If Step1TrainCompleted AndAlso Step1TestCompleted Then
            doMT(Sub() gbKeypointExtraction.ForeColor = Color.Green, Me)
            Stopwatches(0).Stop()
            PerformNextStep()
        End If
    End Sub

#End Region

#Region "Step2"

    Private Sub PerformStep2()
        Step2Thread = New Thread(Sub() Step2()) With {.IsBackground = True}
        Step2Thread.Start()

        Stopwatches(1).Start()
        isStepXInProgress(1) = True
    End Sub

    Private Sub Step2()
        '---------------------------------------------------------------------------------------------
        Level1_Clustering1()
        '---------------------------------------------------------------------------------------------

        Step2Completed = True
        Step2_ProcessComplete1()
    End Sub

    Private Sub Step2_ProcessComplete1()
        doMT(Sub() gbLevel1Clustering.ForeColor = Color.Green, Me)
        Stopwatches(1).Stop()
        PerformNextStep()
    End Sub

    Private Sub Level1_Clustering1()
        Try
            Dim ClustersCount As Integer = CInt(nudLevel1Centres.Value)
            doMT(Sub() Step2_PBr1.Style = ProgressBarStyle.Marquee, Me)

            Dim SelectPercentage1 As Integer = CInt(L1_PercentageNUpDn1.Value)

            Dim SqlFunctions1 As New SqlFunctions
            Dim SqlStr1 As String =
                <SQL>
                SELECT TOP <%= SelectPercentage1 %> PERCENT
	                id
	                ,keypoint_color_vector
	                ,CONVERT(INT, '1') AS PhotoSetType
                FROM [YelpRestaurants].[dbo].[train_photo_keypoint_vectors]
                UNION
                SELECT TOP <%= SelectPercentage1 %> PERCENT
	                id
	                ,keypoint_color_vector
	                ,CONVERT(INT, '2') AS PhotoSetType
                FROM [YelpRestaurants].[dbo].[test_photo_keypoint_vectors]
                ORDER BY PhotoSetType, id
            </SQL>.Value
            Dim SqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(SqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim ClusterData1(SqlDTable1.Rows.Count - 1)() As Double
            Dim VectorStr1 As String
            Dim VectorLength1 As Integer = CountSpaces1(SqlDTable1.Rows(0).Item("keypoint_color_vector").ToString) + 1

            For i1 As Integer = 0 To SqlDTable1.Rows.Count - 1
                VectorStr1 = SqlDTable1.Rows(i1).Item("keypoint_color_vector").ToString
                ClusterData1(i1) = VectorToDoubleArray1(VectorStr1, VectorLength1)
            Next

            'Making sure that there are more points that Cluster Centres
            If SqlDTable1.Rows.Count < ClustersCount Then
                ClustersCount = CInt(SqlDTable1.Rows.Count / 2)
                doMT(Sub()
                         nudLevel1Centres.Value = ClustersCount
                         nudLevel1Centres.ForeColor = Color.Red
                     End Sub, Me)
            End If

            Dim kMeans1 As New KMeans(ClustersCount)
            Dim Clusters1() As Integer = kMeans1.Compute(ClusterData1)
            Dim PhotoSetType1 As Integer
            Dim TableName1 As String = ""
            Dim id1 As Integer

            For i1 As Integer = 0 To SqlDTable1.Rows.Count - 1
                PhotoSetType1 = CInt(SqlDTable1.Rows(i1).Item("PhotoSetType"))
                id1 = CInt(SqlDTable1.Rows(i1).Item("id"))

                Select Case PhotoSetType1
                    Case 1
                        TableName1 = "train_photo_keypoint_vectors"
                    Case 2
                        TableName1 = "test_photo_keypoint_vectors"
                End Select

                Dim SqlStr2 As String =
                    <SQL>
                    UPDATE [YelpRestaurants].[dbo].<%= TableName1 %>
                    SET cluster_number = '<%= Clusters1(i1) %>'
                    WHERE id = '<%= id1 %>'
                </SQL>.Value
                SqlFunctions1.ExecuteSQLQuery(SqlStr2, SQLError1)

                If SQLError1.Length > 0 Then
                    AppendSQLErrorLOG()
                    Exit Sub
                End If
            Next

            SqlDTable1.Dispose()

            Dim TrainSqlStr1 As String =
                <SQL>
                SELECT --TOP 10 PERCENT
                    id
                    ,keypoint_color_vector
                FROM [YelpRestaurants].[dbo].[train_photo_keypoint_vectors]
                WHERE cluster_number IS NULL
                ORDER BY id
            </SQL>.Value
            Dim TrainSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TrainSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim TrainRowsCount1 As Integer = TrainSqlDTable1.Rows.Count
            Dim TestSqlStr1 As String =
                <SQL>
                SELECT --TOP 10 PERCENT
                    id
                    ,keypoint_color_vector
                FROM [YelpRestaurants].[dbo].[test_photo_keypoint_vectors]
                WHERE cluster_number IS NULL
                ORDER BY id
            </SQL>.Value
            Dim TestSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TestSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim TestRowsCount1 As Integer = TestSqlDTable1.Rows.Count
            Dim RowsCount1 As Integer = If(TrainRowsCount1 > TestRowsCount1, TrainRowsCount1, TestRowsCount1)

            doMT(Sub()
                     Step2_PBr1.Style = ProgressBarStyle.Continuous
                     Step2_PBr1.Maximum = RowsCount1
                 End Sub, Me)
            isStep2Counting = True

            For i1 As Integer = 0 To RowsCount1 - 1
                Step2PBValue = i1 + 1

                If i1 <= TrainRowsCount1 - 1 Then
                    id1 = CInt(TrainSqlDTable1.Rows(i1).Item("id"))
                    VectorStr1 = TrainSqlDTable1.Rows(i1).Item("keypoint_color_vector").ToString
                    TableName1 = "train_photo_keypoint_vectors"
                    SQLError1 = UpdateClusterNumber1(id1, TableName1, kMeans1, VectorStr1, SqlFunctions1)

                    If SQLError1.Length > 0 Then
                        AppendSQLErrorLOG()
                        Exit Sub
                    End If
                End If

                If i1 <= TestRowsCount1 - 1 Then
                    id1 = CInt(TestSqlDTable1.Rows(i1).Item("id"))
                    VectorStr1 = TestSqlDTable1.Rows(i1).Item("keypoint_color_vector").ToString
                    TableName1 = "test_photo_keypoint_vectors"
                    SQLError1 = UpdateClusterNumber1(id1, TableName1, kMeans1, VectorStr1, SqlFunctions1)

                    If SQLError1.Length > 0 Then
                        AppendSQLErrorLOG()
                        Exit Sub
                    End If
                End If
            Next

            TrainSqlDTable1.Dispose()
            TestSqlDTable1.Dispose()
            SqlFunctions1.Dispose()
        Catch ex As Exception
            MsgBox("Failed on Level 1 Clustering!" & vbCrLf & ex.ToString)
        End Try

    End Sub

#End Region

#Region "Step3"

    Private Sub PerformStep3()
        Step3TrainThread = New Thread(Sub() Step3_TrainPart1()) With {.IsBackground = True}
        Step3TestThread = New Thread(Sub() Step3_TestPart1()) With {.IsBackground = True}

        Step3TrainThread.Start()
        Step3TestThread.Start()

        Stopwatches(2).Start()
        isStepXInProgress(2) = True
    End Sub

    Private Sub Step3_TrainPart1()
        TrainVectorExtractionLevel1 = New VectorExtractionLevel1(ModelMode.Train)
        doMT(Sub() Step3_TrainPBr1.Maximum = TrainVectorExtractionLevel1.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TrainVectorExtractionLevel1.ExtractVectors()
        TrainVectorExtractionLevel1.Dispose()
        '---------------------------------------------------------------------------------------------

        Step3TrainCompleted = True
        Step3_ProcessComplete1()
    End Sub

    Private Sub Step3_TestPart1()
        TestVectorExtractionLevel1 = New VectorExtractionLevel1(ModelMode.Test)
        doMT(Sub() Step3_TestPBr1.Maximum = TestVectorExtractionLevel1.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TestVectorExtractionLevel1.ExtractVectors()
        TestVectorExtractionLevel1.Dispose()
        '---------------------------------------------------------------------------------------------

        Step3TestCompleted = True
        Step3_ProcessComplete1()
    End Sub

    Private Sub Step3_ProcessComplete1()
        If Step3TrainCompleted = True And Step3TestCompleted = True Then
            doMT(Sub() gbFormingSingleVectorPerPhoto.ForeColor = Color.Green, Me)
            Stopwatches(2).Stop()
            PerformNextStep()
        End If
    End Sub

#End Region

#Region "Step4"

    Private Sub PerformStep4()
        Step4Thread = New Thread(Sub() Step4()) With {.IsBackground = True}
        Step4Thread.Start()

        Stopwatches(3).Start()
        isStepXInProgress(3) = True
    End Sub

    Private Sub Step4()
        '---------------------------------------------------------------------------------------------
        Level2_Clustering1()
        '---------------------------------------------------------------------------------------------

        Step4Completed = True
        Step4_ProcessComplete1()
    End Sub

    Private Sub Step4_ProcessComplete1()
        doMT(Sub() gbLevel2Clustering.ForeColor = Color.Green, Me)
        Stopwatches(3).Stop()
        PerformNextStep()
    End Sub

    Private Sub Level2_Clustering1()
        Try
            Dim ClustersCount As Integer = CInt(L2_CentersNUpDn1.Value)
            doMT(Sub() Step4_PBr1.Style = ProgressBarStyle.Marquee, Me)

            Dim SelectPercentage1 As Integer = CInt(L2_PercentageNUpDn1.Value)

            Dim SqlFunctions1 As New SqlFunctions
            Dim SqlStr1 As String =
                <SQL>
                SELECT TOP <%= SelectPercentage1 %> PERCENT
	                id
	                ,vector
	                ,CONVERT(INT, '1') AS PhotoSetType
                FROM [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1]
                UNION
                SELECT TOP <%= SelectPercentage1 %> PERCENT
	                id
	                ,vector
	                ,CONVERT(INT, '2') AS PhotoSetType
                FROM [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1]
                ORDER BY PhotoSetType, id
            </SQL>.Value
            Dim SqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(SqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim ClusterData1(SqlDTable1.Rows.Count - 1)() As Double
            Dim VectorStr1 As String
            Dim VectorLength1 As Integer = CountSpaces1(SqlDTable1.Rows(0).Item("vector").ToString) + 1

            For i1 As Integer = 0 To SqlDTable1.Rows.Count - 1
                VectorStr1 = SqlDTable1.Rows(i1).Item("vector").ToString
                ClusterData1(i1) = VectorToDoubleArray1(VectorStr1, VectorLength1)
            Next

            'Making sure that there are more point that Cluster Centres
            If SqlDTable1.Rows.Count < ClustersCount Then
                ClustersCount = CInt(SqlDTable1.Rows.Count / 2)
                doMT(Sub()
                         L2_CentersNUpDn1.Value = ClustersCount
                         L2_CentersNUpDn1.ForeColor = Color.Red
                     End Sub, Me)
            End If

            Dim kMeans1 As New KMeans(ClustersCount)
            Dim Clusters1() As Integer = kMeans1.Compute(ClusterData1)
            Dim PhotoSetType1 As Integer
            Dim TableName1 As String = ""
            Dim id1 As Integer

            For i1 As Integer = 0 To SqlDTable1.Rows.Count - 1
                PhotoSetType1 = CInt(SqlDTable1.Rows(i1).Item("PhotoSetType"))
                id1 = CInt(SqlDTable1.Rows(i1).Item("id"))

                Select Case PhotoSetType1
                    Case 1
                        TableName1 = "train_photo_vectors_cluster_level1"
                    Case 2
                        TableName1 = "test_photo_vectors_cluster_level1"
                End Select

                Dim SqlStr2 As String =
                    <SQL>
                    UPDATE [YelpRestaurants].[dbo].<%= TableName1 %>
                    SET cluster_number = '<%= Clusters1(i1) %>'
                    WHERE id = '<%= id1 %>'
                </SQL>.Value
                SqlFunctions1.ExecuteSQLQuery(SqlStr2, SQLError1)

                If SQLError1.Length > 0 Then
                    AppendSQLErrorLOG()
                    Exit Sub
                End If
            Next

            SqlDTable1.Dispose()

            Dim TrainSqlStr1 As String =
                <SQL>
                SELECT --TOP 10 PERCENT
                    id
                    ,vector
                FROM [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1]
                WHERE cluster_number IS NULL
                ORDER BY id
            </SQL>.Value
            Dim TrainSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TrainSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim TrainRowsCount1 As Integer = TrainSqlDTable1.Rows.Count
            Dim TestSqlStr1 As String =
                <SQL>
                SELECT --TOP 10 PERCENT
                    id
                    ,vector
                FROM [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1]
                WHERE cluster_number IS NULL
                ORDER BY id
            </SQL>.Value
            Dim TestSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TestSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim TestRowsCount1 As Integer = TestSqlDTable1.Rows.Count
            Dim RowsCount1 As Integer = If(TrainRowsCount1 > TestRowsCount1, TrainRowsCount1, TestRowsCount1)

            doMT(Sub()
                     Step4_PBr1.Style = ProgressBarStyle.Continuous
                     Step4_PBr1.Maximum = RowsCount1
                 End Sub, Me)
            isStep4Counting = True

            For i1 As Integer = 0 To RowsCount1 - 1
                Step4PBValue = i1 + 1

                If i1 <= TrainRowsCount1 - 1 Then
                    id1 = CInt(TrainSqlDTable1.Rows(i1).Item("id"))
                    VectorStr1 = TrainSqlDTable1.Rows(i1).Item("vector").ToString
                    TableName1 = "train_photo_vectors_cluster_level1"
                    UpdateClusterNumber1(id1, TableName1, kMeans1, VectorStr1, SqlFunctions1)
                End If

                If i1 <= TestRowsCount1 - 1 Then
                    id1 = CInt(TestSqlDTable1.Rows(i1).Item("id"))
                    VectorStr1 = TestSqlDTable1.Rows(i1).Item("vector").ToString
                    TableName1 = "test_photo_vectors_cluster_level1"
                    UpdateClusterNumber1(id1, TableName1, kMeans1, VectorStr1, SqlFunctions1)
                End If
            Next

            TrainSqlDTable1.Dispose()
            TestSqlDTable1.Dispose()
            SqlFunctions1.Dispose()
        Catch ex As Exception
            MsgBox("Failed on Level 2 Clustering!" & vbCrLf & ex.ToString)
        End Try

    End Sub

#End Region

#Region "Step5"

    Private Sub PerformStep5()
        Step5TrainThread = New Thread(Sub() Step5_TrainPart1()) With {.IsBackground = True}
        Step5TestThread = New Thread(Sub() Step5_TestPart1()) With {.IsBackground = True}

        Step5TrainThread.Start()
        Step5TestThread.Start()

        Stopwatches(4).Start()
        isStepXInProgress(4) = True
    End Sub

    Private Sub Step5_TrainPart1()
        TrainVectorExtractionLevel2 = New VectorExtractionLevel2(ModelMode.Train)
        doMT(Sub() Step5_TrainPBr1.Maximum = TrainVectorExtractionLevel2.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TrainVectorExtractionLevel2.ExtractVectors()
        TrainVectorExtractionLevel2.Dispose()
        '---------------------------------------------------------------------------------------------

        Step5TrainCompleted = True
        Step5_ProcessComplete1()
    End Sub

    Private Sub Step5_TestPart1()
        TestVectorExtractionLevel2 = New VectorExtractionLevel2(ModelMode.Test)
        doMT(Sub() Step5_TestPBr1.Maximum = TestVectorExtractionLevel2.ProgressMax, Me)

        '---------------------------------------------------------------------------------------------
        TestVectorExtractionLevel2.ExtractVectors()
        TestVectorExtractionLevel2.Dispose()
        '---------------------------------------------------------------------------------------------

        Step5TestCompleted = True
        Step5_ProcessComplete1()
    End Sub

    Private Sub Step5_ProcessComplete1()
        If Step5TrainCompleted = True And Step5TestCompleted = True Then
            doMT(Sub() gbFormingSingleVectorPerRestaurant.ForeColor = Color.Green, Me)
            Stopwatches(4).Stop()
            PerformNextStep()
        End If
    End Sub

#End Region

#Region "Step6"

    Private Sub PerformStep6()
        Step6Thread = New Thread(Sub() Step6()) With {.IsBackground = True}
        Step6Thread.Start()

        Stopwatches(5).Start()
        isStepXInProgress(5) = True
    End Sub

    Private Sub Step6()
        '---------------------------------------------------------------------------------------------
        Classification1()
        '---------------------------------------------------------------------------------------------

        Step6Completed = True
        Step6_ProcessComplete1()
    End Sub

    Private Sub Step6_ProcessComplete1()
        Stopwatches(5).Stop()

        Thread.Sleep(100)

        doMT(Sub()
                 gbClassification.ForeColor = Color.Green
                 btnExportPredictions.ForeColor = Color.Black
                 btnExportPredictions.Enabled = True
                 btnViewStatistics.ForeColor = Color.Black
                 btnViewStatistics.Enabled = True
                 ParametersControlsEnabled1(True)
                 btnResetDatabase.Enabled = True
                 isProcessInProgress = False
                 btnStart.Text = "Start"
             End Sub, Me)
    End Sub

    Private Sub Classification1()
        Try
            doMT(Sub() Step6_PBr1.Style = ProgressBarStyle.Marquee, Me)

            Dim SqlFunctions1 As New SqlFunctions
            Dim TrainDataSqlStr1 As String =
                <SQL>
                SELECT
	                Table1.vector AS input_vector
	                ,Table2.binary_labels AS output_vector
                FROM [YelpRestaurants].[dbo].[train_single_instances] AS Table1
                INNER JOIN [YelpRestaurants].[dbo].[train_biz_to_labels] AS Table2
	                ON Table1.business_id = Table2.business_id
                ORDER BY Table1.business_id
            </SQL>.Value
            Dim TrainSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TrainDataSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            ReDim TrainInputVector(TrainSqlDTable1.Rows.Count - 1)
            ReDim TrainOutputVector(TrainSqlDTable1.Rows.Count - 1)

            Dim VectorStr1 As String
            TrainInputVectorLength = CountSpaces1(TrainSqlDTable1.Rows(0).Item("input_vector").ToString) + 1
            TrainOutputVectorLength = CountSpaces1(TrainSqlDTable1.Rows(0).Item("output_vector").ToString) + 1

            For i1 As Integer = 0 To TrainSqlDTable1.Rows.Count - 1
                VectorStr1 = TrainSqlDTable1.Rows(i1).Item("input_vector").ToString
                TrainInputVector(i1) = VectorToDoubleArray1(VectorStr1, TrainInputVectorLength)

                VectorStr1 = TrainSqlDTable1.Rows(i1).Item("output_vector").ToString
                TrainOutputVector(i1) = VectorToIntegerArray1(VectorStr1, TrainOutputVectorLength)
            Next

            TrainSqlDTable1.Dispose()

            Dim Machine1 As MultilabelSupportVectorMachine = Nothing
            TrainModel1(TrainInputVector, TrainOutputVector, TrainInputVectorLength, TrainOutputVectorLength, Machine1)

            Dim TestDataSqlStr1 As String =
                <SQL>
                SELECT
	                [business_id]
                    ,[vector] AS input_vector
                FROM [YelpRestaurants].[dbo].[test_single_instances]
                WHERE business_id NOT IN (
                                             SELECT
                                                 business_id
                                             FROM [YelpRestaurants].[dbo].[test_biz_to_labels]
                                         )
                ORDER BY business_id
            </SQL>.Value
            Dim TestSqlDTable1 As DataTable = SqlFunctions1.GetDataTableFromSQLQuery(TestDataSqlStr1, SQLError1)

            If SQLError1.Length > 0 Then
                AppendSQLErrorLOG()
                Exit Sub
            End If

            Dim TestInputVector1() As Double
            Dim TestOutputVector1() As Integer
            Dim TestInputVectorLength1 As Integer = CountSpaces1(TestSqlDTable1.Rows(0).Item("input_vector").ToString) + 1
            Dim TestOutputIndexString1 As String = ""
            Dim Business_id1 As String
            Dim InsertPredictionsSqlStr1 As String

            doMT(Sub()
                     Step6_PBr1.Style = ProgressBarStyle.Continuous
                     Step6_PBr1.Maximum = TestSqlDTable1.Rows.Count
                 End Sub, Me)
            isStep6Counting = True

            For i1 As Integer = 0 To TestSqlDTable1.Rows.Count - 1
                Step6PBValue = i1 + 1

                VectorStr1 = TestSqlDTable1.Rows(i1).Item("input_vector").ToString
                Business_id1 = TestSqlDTable1.Rows(i1).Item("business_id").ToString
                TestInputVector1 = VectorToDoubleArray1(VectorStr1, TestInputVectorLength1)

                TestOutputVector1 = Machine1.Compute(TestInputVector1)

                TestOutputIndexString1 = ""

                For i2 As Integer = 0 To TestOutputVector1.Count - 1
                    If TestOutputVector1(i2) = 1 Then
                        TestOutputIndexString1 &= i2.ToString & " "
                    End If
                Next

                TestOutputIndexString1 = TestOutputIndexString1.TrimEnd

                InsertPredictionsSqlStr1 =
                    <SQL>
                    INSERT INTO [YelpRestaurants].[dbo].[test_biz_to_labels]
                        (
                            business_id
                            ,labels
                        )
                    VALUES
                        (
                            '<%= Business_id1 %>'
                            ,'<%= TestOutputIndexString1 %>'
                        )
                </SQL>.Value
                SqlFunctions1.ExecuteSQLQuery(InsertPredictionsSqlStr1, SQLError1)

                If SQLError1.Length > 0 Then
                    AppendSQLErrorLOG()
                    Exit Sub
                End If
            Next

            TestSqlDTable1.Dispose()
            SqlFunctions1.Dispose()
        Catch ex As Exception
            CopyTextToClipboard(ex.ToString)
            MsgBox("Failed on SIML Classification!" & vbCrLf & ex.ToString)
        End Try

    End Sub

#End Region

#End Region

#End Region

End Class
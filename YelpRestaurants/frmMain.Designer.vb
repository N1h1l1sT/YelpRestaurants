<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblAlgorithmSteps = New System.Windows.Forms.Label()
        Me.nudLevel1Centres = New System.Windows.Forms.NumericUpDown()
        Me.lblLevel1Centres = New System.Windows.Forms.Label()
        Me.gbAlgorithmSteps = New System.Windows.Forms.GroupBox()
        Me.gbClassification = New System.Windows.Forms.GroupBox()
        Me.Step6_ProgressLbl2 = New System.Windows.Forms.Label()
        Me.Step6_PBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step6_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step6_ProgressLbl1 = New System.Windows.Forms.Label()
        Me.gbFormingSingleVectorPerRestaurant = New System.Windows.Forms.GroupBox()
        Me.Step5_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step5_TestLbl2 = New System.Windows.Forms.Label()
        Me.Step5_TestPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step5_TrainPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step5_TrainLbl2 = New System.Windows.Forms.Label()
        Me.Step5_TestLbl1 = New System.Windows.Forms.Label()
        Me.Step5_TrainLbl1 = New System.Windows.Forms.Label()
        Me.gbLevel2Clustering = New System.Windows.Forms.GroupBox()
        Me.Step4_ProgressLbl2 = New System.Windows.Forms.Label()
        Me.Step4_PBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step4_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step4_ProgressLbl1 = New System.Windows.Forms.Label()
        Me.gbFormingSingleVectorPerPhoto = New System.Windows.Forms.GroupBox()
        Me.Step3_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step3_TestLbl2 = New System.Windows.Forms.Label()
        Me.Step3_TrainPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step3_TestPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step3_TrainLbl1 = New System.Windows.Forms.Label()
        Me.Step3_TestLbl1 = New System.Windows.Forms.Label()
        Me.Step3_TrainLbl2 = New System.Windows.Forms.Label()
        Me.gbLevel1Clustering = New System.Windows.Forms.GroupBox()
        Me.Step2_ProgressLbl2 = New System.Windows.Forms.Label()
        Me.Step2_PBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step2_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step2_ProgressLbl1 = New System.Windows.Forms.Label()
        Me.gbKeypointExtraction = New System.Windows.Forms.GroupBox()
        Me.Step1_TimerLbl1 = New System.Windows.Forms.Label()
        Me.Step1_TestLbl2 = New System.Windows.Forms.Label()
        Me.Step1_TestPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step1_TestLbl1 = New System.Windows.Forms.Label()
        Me.Step1_TrainLbl2 = New System.Windows.Forms.Label()
        Me.Step1_TrainPBr1 = New System.Windows.Forms.ProgressBar()
        Me.Step1_TrainLbl1 = New System.Windows.Forms.Label()
        Me.btnViewStatistics = New System.Windows.Forms.Button()
        Me.btnExportPredictions = New System.Windows.Forms.Button()
        Me.gbParameters = New System.Windows.Forms.GroupBox()
        Me.gbStatistics = New System.Windows.Forms.GroupBox()
        Me.StatsPercentageNUpDn1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatsFoldsNUpDn1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PercentageSplitRBtn1 = New System.Windows.Forms.RadioButton()
        Me.CrossValidationRBtn1 = New System.Windows.Forms.RadioButton()
        Me.gbClustering = New System.Windows.Forms.GroupBox()
        Me.L2_PercentageNUpDn1 = New System.Windows.Forms.NumericUpDown()
        Me.L1_PercentageNUpDn1 = New System.Windows.Forms.NumericUpDown()
        Me.L2_PercentageLbl1 = New System.Windows.Forms.Label()
        Me.L1_PercentageLbl1 = New System.Windows.Forms.Label()
        Me.L2_CentresLbl1 = New System.Windows.Forms.Label()
        Me.L2_CentersNUpDn1 = New System.Windows.Forms.NumericUpDown()
        Me.gbTrainSet = New System.Windows.Forms.GroupBox()
        Me.nudTrainNumOfBusinesses = New System.Windows.Forms.NumericUpDown()
        Me.lblTrainNumOfBusinesses = New System.Windows.Forms.Label()
        Me.nudTrainPhotosPerBusiness = New System.Windows.Forms.NumericUpDown()
        Me.lblTrainPhotosPerBusiness = New System.Windows.Forms.Label()
        Me.lblParameters = New System.Windows.Forms.Label()
        Me.gbTestSet = New System.Windows.Forms.GroupBox()
        Me.nudTestNumOfBusinesses = New System.Windows.Forms.NumericUpDown()
        Me.lblTestNumOfBusinesses = New System.Windows.Forms.Label()
        Me.nudTestPhotosPerBusiness = New System.Windows.Forms.NumericUpDown()
        Me.lblTestPhotosPerBusiness = New System.Windows.Forms.Label()
        Me.gbKeypointVectors = New System.Windows.Forms.GroupBox()
        Me.lblKeypointsPerPicture = New System.Windows.Forms.Label()
        Me.nudKeypointsPerPicture = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnResetDatabase = New System.Windows.Forms.Button()
        Me.tmrUpdateStopwatches = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.sfdSaveToCSV = New System.Windows.Forms.SaveFileDialog()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mniFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniSetTrainDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniSetTestDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniSetSQLConnectionString = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniExit = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.nudLevel1Centres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAlgorithmSteps.SuspendLayout()
        Me.gbClassification.SuspendLayout()
        Me.gbFormingSingleVectorPerRestaurant.SuspendLayout()
        Me.gbLevel2Clustering.SuspendLayout()
        Me.gbFormingSingleVectorPerPhoto.SuspendLayout()
        Me.gbLevel1Clustering.SuspendLayout()
        Me.gbKeypointExtraction.SuspendLayout()
        Me.gbParameters.SuspendLayout()
        Me.gbStatistics.SuspendLayout()
        CType(Me.StatsPercentageNUpDn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatsFoldsNUpDn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClustering.SuspendLayout()
        CType(Me.L2_PercentageNUpDn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L1_PercentageNUpDn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L2_CentersNUpDn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTrainSet.SuspendLayout()
        CType(Me.nudTrainNumOfBusinesses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTrainPhotosPerBusiness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTestSet.SuspendLayout()
        CType(Me.nudTestNumOfBusinesses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTestPhotosPerBusiness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbKeypointVectors.SuspendLayout()
        CType(Me.nudKeypointsPerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(145, 17)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(100, 23)
        Me.btnStart.TabIndex = 14
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblAlgorithmSteps
        '
        Me.lblAlgorithmSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlgorithmSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlgorithmSteps.Location = New System.Drawing.Point(3, 10)
        Me.lblAlgorithmSteps.Name = "lblAlgorithmSteps"
        Me.lblAlgorithmSteps.Size = New System.Drawing.Size(394, 21)
        Me.lblAlgorithmSteps.TabIndex = 0
        Me.lblAlgorithmSteps.Text = "Algorithm steps"
        Me.lblAlgorithmSteps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudLevel1Centres
        '
        Me.nudLevel1Centres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudLevel1Centres.Location = New System.Drawing.Point(160, 18)
        Me.nudLevel1Centres.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.nudLevel1Centres.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudLevel1Centres.Name = "nudLevel1Centres"
        Me.nudLevel1Centres.Size = New System.Drawing.Size(67, 20)
        Me.nudLevel1Centres.TabIndex = 5
        Me.nudLevel1Centres.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'lblLevel1Centres
        '
        Me.lblLevel1Centres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel1Centres.Location = New System.Drawing.Point(12, 22)
        Me.lblLevel1Centres.Name = "lblLevel1Centres"
        Me.lblLevel1Centres.Size = New System.Drawing.Size(145, 13)
        Me.lblLevel1Centres.TabIndex = 0
        Me.lblLevel1Centres.Text = "Level 1 Centres Count:"
        Me.lblLevel1Centres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbAlgorithmSteps
        '
        Me.gbAlgorithmSteps.Controls.Add(Me.gbClassification)
        Me.gbAlgorithmSteps.Controls.Add(Me.gbFormingSingleVectorPerRestaurant)
        Me.gbAlgorithmSteps.Controls.Add(Me.gbLevel2Clustering)
        Me.gbAlgorithmSteps.Controls.Add(Me.gbFormingSingleVectorPerPhoto)
        Me.gbAlgorithmSteps.Controls.Add(Me.gbLevel1Clustering)
        Me.gbAlgorithmSteps.Controls.Add(Me.gbKeypointExtraction)
        Me.gbAlgorithmSteps.Controls.Add(Me.lblAlgorithmSteps)
        Me.gbAlgorithmSteps.Location = New System.Drawing.Point(261, 19)
        Me.gbAlgorithmSteps.Name = "gbAlgorithmSteps"
        Me.gbAlgorithmSteps.Size = New System.Drawing.Size(400, 480)
        Me.gbAlgorithmSteps.TabIndex = 0
        Me.gbAlgorithmSteps.TabStop = False
        '
        'gbClassification
        '
        Me.gbClassification.Controls.Add(Me.Step6_ProgressLbl2)
        Me.gbClassification.Controls.Add(Me.Step6_PBr1)
        Me.gbClassification.Controls.Add(Me.Step6_TimerLbl1)
        Me.gbClassification.Controls.Add(Me.Step6_ProgressLbl1)
        Me.gbClassification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbClassification.Location = New System.Drawing.Point(3, 400)
        Me.gbClassification.Name = "gbClassification"
        Me.gbClassification.Size = New System.Drawing.Size(394, 77)
        Me.gbClassification.TabIndex = 12
        Me.gbClassification.TabStop = False
        Me.gbClassification.Text = "6. SIML Classification"
        '
        'Step6_ProgressLbl2
        '
        Me.Step6_ProgressLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step6_ProgressLbl2.Location = New System.Drawing.Point(308, 38)
        Me.Step6_ProgressLbl2.Name = "Step6_ProgressLbl2"
        Me.Step6_ProgressLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step6_ProgressLbl2.TabIndex = 1
        Me.Step6_ProgressLbl2.Text = "10000/10000"
        Me.Step6_ProgressLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step6_PBr1
        '
        Me.Step6_PBr1.Location = New System.Drawing.Point(106, 38)
        Me.Step6_PBr1.Name = "Step6_PBr1"
        Me.Step6_PBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step6_PBr1.TabIndex = 24
        '
        'Step6_TimerLbl1
        '
        Me.Step6_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step6_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step6_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step6_TimerLbl1.Name = "Step6_TimerLbl1"
        Me.Step6_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step6_TimerLbl1.TabIndex = 0
        Me.Step6_TimerLbl1.Text = "00:00:00"
        Me.Step6_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step6_ProgressLbl1
        '
        Me.Step6_ProgressLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step6_ProgressLbl1.Location = New System.Drawing.Point(21, 38)
        Me.Step6_ProgressLbl1.Name = "Step6_ProgressLbl1"
        Me.Step6_ProgressLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step6_ProgressLbl1.TabIndex = 0
        Me.Step6_ProgressLbl1.Text = "Progress:"
        Me.Step6_ProgressLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFormingSingleVectorPerRestaurant
        '
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TimerLbl1)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TestLbl2)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TestPBr1)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TrainPBr1)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TrainLbl2)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TestLbl1)
        Me.gbFormingSingleVectorPerRestaurant.Controls.Add(Me.Step5_TrainLbl1)
        Me.gbFormingSingleVectorPerRestaurant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFormingSingleVectorPerRestaurant.Location = New System.Drawing.Point(3, 322)
        Me.gbFormingSingleVectorPerRestaurant.Name = "gbFormingSingleVectorPerRestaurant"
        Me.gbFormingSingleVectorPerRestaurant.Size = New System.Drawing.Size(394, 70)
        Me.gbFormingSingleVectorPerRestaurant.TabIndex = 4
        Me.gbFormingSingleVectorPerRestaurant.TabStop = False
        Me.gbFormingSingleVectorPerRestaurant.Text = "5. Forming Single Vector Pet Restaurant"
        '
        'Step5_TimerLbl1
        '
        Me.Step5_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step5_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step5_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step5_TimerLbl1.Name = "Step5_TimerLbl1"
        Me.Step5_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step5_TimerLbl1.TabIndex = 0
        Me.Step5_TimerLbl1.Text = "00:00:00"
        Me.Step5_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step5_TestLbl2
        '
        Me.Step5_TestLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step5_TestLbl2.Location = New System.Drawing.Point(308, 46)
        Me.Step5_TestLbl2.Name = "Step5_TestLbl2"
        Me.Step5_TestLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step5_TestLbl2.TabIndex = 0
        Me.Step5_TestLbl2.Text = "10000/10000"
        Me.Step5_TestLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step5_TestPBr1
        '
        Me.Step5_TestPBr1.Location = New System.Drawing.Point(106, 46)
        Me.Step5_TestPBr1.Name = "Step5_TestPBr1"
        Me.Step5_TestPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step5_TestPBr1.TabIndex = 0
        '
        'Step5_TrainPBr1
        '
        Me.Step5_TrainPBr1.Location = New System.Drawing.Point(106, 22)
        Me.Step5_TrainPBr1.Name = "Step5_TrainPBr1"
        Me.Step5_TrainPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step5_TrainPBr1.TabIndex = 0
        '
        'Step5_TrainLbl2
        '
        Me.Step5_TrainLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step5_TrainLbl2.Location = New System.Drawing.Point(308, 22)
        Me.Step5_TrainLbl2.Name = "Step5_TrainLbl2"
        Me.Step5_TrainLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step5_TrainLbl2.TabIndex = 0
        Me.Step5_TrainLbl2.Text = "10000/10000"
        Me.Step5_TrainLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step5_TestLbl1
        '
        Me.Step5_TestLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step5_TestLbl1.Location = New System.Drawing.Point(21, 45)
        Me.Step5_TestLbl1.Name = "Step5_TestLbl1"
        Me.Step5_TestLbl1.Size = New System.Drawing.Size(81, 13)
        Me.Step5_TestLbl1.TabIndex = 0
        Me.Step5_TestLbl1.Text = "Progress (Test):"
        Me.Step5_TestLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step5_TrainLbl1
        '
        Me.Step5_TrainLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step5_TrainLbl1.Location = New System.Drawing.Point(21, 21)
        Me.Step5_TrainLbl1.Name = "Step5_TrainLbl1"
        Me.Step5_TrainLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step5_TrainLbl1.TabIndex = 0
        Me.Step5_TrainLbl1.Text = "Progress (Train):"
        Me.Step5_TrainLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbLevel2Clustering
        '
        Me.gbLevel2Clustering.Controls.Add(Me.Step4_ProgressLbl2)
        Me.gbLevel2Clustering.Controls.Add(Me.Step4_PBr1)
        Me.gbLevel2Clustering.Controls.Add(Me.Step4_TimerLbl1)
        Me.gbLevel2Clustering.Controls.Add(Me.Step4_ProgressLbl1)
        Me.gbLevel2Clustering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLevel2Clustering.Location = New System.Drawing.Point(3, 256)
        Me.gbLevel2Clustering.Name = "gbLevel2Clustering"
        Me.gbLevel2Clustering.Size = New System.Drawing.Size(394, 52)
        Me.gbLevel2Clustering.TabIndex = 3
        Me.gbLevel2Clustering.TabStop = False
        Me.gbLevel2Clustering.Text = "4. Clustering the Photo Vectors (Level 2 Clustering)"
        '
        'Step4_ProgressLbl2
        '
        Me.Step4_ProgressLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step4_ProgressLbl2.Location = New System.Drawing.Point(308, 24)
        Me.Step4_ProgressLbl2.Name = "Step4_ProgressLbl2"
        Me.Step4_ProgressLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step4_ProgressLbl2.TabIndex = 26
        Me.Step4_ProgressLbl2.Text = "10000/10000"
        Me.Step4_ProgressLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step4_PBr1
        '
        Me.Step4_PBr1.Location = New System.Drawing.Point(106, 24)
        Me.Step4_PBr1.Name = "Step4_PBr1"
        Me.Step4_PBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step4_PBr1.TabIndex = 1
        '
        'Step4_TimerLbl1
        '
        Me.Step4_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step4_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step4_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step4_TimerLbl1.Name = "Step4_TimerLbl1"
        Me.Step4_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step4_TimerLbl1.TabIndex = 23
        Me.Step4_TimerLbl1.Text = "00:00:00"
        Me.Step4_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step4_ProgressLbl1
        '
        Me.Step4_ProgressLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step4_ProgressLbl1.Location = New System.Drawing.Point(21, 23)
        Me.Step4_ProgressLbl1.Name = "Step4_ProgressLbl1"
        Me.Step4_ProgressLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step4_ProgressLbl1.TabIndex = 0
        Me.Step4_ProgressLbl1.Text = "Progress:"
        Me.Step4_ProgressLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFormingSingleVectorPerPhoto
        '
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TimerLbl1)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TestLbl2)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TrainPBr1)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TestPBr1)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TrainLbl1)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TestLbl1)
        Me.gbFormingSingleVectorPerPhoto.Controls.Add(Me.Step3_TrainLbl2)
        Me.gbFormingSingleVectorPerPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFormingSingleVectorPerPhoto.Location = New System.Drawing.Point(3, 173)
        Me.gbFormingSingleVectorPerPhoto.Name = "gbFormingSingleVectorPerPhoto"
        Me.gbFormingSingleVectorPerPhoto.Size = New System.Drawing.Size(394, 72)
        Me.gbFormingSingleVectorPerPhoto.TabIndex = 2
        Me.gbFormingSingleVectorPerPhoto.TabStop = False
        Me.gbFormingSingleVectorPerPhoto.Text = "3. Forming Single Vector Per Photo"
        '
        'Step3_TimerLbl1
        '
        Me.Step3_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step3_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step3_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step3_TimerLbl1.Name = "Step3_TimerLbl1"
        Me.Step3_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step3_TimerLbl1.TabIndex = 0
        Me.Step3_TimerLbl1.Text = "00:00:00"
        Me.Step3_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step3_TestLbl2
        '
        Me.Step3_TestLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step3_TestLbl2.Location = New System.Drawing.Point(308, 47)
        Me.Step3_TestLbl2.Name = "Step3_TestLbl2"
        Me.Step3_TestLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step3_TestLbl2.TabIndex = 0
        Me.Step3_TestLbl2.Text = "10000/10000"
        Me.Step3_TestLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step3_TrainPBr1
        '
        Me.Step3_TrainPBr1.Location = New System.Drawing.Point(106, 23)
        Me.Step3_TrainPBr1.Name = "Step3_TrainPBr1"
        Me.Step3_TrainPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step3_TrainPBr1.TabIndex = 0
        '
        'Step3_TestPBr1
        '
        Me.Step3_TestPBr1.Location = New System.Drawing.Point(106, 47)
        Me.Step3_TestPBr1.Name = "Step3_TestPBr1"
        Me.Step3_TestPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step3_TestPBr1.TabIndex = 0
        '
        'Step3_TrainLbl1
        '
        Me.Step3_TrainLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step3_TrainLbl1.Location = New System.Drawing.Point(21, 22)
        Me.Step3_TrainLbl1.Name = "Step3_TrainLbl1"
        Me.Step3_TrainLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step3_TrainLbl1.TabIndex = 0
        Me.Step3_TrainLbl1.Text = "Progress (Train):"
        Me.Step3_TrainLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step3_TestLbl1
        '
        Me.Step3_TestLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step3_TestLbl1.Location = New System.Drawing.Point(21, 46)
        Me.Step3_TestLbl1.Name = "Step3_TestLbl1"
        Me.Step3_TestLbl1.Size = New System.Drawing.Size(81, 13)
        Me.Step3_TestLbl1.TabIndex = 0
        Me.Step3_TestLbl1.Text = "Progress (Test):"
        Me.Step3_TestLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step3_TrainLbl2
        '
        Me.Step3_TrainLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step3_TrainLbl2.Location = New System.Drawing.Point(308, 23)
        Me.Step3_TrainLbl2.Name = "Step3_TrainLbl2"
        Me.Step3_TrainLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step3_TrainLbl2.TabIndex = 0
        Me.Step3_TrainLbl2.Text = "10000/10000"
        Me.Step3_TrainLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbLevel1Clustering
        '
        Me.gbLevel1Clustering.Controls.Add(Me.Step2_ProgressLbl2)
        Me.gbLevel1Clustering.Controls.Add(Me.Step2_PBr1)
        Me.gbLevel1Clustering.Controls.Add(Me.Step2_TimerLbl1)
        Me.gbLevel1Clustering.Controls.Add(Me.Step2_ProgressLbl1)
        Me.gbLevel1Clustering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLevel1Clustering.Location = New System.Drawing.Point(3, 117)
        Me.gbLevel1Clustering.Name = "gbLevel1Clustering"
        Me.gbLevel1Clustering.Size = New System.Drawing.Size(394, 52)
        Me.gbLevel1Clustering.TabIndex = 1
        Me.gbLevel1Clustering.TabStop = False
        Me.gbLevel1Clustering.Text = "2. Clustering Keypoint Vectors (Level 1 Clustering)"
        '
        'Step2_ProgressLbl2
        '
        Me.Step2_ProgressLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step2_ProgressLbl2.Location = New System.Drawing.Point(308, 23)
        Me.Step2_ProgressLbl2.Name = "Step2_ProgressLbl2"
        Me.Step2_ProgressLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step2_ProgressLbl2.TabIndex = 1
        Me.Step2_ProgressLbl2.Text = "10000/10000"
        Me.Step2_ProgressLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step2_PBr1
        '
        Me.Step2_PBr1.Location = New System.Drawing.Point(106, 23)
        Me.Step2_PBr1.Name = "Step2_PBr1"
        Me.Step2_PBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step2_PBr1.TabIndex = 25
        '
        'Step2_TimerLbl1
        '
        Me.Step2_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step2_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step2_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step2_TimerLbl1.Name = "Step2_TimerLbl1"
        Me.Step2_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step2_TimerLbl1.TabIndex = 0
        Me.Step2_TimerLbl1.Text = "00:00:00"
        Me.Step2_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step2_ProgressLbl1
        '
        Me.Step2_ProgressLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step2_ProgressLbl1.Location = New System.Drawing.Point(21, 23)
        Me.Step2_ProgressLbl1.Name = "Step2_ProgressLbl1"
        Me.Step2_ProgressLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step2_ProgressLbl1.TabIndex = 0
        Me.Step2_ProgressLbl1.Text = "Progress:"
        Me.Step2_ProgressLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbKeypointExtraction
        '
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TimerLbl1)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TestLbl2)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TestPBr1)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TestLbl1)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TrainLbl2)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TrainPBr1)
        Me.gbKeypointExtraction.Controls.Add(Me.Step1_TrainLbl1)
        Me.gbKeypointExtraction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbKeypointExtraction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbKeypointExtraction.Location = New System.Drawing.Point(3, 37)
        Me.gbKeypointExtraction.Name = "gbKeypointExtraction"
        Me.gbKeypointExtraction.Size = New System.Drawing.Size(394, 72)
        Me.gbKeypointExtraction.TabIndex = 0
        Me.gbKeypointExtraction.TabStop = False
        Me.gbKeypointExtraction.Text = "1. Keypoint Extraction"
        '
        'Step1_TimerLbl1
        '
        Me.Step1_TimerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Step1_TimerLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step1_TimerLbl1.Location = New System.Drawing.Point(319, 0)
        Me.Step1_TimerLbl1.Name = "Step1_TimerLbl1"
        Me.Step1_TimerLbl1.Size = New System.Drawing.Size(57, 15)
        Me.Step1_TimerLbl1.TabIndex = 0
        Me.Step1_TimerLbl1.Text = "00:00:00"
        Me.Step1_TimerLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step1_TestLbl2
        '
        Me.Step1_TestLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step1_TestLbl2.Location = New System.Drawing.Point(308, 47)
        Me.Step1_TestLbl2.Name = "Step1_TestLbl2"
        Me.Step1_TestLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step1_TestLbl2.TabIndex = 0
        Me.Step1_TestLbl2.Text = "10000/10000"
        Me.Step1_TestLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step1_TestPBr1
        '
        Me.Step1_TestPBr1.Location = New System.Drawing.Point(106, 47)
        Me.Step1_TestPBr1.Name = "Step1_TestPBr1"
        Me.Step1_TestPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step1_TestPBr1.TabIndex = 0
        '
        'Step1_TestLbl1
        '
        Me.Step1_TestLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step1_TestLbl1.Location = New System.Drawing.Point(21, 46)
        Me.Step1_TestLbl1.Name = "Step1_TestLbl1"
        Me.Step1_TestLbl1.Size = New System.Drawing.Size(81, 13)
        Me.Step1_TestLbl1.TabIndex = 0
        Me.Step1_TestLbl1.Text = "Progress (Test):"
        Me.Step1_TestLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step1_TrainLbl2
        '
        Me.Step1_TrainLbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step1_TrainLbl2.Location = New System.Drawing.Point(308, 23)
        Me.Step1_TrainLbl2.Name = "Step1_TrainLbl2"
        Me.Step1_TrainLbl2.Size = New System.Drawing.Size(83, 13)
        Me.Step1_TrainLbl2.TabIndex = 0
        Me.Step1_TrainLbl2.Text = "10000/10000"
        Me.Step1_TrainLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Step1_TrainPBr1
        '
        Me.Step1_TrainPBr1.Location = New System.Drawing.Point(106, 23)
        Me.Step1_TrainPBr1.Name = "Step1_TrainPBr1"
        Me.Step1_TrainPBr1.Size = New System.Drawing.Size(198, 13)
        Me.Step1_TrainPBr1.TabIndex = 0
        '
        'Step1_TrainLbl1
        '
        Me.Step1_TrainLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Step1_TrainLbl1.Location = New System.Drawing.Point(21, 22)
        Me.Step1_TrainLbl1.Name = "Step1_TrainLbl1"
        Me.Step1_TrainLbl1.Size = New System.Drawing.Size(84, 13)
        Me.Step1_TrainLbl1.TabIndex = 0
        Me.Step1_TrainLbl1.Text = "Progress (Train):"
        Me.Step1_TrainLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewStatistics
        '
        Me.btnViewStatistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewStatistics.Location = New System.Drawing.Point(84, 17)
        Me.btnViewStatistics.Name = "btnViewStatistics"
        Me.btnViewStatistics.Size = New System.Drawing.Size(100, 23)
        Me.btnViewStatistics.TabIndex = 1
        Me.btnViewStatistics.Text = "View Statistics"
        Me.btnViewStatistics.UseVisualStyleBackColor = True
        '
        'btnExportPredictions
        '
        Me.btnExportPredictions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportPredictions.Location = New System.Drawing.Point(217, 17)
        Me.btnExportPredictions.Name = "btnExportPredictions"
        Me.btnExportPredictions.Size = New System.Drawing.Size(100, 23)
        Me.btnExportPredictions.TabIndex = 0
        Me.btnExportPredictions.Text = "Export Predictions"
        Me.btnExportPredictions.UseVisualStyleBackColor = True
        '
        'gbParameters
        '
        Me.gbParameters.Controls.Add(Me.gbStatistics)
        Me.gbParameters.Controls.Add(Me.gbClustering)
        Me.gbParameters.Controls.Add(Me.gbTrainSet)
        Me.gbParameters.Controls.Add(Me.lblParameters)
        Me.gbParameters.Controls.Add(Me.gbTestSet)
        Me.gbParameters.Controls.Add(Me.gbKeypointVectors)
        Me.gbParameters.Location = New System.Drawing.Point(3, 19)
        Me.gbParameters.Name = "gbParameters"
        Me.gbParameters.Size = New System.Drawing.Size(256, 481)
        Me.gbParameters.TabIndex = 0
        Me.gbParameters.TabStop = False
        '
        'gbStatistics
        '
        Me.gbStatistics.Controls.Add(Me.StatsPercentageNUpDn1)
        Me.gbStatistics.Controls.Add(Me.Label2)
        Me.gbStatistics.Controls.Add(Me.StatsFoldsNUpDn1)
        Me.gbStatistics.Controls.Add(Me.Label1)
        Me.gbStatistics.Controls.Add(Me.PercentageSplitRBtn1)
        Me.gbStatistics.Controls.Add(Me.CrossValidationRBtn1)
        Me.gbStatistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStatistics.Location = New System.Drawing.Point(3, 400)
        Me.gbStatistics.Name = "gbStatistics"
        Me.gbStatistics.Size = New System.Drawing.Size(250, 78)
        Me.gbStatistics.TabIndex = 4
        Me.gbStatistics.TabStop = False
        Me.gbStatistics.Text = "Classification statistics"
        '
        'StatsPercentageNUpDn1
        '
        Me.StatsPercentageNUpDn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatsPercentageNUpDn1.Location = New System.Drawing.Point(160, 49)
        Me.StatsPercentageNUpDn1.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.StatsPercentageNUpDn1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.StatsPercentageNUpDn1.Name = "StatsPercentageNUpDn1"
        Me.StatsPercentageNUpDn1.Size = New System.Drawing.Size(67, 20)
        Me.StatsPercentageNUpDn1.TabIndex = 13
        Me.StatsPercentageNUpDn1.Value = New Decimal(New Integer() {70, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(128, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatsFoldsNUpDn1
        '
        Me.StatsFoldsNUpDn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatsFoldsNUpDn1.Location = New System.Drawing.Point(160, 23)
        Me.StatsFoldsNUpDn1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.StatsFoldsNUpDn1.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.StatsFoldsNUpDn1.Name = "StatsFoldsNUpDn1"
        Me.StatsFoldsNUpDn1.Size = New System.Drawing.Size(67, 20)
        Me.StatsFoldsNUpDn1.TabIndex = 11
        Me.StatsFoldsNUpDn1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Folds"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PercentageSplitRBtn1
        '
        Me.PercentageSplitRBtn1.AutoSize = True
        Me.PercentageSplitRBtn1.Checked = True
        Me.PercentageSplitRBtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentageSplitRBtn1.Location = New System.Drawing.Point(22, 51)
        Me.PercentageSplitRBtn1.Name = "PercentageSplitRBtn1"
        Me.PercentageSplitRBtn1.Size = New System.Drawing.Size(101, 17)
        Me.PercentageSplitRBtn1.TabIndex = 12
        Me.PercentageSplitRBtn1.TabStop = True
        Me.PercentageSplitRBtn1.Text = "Percentage split"
        Me.PercentageSplitRBtn1.UseVisualStyleBackColor = True
        '
        'CrossValidationRBtn1
        '
        Me.CrossValidationRBtn1.AutoSize = True
        Me.CrossValidationRBtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrossValidationRBtn1.Location = New System.Drawing.Point(22, 25)
        Me.CrossValidationRBtn1.Name = "CrossValidationRBtn1"
        Me.CrossValidationRBtn1.Size = New System.Drawing.Size(99, 17)
        Me.CrossValidationRBtn1.TabIndex = 10
        Me.CrossValidationRBtn1.Text = "Cross-validation"
        Me.CrossValidationRBtn1.UseVisualStyleBackColor = True
        '
        'gbClustering
        '
        Me.gbClustering.Controls.Add(Me.L2_PercentageNUpDn1)
        Me.gbClustering.Controls.Add(Me.L1_PercentageNUpDn1)
        Me.gbClustering.Controls.Add(Me.L2_PercentageLbl1)
        Me.gbClustering.Controls.Add(Me.L1_PercentageLbl1)
        Me.gbClustering.Controls.Add(Me.lblLevel1Centres)
        Me.gbClustering.Controls.Add(Me.L2_CentresLbl1)
        Me.gbClustering.Controls.Add(Me.L2_CentersNUpDn1)
        Me.gbClustering.Controls.Add(Me.nudLevel1Centres)
        Me.gbClustering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbClustering.Location = New System.Drawing.Point(3, 256)
        Me.gbClustering.Name = "gbClustering"
        Me.gbClustering.Size = New System.Drawing.Size(250, 136)
        Me.gbClustering.TabIndex = 3
        Me.gbClustering.TabStop = False
        Me.gbClustering.Text = "Clustering"
        '
        'L2_PercentageNUpDn1
        '
        Me.L2_PercentageNUpDn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2_PercentageNUpDn1.Location = New System.Drawing.Point(160, 104)
        Me.L2_PercentageNUpDn1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L2_PercentageNUpDn1.Name = "L2_PercentageNUpDn1"
        Me.L2_PercentageNUpDn1.Size = New System.Drawing.Size(67, 20)
        Me.L2_PercentageNUpDn1.TabIndex = 8
        Me.L2_PercentageNUpDn1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'L1_PercentageNUpDn1
        '
        Me.L1_PercentageNUpDn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1_PercentageNUpDn1.Location = New System.Drawing.Point(160, 47)
        Me.L1_PercentageNUpDn1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L1_PercentageNUpDn1.Name = "L1_PercentageNUpDn1"
        Me.L1_PercentageNUpDn1.Size = New System.Drawing.Size(67, 20)
        Me.L1_PercentageNUpDn1.TabIndex = 6
        Me.L1_PercentageNUpDn1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'L2_PercentageLbl1
        '
        Me.L2_PercentageLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2_PercentageLbl1.Location = New System.Drawing.Point(12, 108)
        Me.L2_PercentageLbl1.Name = "L2_PercentageLbl1"
        Me.L2_PercentageLbl1.Size = New System.Drawing.Size(145, 13)
        Me.L2_PercentageLbl1.TabIndex = 8
        Me.L2_PercentageLbl1.Text = "Level 2 data percentage:"
        Me.L2_PercentageLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L1_PercentageLbl1
        '
        Me.L1_PercentageLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1_PercentageLbl1.Location = New System.Drawing.Point(12, 51)
        Me.L1_PercentageLbl1.Name = "L1_PercentageLbl1"
        Me.L1_PercentageLbl1.Size = New System.Drawing.Size(145, 13)
        Me.L1_PercentageLbl1.TabIndex = 7
        Me.L1_PercentageLbl1.Text = "Level 1 data percentage:"
        Me.L1_PercentageLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L2_CentresLbl1
        '
        Me.L2_CentresLbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2_CentresLbl1.Location = New System.Drawing.Point(12, 79)
        Me.L2_CentresLbl1.Name = "L2_CentresLbl1"
        Me.L2_CentresLbl1.Size = New System.Drawing.Size(145, 13)
        Me.L2_CentresLbl1.TabIndex = 0
        Me.L2_CentresLbl1.Text = "Level 2 centres count:"
        Me.L2_CentresLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L2_CentersNUpDn1
        '
        Me.L2_CentersNUpDn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2_CentersNUpDn1.Location = New System.Drawing.Point(160, 75)
        Me.L2_CentersNUpDn1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.L2_CentersNUpDn1.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.L2_CentersNUpDn1.Name = "L2_CentersNUpDn1"
        Me.L2_CentersNUpDn1.Size = New System.Drawing.Size(67, 20)
        Me.L2_CentersNUpDn1.TabIndex = 7
        Me.L2_CentersNUpDn1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'gbTrainSet
        '
        Me.gbTrainSet.Controls.Add(Me.nudTrainNumOfBusinesses)
        Me.gbTrainSet.Controls.Add(Me.lblTrainNumOfBusinesses)
        Me.gbTrainSet.Controls.Add(Me.nudTrainPhotosPerBusiness)
        Me.gbTrainSet.Controls.Add(Me.lblTrainPhotosPerBusiness)
        Me.gbTrainSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTrainSet.Location = New System.Drawing.Point(3, 37)
        Me.gbTrainSet.Name = "gbTrainSet"
        Me.gbTrainSet.Size = New System.Drawing.Size(250, 72)
        Me.gbTrainSet.TabIndex = 0
        Me.gbTrainSet.TabStop = False
        Me.gbTrainSet.Text = "Train set"
        '
        'nudTrainNumOfBusinesses
        '
        Me.nudTrainNumOfBusinesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTrainNumOfBusinesses.Location = New System.Drawing.Point(160, 18)
        Me.nudTrainNumOfBusinesses.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.nudTrainNumOfBusinesses.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTrainNumOfBusinesses.Name = "nudTrainNumOfBusinesses"
        Me.nudTrainNumOfBusinesses.Size = New System.Drawing.Size(67, 20)
        Me.nudTrainNumOfBusinesses.TabIndex = 0
        Me.nudTrainNumOfBusinesses.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblTrainNumOfBusinesses
        '
        Me.lblTrainNumOfBusinesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainNumOfBusinesses.Location = New System.Drawing.Point(12, 22)
        Me.lblTrainNumOfBusinesses.Name = "lblTrainNumOfBusinesses"
        Me.lblTrainNumOfBusinesses.Size = New System.Drawing.Size(145, 13)
        Me.lblTrainNumOfBusinesses.TabIndex = 0
        Me.lblTrainNumOfBusinesses.Text = "Number of businesses:"
        Me.lblTrainNumOfBusinesses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudTrainPhotosPerBusiness
        '
        Me.nudTrainPhotosPerBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTrainPhotosPerBusiness.Location = New System.Drawing.Point(160, 44)
        Me.nudTrainPhotosPerBusiness.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudTrainPhotosPerBusiness.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTrainPhotosPerBusiness.Name = "nudTrainPhotosPerBusiness"
        Me.nudTrainPhotosPerBusiness.Size = New System.Drawing.Size(67, 20)
        Me.nudTrainPhotosPerBusiness.TabIndex = 1
        Me.nudTrainPhotosPerBusiness.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblTrainPhotosPerBusiness
        '
        Me.lblTrainPhotosPerBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrainPhotosPerBusiness.Location = New System.Drawing.Point(12, 48)
        Me.lblTrainPhotosPerBusiness.Name = "lblTrainPhotosPerBusiness"
        Me.lblTrainPhotosPerBusiness.Size = New System.Drawing.Size(145, 13)
        Me.lblTrainPhotosPerBusiness.TabIndex = 0
        Me.lblTrainPhotosPerBusiness.Text = "Photos Pet Business:"
        Me.lblTrainPhotosPerBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParameters
        '
        Me.lblParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParameters.Location = New System.Drawing.Point(3, 10)
        Me.lblParameters.Name = "lblParameters"
        Me.lblParameters.Size = New System.Drawing.Size(250, 21)
        Me.lblParameters.TabIndex = 0
        Me.lblParameters.Text = "Parameters"
        Me.lblParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbTestSet
        '
        Me.gbTestSet.Controls.Add(Me.nudTestNumOfBusinesses)
        Me.gbTestSet.Controls.Add(Me.lblTestNumOfBusinesses)
        Me.gbTestSet.Controls.Add(Me.nudTestPhotosPerBusiness)
        Me.gbTestSet.Controls.Add(Me.lblTestPhotosPerBusiness)
        Me.gbTestSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTestSet.Location = New System.Drawing.Point(3, 117)
        Me.gbTestSet.Name = "gbTestSet"
        Me.gbTestSet.Size = New System.Drawing.Size(250, 75)
        Me.gbTestSet.TabIndex = 1
        Me.gbTestSet.TabStop = False
        Me.gbTestSet.Text = "Test set"
        '
        'nudTestNumOfBusinesses
        '
        Me.nudTestNumOfBusinesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTestNumOfBusinesses.Location = New System.Drawing.Point(160, 18)
        Me.nudTestNumOfBusinesses.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudTestNumOfBusinesses.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTestNumOfBusinesses.Name = "nudTestNumOfBusinesses"
        Me.nudTestNumOfBusinesses.Size = New System.Drawing.Size(67, 20)
        Me.nudTestNumOfBusinesses.TabIndex = 2
        Me.nudTestNumOfBusinesses.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblTestNumOfBusinesses
        '
        Me.lblTestNumOfBusinesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestNumOfBusinesses.Location = New System.Drawing.Point(12, 22)
        Me.lblTestNumOfBusinesses.Name = "lblTestNumOfBusinesses"
        Me.lblTestNumOfBusinesses.Size = New System.Drawing.Size(145, 13)
        Me.lblTestNumOfBusinesses.TabIndex = 0
        Me.lblTestNumOfBusinesses.Text = "Number of businesses:"
        Me.lblTestNumOfBusinesses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudTestPhotosPerBusiness
        '
        Me.nudTestPhotosPerBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTestPhotosPerBusiness.Location = New System.Drawing.Point(160, 44)
        Me.nudTestPhotosPerBusiness.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudTestPhotosPerBusiness.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTestPhotosPerBusiness.Name = "nudTestPhotosPerBusiness"
        Me.nudTestPhotosPerBusiness.Size = New System.Drawing.Size(67, 20)
        Me.nudTestPhotosPerBusiness.TabIndex = 3
        Me.nudTestPhotosPerBusiness.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblTestPhotosPerBusiness
        '
        Me.lblTestPhotosPerBusiness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestPhotosPerBusiness.Location = New System.Drawing.Point(12, 48)
        Me.lblTestPhotosPerBusiness.Name = "lblTestPhotosPerBusiness"
        Me.lblTestPhotosPerBusiness.Size = New System.Drawing.Size(145, 13)
        Me.lblTestPhotosPerBusiness.TabIndex = 0
        Me.lblTestPhotosPerBusiness.Text = "Photos for each business:"
        Me.lblTestPhotosPerBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbKeypointVectors
        '
        Me.gbKeypointVectors.Controls.Add(Me.lblKeypointsPerPicture)
        Me.gbKeypointVectors.Controls.Add(Me.nudKeypointsPerPicture)
        Me.gbKeypointVectors.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbKeypointVectors.Location = New System.Drawing.Point(3, 197)
        Me.gbKeypointVectors.Name = "gbKeypointVectors"
        Me.gbKeypointVectors.Size = New System.Drawing.Size(250, 48)
        Me.gbKeypointVectors.TabIndex = 2
        Me.gbKeypointVectors.TabStop = False
        Me.gbKeypointVectors.Text = "Keypoint vectors"
        '
        'lblKeypointsPerPicture
        '
        Me.lblKeypointsPerPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeypointsPerPicture.Location = New System.Drawing.Point(12, 22)
        Me.lblKeypointsPerPicture.Name = "lblKeypointsPerPicture"
        Me.lblKeypointsPerPicture.Size = New System.Drawing.Size(145, 13)
        Me.lblKeypointsPerPicture.TabIndex = 0
        Me.lblKeypointsPerPicture.Text = "Keypoints Per Picture:"
        Me.lblKeypointsPerPicture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudKeypointsPerPicture
        '
        Me.nudKeypointsPerPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudKeypointsPerPicture.Location = New System.Drawing.Point(160, 18)
        Me.nudKeypointsPerPicture.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudKeypointsPerPicture.Name = "nudKeypointsPerPicture"
        Me.nudKeypointsPerPicture.Size = New System.Drawing.Size(67, 20)
        Me.nudKeypointsPerPicture.TabIndex = 4
        Me.nudKeypointsPerPicture.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnResetDatabase)
        Me.GroupBox6.Controls.Add(Me.btnStart)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 495)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(256, 50)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'btnResetDatabase
        '
        Me.btnResetDatabase.Location = New System.Drawing.Point(12, 17)
        Me.btnResetDatabase.Name = "btnResetDatabase"
        Me.btnResetDatabase.Size = New System.Drawing.Size(100, 23)
        Me.btnResetDatabase.TabIndex = 14
        Me.btnResetDatabase.Text = "Reset Database"
        Me.btnResetDatabase.UseVisualStyleBackColor = True
        '
        'tmrUpdateStopwatches
        '
        Me.tmrUpdateStopwatches.Interval = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnViewStatistics)
        Me.GroupBox1.Controls.Add(Me.btnExportPredictions)
        Me.GroupBox1.Location = New System.Drawing.Point(261, 495)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 50)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'sfdSaveToCSV
        '
        Me.sfdSaveToCSV.Filter = "CSV Files|*.csv"
        Me.sfdSaveToCSV.Title = "Save the classification predictions"
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniFile})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(663, 24)
        Me.mnuMain.TabIndex = 17
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mniFile
        '
        Me.mniFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniSettings, Me.mniExit})
        Me.mniFile.Name = "mniFile"
        Me.mniFile.Size = New System.Drawing.Size(36, 20)
        Me.mniFile.Text = "File"
        '
        'mniSettings
        '
        Me.mniSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniSetTrainDirectory, Me.mniSetTestDirectory, Me.mniSetSQLConnectionString})
        Me.mniSettings.Name = "mniSettings"
        Me.mniSettings.Size = New System.Drawing.Size(118, 22)
        Me.mniSettings.Text = "&Settings"
        '
        'mniSetTrainDirectory
        '
        Me.mniSetTrainDirectory.Name = "mniSetTrainDirectory"
        Me.mniSetTrainDirectory.Size = New System.Drawing.Size(238, 22)
        Me.mniSetTrainDirectory.Text = "Set T&rain Directory"
        '
        'mniSetTestDirectory
        '
        Me.mniSetTestDirectory.Name = "mniSetTestDirectory"
        Me.mniSetTestDirectory.Size = New System.Drawing.Size(238, 22)
        Me.mniSetTestDirectory.Text = "Set T&est Directory"
        '
        'mniSetSQLConnectionString
        '
        Me.mniSetSQLConnectionString.Name = "mniSetSQLConnectionString"
        Me.mniSetSQLConnectionString.Size = New System.Drawing.Size(238, 22)
        Me.mniSetSQLConnectionString.Text = "Set the S&QL Connection String"
        '
        'mniExit
        '
        Me.mniExit.Name = "mniExit"
        Me.mniExit.Size = New System.Drawing.Size(118, 22)
        Me.mniExit.Text = "E&xit"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 547)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.gbParameters)
        Me.Controls.Add(Me.gbAlgorithmSteps)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMain
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yelp Restaurant Classification"
        CType(Me.nudLevel1Centres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAlgorithmSteps.ResumeLayout(False)
        Me.gbClassification.ResumeLayout(False)
        Me.gbFormingSingleVectorPerRestaurant.ResumeLayout(False)
        Me.gbLevel2Clustering.ResumeLayout(False)
        Me.gbFormingSingleVectorPerPhoto.ResumeLayout(False)
        Me.gbLevel1Clustering.ResumeLayout(False)
        Me.gbKeypointExtraction.ResumeLayout(False)
        Me.gbParameters.ResumeLayout(False)
        Me.gbStatistics.ResumeLayout(False)
        Me.gbStatistics.PerformLayout()
        CType(Me.StatsPercentageNUpDn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatsFoldsNUpDn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClustering.ResumeLayout(False)
        CType(Me.L2_PercentageNUpDn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L1_PercentageNUpDn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L2_CentersNUpDn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTrainSet.ResumeLayout(False)
        CType(Me.nudTrainNumOfBusinesses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTrainPhotosPerBusiness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTestSet.ResumeLayout(False)
        CType(Me.nudTestNumOfBusinesses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTestPhotosPerBusiness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbKeypointVectors.ResumeLayout(False)
        CType(Me.nudKeypointsPerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblAlgorithmSteps As System.Windows.Forms.Label
    Friend WithEvents nudLevel1Centres As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLevel1Centres As System.Windows.Forms.Label
    Friend WithEvents gbAlgorithmSteps As System.Windows.Forms.GroupBox
    Friend WithEvents gbParameters As System.Windows.Forms.GroupBox
    Friend WithEvents L2_CentersNUpDn1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L2_CentresLbl1 As System.Windows.Forms.Label
    Friend WithEvents gbTrainSet As System.Windows.Forms.GroupBox
    Friend WithEvents nudTrainNumOfBusinesses As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTrainNumOfBusinesses As System.Windows.Forms.Label
    Friend WithEvents nudTrainPhotosPerBusiness As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTrainPhotosPerBusiness As System.Windows.Forms.Label
    Friend WithEvents lblParameters As System.Windows.Forms.Label
    Friend WithEvents gbTestSet As System.Windows.Forms.GroupBox
    Friend WithEvents nudTestNumOfBusinesses As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTestNumOfBusinesses As System.Windows.Forms.Label
    Friend WithEvents nudTestPhotosPerBusiness As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTestPhotosPerBusiness As System.Windows.Forms.Label
    Friend WithEvents gbClustering As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetDatabase As System.Windows.Forms.Button
    Friend WithEvents gbKeypointVectors As System.Windows.Forms.GroupBox
    Friend WithEvents lblKeypointsPerPicture As System.Windows.Forms.Label
    Friend WithEvents nudKeypointsPerPicture As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbClassification As System.Windows.Forms.GroupBox
    Friend WithEvents gbFormingSingleVectorPerRestaurant As System.Windows.Forms.GroupBox
    Friend WithEvents gbLevel2Clustering As System.Windows.Forms.GroupBox
    Friend WithEvents gbFormingSingleVectorPerPhoto As System.Windows.Forms.GroupBox
    Friend WithEvents gbLevel1Clustering As System.Windows.Forms.GroupBox
    Friend WithEvents Step4_ProgressLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step3_TestLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step3_TrainPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step3_TestPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step3_TrainLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step3_TestLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step3_TrainLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step2_ProgressLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step6_ProgressLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step5_TestLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step5_TestPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step5_TrainPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step5_TrainLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step5_TestLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step5_TrainLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step6_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step5_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step4_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step3_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step2_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents btnExportPredictions As System.Windows.Forms.Button
    Friend WithEvents Step4_PBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step6_PBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step2_PBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tmrUpdateStopwatches As System.Windows.Forms.Timer
    Friend WithEvents gbKeypointExtraction As System.Windows.Forms.GroupBox
    Friend WithEvents Step1_TimerLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step1_TestLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step1_TestPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step1_TestLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step1_TrainLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step1_TrainPBr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Step1_TrainLbl1 As System.Windows.Forms.Label
    Friend WithEvents btnViewStatistics As System.Windows.Forms.Button
    Friend WithEvents Step4_ProgressLbl2 As System.Windows.Forms.Label
    Friend WithEvents Step2_ProgressLbl2 As System.Windows.Forms.Label
    Friend WithEvents L2_PercentageNUpDn1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L1_PercentageNUpDn1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L2_PercentageLbl1 As System.Windows.Forms.Label
    Friend WithEvents L1_PercentageLbl1 As System.Windows.Forms.Label
    Friend WithEvents Step6_ProgressLbl2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents sfdSaveToCSV As System.Windows.Forms.SaveFileDialog
    Friend WithEvents gbStatistics As System.Windows.Forms.GroupBox
    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mniFile As ToolStripMenuItem
    Friend WithEvents mniSettings As ToolStripMenuItem
    Friend WithEvents mniSetTrainDirectory As ToolStripMenuItem
    Friend WithEvents mniSetTestDirectory As ToolStripMenuItem
    Friend WithEvents mniExit As ToolStripMenuItem
    Friend WithEvents mniSetSQLConnectionString As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PercentageSplitRBtn1 As System.Windows.Forms.RadioButton
    Friend WithEvents CrossValidationRBtn1 As System.Windows.Forms.RadioButton
    Friend WithEvents StatsPercentageNUpDn1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatsFoldsNUpDn1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

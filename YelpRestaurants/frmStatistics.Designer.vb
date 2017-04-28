<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatistics))
        Me.TruePositivesLbl1 = New System.Windows.Forms.Label()
        Me.FalsePositivesLbl1 = New System.Windows.Forms.Label()
        Me.TrueNegativesLbl1 = New System.Windows.Forms.Label()
        Me.FalseNegativesLbl1 = New System.Windows.Forms.Label()
        Me.StatisticsGBx1 = New System.Windows.Forms.GroupBox()
        Me.FalseNegativesLbl2 = New System.Windows.Forms.Label()
        Me.TrueNegativesLbl2 = New System.Windows.Forms.Label()
        Me.FalsePositivesLbl2 = New System.Windows.Forms.Label()
        Me.TruePositivesLbl2 = New System.Windows.Forms.Label()
        Me.StatisticsGBx2 = New System.Windows.Forms.GroupBox()
        Me.FalseNegativesRateLbl2 = New System.Windows.Forms.Label()
        Me.TrueNegativesRateLbl2 = New System.Windows.Forms.Label()
        Me.FalsePositivesRateLbl2 = New System.Windows.Forms.Label()
        Me.TruePositivesRateLbl2 = New System.Windows.Forms.Label()
        Me.TruePositiveRateLbl1 = New System.Windows.Forms.Label()
        Me.FalseNegativeRateLbl1 = New System.Windows.Forms.Label()
        Me.FalsePositiveRateLbl1 = New System.Windows.Forms.Label()
        Me.TrueNegativeRateLbl1 = New System.Windows.Forms.Label()
        Me.FmeasureLbl2 = New System.Windows.Forms.Label()
        Me.PrecisionLbl2 = New System.Windows.Forms.Label()
        Me.ErrorRateLbl2 = New System.Windows.Forms.Label()
        Me.AccuracyLbl2 = New System.Windows.Forms.Label()
        Me.AccuracyLbl1 = New System.Windows.Forms.Label()
        Me.FmeasureLbl1 = New System.Windows.Forms.Label()
        Me.ErrorRateLbl1 = New System.Windows.Forms.Label()
        Me.PrecisionLbl1 = New System.Windows.Forms.Label()
        Me.StatisticsGBx3 = New System.Windows.Forms.GroupBox()
        Me.StatisticsBtn1 = New System.Windows.Forms.Button()
        Me.ExportBtn1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.StatisticsGBx1.SuspendLayout()
        Me.StatisticsGBx2.SuspendLayout()
        Me.StatisticsGBx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TruePositivesLbl1
        '
        Me.TruePositivesLbl1.Location = New System.Drawing.Point(33, 22)
        Me.TruePositivesLbl1.Name = "TruePositivesLbl1"
        Me.TruePositivesLbl1.Size = New System.Drawing.Size(91, 18)
        Me.TruePositivesLbl1.TabIndex = 0
        Me.TruePositivesLbl1.Text = "True positives:"
        Me.TruePositivesLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FalsePositivesLbl1
        '
        Me.FalsePositivesLbl1.Location = New System.Drawing.Point(33, 46)
        Me.FalsePositivesLbl1.Name = "FalsePositivesLbl1"
        Me.FalsePositivesLbl1.Size = New System.Drawing.Size(91, 18)
        Me.FalsePositivesLbl1.TabIndex = 1
        Me.FalsePositivesLbl1.Text = "False positives:"
        Me.FalsePositivesLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TrueNegativesLbl1
        '
        Me.TrueNegativesLbl1.Location = New System.Drawing.Point(33, 70)
        Me.TrueNegativesLbl1.Name = "TrueNegativesLbl1"
        Me.TrueNegativesLbl1.Size = New System.Drawing.Size(91, 18)
        Me.TrueNegativesLbl1.TabIndex = 2
        Me.TrueNegativesLbl1.Text = "True negatives:"
        Me.TrueNegativesLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FalseNegativesLbl1
        '
        Me.FalseNegativesLbl1.Location = New System.Drawing.Point(33, 94)
        Me.FalseNegativesLbl1.Name = "FalseNegativesLbl1"
        Me.FalseNegativesLbl1.Size = New System.Drawing.Size(91, 18)
        Me.FalseNegativesLbl1.TabIndex = 3
        Me.FalseNegativesLbl1.Text = "False negatives:"
        Me.FalseNegativesLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatisticsGBx1
        '
        Me.StatisticsGBx1.Controls.Add(Me.FalseNegativesLbl2)
        Me.StatisticsGBx1.Controls.Add(Me.TrueNegativesLbl2)
        Me.StatisticsGBx1.Controls.Add(Me.FalsePositivesLbl2)
        Me.StatisticsGBx1.Controls.Add(Me.TruePositivesLbl2)
        Me.StatisticsGBx1.Controls.Add(Me.TruePositivesLbl1)
        Me.StatisticsGBx1.Controls.Add(Me.FalseNegativesLbl1)
        Me.StatisticsGBx1.Controls.Add(Me.FalsePositivesLbl1)
        Me.StatisticsGBx1.Controls.Add(Me.TrueNegativesLbl1)
        Me.StatisticsGBx1.Location = New System.Drawing.Point(2, 2)
        Me.StatisticsGBx1.Name = "StatisticsGBx1"
        Me.StatisticsGBx1.Size = New System.Drawing.Size(198, 122)
        Me.StatisticsGBx1.TabIndex = 0
        Me.StatisticsGBx1.TabStop = False
        Me.StatisticsGBx1.Text = "Micro averaged statistics"
        '
        'FalseNegativesLbl2
        '
        Me.FalseNegativesLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FalseNegativesLbl2.Location = New System.Drawing.Point(125, 94)
        Me.FalseNegativesLbl2.Name = "FalseNegativesLbl2"
        Me.FalseNegativesLbl2.Size = New System.Drawing.Size(63, 18)
        Me.FalseNegativesLbl2.TabIndex = 7
        Me.FalseNegativesLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrueNegativesLbl2
        '
        Me.TrueNegativesLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TrueNegativesLbl2.Location = New System.Drawing.Point(125, 70)
        Me.TrueNegativesLbl2.Name = "TrueNegativesLbl2"
        Me.TrueNegativesLbl2.Size = New System.Drawing.Size(63, 18)
        Me.TrueNegativesLbl2.TabIndex = 6
        Me.TrueNegativesLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FalsePositivesLbl2
        '
        Me.FalsePositivesLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FalsePositivesLbl2.Location = New System.Drawing.Point(125, 46)
        Me.FalsePositivesLbl2.Name = "FalsePositivesLbl2"
        Me.FalsePositivesLbl2.Size = New System.Drawing.Size(63, 18)
        Me.FalsePositivesLbl2.TabIndex = 5
        Me.FalsePositivesLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TruePositivesLbl2
        '
        Me.TruePositivesLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TruePositivesLbl2.Location = New System.Drawing.Point(125, 22)
        Me.TruePositivesLbl2.Name = "TruePositivesLbl2"
        Me.TruePositivesLbl2.Size = New System.Drawing.Size(63, 18)
        Me.TruePositivesLbl2.TabIndex = 4
        Me.TruePositivesLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatisticsGBx2
        '
        Me.StatisticsGBx2.Controls.Add(Me.FalseNegativesRateLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.TrueNegativesRateLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.FalsePositivesRateLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.TruePositivesRateLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.TruePositiveRateLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.FalseNegativeRateLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.FalsePositiveRateLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.TrueNegativeRateLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.FmeasureLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.PrecisionLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.ErrorRateLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.AccuracyLbl2)
        Me.StatisticsGBx2.Controls.Add(Me.AccuracyLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.FmeasureLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.ErrorRateLbl1)
        Me.StatisticsGBx2.Controls.Add(Me.PrecisionLbl1)
        Me.StatisticsGBx2.Location = New System.Drawing.Point(202, 2)
        Me.StatisticsGBx2.Name = "StatisticsGBx2"
        Me.StatisticsGBx2.Size = New System.Drawing.Size(337, 122)
        Me.StatisticsGBx2.TabIndex = 1
        Me.StatisticsGBx2.TabStop = False
        Me.StatisticsGBx2.Text = "Statistics based on micro averaged values"
        '
        'FalseNegativesRateLbl2
        '
        Me.FalseNegativesRateLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FalseNegativesRateLbl2.Location = New System.Drawing.Point(265, 94)
        Me.FalseNegativesRateLbl2.Name = "FalseNegativesRateLbl2"
        Me.FalseNegativesRateLbl2.Size = New System.Drawing.Size(63, 18)
        Me.FalseNegativesRateLbl2.TabIndex = 15
        Me.FalseNegativesRateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrueNegativesRateLbl2
        '
        Me.TrueNegativesRateLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TrueNegativesRateLbl2.Location = New System.Drawing.Point(265, 70)
        Me.TrueNegativesRateLbl2.Name = "TrueNegativesRateLbl2"
        Me.TrueNegativesRateLbl2.Size = New System.Drawing.Size(63, 18)
        Me.TrueNegativesRateLbl2.TabIndex = 14
        Me.TrueNegativesRateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FalsePositivesRateLbl2
        '
        Me.FalsePositivesRateLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FalsePositivesRateLbl2.Location = New System.Drawing.Point(265, 46)
        Me.FalsePositivesRateLbl2.Name = "FalsePositivesRateLbl2"
        Me.FalsePositivesRateLbl2.Size = New System.Drawing.Size(63, 18)
        Me.FalsePositivesRateLbl2.TabIndex = 13
        Me.FalsePositivesRateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TruePositivesRateLbl2
        '
        Me.TruePositivesRateLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TruePositivesRateLbl2.Location = New System.Drawing.Point(265, 22)
        Me.TruePositivesRateLbl2.Name = "TruePositivesRateLbl2"
        Me.TruePositivesRateLbl2.Size = New System.Drawing.Size(63, 18)
        Me.TruePositivesRateLbl2.TabIndex = 12
        Me.TruePositivesRateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TruePositiveRateLbl1
        '
        Me.TruePositiveRateLbl1.Location = New System.Drawing.Point(157, 22)
        Me.TruePositiveRateLbl1.Name = "TruePositiveRateLbl1"
        Me.TruePositiveRateLbl1.Size = New System.Drawing.Size(107, 18)
        Me.TruePositiveRateLbl1.TabIndex = 8
        Me.TruePositiveRateLbl1.Text = "True positive rate:"
        Me.TruePositiveRateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FalseNegativeRateLbl1
        '
        Me.FalseNegativeRateLbl1.Location = New System.Drawing.Point(157, 94)
        Me.FalseNegativeRateLbl1.Name = "FalseNegativeRateLbl1"
        Me.FalseNegativeRateLbl1.Size = New System.Drawing.Size(107, 18)
        Me.FalseNegativeRateLbl1.TabIndex = 11
        Me.FalseNegativeRateLbl1.Text = "False negative rate:"
        Me.FalseNegativeRateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FalsePositiveRateLbl1
        '
        Me.FalsePositiveRateLbl1.Location = New System.Drawing.Point(157, 46)
        Me.FalsePositiveRateLbl1.Name = "FalsePositiveRateLbl1"
        Me.FalsePositiveRateLbl1.Size = New System.Drawing.Size(107, 18)
        Me.FalsePositiveRateLbl1.TabIndex = 9
        Me.FalsePositiveRateLbl1.Text = "False positive rate:"
        Me.FalsePositiveRateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TrueNegativeRateLbl1
        '
        Me.TrueNegativeRateLbl1.Location = New System.Drawing.Point(157, 70)
        Me.TrueNegativeRateLbl1.Name = "TrueNegativeRateLbl1"
        Me.TrueNegativeRateLbl1.Size = New System.Drawing.Size(107, 18)
        Me.TrueNegativeRateLbl1.TabIndex = 10
        Me.TrueNegativeRateLbl1.Text = "True negative rate:"
        Me.TrueNegativeRateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FmeasureLbl2
        '
        Me.FmeasureLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FmeasureLbl2.Location = New System.Drawing.Point(78, 94)
        Me.FmeasureLbl2.Name = "FmeasureLbl2"
        Me.FmeasureLbl2.Size = New System.Drawing.Size(63, 18)
        Me.FmeasureLbl2.TabIndex = 7
        Me.FmeasureLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrecisionLbl2
        '
        Me.PrecisionLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PrecisionLbl2.Location = New System.Drawing.Point(78, 70)
        Me.PrecisionLbl2.Name = "PrecisionLbl2"
        Me.PrecisionLbl2.Size = New System.Drawing.Size(63, 18)
        Me.PrecisionLbl2.TabIndex = 6
        Me.PrecisionLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorRateLbl2
        '
        Me.ErrorRateLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ErrorRateLbl2.Location = New System.Drawing.Point(78, 46)
        Me.ErrorRateLbl2.Name = "ErrorRateLbl2"
        Me.ErrorRateLbl2.Size = New System.Drawing.Size(63, 18)
        Me.ErrorRateLbl2.TabIndex = 5
        Me.ErrorRateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AccuracyLbl2
        '
        Me.AccuracyLbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AccuracyLbl2.Location = New System.Drawing.Point(78, 22)
        Me.AccuracyLbl2.Name = "AccuracyLbl2"
        Me.AccuracyLbl2.Size = New System.Drawing.Size(63, 18)
        Me.AccuracyLbl2.TabIndex = 4
        Me.AccuracyLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AccuracyLbl1
        '
        Me.AccuracyLbl1.Location = New System.Drawing.Point(6, 22)
        Me.AccuracyLbl1.Name = "AccuracyLbl1"
        Me.AccuracyLbl1.Size = New System.Drawing.Size(71, 18)
        Me.AccuracyLbl1.TabIndex = 0
        Me.AccuracyLbl1.Text = "Accuracy:"
        Me.AccuracyLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FmeasureLbl1
        '
        Me.FmeasureLbl1.Location = New System.Drawing.Point(6, 94)
        Me.FmeasureLbl1.Name = "FmeasureLbl1"
        Me.FmeasureLbl1.Size = New System.Drawing.Size(71, 18)
        Me.FmeasureLbl1.TabIndex = 3
        Me.FmeasureLbl1.Text = "F-measure:"
        Me.FmeasureLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErrorRateLbl1
        '
        Me.ErrorRateLbl1.Location = New System.Drawing.Point(6, 46)
        Me.ErrorRateLbl1.Name = "ErrorRateLbl1"
        Me.ErrorRateLbl1.Size = New System.Drawing.Size(71, 18)
        Me.ErrorRateLbl1.TabIndex = 1
        Me.ErrorRateLbl1.Text = "Error rate:"
        Me.ErrorRateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PrecisionLbl1
        '
        Me.PrecisionLbl1.Location = New System.Drawing.Point(6, 70)
        Me.PrecisionLbl1.Name = "PrecisionLbl1"
        Me.PrecisionLbl1.Size = New System.Drawing.Size(71, 18)
        Me.PrecisionLbl1.TabIndex = 2
        Me.PrecisionLbl1.Text = "Precision"
        Me.PrecisionLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatisticsGBx3
        '
        Me.StatisticsGBx3.Controls.Add(Me.StatisticsBtn1)
        Me.StatisticsGBx3.Controls.Add(Me.ExportBtn1)
        Me.StatisticsGBx3.Location = New System.Drawing.Point(2, 119)
        Me.StatisticsGBx3.Name = "StatisticsGBx3"
        Me.StatisticsGBx3.Size = New System.Drawing.Size(537, 50)
        Me.StatisticsGBx3.TabIndex = 8
        Me.StatisticsGBx3.TabStop = False
        '
        'StatisticsBtn1
        '
        Me.StatisticsBtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatisticsBtn1.Location = New System.Drawing.Point(324, 16)
        Me.StatisticsBtn1.Name = "StatisticsBtn1"
        Me.StatisticsBtn1.Size = New System.Drawing.Size(100, 23)
        Me.StatisticsBtn1.TabIndex = 0
        Me.StatisticsBtn1.Text = "Export statistics"
        Me.StatisticsBtn1.UseVisualStyleBackColor = True
        '
        'ExportBtn1
        '
        Me.ExportBtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportBtn1.Location = New System.Drawing.Point(430, 16)
        Me.ExportBtn1.Name = "ExportBtn1"
        Me.ExportBtn1.Size = New System.Drawing.Size(100, 23)
        Me.ExportBtn1.TabIndex = 1
        Me.ExportBtn1.Text = "Close"
        Me.ExportBtn1.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text Files|*.txt"
        Me.SaveFileDialog1.Title = "Save the statistics"
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 170)
        Me.Controls.Add(Me.StatisticsGBx2)
        Me.Controls.Add(Me.StatisticsGBx1)
        Me.Controls.Add(Me.StatisticsGBx3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmStatistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistics"
        Me.StatisticsGBx1.ResumeLayout(False)
        Me.StatisticsGBx2.ResumeLayout(False)
        Me.StatisticsGBx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TruePositivesLbl1 As System.Windows.Forms.Label
    Friend WithEvents FalsePositivesLbl1 As System.Windows.Forms.Label
    Friend WithEvents TrueNegativesLbl1 As System.Windows.Forms.Label
    Friend WithEvents FalseNegativesLbl1 As System.Windows.Forms.Label
    Friend WithEvents StatisticsGBx1 As System.Windows.Forms.GroupBox
    Friend WithEvents FalseNegativesLbl2 As System.Windows.Forms.Label
    Friend WithEvents TrueNegativesLbl2 As System.Windows.Forms.Label
    Friend WithEvents FalsePositivesLbl2 As System.Windows.Forms.Label
    Friend WithEvents TruePositivesLbl2 As System.Windows.Forms.Label
    Friend WithEvents StatisticsGBx2 As System.Windows.Forms.GroupBox
    Friend WithEvents FalseNegativesRateLbl2 As System.Windows.Forms.Label
    Friend WithEvents TrueNegativesRateLbl2 As System.Windows.Forms.Label
    Friend WithEvents FalsePositivesRateLbl2 As System.Windows.Forms.Label
    Friend WithEvents TruePositivesRateLbl2 As System.Windows.Forms.Label
    Friend WithEvents TruePositiveRateLbl1 As System.Windows.Forms.Label
    Friend WithEvents FalseNegativeRateLbl1 As System.Windows.Forms.Label
    Friend WithEvents FalsePositiveRateLbl1 As System.Windows.Forms.Label
    Friend WithEvents TrueNegativeRateLbl1 As System.Windows.Forms.Label
    Friend WithEvents FmeasureLbl2 As System.Windows.Forms.Label
    Friend WithEvents PrecisionLbl2 As System.Windows.Forms.Label
    Friend WithEvents ErrorRateLbl2 As System.Windows.Forms.Label
    Friend WithEvents AccuracyLbl2 As System.Windows.Forms.Label
    Friend WithEvents AccuracyLbl1 As System.Windows.Forms.Label
    Friend WithEvents FmeasureLbl1 As System.Windows.Forms.Label
    Friend WithEvents ErrorRateLbl1 As System.Windows.Forms.Label
    Friend WithEvents PrecisionLbl1 As System.Windows.Forms.Label
    Friend WithEvents StatisticsGBx3 As System.Windows.Forms.GroupBox
    Friend WithEvents StatisticsBtn1 As System.Windows.Forms.Button
    Friend WithEvents ExportBtn1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class

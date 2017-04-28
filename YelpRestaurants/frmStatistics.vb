Imports System.IO

Public Class frmStatistics

    Sub New(ByVal TruePositives As Integer, ByVal FalsePositives As Integer, ByVal TrueNegatives As Integer, ByVal FalseNegatives As Integer)
        InitializeComponent()

        TruePositivesLbl2.Text = TruePositives.ToString
        FalsePositivesLbl2.Text = FalsePositives.ToString
        TrueNegativesLbl2.Text = TrueNegatives.ToString
        FalseNegativesLbl2.Text = FalseNegatives.ToString

        Dim Accuracy1 As Double = (TruePositives + TrueNegatives) / (TruePositives + FalsePositives + TrueNegatives + FalseNegatives)
        Dim ErrorRate1 As Double = (FalsePositives + FalseNegatives) / (TruePositives + FalsePositives + TrueNegatives + FalseNegatives)
        Dim Precision1 As Double = TruePositives / (TruePositives + FalsePositives)
        Dim TruePositiveRate1 As Double = TruePositives / (TruePositives + FalseNegatives)
        Dim FalsePositiveRate1 As Double = FalsePositives / (FalsePositives + TrueNegatives)
        Dim TrueNegativeRate1 As Double = TrueNegatives / (TrueNegatives + FalsePositives)
        Dim FalseNegativeRate1 As Double = FalseNegatives / (FalseNegatives + TruePositives)
        Dim Fmeasure1 As Double = (2 * Precision1 * TruePositiveRate1) / (Precision1 + TruePositiveRate1)

        AccuracyLbl2.Text = FormatNumber(Accuracy1, 3)
        ErrorRateLbl2.Text = FormatNumber(ErrorRate1, 3)
        PrecisionLbl2.Text = FormatNumber(Precision1, 3)
        FmeasureLbl2.Text = FormatNumber(Fmeasure1, 3)
        TruePositivesRateLbl2.Text = FormatNumber(TruePositiveRate1, 3)
        FalsePositivesRateLbl2.Text = FormatNumber(FalsePositiveRate1, 3)
        TrueNegativesRateLbl2.Text = FormatNumber(TrueNegativeRate1, 3)
        FalseNegativesRateLbl2.Text = FormatNumber(FalseNegativeRate1, 3)
    End Sub

    Private Sub ExportBtn1_Click(sender As Object, e As EventArgs) Handles ExportBtn1.Click
        Me.Close()
    End Sub

    Private Sub StatisticsBtn1_Click(sender As Object, e As EventArgs) Handles StatisticsBtn1.Click
        SaveFileDialog1.ShowDialog()

        If SaveFileDialog1.FileName <> "" Then
            If File.Exists(SaveFileDialog1.FileName) = True Then
                File.Delete(SaveFileDialog1.FileName)
            End If

            Using StreamWriter1 As New StreamWriter(SaveFileDialog1.FileName)
                StreamWriter1.WriteLine(Me.Text)
                StreamWriter1.WriteLine("-----------------------------------------------------")
                StreamWriter1.WriteLine("True positives = " & TruePositivesLbl2.Text)
                StreamWriter1.WriteLine("True negatives = " & TrueNegativesLbl2.Text)
                StreamWriter1.WriteLine("False positives = " & FalsePositivesLbl2.Text)
                StreamWriter1.WriteLine("False negatives = " & FalseNegativesLbl2.Text)
                StreamWriter1.WriteLine("Accuracy = " & AccuracyLbl2.Text)
                StreamWriter1.WriteLine("ErrorRate = " & ErrorRateLbl2.Text)
                StreamWriter1.WriteLine("Precision = " & PrecisionLbl2.Text)
                StreamWriter1.WriteLine("F-measure = " & FmeasureLbl2.Text)
                StreamWriter1.WriteLine("True positives rate = " & TruePositivesRateLbl2.Text)
                StreamWriter1.WriteLine("False positives rate = " & FalsePositivesRateLbl2.Text)
                StreamWriter1.WriteLine("True negatives rate = " & TrueNegativesRateLbl2.Text)
                StreamWriter1.WriteLine("False negatives rate = " & FalseNegativesRateLbl2.Text)
                StreamWriter1.WriteLine("-----------------------------------------------------")

                StreamWriter1.Close()
            End Using

            MessageBox.Show("The export completed successfully", "Statistics export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

End Class
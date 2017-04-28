Imports System.Data.SqlClient

Public Class SqlFunctions
    Dim SqlConn As SqlConnection = Nothing
    Dim SQLConnectionString As String = My.Settings.SQLConnectionString1

    Sub New()
        SqlConn = New SqlConnection(SQLConnectionString)
        SqlConn.Open()
    End Sub

    Public Function ExecuteSQLQuery(ByVal QueryString As String, ByRef Error1 As String) As Boolean
        Try
            Dim SQLCmd As New SqlCommand(QueryString, SqlConn)
            SQLCmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetDataTableFromSQLQuery(ByVal Query1 As String, ByRef Error1 As String) As DataTable
        Dim Result1 As New DataTable

        Try
            Using SqlDAdap1 As New SqlDataAdapter(Query1, SqlConn)
                SqlDAdap1.Fill(Result1)
            End Using
        Catch ex As Exception
            Error1 = ex.Message

            If Not ex.InnerException Is Nothing Then
                Error1 &= vbCrLf & ex.InnerException.Message.ToString
            End If
        End Try

        Return Result1
    End Function

    Sub Dispose()
        If Not SqlConn Is Nothing Then
            SqlConn.Dispose()
            SqlConn.Dispose()
        End If
    End Sub

End Class
Imports System.Text
Imports System.Threading

Public Enum ModelMode
    Train = 1
    Test = 2
End Enum

Module modGlobal
    Public Sub RunSecurely(ByVal Action1 As Action, ByVal frm As Form)
        doMT(Action1, frm)
    End Sub
    Public Sub SecurelyExecute(ByVal Action1 As Action, ByVal frm As Form)
        doMT(Action1, frm)
    End Sub
    Public Sub doMT(ByVal Action1 As Action, ByVal frm As Form)
        Thread.Sleep(1)

        If frm.InvokeRequired = True Then
            frm.BeginInvoke(Action1)
        Else
            Action1()
        End If
    End Sub

    Public Function CopyTextToClipboard(ByVal text As String) As Boolean
        Try
            Dim a As New Thread(Sub()
                                    Try
                                        Clipboard.SetText(text)
                                    Catch ex As Exception
                                    End Try
                                End Sub)
            a.SetApartmentState(ApartmentState.STA)
            a.Start()
            a.Join() 'Wait for the thread to end
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function




#Region "ArrayBox"
#Region "T()"
    ' => T()
    Public Function ArrayBox(Of T)(ByVal TVar As T(), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", 1, True, TVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => T()
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal TVar As T(), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", 1, True, TVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => T()
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal TVar As T(), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, 0, True, TVar, , DefaultSpace)
        Return Result
    End Function
    'SplitOnNum => T()
    Public Function ArrayBox(Of T)(ByVal SplitOnNum As UInteger, ByVal TVar As T(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", SplitOnNum, True, TVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, Var => T()
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal SplitOnNum As UInteger, ByVal IgnoreNullValues As Boolean, ByVal TVar As T(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder

        If TVar IsNot Nothing Then
            For i = 0 To TVar.Length - 1
                If (TVar(i) IsNot Nothing AndAlso Not IsDBNull(TVar(i))) OrElse Not IgnoreNullValues Then   '        If the variable is something
                    Dim StringToBeAppended As String = StrInCaseOfNullValue
                    Try
                        StringToBeAppended = TVar(i).ToString
                    Catch ex As Exception
                    End Try

                    If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '      Numerise it if user asked it

                    If PrefixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotPrefixIfValueIsNumeric) Then ' If there is a Prefix set, and value isnt numeric OR, is numeric but prefixing is allowed
                        sbRet.Append(PrefixString) '                                                                                then append it before the actual value
                    End If

                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '         If we are to proceed normally,
                        sbRet.Append(StringToBeAppended) '                              Print the Value of TVar(i)
                    Else
                        sbRet.Append(StringToBeAppended.Replace("""", """""""")) '      Else, add 2 double-quotes before any double-quote character
                    End If

                    If SuffixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotSuffixIfValueIsNumeric) Then 'If there is a Suffix set, and value isnt numeric OR, is numeric but suffixing is allowed
                        sbRet.Append(SuffixString) '                                                                                    then append it after the actual value
                    End If

                    If AlwaysDelimitBeforeNewLine AndAlso DelimitationStr <> "" AndAlso i <> TVar.Length - 1 Then '      If Always Delimit And it isn't the last element of all
                        sbRet.Append(DelimitationStr) '                                                                 then Delimit it
                        If Not IgnoreDelimitSpace AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) Then sbRet.Append(DefaultSpace) 'Put a space if a space should be put

                    ElseIf DelimitationStr <> "" AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) AndAlso i <> TVar.Length - 1 Then ' if it should be delimited And it isn't the last element of the line
                        sbRet.Append(DelimitationStr) '                                                                                         then Delimit it
                        If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                                             Put a space if a space should be put
                    End If

                    If SplitOnNum <> 0 AndAlso (i + 1) Mod SplitOnNum = 0 AndAlso i <> TVar.Length - 1 Then 'If you separate them with NewLines and it is the last element of the line
                        sbRet.AppendLine() '                                                                then append a NewLine
                    End If
                End If
            Next

        End If

        Return sbRet.ToString
    End Function
#End Region

#Region "List(Of T)"
    ' => List(Of T)
    Public Function ArrayBox(Of T)(ByVal listTVar As List(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", 1, True, listTVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => List(Of T)
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal listTVar As List(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", 1, True, listTVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => List(Of T)
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal listTVar As List(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, 0, True, listTVar, , DefaultSpace)
        Return Result
    End Function
    'SplitOnNum => List(Of T)
    Public Function ArrayBox(Of T)(ByVal SplitOnNum As UInteger, ByVal listTVar As List(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", SplitOnNum, True, listTVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, listTVar => List(of T)
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal SplitOnNum As UInteger, ByVal IgnoreNullValues As Boolean, ByVal listTVar As List(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder

        If listTVar IsNot Nothing Then
            For i = 0 To listTVar.Count - 1
                If (listTVar.Item(i) IsNot Nothing AndAlso Not IsDBNull(listTVar.Item(i))) OrElse Not IgnoreNullValues Then   '   If the variable is something
                    Dim StringToBeAppended As String = StrInCaseOfNullValue
                    Try
                        StringToBeAppended = listTVar.Item(i).ToString
                    Catch ex As Exception
                    End Try

                    If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '      Numerise it if user asked it

                    If PrefixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotPrefixIfValueIsNumeric) Then ' If there is a Prefix set, and value isnt numeric OR, is numeric but prefixing is allowed
                        sbRet.Append(PrefixString) '                                                                                then append it before the actual value
                    End If

                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '         If we are to proceed normally,
                        sbRet.Append(StringToBeAppended) '                              Print the Value of listTVar(i)
                    Else
                        sbRet.Append(StringToBeAppended.Replace("""", """""""")) '      Else, add 2 double-quotes before any double-quote character
                    End If

                    If SuffixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotSuffixIfValueIsNumeric) Then 'If there is a Suffix set, and value isnt numeric OR, is numeric but suffixing is allowed
                        sbRet.Append(SuffixString) '                                                                                    then append it after the actual value
                    End If

                    If AlwaysDelimitBeforeNewLine AndAlso DelimitationStr <> "" AndAlso i <> listTVar.Count - 1 Then '       If Always Delimit And it isn't the last element of all
                        sbRet.Append(DelimitationStr) '                                                                 then Delimit it
                        If Not IgnoreDelimitSpace AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) Then sbRet.Append(DefaultSpace) ' Put a space if a space should be put

                    ElseIf DelimitationStr <> "" AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) AndAlso i <> listTVar.Count - 1 Then '  if it should be delimited And it isn't the last element of the line
                        sbRet.Append(DelimitationStr) '                                                                                         then Delimit it
                        If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                                             Put a space if a space should be put
                    End If

                    If SplitOnNum <> 0 AndAlso (i + 1) Mod SplitOnNum = 0 AndAlso i <> listTVar.Count - 1 Then '  If you separate them with NewLines and it is the last element of the line
                        sbRet.AppendLine() '                                                                then append a NewLine
                    End If
                End If
            Next

        End If

        Return sbRet.ToString
    End Function
#End Region

#Region "IEnumerable(Of T)"
    ' => IEnumerable(Of T)
    Public Function ArrayBox(Of T)(ByVal IETVar As IEnumerable(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", 1, True, IETVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => IEnumerable(Of T)
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal IETVar As IEnumerable(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", 1, True, IETVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => IEnumerable(Of T)
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal IETVar As IEnumerable(Of T), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, 0, True, IETVar, , DefaultSpace)
        Return Result
    End Function
    'SplitOnNum => IEnumerable(Of T)
    Public Function ArrayBox(Of T)(ByVal SplitOnNum As UInteger, ByVal IETVar As IEnumerable(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", SplitOnNum, True, IETVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, Var => IEnumerable(Of T)
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal SplitOnNum As UInteger, ByVal IgnoreNullValues As Boolean, ByVal IETVar As IEnumerable(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder

        If IETVar IsNot Nothing Then
            For i = 0 To IETVar.Count - 1
                If (IETVar(i) IsNot Nothing AndAlso Not IsDBNull(IETVar(i))) OrElse Not IgnoreNullValues Then   '   If the IEVariable is something
                    Dim StringToBeAppended As String = StrInCaseOfNullValue
                    Try
                        StringToBeAppended = IETVar(i).ToString
                    Catch ex As Exception
                    End Try

                    If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '      Numerise it if user asked it

                    If PrefixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotPrefixIfValueIsNumeric) Then ' If there is a Prefix set, and value isnt numeric OR, is numeric but prefixing is allowed
                        sbRet.Append(PrefixString) '                                                                                then append it before the actual value
                    End If

                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '         If we are to proceed normally,
                        sbRet.Append(StringToBeAppended) '                              Print the Value of IETVar(i)
                    Else
                        sbRet.Append(StringToBeAppended.Replace("""", """""""")) '      Else, add 2 double-quotes before any double-quote character
                    End If

                    If SuffixString <> "" AndAlso (Not IsNumeric(StringToBeAppended) OrElse Not DoNotSuffixIfValueIsNumeric) Then 'If there is a Suffix set, and value isnt numeric OR, is numeric but suffixing is allowed
                        sbRet.Append(SuffixString) '                                                                                    then append it after the actual value
                    End If

                    If AlwaysDelimitBeforeNewLine AndAlso DelimitationStr <> "" AndAlso i <> IETVar.Count - 1 Then '       If Always Delimit And it isn't the last element of all
                        sbRet.Append(DelimitationStr) '                                                                 then Delimit it
                        If Not IgnoreDelimitSpace AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) Then sbRet.Append(DefaultSpace) ' Put a space if a space should be put

                    ElseIf DelimitationStr <> "" AndAlso (SplitOnNum = 0 OrElse (i + 1) Mod SplitOnNum <> 0) AndAlso i <> IETVar.Count - 1 Then '  if it should be delimited And it isn't the last element of the line
                        sbRet.Append(DelimitationStr) '                                                                                         then Delimit it
                        If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                                             Put a space if a space should be put
                    End If

                    If SplitOnNum <> 0 AndAlso (i + 1) Mod SplitOnNum = 0 AndAlso i <> IETVar.Count - 1 Then '  If you separate them with NewLines and it is the last element of the line
                        sbRet.AppendLine() '                                                                then append a NewLine
                    End If
                End If
            Next

        End If

        Return sbRet.ToString
    End Function
#End Region

#Region "T1(), T2()"
    ' => [ T1(), T2() ]
    Public Function ArrayBox(Of T)(ByVal TArVar1 As T(), ByVal TArVar2 As T(), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, TArVar1, TArVar2)
        Return Result
    End Function
    'doNumeriseItems => [ T1(), T2() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal TArVar1 As T(), ByVal TArVar2 As T(), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, DelimitationStr, TArVar1, TArVar2)
        Return Result
    End Function
    'DefaultSpace => [ T1(), T2() ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal TArVar1 As T(), ByVal TArVar2 As T(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, TArVar1, TArVar2, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, var => [ T1(), T2() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal TArVar1 As T(), ByVal TArVar2 As T(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = "", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim Var1Length As Integer = TArVar1.Length
        Dim Var2Length As Integer = TArVar2.Length
        Dim MaxLength As Integer
        If Var1Length >= Var2Length Then MaxLength = Var1Length Else MaxLength = Var2Length

        For i = 0 To MaxLength - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ")

            If TArVar1.Length >= i AndAlso Not IsNothing(TArVar1) AndAlso Not IsDBNull(TArVar1) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(TArVar1(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(TArVar1(i).ToString)
                Else
                    sbRet.Append(TArVar1(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(TArVar1(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If DelimitationStr <> "" Then
                sbRet.Append(DelimitationStr)
                If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace)
            End If

            If TArVar2.Length >= i AndAlso Not IsNothing(TArVar2) AndAlso Not IsDBNull(TArVar2) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(TArVar2(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(TArVar2(i).ToString)
                Else
                    sbRet.Append(TArVar2(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(TArVar2(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If AlwaysDelimitBeforeNewLine AndAlso i <> MaxLength - 1 Then sbRet.Append(DelimitationStr)
            If i <> MaxLength - 1 Then sbRet.AppendLine()
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "List(Of T1), List(Of T2)"
    ' => [ List(Of T1), List(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal Var1 As List(Of T), ByVal ListTVar2 As List(Of T), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, Var1, ListTVar2)
        Return Result
    End Function
    'doNumeriseItems => [ List(Of T1), List(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal Var1 As List(Of T), ByVal ListTVar2 As List(Of T), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, DelimitationStr, Var1, ListTVar2)
        Return Result
    End Function
    'DefaultSpace => [ List(Of T1), List(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal Var1 As List(Of T), ByVal ListTVar2 As List(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, Var1, ListTVar2, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, var => [ List(of T1), List(of T2) ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal ListTVar1 As List(Of T), ByVal ListTVar2 As List(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim Var1Length As Integer = ListTVar1.Count
        Dim Var2Length As Integer = ListTVar2.Count
        Dim MaxLength As Integer
        If Var1Length >= Var2Length Then MaxLength = Var1Length Else MaxLength = Var2Length

        For i = 0 To MaxLength - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ")

            If ListTVar1.Count >= i AndAlso Not IsNothing(ListTVar1) AndAlso Not IsDBNull(ListTVar1) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(ListTVar1.Item(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(ListTVar1.Item(i).ToString)
                Else
                    sbRet.Append(ListTVar1.Item(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(ListTVar1.Item(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If DelimitationStr <> "" Then
                sbRet.Append(DelimitationStr)
                If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace)
            End If

            If ListTVar2.Count >= i AndAlso Not IsNothing(ListTVar2) AndAlso Not IsDBNull(ListTVar2) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(ListTVar2.Item(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(ListTVar2.Item(i).ToString)
                Else
                    sbRet.Append(ListTVar2.Item(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(ListTVar2.Item(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If AlwaysDelimitBeforeNewLine AndAlso i <> MaxLength - 1 Then sbRet.Append(DelimitationStr)
            If i <> MaxLength - 1 Then sbRet.AppendLine()
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "IEnumerable(Of T1), IEnumerable(Of T2)"
    ' => [ IEnumerable(Of T1), IEnumerable(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal IETVar1 As IEnumerable(Of T), ByVal IETVar2 As IEnumerable(Of T), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, IETVar1, IETVar2)
        Return Result
    End Function
    'doNumeriseItems => [ IEnumerable(Of T1), IEnumerable(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal IETVar1 As IEnumerable(Of T), ByVal IETVar2 As IEnumerable(Of T), Optional ByVal DelimitationStr As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, DelimitationStr, IETVar1, IETVar2)
        Return Result
    End Function
    'DefaultSpace => [ IEnumerable(Of T1), IEnumerable(Of T2) ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal IETVar1 As IEnumerable(Of T), ByVal IETVar2 As IEnumerable(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, IETVar1, IETVar2, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, var => [ IEnumerable(of T1), IEnumerable(of T2) ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal IETVar1 As IEnumerable(Of T), ByVal IETVar2 As IEnumerable(Of T), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim Var1Length As Integer = IETVar1.Count
        Dim Var2Length As Integer = IETVar2.Count
        Dim MaxLength As Integer
        If Var1Length >= Var2Length Then MaxLength = Var1Length Else MaxLength = Var2Length

        For i = 0 To MaxLength - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ")

            If IETVar1.Count >= i AndAlso Not IsNothing(IETVar1) AndAlso Not IsDBNull(IETVar1) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(IETVar1(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(IETVar1(i).ToString)
                Else
                    sbRet.Append(IETVar1(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(IETVar1(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If DelimitationStr <> "" Then
                sbRet.Append(DelimitationStr)
                If Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace)
            End If

            If IETVar2.Count >= i AndAlso Not IsNothing(IETVar2) AndAlso Not IsDBNull(IETVar2) Then
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse Not IsNumeric(IETVar2(i).ToString)) Then sbRet.Append(PrefixString)

                If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then
                    sbRet.Append(IETVar2(i).ToString)
                Else
                    sbRet.Append(IETVar2(i).ToString.Replace("""", """"""""))
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse Not IsNumeric(IETVar2(i).ToString)) Then sbRet.Append(SuffixString)

            Else
                If PrefixString <> "" Then sbRet.Append(PrefixString)
                sbRet.Append(StrInCaseOfNullValue)
                If SuffixString <> "" Then sbRet.Append(SuffixString)
            End If

            If AlwaysDelimitBeforeNewLine AndAlso i <> MaxLength - 1 Then sbRet.Append(DelimitationStr)
            If i <> MaxLength - 1 Then sbRet.AppendLine()
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "T()()"
    ' => [ T()() ]
    Public Function ArrayBox(Of T)(ByVal ArArTVar As T()(), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", ArArTVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => [ T()() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal ArArTVar As T()(), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", ArArTVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => [ T()() ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal ArArTVar As T()(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, ArArTVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, ArArTVar => [ T()() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal ArArTVar As T()(), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim LastRowIndex As Integer

        For i = 0 To ArArTVar.Length - 1
            If ArArTVar(i).Length > LastRowIndex Then LastRowIndex = ArArTVar(i).Length '                                     Finding which the index-number of the row with the most elements in it
        Next

        For i = 0 To LastRowIndex - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '                                                                      Numerise the element if it should

            For j = 0 To ArArTVar.Length - 1
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse IsNothing(ArArTVar(j)(i)) OrElse IsDBNull(ArArTVar(j)(i)) OrElse Not IsNumeric(ArArTVar(j)(i).ToString)) Then
                    sbRet.Append(PrefixString) 'If there is a PrefixString and either we don't care whether it is a number or not, or it isn't number anyway, then prefix it
                End If

                If ArArTVar(j).Length > i AndAlso Not IsNothing(ArArTVar(j)(i)) AndAlso Not IsDBNull(ArArTVar(j)(i)) Then 'If there is an element
                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '                                                             If everything should be printed normally
                        sbRet.Append(ArArTVar(j)(i).ToString) '                                                                             Print the actual element
                    Else
                        sbRet.Append(ArArTVar(j)(i).ToString.Replace("""", """""""")) '                                                     Else put 2 double-quotes b4 every double-quote
                    End If

                Else
                    sbRet.Append(StrInCaseOfNullValue) '         If there isn't then just put a space
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse IsNothing(ArArTVar(j)(i)) OrElse IsDBNull(ArArTVar(j)(i)) OrElse Not IsNumeric(ArArTVar(j)(i).ToString)) Then
                    sbRet.Append(SuffixString) 'If there is a SuffixString and either we don't care whether it is a number or not, or it isn't number anyway, then Suffix it
                End If

                If DelimitationStr <> "" Then
                    If j <> ArArTVar.Length - 1 OrElse (AlwaysDelimitBeforeNewLine AndAlso i <> LastRowIndex) Then sbRet.Append(DelimitationStr) 'If it isn't the last element on the line, or it is but we should always delimit
                    If j <> ArArTVar.Length - 1 AndAlso Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                  Also put a space after delimitation if should be
                End If
            Next

            If i <> LastRowIndex - 1 Then sbRet.AppendLine() '                                                                              New line to separate previous row from new one
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "List(Of T())"
    ' => [ List(Of T()) ]
    Public Function ArrayBox(Of T)(ByVal listTArVar As List(Of T()), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", listTArVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal listTArVar As List(Of T()), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", listTArVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal listTArVar As List(Of T()), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, listTArVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, listTArVar => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal listTArVar As List(Of T()), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim LastRowIndex As Integer

        For i = 0 To listTArVar.Count - 1
            If listTArVar.Item(i).Length > LastRowIndex Then LastRowIndex = listTArVar.Item(i).Length '                                     Finding which the index-number of the row with the most elements in it
        Next

        For i = 0 To LastRowIndex - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '                                                                      Numerise the element if it should

            For j = 0 To listTArVar.Count - 1
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse IsNothing(listTArVar.Item(j)(i)) OrElse IsDBNull(listTArVar.Item(j)(i)) OrElse Not IsNumeric(listTArVar.Item(j)(i).ToString)) Then
                    sbRet.Append(PrefixString) 'If there is a PrefixString and either we don't care whether it is a number or not, or it isn't number anyway, then prefix it
                End If

                If listTArVar.Item(j).Length > i AndAlso Not IsNothing(listTArVar(j)(i)) AndAlso Not IsDBNull(listTArVar(j)(i)) Then 'If there is an element
                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '                                                             If everything should be printed normally
                        sbRet.Append(listTArVar.Item(j)(i).ToString) '                                                                             Print the actual element
                    Else
                        sbRet.Append(listTArVar.Item(j)(i).ToString.Replace("""", """""""")) '                                                     Else put 2 double-quotes b4 every double-quote
                    End If

                Else
                    sbRet.Append(StrInCaseOfNullValue) '         If ther isn't then just put a space
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse IsNothing(listTArVar.Item(j)(i)) OrElse IsDBNull(listTArVar.Item(j)(i)) OrElse Not IsNumeric(listTArVar.Item(j)(i).ToString)) Then
                    sbRet.Append(SuffixString) 'If there is a SuffixString and either we don't care whether it is a number or not, or it isn't number anyway, then Suffix it
                End If

                If DelimitationStr <> "" Then
                    If j <> listTArVar.Count - 1 OrElse (AlwaysDelimitBeforeNewLine AndAlso i <> LastRowIndex) Then sbRet.Append(DelimitationStr) 'If it isnt the last element on the line, or it is but we should always delimit
                    If j <> listTArVar.Count - 1 AndAlso Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                  Also put a space after delimitation if should be
                End If
            Next

            If i <> LastRowIndex - 1 Then sbRet.AppendLine() '                                                                              New line to separate previous row from new one
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "List(Of List(of T))"
    ' => [ List(Of List(of T)) ]
    Public Function ArrayBox(Of T)(ByVal ListListTVar As List(Of List(Of T)), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", ListListTVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal ListListTVar As List(Of List(Of T)), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", ListListTVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal ListListTVar As List(Of List(Of T)), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, ListListTVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, ListListTVar => [ List(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal ListListTVar As List(Of List(Of T)), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim LastRowIndex As Integer

        For i = 0 To ListListTVar.Count - 1
            If ListListTVar.Item(i).Count > LastRowIndex Then LastRowIndex = ListListTVar.Item(i).Count '                                     Finding which the index-number of the row with the most elements in it
        Next

        For j = 0 To ListListTVar.Count - 1
            If doNumeriseItems Then sbRet.Append(j + 1).Append(") ") '                                                                      Numerise the element if it should

            For i = 0 To LastRowIndex - 1
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse IsNothing(ListListTVar.Item(j)(i)) OrElse IsDBNull(ListListTVar.Item(j)(i)) OrElse Not IsNumeric(ListListTVar.Item(j)(i).ToString)) Then
                    sbRet.Append(PrefixString) 'If there is a PrefixString and either we don't care whether it is a number or not, or it isn't number anyway, then prefix it
                End If

                If ListListTVar.Item(j).Count > i AndAlso Not IsNothing(ListListTVar(j)(i)) AndAlso Not IsDBNull(ListListTVar(j)(i)) Then 'If there is an element
                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '                                                             If everything should be printed normally
                        sbRet.Append(ListListTVar.Item(j)(i).ToString) '                                                                             Print the actual element
                    Else
                        sbRet.Append(ListListTVar.Item(j)(i).ToString.Replace("""", """""""")) '                                                     Else put 2 double-quotes b4 every double-quote
                    End If

                Else
                    sbRet.Append(StrInCaseOfNullValue) '         If there isn't then just put a space
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse IsNothing(ListListTVar.Item(j)(i)) OrElse IsDBNull(ListListTVar.Item(j)(i)) OrElse Not IsNumeric(ListListTVar.Item(j)(i).ToString)) Then
                    sbRet.Append(SuffixString) 'If there is a SuffixString and either we don't care whether it is a number or not, or it isn't number anyway, then Suffix it
                End If

                If DelimitationStr <> "" Then
                    If i <> LastRowIndex - 1 OrElse (AlwaysDelimitBeforeNewLine AndAlso i <> LastRowIndex) Then sbRet.Append(DelimitationStr) 'If it isn't the last element on the line, or it is but we should always delimit
                    If i <> LastRowIndex - 1 AndAlso Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                  Also put a space after delimitation if should be
                End If
            Next

            If j <> ListListTVar.Count - 1 Then sbRet.AppendLine() '                                                                              New line to separate previous row from new one
        Next

        Return sbRet.ToString
    End Function
#End Region

#Region "IEnumerable(Of T())"
    ' => [ IEnumerable(Of T()) ]
    Public Function ArrayBox(Of T)(ByVal IEArTVar As IEnumerable(Of T()), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, "", IEArTVar, , DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems => [ IEnumerable(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal IEArTVar As IEnumerable(Of T()), Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(doNumeriseItems, "", IEArTVar, , DefaultSpace)
        Return Result
    End Function
    'DelimitationStr => [ IEnumerable(Of T() ]
    Public Function ArrayBox(Of T)(ByVal DelimitationStr As String, ByVal IEArTVar As IEnumerable(Of T()), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ") As String
        Dim Result As String = ArrayBox(False, DelimitationStr, IEArTVar, IgnoreDelimitSpace, DefaultSpace)
        Return Result
    End Function
    'doNumeriseItems, DelimitationStr, SplitOnNum, IgnoreNullValues, IEArTVar => [ IEnumerable(Of T() ]
    Public Function ArrayBox(Of T)(ByVal doNumeriseItems As Boolean, ByVal DelimitationStr As String, ByVal IEArTVar As IEnumerable(Of T()), Optional ByVal IgnoreDelimitSpace As Boolean = False, Optional ByVal DefaultSpace As String = " ", Optional ByVal AlwaysDelimitBeforeNewLine As Boolean = False, Optional ByVal PrefixString As String = "", Optional ByVal SuffixString As String = "", Optional DoNotPrefixIfValueIsNumeric As Boolean = False, Optional DoNotSuffixIfValueIsNumeric As Boolean = False, Optional ByVal AddTwoDoubleQuotesBeforeADoubleQuoteCharacter As Boolean = False, Optional ByVal StrInCaseOfNullValue As String = " ") As String
        Dim sbRet As New StringBuilder
        Dim LastRowIndex As Integer

        For i = 0 To IEArTVar.Count - 1
            If IEArTVar(i).Length > LastRowIndex Then LastRowIndex = IEArTVar(i).Length '                                     Finding which the index-number of the row with the most elements in it
        Next

        For i = 0 To LastRowIndex - 1
            If doNumeriseItems Then sbRet.Append(i + 1).Append(") ") '                                                                      Numerise the element if it should

            For j = 0 To IEArTVar.Count - 1
                If PrefixString <> "" AndAlso (Not DoNotPrefixIfValueIsNumeric OrElse IsNothing(IEArTVar(j)(i)) OrElse IsDBNull(IEArTVar(j)(i)) OrElse Not IsNumeric(IEArTVar(j)(i).ToString)) Then
                    sbRet.Append(PrefixString) 'If there is a PrefixString and either we don't care whether it is a number or not, or it isn't number anyway, then prefix it
                End If

                If IEArTVar(j).Length > i AndAlso Not IsNothing(IEArTVar(j)(i)) AndAlso Not IsDBNull(IEArTVar(j)(i)) Then 'If there is an element
                    If Not AddTwoDoubleQuotesBeforeADoubleQuoteCharacter Then '                                                             If everything should be printed normally
                        sbRet.Append(IEArTVar(j)(i).ToString) '                                                                             Print the actual element
                    Else
                        sbRet.Append(IEArTVar(j)(i).ToString.Replace("""", """""""")) '                                                     Else put 2 double-quotes b4 every double-quote
                    End If

                Else
                    sbRet.Append(StrInCaseOfNullValue) '         If ther isn't then just put a space
                End If

                If SuffixString <> "" AndAlso (Not DoNotSuffixIfValueIsNumeric OrElse IsNothing(IEArTVar(j)(i)) OrElse IsDBNull(IEArTVar(j)(i)) OrElse Not IsNumeric(IEArTVar(j)(i).ToString)) Then
                    sbRet.Append(SuffixString) 'If there is a SuffixString and either we don't care whether it is a number or not, or it isn't number anyway, then Suffix it
                End If

                If DelimitationStr <> "" Then
                    If j <> IEArTVar.Count - 1 OrElse (AlwaysDelimitBeforeNewLine AndAlso i <> LastRowIndex) Then sbRet.Append(DelimitationStr) 'If it isnt the last element on the line, or it is but we should always delimit
                    If j <> IEArTVar.Count - 1 AndAlso Not IgnoreDelimitSpace Then sbRet.Append(DefaultSpace) '                                  Also put a space after delimitation if should be
                End If
            Next

            If i <> LastRowIndex - 1 Then sbRet.AppendLine() '                                                                              New line to separate previous row from new one
        Next

        Return sbRet.ToString
    End Function
#End Region
#End Region


End Module

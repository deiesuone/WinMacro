Public Class UtilValidate

#Region "静的メソッド"

    ''' <summary>
    ''' 指定文字列をIntegerにパースする
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ParseInteger(val As String) As Integer

        Dim result As Integer

        Integer.TryParse(val, result)

        Return result

    End Function

    ''' <summary>
    ''' 指定文字列をmin,maxの範囲内でパースする
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ParseInteger(val As String, min As Integer, max As Integer) As Integer

        Dim result As Integer

        Integer.TryParse(val, result)

        If min > result Or result > max Then

            Return min

        End If

        Return result

    End Function

    ''' <summary>
    ''' 指定文字列をカラー用文字列にパースする
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseColor(val As String) As String

        If System.Text.RegularExpressions.Regex.IsMatch(val, "[0-9a-fA-F]{6}") Then
            Return val.ToUpper
        Else
            Return "FFFFFF"
        End If

    End Function

#End Region

End Class

<Serializable> _
Public Class PartsConditions001Data
    Implements IPartsData

#Region "Enum"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CmbConditionsTypes

        ''' <summary>
        ''' 座標Aの色A'
        ''' </summary>
        ''' <remarks></remarks>
        PointAColorAd

        ''' <summary>
        ''' 現在座標の色A'
        ''' </summary>
        ''' <remarks></remarks>
        PointNowColorAd

        ''' <summary>
        ''' 必ず実行
        ''' </summary>
        ''' <remarks></remarks>
        AlwaysExecuted

    End Enum

#End Region
    
#Region "プロパティ"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CmbConditionsType As CmbConditionsTypes = CmbConditionsTypes.PointAColorAd

    ''' <summary>
    ''' 座標AのX
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtAX As Integer = 0

    ''' <summary>
    ''' 座標AのY
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtAY As Integer = 0

    ''' <summary>
    ''' 色AのRGB
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtARGB As String = "FFFFFF"

    ''' <summary>
    ''' グリッドに表示する詳細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayString As String Implements IPartsData.DisplayString

        Get

            Dim ret As String = String.Empty

            Select Case Me.CmbConditionsType

                Case CmbConditionsTypes.PointAColorAd

                    ret = String.Concat("座標(", Me.TxtAX, ", ", Me.TxtAY, ")が色#", Me.TxtARGB, "の時、")

                Case CmbConditionsTypes.PointNowColorAd

                    ret = String.Concat("現在座標が色#", Me.TxtARGB, "の時、")

                Case CmbConditionsTypes.AlwaysExecuted

                    ret = "必ず実行する、"

            End Select

            Return ret
        End Get

    End Property

    ''' <summary>
    ''' 動作
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConditions() As Boolean

        Select Case Me.CmbConditionsType

            Case PartsConditions001Data.CmbConditionsTypes.PointAColorAd

                If Not Me.TxtARGB = UtilMacro.GetCursorRGB(New System.Drawing.Point(Me.TxtAX, Me.TxtAY)).ToString.Substring(3, 6) Then Return False

            Case PartsConditions001Data.CmbConditionsTypes.PointNowColorAd

                If Not Me.TxtARGB = UtilMacro.GetCursorRGB().ToString.Substring(3, 6) Then Return False

            Case PartsConditions001Data.CmbConditionsTypes.AlwaysExecuted

                Return True

        End Select

        Return True

    End Function

#End Region

End Class

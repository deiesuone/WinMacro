<Serializable> _
Public Class PartsConditions002Data
    Implements IPartsData

#Region "Enum"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CmbConditionsTypes

        ''' <summary>
        ''' かつ
        ''' </summary>
        ''' <remarks></remarks>
        ConditionsAnd

        ''' <summary>
        ''' または
        ''' </summary>
        ''' <remarks></remarks>
        ConditionsOr

    End Enum

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' コンボボックスの値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CmbConditionsType As CmbConditionsTypes = CmbConditionsTypes.ConditionsAnd

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

                Case CmbConditionsTypes.ConditionsAnd

                    ret = "かつ、"

                Case CmbConditionsTypes.ConditionsOr

                    ret = "または、"

            End Select

            Return ret

        End Get

    End Property

    ''' <summary>
    ''' 動作
    ''' </summary>
    ''' <param name="con1"></param>
    ''' <param name="con2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConditions(con1 As Boolean, con2 As Boolean) As Boolean

        Select Case Me.CmbConditionsType

            Case CmbConditionsTypes.ConditionsAnd

                Return con1 And con2

            Case CmbConditionsTypes.ConditionsOr

                Return con1 Or con2

        End Select

        Return False

    End Function

#End Region

End Class

Imports System.ComponentModel

<Serializable> _
Public Class PartsTiming001Data
    Implements IPartsData

#Region "プロパティ"

    ''' <summary>
    ''' 待つ時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TxtInterval As Integer = 5000

    ''' <summary>
    ''' 表示用文言を返す。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayString As String Implements IPartsData.DisplayString

        Get

            If Me.TxtInterval = 0 Then

                Return String.Empty

            Else

                Return String.Concat("実行まで", Me.TxtInterval, "ミリ秒待つ。")

            End If

        End Get

    End Property

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' 動作
    ''' キャンセルがあったかどうかを判定しながら指定時間待つ
    ''' </summary>
    ''' <param name="bgw"></param>
    ''' <param name="notch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Wait(bgw As BackgroundWorker, Optional notch As Integer = 100) As Boolean

        ' 待機する時間は100ミリ秒づつ分けて、そのタイミングでキャンセル判定を行う
        Dim interval = Me.TxtInterval

        Do While (interval > 0)

            If interval < notch Then

                System.Threading.Thread.Sleep(interval)

            Else

                System.Threading.Thread.Sleep(notch)

            End If

            If bgw.CancellationPending Then

                Return False

            End If

            interval -= notch

        Loop

        Return True

    End Function

#End Region

End Class

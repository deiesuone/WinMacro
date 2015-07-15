Public Interface IParts

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PartsData As IPartsData

    ''' <summary>
    ''' ヘッダー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Header As String

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 入力データ取得
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetData()

    ''' <summary>
    ''' 入力データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Sub GetData()

#End Region

End Interface

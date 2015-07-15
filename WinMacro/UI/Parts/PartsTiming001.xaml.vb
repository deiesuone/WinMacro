Public Class PartsTiming001
    Implements IParts

#Region "プロパティ"

    ''' <summary>
    ''' 入力データ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartsData As IPartsData Implements IParts.PartsData

    ''' <summary>
    ''' ヘッダー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Header As String Implements IParts.Header

        Get

            Return Me.GrpTiming.Header

        End Get

        Set(value As String)

            Me.GrpTiming.Header = value

        End Set

    End Property

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.PartsData = New PartsTiming001Data

    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' 引数で初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(parts_data As PartsTiming001Data)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Me.PartsData = parts_data

    End Sub

#End Region

#Region "公開メソッド"

    ''' <summary>
    ''' データをコントロールに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData() Implements IParts.GetData

        With DirectCast(Me.PartsData, PartsTiming001Data)

            Me.TxtInterval.Text = UtilValidate.ParseInteger(.TxtInterval)

        End With

    End Sub

    ''' <summary>
    ''' データをコントロールに反映
    ''' 引数を所持データに用いる
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub GetData(parts_data As PartsTiming001Data)

        Me.PartsData = parts_data

        Me.GetData()

    End Sub

    ''' <summary>
    ''' コントロールをデータに反映
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetData() Implements IParts.SetData

        With DirectCast(Me.PartsData, PartsTiming001Data)

            .TxtInterval = UtilValidate.ParseInteger(Me.TxtInterval.Text, 0, Int32.MaxValue)

        End With

    End Sub

#End Region

End Class

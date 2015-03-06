Imports System.Windows.Forms

Public Class replaceDialog


    Private Sub FindNextButton_Click(sender As Object, e As EventArgs) Handles FindNextButton.Click

    End Sub

    Private Sub ReplaceButton_Click(sender As Object, e As EventArgs) Handles ReplaceButton.Click

    End Sub

    Private Sub ReplaceAllButton_Click(sender As Object, e As EventArgs) Handles ReplaceAllButton.Click

    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub findDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Replace"
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Application.Idle, AddressOf UpdateButtons
    End Sub

    Private Sub UpdateButtons(sender As Object, e As EventArgs)
        Dim box = TryCast(Me.FindText, TextBoxBase)
        ' update buttons as required
        FindNextButton.Enabled = box.TextLength > 0
        Dim box2 = TryCast(Me.ReplaceText, TextBoxBase)

        ReplaceButton.Enabled = box2.TextLength > 0
        ReplaceAllButton.Enabled = ReplaceButton.Enabled
    End Sub


End Class

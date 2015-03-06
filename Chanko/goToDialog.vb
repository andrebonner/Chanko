Imports System.Windows.Forms

Public Class goToDialog

    Private Sub GoToButton_Click(sender As Object, e As EventArgs) Handles GoToButton.Click

    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub goToDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Go To Line"
        LineText.Text = "1"

    End Sub
End Class

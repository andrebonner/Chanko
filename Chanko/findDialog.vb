Imports System.Windows.Forms

Public Class findDialog

    Private ordint As Integer
    Private nextS As Long
    Private Search As String
    Private direction As String = "Down"

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ' search moves up
        ' nextS - 1
        direction = "Up"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'search moves down
        ' nextS + 1
        direction = "Down"
    End Sub

    Private Sub FindNextButton_Click(sender As Object, e As EventArgs) Handles FindNextButton.Click
        FindIn()

    End Sub

    Public Function FindIn()
        Dim txtBody As String
        Dim Where As Long

        ' Get search string from user.
        Search = FindText.Text
        txtBody = PadNoteForm.NoteText.Text

        If matchCheck.Checked Then
            ordint = StringComparison.Ordinal
        Else
            ordint = StringComparison.OrdinalIgnoreCase
        End If

        Where = FindNext(Search, txtBody, nextS)

        If direction = "Up" Then
            nextS = nextS - 1
        End If

        If direction = "Down" Then
            nextS = nextS + 1
        End If

        If Where >= 0 Then
            PadNoteForm.NoteText.SelectionStart = Where - 1
            PadNoteForm.NoteText.SelectionLength = Len(Search)
            PadNoteForm.NoteText.Focus()
        Else
            If nextS > Len(txtBody) Then
                MsgBox("Reached the end of the Note", MsgBoxStyle.Exclamation, "String not found")
                nextS = 0
            Else
                FindIn()
            End If
        End If
        Return Nothing
    End Function
    Function FindNext(s As String, body As String, i As Integer) As Long
        Dim Where As Long = -1

        Where = InStr(i + 1, body, Search)
        ' Find string in text.
        If body.IndexOf(s, i, ordint) >= 0 Then
            Where = body.IndexOf(s, i, ordint)
        End If

        If Where >= 0 Then
            FindNext = Where
        Else
            FindNext = Where
        End If
    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub findDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Find"
        RadioButton2.Checked = True
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
    End Sub


End Class

Public Class PadNoteForm
    ' the App Title
    Private AppTitle As String = "PadNote"
    ' the filename
    Private filename As String = "Untitled"
    ' document printing
    Private docToPrint As System.Drawing.Printing.PrintDocument
    ' document content
    Private documentContents As String
    ' value to indicate changes to document
    Private changed As Boolean
    Private Sub PadNoteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'setting main window title 
        Me.Text = filename + " - " + AppTitle

        ' is textbox undo event not active
        If Not NoteText.CanUndo() Then
            ' disable undo menuitem
            UndoToolStripMenuItem.Enabled = False
        End If

        'set main status
        StatusMainLabel.Text = "Ready ..."
    End Sub
    Private Sub PadNoteForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ' is the text in textbox been modified
        If changed Then
            ' is the user going to save the changes
            If MessageBox.Show("Do you want to save changes to your Note?", AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation
                               ) = DialogResult.Yes Then
                ' Cancel the Closing event
                e.Cancel = True
                ' save note
                filename = SaveAsNote(NoteText.Text)
            End If
        End If
        ' remove handler from address
        RemoveHandler Application.Idle, AddressOf UpdateButtons

    End Sub
    Function OpenNote()
        ' set filter for the supported file-types
        MainOpenFileDialog.Filter = "Note Files|*.note|Text Files|*.txt|Log Files|*.log"
        ' set the open dialog title
        MainOpenFileDialog.Title = AppTitle + " Open Note"

        ' use the previously used directory
        MainOpenFileDialog.RestoreDirectory = True
        ' is the open dialog ok button pressed
        If MainOpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' is the open dialog containing a file  
            If MainOpenFileDialog.FileName <> "" Then
                Debug.WriteLine("Opening note")
                ' set the main status
                Me.StatusMainLabel.Text = "Opened note..."
                ' read the file from stream to the end
                Dim objR As New System.IO.StreamReader(MainOpenFileDialog.FileName)
                NoteText.Text = objR.ReadToEnd
                objR.Close()
                ' set changed value
                changed = False
                'Try
                '    NoteText.Text = System.IO.File.ReadAllText(MainSaveFileDialog.FileName, System.Text.Encoding.ASCII)
                'Catch ex As Exception
                '    Debug.WriteLine("Error! " + ex.Message)
                'End Try
                ' set filename value
                filename = MainOpenFileDialog.FileName
                ' set window title
                Me.Text = filename + " - " + AppTitle
            End If
        End If
        ' no need to return anything
        Return Nothing
    End Function
    Function PrintNote()
        ' creating a print document
        docToPrint = New System.Drawing.Printing.PrintDocument()
        ' set allow some pages
        MainPrintDialog.AllowSomePages = True
        ' set show help
        MainPrintDialog.ShowHelp = True
        ' set print document
        MainPrintDialog.Document = docToPrint
        ' is the print dialog ok button pressed
        If MainPrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' print the document
            docToPrint.Print()
            Debug.WriteLine("Printing note")
            ' set the main status 
            Me.StatusMainLabel.Text = "Printing Note..."
        End If
        ' no need to return anything
        Return Nothing
    End Function
    Function PrintPreview()
        ' create a preview of what the document will look like
        ReadDocument()
        ' set preview dialog to print document
        MainPrintPreviewDialog.Document = docToPrint
        ' show the preview dialog
        MainPrintPreviewDialog.ShowDialog()
        Debug.WriteLine("Print preview note")
        ' set main status
        Me.StatusMainLabel.Text = "Previewing note..."
        ' no need to return anything
        Return Nothing
    End Function
    Function SaveAsNote(note As String)
        ' set save dialog filter to supported file-types
        MainSaveFileDialog.Filter = "Note Files|*.note|Text Files|*.txt|Log Files|*.log"
        ' set save dialog title
        MainSaveFileDialog.Title = AppTitle + " Save As..."
        ' use the previously used directory
        MainSaveFileDialog.RestoreDirectory = True
        ' is the save dialog ok button pressed
        If MainSaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' is the save dialog getting a file
            If MainSaveFileDialog.FileName <> "" Then
                ' write texgt to the textbox
                System.IO.File.WriteAllText(MainSaveFileDialog.FileName, note) cc
                changed = False
                Debug.WriteLine("Saving note")
                Me.StatusMainLabel.Text = "New Note saved..."
                filename = MainSaveFileDialog.FileName
            End If
        End If
        Return Nothing
    End Function

    Function SaveNote(file As String, note As String)
        System.IO.File.WriteAllText(filename, note)
        changed = False
        Debug.WriteLine("Saving note")
        Me.StatusMainLabel.Text = "Note Saved..."
        Return Nothing
    End Function

    Sub ReadDocument()
        docToPrint.DocumentName = filename
        Dim fstream As New System.IO.FileStream(filename, System.IO.FileMode.Open)
        Try
            Dim reader As New System.IO.StreamReader(fstream)
            Try
                documentContents = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            fstream.Dispose()
        End Try
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If NoteText.Text <> String.Empty And filename = "Untitled" Then
            ' save note
            SaveAsNote(NoteText.Text)
        End If
        NoteText.Text = ""
        filename = "Untitled"
        Me.Text = filename + " - " + AppTitle
        Me.StatusMainLabel.Text = "New note created..."
        changed = False
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If NoteText.Text <> String.Empty And filename = "Untitled" Then
            ' save note
            SaveAsNote(NoteText.Text)
        End If
        'is the file data altered
        'open file
        OpenNote()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If NoteText.Text = String.Empty Then
            Return
        End If
        If filename = "Untitled" Then
            ' save note
            SaveAsNote(NoteText.Text)
        Else
            SaveNote(filename, NoteText.Text)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If NoteText.Text = String.Empty Then
            Return
        End If
        ' save as note
        SaveAsNote(NoteText.Text)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        ' print note
        PrintNote()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        ' print preview note
        PrintPreview()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' close the PadNote
        End
    End Sub


    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        NoteText.Undo()
    End Sub


    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        NoteText.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        NoteText.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        NoteText.Paste()
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        '' send delete key
        'SendKeys.Send("{DEL}")
        NoteText.SelectedText = ""
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        findDialog.Show(Me)
    End Sub

    Private Sub FindNextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindNextToolStripMenuItem.Click
        ' is findtext search value present
        If findDialog.FindText.Text <> "" Then
            findDialog.FindIn()
        End If
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceToolStripMenuItem.Click
        replaceDialog.ShowDialog()
    End Sub
    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        goToDialog.ShowDialog()
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        NoteText.SelectAll()
    End Sub
    Private Sub TimeDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeDateToolStripMenuItem.Click
        NoteText.Text.Insert(NoteText.SelectionStart, DateAndTime.DateString)
    End Sub



    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        If Not NoteText.WordWrap Then
            NoteText.ScrollBars = ScrollBars.Vertical
        Else
            NoteText.ScrollBars = ScrollBars.Horizontal
        End If

        NoteText.AcceptsReturn = Not NoteText.AcceptsReturn
        NoteText.AcceptsTab = Not NoteText.AcceptsTab
        NoteText.WordWrap = Not NoteText.WordWrap
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        MainFontDialog.ShowColor = True

        MainFontDialog.Font = NoteText.Font
        MainFontDialog.Color = NoteText.ForeColor

        If MainFontDialog.ShowDialog() <> DialogResult.Cancel Then
            NoteText.Font = MainFontDialog.Font
            NoteText.ForeColor = MainFontDialog.Color
        End If

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        MainStatus.Visible = Not MainStatus.Visible
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about.ShowDialog()
    End Sub


    Private Sub NoteText_TextChanged(sender As Object, e As EventArgs) Handles NoteText.TextChanged
        changed = True
    End Sub
    Private Sub UpdateButtons(ByVal sender As Object, ByVal e As EventArgs)
        Dim box = TryCast(Me.ActiveControl, TextBoxBase)
        ' update buttons as required
        UndoToolStripMenuItem.Enabled = box.CanUndo()
        CopyToolStripMenuItem.Enabled = box IsNot Nothing And box.SelectionLength > 0
        CutToolStripMenuItem.Enabled = CopyToolStripMenuItem.Enabled
        PasteToolStripMenuItem.Enabled = box IsNot Nothing And Clipboard.ContainsText

        DeleteToolStripMenuItem.Enabled = box IsNot Nothing And box.SelectionLength > 0

        FindToolStripMenuItem.Enabled = box.TextLength > 0
        FindNextToolStripMenuItem.Enabled = FindToolStripMenuItem.Enabled
        ReplaceToolStripMenuItem.Enabled = FindNextToolStripMenuItem.Enabled
        GoToToolStripMenuItem.Enabled = ReplaceToolStripMenuItem.Enabled

        SelectAllToolStripMenuItem.Enabled = box IsNot Nothing And box.CanSelect

    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Application.Idle, AddressOf UpdateButtons
    End Sub


End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class replaceDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FindNextButton = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FindText = New System.Windows.Forms.TextBox()
        Me.matchCheck = New System.Windows.Forms.CheckBox()
        Me.ReplaceButton = New System.Windows.Forms.Button()
        Me.ReplaceAllButton = New System.Windows.Forms.Button()
        Me.ReplaceText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ReplaceAllButton, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ReplaceButton, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FindNextButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(321, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(102, 116)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FindNextButton
        '
        Me.FindNextButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FindNextButton.Location = New System.Drawing.Point(9, 3)
        Me.FindNextButton.Name = "FindNextButton"
        Me.FindNextButton.Size = New System.Drawing.Size(84, 23)
        Me.FindNextButton.TabIndex = 0
        Me.FindNextButton.Text = "Find Next"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(9, 90)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(84, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Find what:"
        '
        'FindText
        '
        Me.FindText.Location = New System.Drawing.Point(91, 23)
        Me.FindText.Name = "FindText"
        Me.FindText.Size = New System.Drawing.Size(215, 20)
        Me.FindText.TabIndex = 2
        '
        'matchCheck
        '
        Me.matchCheck.AutoSize = True
        Me.matchCheck.Location = New System.Drawing.Point(24, 119)
        Me.matchCheck.Name = "matchCheck"
        Me.matchCheck.Size = New System.Drawing.Size(82, 17)
        Me.matchCheck.TabIndex = 3
        Me.matchCheck.Text = "Match case"
        Me.matchCheck.UseVisualStyleBackColor = True
        '
        'ReplaceButton
        '
        Me.ReplaceButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ReplaceButton.Location = New System.Drawing.Point(9, 32)
        Me.ReplaceButton.Name = "ReplaceButton"
        Me.ReplaceButton.Size = New System.Drawing.Size(84, 23)
        Me.ReplaceButton.TabIndex = 4
        Me.ReplaceButton.Text = "Replace"
        '
        'ReplaceAllButton
        '
        Me.ReplaceAllButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ReplaceAllButton.Location = New System.Drawing.Point(9, 61)
        Me.ReplaceAllButton.Name = "ReplaceAllButton"
        Me.ReplaceAllButton.Size = New System.Drawing.Size(84, 23)
        Me.ReplaceAllButton.TabIndex = 5
        Me.ReplaceAllButton.Text = "Replace All"
        '
        'ReplaceText
        '
        Me.ReplaceText.Location = New System.Drawing.Point(91, 59)
        Me.ReplaceText.Name = "ReplaceText"
        Me.ReplaceText.Size = New System.Drawing.Size(215, 20)
        Me.ReplaceText.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Replace with:"
        '
        'replaceDialog
        '
        Me.AcceptButton = Me.FindNextButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 149)
        Me.Controls.Add(Me.ReplaceText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.matchCheck)
        Me.Controls.Add(Me.FindText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "replaceDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "replaceDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FindNextButton As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindText As System.Windows.Forms.TextBox
    Friend WithEvents matchCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ReplaceAllButton As System.Windows.Forms.Button
    Friend WithEvents ReplaceButton As System.Windows.Forms.Button
    Friend WithEvents ReplaceText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class

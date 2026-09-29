<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week8Form
    Inherits BaseLessonForm

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage

    ' Tab 1 Controls (ColorDialog)
    Friend WithEvents lblInstColor As System.Windows.Forms.Label
    Friend WithEvents btnPickColor As System.Windows.Forms.Button
    Friend WithEvents pnlColorDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblColorInfo As System.Windows.Forms.Label

    ' Tab 2 Controls (FontDialog)
    Friend WithEvents lblInstFont As System.Windows.Forms.Label
    Friend WithEvents btnPickFont As System.Windows.Forms.Button
    Friend WithEvents lblSampleText As System.Windows.Forms.Label

    ' Tab 3 Controls (OpenFileDialog)
    Friend WithEvents lblInstOpen As System.Windows.Forms.Label
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents txtOpenFilePath As System.Windows.Forms.TextBox

    ' Tab 4 Controls (SaveFileDialog)
    Friend WithEvents lblInstSave As System.Windows.Forms.Label
    Friend WithEvents btnSaveFile As System.Windows.Forms.Button
    Friend WithEvents txtSaveFilePath As System.Windows.Forms.TextBox

    ' Reviewer
    Friend WithEvents txtReviewer As System.Windows.Forms.RichTextBox

    ' Dialog Controls
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblInstColor = New System.Windows.Forms.Label()
        Me.btnPickColor = New System.Windows.Forms.Button()
        Me.pnlColorDisplay = New System.Windows.Forms.Panel()
        Me.lblColorInfo = New System.Windows.Forms.Label()

        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblInstFont = New System.Windows.Forms.Label()
        Me.btnPickFont = New System.Windows.Forms.Button()
        Me.lblSampleText = New System.Windows.Forms.Label()

        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblInstOpen = New System.Windows.Forms.Label()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.txtOpenFilePath = New System.Windows.Forms.TextBox()

        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lblInstSave = New System.Windows.Forms.Label()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.txtSaveFilePath = New System.Windows.Forms.TextBox()

        Me.txtReviewer = New System.Windows.Forms.RichTextBox()

        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()

        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()

        '
        ' TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(20, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(360, 380)
        Me.TabControl1.TabIndex = 0

        '
        ' TabPage1 (ColorDialog)
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(28, 34, 58)
        Me.TabPage1.Controls.Add(Me.lblInstColor)
        Me.TabPage1.Controls.Add(Me.btnPickColor)
        Me.TabPage1.Controls.Add(Me.pnlColorDisplay)
        Me.TabPage1.Controls.Add(Me.lblColorInfo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(352, 347)
        Me.TabPage1.Text = "ColorDialog"

        Me.lblInstColor.AutoSize = True
        Me.lblInstColor.ForeColor = System.Drawing.Color.White
        Me.lblInstColor.Location = New System.Drawing.Point(15, 15)
        Me.lblInstColor.Name = "lblInstColor"
        Me.lblInstColor.Text = "Click below to define a custom color."

        Me.btnPickColor.BackColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.btnPickColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPickColor.ForeColor = System.Drawing.Color.White
        Me.btnPickColor.Location = New System.Drawing.Point(15, 50)
        Me.btnPickColor.Name = "btnPickColor"
        Me.btnPickColor.Size = New System.Drawing.Size(320, 35)
        Me.btnPickColor.Text = "Show ColorDialog"
        Me.btnPickColor.UseVisualStyleBackColor = False

        Me.pnlColorDisplay.BackColor = System.Drawing.Color.Gray
        Me.pnlColorDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorDisplay.Location = New System.Drawing.Point(15, 100)
        Me.pnlColorDisplay.Name = "pnlColorDisplay"
        Me.pnlColorDisplay.Size = New System.Drawing.Size(320, 100)

        Me.lblColorInfo.AutoSize = True
        Me.lblColorInfo.ForeColor = System.Drawing.Color.Cyan
        Me.lblColorInfo.Location = New System.Drawing.Point(15, 215)
        Me.lblColorInfo.Name = "lblColorInfo"
        Me.lblColorInfo.Text = "Selected Color: None"

        '
        ' TabPage2 (FontDialog)
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(28, 34, 58)
        Me.TabPage2.Controls.Add(Me.lblInstFont)
        Me.TabPage2.Controls.Add(Me.btnPickFont)
        Me.TabPage2.Controls.Add(Me.lblSampleText)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(352, 347)
        Me.TabPage2.Text = "FontDialog"

        Me.lblInstFont.AutoSize = True
        Me.lblInstFont.ForeColor = System.Drawing.Color.White
        Me.lblInstFont.Location = New System.Drawing.Point(15, 15)
        Me.lblInstFont.Name = "lblInstFont"
        Me.lblInstFont.Text = "Select a font, size, and color for the text below."

        Me.btnPickFont.BackColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.btnPickFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPickFont.ForeColor = System.Drawing.Color.White
        Me.btnPickFont.Location = New System.Drawing.Point(15, 50)
        Me.btnPickFont.Name = "btnPickFont"
        Me.btnPickFont.Size = New System.Drawing.Size(320, 35)
        Me.btnPickFont.Text = "Show FontDialog"
        Me.btnPickFont.UseVisualStyleBackColor = False

        Me.lblSampleText.BackColor = System.Drawing.Color.FromArgb(40, 40, 40)
        Me.lblSampleText.ForeColor = System.Drawing.Color.White
        Me.lblSampleText.Location = New System.Drawing.Point(15, 100)
        Me.lblSampleText.Name = "lblSampleText"
        Me.lblSampleText.Size = New System.Drawing.Size(320, 150)
        Me.lblSampleText.Text = "The quick brown fox jumps over the lazy dog."
        Me.lblSampleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        ' TabPage3 (OpenFileDialog)
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(28, 34, 58)
        Me.TabPage3.Controls.Add(Me.lblInstOpen)
        Me.TabPage3.Controls.Add(Me.btnOpenFile)
        Me.TabPage3.Controls.Add(Me.txtOpenFilePath)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(352, 347)
        Me.TabPage3.Text = "OpenFileDialog"

        Me.lblInstOpen.AutoSize = True
        Me.lblInstOpen.ForeColor = System.Drawing.Color.White
        Me.lblInstOpen.Location = New System.Drawing.Point(15, 15)
        Me.lblInstOpen.Name = "lblInstOpen"
        Me.lblInstOpen.Text = "Simulate opening a file from your computer."

        Me.btnOpenFile.BackColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenFile.ForeColor = System.Drawing.Color.White
        Me.btnOpenFile.Location = New System.Drawing.Point(15, 50)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(320, 35)
        Me.btnOpenFile.Text = "Show OpenFileDialog"
        Me.btnOpenFile.UseVisualStyleBackColor = False

        Me.txtOpenFilePath.BackColor = System.Drawing.Color.FromArgb(20, 20, 20)
        Me.txtOpenFilePath.ForeColor = System.Drawing.Color.Lime
        Me.txtOpenFilePath.Location = New System.Drawing.Point(15, 100)
        Me.txtOpenFilePath.Multiline = True
        Me.txtOpenFilePath.Name = "txtOpenFilePath"
        Me.txtOpenFilePath.ReadOnly = True
        Me.txtOpenFilePath.Size = New System.Drawing.Size(320, 80)
        Me.txtOpenFilePath.Text = "No file selected."

        '
        ' TabPage4 (SaveFileDialog)
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(28, 34, 58)
        Me.TabPage4.Controls.Add(Me.lblInstSave)
        Me.TabPage4.Controls.Add(Me.btnSaveFile)
        Me.TabPage4.Controls.Add(Me.txtSaveFilePath)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(352, 347)
        Me.TabPage4.Text = "SaveFileDialog"

        Me.lblInstSave.AutoSize = True
        Me.lblInstSave.ForeColor = System.Drawing.Color.White
        Me.lblInstSave.Location = New System.Drawing.Point(15, 15)
        Me.lblInstSave.Name = "lblInstSave"
        Me.lblInstSave.Text = "Simulate picking a save location."

        Me.btnSaveFile.BackColor = System.Drawing.Color.FromArgb(50, 50, 50)
        Me.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveFile.ForeColor = System.Drawing.Color.White
        Me.btnSaveFile.Location = New System.Drawing.Point(15, 50)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(320, 35)
        Me.btnSaveFile.Text = "Show SaveFileDialog"
        Me.btnSaveFile.UseVisualStyleBackColor = False

        Me.txtSaveFilePath.BackColor = System.Drawing.Color.FromArgb(20, 20, 20)
        Me.txtSaveFilePath.ForeColor = System.Drawing.Color.Yellow
        Me.txtSaveFilePath.Location = New System.Drawing.Point(15, 100)
        Me.txtSaveFilePath.Multiline = True
        Me.txtSaveFilePath.Name = "txtSaveFilePath"
        Me.txtSaveFilePath.ReadOnly = True
        Me.txtSaveFilePath.Size = New System.Drawing.Size(320, 80)
        Me.txtSaveFilePath.Text = "No save path chosen."

        '
        ' txtReviewer
        '
        Me.txtReviewer.BackColor = System.Drawing.Color.FromArgb(28, 34, 58)
        Me.txtReviewer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReviewer.ForeColor = System.Drawing.Color.White
        Me.txtReviewer.Location = New System.Drawing.Point(395, 65)
        Me.txtReviewer.Name = "txtReviewer"
        Me.txtReviewer.ReadOnly = True
        Me.txtReviewer.Size = New System.Drawing.Size(385, 380)
        Me.txtReviewer.TabIndex = 1
        Me.txtReviewer.Text = ""

        '
        ' Week8Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 560)
        Me.Controls.Add(Me.txtReviewer)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Week8Form"
        Me.Text = "Week 8 - Controls & Properties"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.txtReviewer, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
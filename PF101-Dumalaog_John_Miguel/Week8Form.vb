Imports System.Drawing
Imports System.Windows.Forms

<System.Runtime.Versioning.SupportedOSPlatform("windows")>
Partial Public Class Week8Form

    Private Sub Week8Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "OOP(PF101) - Week 8 Dialog Controls"

        ' FIX: Directly access the protected pnlContainer inherited from BaseLessonForm.
        ' Me.Controls.Find fails because pnlContainer's .Name property is never set in the base class.
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(TabControl1)
            pnlContainer.Controls.Add(txtReviewer)

            Dim topMargin As Integer = 85
            Dim bottomMargin As Integer = 70
            Dim sideMargin As Integer = 25
            Dim spacing As Integer = 15

            ' Use pnlContainer width/height instead of targetPanel
            Dim availableWidth As Integer = pnlContainer.Width - (sideMargin * 2) - spacing
            Dim tabWidth As Integer = CInt(availableWidth * 0.58)
            Dim textWidth As Integer = availableWidth - tabWidth
            Dim contentHeight As Integer = pnlContainer.Height - topMargin - bottomMargin

            TabControl1.SetBounds(sideMargin, topMargin, tabWidth, contentHeight)
            txtReviewer.SetBounds(sideMargin + tabWidth + spacing, topMargin, textWidth, contentHeight)

            For Each page As TabPage In TabControl1.TabPages
                FixControlLayouts(page)
            Next

            TabControl1.BringToFront()
            txtReviewer.BringToFront()
        End If

        LoadReviewerText(0)
    End Sub

    Private Sub FixControlLayouts(container As Control)
        Dim padding As Integer = 12
        Dim maxW As Integer = container.ClientSize.Width - padding
        Dim maxH As Integer = container.ClientSize.Height - padding

        For Each ctrl As Control In container.Controls
            If ctrl.Right > maxW Then
                ctrl.Width = maxW - ctrl.Left
            End If

            If ctrl.Bottom > maxH Then
                If TypeOf ctrl Is ListBox OrElse TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is Label OrElse (TypeOf ctrl Is TextBox AndAlso DirectCast(ctrl, TextBox).Multiline) Then
                    ctrl.Height = maxH - ctrl.Top
                Else
                    ctrl.Top = maxH - ctrl.Height
                End If
            End If

            If ctrl.HasChildren Then
                FixControlLayouts(ctrl)
            End If
        Next
    End Sub

    Private Sub LoadReviewerText(index As Integer)
        If txtReviewer Is Nothing Then Return

        Select Case index
            Case 0
                txtReviewer.Text = "Common Dialog Controls" & vbCrLf & vbCrLf &
                                   "There are many built-in dialog boxes to be used in Windows forms for various tasks like opening and saving files... All of these dialog box control classes inherit from the CommonDialog class." & vbCrLf & vbCrLf &
                                   "The ShowDialog method is used to display all the dialog box controls at run-time. It returns a value of the type of DialogResult enumeration." & vbCrLf & vbCrLf &
                                   "ColorDialog Control" & vbCrLf &
                                   "The ColorDialog control class represents a common dialog box that displays available colors... The main property of the ColorDialog control is Color."
            Case 1
                txtReviewer.Text = "FontDialog Control" & vbCrLf & vbCrLf &
                                   "The FontDialog control prompts the user to choose a font from among those installed on the local computer and lets the user select the font, font size, and color." & vbCrLf & vbCrLf &
                                   "Common Properties:" & vbCrLf &
                                   "• Font: Gets or sets the selected font." & vbCrLf &
                                   "• Color: Gets or sets the selected font color. (Requires ShowColor = True)"
            Case 2
                txtReviewer.Text = "OpenFileDialog Control" & vbCrLf & vbCrLf &
                                   "The OpenFileDialog control prompts the user to open a file and allows the user to select a file to open. The class inherits from the FileDialog class." & vbCrLf & vbCrLf &
                                   "Common Properties:" & vbCrLf &
                                   "• FileName: Gets or sets a string containing the file name selected." & vbCrLf &
                                   "• Filter: Gets or sets the current file name filter string."
            Case 3
                txtReviewer.Text = "SaveFileDialog Control" & vbCrLf & vbCrLf &
                                   "The SaveFileDialog control prompts the user to select a location for saving a file and allows the user to specify the name of the file to save data." & vbCrLf & vbCrLf &
                                   "Common Properties:" & vbCrLf &
                                   "• DefaultExt: Gets or sets the default file name extension." & vbCrLf &
                                   "• OverwritePrompt: Displays a warning if the user specifies a file name that already exists."
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        LoadReviewerText(TabControl1.SelectedIndex)
    End Sub

    Private Sub btnPickColor_Click(sender As Object, e As EventArgs) Handles btnPickColor.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            pnlColorDisplay.BackColor = ColorDialog1.Color
            lblColorInfo.Text = $"Selected Color: {ColorDialog1.Color.Name}"
            lblColorInfo.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnPickFont_Click(sender As Object, e As EventArgs) Handles btnPickFont.Click
        FontDialog1.ShowColor = True
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            lblSampleText.Font = FontDialog1.Font
            lblSampleText.ForeColor = FontDialog1.Color
            lblSampleText.Text = $"Selected Font: {FontDialog1.Font.Name}"
        End If
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        OpenFileDialog1.Title = "Select a file to open"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtOpenFilePath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        SaveFileDialog1.Title = "Save file as..."
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            txtSaveFilePath.Text = SaveFileDialog1.FileName
        End If
    End Sub

End Class
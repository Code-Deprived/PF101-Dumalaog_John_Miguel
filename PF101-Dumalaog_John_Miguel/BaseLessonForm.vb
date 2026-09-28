Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class BaseLessonForm
    Inherits Form

    Protected Property LessonTitle As String = "Lesson Reviewer"
    Protected ReadOnly pnlContainer As New DoubleBufferedPanel()

    Public Sub New()
        ' Disable DPI font distortion
        Me.AutoScaleMode = AutoScaleMode.None
        Me.DoubleBuffered = True

        ' Fixed Client Size (Inner window area)
        Me.ClientSize = New Size(850, 560)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.BackColor = Color.FromArgb(24, 28, 48)

        ' Container Panel (Centered inside Form)
        pnlContainer.Size = New Size(800, 450)
        pnlContainer.Location = New Point(25, 38)
        pnlContainer.BackColor = Color.FromArgb(220, 34, 42, 72)
        AddHandler pnlContainer.Paint, AddressOf PaintContainer
        Me.Controls.Add(pnlContainer)

        ' Title Header
        Dim lblTitle As New Label() With {
            .Size = New Size(760, 40),
            .Location = New Point(20, 15),
            .BackColor = Color.Transparent
        }
        AddHandler lblTitle.Paint, Sub(s, pe) DrawHeaderBox(pe.Graphics, lblTitle.ClientRectangle, LessonTitle, 14.0F)
        pnlContainer.Controls.Add(lblTitle)

        ' Back Button
        Dim btnClose As New Label() With {
            .Size = New Size(160, 40),
            .Location = New Point((850 - 160) \ 2, 490),
            .Cursor = Cursors.Hand,
            .BackColor = Color.Transparent
        }
        AddHandler btnClose.Paint, Sub(s, pe) DrawHeaderBox(pe.Graphics, btnClose.ClientRectangle, "Back", 14.0F)
        AddHandler btnClose.Click, Sub(s, ea) Me.Close()
        Me.Controls.Add(btnClose)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        ' Enforce exact size on load to override any designer settings
        Me.ClientSize = New Size(850, 560)
    End Sub

    Private Sub PaintContainer(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlContainer.Width - 1, pnlContainer.Height - 1)
        Using path As GraphicsPath = GetRoundedRectPath(rect, 12),
              bg As New SolidBrush(Color.FromArgb(220, 34, 42, 72)),
              pen As New Pen(Color.FromArgb(15, 20, 38), 3)
            e.Graphics.FillPath(bg, path)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Protected Function CreateReviewerTextBox(text As String) As RichTextBox
        Return New RichTextBox() With {
            .Size = New Size(385, 380),
            .Location = New Point(395, 65),
            .BackColor = Color.FromArgb(28, 34, 58),
            .ForeColor = Color.White,
            .Font = GetAndyFont(10.0F, FontStyle.Regular),
            .BorderStyle = BorderStyle.None,
            .ReadOnly = True,
            .WordWrap = True,
            .Text = text
        }
    End Function

    Protected Function CreateDemoPanel() As DoubleBufferedPanel
        Return New DoubleBufferedPanel() With {
            .Size = New Size(360, 380),
            .Location = New Point(20, 65),
            .BackColor = Color.FromArgb(28, 34, 58)
        }
    End Function
End Class
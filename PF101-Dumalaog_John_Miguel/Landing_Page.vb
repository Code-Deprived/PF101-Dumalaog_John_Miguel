Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms

Public Class Landing_Page
    Private ReadOnly lessonData As New Dictionary(Of Label, (Title As String, Subtext As String))
    Private ReadOnly hoveredControls As New HashSet(Of Control)()

    ' Splash Text Animation
    Private ReadOnly splashTimer As New Timer() With {.Interval = 35}
    Private currentFontSize As Single = 14.0F
    Private isGrowing As Boolean = True
    Private lblSplash As Label

    Private Sub Landing_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Enable double buffering on ALL menu panels & controls to stop GIF flickering
        EnableDoubleBufferingRecursive(Me)

        ' 2. Parent panels & logo to GIF background for transparent layering
        pnlMainMenu.Parent = picBG
        pnlLessonSelect.Parent = picBG
        If Controls.ContainsKey("picLogo") Then Controls("picLogo").Parent = picBG
        pnlMainMenu.Visible = True
        pnlLessonSelect.Visible = False

        ' Map Lesson Metadata
        lessonData(lblWeek2) = ("Week 2 - Intro to OOP", "Classes   Objects   Encapsulation")
        lessonData(lblWeek3) = ("Week 3 - Getting Started", "Syntax   Variables   Data Types")
        lessonData(lblWeek4) = ("Week 4 - Designing Interfaces", "WinForms   Controls   Layouts")
        lessonData(lblWeek5) = ("Week 5 - Data Handling", "Arrays   Collections   File I/O")
        lessonData(lblWeek6) = ("Week 6 - Control Structures", "If/Else   Select Case   Loops")

        ' Prepare Text & Transparencies
        Dim allLabels As Label() = {lblLessons, lblSBIT1A, lblHelp, lblExit, lblSelectHeader, btnBack, lblWeek2, lblWeek3, lblWeek4, lblWeek5, lblWeek6}
        For Each lbl In allLabels
            lbl.BackColor = Color.Transparent
            lbl.Text = ""
        Next

        ' Load animated background
        Dim gifPath As String = Path.Combine(Application.StartupPath, "snow.gif")
        If File.Exists(gifPath) Then picBG.ImageLocation = gifPath

        InitSplashText()

        ' --- NEW: Play background music safely ---
        Dim audioPath As String = System.IO.Path.Combine(Application.StartupPath, "Terraria_Music.wav")
        If System.IO.File.Exists(audioPath) Then
            My.Computer.Audio.Play(audioPath, AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub InitSplashText()
        lblSplash = New Label() With {
            .Size = New Size(240, 55),
            .Location = New Point(620, 115),
            .BackColor = Color.Transparent,
            .Parent = pnlMainMenu
        }
        AddHandler splashTimer.Tick, AddressOf SplashTimer_Tick
        AddHandler lblSplash.Paint, AddressOf DrawSplashText
        lblSplash.BringToFront()
        splashTimer.Start()
    End Sub

    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs)
        currentFontSize += If(isGrowing, 0.18F, -0.18F)
        If currentFontSize >= 17.0F Then isGrowing = False
        If currentFontSize <= 12.0F Then isGrowing = True
        If lblSplash IsNot Nothing AndAlso lblSplash.Visible Then lblSplash.Invalidate()
    End Sub

    Private Sub DrawSplashText(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        Dim centerX As Integer = lblSplash.Width \ 2
        Dim centerY As Integer = lblSplash.Height \ 2
        g.TranslateTransform(centerX, centerY)
        g.RotateTransform(-14.0F)

        Using splashFont As Font = GetAndyFont(currentFontSize, FontStyle.Bold),
              sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center},
              path As New GraphicsPath()
            Dim renderRect As New Rectangle(-centerX, -centerY, lblSplash.Width, lblSplash.Height)
            path.AddString("Try Furton's!", splashFont.FontFamily, CInt(splashFont.Style), g.DpiY * splashFont.Size / 72.0F, renderRect, sf)
            Using outlinePen As New Pen(Color.FromArgb(40, 40, 0), 4.0F) With {.LineJoin = LineJoin.Round},
                  yellowBrush As New SolidBrush(Color.Yellow)
                g.DrawPath(outlinePen, path)
                g.FillPath(yellowBrush, path)
            End Using
        End Using
    End Sub

    Private Function GetControlText(lbl As Label) As String
        Select Case lbl.Name
            Case "lblLessons" : Return "Lessons"
            Case "lblSBIT1A" : Return "SBIT1A"
            Case "lblHelp" : Return "Help"
            Case "lblExit" : Return "Exit"
            Case "btnBack" : Return "Back"
            Case "lblSelectHeader" : Return "Select Lesson"
            Case Else : Return ""
        End Select
    End Function

    Private Sub pnlListContainer_Paint(sender As Object, e As PaintEventArgs) Handles pnlListContainer.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlListContainer.Width - 1, pnlListContainer.Height - 1)
        Using path As GraphicsPath = GetRoundedRectPath(rect, 12),
              bgBrush As New SolidBrush(Color.FromArgb(220, 34, 42, 72)),
              outerPen As New Pen(Color.FromArgb(15, 20, 38), 3)
            e.Graphics.FillPath(bgBrush, path)
            e.Graphics.DrawPath(outerPen, path)
        End Using
    End Sub

    Private Sub lblSelectHeader_Paint(sender As Object, e As PaintEventArgs) Handles lblSelectHeader.Paint
        DrawHeaderBox(e.Graphics, lblSelectHeader.ClientRectangle, GetControlText(lblSelectHeader), 22.0F)
    End Sub

    Private Sub btnBack_Paint(sender As Object, e As PaintEventArgs) Handles btnBack.Paint
        DrawHeaderBox(e.Graphics, btnBack.ClientRectangle, GetControlText(btnBack), 18.0F)
    End Sub

    Private Sub DrawLessonSlot(sender As Object, e As PaintEventArgs) Handles lblWeek2.Paint, lblWeek3.Paint, lblWeek4.Paint, lblWeek5.Paint, lblWeek6.Paint
        Dim lbl As Label = CType(sender, Label)
        If Not lessonData.ContainsKey(lbl) Then Return

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim isHovered As Boolean = hoveredControls.Contains(lbl)
        Dim slotBg As Color = If(isHovered, Color.FromArgb(240, 58, 68, 112), Color.FromArgb(220, 44, 52, 88))
        Dim slotBorder As Color = If(isHovered, Color.FromArgb(160, 180, 240), Color.FromArgb(70, 82, 130))

        Using path As GraphicsPath = GetRoundedRectPath(New Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1), 8),
              bgBrush As New SolidBrush(slotBg),
              borderPen As New Pen(slotBorder, 2)
            e.Graphics.FillPath(bgBrush, path)
            e.Graphics.DrawPath(borderPen, path)
        End Using

        Dim info = lessonData(lbl)
        Using titleFont As Font = GetAndyFont(15.0F, FontStyle.Bold)
            DrawOutlinedText(e.Graphics, info.Title, titleFont, If(isHovered, Color.Yellow, Color.White), Color.Black, New Rectangle(15, 6, lbl.Width - 30, 26), StringAlignment.Near)
        End Using
        Using subFont As Font = GetAndyFont(11.0F, FontStyle.Regular),
              subBrush As New SolidBrush(Color.FromArgb(180, 195, 230))
            e.Graphics.DrawString(info.Subtext, subFont, subBrush, New Rectangle(15, 34, lbl.Width - 30, 24))
        End Using
    End Sub

    Private Sub DrawTerrariaTextOutline(sender As Object, e As PaintEventArgs) Handles lblLessons.Paint, lblSBIT1A.Paint, lblHelp.Paint, lblExit.Paint
        Dim lbl As Label = CType(sender, Label)
        Using andyFont As Font = GetAndyFont(24.0F, FontStyle.Bold)
            DrawOutlinedText(e.Graphics, GetControlText(lbl), andyFont, lbl.ForeColor, Color.Black, lbl.ClientRectangle)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' Prevents flickering over the animated background
    End Sub

    Private Sub MenuNav_Click(sender As Object, e As EventArgs) Handles lblLessons.Click, btnBack.Click
        Dim isLessons As Boolean = (sender Is lblLessons)
        pnlMainMenu.Visible = Not isLessons
        pnlLessonSelect.Visible = isLessons
    End Sub

    Private Sub lblSBIT1A_Click(sender As Object, e As EventArgs) Handles lblSBIT1A.Click
        MessageBox.Show("SBIT1A Section coming soon!", "Portfolio Reviewer Hub")
    End Sub

    Private Sub lblHelp_Click(sender As Object, e As EventArgs) Handles lblHelp.Click
        MessageBox.Show("Click 'Lessons' to open course modules.", "Help")
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        Application.Exit()
    End Sub

    Private Sub MenuHoverEnter(sender As Object, e As EventArgs) Handles lblLessons.MouseEnter, lblSBIT1A.MouseEnter, lblHelp.MouseEnter, lblExit.MouseEnter, btnBack.MouseEnter
        CType(sender, Label).ForeColor = Color.Yellow
    End Sub

    Private Sub MenuHoverLeave(sender As Object, e As EventArgs) Handles lblLessons.MouseLeave, lblSBIT1A.MouseLeave, lblHelp.MouseLeave, lblExit.MouseLeave, btnBack.MouseLeave
        CType(sender, Label).ForeColor = Color.White
    End Sub

    Private Sub LessonHoverEnter(sender As Object, e As EventArgs) Handles lblWeek2.MouseEnter, lblWeek3.MouseEnter, lblWeek4.MouseEnter, lblWeek5.MouseEnter, lblWeek6.MouseEnter
        hoveredControls.Add(CType(sender, Label))
        CType(sender, Label).Invalidate()
    End Sub

    Private Sub LessonHoverLeave(sender As Object, e As EventArgs) Handles lblWeek2.MouseLeave, lblWeek3.MouseLeave, lblWeek4.MouseLeave, lblWeek5.MouseLeave, lblWeek6.MouseLeave
        hoveredControls.Remove(CType(sender, Label))
        CType(sender, Label).Invalidate()
    End Sub

    Private Sub OpenLesson(Of T As {Form, New})()
        Using f As New T()
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub lblWeek2_Click(sender As Object, e As EventArgs) Handles lblWeek2.Click
        OpenLesson(Of Week2Form)()
    End Sub

    Private Sub lblWeek3_Click(sender As Object, e As EventArgs) Handles lblWeek3.Click
        OpenLesson(Of Week3Form)()
    End Sub

    Private Sub lblWeek4_Click(sender As Object, e As EventArgs) Handles lblWeek4.Click
        OpenLesson(Of Week4Form)()
    End Sub

    Private Sub lblWeek5_Click(sender As Object, e As EventArgs) Handles lblWeek5.Click
        OpenLesson(Of Week5Form)()
    End Sub

    Private Sub lblWeek6_Click(sender As Object, e As EventArgs) Handles lblWeek6.Click
        OpenLesson(Of Week6Form)()
    End Sub
End Class
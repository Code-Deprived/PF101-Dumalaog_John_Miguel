Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Collections.Generic

Public Class Week3Form
    Inherits BaseLessonForm

    ' Advanced Concept: Encapsulating data structures instead of relying on loose UI strings
    Private Class VirtualVariable
        Public Property VarName As String
        Public Property DataType As String
        Public Property Value As Object
    End Class

    Private storedVariables As New List(Of VirtualVariable)()
    Private ideToolTip As New ToolTip()

    Private Sub Week3Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Re-parenting to BaseLessonForm's container to prevent UI swallowing[cite: 11]
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If

        ApplyTerrariaAesthetics()
        SetupInteractiveTooltips()
        LoadModuleContent()
    End Sub

    Private Sub ApplyTerrariaAesthetics()
        ' 1. Deepen the main panel background to a darker "night sky" blue
        pnlInteractive.BackColor = Color.FromArgb(22, 25, 45)

        ' 2. Soften the lesson text color for better contrast and readability against dark backgrounds
        lblLesson.ForeColor = Color.FromArgb(200, 210, 230)

        ' 3. Overhaul the TextBoxes (Removes the stark white Windows default)
        Dim textboxes As TextBox() = {txtName, txtAge}
        For Each tb In textboxes
            tb.BackColor = Color.FromArgb(30, 35, 60)
            tb.ForeColor = Color.Gold
            tb.BorderStyle = BorderStyle.FixedSingle
            tb.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Next

        ' 4. Upgrade the Output Console to look like a true retro terminal
        lblOutput.BackColor = Color.FromArgb(10, 10, 15) ' Near black
        lblOutput.ForeColor = Color.Lime ' Default terminal green
        lblOutput.Font = New Font("Consolas", 10.5F, FontStyle.Regular)
        lblOutput.BorderStyle = BorderStyle.FixedSingle

        ' 5. Refine the Buttons with gold borders and pointer cursors
        Dim buttons As Button() = {btnVars, btnConsole}
        For Each btn In buttons
            btn.BackColor = Color.FromArgb(50, 60, 100)
            btn.ForeColor = Color.White
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.Gold ' Adds a Terraria-style border highlight
            btn.FlatAppearance.BorderSize = 1
            btn.Cursor = Cursors.Hand
        Next

        ' 6. Re-apply Hover Effects (Ensuring they match the new base colors)
        AddHandler btnVars.MouseEnter, Sub(s, e) btnVars.BackColor = Color.FromArgb(80, 100, 160)
        AddHandler btnVars.MouseLeave, Sub(s, e) btnVars.BackColor = Color.FromArgb(50, 60, 100)
        AddHandler btnConsole.MouseEnter, Sub(s, e) btnConsole.BackColor = Color.FromArgb(80, 100, 160)
        AddHandler btnConsole.MouseLeave, Sub(s, e) btnConsole.BackColor = Color.FromArgb(50, 60, 100)
    End Sub

    Private Sub SetupInteractiveTooltips()
        ' Interactive tooltips teaching IDE concepts upon hovering
        ideToolTip.SetToolTip(txtName, "Variables allow us to use words instead of numbers to store data in RAM.")
        ideToolTip.SetToolTip(btnVars, "Click to allocate your variables into application memory.")
        ideToolTip.SetToolTip(btnConsole, "Converts your instructions into machine language (1s and 0s) via the Compiler.")
    End Sub

    Private Sub LoadModuleContent()
        ' String interpolation for clean, readable multi-line text formatting
        lblLesson.Font = GetAndyFont(12.0F, FontStyle.Regular)
        lblLesson.Text = $"Week 3: Getting Started with VB.NET{vbCrLf}{vbCrLf}" &
                         $"Computer Programming: The process of developing sets of instructions to enable a computer to do a certain task.{vbCrLf}{vbCrLf}" &
                         $"The Compiler: A special software that converts programming language statements into machine language (1s and 0s) that the CPU understands.{vbCrLf}{vbCrLf}" &
                         $"The IDE (Integrated Development Environment): Provides the workspace, translating human-readable variables into executed actions."
    End Sub

    Private Sub btnVars_Click(sender As Object, e As EventArgs) Handles btnVars.Click
        Dim userName As String = txtName.Text.Trim()
        Dim userAgeStr As String = txtAge.Text.Trim()

        If String.IsNullOrWhiteSpace(userName) Then
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Syntax Error: Name cannot be blank."
            Return
        End If

        Dim userAge As Integer
        ' Safe type-casting
        If Integer.TryParse(userAgeStr, userAge) Then
            storedVariables.Clear()
            storedVariables.Add(New VirtualVariable With {.VarName = "userName", .DataType = "String", .Value = userName})
            storedVariables.Add(New VirtualVariable With {.VarName = "userAge", .DataType = "Integer", .Value = userAge})

            lblOutput.ForeColor = Color.Lime
            lblOutput.Text = $"[Memory Allocation Success]{vbCrLf}Variables successfully stored in RAM.{vbCrLf}Awaiting Compiler Execution..."
            btnConsole.Enabled = True
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Syntax Error: Age must be a valid Integer (whole number)."
        End If
    End Sub

    ' Advanced Concept: Async/Await simulates the processing time of a real compiler
    Private Async Sub btnConsole_Click(sender As Object, e As EventArgs) Handles btnConsole.Click
        If storedVariables.Count = 0 Then
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Build Error: No variables declared."
            Return
        End If

        btnConsole.Enabled = False
        btnVars.Enabled = False
        lblOutput.ForeColor = Color.LightGray

        ' Educational Integration: Demonstrating the compiler concept visually
        lblOutput.Text = "Initializing Compiler..." & vbCrLf
        Await Task.Delay(600)
        lblOutput.Text &= "Converting statements to machine language..." & vbCrLf
        Await Task.Delay(800)

        ' Simulating the 1s and 0s processing
        lblOutput.Text &= "01000011 01010000 01010101..." & vbCrLf
        Await Task.Delay(600)

        lblOutput.ForeColor = Color.Cyan
        lblOutput.Text &= vbCrLf & "--- TERMINAL EXECUTION ---" & vbCrLf
        lblOutput.Text &= "Developer: John Miguel Crisostomo Dumalaog" & vbCrLf & vbCrLf

        For Each v In storedVariables
            lblOutput.Text &= $"Allocated {v.DataType}: {v.VarName} = {v.Value}{vbCrLf}"
            Await Task.Delay(400)
        Next

        lblOutput.ForeColor = Color.Lime
        lblOutput.Text &= vbCrLf & "Process exited with code 0."

        btnConsole.Enabled = True
        btnVars.Enabled = True
    End Sub
End Class
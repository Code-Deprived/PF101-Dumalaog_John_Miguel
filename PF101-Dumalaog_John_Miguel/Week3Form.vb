Public Class Week3Form

    Private Sub Week3Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CRITICAL FIX: Transfer the Designer controls into the Base Form's container
        ' This ensures your base form's "Lesson Reviewer" UI doesn't swallow them
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)

            ' Force them to the very top layer
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If
    End Sub

    ' --- 1. Variable & Syntax Checking Demo ---
    Private Sub btnVars_Click(sender As Object, e As EventArgs) Handles btnVars.Click
        Dim userName As String = txtName.Text.Trim()
        Dim userAge As Integer

        ' Input Validation & Type Casting
        If String.IsNullOrWhiteSpace(userName) Then
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Syntax Error: Name cannot be blank."
            Return
        End If

        ' Verify the age can be successfully cast to an Integer data type
        If Integer.TryParse(txtAge.Text, userAge) Then
            lblOutput.ForeColor = Color.Lime
            lblOutput.Text = $"[Variables Created & Stored]{vbCrLf}" &
                             $"Dim userName As String = ""{userName}""{vbCrLf}" &
                             $"Dim userAge As Integer = {userAge}{vbCrLf}{vbCrLf}" &
                             $"Syntax check passed successfully."
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Syntax Error: Age must be a valid Integer (whole number)."
        End If
    End Sub

    ' --- 2. Console Application Simulator Demo ---
    Private Sub btnConsole_Click(sender As Object, e As EventArgs) Handles btnConsole.Click
        ' Switch text color to standard console gray for authenticity
        lblOutput.ForeColor = Color.LightGray

        ' Simulate a standard VB.NET Console.WriteLine execution
        lblOutput.Text = "Microsoft Windows [Version 10.0.19045]" & vbCrLf &
                         "(c) Microsoft Corporation. All rights reserved." & vbCrLf & vbCrLf &
                         "C:\VB_Projects> ConsoleApp.exe" & vbCrLf &
                         "Hello World!" & vbCrLf &
                         "Press any key to continue . . ."
    End Sub

End Class
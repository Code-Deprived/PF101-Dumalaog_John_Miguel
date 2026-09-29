Public Class Week6Form
    Private Const TAX_RATE As Decimal = 0.12D

    Private Sub Week6Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Set default value to prevent startup crashes
        cmbTruthOp.SelectedIndex = 0

        ' 2. Transfer the Designer controls into the Base Form's container
        ' This ensures your base form's "Lesson Reviewer" UI doesn't swallow them
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)

            ' Force them to the very top layer
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If
    End Sub

    Private Sub btnTax_Click(sender As Object, e As EventArgs) Handles btnTax.Click
        If IsNumeric(txtTax.Text) Then
            Dim amount As Decimal = CDec(txtTax.Text)
            Dim taxAmount As Decimal = amount * TAX_RATE
            Dim total As Decimal = amount + taxAmount

            lblOutput.ForeColor = Color.Lime
            lblOutput.Text = $"[If/Else: Condition Met]{vbCrLf}" &
                             $"Subtotal: {amount:C2}{vbCrLf}" &
                             $"Tax (12%): {taxAmount:C2}{vbCrLf}" &
                             $"Total: {total:C2}"
        Else
            lblOutput.ForeColor = Color.Red
            lblOutput.Text = "[If/Else: Condition Failed]" & vbCrLf & "Error: Please enter a valid number."
        End If
    End Sub

    Private Sub btnGrade_Click(sender As Object, e As EventArgs) Handles btnGrade.Click
        Dim gradeInput As String = txtGrade.Text.Trim().ToUpper()
        lblOutput.ForeColor = Color.Cyan

        Select Case gradeInput
            Case "A" : lblOutput.Text = "Select Case 'A':" & vbCrLf & "Excellent performance!"
            Case "B" : lblOutput.Text = "Select Case 'B':" & vbCrLf & "Good job, well above average."
            Case "C" : lblOutput.Text = "Select Case 'C':" & vbCrLf & "Average performance."
            Case "D" : lblOutput.Text = "Select Case 'D':" & vbCrLf & "Below average, needs improvement."
            Case "F" : lblOutput.Text = "Select Case 'F':" & vbCrLf & "Failing grade. Retake required."
            Case Else
                lblOutput.ForeColor = Color.Orange
                lblOutput.Text = $"Select Case Else:" & vbCrLf & $"'{gradeInput}' is not a valid grade."
        End Select
    End Sub

    Private Sub btnLoop_Click(sender As Object, e As EventArgs) Handles btnLoop.Click
        Dim loopResult As String = "Starting For...Next Loop:" & vbCrLf
        lblOutput.ForeColor = Color.Yellow

        For index As Integer = 1 To 5
            loopResult &= $"- Executing iteration {index}{vbCrLf}"
        Next

        lblOutput.Text = loopResult & "Loop Complete."
    End Sub

    Private Sub btnTruth_Click(sender As Object, e As EventArgs) Handles btnTruth.Click
        If cmbTruthOp.SelectedItem Is Nothing Then
            lblOutput.Text = "Please select an operator."
            Return
        End If

        Dim operatorSelected As String = cmbTruthOp.SelectedItem.ToString()
        Dim tableOutput As String = ""

        ' Use vbTab for column alignment since MessageBox uses a variable-width font
        If operatorSelected = "NOT (A)" Then
            tableOutput = "A" & vbTab & "| NOT A" & vbCrLf &
                          "-------------------" & vbCrLf &
                          "True" & vbTab & "| False" & vbCrLf &
                          "False" & vbTab & "| True"
        Else
            tableOutput = "A" & vbTab & "| B" & vbTab & $"| A {operatorSelected} B" & vbCrLf &
                          "----------------------------------------" & vbCrLf

            ' Generate combinations
            For Each a As Boolean In {True, False}
                For Each b As Boolean In {True, False}
                    Dim result As Boolean
                    Select Case operatorSelected
                        Case "AND" : result = a And b
                        Case "OR" : result = a Or b
                        Case "XOR" : result = a Xor b
                    End Select
                    tableOutput &= $"{a}" & vbTab & $"| {b}" & vbTab & $"| {result}{vbCrLf}"
                Next
            Next
        End If

        ' Update the label to show status, then display the pop-up
        lblOutput.ForeColor = Color.Cyan
        lblOutput.Text = $"Generating {operatorSelected} Truth Table..."

        MessageBox.Show(tableOutput, $"{operatorSelected} Truth Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
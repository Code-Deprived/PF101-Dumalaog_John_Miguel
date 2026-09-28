Public Class Week6Form
    Private Const TAX_RATE As Decimal = 0.12D

    Private Sub Week6Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Set default values to prevent startup crashes
        cmbTruthA.SelectedIndex = 0
        cmbTruthB.SelectedIndex = 0
        cmbTruthOp.SelectedIndex = 0

        ' 2. CRITICAL FIX: Transfer the Designer controls into the Base Form's container
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
        Dim valA As Boolean = Boolean.Parse(cmbTruthA.SelectedItem.ToString())
        Dim valB As Boolean = Boolean.Parse(cmbTruthB.SelectedItem.ToString())
        Dim operatorSelected As String = cmbTruthOp.SelectedItem.ToString()
        Dim result As Boolean
        Dim operationString As String = ""

        Select Case operatorSelected
            Case "AND"
                result = valA And valB
                operationString = $"{valA} AND {valB}"
            Case "OR"
                result = valA Or valB
                operationString = $"{valA} OR {valB}"
            Case "XOR"
                result = valA Xor valB
                operationString = $"{valA} XOR {valB}"
            Case "NOT (A)"
                result = Not valA
                operationString = $"NOT {valA}"
        End Select

        lblOutput.ForeColor = If(result, Color.Lime, Color.Tomato)
        lblOutput.Text = $"Truth Table Execution:{vbCrLf}{operationString} = {result}"
    End Sub

    Private Sub cmbTruthOp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTruthOp.SelectedIndexChanged
        If cmbTruthOp.SelectedItem IsNot Nothing Then
            cmbTruthB.Enabled = (cmbTruthOp.SelectedItem.ToString() <> "NOT (A)")
        End If
    End Sub
End Class
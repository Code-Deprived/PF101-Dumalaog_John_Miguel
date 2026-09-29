Imports System.Drawing
Imports System.Windows.Forms

Public Class Week5Form
    Inherits BaseLessonForm

    ' Module-Level Constant Demonstration
    Private Const SALES_TAX_RATE_DECIMAL As Decimal = 0.12D

    Private Sub Week5Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CRITICAL FIX: Transfer the Designer controls into the Base Form's container
        ' This ensures your base form's UI doesn't swallow them
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            ' Make the panel transparent to blend with the base form and hide residual borders
            pnlInteractive.BackColor = Color.Transparent
            pnlInteractive.BringToFront()

            ' Change GroupBox and Label fonts to white for visibility
            grpCalculator.ForeColor = Color.White
            grpConversion.ForeColor = Color.White
            lblNum1.ForeColor = Color.White
            lblNum2.ForeColor = Color.White
            lblOp.ForeColor = Color.White
            lblConvert.ForeColor = Color.White

            ' Ensure inputs and buttons keep black text
            txtNum1.ForeColor = Color.Black
            txtNum2.ForeColor = Color.Black
            txtConvert.ForeColor = Color.Black
            cmbOperator.ForeColor = Color.Black
            btnCalculate.ForeColor = Color.Black
            btnFormatCurrency.ForeColor = Color.Black
            btnFormatNumber.ForeColor = Color.Black
        End If

        ' Populate Calculator Operators
        cmbOperator.Items.Clear()
        cmbOperator.Items.AddRange({"+ (Addition)", "- (Subtraction)", "* (Multiplication)", "/ (Division)", "\ (Integer Division)", "Mod (Modulus)", "^ (Exponentiation)"})
        cmbOperator.SelectedIndex = 0
    End Sub

    ' ==========================================
    ' TOPIC 1: THE ARITHMETIC CALCULATOR
    ' ==========================================
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Local Variables demonstrating Scope and Data Types
        Dim num1 As Double
        Dim num2 As Double
        Dim result As Double
        Dim intResult As Integer

        ' Explicit Conversion using Parse
        If Double.TryParse(txtNum1.Text, num1) AndAlso Double.TryParse(txtNum2.Text, num2) Then
            Dim opSelection As String = cmbOperator.SelectedItem.ToString()
            Dim outputStr As String = ""

            Try
                Select Case opSelection
                    Case "+ (Addition)"
                        result = num1 + num2
                        outputStr = $"{num1} + {num2} = {result}"
                    Case "- (Subtraction)"
                        result = num1 - num2
                        outputStr = $"{num1} - {num2} = {result}"
                    Case "* (Multiplication)"
                        result = num1 * num2
                        outputStr = $"{num1} * {num2} = {result}"
                    Case "/ (Division)"
                        If num2 = 0 Then Throw New DivideByZeroException()
                        result = num1 / num2
                        outputStr = $"{num1} / {num2} = {result}"
                    Case "\ (Integer Division)"
                        If num2 = 0 Then Throw New DivideByZeroException()
                        ' Integer Division discards the remainder
                        intResult = CInt(num1) \ CInt(num2)
                        outputStr = $"{CInt(num1)} \ {CInt(num2)} = {intResult} (Integer Result)"
                    Case "Mod (Modulus)"
                        If num2 = 0 Then Throw New DivideByZeroException()
                        ' Modulus returns the remainder
                        result = num1 Mod num2
                        outputStr = $"{num1} Mod {num2} = {result} (Remainder)"
                    Case "^ (Exponentiation)"
                        result = num1 ^ num2
                        outputStr = $"{num1} ^ {num2} = {result}"
                End Select

                lblOutput.ForeColor = Color.Lime
                lblOutput.Text = $"[Calculation Success]{vbCrLf}{outputStr}"
            Catch ex As DivideByZeroException
                lblOutput.ForeColor = Color.Tomato
                lblOutput.Text = "Error: Cannot divide by zero."
            End Try
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Data Type Error: Please enter valid numbers."
        End If
    End Sub

    ' ==========================================
    ' TOPIC 2: DATA CONVERSION & FORMATTING
    ' ==========================================
    Private Sub btnFormatCurrency_Click(sender As Object, e As EventArgs) Handles btnFormatCurrency.Click
        Dim inputVal As Decimal
        ' Using Parse method to convert String to Decimal
        If Decimal.TryParse(txtConvert.Text, inputVal) Then
            ' Applying Assignment Operator (+=) and Constants
            Dim taxAmount As Decimal = inputVal * SALES_TAX_RATE_DECIMAL
            Dim total As Decimal = inputVal
            total += taxAmount

            lblOutput.ForeColor = Color.Cyan
            lblOutput.Text = $"[Conversion & Formatting]{vbCrLf}" &
                             $"Base: {inputVal.ToString("C2")}{vbCrLf}" &
                             $"Tax (12%): {taxAmount.ToString("C2")}{vbCrLf}" &
                             $"Total: {total.ToString("C2")}"
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Parse Error: Invalid Decimal input."
        End If
    End Sub

    Private Sub btnFormatNumber_Click(sender As Object, e As EventArgs) Handles btnFormatNumber.Click
        Dim inputVal As Double
        If Double.TryParse(txtConvert.Text, inputVal) Then
            ' Explicitly casting Double to Integer
            Dim roundedInt As Integer = Convert.ToInt32(inputVal)

            lblOutput.ForeColor = Color.Yellow
            lblOutput.Text = $"[Data Types & Precision]{vbCrLf}" &
                             $"Original Double: {inputVal}{vbCrLf}" &
                             $"Formatted (N2): {inputVal.ToString("N2")}{vbCrLf}" &
                             $"Cast to Integer: {roundedInt.ToString("N0")}"
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Parse Error: Invalid numeric input."
        End If
    End Sub
End Class
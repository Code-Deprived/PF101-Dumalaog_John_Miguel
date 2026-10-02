Imports System.Drawing
Imports System.Windows.Forms

Public Class Week5Form
    Inherits BaseLessonForm

    ' [ADVANCED TOPIC] Constants: Values fixed over time. 
    ' Module rule: Constants must have an initial value specified[cite: 13].
    Private Const SALES_TAX_RATE As Decimal = 0.12D
    Private Const MAX_INVENTORY As Short = 99

    ' [ADVANCED TOPIC] Enums: Strongly typed named constants for operators
    Private Enum CalcOp
        None
        Add
        Subtract
        Multiply
        Divide
        Power
    End Enum

    ' --- STATE VARIABLES ---
    Private calcStoredValue As Decimal = 0
    Private calcCurrentOp As CalcOp = CalcOp.None
    Private calcNewNumberStart As Boolean = True

    ' --- DYNAMIC UI CONTROLS ---
    Private pnlCalculator As New DoubleBufferedPanel()
    Private lblCalcDisplay As New Label()
    Private pnlData As New DoubleBufferedPanel()
    Private lstMemory As New ListBox()

    Private Sub Week5Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Week 5: Data Handling & Variables"

        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Clear()

            ' Setup Split Layout
            InitializeCalculatorUI()
            InitializeDataHandlingUI()
            InitializeLessonText()
        End If
    End Sub

    ' ==========================================
    ' TOPIC 1: THE "TERRARIA" REAL CALCULATOR
    ' ==========================================
    Private Sub InitializeCalculatorUI()
        pnlCalculator.Size = New Size(260, 360)
        pnlCalculator.Location = New Point(20, 20)
        pnlCalculator.BackColor = Color.FromArgb(40, 45, 65) ' Terraria Stone/Night
        pnlCalculator.BorderStyle = BorderStyle.FixedSingle

        ' Calculator Display
        lblCalcDisplay.SetBounds(10, 10, 240, 50)
        lblCalcDisplay.BackColor = Color.FromArgb(15, 20, 30)
        lblCalcDisplay.ForeColor = Color.Lime
        lblCalcDisplay.Font = GetAndyFont(22.0F, FontStyle.Bold)
        lblCalcDisplay.TextAlign = ContentAlignment.MiddleRight
        lblCalcDisplay.Text = "0"
        lblCalcDisplay.BorderStyle = BorderStyle.Fixed3D
        pnlCalculator.Controls.Add(lblCalcDisplay)

        ' [ADVANCED TOPIC] Dynamic Control Arrays & Lambda Event Handlers
        Dim buttons(,) As String = {
            {"7", "8", "9", "/"},
            {"4", "5", "6", "*"},
            {"1", "2", "3", "-"},
            {"C", "0", ".", "+"},
            {"^", "TAX", "", "="}
        }

        Dim btnSize As Integer = 55
        Dim spacing As Integer = 5
        Dim startX As Integer = 10
        Dim startY As Integer = 70

        For row As Integer = 0 To 4
            For col As Integer = 0 To 3
                Dim btnText As String = buttons(row, col)
                If String.IsNullOrEmpty(btnText) Then Continue For

                Dim btn As New Button() With {
                    .Text = btnText,
                    .Size = New Size(btnSize, btnSize),
                    .Location = New Point(startX + (col * (btnSize + spacing)), startY + (row * (btnSize + spacing))),
                    .BackColor = Color.FromArgb(70, 75, 95),
                    .ForeColor = Color.White,
                    .Font = GetAndyFont(14.0F, FontStyle.Bold),
                    .FlatStyle = FlatStyle.Flat,
                    .Cursor = Cursors.Hand
                }
                btn.FlatAppearance.BorderColor = Color.Gold

                ' Wire up events dynamically based on button type
                If IsNumeric(btnText) OrElse btnText = "." Then
                    AddHandler btn.Click, Sub(s, e) HandleNumberInput(btnText)
                ElseIf btnText = "C" Then
                    AddHandler btn.Click, Sub(s, e) HandleClear()
                ElseIf btnText = "=" Then
                    AddHandler btn.Click, Sub(s, e) HandleEquals()
                ElseIf btnText = "TAX" Then
                    AddHandler btn.Click, Sub(s, e) HandleTax()
                Else
                    AddHandler btn.Click, Sub(s, e) HandleOperator(btnText)
                End If

                ' Hover Effects
                AddHandler btn.MouseEnter, Sub(s, e) btn.BackColor = Color.FromArgb(100, 105, 125)
                AddHandler btn.MouseLeave, Sub(s, e) btn.BackColor = Color.FromArgb(70, 75, 95)

                pnlCalculator.Controls.Add(btn)
            Next
        Next

        ' Span the equals button
        Dim eqBtn = pnlCalculator.Controls.OfType(Of Button).FirstOrDefault(Function(b) b.Text = "=")
        If eqBtn IsNot Nothing Then
            eqBtn.Width = (btnSize * 2) + spacing
            eqBtn.Location = New Point(startX + (2 * (btnSize + spacing)), startY + (4 * (btnSize + spacing)))
            eqBtn.BackColor = Color.SeaGreen
        End If

        pnlContainer.Controls.Add(pnlCalculator)
    End Sub

    ' --- CALCULATOR LOGIC ENGINE ---
    Private Sub HandleNumberInput(num As String)
        If calcNewNumberStart Then
            lblCalcDisplay.Text = If(num = ".", "0.", num)
            calcNewNumberStart = False
        Else
            If num = "." AndAlso lblCalcDisplay.Text.Contains(".") Then Return
            lblCalcDisplay.Text &= num
        End If
    End Sub

    Private Sub HandleOperator(opStr As String)
        Decimal.TryParse(lblCalcDisplay.Text, calcStoredValue)
        calcNewNumberStart = True
        Select Case opStr
            Case "+" : calcCurrentOp = CalcOp.Add
            Case "-" : calcCurrentOp = CalcOp.Subtract
            Case "*" : calcCurrentOp = CalcOp.Multiply
            Case "/" : calcCurrentOp = CalcOp.Divide
            Case "^" : calcCurrentOp = CalcOp.Power
        End Select
    End Sub

    Private Sub HandleEquals()
        Dim currentValue As Decimal
        Decimal.TryParse(lblCalcDisplay.Text, currentValue)
        Dim result As Decimal = 0

        Try
            Select Case calcCurrentOp
                Case CalcOp.Add : result = calcStoredValue + currentValue
                Case CalcOp.Subtract : result = calcStoredValue - currentValue
                Case CalcOp.Multiply : result = calcStoredValue * currentValue
                Case CalcOp.Divide
                    If currentValue = 0 Then Throw New DivideByZeroException()
                    result = calcStoredValue / currentValue
                Case CalcOp.Power : result = CDec(Math.Pow(CDbl(calcStoredValue), CDbl(currentValue)))
                Case Else : Return
            End Select
            lblCalcDisplay.Text = result.ToString("0.######")
        Catch ex As DivideByZeroException
            lblCalcDisplay.Text = "ERR: DIV/0"
        Catch ex As Exception
            lblCalcDisplay.Text = "ERROR"
        End Try

        calcCurrentOp = CalcOp.None
        calcNewNumberStart = True
    End Sub

    Private Sub HandleTax()
        Dim currentValue As Decimal
        If Decimal.TryParse(lblCalcDisplay.Text, currentValue) Then
            Dim taxAmount As Decimal = currentValue * SALES_TAX_RATE
            lblCalcDisplay.Text = (currentValue + taxAmount).ToString("0.##")
            calcNewNumberStart = True
        End If
    End Sub

    Private Sub HandleClear()
        lblCalcDisplay.Text = "0"
        calcStoredValue = 0
        calcCurrentOp = CalcOp.None
        calcNewNumberStart = True
    End Sub

    ' ==========================================
    ' TOPIC 2: DATA HANDLING & MEMORY VISUALIZER
    ' ==========================================
    Private Sub InitializeDataHandlingUI()
        pnlData.Size = New Size(260, 360)
        pnlData.Location = New Point(300, 20)
        pnlData.BackColor = Color.FromArgb(30, 35, 50)
        pnlData.BorderStyle = BorderStyle.FixedSingle

        Dim lblTitle As New Label() With {.Text = "Variable Memory Allocation", .ForeColor = Color.Gold, .Location = New Point(10, 10), .AutoSize = True, .Font = GetAndyFont(14.0F, FontStyle.Bold)}

        Dim lblName As New Label() With {.Text = "Item Name (String):", .ForeColor = Color.White, .Location = New Point(10, 45), .AutoSize = True}
        Dim txtName As New TextBox() With {.Location = New Point(10, 65), .Width = 230, .BackColor = Color.FromArgb(15, 20, 30), .ForeColor = Color.White}

        Dim lblQty As New Label() With {.Text = "Quantity (Integer):", .ForeColor = Color.White, .Location = New Point(10, 100), .AutoSize = True}
        Dim txtQty As New TextBox() With {.Location = New Point(10, 120), .Width = 230, .BackColor = Color.FromArgb(15, 20, 30), .ForeColor = Color.White}

        Dim lblPrice As New Label() With {.Text = "Base Price (Decimal):", .ForeColor = Color.White, .Location = New Point(10, 155), .AutoSize = True}
        Dim txtPrice As New TextBox() With {.Location = New Point(10, 175), .Width = 230, .BackColor = Color.FromArgb(15, 20, 30), .ForeColor = Color.White}

        Dim btnAllocate As New Button() With {
            .Text = "Allocate to RAM", .Location = New Point(10, 215), .Size = New Size(230, 35),
            .BackColor = Color.SeaGreen, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
        }
        btnAllocate.FlatAppearance.BorderColor = Color.Gold

        lstMemory.SetBounds(10, 260, 230, 80)
        lstMemory.BackColor = Color.Black
        lstMemory.ForeColor = Color.Cyan
        lstMemory.Font = New Font("Consolas", 9.0F)

        AddHandler btnAllocate.Click, Sub(s, e)
                                          Dim itemName As String = txtName.Text
                                          Dim qty As Integer
                                          Dim price As Decimal

                                          lstMemory.Items.Clear()
                                          If String.IsNullOrWhiteSpace(itemName) OrElse Not Integer.TryParse(txtQty.Text, qty) OrElse Not Decimal.TryParse(txtPrice.Text, price) Then
                                              lstMemory.ForeColor = Color.Tomato
                                              lstMemory.Items.Add("ERR: Data Type Mismatch.")
                                              lstMemory.Items.Add("Check Int/Dec formats.")
                                              Return
                                          End If

                                          lstMemory.ForeColor = Color.Cyan
                                          lstMemory.Items.Add($"[String]  Item: {itemName}")
                                          lstMemory.Items.Add($"[Integer] Qty:  {qty}")
                                          lstMemory.Items.Add($"[Decimal] Cost: {price:C2}")
                                      End Sub

        pnlData.Controls.AddRange({lblTitle, lblName, txtName, lblQty, txtQty, lblPrice, txtPrice, btnAllocate, lstMemory})
        pnlContainer.Controls.Add(pnlData)
    End Sub

    Private Sub InitializeLessonText()
        Dim txtLesson As New RichTextBox() With {
            .Size = New Size(200, 360),
            .Location = New Point(580, 20),
            .BackColor = Color.FromArgb(20, 25, 40),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 9.0F),
            .BorderStyle = BorderStyle.None,
            .ReadOnly = True
        }

        txtLesson.Text = "MODULE REVIEW: DATA HANDLING" & vbCrLf & vbCrLf &
                         "Variables: Provide a means to store data values to random access memory. They support computation through assignment statements[cite: 13]." & vbCrLf & vbCrLf &
                         "Naming Rules:" & vbCrLf &
                         "- Include letters, digits, underscores." & vbCrLf &
                         "- Must begin with a letter." & vbCrLf &
                         "- No spaces, periods, or reserved words (like LET, DIM)." & vbCrLf &
                         "- Not case sensitive." & vbCrLf & vbCrLf &
                         "Key Data Types:" & vbCrLf &
                         "- String: Alphabetic characters." & vbCrLf &
                         "- Decimal: Calculations requiring precision (dollars/cents)." & vbCrLf &
                         "- Integer: Whole numbers (e.g., inventory)." & vbCrLf &
                         "- Single: Used for percentages or scientific calculations." & vbCrLf & vbCrLf &
                         "Modifiers:" & vbCrLf &
                         "- Dim: Local scope." & vbCrLf &
                         "- Private: Module-level scope." & vbCrLf &
                         "- Const: Fixed values that cannot change during execution."

        pnlContainer.Controls.Add(txtLesson)
    End Sub
End Class
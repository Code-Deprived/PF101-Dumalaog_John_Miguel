Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading.Tasks

Public Class Week6Form
    Inherits BaseLessonForm

    ' --- DYNAMIC UI CONTROLS ---
    Private dgvTruthTable As New DataGridView()
    Private WithEvents btnMine As New Button()
    Private WithEvents btnWorldTime As New Button()

    ' Boolean Flag as required by the module
    Private isMining As Boolean = False

    Private Sub Week6Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTruthOp.SelectedIndex = 0

        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If

        InitializeTerrariaAesthetics()
        SetupAdvancedControls()
        UpdateLessonText()
    End Sub

    Private Sub InitializeTerrariaAesthetics()
        ' Enforce Terraria Night/Underworld colors
        pnlInteractive.BackColor = Color.FromArgb(25, 30, 50)
        lblOutput.BackColor = Color.FromArgb(10, 10, 15)
        lblOutput.ForeColor = Color.Lime
        lblOutput.Font = New Font("Consolas", 10.0F, FontStyle.Regular)

        ' Upgrade existing buttons
        Dim buttons As Button() = {btnTax, btnGrade, btnLoop, btnTruth, btnMine, btnWorldTime}
        For Each btn In buttons
            btn.BackColor = Color.FromArgb(60, 70, 110)
            btn.ForeColor = Color.White
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.Gold
            btn.Cursor = Cursors.Hand
        Next

        ' Textboxes
        Dim textboxes As TextBox() = {txtTax, txtGrade}
        For Each tb In textboxes
            tb.BackColor = Color.FromArgb(30, 35, 60)
            tb.ForeColor = Color.Gold
            tb.BorderStyle = BorderStyle.FixedSingle
        Next
    End Sub

    Private Sub SetupAdvancedControls()
        ' 1. Re-add Missing Text for Dynamic Buttons
        btnWorldTime.Text = "Check World Time"
        btnMine.Text = "Mine (Do While)"

        ' Hide redundant loops button if it exists
        If btnLoop IsNot Nothing Then btnLoop.Visible = False

        ' 2. Fix the Top Row Overlap & Position Designer Labels
        For Each ctrl As Control In pnlInteractive.Controls
            If TypeOf ctrl Is Label Then
                ' Hide the big title label that is overlapping the inputs
                If ctrl.Text.Contains("Control Structures") Then
                    ctrl.Visible = False
                    ' Position the input labels
                ElseIf ctrl.Text.Contains("Tax") Then
                    ctrl.Location = New Point(15, 18)
                ElseIf ctrl.Text.Contains("Grade") Then
                    ctrl.Location = New Point(200, 18) ' Pushed right slightly to prevent cramping
                End If
            End If
        Next

        ' 3. Top Row Inputs (Y = 15)
        txtTax.SetBounds(115, 15, 75, 22) ' Made slightly wider
        txtGrade.SetBounds(275, 15, 70, 22)

        ' 4. Row 1 Buttons (Y = 50) - Shifted down 5px for breathing room
        btnTax.SetBounds(15, 50, 160, 30)
        btnGrade.SetBounds(185, 50, 160, 30)

        ' 5. Row 2 Buttons (Y = 90)
        btnWorldTime.SetBounds(15, 90, 160, 30)
        btnMine.SetBounds(185, 90, 160, 30)

        ' 6. Row 3 Logic / Truth Table (Y = 130)
        If lblTruthOp IsNot Nothing Then lblTruthOp.Location = New Point(15, 135)
        cmbTruthOp.SetBounds(85, 131, 90, 25)
        btnTruth.SetBounds(185, 130, 160, 30)

        ' 7. Bottom Area: Output Console & DataGrid (Y = 170)
        lblOutput.SetBounds(15, 170, 330, 145)

        dgvTruthTable.SetBounds(15, 170, 330, 145)
        dgvTruthTable.BackgroundColor = Color.FromArgb(15, 20, 38)
        dgvTruthTable.ForeColor = Color.Black
        dgvTruthTable.RowHeadersVisible = False
        dgvTruthTable.AllowUserToAddRows = False
        dgvTruthTable.ReadOnly = True
        dgvTruthTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTruthTable.Visible = False

        ' 8. Add and Layer Controls
        pnlInteractive.Controls.Add(btnMine)
        pnlInteractive.Controls.Add(btnWorldTime)
        pnlInteractive.Controls.Add(dgvTruthTable)

        lblOutput.BringToFront()
        dgvTruthTable.BringToFront()
    End Sub

    Private Sub UpdateLessonText()
        lblLesson.Font = GetAndyFont(11.0F, FontStyle.Regular)
        lblLesson.Text = "Week 6: Selection & Repetition" & vbCrLf & vbCrLf &
                         "If...Then...ElseIf: Evaluates binary relational operators. The If...Then...ElseIf statement allows for an entire series of possible choices." & vbCrLf & vbCrLf &
                         "Boolean Flags: A flag is a Boolean variable that signals when some condition exists in the program." & vbCrLf & vbCrLf &
                         "Repetition (Loops):" & vbCrLf &
                         "- For...Next: Runs a specific number of times." & vbCrLf &
                         "- Do While: Runs as long as a condition remains True." & vbCrLf &
                         "- Continue: Skips the current loop iteration." & vbCrLf &
                         "- Exit: Breaks out of the loop entirely."
    End Sub

    ' --- DATE AND TIME ---
    Private Sub btnWorldTime_Click(sender As Object, e As EventArgs) Handles btnWorldTime.Click
        dgvTruthTable.Visible = False
        lblOutput.Visible = True

        ' Module focus: Date and Time
        Dim currentTime As DateTime = DateTime.Now
        Dim timeOfDay As String = If(currentTime.Hour >= 6 And currentTime.Hour < 18, "Daytime", "Nighttime")

        lblOutput.ForeColor = Color.Gold
        lblOutput.Text = $"Terraria World Time:{vbCrLf}" &
                         $"Current Date: {currentTime.ToShortDateString()}{vbCrLf}" &
                         $"Current Time: {currentTime.ToLongTimeString()}{vbCrLf}" &
                         $"Status: {timeOfDay}"
    End Sub

    ' --- ASYNC DO WHILE LOOP + EXIT/CONTINUE ---
    Private Async Sub btnMine_Click(sender As Object, e As EventArgs) Handles btnMine.Click
        If isMining Then Return

        dgvTruthTable.Visible = False
        lblOutput.Visible = True
        isMining = True ' Boolean Flag in action

        lblOutput.ForeColor = Color.Lime
        lblOutput.Text = "Starting Mining Expedition (Do While)..." & vbCrLf

        Dim depth As Integer = 0
        Dim rng As New Random()

        ' Module focus: Do While Loop
        Do While depth < 5
            Await Task.Delay(500) ' Keeps UI responsive during loop
            depth += 1
            Dim blockType As Integer = rng.Next(1, 4)

            ' Module focus: Continue and Exit statements
            If blockType = 1 Then
                lblOutput.Text &= $"- Depth {depth}: Dirt. (Continue - Skipping){vbCrLf}"
                Continue Do ' Skips the rest of this iteration
            End If

            If blockType = 2 Then
                lblOutput.Text &= $"- Depth {depth}: Lava! (Exit Do - Escaping!){vbCrLf}"
                Exit Do ' Breaks out of the loop completely
            End If

            lblOutput.Text &= $"- Depth {depth}: Found Gold Ore!{vbCrLf}"
        Loop

        lblOutput.Text &= "Expedition Ended."
        isMining = False
    End Sub

    ' --- TRUTH TABLE (DATAGRIDVIEW) ---
    Private Sub btnTruth_Click(sender As Object, e As EventArgs) Handles btnTruth.Click
        If cmbTruthOp.SelectedItem Is Nothing Then Return

        lblOutput.Visible = False
        dgvTruthTable.Visible = True
        Dim operatorSelected As String = cmbTruthOp.SelectedItem.ToString()

        ' Clear previous data
        dgvTruthTable.Columns.Clear()
        dgvTruthTable.Rows.Clear()

        If operatorSelected = "NOT (A)" Then
            dgvTruthTable.Columns.Add("A", "Input A")
            dgvTruthTable.Columns.Add("Result", "NOT A")
            dgvTruthTable.Rows.Add("True", "False")
            dgvTruthTable.Rows.Add("False", "True")
        Else
            dgvTruthTable.Columns.Add("A", "Input A")
            dgvTruthTable.Columns.Add("B", "Input B")
            dgvTruthTable.Columns.Add("Result", $"A {operatorSelected} B")

            Dim states() As Boolean = {True, False}
            For Each a As Boolean In states
                For Each b As Boolean In states
                    Dim result As Boolean
                    Select Case operatorSelected
                        Case "AND" : result = a And b
                        Case "OR" : result = a Or b
                        Case "XOR" : result = a Xor b
                    End Select
                    dgvTruthTable.Rows.Add(a.ToString(), b.ToString(), result.ToString())
                Next
            Next
        End If
    End Sub

    ' --- IF/ELSEIF & CONSTANTS ---
    ' Wires up the "Calculate (If/Else Const)" button
    Private Sub btnTax_Click(sender As Object, e As EventArgs) Handles btnTax.Click
        dgvTruthTable.Visible = False
        lblOutput.Visible = True

        ' Module focus: Named Constants and If/Else logic
        Const TAX_RATE As Double = 0.12 ' 12% Goblin Tinkerer Tax
        Dim amount As Double

        If Double.TryParse(txtTax.Text, amount) Then
            If amount < 0 Then
                lblOutput.ForeColor = Color.Tomato
                lblOutput.Text = "Invalid: Coin amount cannot be negative."
            ElseIf amount = 0 Then
                lblOutput.ForeColor = Color.Lime
                lblOutput.Text = "Tax Exempt: No coins to tax."
            Else
                Dim totalTax As Double = amount * TAX_RATE
                lblOutput.ForeColor = Color.Gold
                lblOutput.Text = $"Coin Stack: {amount}{vbCrLf}" &
                                 $"Goblin Tax Rate (Const): {TAX_RATE * 100}%{vbCrLf}" &
                                 $"Total Tax Deducted: {totalTax} Coins"
            End If
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Input Error: Enter a valid number for Tax."
        End If
    End Sub

    ' --- SELECT CASE ---
    ' Wires up the "Eval (Select Case)" button
    Private Sub btnGrade_Click(sender As Object, e As EventArgs) Handles btnGrade.Click
        dgvTruthTable.Visible = False
        lblOutput.Visible = True

        ' Module focus: Select Case Statement
        Dim grade As String = txtGrade.Text.Trim().ToUpper()

        Select Case grade
            Case "A"
                lblOutput.ForeColor = Color.Gold
                lblOutput.Text = "Grade A: Legendary Drop! (Select Case Executed)"
            Case "B"
                lblOutput.ForeColor = Color.Cyan
                lblOutput.Text = "Grade B: Rare Drop! (Select Case Executed)"
            Case "C"
                lblOutput.ForeColor = Color.Lime
                lblOutput.Text = "Grade C: Uncommon Drop. (Select Case Executed)"
            Case "D"
                lblOutput.ForeColor = Color.White
                lblOutput.Text = "Grade D: Common Drop. (Select Case Executed)"
            Case "F"
                lblOutput.ForeColor = Color.Tomato
                lblOutput.Text = "Grade F: You died! (Select Case Executed)"
            Case Else
                lblOutput.ForeColor = Color.Tomato
                lblOutput.Text = "Input Error: Enter a valid grade (A, B, C, D, or F)."
        End Select
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week6Form
    Inherits BaseLessonForm

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents pnlInteractive As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents btnTax As System.Windows.Forms.Button
    Friend WithEvents lblGrade As System.Windows.Forms.Label
    Friend WithEvents txtGrade As System.Windows.Forms.TextBox
    Friend WithEvents btnGrade As System.Windows.Forms.Button
    Friend WithEvents btnLoop As System.Windows.Forms.Button
    Friend WithEvents lblTruthA As System.Windows.Forms.Label
    Friend WithEvents cmbTruthA As System.Windows.Forms.ComboBox
    Friend WithEvents lblTruthOp As System.Windows.Forms.Label
    Friend WithEvents cmbTruthOp As System.Windows.Forms.ComboBox
    Friend WithEvents lblTruthB As System.Windows.Forms.Label
    Friend WithEvents cmbTruthB As System.Windows.Forms.ComboBox
    Friend WithEvents btnTruth As System.Windows.Forms.Button
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents lblLesson As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Week6Form))
        pnlInteractive = New Panel()
        lblOutput = New Label()
        btnTruth = New Button()
        cmbTruthB = New ComboBox()
        lblTruthB = New Label()
        cmbTruthOp = New ComboBox()
        lblTruthOp = New Label()
        cmbTruthA = New ComboBox()
        lblTruthA = New Label()
        btnLoop = New Button()
        btnGrade = New Button()
        txtGrade = New TextBox()
        lblGrade = New Label()
        btnTax = New Button()
        txtTax = New TextBox()
        lblTax = New Label()
        lblTitle = New Label()
        lblLesson = New Label()
        pnlInteractive.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlInteractive
        ' 
        pnlInteractive.BackColor = Color.Transparent
        pnlInteractive.Controls.Add(lblOutput)
        pnlInteractive.Controls.Add(btnTruth)
        pnlInteractive.Controls.Add(cmbTruthB)
        pnlInteractive.Controls.Add(lblTruthB)
        pnlInteractive.Controls.Add(cmbTruthOp)
        pnlInteractive.Controls.Add(lblTruthOp)
        pnlInteractive.Controls.Add(cmbTruthA)
        pnlInteractive.Controls.Add(lblTruthA)
        pnlInteractive.Controls.Add(btnLoop)
        pnlInteractive.Controls.Add(btnGrade)
        pnlInteractive.Controls.Add(txtGrade)
        pnlInteractive.Controls.Add(lblGrade)
        pnlInteractive.Controls.Add(btnTax)
        pnlInteractive.Controls.Add(txtTax)
        pnlInteractive.Controls.Add(lblTax)
        pnlInteractive.Controls.Add(lblTitle)
        pnlInteractive.Location = New Point(30, 75)
        pnlInteractive.Name = "pnlInteractive"
        pnlInteractive.Size = New Size(360, 375)
        pnlInteractive.TabIndex = 0
        ' 
        ' lblOutput
        ' 
        lblOutput.BackColor = Color.Black
        lblOutput.BorderStyle = BorderStyle.FixedSingle
        lblOutput.Font = New Font("Consolas", 10.2F)
        lblOutput.ForeColor = Color.Lime
        lblOutput.Location = New Point(15, 315)
        lblOutput.Name = "lblOutput"
        lblOutput.Size = New Size(330, 55)
        lblOutput.TabIndex = 15
        lblOutput.Text = "Waiting for input..."
        ' 
        ' btnTruth
        ' 
        btnTruth.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnTruth.ForeColor = Color.White
        btnTruth.Location = New Point(15, 275)
        btnTruth.Name = "btnTruth"
        btnTruth.Size = New Size(330, 30)
        btnTruth.TabIndex = 14
        btnTruth.Text = "Evaluate Truth Table"
        btnTruth.UseVisualStyleBackColor = False
        ' 
        ' cmbTruthB
        ' 
        cmbTruthB.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTruthB.FormattingEnabled = True
        cmbTruthB.Items.AddRange(New Object() {"True", "False"})
        cmbTruthB.Location = New Point(255, 237)
        cmbTruthB.Name = "cmbTruthB"
        cmbTruthB.Size = New Size(65, 28)
        cmbTruthB.TabIndex = 13
        ' 
        ' lblTruthB
        ' 
        lblTruthB.AutoSize = True
        lblTruthB.ForeColor = Color.White
        lblTruthB.Location = New Point(230, 240)
        lblTruthB.Name = "lblTruthB"
        lblTruthB.Size = New Size(21, 20)
        lblTruthB.TabIndex = 12
        lblTruthB.Text = "B:"
        ' 
        ' cmbTruthOp
        ' 
        cmbTruthOp.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTruthOp.FormattingEnabled = True
        cmbTruthOp.Items.AddRange(New Object() {"AND", "OR", "XOR", "NOT (A)"})
        cmbTruthOp.Location = New Point(145, 237)
        cmbTruthOp.Name = "cmbTruthOp"
        cmbTruthOp.Size = New Size(75, 28)
        cmbTruthOp.TabIndex = 11
        ' 
        ' lblTruthOp
        ' 
        lblTruthOp.AutoSize = True
        lblTruthOp.ForeColor = Color.White
        lblTruthOp.Location = New Point(110, 240)
        lblTruthOp.Name = "lblTruthOp"
        lblTruthOp.Size = New Size(31, 20)
        lblTruthOp.TabIndex = 10
        lblTruthOp.Text = "OP:"
        ' 
        ' cmbTruthA
        ' 
        cmbTruthA.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTruthA.FormattingEnabled = True
        cmbTruthA.Items.AddRange(New Object() {"True", "False"})
        cmbTruthA.Location = New Point(40, 237)
        cmbTruthA.Name = "cmbTruthA"
        cmbTruthA.Size = New Size(65, 28)
        cmbTruthA.TabIndex = 9
        ' 
        ' lblTruthA
        ' 
        lblTruthA.AutoSize = True
        lblTruthA.ForeColor = Color.White
        lblTruthA.Location = New Point(15, 240)
        lblTruthA.Name = "lblTruthA"
        lblTruthA.Size = New Size(22, 20)
        lblTruthA.TabIndex = 8
        lblTruthA.Text = "A:"
        ' 
        ' btnLoop
        ' 
        btnLoop.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnLoop.ForeColor = Color.White
        btnLoop.Location = New Point(15, 195)
        btnLoop.Name = "btnLoop"
        btnLoop.Size = New Size(330, 30)
        btnLoop.TabIndex = 7
        btnLoop.Text = "Run For...Next Loop"
        btnLoop.UseVisualStyleBackColor = False
        ' 
        ' btnGrade
        ' 
        btnGrade.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnGrade.ForeColor = Color.White
        btnGrade.Location = New Point(15, 155)
        btnGrade.Name = "btnGrade"
        btnGrade.Size = New Size(330, 30)
        btnGrade.TabIndex = 6
        btnGrade.Text = "Evaluate (Select Case)"
        btnGrade.UseVisualStyleBackColor = False
        ' 
        ' txtGrade
        ' 
        txtGrade.Location = New Point(135, 120)
        txtGrade.Name = "txtGrade"
        txtGrade.Size = New Size(210, 27)
        txtGrade.TabIndex = 5
        ' 
        ' lblGrade
        ' 
        lblGrade.AutoSize = True
        lblGrade.ForeColor = Color.White
        lblGrade.Location = New Point(10, 123)
        lblGrade.Name = "lblGrade"
        lblGrade.Size = New Size(89, 20)
        lblGrade.TabIndex = 4
        lblGrade.Text = "Grade (A-F):"
        ' 
        ' btnTax
        ' 
        btnTax.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnTax.ForeColor = Color.White
        btnTax.Location = New Point(15, 80)
        btnTax.Name = "btnTax"
        btnTax.Size = New Size(330, 30)
        btnTax.TabIndex = 3
        btnTax.Text = "Calculate (If/Else & Const)"
        btnTax.UseVisualStyleBackColor = False
        ' 
        ' txtTax
        ' 
        txtTax.Location = New Point(135, 45)
        txtTax.Name = "txtTax"
        txtTax.Size = New Size(210, 27)
        txtTax.TabIndex = 2
        ' 
        ' lblTax
        ' 
        lblTax.AutoSize = True
        lblTax.ForeColor = Color.White
        lblTax.Location = New Point(10, 48)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(113, 20)
        lblTax.TabIndex = 1
        lblTax.Text = "Amount for Tax:"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(10, 5)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(252, 28)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Control Structures & Logic:"
        ' 
        ' lblLesson
        ' 
        lblLesson.BackColor = Color.Transparent
        lblLesson.Font = New Font("Segoe UI", 9.5F)
        lblLesson.ForeColor = Color.White
        lblLesson.Location = New Point(400, 75)
        lblLesson.Name = "lblLesson"
        lblLesson.Size = New Size(360, 375)
        lblLesson.TabIndex = 1
        lblLesson.Text = resources.GetString("lblLesson.Text")
        ' 
        ' Week6Form
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        ClientSize = New Size(850, 580)
        Controls.Add(lblLesson)
        Controls.Add(pnlInteractive)
        Name = "Week6Form"
        Text = "Week 6 - Control Structures & Logic"
        Controls.SetChildIndex(pnlInteractive, 0)
        Controls.SetChildIndex(lblLesson, 0)
        Controls.SetChildIndex(pnlContainer, 0)
        pnlInteractive.ResumeLayout(False)
        pnlInteractive.PerformLayout()
        ResumeLayout(False)

    End Sub
End Class
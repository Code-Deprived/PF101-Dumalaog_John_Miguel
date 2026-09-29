<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week5Form
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlInteractive = New System.Windows.Forms.Panel()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.grpConversion = New System.Windows.Forms.GroupBox()
        Me.btnFormatNumber = New System.Windows.Forms.Button()
        Me.btnFormatCurrency = New System.Windows.Forms.Button()
        Me.txtConvert = New System.Windows.Forms.TextBox()
        Me.lblConvert = New System.Windows.Forms.Label()
        Me.grpCalculator = New System.Windows.Forms.GroupBox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.txtNum2 = New System.Windows.Forms.TextBox()
        Me.lblNum2 = New System.Windows.Forms.Label()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.txtNum1 = New System.Windows.Forms.TextBox()
        Me.lblNum1 = New System.Windows.Forms.Label()
        Me.pnlInteractive.SuspendLayout()
        Me.grpConversion.SuspendLayout()
        Me.grpCalculator.SuspendLayout()
        Me.SuspendLayout()
        '
        ' pnlInteractive
        '
        Me.pnlInteractive.Controls.Add(Me.lblOutput)
        Me.pnlInteractive.Controls.Add(Me.grpConversion)
        Me.pnlInteractive.Controls.Add(Me.grpCalculator)
        Me.pnlInteractive.Location = New System.Drawing.Point(20, 20)
        Me.pnlInteractive.Name = "pnlInteractive"
        Me.pnlInteractive.Size = New System.Drawing.Size(760, 410)
        Me.pnlInteractive.TabIndex = 0
        '
        ' lblOutput
        '
        Me.lblOutput.BackColor = System.Drawing.Color.Black
        Me.lblOutput.Font = New System.Drawing.Font("Consolas", 11.25F)
        Me.lblOutput.ForeColor = System.Drawing.Color.Lime
        Me.lblOutput.Location = New System.Drawing.Point(20, 310)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Padding = New System.Windows.Forms.Padding(10)
        Me.lblOutput.Size = New System.Drawing.Size(720, 90)
        Me.lblOutput.TabIndex = 2
        Me.lblOutput.Text = "System Output Ready..."
        '
        ' grpConversion
        '
        Me.grpConversion.Controls.Add(Me.btnFormatNumber)
        Me.grpConversion.Controls.Add(Me.btnFormatCurrency)
        Me.grpConversion.Controls.Add(Me.txtConvert)
        Me.grpConversion.Controls.Add(Me.lblConvert)
        Me.grpConversion.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold)
        Me.grpConversion.Location = New System.Drawing.Point(20, 165)
        Me.grpConversion.Name = "grpConversion"
        Me.grpConversion.Size = New System.Drawing.Size(720, 130)
        Me.grpConversion.TabIndex = 1
        Me.grpConversion.TabStop = False
        Me.grpConversion.Text = "Topic 2: Data Conversion && Formatting"
        '
        ' btnFormatNumber
        '
        Me.btnFormatNumber.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.btnFormatNumber.Location = New System.Drawing.Point(460, 54)
        Me.btnFormatNumber.Name = "btnFormatNumber"
        Me.btnFormatNumber.Size = New System.Drawing.Size(210, 32)
        Me.btnFormatNumber.TabIndex = 3
        Me.btnFormatNumber.Text = "Test Precision && Casting"
        Me.btnFormatNumber.UseVisualStyleBackColor = True
        '
        ' btnFormatCurrency
        '
        Me.btnFormatCurrency.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.btnFormatCurrency.Location = New System.Drawing.Point(260, 54)
        Me.btnFormatCurrency.Name = "btnFormatCurrency"
        Me.btnFormatCurrency.Size = New System.Drawing.Size(180, 32)
        Me.btnFormatCurrency.TabIndex = 2
        Me.btnFormatCurrency.Text = "Test Currency && Tax"
        Me.btnFormatCurrency.UseVisualStyleBackColor = True
        '
        ' txtConvert
        '
        Me.txtConvert.Font = New System.Drawing.Font("Segoe UI", 10.0F)
        Me.txtConvert.Location = New System.Drawing.Point(33, 58)
        Me.txtConvert.Name = "txtConvert"
        Me.txtConvert.Size = New System.Drawing.Size(200, 30)
        Me.txtConvert.TabIndex = 1
        '
        ' lblConvert
        '
        Me.lblConvert.AutoSize = True
        Me.lblConvert.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.lblConvert.Location = New System.Drawing.Point(30, 40)
        Me.lblConvert.Name = "lblConvert"
        Me.lblConvert.Size = New System.Drawing.Size(112, 20)
        Me.lblConvert.TabIndex = 0
        Me.lblConvert.Text = "Enter any value:"
        '
        ' grpCalculator
        '
        Me.grpCalculator.Controls.Add(Me.btnCalculate)
        Me.grpCalculator.Controls.Add(Me.txtNum2)
        Me.grpCalculator.Controls.Add(Me.lblNum2)
        Me.grpCalculator.Controls.Add(Me.cmbOperator)
        Me.grpCalculator.Controls.Add(Me.lblOp)
        Me.grpCalculator.Controls.Add(Me.txtNum1)
        Me.grpCalculator.Controls.Add(Me.lblNum1)
        Me.grpCalculator.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold)
        Me.grpCalculator.Location = New System.Drawing.Point(20, 20)
        Me.grpCalculator.Name = "grpCalculator"
        Me.grpCalculator.Size = New System.Drawing.Size(720, 130)
        Me.grpCalculator.TabIndex = 0
        Me.grpCalculator.TabStop = False
        Me.grpCalculator.Text = "Topic 1: Arithmetic Calculator"
        '
        ' btnCalculate
        '
        Me.btnCalculate.Font = New System.Drawing.Font("Segoe UI", 9.75F)
        Me.btnCalculate.Location = New System.Drawing.Point(520, 54)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(150, 32)
        Me.btnCalculate.TabIndex = 6
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        ' txtNum2
        '
        Me.txtNum2.Font = New System.Drawing.Font("Segoe UI", 10.0F)
        Me.txtNum2.Location = New System.Drawing.Point(373, 58)
        Me.txtNum2.Name = "txtNum2"
        Me.txtNum2.Size = New System.Drawing.Size(120, 30)
        Me.txtNum2.TabIndex = 5
        '
        ' lblNum2
        '
        Me.lblNum2.AutoSize = True
        Me.lblNum2.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.lblNum2.Location = New System.Drawing.Point(370, 40)
        Me.lblNum2.Name = "lblNum2"
        Me.lblNum2.Size = New System.Drawing.Size(78, 20)
        Me.lblNum2.TabIndex = 4
        Me.lblNum2.Text = "Number 2:"
        '
        ' cmbOperator
        '
        Me.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperator.Font = New System.Drawing.Font("Segoe UI", 10.0F)
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Location = New System.Drawing.Point(173, 58)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(180, 31)
        Me.cmbOperator.TabIndex = 3
        '
        ' lblOp
        '
        Me.lblOp.AutoSize = True
        Me.lblOp.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.lblOp.Location = New System.Drawing.Point(170, 40)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(72, 20)
        Me.lblOp.TabIndex = 2
        Me.lblOp.Text = "Operator:"
        '
        ' txtNum1
        '
        Me.txtNum1.Font = New System.Drawing.Font("Segoe UI", 10.0F)
        Me.txtNum1.Location = New System.Drawing.Point(33, 58)
        Me.txtNum1.Name = "txtNum1"
        Me.txtNum1.Size = New System.Drawing.Size(120, 30)
        Me.txtNum1.TabIndex = 1
        '
        ' lblNum1
        '
        Me.lblNum1.AutoSize = True
        Me.lblNum1.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        Me.lblNum1.Location = New System.Drawing.Point(30, 40)
        Me.lblNum1.Name = "lblNum1"
        Me.lblNum1.Size = New System.Drawing.Size(78, 20)
        Me.lblNum1.TabIndex = 0
        Me.lblNum1.Text = "Number 1:"
        '
        ' Week5Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0F, 20.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(18, 18, 18)
        Me.ClientSize = New System.Drawing.Size(850, 560)
        Me.Controls.Add(Me.pnlInteractive)
        Me.Name = "Week5Form"
        Me.Text = "Week 5: Data Handling"
        Me.Controls.SetChildIndex(Me.pnlInteractive, 0)
        Me.Controls.SetChildIndex(Me.pnlContainer, 0)
        Me.pnlInteractive.ResumeLayout(False)
        Me.grpConversion.ResumeLayout(False)
        Me.grpConversion.PerformLayout()
        Me.grpCalculator.ResumeLayout(False)
        Me.grpCalculator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlInteractive As System.Windows.Forms.Panel
    Friend WithEvents grpCalculator As System.Windows.Forms.GroupBox
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents txtNum2 As System.Windows.Forms.TextBox
    Friend WithEvents lblNum2 As System.Windows.Forms.Label
    Friend WithEvents cmbOperator As System.Windows.Forms.ComboBox
    Friend WithEvents lblOp As System.Windows.Forms.Label
    Friend WithEvents txtNum1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNum1 As System.Windows.Forms.Label
    Friend WithEvents grpConversion As System.Windows.Forms.GroupBox
    Friend WithEvents btnFormatNumber As System.Windows.Forms.Button
    Friend WithEvents btnFormatCurrency As System.Windows.Forms.Button
    Friend WithEvents txtConvert As System.Windows.Forms.TextBox
    Friend WithEvents lblConvert As System.Windows.Forms.Label
    Friend WithEvents lblOutput As System.Windows.Forms.Label

End Class
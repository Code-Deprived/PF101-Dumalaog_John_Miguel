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

    Friend WithEvents pnlInteractive As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label

    ' List & File Controls
    Friend WithEvents lblInputText As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents btnFile As System.Windows.Forms.Button

    ' Array Controls
    Friend WithEvents lblInputArray As System.Windows.Forms.Label
    Friend WithEvents txtArray As System.Windows.Forms.TextBox
    Friend WithEvents btnArray As System.Windows.Forms.Button

    ' Math Controls
    Friend WithEvents lblMathBase As System.Windows.Forms.Label
    Friend WithEvents numBase As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMathExp As System.Windows.Forms.Label
    Friend WithEvents numExp As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMath As System.Windows.Forms.Button

    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents lblLesson As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Week5Form))
        pnlInteractive = New Panel()
        lblOutput = New Label()
        btnMath = New Button()
        numExp = New NumericUpDown()
        lblMathExp = New Label()
        numBase = New NumericUpDown()
        lblMathBase = New Label()
        btnArray = New Button()
        txtArray = New TextBox()
        lblInputArray = New Label()
        btnFile = New Button()
        btnList = New Button()
        txtInput = New TextBox()
        lblInputText = New Label()
        lblTitle = New Label()
        lblLesson = New Label()
        pnlInteractive.SuspendLayout()
        CType(numExp, ComponentModel.ISupportInitialize).BeginInit()
        CType(numBase, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlInteractive
        ' 
        pnlInteractive.BackColor = Color.Transparent
        pnlInteractive.Controls.Add(lblOutput)
        pnlInteractive.Controls.Add(btnMath)
        pnlInteractive.Controls.Add(numExp)
        pnlInteractive.Controls.Add(lblMathExp)
        pnlInteractive.Controls.Add(numBase)
        pnlInteractive.Controls.Add(lblMathBase)
        pnlInteractive.Controls.Add(btnArray)
        pnlInteractive.Controls.Add(txtArray)
        pnlInteractive.Controls.Add(lblInputArray)
        pnlInteractive.Controls.Add(btnFile)
        pnlInteractive.Controls.Add(btnList)
        pnlInteractive.Controls.Add(txtInput)
        pnlInteractive.Controls.Add(lblInputText)
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
        lblOutput.Location = New Point(15, 235)
        lblOutput.Name = "lblOutput"
        lblOutput.Size = New Size(330, 125)
        lblOutput.TabIndex = 0
        lblOutput.Text = "Waiting for input..."
        ' 
        ' btnMath
        ' 
        btnMath.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnMath.ForeColor = Color.White
        btnMath.Location = New Point(240, 188)
        btnMath.Name = "btnMath"
        btnMath.Size = New Size(105, 30)
        btnMath.TabIndex = 1
        btnMath.Text = "Math.Pow()"
        btnMath.UseVisualStyleBackColor = False
        ' 
        ' numExp
        ' 
        numExp.Location = New Point(165, 190)
        numExp.Name = "numExp"
        numExp.Size = New Size(60, 27)
        numExp.TabIndex = 2
        numExp.Value = New Decimal(New Integer() {3, 0, 0, 0})
        ' 
        ' lblMathExp
        ' 
        lblMathExp.AutoSize = True
        lblMathExp.ForeColor = Color.White
        lblMathExp.Location = New Point(130, 193)
        lblMathExp.Name = "lblMathExp"
        lblMathExp.Size = New Size(36, 20)
        lblMathExp.TabIndex = 3
        lblMathExp.Text = "Exp:"
        ' 
        ' numBase
        ' 
        numBase.Location = New Point(55, 190)
        numBase.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numBase.Minimum = New Decimal(New Integer() {1000, 0, 0, Integer.MinValue})
        numBase.Name = "numBase"
        numBase.Size = New Size(60, 27)
        numBase.TabIndex = 4
        numBase.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' lblMathBase
        ' 
        lblMathBase.AutoSize = True
        lblMathBase.ForeColor = Color.White
        lblMathBase.Location = New Point(10, 193)
        lblMathBase.Name = "lblMathBase"
        lblMathBase.Size = New Size(43, 20)
        lblMathBase.TabIndex = 5
        lblMathBase.Text = "Base:"
        ' 
        ' btnArray
        ' 
        btnArray.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnArray.ForeColor = Color.White
        btnArray.Location = New Point(15, 150)
        btnArray.Name = "btnArray"
        btnArray.Size = New Size(330, 30)
        btnArray.TabIndex = 6
        btnArray.Text = "Parse Array & Sum"
        btnArray.UseVisualStyleBackColor = False
        ' 
        ' txtArray
        ' 
        txtArray.Location = New Point(135, 115)
        txtArray.Name = "txtArray"
        txtArray.Size = New Size(210, 27)
        txtArray.TabIndex = 7
        txtArray.Text = "10, 20, 30, 40"
        ' 
        ' lblInputArray
        ' 
        lblInputArray.AutoSize = True
        lblInputArray.ForeColor = Color.White
        lblInputArray.Location = New Point(10, 118)
        lblInputArray.Name = "lblInputArray"
        lblInputArray.Size = New Size(118, 20)
        lblInputArray.TabIndex = 8
        lblInputArray.Text = "Nums (10,20,30):"
        ' 
        ' btnFile
        ' 
        btnFile.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnFile.ForeColor = Color.White
        btnFile.Location = New Point(185, 75)
        btnFile.Name = "btnFile"
        btnFile.Size = New Size(160, 30)
        btnFile.TabIndex = 9
        btnFile.Text = "Save & Read File"
        btnFile.UseVisualStyleBackColor = False
        ' 
        ' btnList
        ' 
        btnList.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnList.ForeColor = Color.White
        btnList.Location = New Point(15, 75)
        btnList.Name = "btnList"
        btnList.Size = New Size(160, 30)
        btnList.TabIndex = 10
        btnList.Text = "Add to List"
        btnList.UseVisualStyleBackColor = False
        ' 
        ' txtInput
        ' 
        txtInput.Location = New Point(135, 40)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(210, 27)
        txtInput.TabIndex = 11
        ' 
        ' lblInputText
        ' 
        lblInputText.AutoSize = True
        lblInputText.ForeColor = Color.White
        lblInputText.Location = New Point(10, 43)
        lblInputText.Name = "lblInputText"
        lblInputText.Size = New Size(104, 20)
        lblInputText.TabIndex = 12
        lblInputText.Text = "Text (List/File):"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(10, 5)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(262, 28)
        lblTitle.TabIndex = 13
        lblTitle.Text = "Data Handling Interactive:"
        ' 
        ' lblLesson
        ' 
        lblLesson.BackColor = Color.Transparent
        lblLesson.Font = New Font("Segoe UI", 9.5F)
        lblLesson.ForeColor = Color.White
        lblLesson.Location = New Point(400, 75)
        lblLesson.Name = "lblLesson"
        lblLesson.Size = New Size(360, 375)
        lblLesson.TabIndex = 2
        lblLesson.Text = resources.GetString("lblLesson.Text")
        ' 
        ' Week5Form
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        ClientSize = New Size(850, 580)
        Controls.Add(lblLesson)
        Controls.Add(pnlInteractive)
        Name = "Week5Form"
        Text = "Week 5 - Data Handling & Structures"
        Controls.SetChildIndex(pnlInteractive, 0)
        Controls.SetChildIndex(lblLesson, 0)
        Controls.SetChildIndex(pnlContainer, 0)
        pnlInteractive.ResumeLayout(False)
        pnlInteractive.PerformLayout()
        CType(numExp, ComponentModel.ISupportInitialize).EndInit()
        CType(numBase, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
End Class
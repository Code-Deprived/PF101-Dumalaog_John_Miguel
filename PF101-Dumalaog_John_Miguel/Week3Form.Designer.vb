<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week3Form
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents btnVars As System.Windows.Forms.Button
    Friend WithEvents btnConsole As System.Windows.Forms.Button
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents lblLesson As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlInteractive = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.btnVars = New System.Windows.Forms.Button()
        Me.btnConsole = New System.Windows.Forms.Button()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.lblLesson = New System.Windows.Forms.Label()

        Me.pnlInteractive.SuspendLayout()
        Me.SuspendLayout()

        ' pnlInteractive
        Me.pnlInteractive.BackColor = System.Drawing.Color.Transparent
        Me.pnlInteractive.Controls.Add(Me.lblOutput)
        Me.pnlInteractive.Controls.Add(Me.btnConsole)
        Me.pnlInteractive.Controls.Add(Me.btnVars)
        Me.pnlInteractive.Controls.Add(Me.txtAge)
        Me.pnlInteractive.Controls.Add(Me.lblAge)
        Me.pnlInteractive.Controls.Add(Me.txtName)
        Me.pnlInteractive.Controls.Add(Me.lblName)
        Me.pnlInteractive.Controls.Add(Me.lblTitle)
        Me.pnlInteractive.Location = New System.Drawing.Point(30, 75)
        Me.pnlInteractive.Name = "pnlInteractive"
        Me.pnlInteractive.Size = New System.Drawing.Size(360, 375)
        Me.pnlInteractive.TabIndex = 0

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(10, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(183, 28)
        Me.lblTitle.Text = "Interactive Demo:"

        ' lblName
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(10, 48)
        Me.lblName.Name = "lblName"
        Me.lblName.Text = "String (Name):"

        ' txtName
        Me.txtName.Location = New System.Drawing.Point(135, 45)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(210, 27)
        Me.txtName.TabIndex = 1

        ' lblAge
        Me.lblAge.AutoSize = True
        Me.lblAge.ForeColor = System.Drawing.Color.White
        Me.lblAge.Location = New System.Drawing.Point(10, 88)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Text = "Integer (Age):"

        ' txtAge
        Me.txtAge.Location = New System.Drawing.Point(135, 85)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(210, 27)
        Me.txtAge.TabIndex = 2

        ' btnVars
        Me.btnVars.BackColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.btnVars.ForeColor = System.Drawing.Color.White
        Me.btnVars.Location = New System.Drawing.Point(15, 125)
        Me.btnVars.Name = "btnVars"
        Me.btnVars.Size = New System.Drawing.Size(330, 30)
        Me.btnVars.TabIndex = 3
        Me.btnVars.Text = "Test Variables & Syntax"
        Me.btnVars.UseVisualStyleBackColor = False

        ' btnConsole
        Me.btnConsole.BackColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.btnConsole.ForeColor = System.Drawing.Color.White
        Me.btnConsole.Location = New System.Drawing.Point(15, 165)
        Me.btnConsole.Name = "btnConsole"
        Me.btnConsole.Size = New System.Drawing.Size(330, 30)
        Me.btnConsole.TabIndex = 4
        Me.btnConsole.Text = "Simulate Console App"
        Me.btnConsole.UseVisualStyleBackColor = False

        ' lblOutput
        Me.lblOutput.BackColor = System.Drawing.Color.Black
        Me.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOutput.Font = New System.Drawing.Font("Consolas", 10.2!)
        Me.lblOutput.ForeColor = System.Drawing.Color.Lime
        Me.lblOutput.Location = New System.Drawing.Point(15, 210)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(330, 150)
        Me.lblOutput.TabIndex = 5
        Me.lblOutput.Text = "Output will appear here..."
        Me.lblOutput.TextAlign = System.Drawing.ContentAlignment.TopLeft

        ' lblLesson
        Me.lblLesson.BackColor = System.Drawing.Color.Transparent
        Me.lblLesson.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblLesson.ForeColor = System.Drawing.Color.White
        Me.lblLesson.Location = New System.Drawing.Point(400, 75)
        Me.lblLesson.Name = "lblLesson"
        Me.lblLesson.Size = New System.Drawing.Size(360, 375)
        Me.lblLesson.TabIndex = 6
        Me.lblLesson.Text = "Getting Started with Visual Basic .NET" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "IDE Components:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "• Solution Explorer manages files." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "• Toolbox holds interface controls." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "Console Applications:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "Run in a DOS-like command line. They are great for testing logic without a GUI." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "Syntax & Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "• VB.NET is case-insensitive." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "• Use 'Dim' to declare a variable." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "• Data Types include String (text), Integer (whole numbers), Decimal (money), and Boolean (True/False)."

        ' Week3Form
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(18, 18, 18)
        Me.ClientSize = New System.Drawing.Size(850, 580)
        Me.Controls.Add(Me.lblLesson)
        Me.Controls.Add(Me.pnlInteractive)
        Me.Name = "Week3Form"
        Me.Text = "Week 3 - Getting Started with VB.NET"

        Me.pnlInteractive.ResumeLayout(False)
        Me.pnlInteractive.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
End Class
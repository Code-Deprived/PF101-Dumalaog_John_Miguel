<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Level2Form
    Inherits System.Windows.Forms.Form

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
        pnlGrid = New Panel()
        lblTimerTitle = New Label()
        lblTimer = New Label()
        picTimerIcon = New PictureBox()
        pnlVictory = New Panel()
        btnNextLevel = New Button()
        pnlGameOver = New Panel()
        btnRestart = New Button()
        CType(picTimerIcon, ComponentModel.ISupportInitialize).BeginInit()
        pnlVictory.SuspendLayout()
        pnlGameOver.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlGrid
        ' 
        pnlGrid.BackColor = Color.Transparent
        pnlGrid.Location = New Point(280, 150)
        pnlGrid.Name = "pnlGrid"
        pnlGrid.Size = New Size(400, 400)
        pnlGrid.TabIndex = 0
        ' 
        ' lblTimerTitle
        ' 
        lblTimerTitle.AutoSize = True
        lblTimerTitle.BackColor = Color.Transparent
        lblTimerTitle.Font = New Font("Consolas", 18.0F, FontStyle.Bold)
        lblTimerTitle.ForeColor = Color.White
        lblTimerTitle.Location = New Point(420, 50)
        lblTimerTitle.Name = "lblTimerTitle"
        lblTimerTitle.Size = New Size(111, 36)
        lblTimerTitle.TabIndex = 1
        lblTimerTitle.Text = "Time: "
        ' 
        ' lblTimer
        ' 
        lblTimer.AutoSize = True
        lblTimer.BackColor = Color.Transparent
        lblTimer.Font = New Font("Consolas", 18.0F, FontStyle.Bold)
        lblTimer.ForeColor = Color.White
        lblTimer.Location = New Point(510, 50)
        lblTimer.Name = "lblTimer"
        lblTimer.Size = New Size(47, 36)
        lblTimer.TabIndex = 2
        lblTimer.Text = "45"
        ' 
        ' picTimerIcon
        ' 
        picTimerIcon.BackColor = Color.Transparent
        picTimerIcon.Location = New Point(370, 40)
        picTimerIcon.Name = "picTimerIcon"
        picTimerIcon.Size = New Size(50, 55)
        picTimerIcon.SizeMode = PictureBoxSizeMode.Zoom
        picTimerIcon.TabIndex = 3
        picTimerIcon.TabStop = False
        ' 
        ' pnlVictory
        ' 
        pnlVictory.BackColor = Color.FromArgb(CByte(20), CByte(60), CByte(20))
        pnlVictory.BackgroundImageLayout = ImageLayout.Zoom
        pnlVictory.Controls.Add(btnNextLevel)
        pnlVictory.Location = New Point(326, 207)
        pnlVictory.Name = "pnlVictory"
        pnlVictory.Size = New Size(300, 200)
        pnlVictory.TabIndex = 4
        pnlVictory.Visible = False
        ' 
        ' btnNextLevel
        ' 
        btnNextLevel.BackColor = Color.Transparent
        btnNextLevel.Cursor = Cursors.Hand
        btnNextLevel.FlatStyle = FlatStyle.Flat
        btnNextLevel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnNextLevel.ForeColor = Color.DarkViolet
        btnNextLevel.Location = New Point(75, 90)
        btnNextLevel.Name = "btnNextLevel"
        btnNextLevel.Size = New Size(150, 40)
        btnNextLevel.TabIndex = 0
        btnNextLevel.Text = "Face the Boss"
        btnNextLevel.UseVisualStyleBackColor = False
        ' 
        ' pnlGameOver
        ' 
        pnlGameOver.BackColor = Color.FromArgb(CByte(60), CByte(20), CByte(20))
        pnlGameOver.BackgroundImageLayout = ImageLayout.Zoom
        pnlGameOver.Controls.Add(btnRestart)
        pnlGameOver.Location = New Point(326, 207)
        pnlGameOver.Name = "pnlGameOver"
        pnlGameOver.Size = New Size(300, 200)
        pnlGameOver.TabIndex = 5
        pnlGameOver.Visible = False
        ' 
        ' btnRestart
        ' 
        btnRestart.BackColor = Color.Maroon
        btnRestart.Cursor = Cursors.Hand
        btnRestart.FlatStyle = FlatStyle.Flat
        btnRestart.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRestart.ForeColor = Color.White
        btnRestart.Location = New Point(75, 140)
        btnRestart.Name = "btnRestart"
        btnRestart.Size = New Size(150, 40)
        btnRestart.TabIndex = 0
        btnRestart.Text = "Try Again"
        btnRestart.UseVisualStyleBackColor = False
        ' 
        ' Level2Form
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        ClientSize = New Size(953, 615)
        Controls.Add(pnlVictory)
        Controls.Add(pnlGameOver)
        Controls.Add(picTimerIcon)
        Controls.Add(lblTimer)
        Controls.Add(lblTimerTitle)
        Controls.Add(pnlGrid)
        Name = "Level2Form"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Level 2 - The Arcane Vault"
        CType(picTimerIcon, ComponentModel.ISupportInitialize).EndInit()
        pnlVictory.ResumeLayout(False)
        pnlGameOver.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlGrid As Panel
    Friend WithEvents lblTimerTitle As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents picTimerIcon As PictureBox
    Friend WithEvents pnlVictory As Panel
    Friend WithEvents btnNextLevel As Button
    Friend WithEvents pnlGameOver As Panel
    Friend WithEvents btnRestart As Button
End Class
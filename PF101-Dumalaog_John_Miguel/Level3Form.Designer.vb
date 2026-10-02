<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Level3Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'UI Controls
    Friend WithEvents picBoss As System.Windows.Forms.PictureBox
    Friend WithEvents picPriest As System.Windows.Forms.PictureBox
    Friend WithEvents pbBossHP As System.Windows.Forms.ProgressBar
    Friend WithEvents pbPlayerHP As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblBossHP As System.Windows.Forms.Label
    Friend WithEvents lblPlayerHP As System.Windows.Forms.Label
    Friend WithEvents tmrBoss As System.Windows.Forms.Timer

    Friend WithEvents picAttack1 As System.Windows.Forms.PictureBox
    Friend WithEvents picAttack2 As System.Windows.Forms.PictureBox
    Friend WithEvents picAttack3 As System.Windows.Forms.PictureBox
    Friend WithEvents picItem1 As System.Windows.Forms.PictureBox
    Friend WithEvents picItem2 As System.Windows.Forms.PictureBox
    Friend WithEvents picItem3 As System.Windows.Forms.PictureBox

    Friend WithEvents pnlVictory As System.Windows.Forms.Panel
    Friend WithEvents btnNextLevel As System.Windows.Forms.Button
    Friend WithEvents pnlGameOver As System.Windows.Forms.Panel
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents toolTip As System.Windows.Forms.ToolTip

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        picBoss = New PictureBox()
        picPriest = New PictureBox()
        pbBossHP = New ProgressBar()
        pbPlayerHP = New ProgressBar()
        lblStatus = New Label()
        lblBossHP = New Label()
        lblPlayerHP = New Label()
        tmrBoss = New Timer(components)
        picAttack1 = New PictureBox()
        picAttack2 = New PictureBox()
        picAttack3 = New PictureBox()
        picItem1 = New PictureBox()
        picItem2 = New PictureBox()
        picItem3 = New PictureBox()
        pnlVictory = New Panel()
        btnNextLevel = New Button()
        pnlGameOver = New Panel()
        btnRestart = New Button()
        toolTip = New ToolTip(components)
        CType(picBoss, ComponentModel.ISupportInitialize).BeginInit()
        CType(picPriest, ComponentModel.ISupportInitialize).BeginInit()
        CType(picAttack1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picAttack2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picAttack3, ComponentModel.ISupportInitialize).BeginInit()
        CType(picItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picItem3, ComponentModel.ISupportInitialize).BeginInit()
        pnlVictory.SuspendLayout()
        pnlGameOver.SuspendLayout()
        SuspendLayout()
        ' 
        ' picBoss
        ' 
        picBoss.BackColor = Color.Transparent
        picBoss.Location = New Point(600, 100)
        picBoss.Name = "picBoss"
        picBoss.Size = New Size(250, 250)
        picBoss.SizeMode = PictureBoxSizeMode.Zoom
        picBoss.TabIndex = 3
        picBoss.TabStop = False
        ' 
        ' picPriest
        ' 
        picPriest.BackColor = Color.Transparent
        picPriest.Location = New Point(100, 230)
        picPriest.Name = "picPriest"
        picPriest.Size = New Size(180, 180)
        picPriest.SizeMode = PictureBoxSizeMode.Zoom
        picPriest.TabIndex = 6
        picPriest.TabStop = False
        ' 
        ' pbBossHP
        ' 
        pbBossHP.Location = New Point(600, 75)
        pbBossHP.Maximum = 300
        pbBossHP.Name = "pbBossHP"
        pbBossHP.Size = New Size(250, 20)
        pbBossHP.TabIndex = 4
        pbBossHP.Value = 300
        ' 
        ' pbPlayerHP
        ' 
        pbPlayerHP.Location = New Point(100, 420)
        pbPlayerHP.Name = "pbPlayerHP"
        pbPlayerHP.Size = New Size(180, 20)
        pbPlayerHP.TabIndex = 7
        pbPlayerHP.Value = 100
        ' 
        ' lblStatus
        ' 
        lblStatus.BackColor = Color.FromArgb(CByte(180), CByte(0), CByte(0), CByte(0))
        lblStatus.Font = New Font("Consolas", 14.0F, FontStyle.Bold)
        lblStatus.ForeColor = Color.White
        lblStatus.Location = New Point(953, 20)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(600, 45)
        lblStatus.TabIndex = 2
        lblStatus.Text = "The Final Boss appears! Your turn."
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblBossHP
        ' 
        lblBossHP.BackColor = Color.Transparent
        lblBossHP.Font = New Font("Consolas", 12.0F, FontStyle.Bold)
        lblBossHP.ForeColor = Color.Red
        lblBossHP.Location = New Point(600, 55)
        lblBossHP.Name = "lblBossHP"
        lblBossHP.Size = New Size(250, 20)
        lblBossHP.TabIndex = 5
        lblBossHP.Text = "Boss HP: 300/300"
        lblBossHP.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPlayerHP
        ' 
        lblPlayerHP.BackColor = Color.Transparent
        lblPlayerHP.Font = New Font("Consolas", 12.0F, FontStyle.Bold)
        lblPlayerHP.ForeColor = Color.Lime
        lblPlayerHP.Location = New Point(100, 445)
        lblPlayerHP.Name = "lblPlayerHP"
        lblPlayerHP.Size = New Size(180, 20)
        lblPlayerHP.TabIndex = 8
        lblPlayerHP.Text = "Priest HP: 100/100"
        lblPlayerHP.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' tmrBoss
        ' 
        tmrBoss.Interval = 1500
        ' 
        ' picAttack1
        ' 
        picAttack1.BackColor = Color.Transparent
        picAttack1.BorderStyle = BorderStyle.FixedSingle
        picAttack1.Cursor = Cursors.Hand
        picAttack1.Location = New Point(350, 480)
        picAttack1.Name = "picAttack1"
        picAttack1.Size = New Size(70, 70)
        picAttack1.SizeMode = PictureBoxSizeMode.Zoom
        picAttack1.TabIndex = 9
        picAttack1.TabStop = False
        toolTip.SetToolTip(picAttack1, "Light Attack: 15 Dmg (100% Hit)")
        ' 
        ' picAttack2
        ' 
        picAttack2.BackColor = Color.Transparent
        picAttack2.BorderStyle = BorderStyle.FixedSingle
        picAttack2.Cursor = Cursors.Hand
        picAttack2.Location = New Point(440, 480)
        picAttack2.Name = "picAttack2"
        picAttack2.Size = New Size(70, 70)
        picAttack2.SizeMode = PictureBoxSizeMode.Zoom
        picAttack2.TabIndex = 10
        picAttack2.TabStop = False
        toolTip.SetToolTip(picAttack2, "Heavy Attack: 30 Dmg (70% Hit)")
        ' 
        ' picAttack3
        ' 
        picAttack3.BackColor = Color.Transparent
        picAttack3.BorderStyle = BorderStyle.FixedSingle
        picAttack3.Cursor = Cursors.Hand
        picAttack3.Location = New Point(530, 480)
        picAttack3.Name = "picAttack3"
        picAttack3.Size = New Size(70, 70)
        picAttack3.SizeMode = PictureBoxSizeMode.Zoom
        picAttack3.TabIndex = 11
        picAttack3.TabStop = False
        toolTip.SetToolTip(picAttack3, "Ultimate Attack: 60 Dmg (40% Hit)")
        ' 
        ' picItem1
        ' 
        picItem1.BackColor = Color.Transparent
        picItem1.BorderStyle = BorderStyle.FixedSingle
        picItem1.Cursor = Cursors.Hand
        picItem1.Location = New Point(650, 480)
        picItem1.Name = "picItem1"
        picItem1.Size = New Size(70, 70)
        picItem1.SizeMode = PictureBoxSizeMode.Zoom
        picItem1.TabIndex = 12
        picItem1.TabStop = False
        toolTip.SetToolTip(picItem1, "Attack Buff: Next attack is a guaranteed Critical (+100% Dmg)")
        ' 
        ' picItem2
        ' 
        picItem2.BackColor = Color.Transparent
        picItem2.BorderStyle = BorderStyle.FixedSingle
        picItem2.Cursor = Cursors.Hand
        picItem2.Location = New Point(740, 480)
        picItem2.Name = "picItem2"
        picItem2.Size = New Size(70, 70)
        picItem2.SizeMode = PictureBoxSizeMode.Zoom
        picItem2.TabIndex = 13
        picItem2.TabStop = False
        toolTip.SetToolTip(picItem2, "Heal: Restores 40 HP")
        ' 
        ' picItem3
        ' 
        picItem3.BackColor = Color.Transparent
        picItem3.BorderStyle = BorderStyle.FixedSingle
        picItem3.Cursor = Cursors.Hand
        picItem3.Location = New Point(830, 480)
        picItem3.Name = "picItem3"
        picItem3.Size = New Size(70, 70)
        picItem3.SizeMode = PictureBoxSizeMode.Zoom
        picItem3.TabIndex = 14
        picItem3.TabStop = False
        toolTip.SetToolTip(picItem3, "Shield: Block next Boss attack")
        ' 
        ' pnlVictory
        ' 
        pnlVictory.BackColor = Color.FromArgb(CByte(20), CByte(60), CByte(20))
        pnlVictory.Controls.Add(btnNextLevel)
        pnlVictory.Location = New Point(326, 207)
        pnlVictory.Name = "pnlVictory"
        pnlVictory.Size = New Size(300, 200)
        pnlVictory.TabIndex = 0
        pnlVictory.Visible = False
        ' 
        ' btnNextLevel
        ' 
        btnNextLevel.BackColor = Color.Transparent
        btnNextLevel.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnNextLevel.ForeColor = Color.DarkViolet
        btnNextLevel.Location = New Point(75, 59)
        btnNextLevel.Name = "btnNextLevel"
        btnNextLevel.Size = New Size(150, 40)
        btnNextLevel.TabIndex = 0
        btnNextLevel.Text = "Return to Hub"
        btnNextLevel.UseVisualStyleBackColor = False
        ' 
        ' pnlGameOver
        ' 
        pnlGameOver.BackColor = Color.FromArgb(CByte(60), CByte(20), CByte(20))
        pnlGameOver.Controls.Add(btnRestart)
        pnlGameOver.Location = New Point(326, 207)
        pnlGameOver.Name = "pnlGameOver"
        pnlGameOver.Size = New Size(300, 200)
        pnlGameOver.TabIndex = 1
        pnlGameOver.Visible = False
        ' 
        ' btnRestart
        ' 
        btnRestart.BackColor = Color.Maroon
        btnRestart.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRestart.ForeColor = Color.White
        btnRestart.Location = New Point(75, 140)
        btnRestart.Name = "btnRestart"
        btnRestart.Size = New Size(150, 40)
        btnRestart.TabIndex = 0
        btnRestart.Text = "Try Again"
        btnRestart.UseVisualStyleBackColor = False
        ' 
        ' Level3Form
        ' 
        BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        ClientSize = New Size(953, 615)
        Controls.Add(pnlVictory)
        Controls.Add(pnlGameOver)
        Controls.Add(lblStatus)
        Controls.Add(picBoss)
        Controls.Add(pbBossHP)
        Controls.Add(lblBossHP)
        Controls.Add(picPriest)
        Controls.Add(pbPlayerHP)
        Controls.Add(lblPlayerHP)
        Controls.Add(picAttack1)
        Controls.Add(picAttack2)
        Controls.Add(picAttack3)
        Controls.Add(picItem1)
        Controls.Add(picItem2)
        Controls.Add(picItem3)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Level3Form"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Level 3 - The Final Boss"
        CType(picBoss, ComponentModel.ISupportInitialize).EndInit()
        CType(picPriest, ComponentModel.ISupportInitialize).EndInit()
        CType(picAttack1, ComponentModel.ISupportInitialize).EndInit()
        CType(picAttack2, ComponentModel.ISupportInitialize).EndInit()
        CType(picAttack3, ComponentModel.ISupportInitialize).EndInit()
        CType(picItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(picItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(picItem3, ComponentModel.ISupportInitialize).EndInit()
        pnlVictory.ResumeLayout(False)
        pnlGameOver.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class
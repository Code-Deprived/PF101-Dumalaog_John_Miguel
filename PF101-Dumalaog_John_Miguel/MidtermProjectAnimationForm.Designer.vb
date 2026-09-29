<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MidtermProjectAnimationForm
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
        components = New ComponentModel.Container()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        lblGame1Status = New Label()
        btnMoveBoat = New Button()
        btnReset1 = New Button()
        flpRightShore = New FlowLayoutPanel()
        pnlRiver = New Panel()
        flpBoat = New FlowLayoutPanel()
        flpLeftShore = New FlowLayoutPanel()
        tmrBoat = New Timer(components)
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        pnlRiver.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Margin = New Padding(3, 4, 3, 4)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(953, 615)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.FromArgb(CByte(20), CByte(40), CByte(60))
        TabPage1.Controls.Add(lblGame1Status)
        TabPage1.Controls.Add(btnMoveBoat)
        TabPage1.Controls.Add(btnReset1)
        TabPage1.Controls.Add(flpRightShore)
        TabPage1.Controls.Add(pnlRiver)
        TabPage1.Controls.Add(flpLeftShore)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Margin = New Padding(3, 4, 3, 4)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3, 4, 3, 4)
        TabPage1.Size = New Size(945, 582)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Level 1 (Priests n Devils)"
        ' 
        ' lblGame1Status
        ' 
        lblGame1Status.AutoSize = True
        lblGame1Status.Font = New Font("Consolas", 15.75F, FontStyle.Bold)
        lblGame1Status.ForeColor = Color.White
        lblGame1Status.Location = New Point(709, 27)
        lblGame1Status.Name = "lblGame1Status"
        lblGame1Status.Size = New Size(209, 32)
        lblGame1Status.TabIndex = 5
        lblGame1Status.Text = "Time Left  60"
        ' 
        ' btnMoveBoat
        ' 
        btnMoveBoat.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnMoveBoat.Cursor = Cursors.Hand
        btnMoveBoat.FlatStyle = FlatStyle.Flat
        btnMoveBoat.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnMoveBoat.ForeColor = Color.White
        btnMoveBoat.Location = New Point(429, 27)
        btnMoveBoat.Margin = New Padding(3, 4, 3, 4)
        btnMoveBoat.Name = "btnMoveBoat"
        btnMoveBoat.Size = New Size(80, 93)
        btnMoveBoat.TabIndex = 4
        btnMoveBoat.Text = "GO"
        btnMoveBoat.UseVisualStyleBackColor = False
        ' 
        ' btnReset1
        ' 
        btnReset1.BackColor = Color.Maroon
        btnReset1.Cursor = Cursors.Hand
        btnReset1.FlatStyle = FlatStyle.Flat
        btnReset1.ForeColor = Color.White
        btnReset1.Location = New Point(23, 27)
        btnReset1.Margin = New Padding(3, 4, 3, 4)
        btnReset1.Name = "btnReset1"
        btnReset1.Size = New Size(114, 53)
        btnReset1.TabIndex = 3
        btnReset1.Text = "Reset Game"
        btnReset1.UseVisualStyleBackColor = False
        ' 
        ' flpRightShore
        ' 
        flpRightShore.BackColor = Color.Green
        flpRightShore.Location = New Point(624, 287)
        flpRightShore.Margin = New Padding(3, 4, 3, 4)
        flpRightShore.Name = "flpRightShore"
        flpRightShore.Padding = New Padding(0, 13, 0, 0)
        flpRightShore.Size = New Size(320, 246)
        flpRightShore.TabIndex = 2
        flpRightShore.WrapContents = False
        ' 
        ' pnlRiver
        ' 
        pnlRiver.BackColor = Color.SteelBlue
        pnlRiver.Controls.Add(flpBoat)
        pnlRiver.Location = New Point(320, 373)
        pnlRiver.Margin = New Padding(3, 4, 3, 4)
        pnlRiver.Name = "pnlRiver"
        pnlRiver.Size = New Size(304, 160)
        pnlRiver.TabIndex = 1
        ' 
        ' flpBoat
        ' 
        flpBoat.BackColor = Color.SaddleBrown
        flpBoat.Location = New Point(167, 27)
        flpBoat.Margin = New Padding(3, 4, 3, 4)
        flpBoat.Name = "flpBoat"
        flpBoat.Padding = New Padding(2, 7, 2, 0)
        flpBoat.Size = New Size(140, 95)
        flpBoat.TabIndex = 0
        flpBoat.WrapContents = False
        ' 
        ' flpLeftShore
        ' 
        flpLeftShore.BackColor = Color.Green
        flpLeftShore.Location = New Point(0, 287)
        flpLeftShore.Margin = New Padding(3, 4, 3, 4)
        flpLeftShore.Name = "flpLeftShore"
        flpLeftShore.Padding = New Padding(0, 13, 0, 0)
        flpLeftShore.Size = New Size(320, 246)
        flpLeftShore.TabIndex = 0
        flpLeftShore.WrapContents = False
        ' 
        ' tmrBoat
        ' 
        tmrBoat.Interval = 20
        ' 
        ' MidtermProjectAnimationForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(953, 615)
        Controls.Add(TabControl1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "MidtermProjectAnimationForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Midterm Project - Animations"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        pnlRiver.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents flpLeftShore As FlowLayoutPanel
    Friend WithEvents pnlRiver As Panel
    Friend WithEvents flpRightShore As FlowLayoutPanel
    Friend WithEvents flpBoat As FlowLayoutPanel
    Friend WithEvents btnMoveBoat As Button
    Friend WithEvents btnReset1 As Button
    Friend WithEvents lblGame1Status As Label
    Friend WithEvents tmrBoat As Timer
End Class
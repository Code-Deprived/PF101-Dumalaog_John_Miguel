<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Landing_page
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Landing_page))
        pnlMainMenu = New Panel()
        lblLessons = New Label()
        lblSBIT1A = New Label()
        lblHelp = New Label()
        lblExit = New Label()
        PictureBox1 = New PictureBox()
        pnlLessonSelect = New Panel()
        btnBack = New Label()
        pnlListContainer = New Panel()
        lblWeek6 = New Label()
        lblWeek5 = New Label()
        lblWeek4 = New Label()
        lblWeek3 = New Label()
        lblWeek2 = New Label()
        lblSelectHeader = New Label()
        picBG = New PictureBox()
        pnlMainMenu.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlLessonSelect.SuspendLayout()
        pnlListContainer.SuspendLayout()
        CType(picBG, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' pnlMainMenu
        '
        pnlMainMenu.BackColor = Color.Transparent
        pnlMainMenu.Controls.Add(lblLessons)
        pnlMainMenu.Controls.Add(lblSBIT1A)
        pnlMainMenu.Controls.Add(lblHelp)
        pnlMainMenu.Controls.Add(lblExit)
        pnlMainMenu.Controls.Add(PictureBox1)
        pnlMainMenu.Dock = DockStyle.Fill
        pnlMainMenu.Location = New Point(0, 0)
        pnlMainMenu.Name = "pnlMainMenu"
        pnlMainMenu.Size = New Size(982, 691)
        pnlMainMenu.TabIndex = 0
        '
        ' PictureBox1
        '
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(132, 30)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(718, 132)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        '
        ' lblLessons
        '
        lblLessons.Cursor = Cursors.Hand
        lblLessons.Font = New Font("Microsoft Sans Serif", 24.0F, FontStyle.Bold)
        lblLessons.ForeColor = Color.White
        lblLessons.Location = New Point(371, 195)
        lblLessons.Name = "lblLessons"
        lblLessons.Size = New Size(240, 50)
        lblLessons.TabIndex = 1
        '
        ' lblSBIT1A
        '
        lblSBIT1A.Cursor = Cursors.Hand
        lblSBIT1A.Font = New Font("Microsoft Sans Serif", 24.0F, FontStyle.Bold)
        lblSBIT1A.ForeColor = Color.White
        lblSBIT1A.Location = New Point(371, 260)
        lblSBIT1A.Name = "lblSBIT1A"
        lblSBIT1A.Size = New Size(240, 50)
        lblSBIT1A.TabIndex = 2
        '
        ' lblHelp
        '
        lblHelp.Cursor = Cursors.Hand
        lblHelp.Font = New Font("Microsoft Sans Serif", 24.0F, FontStyle.Bold)
        lblHelp.ForeColor = Color.White
        lblHelp.Location = New Point(371, 325)
        lblHelp.Name = "lblHelp"
        lblHelp.Size = New Size(240, 50)
        lblHelp.TabIndex = 3
        '
        ' lblExit
        '
        lblExit.Cursor = Cursors.Hand
        lblExit.Font = New Font("Microsoft Sans Serif", 24.0F, FontStyle.Bold)
        lblExit.ForeColor = Color.White
        lblExit.Location = New Point(371, 390)
        lblExit.Name = "lblExit"
        lblExit.Size = New Size(240, 50)
        lblExit.TabIndex = 4
        '
        ' pnlLessonSelect
        '
        pnlLessonSelect.BackColor = Color.Transparent
        pnlLessonSelect.Controls.Add(btnBack)
        pnlLessonSelect.Controls.Add(pnlListContainer)
        pnlLessonSelect.Controls.Add(lblSelectHeader)
        pnlLessonSelect.Dock = DockStyle.Fill
        pnlLessonSelect.Location = New Point(0, 0)
        pnlLessonSelect.Name = "pnlLessonSelect"
        pnlLessonSelect.Size = New Size(982, 691)
        pnlLessonSelect.TabIndex = 1
        pnlLessonSelect.Visible = False
        '
        ' lblSelectHeader
        '
        lblSelectHeader.Font = New Font("Microsoft Sans Serif", 20.0F, FontStyle.Bold)
        lblSelectHeader.ForeColor = Color.White
        lblSelectHeader.Location = New Point(351, 20)
        lblSelectHeader.Name = "lblSelectHeader"
        lblSelectHeader.Size = New Size(280, 48)
        lblSelectHeader.TabIndex = 0
        '
        ' pnlListContainer
        '
        pnlListContainer.BackColor = Color.Transparent
        pnlListContainer.Controls.Add(lblWeek6)
        pnlListContainer.Controls.Add(lblWeek5)
        pnlListContainer.Controls.Add(lblWeek4)
        pnlListContainer.Controls.Add(lblWeek3)
        pnlListContainer.Controls.Add(lblWeek2)
        pnlListContainer.Location = New Point(181, 78)
        pnlListContainer.Name = "pnlListContainer"
        pnlListContainer.Padding = New Padding(20)
        pnlListContainer.Size = New Size(620, 405)
        pnlListContainer.TabIndex = 1
        '
        ' lblWeek2
        '
        lblWeek2.Cursor = Cursors.Hand
        lblWeek2.Location = New Point(23, 12)
        lblWeek2.Name = "lblWeek2"
        lblWeek2.Size = New Size(574, 68)
        lblWeek2.TabIndex = 0
        '
        ' lblWeek3
        '
        lblWeek3.Cursor = Cursors.Hand
        lblWeek3.Location = New Point(23, 88)
        lblWeek3.Name = "lblWeek3"
        lblWeek3.Size = New Size(574, 68)
        lblWeek3.TabIndex = 1
        '
        ' lblWeek4
        '
        lblWeek4.Cursor = Cursors.Hand
        lblWeek4.Location = New Point(23, 164)
        lblWeek4.Name = "lblWeek4"
        lblWeek4.Size = New Size(574, 68)
        lblWeek4.TabIndex = 2
        '
        ' lblWeek5
        '
        lblWeek5.Cursor = Cursors.Hand
        lblWeek5.Location = New Point(23, 240)
        lblWeek5.Name = "lblWeek5"
        lblWeek5.Size = New Size(574, 68)
        lblWeek5.TabIndex = 3
        '
        ' lblWeek6
        '
        lblWeek6.Cursor = Cursors.Hand
        lblWeek6.Location = New Point(23, 316)
        lblWeek6.Name = "lblWeek6"
        lblWeek6.Size = New Size(574, 68)
        lblWeek6.TabIndex = 4
        '
        ' btnBack
        '
        btnBack.Cursor = Cursors.Hand
        btnBack.Font = New Font("Microsoft Sans Serif", 18.0F, FontStyle.Bold)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(411, 500)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(160, 45)
        btnBack.TabIndex = 2
        '
        ' picBG
        '
        picBG.Dock = DockStyle.Fill
        picBG.Location = New Point(0, 0)
        picBG.Name = "picBG"
        picBG.Size = New Size(982, 691)
        picBG.SizeMode = PictureBoxSizeMode.StretchImage
        picBG.TabIndex = 2
        picBG.TabStop = False
        '
        ' Landing_page
        '
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(982, 691)
        Controls.Add(pnlMainMenu)
        Controls.Add(pnlLessonSelect)
        Controls.Add(picBG)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "Landing_page"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Terraria Reviewer Hub"
        pnlMainMenu.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlLessonSelect.ResumeLayout(False)
        pnlListContainer.ResumeLayout(False)
        CType(picBG, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMainMenu As Panel
    Friend WithEvents lblLessons As Label
    Friend WithEvents lblSBIT1A As Label
    Friend WithEvents lblHelp As Label
    Friend WithEvents lblExit As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlLessonSelect As Panel
    Friend WithEvents btnBack As Label
    Friend WithEvents pnlListContainer As Panel
    Friend WithEvents lblWeek6 As Label
    Friend WithEvents lblWeek5 As Label
    Friend WithEvents lblWeek4 As Label
    Friend WithEvents lblWeek3 As Label
    Friend WithEvents lblWeek2 As Label
    Friend WithEvents lblSelectHeader As Label
    Friend WithEvents picBG As PictureBox
End Class
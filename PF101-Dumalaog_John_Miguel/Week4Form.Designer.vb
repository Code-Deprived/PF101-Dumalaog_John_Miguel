<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week4Form
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

    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents lblDemo As System.Windows.Forms.Label
    Friend WithEvents txtDemo As System.Windows.Forms.TextBox
    Friend WithEvents btnTestEvent As System.Windows.Forms.Button
    Friend WithEvents btnChangeProp As System.Windows.Forms.Button
    Friend WithEvents btnResizePanel As System.Windows.Forms.Button
    Friend WithEvents btnAnchored As System.Windows.Forms.Button
    Friend WithEvents pnlDockBottom As System.Windows.Forms.Panel
    Friend WithEvents lblDockStatus As System.Windows.Forms.Label
    Friend WithEvents lblLesson As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Week4Form))
        pnlLeft = New Panel()
        btnAnchored = New Button()
        btnResizePanel = New Button()
        btnChangeProp = New Button()
        btnTestEvent = New Button()
        txtDemo = New TextBox()
        lblDemo = New Label()
        pnlDockBottom = New Panel()
        lblDockStatus = New Label()
        lblLesson = New Label()
        pnlLeft.SuspendLayout()
        pnlDockBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.Transparent
        pnlLeft.BorderStyle = BorderStyle.FixedSingle
        pnlLeft.Controls.Add(btnAnchored)
        pnlLeft.Controls.Add(btnResizePanel)
        pnlLeft.Controls.Add(btnChangeProp)
        pnlLeft.Controls.Add(btnTestEvent)
        pnlLeft.Controls.Add(txtDemo)
        pnlLeft.Controls.Add(lblDemo)
        pnlLeft.Controls.Add(pnlDockBottom)
        pnlLeft.Location = New Point(30, 75)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(320, 375)
        pnlLeft.TabIndex = 0
        ' 
        ' btnAnchored
        ' 
        btnAnchored.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnAnchored.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btnAnchored.ForeColor = Color.White
        btnAnchored.Location = New Point(185, 285)
        btnAnchored.Name = "btnAnchored"
        btnAnchored.Size = New Size(115, 35)
        btnAnchored.TabIndex = 0
        btnAnchored.Text = "Anchored B-R"
        btnAnchored.UseVisualStyleBackColor = False
        ' 
        ' btnResizePanel
        ' 
        btnResizePanel.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnResizePanel.ForeColor = Color.White
        btnResizePanel.Location = New Point(15, 180)
        btnResizePanel.Name = "btnResizePanel"
        btnResizePanel.Size = New Size(285, 35)
        btnResizePanel.TabIndex = 1
        btnResizePanel.Text = "↔ Resize Panel (Demo Anchor/Dock)"
        btnResizePanel.UseVisualStyleBackColor = False
        ' 
        ' btnChangeProp
        ' 
        btnChangeProp.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnChangeProp.ForeColor = Color.White
        btnChangeProp.Location = New Point(15, 135)
        btnChangeProp.Name = "btnChangeProp"
        btnChangeProp.Size = New Size(285, 35)
        btnChangeProp.TabIndex = 2
        btnChangeProp.Text = "Toggle TextBox Property"
        btnChangeProp.UseVisualStyleBackColor = False
        ' 
        ' btnTestEvent
        ' 
        btnTestEvent.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnTestEvent.ForeColor = Color.White
        btnTestEvent.Location = New Point(15, 90)
        btnTestEvent.Name = "btnTestEvent"
        btnTestEvent.Size = New Size(285, 35)
        btnTestEvent.TabIndex = 3
        btnTestEvent.Text = "Test Method & Event"
        btnTestEvent.UseVisualStyleBackColor = False
        ' 
        ' txtDemo
        ' 
        txtDemo.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        txtDemo.ForeColor = Color.White
        txtDemo.Location = New Point(15, 50)
        txtDemo.Name = "txtDemo"
        txtDemo.Size = New Size(285, 27)
        txtDemo.TabIndex = 4
        txtDemo.Text = "Watch my properties change!"
        txtDemo.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblDemo
        ' 
        lblDemo.AutoSize = True
        lblDemo.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblDemo.ForeColor = Color.White
        lblDemo.Location = New Point(10, 10)
        lblDemo.Name = "lblDemo"
        lblDemo.Size = New Size(238, 28)
        lblDemo.TabIndex = 5
        lblDemo.Text = "Control Property Demo:"
        ' 
        ' pnlDockBottom
        ' 
        pnlDockBottom.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        pnlDockBottom.Controls.Add(lblDockStatus)
        pnlDockBottom.Dock = DockStyle.Bottom
        pnlDockBottom.Location = New Point(0, 335)
        pnlDockBottom.Name = "pnlDockBottom"
        pnlDockBottom.Size = New Size(318, 38)
        pnlDockBottom.TabIndex = 6
        ' 
        ' lblDockStatus
        ' 
        lblDockStatus.AutoSize = True
        lblDockStatus.ForeColor = Color.LightGray
        lblDockStatus.Location = New Point(10, 9)
        lblDockStatus.Name = "lblDockStatus"
        lblDockStatus.Size = New Size(178, 20)
        lblDockStatus.TabIndex = 0
        lblDockStatus.Text = "DOCKED to Bottom Edge"
        ' 
        ' lblLesson
        ' 
        lblLesson.BackColor = Color.Transparent
        lblLesson.Font = New Font("Segoe UI", 9.5F)
        lblLesson.ForeColor = Color.White
        lblLesson.Location = New Point(370, 75)
        lblLesson.Name = "lblLesson"
        lblLesson.Size = New Size(390, 375)
        lblLesson.TabIndex = 2
        lblLesson.Text = resources.GetString("lblLesson.Text")
        ' 
        ' Week4Form
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        ClientSize = New Size(850, 580)
        Controls.Add(lblLesson)
        Controls.Add(pnlLeft)
        Name = "Week4Form"
        Text = "Week 4 - Planning Applications and Designing Interfaces"
        Controls.SetChildIndex(pnlLeft, 0)
        Controls.SetChildIndex(lblLesson, 0)
        Controls.SetChildIndex(pnlContainer, 0)
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlDockBottom.ResumeLayout(False)
        pnlDockBottom.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week7Form
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
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnShow2D As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents lblLesson As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Week7Form))
        pnlInteractive = New Panel()
        lstOutput = New ListBox()
        btnShow2D = New Button()
        btnSearch = New Button()
        btnRemove = New Button()
        btnAdd = New Button()
        txtInput = New TextBox()
        lblTitle = New Label()
        lblLesson = New Label()
        pnlInteractive.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlInteractive
        ' 
        pnlInteractive.BackColor = Color.Transparent
        pnlInteractive.Controls.Add(lstOutput)
        pnlInteractive.Controls.Add(btnShow2D)
        pnlInteractive.Controls.Add(btnSearch)
        pnlInteractive.Controls.Add(btnRemove)
        pnlInteractive.Controls.Add(btnAdd)
        pnlInteractive.Controls.Add(txtInput)
        pnlInteractive.Controls.Add(lblTitle)
        pnlInteractive.Location = New Point(30, 75)
        pnlInteractive.Name = "pnlInteractive"
        pnlInteractive.Size = New Size(360, 420)
        pnlInteractive.TabIndex = 0
        ' 
        ' lstOutput
        ' 
        lstOutput.BackColor = Color.Black
        lstOutput.BorderStyle = BorderStyle.FixedSingle
        lstOutput.Font = New Font("Consolas", 10.2F)
        lstOutput.ForeColor = Color.Lime
        lstOutput.FormattingEnabled = True
        lstOutput.Location = New Point(15, 125)
        lstOutput.Name = "lstOutput"
        lstOutput.Size = New Size(330, 182)
        lstOutput.TabIndex = 6
        ' 
        ' btnShow2D
        ' 
        btnShow2D.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnShow2D.FlatStyle = FlatStyle.Flat
        btnShow2D.ForeColor = Color.White
        btnShow2D.Location = New Point(175, 80)
        btnShow2D.Name = "btnShow2D"
        btnShow2D.Size = New Size(170, 32)
        btnShow2D.TabIndex = 5
        btnShow2D.Text = "View 2D Array (Chest)"
        btnShow2D.UseVisualStyleBackColor = False
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(15, 80)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(155, 32)
        btnSearch.TabIndex = 4
        btnSearch.Text = "Search Item"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnRemove
        ' 
        btnRemove.BackColor = Color.IndianRed
        btnRemove.FlatAppearance.BorderSize = 0
        btnRemove.FlatStyle = FlatStyle.Flat
        btnRemove.ForeColor = Color.White
        btnRemove.Location = New Point(285, 40)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(60, 30)
        btnRemove.TabIndex = 3
        btnRemove.Text = "Del"
        btnRemove.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.SeaGreen
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(220, 40)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(60, 30)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' txtInput
        ' 
        txtInput.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        txtInput.BorderStyle = BorderStyle.FixedSingle
        txtInput.Font = New Font("Segoe UI", 10.0F)
        txtInput.ForeColor = Color.White
        txtInput.Location = New Point(15, 40)
        txtInput.Name = "txtInput"
        txtInput.PlaceholderText = "Enter item name..."
        txtInput.Size = New Size(200, 30)
        txtInput.TabIndex = 1
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(10, 5)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(229, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Inventory Array Builder:"
        ' 
        ' lblLesson
        ' 
        lblLesson.BackColor = Color.Transparent
        lblLesson.Font = New Font("Segoe UI", 9.5F)
        lblLesson.ForeColor = Color.White
        lblLesson.Location = New Point(410, 75)
        lblLesson.Name = "lblLesson"
        lblLesson.Size = New Size(350, 400)
        lblLesson.TabIndex = 1
        lblLesson.Text = resources.GetString("lblLesson.Text")
        ' 
        ' Week7Form
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        ClientSize = New Size(850, 560)
        Controls.Add(lblLesson)
        Controls.Add(pnlInteractive)
        Name = "Week7Form"
        Text = "Week 7 - Arrays"
        Controls.SetChildIndex(pnlContainer, 0)
        Controls.SetChildIndex(pnlInteractive, 0)
        Controls.SetChildIndex(lblLesson, 0)
        pnlInteractive.ResumeLayout(False)
        pnlInteractive.PerformLayout()
        ResumeLayout(False)

    End Sub
End Class
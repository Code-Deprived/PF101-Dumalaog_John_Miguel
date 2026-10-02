<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Week8Form
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

    ' Tab Controls
    Friend WithEvents tcWeek8 As System.Windows.Forms.TabControl
    Friend WithEvents tpDialogs As System.Windows.Forms.TabPage
    Friend WithEvents tpTextEditor As System.Windows.Forms.TabPage
    Friend WithEvents tpTreeView As System.Windows.Forms.TabPage
    Friend WithEvents tpListView As System.Windows.Forms.TabPage
    Friend WithEvents tpReviewer As System.Windows.Forms.TabPage

    ' Module 1 Controls
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents chkAllowFullOpen As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowColorFont As System.Windows.Forms.CheckBox
    Friend WithEvents chkMultiselect As System.Windows.Forms.CheckBox
    Friend WithEvents chkOverwritePrompt As System.Windows.Forms.CheckBox
    Friend WithEvents pnlDialogPreview As System.Windows.Forms.Panel
    Friend WithEvents lblPreviewSample As System.Windows.Forms.Label
    Friend WithEvents rtbDialogLog As System.Windows.Forms.RichTextBox

    ' Module 2 Controls
    Friend WithEvents rtbEditor As System.Windows.Forms.RichTextBox
    Friend WithEvents lblEditorStatus As System.Windows.Forms.Label

    ' Module 3 Controls
    Friend WithEvents tvTerraria As System.Windows.Forms.TreeView
    Friend WithEvents txtNodeText As System.Windows.Forms.TextBox
    Friend WithEvents lblNodeInspector As System.Windows.Forms.Label

    ' Module 4 Controls
    Friend WithEvents lvChest As System.Windows.Forms.ListView
    Friend WithEvents cmbListViewMode As System.Windows.Forms.ComboBox
    Friend WithEvents chkGridLines As System.Windows.Forms.CheckBox
    Friend WithEvents chkCheckBoxes As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchItem As System.Windows.Forms.TextBox

    ' Module 5 Controls
    Friend WithEvents txtReviewerContent As System.Windows.Forms.RichTextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tcWeek8 = New System.Windows.Forms.TabControl()
        Me.tpDialogs = New System.Windows.Forms.TabPage()
        Me.tpTextEditor = New System.Windows.Forms.TabPage()
        Me.tpTreeView = New System.Windows.Forms.TabPage()
        Me.tpListView = New System.Windows.Forms.TabPage()
        Me.tpReviewer = New System.Windows.Forms.TabPage()

        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()

        Me.chkAllowFullOpen = New System.Windows.Forms.CheckBox()
        Me.chkShowColorFont = New System.Windows.Forms.CheckBox()
        Me.chkMultiselect = New System.Windows.Forms.CheckBox()
        Me.chkOverwritePrompt = New System.Windows.Forms.CheckBox()
        Me.pnlDialogPreview = New System.Windows.Forms.Panel()
        Me.lblPreviewSample = New System.Windows.Forms.Label()
        Me.rtbDialogLog = New System.Windows.Forms.RichTextBox()

        Me.rtbEditor = New System.Windows.Forms.RichTextBox()
        Me.lblEditorStatus = New System.Windows.Forms.Label()

        Me.tvTerraria = New System.Windows.Forms.TreeView()
        Me.txtNodeText = New System.Windows.Forms.TextBox()
        Me.lblNodeInspector = New System.Windows.Forms.Label()

        Me.lvChest = New System.Windows.Forms.ListView()
        Me.cmbListViewMode = New System.Windows.Forms.ComboBox()
        Me.chkGridLines = New System.Windows.Forms.CheckBox()
        Me.chkCheckBoxes = New System.Windows.Forms.CheckBox()
        Me.txtSearchItem = New System.Windows.Forms.TextBox()

        Me.txtReviewerContent = New System.Windows.Forms.RichTextBox()

        Me.tcWeek8.SuspendLayout()
        Me.SuspendLayout()
        '
        ' tcWeek8
        '
        Me.tcWeek8.Controls.Add(Me.tpDialogs)
        Me.tcWeek8.Controls.Add(Me.tpTextEditor)
        Me.tcWeek8.Controls.Add(Me.tpTreeView)
        Me.tcWeek8.Controls.Add(Me.tpListView)
        Me.tcWeek8.Controls.Add(Me.tpReviewer)
        Me.tcWeek8.Location = New System.Drawing.Point(15, 60)
        Me.tcWeek8.Name = "tcWeek8"
        Me.tcWeek8.SelectedIndex = 0
        Me.tcWeek8.Size = New System.Drawing.Size(770, 375)
        Me.tcWeek8.TabIndex = 0
        '
        ' tpDialogs
        '
        Me.tpDialogs.Location = New System.Drawing.Point(4, 29)
        Me.tpDialogs.Name = "tpDialogs"
        Me.tpDialogs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDialogs.Size = New System.Drawing.Size(762, 342)
        Me.tpDialogs.TabIndex = 0
        Me.tpDialogs.Text = "Common Dialogs"
        '
        ' tpTextEditor
        '
        Me.tpTextEditor.Location = New System.Drawing.Point(4, 29)
        Me.tpTextEditor.Name = "tpTextEditor"
        Me.tpTextEditor.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTextEditor.Size = New System.Drawing.Size(762, 342)
        Me.tpTextEditor.TabIndex = 1
        Me.tpTextEditor.Text = "Text Editor & Clipboard"
        '
        ' tpTreeView
        '
        Me.tpTreeView.Location = New System.Drawing.Point(4, 29)
        Me.tpTreeView.Name = "tpTreeView"
        Me.tpTreeView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTreeView.Size = New System.Drawing.Size(762, 342)
        Me.tpTreeView.TabIndex = 2
        Me.tpTreeView.Text = "TreeView Browser"
        '
        ' tpListView
        '
        Me.tpListView.Location = New System.Drawing.Point(4, 29)
        Me.tpListView.Name = "tpListView"
        Me.tpListView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListView.Size = New System.Drawing.Size(762, 342)
        Me.tpListView.TabIndex = 3
        Me.tpListView.Text = "ListView Chest"
        '
        ' tpReviewer
        '
        Me.tpReviewer.Location = New System.Drawing.Point(4, 29)
        Me.tpReviewer.Name = "tpReviewer"
        Me.tpReviewer.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReviewer.Size = New System.Drawing.Size(762, 342)
        Me.tpReviewer.TabIndex = 4
        Me.tpReviewer.Text = "Module Reviewer"
        '
        ' Week8Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 560)
        Me.Name = "Week8Form"
        Me.Text = "Week 8: Working with Controls & Properties"
        Me.tcWeek8.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class
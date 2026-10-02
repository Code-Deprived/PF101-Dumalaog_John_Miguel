Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

<System.Runtime.Versioning.SupportedOSPlatform("windows")>
Public Class Week8Form
    Inherits BaseLessonForm

    ' --- PRINTING ENGINE ---
    Private WithEvents printDoc As New PrintDocument()

    ' --- STATE & DATA STRUCTURES ---
    Private Structure ChestItem
        Public Slot As Integer
        Public Name As String
        Public Category As String
        Public Qty As Integer
        Public Rarity As String
        Public GoldValue As Decimal
    End Structure

    Private initialChestItems As New List(Of ChestItem) From {
        New ChestItem With {.Slot = 1, .Name = "Zenith", .Category = "Weapon", .Qty = 1, .Rarity = "Red", .GoldValue = 100D
    },
        New ChestItem With {.Slot = 2, .Name = "Solar Flare Armor", .Category = "Armor", .Qty = 1, .Rarity = "Amber", .GoldValue = 45D
    },
        New ChestItem With {.Slot = 3, .Name = "Terraspark Boots", .Category = "Accessory", .Qty = 1, .Rarity = "Lime", .GoldValue = 20D
    },
        New ChestItem With {.Slot = 4, .Name = "Greater Healing Potion", .Category = "Consumable", .Qty = 30, .Rarity = "Rare", .GoldValue = 15D
    },
        New ChestItem With {.Slot = 5, .Name = "Luminite Bar", .Category = "Material", .Qty = 99, .Rarity = "Cyan", .GoldValue = 120D
    }
    }

    Private Sub Week8Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Week 8: Working with Controls & Properties"
        Me.LessonTitle = "Week 8 Reviewer & Interactive Workshop"

        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Clear()

            ' Style the TabControl and TabPages
            tcWeek8.SetBounds(15, 60, 770, 375)
            tcWeek8.Font = GetAndyFont(10.5F, FontStyle.Bold)

            ApplyTerrariaTabStyles()

            ' Initialize Sub-Modules
            InitializeDialogsTab()
            InitializeEditorTab()
            InitializeTreeViewTab()
            InitializeListViewTab()
            InitializeReviewerTab()

            pnlContainer.Controls.Add(tcWeek8)
            tcWeek8.BringToFront()
        End If
    End Sub

    Private Sub ApplyTerrariaTabStyles()
        For Each page As TabPage In tcWeek8.TabPages
            page.BackColor = Color.FromArgb(24, 28, 48)
            page.ForeColor = Color.White
        Next
    End Sub

    ' =========================================================================
    ' MODULE 1: COMMON DIALOGS & DIALOGRESULT DEMONSTRATION
    ' =========================================================================
    Private Sub InitializeDialogsTab()
        tpDialogs.Controls.Clear()

        Dim pnlLeft As New DoubleBufferedPanel() With {
            .Bounds = New Rectangle(10, 10, 360, 325),
            .BackColor = Color.FromArgb(18, 22, 38),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblTitle As New Label() With {
            .Text = "Common Dialog Controls",
            .Font = GetAndyFont(13.0F, FontStyle.Bold),
            .ForeColor = Color.Gold,
            .Bounds = New Rectangle(10, 10, 340, 25)
        }

        ' Config Checkboxes
        chkAllowFullOpen.SetBounds(10, 40, 160, 22)
        chkAllowFullOpen.Text = "Allow Custom Colors"
        chkAllowFullOpen.ForeColor = Color.White
        chkAllowFullOpen.Checked = True

        chkShowColorFont.SetBounds(180, 40, 160, 22)
        chkShowColorFont.Text = "Show Font Color"
        chkShowColorFont.ForeColor = Color.White
        chkShowColorFont.Checked = True

        chkMultiselect.SetBounds(10, 65, 160, 22)
        chkMultiselect.Text = "Multi-Select Files"
        chkMultiselect.ForeColor = Color.White

        chkOverwritePrompt.SetBounds(180, 65, 160, 22)
        chkOverwritePrompt.Text = "Overwrite Prompt"
        chkOverwritePrompt.ForeColor = Color.White
        chkOverwritePrompt.Checked = True

        ' Action Buttons
        Dim btnColor As Button = CreateTerrariaBtn("ColorDialog", 10, 95, 160, 32, Color.FromArgb(60, 70, 110))
        Dim btnFont As Button = CreateTerrariaBtn("FontDialog", 180, 95, 160, 32, Color.FromArgb(60, 70, 110))
        Dim btnOpen As Button = CreateTerrariaBtn("OpenFileDialog", 10, 135, 160, 32, Color.FromArgb(60, 70, 110))
        Dim btnSave As Button = CreateTerrariaBtn("SaveFileDialog", 180, 135, 160, 32, Color.FromArgb(60, 70, 110))
        Dim btnPrint As Button = CreateTerrariaBtn("PrintDialog", 10, 175, 330, 32, Color.FromArgb(40, 90, 80))

        ' Preview Card
        pnlDialogPreview.SetBounds(10, 215, 330, 95)
        pnlDialogPreview.BackColor = Color.FromArgb(32, 38, 62)
        pnlDialogPreview.BorderStyle = BorderStyle.Fixed3D

        lblPreviewSample.Text = "Terraria Workshop Preview Text"
        lblPreviewSample.Font = GetAndyFont(12.0F, FontStyle.Bold)
        lblPreviewSample.ForeColor = Color.Gold
        lblPreviewSample.Dock = DockStyle.Fill
        lblPreviewSample.TextAlign = ContentAlignment.MiddleCenter

        pnlDialogPreview.Controls.Add(lblPreviewSample)

        AddHandler btnColor.Click, AddressOf RunColorDialogDemo
        AddHandler btnFont.Click, AddressOf RunFontDialogDemo
        AddHandler btnOpen.Click, AddressOf RunOpenFileDialogDemo
        AddHandler btnSave.Click, AddressOf RunSaveFileDialogDemo
        AddHandler btnPrint.Click, AddressOf RunPrintDialogDemo

        pnlLeft.Controls.AddRange({lblTitle, chkAllowFullOpen, chkShowColorFont, chkMultiselect, chkOverwritePrompt, btnColor, btnFont, btnOpen, btnSave, btnPrint, pnlDialogPreview})

        ' Right Terminal Panel for DialogResult & Properties
        Dim pnlRight As New DoubleBufferedPanel() With {
            .Bounds = New Rectangle(380, 10, 365, 325),
            .BackColor = Color.FromArgb(12, 15, 26),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblTermHeader As New Label() With {
            .Text = "DialogResult & Property Diagnostics",
            .Font = GetAndyFont(12.0F, FontStyle.Bold),
            .ForeColor = Color.Cyan,
            .Bounds = New Rectangle(10, 10, 345, 22)
        }

        rtbDialogLog.SetBounds(10, 35, 343, 275)
        rtbDialogLog.BackColor = Color.FromArgb(8, 10, 18)
        rtbDialogLog.ForeColor = Color.Lime
        rtbDialogLog.Font = New Font("Consolas", 9.0F, FontStyle.Regular)
        rtbDialogLog.ReadOnly = True
        rtbDialogLog.BorderStyle = BorderStyle.None

        pnlRight.Controls.AddRange({lblTermHeader, rtbDialogLog})
        tpDialogs.Controls.AddRange({pnlLeft, pnlRight})

        LogDialogOutput("SYSTEM", DialogResult.None, "Dialog Control Subsystem Ready. Select a dialog action above.")
    End Sub

    Private Sub LogDialogOutput(dialogName As String, result As DialogResult, details As String)
        rtbDialogLog.AppendText($"========================================{vbCrLf}")
        rtbDialogLog.AppendText($"[CONTROL]: {dialogName}{vbCrLf}")
        rtbDialogLog.AppendText($"[RESULT ]: DialogResult.{result}{vbCrLf}")
        rtbDialogLog.AppendText($"[DETAILS]:{vbCrLf}{details}{vbCrLf}{vbCrLf}")
        rtbDialogLog.SelectionStart = rtbDialogLog.TextLength
        rtbDialogLog.ScrollToCaret()
    End Sub

    Private Sub RunColorDialogDemo(sender As Object, e As EventArgs)
        ColorDialog1.AllowFullOpen = chkAllowFullOpen.Checked
        ColorDialog1.FullOpen = True
        ColorDialog1.AnyColor = True

        Dim res As DialogResult = ColorDialog1.ShowDialog()
        If res = DialogResult.OK Then
            pnlDialogPreview.BackColor = ColorDialog1.Color
            lblPreviewSample.ForeColor = If(ColorDialog1.Color.R * 0.299 + ColorDialog1.Color.G * 0.587 + ColorDialog1.Color.B * 0.114 > 128, Color.Black, Color.White)
            LogDialogOutput("ColorDialog", res, $"Selected Color: {ColorDialog1.Color}{vbCrLf}RGB: ({ColorDialog1.Color.R}, {ColorDialog1.Color.G}, {ColorDialog1.Color.B}){vbCrLf}Hex: #{ColorDialog1.Color.R:X2}{ColorDialog1.Color.G:X2}{ColorDialog1.Color.B:X2}")
        Else
            LogDialogOutput("ColorDialog", res, "User cancelled color selection or closed dialog.")
        End If
    End Sub

    Private Sub RunFontDialogDemo(sender As Object, e As EventArgs)
        FontDialog1.ShowColor = chkShowColorFont.Checked
        FontDialog1.Font = lblPreviewSample.Font
        FontDialog1.Color = lblPreviewSample.ForeColor

        Dim res As DialogResult = FontDialog1.ShowDialog()
        If res = DialogResult.OK Then
            lblPreviewSample.Font = FontDialog1.Font
            If chkShowColorFont.Checked Then lblPreviewSample.ForeColor = FontDialog1.Color
            LogDialogOutput("FontDialog", res, $"Selected Font: {FontDialog1.Font.Name}, {FontDialog1.Font.SizeInPoints}pt, Style={FontDialog1.Font.Style}{vbCrLf}Selected Color: {FontDialog1.Color}")
        Else
            LogDialogOutput("FontDialog", res, "User cancelled font selection.")
        End If
    End Sub

    Private Sub RunOpenFileDialogDemo(sender As Object, e As EventArgs)
        OpenFileDialog1.Title = "Select Terraria Data or Text File"
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|Terraria World (*.wld)|*.wld|All Files (*.*)|*.*"
        OpenFileDialog1.Multiselect = chkMultiselect.Checked
        OpenFileDialog1.CheckFileExists = True

        Dim res As DialogResult = OpenFileDialog1.ShowDialog()
        If res = DialogResult.OK Then
            Dim info As String = $"FileName: {OpenFileDialog1.FileName}{vbCrLf}"
            If OpenFileDialog1.Multiselect Then
                info &= $"Selected Files Count: {OpenFileDialog1.FileNames.Length}{vbCrLf}"
                For Each f In OpenFileDialog1.FileNames
                    info &= $" -> {f}{vbCrLf}"
                Next
            End If
            LogDialogOutput("OpenFileDialog", res, info)
        Else
            LogDialogOutput("OpenFileDialog", res, "File selection aborted.")
        End If
    End Sub

    Private Sub RunSaveFileDialogDemo(sender As Object, e As EventArgs)
        SaveFileDialog1.Title = "Save Workshop Item / Blueprint"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|JSON Blueprint (*.json)|*.json|All Files (*.*)|*.*"
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.OverwritePrompt = chkOverwritePrompt.Checked

        Dim res As DialogResult = SaveFileDialog1.ShowDialog()
        If res = DialogResult.OK Then
            LogDialogOutput("SaveFileDialog", res, $"Save Target Path: {SaveFileDialog1.FileName}{vbCrLf}Default Ext: {SaveFileDialog1.DefaultExt}{vbCrLf}Filter Index: {SaveFileDialog1.FilterIndex}")
        Else
            LogDialogOutput("SaveFileDialog", res, "Save action cancelled.")
        End If
    End Sub

    Private Sub RunPrintDialogDemo(sender As Object, e As EventArgs)
        PrintDialog1.Document = printDoc
        PrintDialog1.AllowSelection = True
        PrintDialog1.AllowSomePages = True

        Dim res As DialogResult = PrintDialog1.ShowDialog()
        If res = DialogResult.OK Then
            LogDialogOutput("PrintDialog", res, $"Printer Name: {printDoc.PrinterSettings.PrinterName}{vbCrLf}Copies: {printDoc.PrinterSettings.Copies}{vbCrLf}Print To File: {printDoc.PrinterSettings.PrintToFile}")
            Try
                printDoc.Print()
            Catch ex As Exception
                MessageBox.Show($"Simulated Print Execution Completed.{vbCrLf}Details: {ex.Message}", "Print Subsystem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            LogDialogOutput("PrintDialog", res, "Printing cancelled by user.")
        End If
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Using borderPen As New Pen(Color.Gold, 4),
              headerFont As New Font("Trebuchet MS", 18, FontStyle.Bold),
              bodyFont As New Font("Consolas", 11, FontStyle.Regular),
              goldBrush As New SolidBrush(Color.DarkGoldenrod),
              textBrush As New SolidBrush(Color.Black)

            g.DrawRectangle(borderPen, 40, 40, e.PageBounds.Width - 80, e.PageBounds.Height - 80)
            g.DrawString("TERRARIA WORKSHOP CERTIFICATE", headerFont, goldBrush, 60, 60)
            g.DrawString($"Printed On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", bodyFont, textBrush, 60, 100)
            g.DrawString("This document verifies successful demonstration of VB.NET PrintDialog & PrintDocument controls.", bodyFont, textBrush, 60, 140)
        End Using
        e.HasMorePages = False
    End Sub

    ' =========================================================================
    ' MODULE 2: TEXT EDITING, FORMATTING & CLIPBOARD OPERATIONS
    ' =========================================================================
    Private Sub InitializeEditorTab()
        tpTextEditor.Controls.Clear()

        ' Toolbar
        Dim pnlToolbar As New DoubleBufferedPanel() With {
            .Bounds = New Rectangle(10, 10, 735, 42),
            .BackColor = Color.FromArgb(18, 22, 38),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim btnCut As Button = CreateTerrariaBtn("Cut", 5, 5, 55, 30, Color.FromArgb(60, 70, 110))
        Dim btnCopy As Button = CreateTerrariaBtn("Copy", 65, 5, 55, 30, Color.FromArgb(60, 70, 110))
        Dim btnPaste As Button = CreateTerrariaBtn("Paste", 125, 5, 55, 30, Color.FromArgb(60, 70, 110))
        Dim btnUndo As Button = CreateTerrariaBtn("Undo", 185, 5, 55, 30, Color.FromArgb(60, 70, 110))
        Dim btnRedo As Button = CreateTerrariaBtn("Redo", 245, 5, 55, 30, Color.FromArgb(60, 70, 110))
        Dim btnClear As Button = CreateTerrariaBtn("Clear", 305, 5, 55, 30, Color.FromArgb(120, 50, 50))

        Dim btnBold As Button = CreateTerrariaBtn("B", 370, 5, 35, 30, Color.FromArgb(80, 90, 130))
        Dim btnItalic As Button = CreateTerrariaBtn("I", 410, 5, 35, 30, Color.FromArgb(80, 90, 130))
        Dim btnUnderline As Button = CreateTerrariaBtn("U", 450, 5, 35, 30, Color.FromArgb(80, 90, 130))

        Dim btnAlignLeft As Button = CreateTerrariaBtn("Left", 495, 5, 45, 30, Color.FromArgb(50, 60, 90))
        Dim btnAlignCenter As Button = CreateTerrariaBtn("Center", 545, 5, 55, 30, Color.FromArgb(50, 60, 90))
        Dim btnAlignRight As Button = CreateTerrariaBtn("Right", 605, 5, 45, 30, Color.FromArgb(50, 60, 90))

        Dim btnColorText As Button = CreateTerrariaBtn("Color", 655, 5, 70, 30, Color.FromArgb(40, 90, 80))

        AddHandler btnCut.Click, Sub() rtbEditor.Cut()
        AddHandler btnCopy.Click, Sub() rtbEditor.Copy()
        AddHandler btnPaste.Click, Sub() rtbEditor.Paste()
        AddHandler btnUndo.Click, Sub() If rtbEditor.CanUndo Then rtbEditor.Undo()
        AddHandler btnRedo.Click, Sub() If rtbEditor.CanRedo Then rtbEditor.Redo()
        AddHandler btnClear.Click, Sub() rtbEditor.Clear()

        AddHandler btnBold.Click, Sub() ToggleSelectionStyle(FontStyle.Bold)
        AddHandler btnItalic.Click, Sub() ToggleSelectionStyle(FontStyle.Italic)
        AddHandler btnUnderline.Click, Sub() ToggleSelectionStyle(FontStyle.Underline)

        AddHandler btnAlignLeft.Click, Sub() rtbEditor.SelectionAlignment = HorizontalAlignment.Left
        AddHandler btnAlignCenter.Click, Sub() rtbEditor.SelectionAlignment = HorizontalAlignment.Center
        AddHandler btnAlignRight.Click, Sub() rtbEditor.SelectionAlignment = HorizontalAlignment.Right

        AddHandler btnColorText.Click, Sub()
                                           If ColorDialog1.ShowDialog() = DialogResult.OK Then
                                               rtbEditor.SelectionColor = ColorDialog1.Color
                                           End If
                                       End Sub

        pnlToolbar.Controls.AddRange({btnCut, btnCopy, btnPaste, btnUndo, btnRedo, btnClear, btnBold, btnItalic, btnUnderline, btnAlignLeft, btnAlignCenter, btnAlignRight, btnColorText})

        ' Editor Box
        rtbEditor.SetBounds(10, 60, 735, 235)
        rtbEditor.BackColor = Color.FromArgb(12, 16, 28)
        rtbEditor.ForeColor = Color.White
        rtbEditor.Font = New Font("Consolas", 10.5F, FontStyle.Regular)
        rtbEditor.BorderStyle = BorderStyle.FixedSingle
        rtbEditor.Text = "Terraria Advanced Text Editor & Formatting Engine" & vbCrLf & vbCrLf &
                         "1. Select any text above to apply Cut, Copy, or Paste." & vbCrLf &
                         "2. Use the B, I, U buttons to toggle selection typography." & vbCrLf &
                         "3. Change text alignment or apply custom colors via ColorDialog."

        AddHandler rtbEditor.SelectionChanged, AddressOf UpdateEditorStats

        ' Status Strip
        lblEditorStatus.SetBounds(10, 302, 735, 22)
        lblEditorStatus.BackColor = Color.FromArgb(18, 22, 38)
        lblEditorStatus.ForeColor = Color.Cyan
        lblEditorStatus.Font = GetAndyFont(10.0F, FontStyle.Regular)
        lblEditorStatus.Text = "SelectionStart: 0 | SelectionLength: 0 | Total Lines: 5"

        tpTextEditor.Controls.AddRange({pnlToolbar, rtbEditor, lblEditorStatus})
    End Sub

    Private Sub ToggleSelectionStyle(styleFlag As FontStyle)
        If rtbEditor.SelectionFont Is Nothing Then Return
        Dim currentFont As Font = rtbEditor.SelectionFont
        Dim newStyle As FontStyle = currentFont.Style Xor styleFlag
        rtbEditor.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newStyle)
    End Sub

    Private Sub UpdateEditorStats(sender As Object, e As EventArgs)
        Dim lineCount As Integer = rtbEditor.Lines.Length
        lblEditorStatus.Text = $"SelectionStart: {rtbEditor.SelectionStart} | SelectionLength: {rtbEditor.SelectionLength} | Selected Text: '{rtbEditor.SelectedText}' | Total Lines: {lineCount}"
    End Sub

    ' =========================================================================
    ' MODULE 3: TREEVIEW CONTROL (HIERARCHICAL TREE)
    ' =========================================================================
    Private Sub InitializeTreeViewTab()
        tpTreeView.Controls.Clear()

        ' Left TreeView
        tvTerraria.SetBounds(10, 10, 350, 315)
        tvTerraria.BackColor = Color.FromArgb(12, 16, 28)
        tvTerraria.ForeColor = Color.Gold
        tvTerraria.LineColor = Color.LightSkyBlue
        tvTerraria.Font = GetAndyFont(11.0F, FontStyle.Regular)
        tvTerraria.BorderStyle = BorderStyle.FixedSingle

        BuildSampleTree()
        AddHandler tvTerraria.AfterSelect, AddressOf InspectTreeNode

        ' Right Control & Inspector Panel
        Dim pnlRight As New DoubleBufferedPanel() With {
            .Bounds = New Rectangle(370, 10, 375, 315),
            .BackColor = Color.FromArgb(18, 22, 38),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblAdd As New Label() With {.Text = "Manage Nodes:", .ForeColor = Color.Gold, .Bounds = New Rectangle(10, 10, 120, 20), .Font = GetAndyFont(11.0F, FontStyle.Bold)}
        txtNodeText.SetBounds(130, 8, 230, 24)
        txtNodeText.BackColor = Color.FromArgb(30, 35, 60)
        txtNodeText.ForeColor = Color.White
        txtNodeText.Text = "New Terraria Node"

        Dim btnAddRoot As Button = CreateTerrariaBtn("Add Root Node", 10, 40, 175, 30, Color.SeaGreen)
        Dim btnAddChild As Button = CreateTerrariaBtn("Add Child Node", 190, 40, 175, 30, Color.SeaGreen)
        Dim btnRemoveNode As Button = CreateTerrariaBtn("Remove Selected", 10, 78, 175, 30, Color.IndianRed)
        Dim btnClearTree As Button = CreateTerrariaBtn("Clear All Nodes", 190, 78, 175, 30, Color.Maroon)

        Dim btnExpand As Button = CreateTerrariaBtn("Expand All", 10, 116, 175, 30, Color.FromArgb(60, 70, 110))
        Dim btnCollapse As Button = CreateTerrariaBtn("Collapse All", 190, 116, 175, 30, Color.FromArgb(60, 70, 110))

        ' Inspector Box
        lblNodeInspector.SetBounds(10, 158, 355, 145)
        lblNodeInspector.BackColor = Color.FromArgb(8, 10, 18)
        lblNodeInspector.ForeColor = Color.Lime
        lblNodeInspector.Font = New Font("Consolas", 9.5F, FontStyle.Regular)
        lblNodeInspector.BorderStyle = BorderStyle.FixedSingle
        lblNodeInspector.Text = "Select any TreeView node to inspect its hierarchical properties."

        AddHandler btnAddRoot.Click, Sub()
                                         If Not String.IsNullOrWhiteSpace(txtNodeText.Text) Then
                                             tvTerraria.Nodes.Add(New TreeNode(txtNodeText.Text.Trim()))
                                         End If
                                     End Sub

        AddHandler btnAddChild.Click, Sub()
                                          If tvTerraria.SelectedNode IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtNodeText.Text) Then
                                              tvTerraria.SelectedNode.Nodes.Add(New TreeNode(txtNodeText.Text.Trim()))
                                              tvTerraria.SelectedNode.Expand()
                                          Else
                                              MessageBox.Show("Please select a parent node first.", "TreeView Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                          End If
                                      End Sub

        AddHandler btnRemoveNode.Click, Sub()
                                            If tvTerraria.SelectedNode IsNot Nothing Then
                                                tvTerraria.SelectedNode.Remove()
                                            End If
                                        End Sub

        AddHandler btnClearTree.Click, Sub() tvTerraria.Nodes.Clear()
        AddHandler btnExpand.Click, Sub() tvTerraria.ExpandAll()
        AddHandler btnCollapse.Click, Sub() tvTerraria.CollapseAll()

        pnlRight.Controls.AddRange({lblAdd, txtNodeText, btnAddRoot, btnAddChild, btnRemoveNode, btnClearTree, btnExpand, btnCollapse, lblNodeInspector})
        tpTreeView.Controls.AddRange({tvTerraria, pnlRight})
    End Sub

    Private Sub BuildSampleTree()
        tvTerraria.Nodes.Clear()
        Dim rootWeapons As New TreeNode("⚔️ Weapons")
        rootWeapons.Nodes.Add("Melee: Zenith, Terra Blade")
        rootWeapons.Nodes.Add("Ranged: S.D.M.G., Phantasm")
        rootWeapons.Nodes.Add("Magic: Last Prism")

        Dim rootNPCs As New TreeNode("👹 Bestiary / NPCs")
        Dim nodeBosses As New TreeNode("Bosses")
        nodeBosses.Nodes.Add("Eye of Cthulhu")
        nodeBosses.Nodes.Add("Moon Lord")
        rootNPCs.Nodes.Add(nodeBosses)
        rootNPCs.Nodes.Add("Town NPCs: Guide, Merchant")

        tvTerraria.Nodes.AddRange({rootWeapons, rootNPCs})
        tvTerraria.ExpandAll()
    End Sub

    Private Sub InspectTreeNode(sender As Object, e As TreeViewEventArgs)
        If e.Node Is Nothing Then Return
        lblNodeInspector.Text = $"Node Property Inspector:{vbCrLf}" &
                                $"  Text: {e.Node.Text}{vbCrLf}" &
                                $"  FullPath: {e.Node.FullPath}{vbCrLf}" &
                                $"  Depth (Level): {e.Node.Level}{vbCrLf}" &
                                $"  Index Position: {e.Node.Index}{vbCrLf}" &
                                $"  Child Nodes: {e.Node.Nodes.Count}{vbCrLf}" &
                                $"  IsExpanded: {e.Node.IsExpanded}"
    End Sub

    ' =========================================================================
    ' MODULE 4: LISTVIEW CONTROL (TERRARIA CHEST INVENTORY)
    ' =========================================================================
    Private Sub InitializeListViewTab()
        tpListView.Controls.Clear()

        ' Top Controls
        Dim pnlTop As New DoubleBufferedPanel() With {
            .Bounds = New Rectangle(10, 10, 735, 45),
            .BackColor = Color.FromArgb(18, 22, 38),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim lblView As New Label() With {.Text = "View Mode:", .ForeColor = Color.Gold, .Bounds = New Rectangle(10, 12, 80, 20), .Font = GetAndyFont(10.5F, FontStyle.Bold)}
        cmbListViewMode.SetBounds(90, 10, 110, 24)
        cmbListViewMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbListViewMode.Items.AddRange({"Details", "List", "Tile", "SmallIcon", "LargeIcon"})
        cmbListViewMode.SelectedIndex = 0

        chkGridLines.SetBounds(210, 12, 90, 20)
        chkGridLines.Text = "GridLines"
        chkGridLines.ForeColor = Color.White
        chkGridLines.Checked = True

        chkCheckBoxes.SetBounds(305, 12, 100, 20)
        chkCheckBoxes.Text = "CheckBoxes"
        chkCheckBoxes.ForeColor = Color.White

        Dim lblSearch As New Label() With {.Text = "Filter:", .ForeColor = Color.Gold, .Bounds = New Rectangle(415, 12, 50, 20), .Font = GetAndyFont(10.5F, FontStyle.Bold)}
        txtSearchItem.SetBounds(465, 10, 140, 22)
        txtSearchItem.BackColor = Color.FromArgb(30, 35, 60)
        txtSearchItem.ForeColor = Color.White

        Dim btnResetChest As Button = CreateTerrariaBtn("Reset Data", 615, 7, 110, 28, Color.FromArgb(60, 70, 110))

        AddHandler cmbListViewMode.SelectedIndexChanged, AddressOf ChangeListViewMode
        AddHandler chkGridLines.CheckedChanged, Sub() lvChest.GridLines = chkGridLines.Checked
        AddHandler chkCheckBoxes.CheckedChanged, Sub() lvChest.CheckBoxes = chkCheckBoxes.Checked
        AddHandler txtSearchItem.TextChanged, AddressOf FilterChestItems
        AddHandler btnResetChest.Click, Sub() PopulateChestListView(initialChestItems)

        pnlTop.Controls.AddRange({lblView, cmbListViewMode, chkGridLines, chkCheckBoxes, lblSearch, txtSearchItem, btnResetChest})

        ' ListView Control
        lvChest.SetBounds(10, 62, 735, 260)
        lvChest.BackColor = Color.FromArgb(12, 16, 28)
        lvChest.ForeColor = Color.Cyan
        lvChest.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        lvChest.FullRowSelect = True
        lvChest.GridLines = True
        lvChest.View = View.Details

        ' Columns
        lvChest.Columns.Clear()
        lvChest.Columns.Add("Slot", 60, HorizontalAlignment.Center)
        lvChest.Columns.Add("Item Name", 200, HorizontalAlignment.Left)
        lvChest.Columns.Add("Category", 130, HorizontalAlignment.Left)
        lvChest.Columns.Add("Quantity", 90, HorizontalAlignment.Right)
        lvChest.Columns.Add("Rarity", 100, HorizontalAlignment.Center)
        lvChest.Columns.Add("Value (Gold)", 120, HorizontalAlignment.Right)

        PopulateChestListView(initialChestItems)

        tpListView.Controls.AddRange({pnlTop, lvChest})
    End Sub

    Private Sub PopulateChestListView(items As List(Of ChestItem))
        lvChest.Items.Clear()
        For Each item In items
            Dim lvi As New ListViewItem(item.Slot.ToString())
            lvi.SubItems.Add(item.Name)
            lvi.SubItems.Add(item.Category)
            lvi.SubItems.Add(item.Qty.ToString())
            lvi.SubItems.Add(item.Rarity)
            lvi.SubItems.Add(item.GoldValue.ToString("C2"))
            lvChest.Items.Add(lvi)
        Next
    End Sub

    Private Sub ChangeListViewMode(sender As Object, e As EventArgs)
        Select Case cmbListViewMode.SelectedItem.ToString()
            Case "Details" : lvChest.View = View.Details
            Case "List" : lvChest.View = View.List
            Case "Tile" : lvChest.View = View.Tile
            Case "SmallIcon" : lvChest.View = View.SmallIcon
            Case "LargeIcon" : lvChest.View = View.LargeIcon
        End Select
    End Sub

    Private Sub FilterChestItems(sender As Object, e As EventArgs)
        Dim query As String = txtSearchItem.Text.Trim().ToLower()
        If String.IsNullOrEmpty(query) Then
            PopulateChestListView(initialChestItems)
            Return
        End If

        Dim filtered = initialChestItems.Where(Function(i) i.Name.ToLower().Contains(query) OrElse i.Category.ToLower().Contains(query)).ToList()
        PopulateChestListView(filtered)
    End Sub

    ' =========================================================================
    ' MODULE 5: MODULE REVIEWER & THEORY NOTES
    ' =========================================================================
    Private Sub InitializeReviewerTab()
        tpReviewer.Controls.Clear()

        txtReviewerContent.Dock = DockStyle.Fill
        txtReviewerContent.BackColor = Color.FromArgb(12, 16, 28)
        txtReviewerContent.ForeColor = Color.White
        txtReviewerContent.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        txtReviewerContent.ReadOnly = True

        txtReviewerContent.Text =
            "=========================================================" & vbCrLf &
            " WEEK 8: WORKING WITH CONTROLS AND PROPERTIES (REVIEWER) " & vbCrLf &
            "=========================================================" & vbCrLf & vbCrLf &
            "1. BUILT-IN DIALOG BOXES & COMMONDIALOG CLASS" & vbCrLf &
            "   - All dialog controls inherit from CommonDialog and invoke ShowDialog() at runtime." & vbCrLf &
            "   - ShowDialog() returns a DialogResult enumeration value (OK, Cancel, Abort, Retry, Ignore, Yes, No)." & vbCrLf &
            "   - Dialog controls appear in the Component Tray in Visual Studio Designer." & vbCrLf & vbCrLf &
            "2. COLORDIALOG & FONTDIALOG" & vbCrLf &
            "   - ColorDialog: Color property returns a System.Drawing.Color structure." & vbCrLf &
            "   - FontDialog: Prompts user to select installed system fonts, sizes, and colors (ShowColor = True)." & vbCrLf & vbCrLf &
            "3. FILE DIALOGS (OPENFILEDIALOG & SAVEFILEDIALOG)" & vbCrLf &
            "   - OpenFileDialog: Uses FileName / FileNames and Filter properties to browse files." & vbCrLf &
            "   - SaveFileDialog: Prompts save location, DefaultExt, and OverwritePrompt." & vbCrLf & vbCrLf &
            "4. PRINTDIALOG & PRINTDOCUMENT" & vbCrLf &
            "   - PrintDialog connects to a PrintDocument object to configure printer settings and render pages via the PrintPage event." & vbCrLf & vbCrLf &
            "5. TEXT MANIPULATION & CLIPBOARD API" & vbCrLf &
            "   - Supports SelectionStart, SelectionLength, SelectedText, Cut(), Copy(), Paste(), Clear(), Undo(), Redo()." & vbCrLf & vbCrLf &
            "6. TREEVIEW & LISTVIEW CONTROLS" & vbCrLf &
            "   - TreeView: Displays hierarchical nodes (Nodes.Add, SelectedNode, ExpandAll, CollapseAll)." & vbCrLf &
            "   - ListView: Displays items with SubItems across 5 View modes (Details, List, Tile, SmallIcon, LargeIcon)."

        tpReviewer.Controls.Add(txtReviewerContent)
    End Sub

    Private Function CreateTerrariaBtn(txt As String, x As Integer, y As Integer, w As Integer, h As Integer, bg As Color) As Button
        Dim btn As New Button() With {
            .Text = txt,
            .Bounds = New Rectangle(x, y, w, h),
            .BackColor = bg,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .Font = GetAndyFont(10.0F, FontStyle.Bold)
        }
        btn.FlatAppearance.BorderColor = Color.Gold
        Return btn
    End Function
End Class
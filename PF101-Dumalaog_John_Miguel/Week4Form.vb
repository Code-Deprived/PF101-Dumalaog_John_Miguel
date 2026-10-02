Imports System.Drawing
Imports System.Windows.Forms

Public Class Week4Form
    Inherits BaseLessonForm

    ' --- ADVANCED: Dynamic Control Declarations ---
    Private pnlSandbox As New Panel()
    Private lstEventLog As New ListBox()
    Private pbMana As New ProgressBar()
    Private WithEvents scrollOpacity As New HScrollBar()
    Private WithEvents dtpGameTime As New DateTimePicker()
    Private WithEvents cmbTheme As New ComboBox()
    Private WithEvents chkTopMost As New CheckBox()
    Private WithEvents radDay As New RadioButton()
    Private WithEvents radNight As New RadioButton()
    Private WithEvents btnResize As New Button()
    Private dynBtnAnchored As New Button()
    Private pnlDocked As New Panel()
    Private picIcon As New PictureBox()
    Private pnlAnchorDock As New Panel()

    Private Sub Week4Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear previous designer remnants and setup the container
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Clear()
            pnlContainer.Controls.Add(pnlSandbox)
            pnlSandbox.BringToFront()
        End If

        InitializeTerrariaSandbox()
    End Sub

    ' --- ADVANCED: Programmatic Interface Design ---
    Private Sub InitializeTerrariaSandbox()
        ' 1. Form & Container Properties
        pnlSandbox.Size = New Size(760, 410)
        pnlSandbox.Location = New Point(20, 20)
        pnlSandbox.BackColor = Color.FromArgb(30, 35, 60)
        pnlSandbox.BorderStyle = BorderStyle.FixedSingle

        ' 2. Event Log (ListBox)
        lstEventLog.Size = New Size(300, 380)
        lstEventLog.Location = New Point(440, 15)
        lstEventLog.BackColor = Color.FromArgb(15, 20, 38)
        lstEventLog.ForeColor = Color.Lime
        lstEventLog.Font = New Font("Consolas", 9.0F)
        lstEventLog.TabStop = False ' Excluded from Tab Index
        pnlSandbox.Controls.Add(lstEventLog)
        LogEvent("System", "Sandbox Initialized. Awaiting events...")

        ' 3. ComboBox & PictureBox (Themes & Images)
        Dim lblTheme As New Label() With {.Text = "UI Theme:", .Location = New Point(15, 15), .ForeColor = Color.White, .AutoSize = True}
        cmbTheme.SetBounds(15, 35, 150, 25)
        cmbTheme.Items.AddRange({"Overworld", "Underworld", "Corruption"})
        cmbTheme.SelectedIndex = 0
        cmbTheme.TabIndex = 0
        cmbTheme.TabStop = True

        picIcon.SetBounds(180, 15, 45, 45)
        picIcon.BackColor = Color.Gold
        picIcon.BorderStyle = BorderStyle.Fixed3D

        ' 4. RadioButtons (Form Background Appearance)
        radDay.SetBounds(15, 70, 80, 25)
        radDay.Text = "Day"
        radDay.ForeColor = Color.White
        radDay.Checked = True
        radDay.TabIndex = 1

        radNight.SetBounds(100, 70, 80, 25)
        radNight.Text = "Night"
        radNight.ForeColor = Color.White
        radNight.TabIndex = 2

        ' 5. CheckBox & ScrollBar (Form Opacity & TopMost Properties)
        chkTopMost.SetBounds(15, 100, 200, 25)
        chkTopMost.Text = "Force Window TopMost"
        chkTopMost.ForeColor = Color.White
        chkTopMost.TabIndex = 3

        Dim lblOpacity As New Label() With {.Text = "Window Opacity (ScrollBar):", .Location = New Point(15, 130), .ForeColor = Color.White, .AutoSize = True}
        scrollOpacity.SetBounds(15, 150, 200, 20)
        scrollOpacity.Minimum = 20
        scrollOpacity.Maximum = 100
        scrollOpacity.Value = 100
        scrollOpacity.TabIndex = 4

        ' 6. DateTimePicker & ProgressBar
        Dim lblTime As New Label() With {.Text = "In-Game Time:", .Location = New Point(15, 180), .ForeColor = Color.White, .AutoSize = True}
        dtpGameTime.SetBounds(15, 200, 200, 25)
        dtpGameTime.Format = DateTimePickerFormat.Time
        dtpGameTime.TabIndex = 5

        Dim lblMana As New Label() With {.Text = "Mana Level (ProgressBar):", .Location = New Point(15, 235), .ForeColor = Color.White, .AutoSize = True}
        pbMana.SetBounds(15, 255, 200, 20)
        pbMana.Value = 100

        ' 7. Anchor & Dock Sandbox Panel
        pnlAnchorDock.Location = New Point(230, 80)
        pnlAnchorDock.Size = New Size(190, 195)
        pnlAnchorDock.BackColor = Color.FromArgb(45, 50, 80)
        pnlAnchorDock.BorderStyle = BorderStyle.FixedSingle

        dynBtnAnchored.Text = "Anchored (B-R)"
        dynBtnAnchored.Size = New Size(100, 30)
        dynBtnAnchored.Location = New Point(80, 155)
        dynBtnAnchored.BackColor = Color.SeaGreen
        dynBtnAnchored.ForeColor = Color.White
        dynBtnAnchored.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right ' ANCHOR PROPERTY

        pnlDocked.BackColor = Color.DarkRed
        pnlDocked.Height = 25
        pnlDocked.Dock = DockStyle.Top ' DOCK PROPERTY

        Dim lblDock As New Label() With {.Text = "Docked Top", .ForeColor = Color.White, .AutoSize = True, .Location = New Point(5, 5)}
        pnlDocked.Controls.Add(lblDock)

        pnlAnchorDock.Controls.Add(dynBtnAnchored)
        pnlAnchorDock.Controls.Add(pnlDocked)

        btnResize.Text = "Simulate Resize"
        btnResize.SetBounds(230, 285, 190, 30)
        btnResize.BackColor = Color.FromArgb(60, 70, 110)
        btnResize.ForeColor = Color.White
        btnResize.TabIndex = 6

        ' Add all to Sandbox
        pnlSandbox.Controls.AddRange({lblTheme, cmbTheme, picIcon, radDay, radNight, chkTopMost, lblOpacity, scrollOpacity, lblTime, dtpGameTime, lblMana, pbMana, pnlAnchorDock, btnResize})
    End Sub

    ' --- ADVANCED: Centralized Event Logging ---
    Private Sub LogEvent(controlName As String, action As String)
        lstEventLog.Items.Add($"[{DateTime.Now.ToString("HH:mm:ss")}] {controlName}:")
        lstEventLog.Items.Add($"  -> {action}")
        lstEventLog.TopIndex = lstEventLog.Items.Count - 1 ' Auto-scroll to bottom
    End Sub

    ' --- EVENT HANDLERS ---
    Private Sub cmbTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTheme.SelectedIndexChanged
        LogEvent("ComboBox", $"Selected Theme '{cmbTheme.SelectedItem}'")
        Select Case cmbTheme.SelectedIndex
            Case 0 : picIcon.BackColor = Color.ForestGreen
            Case 1 : picIcon.BackColor = Color.DarkRed
            Case 2 : picIcon.BackColor = Color.Purple
        End Select
    End Sub

    Private Sub radDayNight_CheckedChanged(sender As Object, e As EventArgs) Handles radDay.CheckedChanged, radNight.CheckedChanged
        If radDay.Checked Then
            pnlSandbox.BackColor = Color.FromArgb(30, 35, 60)
            LogEvent("RadioButton", "Day theme applied (BackColor changed)")
        ElseIf radNight.Checked Then
            pnlSandbox.BackColor = Color.FromArgb(10, 12, 20)
            LogEvent("RadioButton", "Night theme applied (BackColor changed)")
        End If
    End Sub

    Private Sub chkTopMost_CheckedChanged(sender As Object, e As EventArgs) Handles chkTopMost.CheckedChanged
        Me.TopMost = chkTopMost.Checked
        LogEvent("CheckBox", $"Form TopMost property set to {Me.TopMost}")
    End Sub

    Private Sub scrollOpacity_Scroll(sender As Object, e As ScrollEventArgs) Handles scrollOpacity.Scroll
        Me.Opacity = scrollOpacity.Value / 100.0
        pbMana.Value = scrollOpacity.Value ' Tie progress bar to scrollbar for interactivity
        LogEvent("ScrollBar", $"Form Opacity & ProgressBar set to {scrollOpacity.Value}%")
    End Sub

    Private Sub dtpGameTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpGameTime.ValueChanged
        LogEvent("DateTimePicker", $"Time set to {dtpGameTime.Value.ToString("HH:mm:ss")}")
    End Sub

    Private Sub btnResize_Click(sender As Object, e As EventArgs) Handles btnResize.Click
        If pnlAnchorDock.Width = 190 Then
            pnlAnchorDock.Size = New Size(140, 140)
            LogEvent("Button/Method", "Panel shrunk. Notice Anchored/Docked controls adapt.")
        Else
            pnlAnchorDock.Size = New Size(190, 195)
            LogEvent("Button/Method", "Panel restored. Notice Anchored/Docked controls adapt.")
        End If

        MessageBox.Show("Notice how the Red Panel stays Docked to the top, and the Green Button stays Anchored to the bottom-right!", "Anchor & Dock Method", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
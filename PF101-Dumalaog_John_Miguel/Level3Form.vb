Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

Public Class Level3Form
    ' --- Game State Variables ---
    Private playerMaxHP As Integer = 150
    Private playerHP As Integer = 150
    Private bossMaxHP As Integer = 250
    Private bossHP As Integer = 250
    Private isPlayerTurn As Boolean = True
    Private isDefending As Boolean = False
    Private isCritNext As Boolean = False
    Private itemsUsed As Boolean() = {False, False, False}
    Private rnd As New Random()

    ' --- Animation Engine Variables ---
    Private WithEvents tmrEffectAnim As New Timer() With {.Interval = 80} ' ~80ms per frame
    Private effectFrames As New List(Of Image)
    Private currentEffectFrame As Integer = 0
    Private picEffectOverlay As New PictureBox()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Level3Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeEffectOverlay()

        ' --- 1. FIX THE ANNOUNCEMENT LABEL (lblStatus) ---
        lblStatus.AutoSize = False
        lblStatus.Size = New Size(600, 40)
        lblStatus.Location = New Point((Me.ClientSize.Width - 600) \ 2, 20)
        lblStatus.TextAlign = ContentAlignment.MiddleCenter

        ' Swapped to a retro RPG-style font and a soft, clean white color 
        ' to match the dark pixel-art aesthetic without being jarring.
        lblStatus.Font = New Font("Courier New", 14, FontStyle.Bold)
        lblStatus.ForeColor = Color.WhiteSmoke
        lblStatus.BackColor = Color.Transparent
        lblStatus.Text = "The Final Boss appears! Your turn."

        ' --- 2. FIX THE GAME OVER / VICTORY PANELS ---
        pnlVictory.BackColor = Color.Transparent
        pnlGameOver.BackColor = Color.Transparent

        ' --- 3. CENTER THE BUTTONS ---
        ' Parent the button to the panel so its coordinates are relative to the frame
        btnRestart.Parent = pnlGameOver
        ' Mathematically center it in the middle of the Game Over panel
        btnRestart.Location = New Point((pnlGameOver.Width - btnRestart.Width) \ 2, (pnlGameOver.Height - btnRestart.Height) \ 2)

        ' Do the exact same thing for the Victory panel's next button
        btnNextLevel.Parent = pnlVictory
        btnNextLevel.Location = New Point((pnlVictory.Width - btnNextLevel.Width) \ 2, (pnlVictory.Height - btnNextLevel.Height) \ 2)

        ' Ensure layers are pushed to the very front
        lblStatus.BringToFront()
        pnlVictory.BringToFront()
        pnlGameOver.BringToFront()

        pbPlayerHP.Maximum = playerMaxHP
        pbBossHP.Maximum = bossMaxHP
        LoadAssets()
        UpdateHPBars()
        SetupHoverEffects()
    End Sub

    Private Sub InitializeEffectOverlay()
        ' Creates a dynamic picture box that plays effect animations over targets
        picEffectOverlay.BackColor = Color.Transparent
        picEffectOverlay.SizeMode = PictureBoxSizeMode.Zoom
        picEffectOverlay.Visible = False
        picEffectOverlay.Enabled = False ' Prevents it from blocking your clicks
        Me.Controls.Add(picEffectOverlay)
    End Sub

    Private Sub SetupHoverEffects()
        Dim buttons As PictureBox() = {picAttack1, picAttack2, picAttack3, picItem1, picItem2, picItem3}
        For Each btn In buttons
            Dim targetBtn = btn
            AddHandler targetBtn.MouseEnter, Sub() targetBtn.BackColor = Color.FromArgb(100, 255, 255, 255)
            AddHandler targetBtn.MouseLeave, Sub() targetBtn.BackColor = Color.Transparent
        Next
    End Sub

    Private Sub LoadAssets()
        Dim path As String = Application.StartupPath
        SafeLoadImage(Me, IO.Path.Combine(path, "Background.jpg"), True)

        ' Characters (Strictly using .gif files)
        SafeLoadImage(picBoss, IO.Path.Combine(path, "lvl3Boss.gif"))
        SafeLoadImage(picPriest, IO.Path.Combine(path, "level3priest.gif"))

        ' UI and Items
        SafeLoadImage(picAttack1, IO.Path.Combine(path, "attack1.png"))
        SafeLoadImage(picAttack2, IO.Path.Combine(path, "attack2.png"))
        SafeLoadImage(picAttack3, IO.Path.Combine(path, "attack3.png"))
        SafeLoadImage(picItem1, IO.Path.Combine(path, "item_1.png"))
        SafeLoadImage(picItem2, IO.Path.Combine(path, "item_2.png"))
        SafeLoadImage(picItem3, IO.Path.Combine(path, "item_3.png"))

        Dim statesPath As String = IO.Path.Combine(path, "States.png")
        If IO.File.Exists(statesPath) Then
            pnlVictory.BackgroundImage = Image.FromFile(statesPath)
            pnlVictory.BackgroundImageLayout = ImageLayout.Zoom
            pnlGameOver.BackgroundImage = Image.FromFile(statesPath)
            pnlGameOver.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Sub SafeLoadImage(target As Object, filePath As String, Optional isBackground As Boolean = False)
        If IO.File.Exists(filePath) Then
            If isBackground Then
                CType(target, Form).BackgroundImage = Image.FromFile(filePath)
                CType(target, Form).BackgroundImageLayout = ImageLayout.Stretch
            Else
                CType(target, PictureBox).Image = Image.FromFile(filePath)
            End If
        End If
    End Sub

    ' ---------------- EFFECT ANIMATION ENGINE ----------------
    Private Sub PlayEffectOverlay(baseFileName As String, targetBox As PictureBox)
        effectFrames.Clear()

        ' Loop to load frames 1 through 8
        For i As Integer = 1 To 8
            Dim framePath As String = IO.Path.Combine(Application.StartupPath, $"{baseFileName} ({i}).png")
            If IO.File.Exists(framePath) Then
                effectFrames.Add(Image.FromFile(framePath))
            End If
        Next

        If effectFrames.Count > 0 Then
            ' Center the effect over the specific character (Boss or Priest)
            picEffectOverlay.Size = targetBox.Size
            picEffectOverlay.Location = targetBox.Location
            picEffectOverlay.Image = effectFrames(0)
            picEffectOverlay.Visible = True
            picEffectOverlay.BringToFront()

            currentEffectFrame = 0
            tmrEffectAnim.Start()
        End If
    End Sub

    Private Sub tmrEffectAnim_Tick(sender As Object, e As EventArgs) Handles tmrEffectAnim.Tick
        currentEffectFrame += 1
        If currentEffectFrame < effectFrames.Count Then
            ' Move to the next frame in the sequence
            picEffectOverlay.Image = effectFrames(currentEffectFrame)
        Else
            ' Animation finished
            tmrEffectAnim.Stop()
            picEffectOverlay.Visible = False
            picEffectOverlay.Image = Nothing
            effectFrames.Clear()
        End If
    End Sub

    ' ---------------- BATTLE LOGIC ----------------
    Private Sub ExecutePlayerAttack(baseDmg As Integer, hitChance As Integer, attackName As String, effectName As String)
        If Not isPlayerTurn OrElse pnlVictory.Visible OrElse pnlGameOver.Visible Then Return

        ' Play the spell effect over the boss
        PlayEffectOverlay(effectName, picBoss)

        If rnd.Next(1, 101) <= hitChance Then
            Dim finalDmg As Integer = baseDmg
            If isCritNext Then
                finalDmg *= 2
                isCritNext = False
                lblStatus.Text = $"CRITICAL HIT! {attackName} dealt {finalDmg} damage!"
            Else
                lblStatus.Text = $"You used {attackName}! Dealt {finalDmg} damage."
            End If
            bossHP = Math.Max(0, bossHP - finalDmg)
        Else
            lblStatus.Text = $"{attackName} missed!"
            isCritNext = False
        End If

        UpdateHPBars()
        If CheckWinLoss() Then Return
        EndPlayerTurn()
    End Sub

    Private Sub picAttack1_Click(sender As Object, e As EventArgs) Handles picAttack1.Click
        ExecutePlayerAttack(15, 100, "Light Attack", "normal attack")
    End Sub

    Private Sub picAttack2_Click(sender As Object, e As EventArgs) Handles picAttack2.Click
        ExecutePlayerAttack(30, 70, "Heavy Attack", "Heavy")
    End Sub

    Private Sub picAttack3_Click(sender As Object, e As EventArgs) Handles picAttack3.Click
        ExecutePlayerAttack(60, 40, "Ultimate Attack", "Ultimate")
    End Sub

    Private Sub picItem1_Click(sender As Object, e As EventArgs) Handles picItem1.Click
        If Not isPlayerTurn OrElse itemsUsed(0) Then Return
        ' Play the Attack Boost effect over the priest
        PlayEffectOverlay("attack boost", picPriest)

        isCritNext = True
        itemsUsed(0) = True
        picItem1.Enabled = False
        picItem1.Image = Nothing
        lblStatus.Text = "Used Attack Buff! Next attack is a guaranteed Critical."
        EndPlayerTurn()
    End Sub

    Private Sub picItem2_Click(sender As Object, e As EventArgs) Handles picItem2.Click
        If Not isPlayerTurn OrElse itemsUsed(1) Then Return
        ' Play the Healing effect over the priest
        PlayEffectOverlay("healing", picPriest)

        playerHP = Math.Min(playerMaxHP, playerHP + 40)
        itemsUsed(1) = True
        picItem2.Enabled = False
        picItem2.Image = Nothing
        lblStatus.Text = "Used Heal! Recovered 40 HP."
        UpdateHPBars()
        EndPlayerTurn()
    End Sub

    Private Sub picItem3_Click(sender As Object, e As EventArgs) Handles picItem3.Click
        If Not isPlayerTurn OrElse itemsUsed(2) Then Return
        ' Play the Shield effect over the priest
        PlayEffectOverlay("Shield", picPriest)

        isDefending = True
        itemsUsed(2) = True
        picItem3.Enabled = False
        picItem3.Image = Nothing
        lblStatus.Text = "Used Shield! Next attack will be blocked."
        EndPlayerTurn()
    End Sub

    Private Sub EndPlayerTurn()
        isPlayerTurn = False
        tmrBoss.Start()
    End Sub

    Private Sub tmrBoss_Tick(sender As Object, e As EventArgs) Handles tmrBoss.Tick
        tmrBoss.Stop()

        Dim attackRoll As Integer = rnd.Next(1, 101)
        Dim bossDmg As Integer = 0
        Dim bossAtkName As String = ""

        If attackRoll <= 50 Then
            bossDmg = 12
            bossAtkName = "Shadow Bolt"
        ElseIf attackRoll <= 85 Then
            bossDmg = 25
            bossAtkName = "Demonic Cleave"
        Else
            bossDmg = 45
            bossAtkName = "Annihilation Beam"
        End If

        If isDefending Then
            lblStatus.Text = $"Boss used {bossAtkName}, but your Shield blocked it!"
            isDefending = False
        Else
            playerHP = Math.Max(0, playerHP - bossDmg)
            lblStatus.Text = $"Boss used {bossAtkName}! You took {bossDmg} damage."
        End If

        UpdateHPBars()
        If CheckWinLoss() Then Return

        isPlayerTurn = True
    End Sub

    Private Sub UpdateHPBars()
        pbPlayerHP.Value = playerHP
        lblPlayerHP.Text = $"Priest HP: {playerHP}/{playerMaxHP}"
        pbBossHP.Value = bossHP
        lblBossHP.Text = $"Boss HP: {bossHP}/{bossMaxHP}"
    End Sub

    Private Function CheckWinLoss() As Boolean
        If bossHP <= 0 Then
            tmrBoss.Stop()
            lblStatus.Text = "VICTORY! The Arcane Vault is safe!"
            lblStatus.ForeColor = Color.Lime
            pnlVictory.Visible = True
            Return True
        ElseIf playerHP <= 0 Then
            tmrBoss.Stop()
            lblStatus.Text = "GAME OVER. The Boss defeated you."
            lblStatus.ForeColor = Color.Red
            pnlGameOver.Visible = True
            Return True
        End If
        Return False
    End Function

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        playerHP = playerMaxHP
        bossHP = bossMaxHP
        isPlayerTurn = True
        isDefending = False
        isCritNext = False
        itemsUsed = {False, False, False}

        picItem1.Enabled = True
        picItem2.Enabled = True
        picItem3.Enabled = True

        pnlGameOver.Visible = False
        lblStatus.ForeColor = Color.White
        lblStatus.Text = "The Final Boss appears! Your turn."

        LoadAssets()
        UpdateHPBars()
    End Sub

    Private Sub btnNextLevel_Click(sender As Object, e As EventArgs) Handles btnNextLevel.Click
        Me.Close()
    End Sub
End Class
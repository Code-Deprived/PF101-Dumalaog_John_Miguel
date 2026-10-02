Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports System.IO

<System.Runtime.Versioning.SupportedOSPlatform("windows")>
Partial Public Class MidtermProjectAnimationForm
    ' --- GAME LOGIC VARIABLES ---
    Private isBoatOnLeft As Boolean = False
    Private isAnimating As Boolean = False
    Private isGameOver As Boolean = False
    Private timeLeft As Integer = 60
    Private WithEvents gameTimer As New Timer() With {.Interval = 1000}

    ' --- CHARACTER BOX SIZE ---
    Private Const CharW As Integer = 70
    Private Const CharH As Integer = 70

    ' --- ANIMATION VARIABLES ---
    Private priestIdleFrames As Image()
    Private devilIdleFrames As Image()
    Private priestDeathFrames As Image()
    Private devilStabbingFrames As Image()
    Private priestJumpFrames As Image()
    Private devilJumpFrames As Image()

    Private devilIdleFramesFlipped As Image()
    Private devilStabFramesFlipped As Image()
    Private devilJumpFramesFlipped As Image()

    Private Const devilDefaultFacesLeft As Boolean = False
    Private ReadOnly FightBoxSize As Size = New Size(CharW, CharH)

    Private currentIdleFrame As Integer = 0
    Private currentDeathFrame As Integer = 0
    Private currentApproachFrame As Integer = 0
    Private losingShore As FlowLayoutPanel

    Private WithEvents tmrIdle As New Timer() With {.Interval = 150}
    Private WithEvents tmrDeath As New Timer() With {.Interval = 150}

    ' --- JUMP ENGINE ---
    Private WithEvents tmrJump As New Timer() With {.Interval = 25}
    Private isJumping As Boolean = False
    Private jumpPic As PictureBox
    Private jumpTargetPanel As FlowLayoutPanel
    Private jumpDest As Point
    Private activeJumpFrames As Image()
    Private jumpFrameIndex As Integer = 0
    Private jumpTickCounter As Integer = 0

    ' --- PARABOLIC JUMP ARC ---
    Private jumpStartX As Integer
    Private jumpStartY As Integer
    Private jumpProgress As Double = 0.0

    ' --- DEVIL-APPROACHES-PRIEST ENGINE ---
    Private WithEvents tmrApproach As New Timer() With {.Interval = 20}
    Private atkPic As PictureBox
    Private vicPic As PictureBox
    Private approachDestX As Integer
    Private atkFacesRight As Boolean

    Private allCharacters As New List(Of PictureBox)

    Private Sub MidtermProjectAnimationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.DoubleBuffered = True

        FixLayoutSizes()
        LoadImages()
        InitializeLevel1()
    End Sub

    Private Sub FixLayoutSizes()
        flpLeftShore.WrapContents = True
        flpRightShore.WrapContents = True
        flpBoat.WrapContents = False

        flpLeftShore.Size = New Size(320, 240)
        flpRightShore.Size = New Size(320, 240)
        flpBoat.Size = New Size(150, 95)
    End Sub

    Private Sub LoadImages()
        Dim path As String = Application.StartupPath

        priestIdleFrames = LoadSpriteSheet(path, "Priest Idle", 8)
        devilIdleFrames = LoadSpriteSheet(path, "Devil Idle", 8)
        priestDeathFrames = LoadSpriteSheet(path, "Death", 8)
        devilStabbingFrames = LoadSpriteSheet(path, "Stab", 8)
        priestJumpFrames = LoadSpriteSheet(path, "Priest Jump", 8)
        devilJumpFrames = LoadSpriteSheet(path, "Devil Jump", 8)

        devilIdleFramesFlipped = devilIdleFrames.Select(Function(im) FlipClone(im)).ToArray()
        devilStabFramesFlipped = devilStabbingFrames.Select(Function(im) FlipClone(im)).ToArray()
        devilJumpFramesFlipped = devilJumpFrames.Select(Function(im) FlipClone(im)).ToArray()

        Dim bgPath As String = IO.Path.Combine(path, "background.png")
        If IO.File.Exists(bgPath) Then
            TabPage1.BackgroundImage = Image.FromFile(bgPath)
            TabPage1.BackgroundImageLayout = ImageLayout.Stretch

            flpLeftShore.BackColor = Color.Transparent
            flpRightShore.BackColor = Color.Transparent
            pnlRiver.BackColor = Color.Transparent
        End If

        Dim boatPath As String = IO.Path.Combine(path, "boat.png")
        If IO.File.Exists(boatPath) Then
            flpBoat.BackgroundImage = Image.FromFile(boatPath)
            flpBoat.BackgroundImageLayout = ImageLayout.Stretch
            flpBoat.BackColor = Color.Transparent
        End If

        ' Dynamically load your new states.png file for the panels
        Dim statesPath As String = IO.Path.Combine(path, "states.png")
        If IO.File.Exists(statesPath) Then
            Dim statesImg = Image.FromFile(statesPath)
            pnlVictory.BackgroundImage = statesImg
            pnlVictory.BackgroundImageLayout = ImageLayout.Zoom
            pnlGameOver.BackgroundImage = statesImg
            pnlGameOver.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Function LoadSpriteSheet(folderPath As String, prefix As String, frameCount As Integer) As Image()
        Dim frames As New List(Of Image)
        For i As Integer = 1 To frameCount
            frames.Add(Image.FromFile(IO.Path.Combine(folderPath, $"{prefix} {i}.png")))
        Next
        Return frames.ToArray()
    End Function

    Private Function FlipClone(img As Image) As Image
        Dim clone = CType(img.Clone(), Image)
        clone.RotateFlip(RotateFlipType.RotateNoneFlipX)
        Return clone
    End Function

    Private Function DevilFrame(normalArr As Image(), flippedArr As Image(), frameIndex As Integer, faceRight As Boolean) As Image
        Dim normalFacesRight As Boolean = Not devilDefaultFacesLeft
        Dim arr = If(faceRight = normalFacesRight, normalArr, flippedArr)
        Return arr(frameIndex Mod arr.Length)
    End Function

    Private Sub ApplyScaledFrame(pic As PictureBox, img As Image, boxSize As Size)
        Dim centerX As Integer = pic.Left + pic.Width \ 2
        Dim bottomY As Integer = pic.Top + pic.Height

        pic.SizeMode = PictureBoxSizeMode.Zoom
        pic.Size = boxSize
        pic.Left = centerX - boxSize.Width \ 2
        pic.Top = bottomY - boxSize.Height
        pic.Image = img
    End Sub

    Private Sub InitializeLevel1()
        flpLeftShore.Controls.Clear()
        flpRightShore.Controls.Clear()
        flpBoat.Controls.Clear()
        allCharacters.Clear()

        For i As Integer = 1 To 6
            Dim pic As New PictureBox() With {
                .Size = New Size(CharW, CharH),
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Cursor = Cursors.Hand,
                .Margin = New Padding(2, 5, 2, 0),
                .BackColor = Color.Transparent
            }

            If i <= 3 Then
                pic.Image = priestIdleFrames(0)
                pic.Tag = "Priest"
            Else
                pic.Image = devilIdleFrames(0)
                pic.Tag = "Devil"
            End If

            AddHandler pic.Click, AddressOf Character_Click_Handler
            flpRightShore.Controls.Add(pic)
            allCharacters.Add(pic)
        Next

        ResetGame()
    End Sub

    Private Sub ResetGame(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnReset1.Click
        gameTimer.Stop()
        tmrBoat.Stop()
        tmrDeath.Stop()
        tmrApproach.Stop()
        tmrIdle.Start()

        ' Hide Panels on Reset
        pnlGameOver.Visible = False
        pnlVictory.Visible = False

        isAnimating = False
        isGameOver = False
        isJumping = False
        isBoatOnLeft = False
        timeLeft = 60
        currentDeathFrame = 0
        currentApproachFrame = 0
        atkPic = Nothing
        vicPic = Nothing

        For Each c As PictureBox In allCharacters
            If c.Parent IsNot flpRightShore Then
                c.Parent?.Controls.Remove(c)
                flpRightShore.Controls.Add(c)
            End If

            c.Visible = True
            c.SizeMode = PictureBoxSizeMode.Zoom
            c.Size = New Size(CharW, CharH)
            c.Image = If(c.Tag.ToString() = "Priest", priestIdleFrames(0), devilIdleFrames(0))
        Next

        flpBoat.Left = pnlRiver.Width - flpBoat.Width - 10
        btnMoveBoat.Enabled = True
        lblGame1Status.Text = $"Time Left  {timeLeft}"
        lblGame1Status.ForeColor = Color.White

        gameTimer.Start()
    End Sub

    Private Sub Character_Click_Handler(sender As Object, e As EventArgs)
        If isAnimating OrElse isGameOver OrElse timeLeft <= 0 OrElse isJumping Then Return
        Dim pic = CType(sender, PictureBox)
        Dim targetPanel As FlowLayoutPanel = Nothing

        If pic.Parent Is flpBoat Then
            targetPanel = If(isBoatOnLeft, flpLeftShore, flpRightShore)
        Else
            Dim correctBank = If(isBoatOnLeft, flpLeftShore, flpRightShore)
            If pic.Parent Is correctBank Then
                If flpBoat.Controls.Count < 2 Then
                    targetPanel = flpBoat
                Else
                    MessageBox.Show("The boat can only hold 2 people!", "Boat Full")
                    Return
                End If
            End If
        End If

        If targetPanel IsNot Nothing Then
            StartJump(pic, targetPanel)
        End If
    End Sub

    Private Sub StartJump(pic As PictureBox, target As FlowLayoutPanel)
        If isJumping OrElse pic Is Nothing OrElse target Is Nothing OrElse pic.Parent Is Nothing Then
            Exit Sub
        End If

        isJumping = True
        jumpPic = pic
        jumpTargetPanel = target
        jumpTickCounter = 0

        Dim startScreenPt = pic.Parent.PointToScreen(pic.Location)
        Dim startLoc = TabPage1.PointToClient(startScreenPt)
        Dim destScreenPt = target.PointToScreen(New Point(target.Width \ 2, target.Height \ 2))
        jumpDest = TabPage1.PointToClient(destScreenPt)

        jumpDest.X -= (CharW \ 2)
        jumpDest.Y -= (CharH \ 2)

        jumpStartX = startLoc.X
        jumpStartY = startLoc.Y
        jumpProgress = 0.0

        pic.Parent.Controls.Remove(pic)
        TabPage1.Controls.Add(pic)

        pic.Location = startLoc
        pic.Size = New Size(CharW, CharH)
        pic.SizeMode = PictureBoxSizeMode.Zoom
        pic.BringToFront()

        Dim isJumpingRight As Boolean = jumpDest.X > startLoc.X

        If pic.Tag.ToString() = "Priest" Then
            activeJumpFrames = priestJumpFrames
        Else
            activeJumpFrames = If(isJumpingRight, devilJumpFrames, devilJumpFramesFlipped)
        End If

        jumpFrameIndex = 0
        pic.Image = activeJumpFrames(0)
        tmrJump.Start()
    End Sub

    Private Sub tmrJump_Tick(sender As Object, e As EventArgs) Handles tmrJump.Tick
        jumpProgress += 0.08

        If jumpProgress >= 1.0 Then
            jumpProgress = 1.0
            tmrJump.Stop()

            jumpPic.Size = New Size(CharW, CharH)
            jumpPic.SizeMode = PictureBoxSizeMode.Zoom
            TabPage1.Controls.Remove(jumpPic)
            jumpTargetPanel.Controls.Add(jumpPic)

            If jumpPic.Tag.ToString() = "Priest" Then jumpPic.Image = priestIdleFrames(currentIdleFrame)
            If jumpPic.Tag.ToString() = "Devil" Then jumpPic.Image = devilIdleFrames(currentIdleFrame)

            isJumping = False
            CheckWinLoss()
        Else
            Dim currentX As Integer = CInt(jumpStartX + (jumpDest.X - jumpStartX) * jumpProgress)
            Dim baseCurrentY As Integer = CInt(jumpStartY + (jumpDest.Y - jumpStartY) * jumpProgress)

            Dim arcHeight As Integer = 80
            Dim arcOffset As Integer = CInt(4 * arcHeight * jumpProgress * (1.0 - jumpProgress))

            jumpPic.Left = currentX
            jumpPic.Top = baseCurrentY - arcOffset

            jumpTickCounter += 1
            If jumpTickCounter Mod 3 = 0 Then
                jumpFrameIndex = (jumpFrameIndex + 1) Mod 8
                jumpPic.Image = activeJumpFrames(jumpFrameIndex)
            End If
        End If
    End Sub

    Private Sub tmrIdle_Tick(sender As Object, e As EventArgs) Handles tmrIdle.Tick
        If isGameOver Then Return

        currentIdleFrame = (currentIdleFrame + 1) Mod 8

        UpdateIdlePanel(flpLeftShore)
        UpdateIdlePanel(flpRightShore)
        UpdateIdlePanel(flpBoat)
    End Sub

    Private Sub UpdateIdlePanel(panel As FlowLayoutPanel)
        For Each ctrl As Control In panel.Controls
            If TypeOf ctrl Is PictureBox AndAlso Not ctrl.Equals(jumpPic) AndAlso Not ctrl.Equals(atkPic) AndAlso Not ctrl.Equals(vicPic) Then
                Dim p = CType(ctrl, PictureBox)
                If p.Tag.ToString() = "Priest" Then p.Image = priestIdleFrames(currentIdleFrame)
                If p.Tag.ToString() = "Devil" Then p.Image = devilIdleFrames(currentIdleFrame)
            End If
        Next
    End Sub

    Private Sub btnMoveBoat_Click(sender As Object, e As EventArgs) Handles btnMoveBoat.Click
        If isJumping OrElse flpBoat.Controls.Count = 0 Then
            MessageBox.Show("The boat needs at least 1 person to operate it!", "Cannot move")
            Return
        End If
        btnMoveBoat.Enabled = False
        isAnimating = True
        tmrBoat.Start()
    End Sub

    Private Sub tmrBoat_Tick(sender As Object, e As EventArgs) Handles tmrBoat.Tick
        Dim targetLeft As Integer = 10
        Dim targetRight As Integer = pnlRiver.Width - flpBoat.Width - 10
        Dim speed As Integer = 10

        If isBoatOnLeft Then
            flpBoat.Left += speed
            If flpBoat.Left >= targetRight Then
                flpBoat.Left = targetRight
                EndAnimation(False)
            End If
        Else
            flpBoat.Left -= speed
            If flpBoat.Left <= targetLeft Then
                flpBoat.Left = targetLeft
                EndAnimation(True)
            End If
        End If
    End Sub

    Private Sub EndAnimation(newLeftState As Boolean)
        tmrBoat.Stop()
        isAnimating = False
        isBoatOnLeft = newLeftState
        btnMoveBoat.Enabled = True
        CheckWinLoss()
    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        timeLeft -= 1
        lblGame1Status.Text = $"Time Left  {timeLeft}"

        If timeLeft <= 10 Then lblGame1Status.ForeColor = Color.Red

        If timeLeft <= 0 Then
            gameTimer.Stop()
            isGameOver = True
            btnMoveBoat.Enabled = False

            pnlGameOver.Visible = True
            pnlGameOver.BringToFront()
        End If
    End Sub

    Private Sub CheckWinLoss()
        Dim leftPriests = CountType(flpLeftShore, "Priest") + If(isBoatOnLeft, CountType(flpBoat, "Priest"), 0)
        Dim leftDevils = CountType(flpLeftShore, "Devil") + If(isBoatOnLeft, CountType(flpBoat, "Devil"), 0)

        Dim rightPriests = CountType(flpRightShore, "Priest") + If(Not isBoatOnLeft, CountType(flpBoat, "Priest"), 0)
        Dim rightDevils = CountType(flpRightShore, "Devil") + If(Not isBoatOnLeft, CountType(flpBoat, "Devil"), 0)

        If (leftDevils > leftPriests AndAlso leftPriests > 0) Then
            TriggerGameOver(flpLeftShore)
            Return
        ElseIf (rightDevils > rightPriests AndAlso rightPriests > 0) Then
            TriggerGameOver(flpRightShore)
            Return
        End If

        If flpLeftShore.Controls.Count = 6 Then
            gameTimer.Stop()
            tmrIdle.Stop()
            isGameOver = True
            btnMoveBoat.Enabled = False
            lblGame1Status.ForeColor = Color.Lime

            pnlVictory.Visible = True
            pnlVictory.BringToFront()
        End If
    End Sub

    Private Sub TriggerGameOver(shoreThatLost As FlowLayoutPanel)
        gameTimer.Stop()
        tmrIdle.Stop()
        isGameOver = True
        btnMoveBoat.Enabled = False

        If isBoatOnLeft AndAlso shoreThatLost Is flpLeftShore Then EmptyBoatTo(flpLeftShore)
        If Not isBoatOnLeft AndAlso shoreThatLost Is flpRightShore Then EmptyBoatTo(flpRightShore)

        losingShore = shoreThatLost

        vicPic = Nothing
        atkPic = Nothing
        For Each ctrl As Control In losingShore.Controls
            Dim p = TryCast(ctrl, PictureBox)
            If p Is Nothing Then Continue For
            If vicPic Is Nothing AndAlso p.Tag.ToString() = "Priest" Then vicPic = p
            If atkPic Is Nothing AndAlso p.Tag.ToString() = "Devil" Then atkPic = p
        Next

        If vicPic Is Nothing OrElse atkPic Is Nothing Then
            pnlGameOver.Visible = True
            pnlGameOver.BringToFront()
            Return
        End If

        StartApproach()
    End Sub

    Private Sub EmptyBoatTo(panel As FlowLayoutPanel)
        Dim chars = flpBoat.Controls.Cast(Of Control)().ToList()
        For Each c In chars
            panel.Controls.Add(c)
        Next
    End Sub

    Private Sub StartApproach()
        Dim atkScreenPt = atkPic.Parent.PointToScreen(atkPic.Location)
        Dim atkLoc = TabPage1.PointToClient(atkScreenPt)
        Dim vicScreenPt = vicPic.Parent.PointToScreen(vicPic.Location)
        Dim vicLoc = TabPage1.PointToClient(vicScreenPt)

        atkPic.Parent.Controls.Remove(atkPic)
        vicPic.Parent.Controls.Remove(vicPic)
        TabPage1.Controls.Add(vicPic)
        TabPage1.Controls.Add(atkPic)
        vicPic.Location = vicLoc
        atkPic.Location = atkLoc
        vicPic.BringToFront()
        atkPic.BringToFront()

        Const gap As Integer = 36
        Dim approachingFromLeft As Boolean = atkLoc.X <= vicLoc.X
        atkFacesRight = approachingFromLeft

        If approachingFromLeft Then
            approachDestX = vicPic.Left - atkPic.Width - gap
        Else
            approachDestX = vicPic.Right + gap
        End If

        atkPic.Top = vicPic.Top

        currentApproachFrame = 0
        atkPic.Image = DevilFrame(devilIdleFrames, devilIdleFramesFlipped, 0, atkFacesRight)

        lblGame1Status.Text = "The Devils Attack!"
        lblGame1Status.ForeColor = Color.Red

        tmrApproach.Start()
    End Sub

    Private Sub tmrApproach_Tick(sender As Object, e As EventArgs) Handles tmrApproach.Tick
        Dim speed As Integer = 6
        Dim dx As Integer = approachDestX - atkPic.Left

        If Math.Abs(dx) <= speed Then
            atkPic.Left = approachDestX
            tmrApproach.Stop()

            currentDeathFrame = 0
            tmrDeath.Start()
        Else
            atkPic.Left += Math.Sign(dx) * speed
            currentApproachFrame = (currentApproachFrame + 1) Mod 8
            atkPic.Image = DevilFrame(devilIdleFrames, devilIdleFramesFlipped, currentApproachFrame, atkFacesRight)
        End If
    End Sub

    Private Sub tmrDeath_Tick(sender As Object, e As EventArgs) Handles tmrDeath.Tick
        If currentDeathFrame >= 8 Then
            tmrDeath.Stop()
            pnlGameOver.Visible = True
            pnlGameOver.BringToFront()
            Return
        End If

        If vicPic IsNot Nothing Then
            ApplyScaledFrame(vicPic, priestDeathFrames(currentDeathFrame), FightBoxSize)
        End If

        If atkPic IsNot Nothing Then
            Dim stabImg = DevilFrame(devilStabbingFrames, devilStabFramesFlipped, currentDeathFrame, atkFacesRight)
            ApplyScaledFrame(atkPic, stabImg, FightBoxSize)
        End If

        currentDeathFrame += 1
    End Sub

    Private Function CountType(container As FlowLayoutPanel, tagType As String) As Integer
        Dim count As Integer = 0
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is PictureBox AndAlso ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString() = tagType Then
                count += 1
            End If
        Next
        Return count
    End Function

    ' --- NEW PANEL BUTTON HANDLERS ---
    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        ResetGame()
    End Sub

    Private Sub btnNextLevel_Click(sender As Object, e As EventArgs) Handles btnNextLevel.Click
        Dim level2 As New Level2Form()

        ' This tells the hidden Level 1 form to close completely when Level 2 is closed
        AddHandler level2.FormClosed, Sub(s, args) Me.Close()

        level2.Show()
        Me.Hide()
    End Sub
End Class
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Linq
Imports System.Collections.Generic

<System.Runtime.Versioning.SupportedOSPlatform("windows")>
Public Class Level2Form
    ' --- GAME VARIABLES ---
    Private cardImages As New Dictionary(Of String, Image)
    Private cardBackImg As Image
    Private gridCards As New List(Of String)
    Private pictureBoxes As New List(Of PictureBox)

    Private firstClicked As PictureBox = Nothing
    Private secondClicked As PictureBox = Nothing
    Private matchesFound As Integer = 0
    Private timeLeft As Integer = 45 ' 45 seconds to solve

    ' --- TIMERS ---
    Private WithEvents flipTimer As New Timer() With {.Interval = 800} ' 0.8s delay before flipping back
    Private WithEvents gameTimer As New Timer() With {.Interval = 1000}

    Private Sub Level2Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.DoubleBuffered = True

        LoadAssets()
        InitializeGame()
    End Sub

    Private Sub LoadAssets()
        Dim path As String = Application.StartupPath

        ' Load Background
        Dim bgPath As String = IO.Path.Combine(path, "level2_bg.png")
        If IO.File.Exists(bgPath) Then
            Me.BackgroundImage = Image.FromFile(bgPath)
            Me.BackgroundImageLayout = ImageLayout.Stretch
        End If

        ' Load Timer Icon
        Dim timerIconPath As String = IO.Path.Combine(path, "icon_timer.png")
        If IO.File.Exists(timerIconPath) Then
            picTimerIcon.Image = Image.FromFile(timerIconPath)
        End If

        ' Load Panels
        Dim statesPath As String = IO.Path.Combine(path, "States.png")
        If IO.File.Exists(statesPath) Then
            Dim statesImg = Image.FromFile(statesPath)
            pnlVictory.BackgroundImage = statesImg
            pnlGameOver.BackgroundImage = statesImg
        End If

        ' Load Card Back
        Dim backPath As String = IO.Path.Combine(path, "card_back.png")
        If IO.File.Exists(backPath) Then cardBackImg = Image.FromFile(backPath)

        ' Load Card Faces into a Dictionary to save memory
        Dim cardNames As String() = {"card_skull", "card_sword", "card_potion", "card_crown", "card_moon", "card_horn"}

        ' FIX: Changed loop variable from 'name' to 'cardName'
        For Each cardName As String In cardNames
            Dim cardPath As String = IO.Path.Combine(path, cardName & ".png")
            If IO.File.Exists(cardPath) Then
                cardImages.Add(cardName, Image.FromFile(cardPath))
            End If
        Next
    End Sub

    Private Sub InitializeGame()
        ' Reset UI
        pnlVictory.Visible = False
        pnlGameOver.Visible = False
        lblTimer.Text = "45"
        lblTimer.ForeColor = Color.White
        timeLeft = 45
        matchesFound = 0
        firstClicked = Nothing
        secondClicked = Nothing
        pnlGrid.Controls.Clear()
        pictureBoxes.Clear()
        gridCards.Clear()

        ' Prepare 12 cards (2 of each unique card)
        Dim cardNames As String() = {"card_skull", "card_sword", "card_potion", "card_crown", "card_moon", "card_horn"}
        For Each cardName As String In cardNames
            gridCards.Add(cardName)
            gridCards.Add(cardName)
        Next

        ' Shuffle the cards randomly
        Dim rnd As New Random()
        gridCards = gridCards.OrderBy(Function(x) rnd.Next()).ToList()

        ' Grid layout settings - SCALED DOWN TO GUARANTEE FIT
        Dim colCount As Integer = 4
        Dim rowCount As Integer = 3
        Dim cardW As Integer = 70  ' Reduced from 85
        Dim cardH As Integer = 100 ' Reduced from 120
        Dim spacing As Integer = 12 ' Reduced from 15

        ' Force exact panel dimensions and turn OFF AutoSize
        pnlGrid.AutoSize = False
        pnlGrid.Width = (colCount * cardW) + ((colCount - 1) * spacing)
        pnlGrid.Height = (rowCount * cardH) + ((rowCount - 1) * spacing)

        ' Center the panel horizontally and move it up slightly higher on the screen
        pnlGrid.Left = (Me.ClientSize.Width - pnlGrid.Width) \ 2
        pnlGrid.Top = 110

        ' Generate all 12 cards
        For i As Integer = 0 To gridCards.Count - 1
            Dim row As Integer = i \ colCount
            Dim col As Integer = i Mod colCount

            Dim pic As New PictureBox() With {
                .Width = cardW,
                .Height = cardH,
                .Left = col * (cardW + spacing),
                .Top = row * (cardH + spacing),
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Image = cardBackImg,
                .Tag = gridCards(i),
                .Cursor = Cursors.Hand,
                .BackColor = Color.Transparent
            }

            AddHandler pic.Click, AddressOf Card_Click
            pnlGrid.Controls.Add(pic)
            pictureBoxes.Add(pic)
        Next

        gameTimer.Start()
    End Sub

    Private Sub Card_Click(sender As Object, e As EventArgs)
        ' Prevent clicking if waiting for cards to flip back, or if game is over
        If flipTimer.Enabled OrElse pnlGameOver.Visible OrElse pnlVictory.Visible Then Return

        Dim clickedPic As PictureBox = CType(sender, PictureBox)

        ' Ignore if already flipped
        If clickedPic.Image IsNot cardBackImg Then Return

        ' Reveal the card
        Dim cardId As String = clickedPic.Tag.ToString()
        If cardImages.ContainsKey(cardId) Then
            clickedPic.Image = cardImages(cardId)
        End If

        ' Logic for First and Second click
        If firstClicked Is Nothing Then
            firstClicked = clickedPic
        Else
            secondClicked = clickedPic
            CheckForMatch()
        End If
    End Sub

    Private Sub CheckForMatch()
        If firstClicked.Tag.ToString() = secondClicked.Tag.ToString() Then
            ' It's a match!
            matchesFound += 1
            firstClicked = Nothing
            secondClicked = Nothing

            ' Check Win Condition
            If matchesFound = 6 Then
                gameTimer.Stop()
                pnlVictory.Visible = True
                pnlVictory.BringToFront()
            End If
        Else
            ' Not a match, start timer to flip them back
            flipTimer.Start()
        End If
    End Sub

    Private Sub flipTimer_Tick(sender As Object, e As EventArgs) Handles flipTimer.Tick
        flipTimer.Stop()
        ' Revert to card backs
        firstClicked.Image = cardBackImg
        secondClicked.Image = cardBackImg
        firstClicked = Nothing
        secondClicked = Nothing
    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        timeLeft -= 1
        lblTimer.Text = timeLeft.ToString()

        If timeLeft <= 10 Then lblTimer.ForeColor = Color.Red

        If timeLeft <= 0 Then
            gameTimer.Stop()
            pnlGameOver.Visible = True
            pnlGameOver.BringToFront()
        End If
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        InitializeGame()
    End Sub

    Private Sub btnNextLevel_Click(sender As Object, e As EventArgs) Handles btnNextLevel.Click
        Dim level3 As New Level3Form()
        AddHandler level3.FormClosed, Sub(s, args) Me.Close()
        level3.Show()
        Me.Hide()
    End Sub
End Class
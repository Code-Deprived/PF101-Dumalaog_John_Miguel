Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq ' Advanced: Enables LINQ for Summing/Averaging arrays

Public Class Week7Form
    Inherits BaseLessonForm

    ' ==========================================
    ' TOPIC 1: 1D ARRAY (IMPLICIT INITIALIZATION)
    ' ==========================================
    ' The module states an array can be implicitly sized when initialized[cite: 17].
    Private inventory() As String = {"Zenith", "Terra Blade", "Meowmere", "Star Wrath"}

    ' ==========================================
    ' TOPIC 2: PARALLEL ARRAYS
    ' ==========================================
    ' Managing two arrays where the indices correlate to the same entity[cite: 17].
    Private enemyNames() As String = {"Slime", "Zombie", "Eye of Cthulhu"}
    Private enemyHP() As Integer = {50, 100, 2800}

    ' ==========================================
    ' TOPIC 3: 2D ARRAYS & NAMED CONSTANTS
    ' ==========================================
    ' Using named constants as subscripts allows sizes to be changed in one place[cite: 17].
    Private Const CHEST_ROWS As Integer = 1 ' Subscript 1 = 2 elements (0 and 1)[cite: 17]
    Private Const CHEST_COLS As Integer = 2 ' Subscript 2 = 3 elements (0, 1, 2)[cite: 17]
    Private chestGrid(CHEST_ROWS, CHEST_COLS) As String

    ' UI Controls
    Private pnlInventory As New DoubleBufferedPanel()
    Private lstInventory As New ListBox()
    Private txtNewItem As New TextBox()

    Private pnlParallel As New DoubleBufferedPanel()
    Private lstStats As New ListBox()

    Private pnlChest As New DoubleBufferedPanel()
    Private flpChest As New FlowLayoutPanel()

    Private Sub Week7Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Week 7: Array Manipulation"
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Clear()
            InitializeInventoryUI()
            InitializeParallelUI()
            InitializeChestUI()
            InitializeLessonText()
        End If

        ' Populate default chest data
        chestGrid(0, 0) = "Wood"
        chestGrid(0, 1) = "Iron Bar"
        chestGrid(0, 2) = "Gel"
        chestGrid(1, 0) = "Gold Coin"
        chestGrid(1, 1) = "Torch"
        chestGrid(1, 2) = "Healing Potion"

        RefreshChestGrid()
    End Sub

    ' ---------------------------------------------------
    ' 1D INVENTORY ENGINE (Sorting, ReDim, Reverse)
    ' ---------------------------------------------------
    Private Sub InitializeInventoryUI()
        pnlInventory.SetBounds(20, 20, 240, 400)
        pnlInventory.BackColor = Color.FromArgb(40, 45, 65)
        pnlInventory.BorderStyle = BorderStyle.FixedSingle

        Dim lblTitle As New Label() With {.Text = "1D Array: Inventory", .ForeColor = Color.Gold, .Location = New Point(10, 10), .AutoSize = True, .Font = GetAndyFont(14.0F, FontStyle.Bold)}

        lstInventory.SetBounds(10, 40, 215, 200)
        lstInventory.BackColor = Color.FromArgb(15, 20, 30)
        lstInventory.ForeColor = Color.Cyan
        lstInventory.Font = New Font("Consolas", 10.0F)

        txtNewItem.SetBounds(10, 250, 215, 25)
        txtNewItem.BackColor = Color.FromArgb(30, 35, 60)
        txtNewItem.ForeColor = Color.White

        Dim btnAdd As Button = CreateTerrariaButton("Add (ReDim)", 10, 280, 100, 30, Color.SeaGreen)
        Dim btnRemove As Button = CreateTerrariaButton("Remove", 125, 280, 100, 30, Color.IndianRed)
        Dim btnSort As Button = CreateTerrariaButton("Sort Array", 10, 315, 100, 30, Color.FromArgb(60, 70, 110))
        Dim btnRev As Button = CreateTerrariaButton("Reverse", 125, 315, 100, 30, Color.FromArgb(60, 70, 110))

        AddHandler btnAdd.Click, AddressOf HandleAddItem
        AddHandler btnRemove.Click, AddressOf HandleRemoveItem
        AddHandler btnSort.Click, Sub()
                                      Array.Sort(inventory) ' Advanced VB.NET built-in sorting
                                      RefreshInventory()
                                  End Sub
        AddHandler btnRev.Click, Sub()
                                     Array.Reverse(inventory) ' Advanced VB.NET built-in reversal
                                     RefreshInventory()
                                 End Sub

        pnlInventory.Controls.AddRange({lblTitle, lstInventory, txtNewItem, btnAdd, btnRemove, btnSort, btnRev})
        pnlContainer.Controls.Add(pnlInventory)
        RefreshInventory()
    End Sub

    Private Sub HandleAddItem(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNewItem.Text) Then Return
        ' ReDim Preserve resizes the array while keeping existing data[cite: 17]
        ReDim Preserve inventory(inventory.Length)
        inventory(inventory.Length - 1) = txtNewItem.Text.Trim()
        txtNewItem.Clear()
        RefreshInventory()
    End Sub

    Private Sub HandleRemoveItem(sender As Object, e As EventArgs)
        ' Check if an item is actually highlighted in the ListBox
        If lstInventory.SelectedIndex < 0 Then
            MessageBox.Show("Please click on an item in the inventory list first to select what you want to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim indexToRemove As Integer = lstInventory.SelectedIndex

        ' Convert array to a list, remove the specific item, and convert back to an array
        Dim tempList = inventory.ToList()
        tempList.RemoveAt(indexToRemove)
        inventory = tempList.ToArray()
        RefreshInventory()
    End Sub

    Private Sub RefreshInventory()
        lstInventory.Items.Clear()
        For Each item In inventory
            lstInventory.Items.Add(item)
        Next
    End Sub

    ' ---------------------------------------------------
    ' PARALLEL ARRAYS & MATH ENGINE (Sum & Average)
    ' ---------------------------------------------------
    Private Sub InitializeParallelUI()
        pnlParallel.SetBounds(270, 20, 240, 195)
        pnlParallel.BackColor = Color.FromArgb(40, 45, 65)
        pnlParallel.BorderStyle = BorderStyle.FixedSingle

        Dim lblTitle As New Label() With {.Text = "Parallel Arrays: Bestiary", .ForeColor = Color.Gold, .Location = New Point(10, 10), .AutoSize = True, .Font = GetAndyFont(14.0F, FontStyle.Bold)}

        lstStats.SetBounds(10, 40, 215, 100)
        lstStats.BackColor = Color.FromArgb(15, 20, 30)
        lstStats.ForeColor = Color.Lime
        lstStats.Font = New Font("Consolas", 10.0F)

        Dim btnCalc As Button = CreateTerrariaButton("Calculate Average HP", 10, 150, 215, 30, Color.FromArgb(100, 50, 100))
        AddHandler btnCalc.Click, AddressOf HandleMathCalculations

        pnlParallel.Controls.AddRange({lblTitle, lstStats, btnCalc})
        pnlContainer.Controls.Add(pnlParallel)

        ' Display parallel arrays
        For i As Integer = 0 To enemyNames.Length - 1
            lstStats.Items.Add($"{enemyNames(i)}: {enemyHP(i)} HP")
        Next
    End Sub

    Private Sub HandleMathCalculations(sender As Object, e As EventArgs)
        ' Summing and averaging array elements is a core module technique[cite: 17]
        ' Advanced: Using LINQ extension methods to calculate cleanly
        Dim totalHP As Integer = enemyHP.Sum()
        Dim avgHP As Double = enemyHP.Average()
        MessageBox.Show($"Total HP of all enemies: {totalHP}{vbCrLf}Average HP per enemy: {Math.Round(avgHP, 2)}", "Array Math", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ---------------------------------------------------
    ' 2D ARRAY ENGINE (Chest Grid)
    ' ---------------------------------------------------
    Private Sub InitializeChestUI()
        pnlChest.SetBounds(270, 225, 240, 195)
        pnlChest.BackColor = Color.FromArgb(40, 45, 65)
        pnlChest.BorderStyle = BorderStyle.FixedSingle

        Dim lblTitle As New Label() With {.Text = "2D Array: Chest Grid", .ForeColor = Color.Gold, .Location = New Point(10, 10), .AutoSize = True, .Font = GetAndyFont(14.0F, FontStyle.Bold)}

        flpChest.SetBounds(10, 40, 215, 140)
        flpChest.BackColor = Color.FromArgb(15, 20, 30)

        pnlChest.Controls.AddRange({lblTitle, flpChest})
        pnlContainer.Controls.Add(pnlChest)
    End Sub

    Private Sub RefreshChestGrid()
        flpChest.Controls.Clear()
        ' Iterating through a multidimensional array (rows and columns)[cite: 17]
        For r As Integer = 0 To CHEST_ROWS
            For c As Integer = 0 To CHEST_COLS
                Dim slotName As String = chestGrid(r, c)
                Dim btnSlot As New Button() With {
                    .Size = New Size(65, 60),
                    .BackColor = Color.FromArgb(70, 75, 95),
                    .ForeColor = Color.White,
                    .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
                    .FlatStyle = FlatStyle.Flat,
                    .Text = $"[{r},{c}]{vbCrLf}{slotName}",
                    .Cursor = Cursors.Hand
                }
                btnSlot.FlatAppearance.BorderColor = Color.Gold

                ' Capture loop variables for Lambda scope
                Dim captureR As Integer = r
                Dim captureC As Integer = c

                AddHandler btnSlot.Click, Sub()
                                              Dim newItem As String = InputBox($"Enter new item for Chest Slot ({captureR}, {captureC}):", "Update 2D Array", chestGrid(captureR, captureC))
                                              If Not String.IsNullOrWhiteSpace(newItem) Then
                                                  chestGrid(captureR, captureC) = newItem
                                                  RefreshChestGrid()
                                              End If
                                          End Sub
                flpChest.Controls.Add(btnSlot)
            Next
        Next
    End Sub

    ' ---------------------------------------------------
    ' HELPER METHODS & LESSON TEXT
    ' ---------------------------------------------------
    Private Function CreateTerrariaButton(txt As String, x As Integer, y As Integer, w As Integer, h As Integer, bg As Color) As Button
        Dim btn As New Button() With {
            .Text = txt, .Location = New Point(x, y), .Size = New Size(w, h),
            .BackColor = bg, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderColor = Color.Gold
        Return btn
    End Function

    Private Sub InitializeLessonText()
        Dim txtLesson As New RichTextBox() With {
            .Size = New Size(245, 400),
            .Location = New Point(520, 20),
            .BackColor = Color.FromArgb(20, 25, 40),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 9.0F),
            .BorderStyle = BorderStyle.None,
            .ReadOnly = True
        }
        txtLesson.Text = "MODULE REVIEW: ARRAYS" & vbCrLf & vbCrLf &
                         "Arrays store multiple values of the same type under a single name[cite: 17]." & vbCrLf & vbCrLf &
                         "1D Arrays & Subscripts:" & vbCrLf &
                         "All variables within an array are called elements. You access them through a zero-indexed subscript[cite: 17]." & vbCrLf & vbCrLf &
                         "Implicit Initialization:" & vbCrLf &
                         "Upper subscript value can be left blank if elements are provided (e.g., Dim arr() As Integer = {1, 2})[cite: 17]." & vbCrLf & vbCrLf &
                         "Named Constants:" & vbCrLf &
                         "A named constant (Const) may be used as an array's highest subscript instead of a number, allowing size changes in one place[cite: 17]." & vbCrLf & vbCrLf &
                         "Parallel & Multidimensional:" & vbCrLf &
                         "A 2D array stores data in multiple sets (rows and columns). Parallel arrays manage separate arrays linked by identical subscripts to sum, average, or search data[cite: 17]."
        pnlContainer.Controls.Add(txtLesson)
    End Sub
End Class
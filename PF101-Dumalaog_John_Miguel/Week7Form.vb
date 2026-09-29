Public Class Week7Form

    ' Declare a dynamic 1D Array at the class level
    Private inventory() As String = {"Zenith", "Terra Blade"}

    Private Sub Week7Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If
        RefreshInventoryDisplay()
    End Sub

    ' --- HELPER METHOD TO DISPLAY ARRAY ---
    Private Sub RefreshInventoryDisplay()
        lstOutput.Items.Clear()
        lstOutput.Items.Add("--- Current Inventory (1D) ---")
        lstOutput.Items.Add("")

        If inventory.Length = 0 Then
            lstOutput.Items.Add("[Inventory Empty]")
        Else
            For i As Integer = 0 To inventory.Length - 1
                lstOutput.Items.Add($"Index {i}: {inventory(i)}")
            Next
        End If

        lstOutput.Items.Add("")
        lstOutput.Items.Add($"Capacity: {inventory.Length} slots")
    End Sub

    ' --- ADD ITEM (REDIM PRESERVE) ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtInput.Text) Then Return

        ' 1. Resize the array by 1, preserving existing items
        ReDim Preserve inventory(inventory.Length)

        ' 2. Add the new item to the last index
        inventory(inventory.Length - 1) = txtInput.Text.Trim()

        txtInput.Clear()
        RefreshInventoryDisplay()
        lstOutput.Items.Add("> Item Added successfully.")
    End Sub

    ' --- REMOVE ITEM (MANUAL ARRAY SHIFTING) ---
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim itemToRemove As String = txtInput.Text.Trim()
        Dim index As Integer = Array.IndexOf(inventory, itemToRemove)

        If index >= 0 Then
            ' Create a new array that is 1 size smaller
            Dim newInventory(inventory.Length - 2) As String
            Dim pos As Integer = 0

            ' Copy everything EXCEPT the item we are removing
            For i As Integer = 0 To inventory.Length - 1
                If i <> index Then
                    newInventory(pos) = inventory(i)
                    pos += 1
                End If
            Next

            ' Replace the old array with the new one
            inventory = newInventory

            txtInput.Clear()
            RefreshInventoryDisplay()
            lstOutput.Items.Add($"> '{itemToRemove}' was deleted.")
        Else
            MessageBox.Show("Item not found in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' --- SEARCH ARRAY ---
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchItem As String = txtInput.Text.Trim()
        Dim index As Integer = Array.IndexOf(inventory, searchItem)

        RefreshInventoryDisplay()
        lstOutput.Items.Add("")

        If index >= 0 Then
            lstOutput.Items.Add($"[SEARCH] '{searchItem}' found at Index {index}!")
        Else
            lstOutput.Items.Add($"[SEARCH] '{searchItem}' is not in inventory.")
        End If
    End Sub

    ' --- 2D ARRAY DEMONSTRATION ---
    Private Sub btnShow2D_Click(sender As Object, e As EventArgs) Handles btnShow2D.Click
        lstOutput.Items.Clear()
        lstOutput.Items.Add("--- Chest Grid (2D Array) ---")
        lstOutput.Items.Add("")

        ' Declare a 2x2 grid (Rows, Columns)
        Dim chestGrid(1, 1) As String
        chestGrid(0, 0) = "Wood"
        chestGrid(0, 1) = "Iron Bar"
        chestGrid(1, 0) = "Gold Coin"
        chestGrid(1, 1) = "Diamond"

        ' Iterate through the 2D array
        For row As Integer = 0 To 1
            Dim rowDisplay As String = $"Row {row}: "
            For col As Integer = 0 To 1
                rowDisplay &= $"[{chestGrid(row, col)}] "
            Next
            lstOutput.Items.Add(rowDisplay)
        Next

        lstOutput.Items.Add("")
        lstOutput.Items.Add("> Switch back to 1D by clicking Add/Search.")
    End Sub

End Class
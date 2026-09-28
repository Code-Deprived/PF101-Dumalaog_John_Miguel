Imports System.IO
Imports System.Collections.Generic

Public Class Week5Form
    ' Maintain the class-level list for the dynamic collection demo
    Private dynamicList As New List(Of String)

    Private Sub Week5Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Re-parent to the Base Form container
        If pnlContainer IsNot Nothing Then
            pnlContainer.Controls.Add(pnlInteractive)
            pnlContainer.Controls.Add(lblLesson)
            pnlInteractive.BringToFront()
            lblLesson.BringToFront()
        End If
    End Sub

    ' --- 1. Dynamic List Demo ---
    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        If txtInput.Text.Trim() <> "" Then
            dynamicList.Add(txtInput.Text)
            lblOutput.ForeColor = Color.Cyan
            lblOutput.Text = $"[List Updated]{vbCrLf}Added: {txtInput.Text}{vbCrLf}Total items in List: {dynamicList.Count}"
            txtInput.Clear()
        Else
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Error: Enter text for the List."
        End If
    End Sub

    ' --- 2. File I/O Demo ---
    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim path As String = "demo.txt"
        Try
            Dim textToSave As String = If(txtInput.Text.Trim() = "", "Default Text - No Input Provided", txtInput.Text)
            File.WriteAllText(path, textToSave)

            Dim readText As String = File.ReadAllText(path)
            lblOutput.ForeColor = Color.Yellow
            lblOutput.Text = $"[File I/O Success]{vbCrLf}Saved to {path}{vbCrLf}Read Data: '{readText}'"
        Catch ex As Exception
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = $"File Error: {ex.Message}"
        End Try
    End Sub

    ' --- 3. Dynamic Array Demo ---
    Private Sub btnArray_Click(sender As Object, e As EventArgs) Handles btnArray.Click
        Dim inputString As String = txtArray.Text.Trim()

        If String.IsNullOrWhiteSpace(inputString) Then
            lblOutput.ForeColor = Color.Tomato
            lblOutput.Text = "Error: Please enter numbers separated by commas."
            Return
        End If

        ' Split the string by commas to dynamically create an array
        Dim stringArray() As String = inputString.Split(","c)
        Dim validNumbers As New List(Of Integer)
        Dim sum As Integer = 0

        ' TryParse handles edge cases where the user accidentally types letters (e.g., "10, apple, 30")
        For Each item In stringArray
            Dim parsedNum As Integer
            If Integer.TryParse(item.Trim(), parsedNum) Then
                validNumbers.Add(parsedNum)
                sum += parsedNum
            End If
        Next

        ' Convert back to a fixed array to demonstrate array properties
        Dim finalArray() As Integer = validNumbers.ToArray()

        lblOutput.ForeColor = Color.Lime
        lblOutput.Text = $"[Array Constructed]{vbCrLf}Valid Elements Captured: {finalArray.Length}{vbCrLf}Sum calculated via loop: {sum}"
    End Sub

    ' --- 4. Dynamic Math Calculations ---
    Private Sub btnMath_Click(sender As Object, e As EventArgs) Handles btnMath.Click
        Dim baseVal As Double = CDbl(numBase.Value)
        Dim expVal As Double = CDbl(numExp.Value)

        Dim result As Double = Math.Pow(baseVal, expVal)

        lblOutput.ForeColor = Color.Cyan
        lblOutput.Text = $"[Math Calculation]{vbCrLf}Math.Pow({baseVal}, {expVal}) = {result}{vbCrLf}({baseVal} raised to the power of {expVal})"
    End Sub
End Class
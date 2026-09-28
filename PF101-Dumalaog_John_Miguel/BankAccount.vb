Public Class BankAccount
    Private balance As Decimal

    Public Sub Deposit(amount As Decimal)
        If amount > 0 Then balance += amount
    End Sub

    Public Sub Withdraw(amount As Decimal)
        If amount > 0 AndAlso amount <= balance Then balance -= amount
    End Sub

    Public Function GetBalance() As Decimal
        Return balance
    End Function
End Class
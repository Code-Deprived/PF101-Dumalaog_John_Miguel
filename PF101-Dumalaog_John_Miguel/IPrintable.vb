Public Interface IPrintable
    Function Print() As String
End Interface

Public Class Document
    Implements IPrintable
    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Document..."
    End Function
End Class
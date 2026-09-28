Public Class Animal
    Public Overridable Function Speak() As String
        Return "Animal speaks"
    End Function
End Class

Public Class Dog
    Inherits Animal
    Public Overrides Function Speak() As String
        Return "Dog barks"
    End Function
End Class
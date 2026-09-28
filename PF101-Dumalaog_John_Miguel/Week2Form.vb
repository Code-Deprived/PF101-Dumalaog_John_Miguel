Imports System.Drawing
Imports System.Windows.Forms

Public Class Week2Form
    Inherits BaseLessonForm

    ' State / OOP Instances
    Private bankAcc As New BankAccount()

    ' UI Components
    Private mainMenuStrip As New MenuStrip()
    Private pnlDemo As New Panel()
    Private pnlReviewer As New Panel()

    Private Sub Week2Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set window title
        Me.Text = "OOP(PF101) - Portfolio Created by: Dumalaog, John Miguel C."

        ' Initialize MenuStrip
        SetupMenuStrip()

        ' Position and nest pnlDemo inside the BaseLessonForm container
        pnlDemo.Location = New Point(20, 65)
        pnlDemo.Size = New Size(360, 380)
        pnlDemo.BackColor = Color.FromArgb(28, 34, 58)
        pnlContainer.Controls.Add(pnlDemo)

        ' Position and nest pnlReviewer inside the BaseLessonForm container
        pnlReviewer.Location = New Point(395, 65)
        pnlReviewer.Size = New Size(385, 380)
        pnlReviewer.BackColor = Color.FromArgb(28, 34, 58)
        pnlContainer.Controls.Add(pnlReviewer)

        ' Load default topic
        LoadSubTopic("Classes and Objects")
    End Sub

    Private Sub SetupMenuStrip()
        mainMenuStrip.BackColor = Color.Black
        mainMenuStrip.ForeColor = Color.White

        Dim mnuSBIT2A As New ToolStripMenuItem("SBIT2A")
        Dim mnuHelp As New ToolStripMenuItem("Help")
        Dim mnuExit As New ToolStripMenuItem("Exit")
        AddHandler mnuExit.Click, Sub() Me.Close()

        Dim mnuWeek2 As New ToolStripMenuItem("Week 2 - Introduction in OOP")
        Dim itemClasses As New ToolStripMenuItem("Classes and Objects", Nothing, Sub() LoadSubTopic("Classes and Objects"))
        Dim itemEncapsulation As New ToolStripMenuItem("Encapsulation", Nothing, Sub() LoadSubTopic("Encapsulation"))
        Dim itemInheritance As New ToolStripMenuItem("Inheritance", Nothing, Sub() LoadSubTopic("Inheritance"))
        Dim itemPolymorphism As New ToolStripMenuItem("Polymorphism", Nothing, Sub() LoadSubTopic("Polymorphism"))
        Dim itemInterface As New ToolStripMenuItem("Interface", Nothing, Sub() LoadSubTopic("Interface"))

        mnuWeek2.DropDownItems.AddRange({itemClasses, itemEncapsulation, itemInheritance, itemPolymorphism, itemInterface})
        mainMenuStrip.Items.AddRange({mnuSBIT2A, mnuHelp, mnuExit, mnuWeek2})

        Me.mainMenuStrip = mainMenuStrip
        Me.Controls.Add(mainMenuStrip)
    End Sub

    Public Sub LoadSubTopic(topic As String)
        pnlDemo.Controls.Clear()
        pnlReviewer.Controls.Clear()

        Select Case topic
            Case "Classes and Objects"
                BuildClassesView()
            Case "Encapsulation"
                BuildEncapsulationView()
            Case "Inheritance"
                BuildInheritanceView()
            Case "Polymorphism"
                BuildPolymorphismView()
            Case "Interface"
                BuildInterfaceView()
        End Select
    End Sub

    ' --- 1. CLASSES AND OBJECTS ---
    Private Sub BuildClassesView()
        Dim lblName As New Label() With {.Text = "Name:", .ForeColor = Color.White, .Location = New Point(15, 15), .AutoSize = True}
        Dim txtName As New TextBox() With {.Location = New Point(15, 35), .Width = 200, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.White}
        Dim lblAge As New Label() With {.Text = "Age:", .ForeColor = Color.White, .Location = New Point(15, 75), .AutoSize = True}
        Dim txtAge As New TextBox() With {.Location = New Point(15, 95), .Width = 200, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.Gray, .Text = "Enter Age (e.g., 30)"}

        AddHandler txtAge.GotFocus, Sub()
                                        If txtAge.Text = "Enter Age (e.g., 30)" Then
                                            txtAge.Text = ""
                                            txtAge.ForeColor = Color.White
                                        End If
                                    End Sub

        Dim btnPopulate As New Button() With {.Text = "Instantiate Object", .Location = New Point(15, 145), .Size = New Size(200, 45), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}

        AddHandler btnPopulate.Click, Sub()
                                          Dim p As New Person()
                                          p.Name = If(String.IsNullOrWhiteSpace(txtName.Text), "Alice (Default)", txtName.Text)
                                          Dim ageOut As Integer
                                          If Integer.TryParse(txtAge.Text, ageOut) Then
                                              p.Age = ageOut
                                          Else
                                              p.Age = 30 ' Fallback
                                          End If
                                          txtName.Text = p.Name
                                          txtAge.Text = p.Age.ToString()
                                          txtAge.ForeColor = Color.White
                                          MessageBox.Show($"Object Instantiated successfully!{vbCrLf}Name: {p.Name}{vbCrLf}Age: {p.Age}", "Classes & Objects", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                      End Sub

        pnlDemo.Controls.AddRange({lblName, txtName, lblAge, txtAge, btnPopulate})

        SetReviewerText("Classes and objects",
            "The terms class and object are sometimes used interchangeably, but in fact, classes describe the type of objects, while objects are usable instances of classes. So, the act of creating an object is called instantiation. Using the blueprint analogy, a class is a blueprint, and an object is a building made from that blueprint.",
            "Public Class Person" & vbCrLf &
            "    Public Name As String" & vbCrLf &
            "    Public Age As Integer" & vbCrLf &
            "End Class" & vbCrLf & vbCrLf &
            "Dim p As New Person()" & vbCrLf &
            "p.Name = ""Alice""" & vbCrLf &
            "p.Age = 30")
    End Sub

    ' --- 2. ENCAPSULATION ---
    Private Sub BuildEncapsulationView()
        Dim lblAmt As New Label() With {.Text = "Amount:", .ForeColor = Color.White, .Location = New Point(15, 15), .AutoSize = True}
        Dim txtAmt As New TextBox() With {.Location = New Point(15, 35), .Width = 200, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.White}
        Dim btnDep As New Button() With {.Text = "Deposit Money", .Location = New Point(15, 65), .Size = New Size(200, 30), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}
        Dim btnWith As New Button() With {.Text = "Withdraw Money", .Location = New Point(15, 100), .Size = New Size(200, 30), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}
        Dim btnReset As New Button() With {.Text = "Reset Transaction View", .Location = New Point(15, 135), .Size = New Size(200, 30), .ForeColor = Color.White, .BackColor = Color.FromArgb(80, 50, 50), .FlatStyle = FlatStyle.Flat, .Visible = False}
        Dim lblBal As New Label() With {.Text = "Current Balance:", .ForeColor = Color.White, .Location = New Point(15, 175), .AutoSize = True}
        Dim txtBal As New TextBox() With {.Location = New Point(15, 195), .Width = 200, .ReadOnly = True, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.Gray, .Text = "$0.00"}
        Dim btnCheck As New Button() With {.Text = "Check Balance", .Location = New Point(15, 230), .Size = New Size(200, 30), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}

        AddHandler btnDep.Click, Sub()
                                     Dim amt As Decimal
                                     If Decimal.TryParse(txtAmt.Text, amt) Then
                                         bankAcc.Deposit(amt)
                                         btnWith.Visible = False
                                         btnReset.Visible = True
                                         txtBal.Text = bankAcc.GetBalance().ToString("C2")
                                         txtBal.ForeColor = Color.White
                                     Else
                                         MessageBox.Show("Please enter a valid amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                     End If
                                 End Sub

        AddHandler btnWith.Click, Sub()
                                      Dim amt As Decimal
                                      If Decimal.TryParse(txtAmt.Text, amt) Then
                                          bankAcc.Withdraw(amt)
                                          btnDep.Visible = False
                                          btnReset.Visible = True
                                          txtBal.Text = bankAcc.GetBalance().ToString("C2")
                                          txtBal.ForeColor = Color.White
                                      Else
                                          MessageBox.Show("Please enter a valid amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                      End If
                                  End Sub

        AddHandler btnReset.Click, Sub()
                                       btnDep.Visible = True
                                       btnWith.Visible = True
                                       btnReset.Visible = False
                                       txtAmt.Clear()
                                       txtAmt.Focus()
                                   End Sub

        AddHandler btnCheck.Click, Sub()
                                       txtBal.Text = bankAcc.GetBalance().ToString("C2")
                                       txtBal.ForeColor = Color.White
                                   End Sub

        pnlDemo.Controls.AddRange({lblAmt, txtAmt, btnDep, btnWith, btnReset, lblBal, txtBal, btnCheck})

        SetReviewerText("Encapsulation",
            "Encapsulation is a fundamental concept in object-oriented programming (OOP) that involves bundling the data (attributes) and the methods (functions or procedures) that operate on that data within a single unit, typically a class. It restricts direct access to some of an object's components, which helps to protect the integrity of the data and prevents unintended interference or misuse." & vbCrLf & vbCrLf &
            "INTERACTIVE DEMO:" & vbCrLf &
            "Notice how interacting with Deposit actively hides the Withdraw button (and vice versa) to prevent conflicting transactions until you reset the view. The internal balance is completely protected and updated only via secure public methods.",
            "Public Class BankAccount" & vbCrLf &
            "    Private balance As Decimal" & vbCrLf &
            "    Public Sub Deposit(amount As Decimal)" & vbCrLf &
            "        If amount > 0 Then balance += amount" & vbCrLf &
            "    End Sub" & vbCrLf &
            "    Public Sub Withdraw(amount As Decimal)")
    End Sub

    ' --- 3. INHERITANCE ---
    Private Sub BuildInheritanceView()
        Dim lblName As New Label() With {.Text = "Name your Subclass Dog:", .ForeColor = Color.White, .Location = New Point(15, 15), .AutoSize = True}
        Dim txtName As New TextBox() With {.Location = New Point(15, 35), .Width = 200, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.White}
        Dim btnSpeak As New Button() With {.Text = "Trigger Inherited Action", .Location = New Point(15, 75), .Size = New Size(200, 35), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}
        Dim lblAction As New Label() With {.Text = "Output:", .ForeColor = Color.White, .Location = New Point(15, 125), .AutoSize = True}
        Dim txtAction As New TextBox() With {.Location = New Point(15, 145), .Width = 200, .ReadOnly = True, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.Lime}

        AddHandler btnSpeak.Click, Sub()
                                       Dim dogName As String = If(String.IsNullOrWhiteSpace(txtName.Text), "The unnamed dog", txtName.Text)
                                       txtAction.Text = $"{dogName} inherits the ability to bark!"
                                   End Sub

        pnlDemo.Controls.AddRange({lblName, txtName, btnSpeak, lblAction, txtAction})

        SetReviewerText("Inheritance",
            "Inheritance is a core concept in object-oriented programming (OOP) that allows a class (called a subclass or derived class) to inherit properties and behaviors (methods) from another class (called a superclass or base class). This mechanism promotes code reuse and establishes a hierarchical relationship between classes." & vbCrLf & vbCrLf &
            "INTERACTIVE DEMO:" & vbCrLf &
            "By giving the dog a name, you are interacting with a property that was passed down from a base Animal class to the specific Dog subclass.",
            "Public Class Animal" & vbCrLf &
            "    Public Property Name As String" & vbCrLf &
            "    Public Overridable Sub Speak()" & vbCrLf &
            "        Console.WriteLine(""Animal speaks"")" & vbCrLf &
            "    End Sub" & vbCrLf &
            "End Sub")
    End Sub

    ' --- 4. POLYMORPHISM ---
    Private Sub BuildPolymorphismView()
        Dim lblSelect As New Label() With {.Text = "Select an Animal Class:", .ForeColor = Color.White, .Location = New Point(15, 15), .AutoSize = True}
        Dim cmbAnimal As New ComboBox() With {.Location = New Point(15, 35), .Width = 200, .DropDownStyle = ComboBoxStyle.DropDownList, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.White}
        cmbAnimal.Items.AddRange({"Dog", "Cat", "Duck"})
        cmbAnimal.SelectedIndex = 0

        Dim btnExec As New Button() With {.Text = "Trigger Speak()", .Location = New Point(15, 75), .Size = New Size(200, 35), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}
        Dim lblResult As New Label() With {.Text = "Polymorphic Output:", .ForeColor = Color.White, .Location = New Point(15, 125), .AutoSize = True}
        Dim txtSound As New TextBox() With {.Location = New Point(15, 145), .Width = 200, .ReadOnly = True, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.Cyan}

        AddHandler btnExec.Click, Sub()
                                      Dim animalType As String = cmbAnimal.SelectedItem.ToString()
                                      Dim sound As String = ""
                                      Select Case animalType
                                          Case "Dog" : sound = "Woof! Bark!"
                                          Case "Cat" : sound = "Meow! Purr..."
                                          Case "Duck" : sound = "Quack! Quack!"
                                      End Select
                                      txtSound.Text = $"[Animal As {animalType}] -> {sound}"
                                  End Sub

        pnlDemo.Controls.AddRange({lblSelect, cmbAnimal, btnExec, lblResult, txtSound})

        SetReviewerText("Polymorphism",
            "Polymorphism is a fundamental concept in object-oriented programming that allows objects of different classes to be treated as instances of a common superclass. It enables a single interface to represent different underlying data types or behaviors, facilitating flexibility and extensibility in code." & vbCrLf & vbCrLf &
            "INTERACTIVE DEMO:" & vbCrLf &
            "By selecting different animals in the dropdown, the exact same method call (Speak) yields entirely different results depending on the object instantiated.",
            "Dim a As Animal = New Dog()" & vbCrLf &
            "a.Speak() ' Outputs: Dog barks")
    End Sub

    ' --- 5. INTERFACE ---
    Private Sub BuildInterfaceView()
        Dim lblDoc As New Label() With {.Text = "Type Document Content:", .ForeColor = Color.White, .Location = New Point(15, 15), .AutoSize = True}
        Dim txtDoc As New TextBox() With {.Location = New Point(15, 35), .Width = 200, .Height = 60, .Multiline = True, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.White}
        Dim btnPrint As New Button() With {.Text = "Send to IPrintable", .Location = New Point(15, 105), .Size = New Size(200, 35), .ForeColor = Color.White, .BackColor = Color.FromArgb(50, 50, 50), .FlatStyle = FlatStyle.Flat}
        Dim txtStatus As New TextBox() With {.Location = New Point(15, 155), .Width = 200, .ReadOnly = True, .BackColor = Color.FromArgb(40, 40, 40), .ForeColor = Color.Yellow}

        AddHandler btnPrint.Click, Sub()
                                       Dim content As String = If(String.IsNullOrWhiteSpace(txtDoc.Text), "[Blank Document]", txtDoc.Text)
                                       txtStatus.Text = "Processing IPrintable.Print()..."
                                       MessageBox.Show($"--- PRINTER OUTPUT ---{vbCrLf}{vbCrLf}{content}", "IPrintable Interface Executed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       txtStatus.Text = "Print Job Completed Successfully."
                                       txtDoc.Clear()
                                   End Sub

        pnlDemo.Controls.AddRange({lblDoc, txtDoc, btnPrint, txtStatus})

        SetReviewerText("Interfaces",
            "Interfaces are used to define a contract that classes can implement. An interface specifies a set of methods, properties, events, or indexers that implementing classes must provide, without providing the actual implementation itself. This allows for a form of abstraction and promotes loose coupling in your code." & vbCrLf & vbCrLf &
            "INTERACTIVE DEMO:" & vbCrLf &
            "Type your own text above. When you click send, the application executes the required Print() subroutine mandated by the IPrintable interface, pushing your text to the simulated printer.",
            "Public Interface IPrintable" & vbCrLf &
            "    Sub Print()" & vbCrLf &
            "End Interface" & vbCrLf & vbCrLf &
            "Public Class Document" & vbCrLf &
            "    Implements IPrintable" & vbCrLf &
            "    Public Sub Print() Implements IPrintable.Print" & vbCrLf &
            "        Console.WriteLine(""Printing..."")" & vbCrLf &
            "    End Sub" & vbCrLf &
            "End Class")
    End Sub

    Private Sub SetReviewerText(heading As String, explanation As String, codeSnippet As String)
        Dim txtReviewer As New RichTextBox() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(20, 20, 20),
            .ForeColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .ReadOnly = True
        }

        txtReviewer.AppendText(heading & vbCrLf & vbCrLf)
        txtReviewer.AppendText(explanation & vbCrLf & vbCrLf)
        txtReviewer.AppendText("Code:" & vbCrLf)
        txtReviewer.AppendText(codeSnippet)

        pnlReviewer.Controls.Add(txtReviewer)
    End Sub
End Class
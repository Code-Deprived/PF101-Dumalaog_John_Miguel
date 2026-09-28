Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms

Public Class DoubleBufferedPanel
    Inherits Panel

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
    End Sub
End Class

Public Module UIHelpers

    ''' <summary>
    ''' Recursively enables double buffering on a control and all of its child controls to prevent GIF flicker.
    ''' </summary>
    Public Sub EnableDoubleBufferingRecursive(parent As Control)
        Dim prop = GetType(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic Or BindingFlags.Instance)
        prop?.SetValue(parent, True, Nothing)

        For Each child As Control In parent.Controls
            EnableDoubleBufferingRecursive(child)
        Next
    End Sub

    Public Function GetAndyFont(size As Single, Optional style As FontStyle = FontStyle.Bold) As Font
        Using fontCollection As New System.Drawing.Text.InstalledFontCollection()
            Dim familyExists As Boolean = fontCollection.Families.Any(Function(f) f.Name.Equals("Andy", StringComparison.OrdinalIgnoreCase))
            Return If(familyExists, New Font("Andy", size, style), New Font("Trebuchet MS", size, style))
        End Using
    End Function

    Public Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Public Sub DrawOutlinedText(g As Graphics, text As String, font As Font, foreColor As Color, strokeColor As Color, rect As Rectangle, Optional align As StringAlignment = StringAlignment.Center)
        Using path As New GraphicsPath()
            Dim emSize As Single = g.DpiY * font.Size / 72.0F
            Using format As New StringFormat() With {.Alignment = align, .LineAlignment = StringAlignment.Center}
                path.AddString(text, font.FontFamily, CInt(font.Style), emSize, rect, format)
            End Using
            Using outlinePen As New Pen(strokeColor, 5.0F) With {.LineJoin = LineJoin.Round}
                g.DrawPath(outlinePen, path)
            End Using
            Using textBrush As New SolidBrush(foreColor)
                g.FillPath(textBrush, path)
            End Using
        End Using
    End Sub

    Public Sub DrawHeaderBox(g As Graphics, rect As Rectangle, text As String, fontSize As Single)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        Using path As GraphicsPath = GetRoundedRectPath(New Rectangle(0, 0, rect.Width - 1, rect.Height - 1), 10),
              bgBrush As New SolidBrush(Color.FromArgb(230, 42, 52, 90)),
              borderPen As New Pen(Color.FromArgb(90, 110, 170), 2)
            g.FillPath(bgBrush, path)
            g.DrawPath(borderPen, path)
        End Using

        Using andyFont As Font = GetAndyFont(fontSize, FontStyle.Bold)
            DrawOutlinedText(g, text, andyFont, Color.White, Color.Black, rect)
        End Using
    End Sub

End Module
Imports System.Windows.Media

Public Class ScreenshotOptions
    Public Sub New()
        BackgroundOpacity = 0.5
        SelectionRectangleBorderBrush = Brushes.Red
    End Sub

    Public Property BackgroundOpacity As Double
    Public Property SelectionRectangleBorderBrush As Brush
End Class

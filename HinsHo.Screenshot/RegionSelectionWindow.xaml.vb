Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Public Class RegionSelectionWindow
    Private _selectionStartPos As Point?

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Loaded, Function(s, e) Activate()
    End Sub

    Public Property SelectedRegion As Rect?

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        Close()
    End Sub

    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)
        _selectionStartPos = e.GetPosition(Me)
        Mouse.Capture(Me)
    End Sub

    Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonUp(e)

        If Not Equals(Mouse.Captured, Me) OrElse _selectionStartPos Is Nothing Then
            Return
        End If

        SelectedRegion = New Rect(_selectionStartPos.Value, e.GetPosition(Me))
        _selectionStartPos = Nothing
        Mouse.Capture(Nothing)
        Close()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If Not Equals(Mouse.Captured, Me) OrElse _selectionStartPos Is Nothing Then
            Return
        End If

        Dim position = e.GetPosition(Me)
        Dim left = Math.Min(_selectionStartPos.Value.X, position.X)
        Dim top = Math.Min(_selectionStartPos.Value.Y, position.Y)
        Canvas.SetLeft(SelectionImage, -left)
        Canvas.SetTop(SelectionImage, -top)
        Canvas.SetLeft(SelectionBorder, left)
        Canvas.SetTop(SelectionBorder, top)
        SelectionBorder.Width = Math.Abs(position.X - _selectionStartPos.Value.X)
        SelectionBorder.Height = Math.Abs(position.Y - _selectionStartPos.Value.Y)
    End Sub
End Class

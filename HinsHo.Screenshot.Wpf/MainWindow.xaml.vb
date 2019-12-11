Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim bitmapSource = Screenshot.CaptureRegionToBitmapSource
        Me.imgScreenShot.Source = bitmapSource
    End Sub
End Class

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows
Imports System.Windows.Media.Imaging
Imports Size = System.Drawing.Size

Public Class Screenshot

    Public Shared Function CaptureAllScreens() As BitmapSource
        Return CaptureRegionToBitmapSource(New Rect(SystemParameters.VirtualScreenLeft,
                                          SystemParameters.VirtualScreenTop,
                                          SystemParameters.VirtualScreenWidth,
                                          SystemParameters.VirtualScreenHeight))
    End Function

    Public Shared Function CaptureRegionToBitmapSource(Optional options As ScreenshotOptions = Nothing) As BitmapSource

        If options Is Nothing Then options = New ScreenshotOptions
        Dim bitmap = CaptureAllScreens()

        Dim left = SystemParameters.VirtualScreenLeft
        Dim top = SystemParameters.VirtualScreenTop
        Dim right = left + SystemParameters.VirtualScreenWidth
        Dim bottom = right + SystemParameters.VirtualScreenHeight

        Dim window As New RegionSelectionWindow
        window.WindowStyle = WindowStyle.None
        window.ResizeMode = ResizeMode.NoResize
        window.Topmost = True
        window.ShowInTaskbar = False
        window.BorderThickness = New Thickness(0)
        window.BackgroundImage.Source = bitmap
        window.BackgroundImage.Opacity = options.BackgroundOpacity
        window.InnerBorder.BorderBrush = options.SelectionRectangleBorderBrush
        window.Left = left
        window.Top = top
        window.Width = right - left
        window.Height = bottom - top

        window.ShowDialog()

        If window.SelectedRegion Is Nothing Then
            Return Nothing
        End If

        Return GetBitmapRegion(bitmap, window.SelectedRegion.Value)
    End Function

    Public Shared Function CaptureRegionToBitmap(Optional options As ScreenshotOptions = Nothing) As Bitmap
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
        Dim encoder As BmpBitmapEncoder = New BmpBitmapEncoder()
        Dim bs As BitmapSource = CaptureRegionToBitmapSource()
        If bs Is Nothing Then
            Return Nothing
        End If

        encoder.Frames.Add(BitmapFrame.Create(CType(bs, BitmapSource)))
        encoder.Save(ms)
        Dim bp As Bitmap = New Bitmap(ms)
        ms.Close()

        Return bp
    End Function


    Public Shared Function CaptureRegionToBitmapSource(rect As Rect) As BitmapSource
        Using bitmap = New Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb)
            Dim graphics = System.Drawing.Graphics.FromImage(bitmap)
            graphics.CopyFromScreen(rect.X, rect.Y, 0, 0, New Size(rect.Size.Width, rect.Size.Height), CopyPixelOperation.SourceCopy)

            Return bitmap.ToBitmapSource
        End Using
    End Function

    Public Shared Function CaptureRegionToBitmap(rect As Rect) As Bitmap
        Using bitmap = New Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb)
            Dim graphics = System.Drawing.Graphics.FromImage(bitmap)
            graphics.CopyFromScreen(rect.X, rect.Y, 0, 0, New Size(rect.Size.Width, rect.Size.Height), CopyPixelOperation.SourceCopy)

            Return bitmap
        End Using
    End Function

    Private Shared Function GetBitmapRegion(bitmap As BitmapSource, rect As Rect) As BitmapSource
        If rect.Width <= 0 Or rect.Height <= 0 Then
            Return Nothing
        End If

        Return New CroppedBitmap(bitmap, New Int32Rect With {
                                 .X = rect.X,
                                 .Y = rect.Y,
                                 .Width = rect.Width,
                                 .Height = rect.Height})
    End Function

End Class

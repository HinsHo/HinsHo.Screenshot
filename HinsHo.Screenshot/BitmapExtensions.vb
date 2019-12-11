Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Media.Imaging

Public Module BitmapExtensions
    <Extension()>
    Function ToBitmapSource(ByVal bitmap As Bitmap) As BitmapSource
        Using stream = New MemoryStream()
            bitmap.Save(stream, ImageFormat.Png)
            Dim bitmapImage = New BitmapImage()
            bitmapImage.BeginInit()
            bitmapImage.StreamSource = New MemoryStream(stream.ToArray())
            bitmapImage.EndInit()
            bitmapImage.Freeze()
            Return bitmapImage
        End Using
    End Function
End Module

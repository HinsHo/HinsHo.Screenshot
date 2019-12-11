Public Class Form1
    Private Sub btnScreenshot_Click(sender As Object, e As EventArgs) Handles btnScreenshot.Click
        Dim bitmap As Bitmap = Screenshot.CaptureRegionToBitmap
        If bitmap Is Nothing Then
            Return
        End If
        PictureBox.Image = bitmap
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.btnScreenshot = New System.Windows.Forms.Button()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(29, 39)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(481, 399)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'btnScreenshot
        '
        Me.btnScreenshot.Location = New System.Drawing.Point(29, 10)
        Me.btnScreenshot.Name = "btnScreenshot"
        Me.btnScreenshot.Size = New System.Drawing.Size(109, 23)
        Me.btnScreenshot.TabIndex = 1
        Me.btnScreenshot.Text = "Screen Shot"
        Me.btnScreenshot.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 450)
        Me.Controls.Add(Me.btnScreenshot)
        Me.Controls.Add(Me.PictureBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents btnScreenshot As Button
End Class

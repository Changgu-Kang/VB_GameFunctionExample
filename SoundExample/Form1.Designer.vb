<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_Snd1 = New System.Windows.Forms.Button()
        Me.btn_Snd2 = New System.Windows.Forms.Button()
        Me.btn_Snd3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Snd1
        '
        Me.btn_Snd1.Location = New System.Drawing.Point(12, 164)
        Me.btn_Snd1.Name = "btn_Snd1"
        Me.btn_Snd1.Size = New System.Drawing.Size(75, 23)
        Me.btn_Snd1.TabIndex = 0
        Me.btn_Snd1.Text = "Sound1"
        Me.btn_Snd1.UseVisualStyleBackColor = True
        '
        'btn_Snd2
        '
        Me.btn_Snd2.Location = New System.Drawing.Point(176, 164)
        Me.btn_Snd2.Name = "btn_Snd2"
        Me.btn_Snd2.Size = New System.Drawing.Size(75, 23)
        Me.btn_Snd2.TabIndex = 1
        Me.btn_Snd2.Text = "Sound2"
        Me.btn_Snd2.UseVisualStyleBackColor = True
        '
        'btn_Snd3
        '
        Me.btn_Snd3.Location = New System.Drawing.Point(338, 164)
        Me.btn_Snd3.Name = "btn_Snd3"
        Me.btn_Snd3.Size = New System.Drawing.Size(75, 23)
        Me.btn_Snd3.TabIndex = 2
        Me.btn_Snd3.Text = "Sound3"
        Me.btn_Snd3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 199)
        Me.Controls.Add(Me.btn_Snd3)
        Me.Controls.Add(Me.btn_Snd2)
        Me.Controls.Add(Me.btn_Snd1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_Snd1 As Button
    Friend WithEvents btn_Snd2 As Button
    Friend WithEvents btn_Snd3 As Button
End Class

﻿Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)


    Dim bg0 As Image
    Dim bg1 As Image

    Dim x_pos As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bg0 = Image.FromFile("bg.jpg")
        bg1 = Image.FromFile("bg.jpg")
        bg1.RotateFlip(RotateFlipType.RotateNoneFlipX) '좌우 반전
    End Sub

    Private Sub CallbackTimer_Tick(sender As Object, e As EventArgs) Handles CallbackTimer.Tick
        x_pos = x_pos - 1
        If (x_pos = -Me.Width) Then
            x_pos = Me.Width
        End If

        Invalidate()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawImage(bg0, x_pos, 0)
        If x_pos > 0 Then
            e.Graphics.DrawImage(bg1, x_pos - Me.Width, 0)
        Else
            e.Graphics.DrawImage(bg1, Me.Width + x_pos, 0)
        End If

        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))

    End Sub
End Class

Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)

    Dim currentKeys As New ArrayList
    Dim image As Image
    Dim x As Integer
    Dim y As Integer

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Dim existed As Boolean = False

        For i = 0 To currentKeys.Count - 1
            If currentKeys(i).Equals(e.KeyCode) Then
                existed = True
            End If
        Next

        If Not existed Then
            currentKeys.Add(e.KeyCode)
        End If

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        currentKeys.Remove(e.KeyCode)
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True


        image = Image.FromFile("fly.png")
        x = Me.Width / 2
        y = Me.Height / 2

    End Sub

    Private Sub CallbackTimer_Tick(sender As Object, e As EventArgs) Handles CallbackTimer.Tick
        For i = 0 To currentKeys.Count - 1
            Select Case currentKeys(i)
                Case Keys.Left
                    x = x - 2
                Case Keys.Right
                    x = x + 2
                Case Keys.Up
                    y = y - 2
                Case Keys.Down
                    y = y + 2
            End Select
        Next
        Invalidate()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawImage(image, x, y, CInt(image.Width / 3), CInt(image.Height / 3))


        e.Graphics.DrawString("→, ←, ↑, ↓ key", drawTextFont, drawTextBrush, New Point(240, Me.Height - 150))
        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))
    End Sub
End Class

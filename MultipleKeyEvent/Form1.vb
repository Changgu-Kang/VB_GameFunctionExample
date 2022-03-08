Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)

    Dim currentKeys As New ArrayList

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
    End Sub

    Private Sub CallbackTimer_Tick(sender As Object, e As EventArgs) Handles CallbackTimer.Tick
        Label1.Text = "Key: "
        For i = 0 To currentKeys.Count - 1
            Label1.Text += currentKeys(i).ToString()
        Next
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))
    End Sub
End Class

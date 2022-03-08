Imports System.Drawing.Imaging

Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)

    Dim bg As Image
    Dim currentKeys As New ArrayList
    Dim image As Image
    Dim x As Integer
    Dim y As Integer
    Dim clrMatrix
    Dim imgAttribs As New ImageAttributes

    Dim alphaCtl As Single = 0

    Dim ptsArray As Single()() = {
            New Single() {1, 0, 0, 0, 0},
            New Single() {0, 1, 0, 0, 0},
            New Single() {0, 0, 1, 0, 0},
            New Single() {0, 0, 0, 1, 0},
            New Single() {0.0F, 0.0F, 0.0F, 0.0F, 1}
        }




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
        bg = Image.FromFile("bg.jpg")

        Me.KeyPreview = True
        image = Image.FromFile("fly.png")
        x = Me.Width / 2
        y = Me.Height / 2


        clrMatrix = New ColorMatrix(ptsArray)

        'Create a ColorMatrix object
        'Create image attributes





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
                Case Keys.Q
                    If alphaCtl > -1.0F Then
                        alphaCtl = alphaCtl - 0.01
                    End If

                Case Keys.W
                    If alphaCtl < 0.0F Then
                        alphaCtl = alphaCtl + 0.01
                    End If

            End Select
        Next

        Label1.Text = CStr(alphaCtl)

        ptsArray(4)(3) = alphaCtl
        clrMatrix = New ColorMatrix(ptsArray)


        Invalidate()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        e.Graphics.DrawImage(bg, 0, 0)


        imgAttribs.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(image, New Rectangle(x, y, image.Width / 2, image.Height / 2),
                             0, 0, CInt(image.Width), CInt(image.Height),
                             GraphicsUnit.Pixel, imgAttribs)


        e.Graphics.DrawString("'Q' and 'W' key", drawTextFont, drawTextBrush, New Point(10, 30))
        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))

    End Sub
End Class

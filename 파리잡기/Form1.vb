Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)


    Structure Enemy
        Dim pos As Point
        Dim rect As Rectangle
        Dim c1_pos As Point
        Dim c2_pos As Point
        Dim c3_pos As Point
        Dim t As Double
    End Structure


    Dim angle As Integer

    Dim sound As New GameSounds

    Dim isClick As Boolean = False

    Dim pnt0_swatter As New Point()
    Dim pnt1_swatter As New Point()

    Dim pnt_weapon As New Point()

    Dim eimage As Image
    Dim wimage As Image


    Dim numEnemy As Integer = 5

    Dim rand As Random

    Dim enemys As ArrayList

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        angle = 0
        sound.AddSound("fly", "파리소리.mp3")
        eimage = Image.FromFile("파리_small.png")
        wimage = Image.FromFile("web.png")
        rand = New Random
        enemys = New ArrayList
        For i = 0 To numEnemy - 1
            AddEnemy()
        Next



        UpdateTimer.Start()
    End Sub



    Private Sub AddEnemy()
        Dim enemy As Enemy
        enemy = New Enemy

        enemy.t = 0

        enemy.c1_pos = New Point(rand.Next(0, Me.Width), rand.Next(0, Me.Height))
        enemy.c2_pos = New Point(rand.Next(0, Me.Width), rand.Next(0, Me.Height))
        enemy.c3_pos = New Point(rand.Next(0, Me.Width), rand.Next(0, Me.Height))

        enemy.pos.X = Math.Pow(1.0 - enemy.t, 2) * enemy.c1_pos.X + 2 * enemy.t * (1.0 - enemy.t) * enemy.c2_pos.X + Math.Pow(enemy.t, 2) * enemy.c3_pos.X
        enemy.pos.Y = Math.Pow(1.0 - enemy.t, 2) * enemy.c1_pos.Y + 2 * enemy.t * (1.0 - enemy.t) * enemy.c2_pos.Y + Math.Pow(enemy.t, 2) * enemy.c3_pos.Y

        enemy.rect = New Rectangle(enemy.pos.X, enemy.pos.Y, eimage.Width - 18, eimage.Height)
        enemys.Add(enemy)
        sound.Play("fly")
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        Dim mat As New Drawing2D.Matrix

        For i = 0 To enemys.Count - 1
            Dim s = CType(enemys(i), Enemy)
            mat.Reset()
            mat.RotateAt(angle, New Point(s.pos.X + eimage.Width / 2, s.pos.Y + eimage.Height / 2))
            e.Graphics.Transform = mat
            e.Graphics.DrawImage(eimage, s.pos.X, s.pos.Y)
        Next

        mat.Reset()
        e.Graphics.Transform = mat

        If isClick Then

            If pnt1_swatter.X < 0 And pnt1_swatter.Y < 0 Then
                'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnt0_swatter.X + pnt1_swatter.X, pnt0_swatter.Y + pnt1_swatter.Y, -pnt1_swatter.X, -pnt1_swatter.Y)
                e.Graphics.DrawImage(wimage, New Rectangle(pnt0_swatter.X + pnt1_swatter.X, pnt0_swatter.Y + pnt1_swatter.Y, -pnt1_swatter.X, -pnt1_swatter.Y))
            ElseIf pnt1_swatter.X < 0 Then
                'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnt0_swatter.X + pnt1_swatter.X, pnt0_swatter.Y, -pnt1_swatter.X, pnt1_swatter.Y)
                e.Graphics.DrawImage(wimage, New Rectangle(pnt0_swatter.X + pnt1_swatter.X, pnt0_swatter.Y, -pnt1_swatter.X, pnt1_swatter.Y))
            ElseIf pnt1_swatter.Y < 0 Then
                'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnt0_swatter.X, pnt0_swatter.Y + pnt1_swatter.Y, pnt1_swatter.X, -pnt1_swatter.Y)
                e.Graphics.DrawImage(wimage, New Rectangle(pnt0_swatter.X, pnt0_swatter.Y + pnt1_swatter.Y, pnt1_swatter.X, -pnt1_swatter.Y))
            Else
                'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnt0_swatter.X, pnt0_swatter.Y, pnt1_swatter.X, pnt1_swatter.Y)


                e.Graphics.DrawImage(wimage, New Rectangle(pnt0_swatter.X, pnt0_swatter.Y, pnt1_swatter.X, pnt1_swatter.Y))

            End If
        End If



        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))

    End Sub

    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        For i = 0 To enemys.Count - 1
            Dim ene = CType(enemys(i), Enemy)
            ene.t = ene.t + 0.03
            If ene.t > 1 Then
                ene.t = 0
                ene.c1_pos = ene.c3_pos
                ene.c2_pos = New Point(rand.Next(0, Me.Width), rand.Next(0, Me.Height))
                ene.c3_pos = New Point(rand.Next(0, Me.Width), rand.Next(0, Me.Height))
            End If
            ene.pos.X = Math.Pow(1.0 - ene.t, 2) * ene.c1_pos.X + 2 * ene.t * (1.0 - ene.t) * ene.c2_pos.X + Math.Pow(ene.t, 2) * ene.c3_pos.X
            ene.pos.Y = Math.Pow(1.0 - ene.t, 2) * ene.c1_pos.Y + 2 * ene.t * (1.0 - ene.t) * ene.c2_pos.Y + Math.Pow(ene.t, 2) * ene.c3_pos.Y
            ene.rect = New Rectangle(ene.pos.X, ene.pos.Y, eimage.Width, eimage.Height)
            enemys(i) = ene
        Next

        angle = angle + 3

        Invalidate()
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        isClick = True
        pnt0_swatter.X = e.X
        pnt0_swatter.Y = e.Y
        pnt1_swatter.X = 0
        pnt1_swatter.Y = 0
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp

        If (isClick) Then
            For i = 0 To enemys.Count - 1
                If MyCatch(i) Then
                    lbCatchCnt.Text = CStr(CInt(lbCatchCnt.Text) + 1)
                    enemys.RemoveAt(i)
                    AddEnemy()

                End If

            Next
        End If

        isClick = False
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        pnt1_swatter.X = e.X - pnt0_swatter.X
        pnt1_swatter.Y = e.Y - pnt0_swatter.Y
        pnt_weapon.X = e.X
        pnt_weapon.Y = e.Y
    End Sub

    Function MyCatch(idx As Integer) As Boolean

        Dim rect As New Rectangle
        Dim ene = CType(enemys(idx), Enemy)

        If pnt1_swatter.X < 0 And pnt1_swatter.Y < 0 Then
            rect.X = pnt0_swatter.X + pnt1_swatter.X
            rect.Y = pnt0_swatter.Y + pnt1_swatter.Y
            rect.Width = -pnt1_swatter.X
            rect.Height = -pnt1_swatter.Y
        ElseIf pnt1_swatter.X < 0 Then
            rect.X = pnt0_swatter.X + pnt1_swatter.X
            rect.Y = pnt0_swatter.Y
            rect.Width = -pnt1_swatter.X
            rect.Height = pnt1_swatter.Y
        ElseIf pnt1_swatter.Y < 0 Then
            rect.X = pnt0_swatter.X
            rect.Y = pnt0_swatter.Y + pnt1_swatter.Y
            rect.Width = pnt1_swatter.X
            rect.Height = -pnt1_swatter.Y
        Else
            rect.X = pnt0_swatter.X
            rect.Y = pnt0_swatter.Y
            rect.Width = pnt1_swatter.X
            rect.Height = pnt1_swatter.Y
        End If

        If rect.Contains(ene.rect) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

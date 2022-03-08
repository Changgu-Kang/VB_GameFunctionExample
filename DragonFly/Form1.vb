Public Class Form1

    Structure ObjData
        Dim x_pos As Integer
        Dim y_pos As Integer
        Dim opt As Integer
    End Structure

    Dim drawTextFont As New System.Drawing.Font("Times", 30)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.White)
    Dim drawTextFormat As New System.Drawing.StringFormat


    Dim weaponOption As Integer = 2

    Dim objArray As New ArrayList

    Dim lightingimage As Image

    Dim currentKeys As New ArrayList
    Private gifimage0 As Bitmap

    Private shootimg As Image

    Dim gameSnds As New GameSounds

    Dim bg0 As Image
    Dim bg1 As Image

    Dim x_pos As Integer = 0

    Dim x As Integer = Me.Width / 2
    Dim y As Integer = Me.Height / 2

    Dim frameCnt As UInteger = 0

    Dim lightarray As New ArrayList

    Dim rand As Random


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
        gifimage0 = Image.FromFile("image/dragon-animated-gif.gif")

        shootimg = Image.FromFile("image/fire_type2.png")
        lightingimage = Image.FromFile("image/lightning-effect-png2.png")

        ImageAnimator.Animate(gifimage0, New EventHandler(AddressOf OnFrameChanged))
        'ImageAnimator.StopAnimate(animatedImage, New EventHandler(AddressOf Me.OnFrameChanged))

        bg0 = Image.FromFile("image/bgimage2.jpg")
        bg1 = Image.FromFile("image/bgimage2.jpg")
        bg1.RotateFlip(RotateFlipType.RotateNoneFlipX) '좌우 반전
        rand = New Random

        gameSnds.AddSound("BGSND", "sound/bgm2.WAV")
        gameSnds.Play("BGSND")

    End Sub

    Private Sub CallbackTimer_Tick(sender As Object, e As EventArgs) Handles CallbackTimer.Tick
        ImageAnimator.UpdateFrames()

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

        x_pos = x_pos - 1
        If (x_pos = -Me.Width) Then
            x_pos = Me.Width
        End If

        For i = 0 To currentKeys.Count - 1
            Select Case currentKeys(i)
                Case Keys.Space
                    If frameCnt Mod 8 = 0 Then
                        If weaponOption = 0 Then
                            Dim obj As ObjData = New ObjData
                            obj.opt = weaponOption
                            obj.x_pos = x + gifimage0.Width / 4 + 100
                            obj.y_pos = y + gifimage0.Height / 4
                            objArray.Add(obj)
                        ElseIf weaponOption = 1 Then
                            Dim obj0 As ObjData = New ObjData
                            obj0.opt = weaponOption
                            obj0.x_pos = x + gifimage0.Width / 4 + 100
                            obj0.y_pos = y + gifimage0.Height / 4 - 10
                            objArray.Add(obj0)

                            Dim obj1 As ObjData = New ObjData
                            obj1.opt = weaponOption
                            obj1.x_pos = x + gifimage0.Width / 4 + 100
                            obj1.y_pos = y + gifimage0.Height / 4 + 10
                            objArray.Add(obj1)

                        ElseIf weaponOption = 2 Then
                            Dim obj0 As ObjData = New ObjData
                            obj0.opt = weaponOption
                            obj0.x_pos = x + gifimage0.Width / 4 + 100
                            obj0.y_pos = y + gifimage0.Height / 4
                            objArray.Add(obj0)

                            Dim obj1 As ObjData = New ObjData
                            obj1.opt = weaponOption
                            obj1.x_pos = x + gifimage0.Width / 4 + 100
                            obj1.y_pos = y + gifimage0.Height / 4 + 20
                            objArray.Add(obj1)

                            Dim obj2 As ObjData = New ObjData
                            obj2.opt = weaponOption
                            obj2.x_pos = x + gifimage0.Width / 4 + 100
                            obj2.y_pos = y + gifimage0.Height / 4 - 20
                            objArray.Add(obj2)

                        ElseIf weaponOption = 3 Then
                            Dim obj0 As ObjData = New ObjData
                            obj0.opt = weaponOption
                            obj0.x_pos = x + gifimage0.Width / 4 + 100
                            obj0.y_pos = y + gifimage0.Height / 4
                            objArray.Add(obj0)

                            Dim obj1 As ObjData = New ObjData
                            obj1.opt = weaponOption
                            obj1.x_pos = x + gifimage0.Width / 4 + 100
                            obj1.y_pos = y + gifimage0.Height / 4 + 20
                            objArray.Add(obj1)

                            Dim obj2 As ObjData = New ObjData
                            obj2.opt = weaponOption
                            obj2.x_pos = x + gifimage0.Width / 4 + 100
                            obj2.y_pos = y + gifimage0.Height / 4 - 20
                            objArray.Add(obj2)
                        End If

                    End If

            End Select

        Next

        For i = 0 To objArray.Count - 1
            Dim obj = CType(objArray(i), ObjData)

            If obj.opt = 3 Then
                obj.x_pos = obj.x_pos + 6
                obj.x_pos = obj.y_pos + 1
            Else
                obj.x_pos = obj.x_pos + 6
            End If

            objArray(i) = obj
        Next

        Dim index As Integer = 0
        While index <> objArray.Count
            Dim obj = CType(objArray(index), ObjData)
            If obj.x_pos > Me.Width Then
                objArray.RemoveAt(index)
            Else
                index += 1
            End If
        End While

        If frameCnt Mod 120 = 10 Then
            Dim cnt = rand.Next(4, 10)
            For i = 0 To cnt
                Dim obj As ObjData = New ObjData
                obj.x_pos = rand.Next(10, Me.Width - 10)
                obj.y_pos = rand.Next(10, Me.Height - 10)
                lightarray.Add(obj)
            Next

        ElseIf frameCnt Mod 120 = 60 Then
            lightarray.Clear()
        End If


        frameCnt = frameCnt + 1
        Invalidate()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        e.Graphics.DrawImage(bg0, x_pos, 0, Me.Width, Me.Height)
        If x_pos > 0 Then
            e.Graphics.DrawImage(bg1, x_pos - Me.Width, 0, Me.Width, Me.Height)
        Else
            e.Graphics.DrawImage(bg1, Me.Width + x_pos, 0, Me.Width, Me.Height)
        End If

        For i = 0 To lightarray.Count - 1
            Dim obj = CType(lightarray(i), ObjData)
            e.Graphics.DrawImage(lightingimage, obj.x_pos, obj.y_pos)
        Next


        e.Graphics.DrawImage(gifimage0, x, y, CInt(gifimage0.Width / 2), CInt(gifimage0.Height / 2))

        For i = 0 To objArray.Count - 1
            Dim obj = CType(objArray(i), ObjData)
            e.Graphics.DrawImage(shootimg, obj.x_pos, obj.y_pos)
        Next

        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(200, 50))

    End Sub

    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)
        'Force a call to the Paint event handler. 

    End Sub

End Class

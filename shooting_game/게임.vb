Public Class 게임

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)

    Dim currentKeys As New ArrayList


    Dim player As New GameSounds


    Dim image As Image
    Dim eimage As Image

    Dim pressedKey As Keys

    Dim x As Integer
    Dim y As Integer
    Dim speed As Integer = 4
    Dim seedspeed As Integer = 10

    Dim isStart As Boolean = False

    Dim rand As Random

    Structure Enemy
        Dim pos As Point
        Dim rect As Rectangle
    End Structure

    Structure Seed
        Dim pos As Point
    End Structure

    Dim contain As ArrayList

    Dim enemys As ArrayList

    Dim frame_num As UInteger = 0

    Dim shoot_cnt As UInteger = 0

    Private Sub 게임_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        player.AddSound("bgm", "bgm.wav")
        player.AddSound("start", "Start button press.wav")
        player.AddSound("collision", "collision.mp3")
        player.AddSound("destroy", "destroy.mp3")
        player.AddSound("end", "end.mp3")


        image = Image.FromFile("전투기.png")
        eimage = Image.FromFile("enemy.png")
        contain = New ArrayList
        enemys = New ArrayList

        x = Me.Width / 2
        y = Me.Height - image.Height * 2


        rand = New Random

        For i = 0 To 0
            Dim enemy As Enemy
            enemy = New Enemy
            enemy.pos.X = rand.Next(50, Me.Width - 50) 'i * (Me.Width - 60) / 6 + 20 ' rand.Next(10, Me.Width - 10)
            enemy.pos.Y = 50
            enemy.rect = New Rectangle(enemy.pos.X, enemy.pos.Y, eimage.Width, eimage.Height)
            EnergyBar.Location = New Point(enemy.pos.X - 5, enemy.pos.Y - 10)
            EnergyBar.Hide()
            enemys.Add(enemy)
        Next

    End Sub


    Private Sub UpdateSeed()

        '총알 위치 update
        For i = 0 To contain.Count - 1
            Dim s = CType(contain(i), Seed)
            s.pos.Y = s.pos.Y - seedspeed
            contain(i) = s
        Next


        Dim index As Integer = 0

        '각 총알의 충돌 유무를 검사하기 위해 루프 사용
        For i = 0 To contain.Count - 1
            Dim s = CType(contain(index), Seed)
            If s.pos.Y < 0 Then '총알이 화면 밖으로 사라지면 제거
                contain.RemoveAt(index)
            Else
                '총알과 적의 충돌 체크 
                Dim collisionEnemy As Boolean = False
                For j = 0 To enemys.Count - 1
                    Dim e = CType(enemys(j), Enemy)
                    If e.rect.Contains(s.pos) Then '적 영역안에 총알이 들어왔는지 검사
                        player.Play("collision")

                        EnergyBar.PerformStep() '에너지 바 수행
                        If EnergyBar.Value = 0 Then '에너지가 0 이면 적 제거됨
                            player.Play("destroy")
                            enemys.RemoveAt(j)
                            EnergyBar.Value = 100
                            lbScore.Text = CStr(CInt(lbScore.Text) + 1)
                        Else '에너지가 0아니면 랜덤 장소로 이동 

                            e.pos.X = rand.Next(50, Me.Width - 50)
                            e.rect = New Rectangle(e.pos.X, e.pos.Y, eimage.Width, eimage.Height)
                            EnergyBar.Location = New Point(e.pos.X - 5, e.pos.Y - 10)
                            enemys(j) = e
                        End If

                        collisionEnemy = True

                        Exit For
                    End If
                Next

                If collisionEnemy = False Then
                    index += 1
                Else
                    contain.RemoveAt(index)
                End If

            End If
        Next

        '적이 없어지면 다시 생성
        If enemys.Count = 0 Then
            Dim enemy As Enemy
            enemy = New Enemy
            enemy.pos.X = rand.Next(50, Me.Width - 50) 'i * (Me.Width - 60) / 6 + 20 ' rand.Next(10, Me.Width - 10)
            enemy.pos.Y = 50
            enemy.rect = New Rectangle(enemy.pos.X, enemy.pos.Y, eimage.Width - 18, eimage.Height)
            EnergyBar.Location = New Point(enemy.pos.X - 5, enemy.pos.Y - 10)
            enemys.Add(enemy)
        End If





    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick
        If isStart Then
            UpdateSeed()
            If player.IsStopped("bgm") Then
                player.Play("bgm")
            End If
        End If


        If isStart Then
            For i = 0 To currentKeys.Count - 1
                Select Case currentKeys(i)
                    Case Keys.Left
                        If x > image.Width / 2 Then
                            x = x - speed
                        End If
                    Case Keys.Right
                        If x < Me.Width - image.Width / 2 Then
                            x = x + speed
                        End If

                    Case Keys.S
                        If frame_num - shoot_cnt > 10 Then
                            Dim s As Seed = New Seed
                            s.pos.X = x - (image.Width / 5)
                            s.pos.Y = y
                            contain.Add(s)
                            shoot_cnt = frame_num
                        End If

                End Select
            Next
        End If

        frame_num = frame_num + 1
        Invalidate()
    End Sub


    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        If isStart Then
            For i = 0 To enemys.Count - 1
                Dim s = CType(enemys(i), Enemy)
                e.Graphics.DrawImage(eimage, s.pos.X, s.pos.Y)
            Next


            For i = 0 To contain.Count - 1
                Dim s = CType(contain(i), Seed)
                e.Graphics.DrawLine(New Pen(Color.Red, 3), New Point(s.pos.X, s.pos.Y), New Point(s.pos.X, s.pos.Y - 3))
            Next
            e.Graphics.DrawImage(image, CInt(x - image.Width / 2), y)
        End If

        e.Graphics.DrawString("School of Computer Engineering, Gyeongsang National University", drawTextFont, drawTextBrush, New Point(15, Me.Height - 100))

    End Sub

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



    Private Sub btnGameStart_Click(sender As Object, e As EventArgs) Handles btnGameStart.Click
        If isStart = False Then
            lbGameTime.Text = "30"
            lbScore.Text = "0"
            isStart = True
            btnGameStart.Hide()
            EnergyBar.Show()
            Me.Focus()
            GameTimer.Start()
            player.Play("bgm")
            player.Play("start")
        End If
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        lbGameTime.Text = CStr(CInt(lbGameTime.Text) - 1)
        If lbGameTime.Text = "0" Then
            isStart = False
            btnGameStart.Show()
            GameTimer.Stop()
            contain.Clear()
            enemys.Clear()
            EnergyBar.Hide()
            EnergyBar.Value = 100
            x = Me.Width / 2
            y = Me.Height - image.Height * 2
            lbGameTime.Text = "30"
            lbScore.Text = "0"
            player.Stop("bgm")
            player.Stop("start")
            player.Stop("collision")
            player.Stop("destroy")
            player.Play("end")
        End If
    End Sub

    Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click
        End
    End Sub
End Class

Public Class Form1

    Dim gameSnds As New GameSounds


    Private Sub btn_Snd1_Click(sender As Object, e As EventArgs) Handles btn_Snd1.Click
        gameSnds.Play("collision")
        'gameSnds.Stop("collision")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gameSnds.AddSound("collision", "sound/collision.mp3")
        gameSnds.AddSound("destroy", "sound/destroy.mp3")
        gameSnds.AddSound("end", "sound/end.mp3")
    End Sub

    Private Sub btn_Snd2_Click(sender As Object, e As EventArgs) Handles btn_Snd2.Click
        gameSnds.Play("destroy")
        'gameSnds.Stop("destory")
    End Sub

    Private Sub btn_Snd3_Click(sender As Object, e As EventArgs) Handles btn_Snd3.Click
        gameSnds.Play("end")
        'gameSnds.Stop("end")
    End Sub
End Class

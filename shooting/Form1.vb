Public Class Form1

    Dim drawTextFont As New System.Drawing.Font("Times", 15)
    Dim drawTextBrush As New System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet)


    Structure ObjData
        Dim x_pos As Integer
        Dim y_pos As Integer
    End Structure



    Dim objArray As New ArrayList

    Dim currentKeys As New ArrayList

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub CallbackTimer_Tick(sender As Object, e As EventArgs) Handles CallbackTimer.Tick
        For i = 0 To currentKeys.Count - 1
            Select Case currentKeys(i)
                Case Keys.Space
                    Dim obj As ObjData = New ObjData
                    obj.x_pos = Me.Width / 2
                    obj.y_pos = Me.Height
                    objArray.Add(obj)
            End Select

        Next

        For i = 0 To objArray.Count - 1
            Dim obj = CType(objArray(i), ObjData)
            obj.y_pos = obj.y_pos - 2
            objArray(i) = obj
        Next

        Dim index As Integer = 0
        While index <> objArray.Count
            Dim obj = CType(objArray(index), ObjData)
            If obj.y_pos < 0 Then
                objArray.RemoveAt(index)
            Else
                index += 1
            End If
        End While

        Invalidate()
    End Sub


    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        For i = 0 To objArray.Count - 1
            Dim obj = CType(objArray(i), ObjData)
            e.Graphics.DrawLine(New Pen(Color.Red, 2), New Point(obj.x_pos, obj.y_pos), New Point(obj.x_pos, obj.y_pos - 1))
        Next

        e.Graphics.DrawString("Space Key", drawTextFont, drawTextBrush, New Point(260, Me.Height - 150))
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


End Class

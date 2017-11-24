Public Class Options

    Private Sub Options_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub

    Private Sub Options_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Form1.Location.X + 50, Form1.Location.Y + 50)
        If inputmouse Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            computerplayer = True
            Form1.newgame()
        Else
            computerplayer = False
            Form1.newgame()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            inputmouse = True
        Else
            inputmouse = False
            If freespace.X = 0 And freespace.Y = 0 Then
                freespace = New Point(0, 5)
            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton1.Checked Then
            inputmouse = True
        Else
            inputmouse = False
            If freespace.X = 0 And freespace.Y = 0 Then
                freespace = New Point(0, 5)
            End If
        End If
    End Sub
End Class
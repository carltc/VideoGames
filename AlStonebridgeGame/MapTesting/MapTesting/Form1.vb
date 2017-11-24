Public Module publicvalues
    Public xlocation As Integer
    Public ylocation As Integer
    Public xnew As Integer
    Public ynew As Integer
    Public direction As Integer
    Public x As Integer
    Public y As Integer
    Public time As Integer
    Public nogolocation As String
    Public map As String
End Module


Public Class Form1

    Private Sub Form7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim bHandled As Boolean = False

        Select Case e.KeyCode
            Case Keys.Right

                xnew = x + 10
                ynew = y
                If cango(xnew, ynew, nogolocation) Then
                    x = x + 10
                Else
                    x = x
                End If

                direction = 2
                e.Handled = True
            Case Keys.Left

                xnew = x - 10
                ynew = y
                If cango(xnew, ynew, nogolocation) Then
                    x = x - 10
                Else
                    x = x
                End If

                direction = 4
                e.Handled = True
            Case Keys.Up

                xnew = x
                ynew = y - 10
                If cango(xnew, ynew, nogolocation) Then
                    y = y - 10
                Else
                    y = y
                End If

                direction = 1
                e.Handled = True
            Case Keys.Down

                xnew = x
                ynew = y + 10
                If cango(xnew, ynew, nogolocation) Then
                    y = y + 10
                Else
                    y = y
                End If

                direction = 3
                e.Handled = True
            Case Keys.Escape



                e.Handled = True
            Case Keys.Enter



                e.Handled = True
        End Select

        Timer1.Enabled = True
        Timer1.Interval = 50
        time = 5
        'PictureBox1.Location = New Point(x, y)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        direction = 3
        x = 160
        y = 140
        PictureBox1.Location = New Point(x, y)
        map = "Spaceship4"
        nogolocation = map & "text.txt"
        PictureBox2.Image = My.Resources.spaceship4
        PictureBox1.Image = My.Resources.al_front_trial_
    End Sub

    Private Sub timertick1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If time = 0 Then
            Timer1.Enabled = False
            time = 5
        Else
            PictureBox1.Image = goanimation(time)
            PictureBox1.Location = New Point(golocationx(time, x), golocationy(time, y))
            time = time - 1
        End If
    End Sub
End Class

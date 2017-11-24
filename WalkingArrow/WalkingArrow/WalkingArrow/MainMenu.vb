Public Class MainMenu

    Dim backbuffer As Bitmap
    Dim characterposition, endpoint, bl, br, flamepoint, midflamepoint, midpoint As Point
    Dim characterdirection, planelength, wingwidth, flamelength, oneflame, boundary, turnspeed, midlength As Integer
    Dim leftb, rightb, leftturn, rightturn As Boolean
    Dim darkgrey2 As Brush

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Form1.Show()
        Me.Close()

    End Sub

    Private Sub MainMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Label1.Text = "WalkingArrow"
        Label1.Location = New Point(0, 0)
        Label1.AutoSize = False
        Label1.Size = New Size(ClientRectangle.Width, 60)
        Dim f As New System.Drawing.Font("Gill Sans Ultra Bold", 20, FontStyle.Bold)
        Label1.Font = f
        If difficulty = "Easy" Then
            RadioButton1.Checked = True
        ElseIf difficulty = "Medium" Then
            RadioButton2.Checked = True
        ElseIf difficulty = "Hard" Then
            RadioButton3.Checked = True
        End If
        TextBox1.Text = playername

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        characterposition = New Point(150, 150)
        characterdirection = 0
        planelength = 20
        wingwidth = 5
        midlength = 7

        Timer1.Interval = 50
        Timer1.Enabled = True

        'leftb = False
        'rightb = True
        leftturn = False
        rightturn = False

        flamelength = 5

        darkgrey2 = New SolidBrush(Color.FromArgb(100, 100, 100))

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Manual.Show()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Highscores.Show()
        Me.Close()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            difficulty = "Easy"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            difficulty = "Medium"
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            difficulty = "Hard"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        playername = TextBox1.Text
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If backbuffer Is Nothing Then
            backbuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
        End If
        Dim g As Graphics = Graphics.FromImage(backbuffer)
        g.FillRectangle(Brushes.White, 0, 0, Me.ClientSize.Width, Me.ClientSize.Height)

        endpoint.X = characterposition.X - planelength * Math.Sin(characterdirection * (Math.PI / 180))
        endpoint.Y = characterposition.Y - planelength * Math.Cos(characterdirection * (Math.PI / 180))

        midpoint.X = characterposition.X - midlength * Math.Sin(characterdirection * (Math.PI / 180))
        midpoint.Y = characterposition.Y - midlength * Math.Cos(characterdirection * (Math.PI / 180))

        bl.X = characterposition.X + wingwidth * Math.Cos(characterdirection * (Math.PI / 180))
        bl.Y = characterposition.Y - wingwidth * Math.Sin(characterdirection * (Math.PI / 180))
        br.X = characterposition.X - wingwidth * Math.Cos(characterdirection * (Math.PI / 180))
        br.Y = characterposition.Y + wingwidth * Math.Sin(characterdirection * (Math.PI / 180))
        Dim triangle(0 To 2) As Point
        Dim side1(0 To 2) As Point
        Dim side2(0 To 2) As Point
        side1 = {midpoint, br, endpoint}
        side2 = {midpoint, endpoint, bl}
        triangle = {midpoint, br, bl}
        If Math.Sin(characterdirection * (Math.PI / 180)) < 0 Then
            g.FillPolygon(Brushes.Gray, triangle)
        Else
            g.FillPolygon(darkgrey2, triangle)
        End If
        If Math.Cos(characterdirection * (Math.PI / 180)) > 0 Then
            g.FillPolygon(Brushes.Gray, side1)
            g.FillPolygon(darkgrey2, side2)
        Else
            g.FillPolygon(darkgrey2, side1)
            g.FillPolygon(Brushes.Gray, side2)
        End If
        triangle = {endpoint, br, bl}
        g.DrawPolygon(Pens.Black, triangle)

        flamepoint.X = characterposition.X + 2 * flamelength * Math.Sin(characterdirection * (Math.PI / 180))
        flamepoint.Y = characterposition.Y + 2 * flamelength * Math.Cos(characterdirection * (Math.PI / 180))
        Dim bigflame(0 To 2) As Point
        bigflame = {br, bl, flamepoint}
        g.FillPolygon(Brushes.Orange, bigflame)

        If oneflame < 20 Then
            midflamepoint.X = characterposition.X + 0.5 * flamelength * Math.Sin(characterdirection * (Math.PI / 180))
            midflamepoint.Y = characterposition.Y + 0.5 * flamelength * Math.Cos(characterdirection * (Math.PI / 180))
            oneflame = oneflame + 1
            Dim flame(0 To 2) As Point
            flame = {br, bl, midflamepoint}
            g.FillPolygon(Brushes.Red, flame)
        ElseIf oneflame < 40 Then
            midflamepoint.X = characterposition.X + flamelength * Math.Sin(characterdirection * (Math.PI / 180))
            midflamepoint.Y = characterposition.Y + flamelength * Math.Cos(characterdirection * (Math.PI / 180))
            oneflame = oneflame + 1
            Dim flame(0 To 2) As Point
            flame = {br, bl, midflamepoint}
            g.FillPolygon(Brushes.Red, flame)
        Else
            oneflame = 0
        End If

        'Copy the back buffer to the screen
        e.Graphics.DrawImageUnscaled(backbuffer, 0, 0)

    End Sub 'OnPaint

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        boundary = 80
        turnspeed = 5

        If leftturn Or rightturn Then
            If leftturn Then
                characterdirection = characterdirection - turnspeed
                If characterposition.X < ClientRectangle.Width - boundary And characterposition.X > boundary And characterposition.Y < ClientRectangle.Height - boundary And characterposition.Y > 60 + boundary Then
                    leftturn = False
                End If
            ElseIf rightturn Then
                characterdirection = characterdirection + turnspeed
                If characterposition.X < ClientRectangle.Width - boundary And characterposition.X > boundary And characterposition.Y < ClientRectangle.Height - boundary And characterposition.Y > 60 + boundary Then
                    rightturn = False
                End If
            End If
        Else
            If characterposition.X > ClientRectangle.Width - boundary Then
                If Math.Cos(characterdirection * (Math.PI / 180)) > 0 Then
                    leftturn = True
                Else
                    rightturn = True
                End If
            ElseIf characterposition.X < boundary Then
                If Math.Cos(characterdirection * (Math.PI / 180)) > 0 Then
                    rightturn = True
                Else
                    leftturn = True
                End If
            ElseIf characterposition.Y > ClientRectangle.Height - boundary Then
                If Math.Sin(characterdirection * (Math.PI / 180)) > 0 Then
                    leftturn = True
                Else
                    rightturn = True
                End If
            ElseIf characterposition.Y < 60 + boundary Then
                If Math.Sin(characterdirection * (Math.PI / 180)) > 0 Then
                    rightturn = True
                Else
                    leftturn = True
                End If
            End If
        End If

        characterposition.Y = characterposition.Y - 5 * Math.Cos(characterdirection * (Math.PI / 180))
        characterposition.X = characterposition.X - 5 * Math.Sin(characterdirection * (Math.PI / 180))
        Me.Refresh()

    End Sub

    Function randomnumber() As Integer

        Dim randnum As Integer

        randnum = Rnd() * 10
        randnum = randnum - (10 / 2)
        randomnumber = randnum

    End Function

End Class
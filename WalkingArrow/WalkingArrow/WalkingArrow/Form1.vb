Public Class Form1

    Dim backbuffer As Bitmap
    Dim wisdown, sisdown, aisdown, disdown, leftisdown, rightisdown As Boolean
    Dim keyid As Keys
    Dim characterposition, shot(), enemy(), enemybackpoint(), bombs(), banipoint, smokepoint() As Point
    Dim speed, characterdirection, turningspeed, boostspeed, normalspeed, shotspeed, shotdirection(), numbershots, enemyspeed, enemydirection(), numberenemies, smokedirection() As Integer
    Dim randomnumber, time, rnd1, rnd2, bombtime, btime, banitime As Single
    Dim wingwidth, enemywidth, enemylength, planelength, score, numberofbombs, bombsize, dead(), bombradius, flamelength, midlength As Integer
    Dim bl, br, endpoint, flamepoint, midpoint, midflamepoint, enemymid As New Point
    Dim frames As Integer
    Dim enemydefeated, shotsused, bombsused, shotkills, smokelife(), smokespeed As Integer
    Dim timepassed As Single
    Dim oneflame As Integer
    Dim darkgrey2 As Brush

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        wisdown = False
        sisdown = False
        aisdown = False
        disdown = False
        leftisdown = False
        rightisdown = False
        Timer1.Interval = 50
        If difficulty = "Easy" Then
            Timer2.Interval = 100
        ElseIf difficulty = "Medium" Then
            Timer2.Interval = 70
        ElseIf difficulty = "Hard" Then
            Timer2.Interval = 50
        End If
        characterposition = New Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2)
        turningspeed = 10
        boostspeed = 20
        normalspeed = 5
        speed = normalspeed
        shotspeed = 10 + speed
        wingwidth = 5
        planelength = 20
        enemywidth = 5
        enemylength = 20
        If difficulty = "Easy" Then
            enemyspeed = 1
        ElseIf difficulty = "Medium" Then
            enemyspeed = 4
        ElseIf difficulty = "Hard" Then
            enemyspeed = 7
        End If
        characterdirection = 0
        numbershots = 0
        numberenemies = 0
        ReDim shot(0 To 0)
        ReDim shotdirection(0 To 0)
        ReDim enemy(0 To 0)
        ReDim enemydirection(0 To 0)
        Randomize()
        time = 0
        score = 0
        btime = 15
        bombtime = 15 * Rnd()
        ReDim bombs(0 To 0)
        numberofbombs = 0
        bombsize = 5
        ReDim dead(0 To 0)
        bombradius = 100
        banitime = 0
        banipoint = New Point(0, 0)
        flamelength = 5
        midlength = 7
        shotkills = 0
        enemydefeated = 0
        shotsused = 0
        bombsused = 0
        score = 0
        timepassed = 0
        ReDim smokepoint(0 To 0)
        ReDim smokedirection(0 To 0)
        ReDim smokelife(0 To 0)
        smokespeed = 1

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        frames = 0
        Timer3.Interval = 1
        Timer4.Interval = 1000
        Timer3.Enabled = True
        Timer4.Enabled = True

        Label9.Text = "Score: 0"
        Label10.Text = "Bombs: 0"
        Label12.Text = "Time: 0"

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False

        darkgrey2 = New SolidBrush(Color.FromArgb(100, 100, 100))

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If backbuffer Is Nothing Then
            backbuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
        End If
        Dim g As Graphics = Graphics.FromImage(backbuffer)
        g.FillRectangle(Brushes.White, 0, 0, Me.ClientSize.Width, Me.ClientSize.Height)

        Dim shotbackpoint() As Point
        If UBound(shot) > 0 Then
            ReDim shotbackpoint(0 To UBound(shot))
            For i = 0 To numbershots - 1
                shotbackpoint(i).X = shot(i).X + 10 * Math.Sin(shotdirection(i) * (Math.PI / 180))
                shotbackpoint(i).Y = shot(i).Y + 10 * Math.Cos(shotdirection(i) * (Math.PI / 180))
                g.DrawLine(Pens.Black, shot(i), shotbackpoint(i))
            Next
        End If

        'g.DrawPie(Pens.Black, 0, 0, 50, 50, 0, 360)

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
        triangle = {endpoint, br, bl}
        If Math.Sin(characterdirection * (Math.PI / 180)) > 0 Then
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

        If wisdown Then
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

            If UBound(smokepoint) < 39 Then
                smokepoint(UBound(smokepoint)).X = characterposition.X - 5
                smokepoint(UBound(smokepoint)).Y = characterposition.Y - 5
                ReDim Preserve smokepoint(0 To UBound(smokepoint) + 1)

                smokedirection(UBound(smokedirection)) = characterdirection - 180 + ((Rnd() - 0.5) * 10)
                ReDim Preserve smokedirection(0 To UBound(smokedirection) + 1)

                smokelife(UBound(smokelife)) = 10
                ReDim Preserve smokelife(0 To UBound(smokelife) + 1)
            End If

            For i = 0 To UBound(smokepoint) - 1
                If smokelife(i) <= 1 Then
                    smokepoint(i).X = characterposition.X - 5
                    smokepoint(i).Y = characterposition.Y - 5
                    smokedirection(i) = characterdirection - 180 + ((Rnd() - 0.5) * 10)
                    smokelife(i) = 10
                    Exit For
                End If
            Next

            For i = 0 To UBound(smokepoint) - 1
                If smokelife(i) >= 1 Then
                    g.DrawPie(Pens.Gray, smokepoint(i).X, smokepoint(i).Y, smokelife(i), smokelife(i), 0, 360)
                End If
            Next

        End If

        If UBound(enemy) > 0 Then
            ReDim Preserve enemybackpoint(0 To UBound(enemy))
            For i = 0 To numberenemies - 1
                Dim ebl, ebr, efl, efr As New Point
                ebl.X = enemy(i).X - enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180))
                ebl.Y = enemy(i).Y + enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                ebr.X = enemy(i).X + enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180))
                ebr.Y = enemy(i).Y - enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efl.X = enemy(i).X - enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efl.Y = enemy(i).Y - enemylength * Math.Cos(enemydirection(i) * (Math.PI / 180)) + enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efr.X = enemy(i).X + enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efr.Y = enemy(i).Y - enemylength * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))

                enemymid.X = enemy(i).X - 0.5 * enemylength * Math.Sin(enemydirection(i) * (Math.PI / 180))
                enemymid.Y = enemy(i).Y - 0.5 * enemylength * Math.Cos(enemydirection(i) * (Math.PI / 180))

                Dim tr1(0 To 2), tr2(0 To 2), tr3(0 To 2), tr4(0 To 2) As Point
                Dim square(0 To 3) As Point
                tr1 = {ebl, enemymid, efl}
                tr2 = {ebl, enemymid, ebr}
                tr3 = {ebr, enemymid, efr}
                tr4 = {efr, enemymid, efl}
                square = {ebl, ebr, efr, efl}
                If Math.Cos(enemydirection(i) * (Math.PI / 180)) > 0 Then
                    g.FillPolygon(Brushes.Red, tr1)
                    g.FillPolygon(Brushes.DarkRed, tr3)
                Else
                    g.FillPolygon(Brushes.DarkRed, tr1)
                    g.FillPolygon(Brushes.Red, tr3)
                End If
                If Math.Sin(enemydirection(i) * (Math.PI / 180)) > 0 Then
                    g.FillPolygon(Brushes.Red, tr4)
                    g.FillPolygon(Brushes.DarkRed, tr2)
                Else
                    g.FillPolygon(Brushes.Red, tr2)
                    g.FillPolygon(Brushes.DarkRed, tr4)
                End If
                g.DrawPolygon(Pens.Black, tr1)
                g.DrawPolygon(Pens.Black, tr2)
                g.DrawPolygon(Pens.Black, tr3)
                g.DrawPolygon(Pens.Black, tr4)
            Next
        End If

        If UBound(bombs) > 0 Then
            For i = 0 To UBound(bombs)
                Dim tl, tr, bl, br As New Point
                tl = New Point(bombs(i).X - bombsize, bombs(i).Y - bombsize)
                tr = New Point(bombs(i).X + bombsize, bombs(i).Y - bombsize)
                bl = New Point(bombs(i).X - bombsize, bombs(i).Y + bombsize)
                br = New Point(bombs(i).X + bombsize, bombs(i).Y + bombsize)
                Dim square(0 To 3) As Point
                square = {tl, tr, br, bl}
                g.FillPolygon(Brushes.Gray, square)
            Next
        End If

        If banitime > 0.2 Then
            Dim bmp As New Bitmap(bombradius * 2, bombradius * 2)
            For i = 0 To bombradius - 1
                For j = 0 To bombradius - 1
                    bmp.SetPixel(i * 2, j * 2, Color.Gray)
                Next
            Next
            g.DrawImage(bmp, banipoint.X - bombradius, banipoint.Y - bombradius)
        ElseIf banitime > 0 Then
            Dim bmp As New Bitmap(bombradius * 2, bombradius * 2)
            For i = 0 To bombradius / 2 - 2
                For j = 0 To bombradius / 2 - 2
                    bmp.SetPixel(i * 4, j * 4, Color.Gray)
                Next
            Next
            g.DrawImage(bmp, banipoint.X - bombradius, banipoint.Y - bombradius)
        End If

        'Copy the back buffer to the screen
        e.Graphics.DrawImageUnscaled(backbuffer, 0, 0)

    End Sub 'OnPaint

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        keyid = e.KeyCode
        Select Case keyid
            Case Keys.W
                wisdown = True
            Case Keys.S
                sisdown = True
            Case Keys.A
                aisdown = True
            Case Keys.D
                disdown = True
            Case Keys.Left
                leftisdown = True
            Case Keys.Right
                rightisdown = True
            Case Keys.Enter
                speed = boostspeed
                shotspeed = 10 + speed
            Case Keys.Space
                shot(numbershots) = characterposition
                shotdirection(numbershots) = characterdirection
                ReDim Preserve shotdirection(0 To UBound(shotdirection) + 1)
                ReDim Preserve shot(0 To UBound(shot) + 1)
                numbershots = numbershots + 1
                shotsused = shotsused + 1
            Case Keys.B
                If numberofbombs > 0 And UBound(enemy) > 0 Then
                    banitime = 0.4
                    banipoint = New Point(characterposition.X, characterposition.Y)
                    numberofbombs = numberofbombs - 1
                    For i = 0 To UBound(enemy) - 1
                        If enemy(i).X > characterposition.X - bombradius And enemy(i).X < characterposition.X + bombradius And enemy(i).Y < characterposition.Y + bombradius And enemy(i).Y > characterposition.Y - bombradius Then
                            dead(UBound(dead)) = i
                            ReDim Preserve dead(0 To UBound(dead) + 1)
                            score = score + 40
                        End If
                    Next
                    For i = 0 To UBound(dead) - 1
                        For m = dead(i) To UBound(enemy) - 1
                            enemy(m) = enemy(m + 1)
                            enemydirection(m) = enemydirection(m + 1)
                        Next
                        ReDim Preserve enemy(0 To UBound(enemy) - 1)
                        ReDim Preserve enemydirection(0 To UBound(enemydirection) - 1)
                        numberenemies = numberenemies - 1
                        enemydefeated = enemydefeated + 1
                    Next
                    ReDim dead(0 To 0)
                End If
                bombsused = bombsused + 1
            Case Keys.Escape
                Timer1.Enabled = False
                Timer2.Enabled = False
                finalscore.playerName = playername
                finalscore.difficulty = difficulty
                If shotsused = 0 Or enemydefeated = 0 Then
                    finalscore.accuracy = 0
                Else
                    finalscore.accuracy = enemydefeated / shotsused * 100
                End If
                finalscore.bombs = bombsused
                finalscore.enemiesdefeated = enemydefeated
                finalscore.score = score
                finalscore.timetaken = round(timepassed, 2)
                ReDim Preserve scores(0 To UBound(scores) + 1)
                scores(UBound(scores) - 1) = finalscore
                MsgBox("Game Over - You scored: " & score)
                Highscores.Show()
                Me.Close()
        End Select
        'If wisdown Or sisdown Or aisdown Or disdown Or leftisdown Or rightisdown Then
        Timer1.Enabled = True
        'End If

    End Sub

    Private Sub Form1_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        keyid = e.KeyCode
        Select Case keyid
            Case Keys.W
                wisdown = False
            Case Keys.S
                sisdown = False
            Case Keys.A
                aisdown = False
            Case Keys.D
                disdown = False
            Case Keys.Left
                leftisdown = False
            Case Keys.Right
                rightisdown = False
            Case Keys.Enter
                speed = normalspeed
                shotspeed = 10 + speed
        End Select
        'If wisdown = False And sisdown = False And aisdown = False And disdown = False And leftisdown = False And rightisdown = False Then
        'Timer1.Enabled = False
        'End If

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim accuracy As Integer = 5
        timepassed = timepassed + 0.05
        Label12.Text = "Time: " & round(timepassed, 0)

        For i = 0 To UBound(smokepoint)
            smokepoint(i).Y = smokepoint(i).Y - smokespeed * Math.Cos(smokedirection(i) * (Math.PI / 180))
            smokepoint(i).X = smokepoint(i).X - smokespeed * Math.Sin(smokedirection(i) * (Math.PI / 180))
            smokedirection(i) = smokedirection(i) + ((Rnd() - 0.5) * 4)
            smokelife(i) = smokelife(i) - 1
        Next

        If wisdown Then
            characterposition.Y = characterposition.Y - speed * Math.Cos(characterdirection * (Math.PI / 180))
            characterposition.X = characterposition.X - speed * Math.Sin(characterdirection * (Math.PI / 180))
        End If
        If sisdown Then
            characterposition.Y = characterposition.Y + speed * Math.Cos(characterdirection * (Math.PI / 180))
            characterposition.X = characterposition.X + speed * Math.Sin(characterdirection * (Math.PI / 180))
        End If
        If disdown Then
            characterdirection = characterdirection - turningspeed
            'If characterdirection < 0 Then
            '    characterdirection = characterdirection + 360
            'End If
        End If
        If aisdown Then
            characterdirection = characterdirection + turningspeed
            'If characterdirection > 359 Then
            '    characterdirection = characterdirection - 360
            'End If
        End If

        If UBound(shot) > 0 Then
            For i = 0 To numbershots - 1
                shot(i).X = shot(i).X - shotspeed * Math.Sin(shotdirection(i) * (Math.PI / 180))
                shot(i).Y = shot(i).Y - shotspeed * Math.Cos(shotdirection(i) * (Math.PI / 180))
            Next
        End If

        If UBound(enemy) > 0 Then
            For i = 0 To numberenemies - 1
                Dim ebl, ebr, efl, efr As New Point
                ebl.X = enemy(i).X - enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180))
                ebl.Y = enemy(i).Y + enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                ebr.X = enemy(i).X + enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180))
                ebr.Y = enemy(i).Y - enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efl.X = enemy(i).X - enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efl.Y = enemy(i).Y - enemylength * Math.Cos(enemydirection(i) * (Math.PI / 180)) + enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efr.X = enemy(i).X + enemywidth * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(i) * (Math.PI / 180))
                efr.Y = enemy(i).Y - enemylength * Math.Cos(enemydirection(i) * (Math.PI / 180)) - enemywidth * Math.Sin(enemydirection(i) * (Math.PI / 180))
                Dim square(0 To 3) As Point
                square = {ebl, ebr, efr, efl}
                If isitin(square, characterposition, accuracy) Then
                    Timer1.Enabled = False
                    Timer2.Enabled = False
                    finalscore.playerName = playername
                    finalscore.difficulty = difficulty
                    If shotsused = 0 Or shotkills = 0 Then
                        finalscore.accuracy = 0
                    Else
                        finalscore.accuracy = shotkills / shotsused * 100
                    End If
                    finalscore.bombs = bombsused
                    finalscore.enemiesdefeated = enemydefeated
                    finalscore.score = score
                    finalscore.timetaken = round(timepassed, 2)
                    ReDim Preserve scores(0 To UBound(scores) + 1)
                    scores(UBound(scores) - 1) = finalscore
                    MsgBox("Game Over - You scored: " & score)
                    GoTo endofgame
                End If
                If enemy(i).X = characterposition.X Then
                    If enemy(i).Y > characterposition.Y Then
                        enemydirection(i) = 0
                    Else
                        enemydirection(i) = 180
                    End If
                ElseIf enemy(i).Y = characterposition.Y Then
                    If enemy(i).X > characterposition.X Then
                        enemydirection(i) = 90
                    Else
                        enemydirection(i) = 270
                    End If
                ElseIf enemy(i).X > characterposition.X And enemy(i).Y > characterposition.Y Then
                    enemydirection(i) = (180 / Math.PI) * Math.Atan((enemy(i).X - characterposition.X) / (enemy(i).Y - characterposition.Y))
                ElseIf enemy(i).X < characterposition.X And enemy(i).Y > characterposition.Y Then
                    enemydirection(i) = 360 + (180 / Math.PI) * Math.Atan((characterposition.X - enemy(i).X) / (-characterposition.Y - enemy(i).Y))
                ElseIf enemy(i).X > characterposition.X And enemy(i).Y < characterposition.Y Then
                    enemydirection(i) = 180 + (180 / Math.PI) * Math.Atan((-characterposition.X - enemy(i).X) / (characterposition.Y - enemy(i).Y))
                ElseIf enemy(i).X < characterposition.X And enemy(i).Y < characterposition.Y Then
                    enemydirection(i) = 180 + (180 / Math.PI) * Math.Atan((characterposition.X - enemy(i).X) / (characterposition.Y - enemy(i).Y))
                End If
                enemy(i).X = enemy(i).X - enemyspeed * Math.Sin(enemydirection(i) * (Math.PI / 180))
                enemy(i).Y = enemy(i).Y - enemyspeed * Math.Cos(enemydirection(i) * (Math.PI / 180))
            Next
        End If

        If UBound(shot) > 0 Then
            For i = 0 To UBound(shot) - 1
                If shot(i).X < 0 Or shot(i).X > ClientRectangle.Width Or shot(i).Y < 0 Or shot(i).Y > ClientRectangle.Height Then
                    For m = i To UBound(shot) - 1
                        shot(m) = shot(m + 1)
                        shotdirection(m) = shotdirection(m + 1)
                    Next
                    ReDim Preserve shot(0 To UBound(shot) - 1)
                    ReDim Preserve shotdirection(0 To UBound(shotdirection) - 1)
                    numbershots = numbershots - 1
                End If
            Next
        End If

        Label1.Text = characterdirection
        Label2.Text = characterposition.ToString
        Label3.Text = numbershots
        Label4.Text = numberenemies
        If numberenemies > 0 Then
            Label5.Text = enemy(numberenemies - 1).ToString
            Label6.Text = enemydirection(numberenemies - 1)
        End If

        If UBound(enemy) > 0 And UBound(shot) > 0 Then
            For i = 0 To UBound(shot) - 1
                For j = 0 To UBound(enemy)
                    Dim ebl, ebr, efl, efr As New Point
                    ebl.X = enemy(j).X - enemywidth * Math.Cos(enemydirection(j) * (Math.PI / 180))
                    ebl.Y = enemy(j).Y + enemywidth * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    ebr.X = enemy(j).X + enemywidth * Math.Cos(enemydirection(j) * (Math.PI / 180))
                    ebr.Y = enemy(j).Y - enemywidth * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    efl.X = enemy(j).X - enemywidth * Math.Cos(enemydirection(j) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    efl.Y = enemy(j).Y - enemylength * Math.Cos(enemydirection(j) * (Math.PI / 180)) + enemywidth * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    efr.X = enemy(j).X + enemywidth * Math.Cos(enemydirection(j) * (Math.PI / 180)) - enemylength * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    efr.Y = enemy(j).Y - enemylength * Math.Cos(enemydirection(j) * (Math.PI / 180)) - enemywidth * Math.Sin(enemydirection(j) * (Math.PI / 180))
                    Dim square(0 To 3) As Point
                    square = {ebl, ebr, efr, efl}
                    For n = 0 To 10
                        Dim poin As New Point
                        poin.X = shot(i).X + n * Math.Sin(shotdirection(i) * (Math.PI / 180))
                        poin.Y = shot(i).Y + n * Math.Cos(shotdirection(i) * (Math.PI / 180))
                        If isitin(square, poin, accuracy) Then
                            For m = i To UBound(shot) - 1
                                shot(m) = shot(m + 1)
                                shotdirection(m) = shotdirection(m + 1)
                            Next
                            ReDim Preserve shot(0 To UBound(shot) - 1)
                            ReDim Preserve shotdirection(0 To UBound(shotdirection) - 1)
                            numbershots = numbershots - 1
                            For m = j To UBound(enemy) - 1
                                enemy(m) = enemy(m + 1)
                                enemydirection(m) = enemydirection(m + 1)
                            Next
                            ReDim Preserve enemy(0 To UBound(enemy) - 1)
                            ReDim Preserve enemydirection(0 To UBound(enemydirection) - 1)
                            numberenemies = numberenemies - 1
                            score = score + (100 / (numbershots + 1))
                            enemydefeated = enemydefeated + 1
                            shotkills = shotkills + 1
                            GoTo escape
                        End If
                    Next
                Next
            Next
        End If

        If UBound(bombs) > 0 Then
            For i = 0 To UBound(bombs) - 1
                Dim tl, tr, bl, br As New Point
                tl = New Point(bombs(i).X - bombsize, bombs(i).Y - bombsize)
                tr = New Point(bombs(i).X + bombsize, bombs(i).Y - bombsize)
                bl = New Point(bombs(i).X - bombsize, bombs(i).Y + bombsize)
                br = New Point(bombs(i).X + bombsize, bombs(i).Y + bombsize)
                Dim square(0 To 3) As Point
                square = {tl, tr, br, bl}
                If isitin(square, characterposition, accuracy) Then
                    numberofbombs = numberofbombs + 1
                    For m = i To UBound(bombs) - 1
                        bombs(m) = bombs(m + 1)
                    Next
                    ReDim Preserve bombs(0 To UBound(bombs) - 1)
                End If
            Next
        End If

        If banitime > 0 Then
            banitime = banitime - 0.1
        End If

escape:

        Label9.Text = "Score: " & score
        Label10.Text = "Bombs: " & numberofbombs

        Timer2.Enabled = True

        Me.Refresh()

        Exit Sub

Endofgame:
        Highscores.Show()
        Me.Close()

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

        If time < 1 And numberenemies < 15 Then
            rnd1 = Rnd()
            rnd2 = Rnd()
            Dim ww, hh As Integer
            ww = ClientRectangle.Width
            hh = ClientRectangle.Height
            If rnd1 <= 0.5 And rnd2 <= 0.5 Then
                enemy(numberenemies) = New Point(rnd1 * 2 * ww, 0)
            ElseIf rnd1 <= 0.5 And rnd2 > 0.5 Then
                enemy(numberenemies) = New Point(ww, rnd1 * 2 * hh)
            ElseIf rnd1 > 0.5 And rnd2 <= 0.5 Then
                enemy(numberenemies) = New Point(rnd1 * 2 * ww, hh)
            Else
                enemy(numberenemies) = New Point(0, rnd1 * 2 * hh)
            End If
            enemydirection(numberenemies) = (180 / Math.PI) * Math.Atan((characterposition.X - enemy(numberenemies).X) / (characterposition.Y - enemy(numberenemies).Y))
            ReDim Preserve enemydirection(0 To UBound(enemy) + 1)
            ReDim Preserve enemy(0 To UBound(enemy) + 1)
            numberenemies = numberenemies + 1
            time = 4
        End If

        If btime < bombtime Then
            rnd1 = Rnd() * ClientRectangle.Width
            rnd2 = Rnd() * ClientRectangle.Height
            bombs(UBound(bombs)) = New Point(rnd1, rnd2)
            ReDim Preserve bombs(0 To UBound(bombs) + 1)
            btime = 15
            bombtime = Rnd() * 15
        End If

        Label4.Text = numberenemies
        If numberenemies > 0 Then
            Label5.Text = enemy(numberenemies - 1).ToString
            Label6.Text = enemydirection(numberenemies - 1)
        End If
        Label7.Text = rnd1
        Label8.Text = rnd2

        btime = btime - 0.1
        time = time - 0.1

    End Sub

    Function isitin(shape() As Point, point As Point, accuracy As Integer) As Boolean

        Dim grad1, grad2, grad3, grad4 As Single
        Dim pt1, pt2, pt3, pt4 As New Point

        If shape(1).X > shape(0).X Then
            If shape(1).X = shape(0).X Then
                grad1 = 1
            Else
                grad1 = (shape(1).Y - shape(0).Y) / (shape(1).X - shape(0).X)
            End If
            For i = 0 To (shape(1).X - shape(0).X)
                pt1.X = i + shape(0).X
                pt1.Y = grad1 * i + shape(0).Y
                If point.X > pt1.X - accuracy And point.X < pt1.X + accuracy And point.Y < pt1.Y + accuracy And point.Y > pt1.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        Else
            If shape(0).X = shape(1).X Then
                grad1 = 1
            Else
                grad1 = (shape(0).Y - shape(1).Y) / (shape(0).X - shape(1).X)
            End If
            For i = 0 To (shape(0).X - shape(1).X)
                pt1.X = i + shape(1).X
                pt1.Y = grad1 * i + shape(1).Y
                If point.X > pt1.X - accuracy And point.X < pt1.X + accuracy And point.Y < pt1.Y + accuracy And point.Y > pt1.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        End If

        If shape(2).X > shape(3).X Then
            If shape(2).X = shape(3).X Then
                grad1 = 1
            Else
                grad2 = (shape(2).Y - shape(3).Y) / (shape(2).X - shape(3).X)
            End If
            For i = 0 To (shape(2).X - shape(3).X)
                pt2.X = i + shape(3).X
                pt2.Y = grad2 * i + shape(3).Y
                If point.X > pt2.X - accuracy And point.X < pt2.X + accuracy And point.Y < pt2.Y + accuracy And point.Y > pt2.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        Else
            If shape(3).X = shape(2).X Then
                grad1 = 1
            Else
                grad2 = (shape(3).Y - shape(2).Y) / (shape(3).X - shape(2).X)
            End If
            For i = 0 To (shape(3).X - shape(2).X)
                pt2.X = i + shape(2).X
                pt2.Y = grad2 * i + shape(2).Y
                If point.X > pt2.X - accuracy And point.X < pt2.X + accuracy And point.Y < pt2.Y + accuracy And point.Y > pt2.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        End If

        If shape(0).X > shape(3).X Then
            If shape(0).X = shape(3).X Then
                grad1 = 1
            Else
                grad3 = (shape(0).Y - shape(3).Y) / (shape(0).X - shape(3).X)
            End If
            For i = 0 To (shape(0).X - shape(3).X)
                pt3.X = i + shape(3).X
                pt3.Y = grad3 * i + shape(3).Y
                If point.X > pt3.X - accuracy And point.X < pt3.X + accuracy And point.Y < pt3.Y + accuracy And point.Y > pt3.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        Else
            If shape(0).X = shape(3).X Then
                grad1 = 1
            Else
                grad3 = (shape(3).Y - shape(0).Y) / (shape(3).X - shape(0).X)
            End If
            For i = 0 To (shape(3).X - shape(0).X)
                pt3.X = i + shape(0).X
                pt3.Y = grad3 * i + shape(0).Y
                If point.X > pt3.X - accuracy And point.X < pt3.X + accuracy And point.Y < pt3.Y + accuracy And point.Y > pt3.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        End If

        If shape(1).X > shape(2).X Then
            If shape(2).X = shape(1).X Then
                grad1 = 1
            Else
                grad4 = (shape(1).Y - shape(2).Y) / (shape(1).X - shape(2).X)
            End If
            For i = 0 To (shape(1).X - shape(2).X)
                pt4.X = i + shape(2).X
                pt4.Y = grad4 * i + shape(2).Y
                If point.X > pt4.X - accuracy And point.X < pt4.X + accuracy And point.Y < pt4.Y + accuracy And point.Y > pt4.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        Else
            If shape(2).X = shape(1).X Then
                grad1 = 1
            Else
                grad4 = (shape(2).Y - shape(1).Y) / (shape(2).X - shape(1).X)
            End If
            For i = 0 To (shape(2).X - shape(1).X)
                pt4.X = i + shape(1).X
                pt4.Y = grad4 * i + shape(1).Y
                If point.X > pt4.X - accuracy And point.X < pt4.X + accuracy And point.Y < pt4.Y + accuracy And point.Y > pt4.Y - accuracy Then
                    Return True
                    Exit Function
                End If
            Next
        End If

            Return False

    End Function

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        frames = frames + 1
        Me.Refresh()

    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick

        Label11.Text = "FPS = " & frames
        frames = 0

    End Sub

    Function round(number As Single, decimalplaces As Integer) As Single

        Dim int As Integer

        int = number * (10 ^ decimalplaces)
        round = int / (10 ^ decimalplaces)

    End Function

End Class

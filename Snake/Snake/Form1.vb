Public Class Form1

    Dim direction, food As Point
    Dim snake() As Point
    Dim foodexists As Boolean
    Dim foodtime, foodcollected As Integer
    Dim foodx, foody As Single
    Dim background As Bitmap

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Timer1.Interval = 100
        Timer1.Enabled = True
        direction = New Point(1, 0)
        snake = {New Point(-1, 0), New Point(0, 0)}
        foodexists = False
        foodtime = 0
        food = New Point(0, 0)
        foodcollected = 0

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        Randomize()

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If foodexists And food = snake(0) Then
            foodcollected = foodcollected + 1
            foodexists = False
            ReDim Preserve snake(0 To UBound(snake) + 1)
            snake(UBound(snake)) = snake(UBound(snake) - 1)
        End If

        For i = 1 To UBound(snake)
            snake(UBound(snake) + 1 - i) = snake(UBound(snake) - i)
        Next
        snake(0) = New Point(snake(0).X + direction.X, snake(0).Y + direction.Y)

        If foodtime > 10 Then
            foodx = (Rnd() - 0.5) * 14
            foody = (Rnd() - 0.5) * 14
            food = New Point(foodx, foody)
            foodtime = 0
            foodexists = True
        End If

        If foodexists = False Then
            foodtime = foodtime + 1
        End If

        For i = 0 To UBound(snake) - 1
            For j = i + 1 To UBound(snake)
                If snake(i) = snake(j) Then
                    Timer1.Enabled = False
                    MsgBox("Game Over")
                    newgame()
                    Exit For
                End If
            Next
        Next

finish:
        Me.Refresh()

    End Sub

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.S And direction <> New Point(0, -1) Then
            direction = New Point(0, 1)
        ElseIf e.KeyCode = Keys.W And direction <> New Point(0, 1) Then
            direction = New Point(0, -1)
        ElseIf e.KeyCode = Keys.A And direction <> New Point(1, 0) Then
            direction = New Point(-1, 0)
        ElseIf e.KeyCode = Keys.D And direction <> New Point(-1, 0) Then
            direction = New Point(1, 0)
        End If

    End Sub

    Function coordtopoint(coord As Point) As Point

        coordtopoint = New Point(roundtonearest(coord.X * 10, 10) + 150, roundtonearest(coord.Y * 10, 10) + 150)

    End Function

    Function roundtonearest(numbertoround As Single, roundto As Integer) As Integer

        Dim int As Integer = (numbertoround / roundto)
        roundtonearest = int * roundto

    End Function

    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        Dim bod, hed, body, head As Bitmap
        bod = New Bitmap(10, 10)
        hed = New Bitmap(10, 10)
        body = New Bitmap(My.Resources.body)
        If direction = New Point(0, -1) Then
            head = New Bitmap(My.Resources.head_down)
        ElseIf direction = New Point(0, 1) Then
            head = New Bitmap(My.Resources.head_up)
        ElseIf direction = New Point(1, 0) Then
            head = New Bitmap(My.Resources.head_right)
        Else
            head = New Bitmap(My.Resources.head_left)
        End If

        For i = 0 To 9
            For j = 0 To 9
                Dim colhed, colbod As Color
                colhed = head.GetPixel(i, j)
                colbod = body.GetPixel(i, j)
                If colhed.GetBrightness < 0.9 Then
                    hed.SetPixel(i, j, colhed)
                End If
                If colbod.GetBrightness < 0.9 Then
                    bod.SetPixel(i, j, colbod)
                End If
            Next
        Next

        If IsNothing(background) Then
            background = New Bitmap(ClientRectangle.Width, ClientRectangle.Height)
        End If
        Dim g As Graphics = Graphics.FromImage(background)

        g.DrawImage(My.Resources.BostonIvy1280, 0, 0, ClientRectangle.Width, ClientRectangle.Height)

        g.DrawImage(hed, coordtopoint(snake(0)).X, coordtopoint(snake(0)).Y, 10, 10)
        For i = 1 To UBound(snake)
            g.DrawImage(bod, coordtopoint(snake(i)).X, coordtopoint(snake(i)).Y, 10, 10)
        Next

        If foodexists Then
            g.FillPie(Brushes.Red, coordtopoint(food).X, coordtopoint(food).Y, 10, 10, 0, 360)
        End If


        e.Graphics.DrawImageUnscaled(background, 0, 0)

    End Sub

    Sub newgame()

        Timer1.Enabled = False
        Timer1.Interval = 100
        Timer1.Enabled = True
        direction = New Point(1, 0)
        snake = {New Point(-1, 0), New Point(0, 0)}
        foodexists = False
        foodtime = 0
        food = New Point(0, 0)
        foodcollected = 0

        Randomize()

    End Sub

End Class

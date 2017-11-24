Public Class Form1

    Dim ss, lx, ly, row, column As Integer
    Dim space(6, 5) As Integer
    Dim player1turn As Boolean
    Dim player1pieces(0 To 0), player2pieces(0 To 0) As Point
    Dim connect As Integer = 4
    Dim rownumbers(0 To 0), columnnumbers(0 To 0) As Integer
    Dim player1wins, player2wins, commove As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        ss = 30
        lx = ((ClientRectangle.Width) * 0.5) - (0.5 * (ss * 7))
        ly = ((ClientRectangle.Height - (Button1.Location.Y + Button1.Height)) * 0.5) - (0.5 * (ss * 6)) + (Button1.Location.Y + Button1.Height)

        '0 refers to empty space
        '1 is player 1 piece
        '2 is player 2 piece
        For i = 0 To 6
            For j = 0 To 5
                space(i, j) = 0
            Next
        Next

        player1turn = True
        commove = 0
        inputmouse = True

    End Sub

    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        If inputmouse Then
            If column >= 1 And column <= 7 And row >= 1 And row <= 6 Then
                For i = 0 To 5
                    If space(column - 1, 5 - i) = 0 Then
                        Dim thickpen As New Pen(Brushes.Black)
                        thickpen.Width = 5
                        e.Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height)
                        e.Graphics.DrawRectangle(thickpen, lx + (column - 1) * ss, ly + (5 - i) * ss, ss, ss)
                        freespace = New Point(column - 1, 5 - i)
                        Exit For
                    End If
                Next
            Else
                e.Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height)
            End If
        Else
            Dim thickpen As New Pen(Brushes.Black)
            thickpen.Width = 5
            e.Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height)
            e.Graphics.DrawRectangle(thickpen, lx + (freespace.X) * ss, ly + (freespace.Y) * ss, ss, ss)
        End If

        If UBound(player1pieces) > 0 Then
            For i = 0 To UBound(player1pieces) - 1
                e.Graphics.FillRectangle(Brushes.Green, lx + player1pieces(i).X * ss, ly + player1pieces(i).Y * ss, ss, ss)
            Next
        End If
        If UBound(player2pieces) > 0 Then
            For i = 0 To UBound(player2pieces) - 1
                e.Graphics.FillRectangle(Brushes.Red, lx + player2pieces(i).X * ss, ly + player2pieces(i).Y * ss, ss, ss)
            Next
        End If

        For i = 0 To 6
            e.Graphics.DrawLine(Pens.Black, New Point(lx, ly + ss * i), New Point(lx + 7 * ss, ly + ss * i))
        Next
        For i = 0 To 7
            e.Graphics.DrawLine(Pens.Black, New Point(lx + ss * i, ly), New Point(lx + ss * i, ly + 6 * ss))
        Next

        If player1turn Then
            Label2.BackColor = Color.LightGreen
            Label2.Text = "Player 1 (Green)"
        Else
            Label2.BackColor = Color.Red
            Label2.Text = "Player 2 (Red)"
        End If

        Label5.Text = "Scoreboard =>  P1: " & player1wins & " , P2: " & player2wins

    End Sub

    Private Sub Form1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        If inputmouse Then
            If e.Y > ly And e.Y < ly + 6 * ss And e.X > lx And e.X < lx + 7 * ss Then
                If e.X > lx And e.X < lx + ss Then
                    column = 1
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + ss And e.X < lx + 2 * ss Then
                    column = 2
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + 2 * ss And e.X < lx + 3 * ss Then
                    column = 3
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + 3 * ss And e.X < lx + 4 * ss Then
                    column = 4
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + 4 * ss And e.X < lx + 5 * ss Then
                    column = 5
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + 5 * ss And e.X < lx + 6 * ss Then
                    column = 6
                    Label3.Text = "Column " & column
                ElseIf e.X > lx + 6 * ss And e.X < lx + 7 * ss Then
                    column = 7
                    Label3.Text = "Column " & column
                End If
            Else
                column = 0
                Label3.Text = "Not in there"
            End If

            If e.Y > ly And e.Y < ly + 6 * ss And e.X > lx And e.X < lx + 7 * ss Then
                If e.Y > ly And e.Y < ly + ss Then
                    row = 1
                    Label4.Text = "Row " & 7 - row
                ElseIf e.Y > ly + ss And e.Y < ly + 2 * ss Then
                    row = 2
                    Label4.Text = "Row " & 7 - row
                ElseIf e.Y > ly + 2 * ss And e.Y < ly + 3 * ss Then
                    row = 3
                    Label4.Text = "Row " & 7 - row
                ElseIf e.Y > ly + 3 * ss And e.Y < ly + 4 * ss Then
                    row = 4
                    Label4.Text = "Row " & 7 - row
                ElseIf e.Y > ly + 4 * ss And e.Y < ly + 5 * ss Then
                    row = 5
                    Label4.Text = "Row " & 7 - row
                ElseIf e.Y > ly + 5 * ss And e.Y < ly + 6 * ss Then
                    row = 6
                    Label4.Text = "Row " & 7 - row
                End If
            Else
                row = 0
                Label4.Text = "Not in there"
            End If

            Me.Refresh()
        End If

    End Sub

    Private Sub Form1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        If inputmouse Then
            If player1turn Then
                player1pieces(UBound(player1pieces)) = New Point(freespace.X, freespace.Y)
                ReDim Preserve player1pieces(0 To UBound(player1pieces) + 1)
                space(freespace.X, freespace.Y) = 1
                If checkwin(player1pieces) Then
                    player1wins = player1wins + 1
                    Me.Refresh()
                    MsgBox("Player 1 Wins")
                    newgame()
                End If
                player1turn = False
            Else
                player2pieces(UBound(player2pieces)) = New Point(freespace.X, freespace.Y)
                ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                space(freespace.X, freespace.Y) = 2
                If checkwin(player2pieces) Then
                    player2wins = player2wins + 1
                    Me.Refresh()
                    MsgBox("Player 2 Wins")
                    newgame()
                End If
                player1turn = True
            End If

            Me.Refresh()
            If computerplayer Then
                ComputerTurn()
                Me.Refresh()
            End If
        End If

    End Sub

    Function checkwin(pieces() As Point) As Boolean

        Dim number As Integer = 0
        Dim p1, p2, p3, p4 As Boolean
        p1 = False
        p2 = False
        p3 = False
        p4 = False

        'Columns
        For i = 0 To 6
            For p = 0 To UBound(pieces) - 1
                If pieces(p).Y = 0 And pieces(p).X = i Then
                    p1 = True
                End If
                If pieces(p).Y = 1 And pieces(p).X = i Then
                    p2 = True
                End If
                If pieces(p).Y = 2 And pieces(p).X = i Then
                    p3 = True
                End If
                If pieces(p).Y = 3 And pieces(p).X = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
            For p = 0 To UBound(pieces) - 1
                If pieces(p).Y = 1 And pieces(p).X = i Then
                    p1 = True
                End If
                If pieces(p).Y = 2 And pieces(p).X = i Then
                    p2 = True
                End If
                If pieces(p).Y = 3 And pieces(p).X = i Then
                    p3 = True
                End If
                If pieces(p).Y = 4 And pieces(p).X = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
            For p = 0 To UBound(pieces) - 1
                If pieces(p).Y = 2 And pieces(p).X = i Then
                    p1 = True
                End If
                If pieces(p).Y = 3 And pieces(p).X = i Then
                    p2 = True
                End If
                If pieces(p).Y = 4 And pieces(p).X = i Then
                    p3 = True
                End If
                If pieces(p).Y = 5 And pieces(p).X = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next

        'Rows
        For i = 0 To 5
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 0 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 1 And pieces(p).Y = i Then
                    p2 = True
                End If
                If pieces(p).X = 2 And pieces(p).Y = i Then
                    p3 = True
                End If
                If pieces(p).X = 3 And pieces(p).Y = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 1 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 2 And pieces(p).Y = i Then
                    p2 = True
                End If
                If pieces(p).X = 3 And pieces(p).Y = i Then
                    p3 = True
                End If
                If pieces(p).X = 4 And pieces(p).Y = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 2 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 3 And pieces(p).Y = i Then
                    p2 = True
                End If
                If pieces(p).X = 4 And pieces(p).Y = i Then
                    p3 = True
                End If
                If pieces(p).X = 5 And pieces(p).Y = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 3 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 4 And pieces(p).Y = i Then
                    p2 = True
                End If
                If pieces(p).X = 5 And pieces(p).Y = i Then
                    p3 = True
                End If
                If pieces(p).X = 6 And pieces(p).Y = i Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next

        'Diagonals
        For i = 0 To 2
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = i + 1 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = i + 2 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = i + 3 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 2
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i + 1 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = i + 2 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = i + 3 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = i + 4 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 1
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i + 2 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = i + 3 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = i + 4 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = i + 5 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 0
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i + 3 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = i + 4 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = i + 5 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = i + 6 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 1
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i And pieces(p).Y = i + 1 Then
                    p1 = True
                End If
                If pieces(p).X = i + 1 And pieces(p).Y = i + 2 Then
                    p2 = True
                End If
                If pieces(p).X = i + 2 And pieces(p).Y = i + 3 Then
                    p3 = True
                End If
                If pieces(p).X = i + 3 And pieces(p).Y = i + 4 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 0
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = i And pieces(p).Y = i + 2 Then
                    p1 = True
                End If
                If pieces(p).X = i + 1 And pieces(p).Y = i + 3 Then
                    p2 = True
                End If
                If pieces(p).X = i + 2 And pieces(p).Y = i + 4 Then
                    p3 = True
                End If
                If pieces(p).X = i + 3 And pieces(p).Y = i + 5 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next

        'opposite diagonals
        For i = 0 To 2
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 1 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 2 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 2
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i - 1 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 2 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 4 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 1
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i - 2 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 4 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 5 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 0
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 4 And pieces(p).Y = i + 1 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 5 And pieces(p).Y = i + 2 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 6 And pieces(p).Y = i + 3 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 1
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i And pieces(p).Y = i + 1 Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 1 And pieces(p).Y = i + 2 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 2 And pieces(p).Y = i + 3 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i + 4 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next
        For i = 0 To 0
            For p = 0 To UBound(pieces) - 1
                If pieces(p).X = 6 - i And pieces(p).Y = i + 2 Then
                    p1 = True
                End If
                If pieces(p).X = 6 - i - 1 And pieces(p).Y = i + 3 Then
                    p2 = True
                End If
                If pieces(p).X = 6 - i - 2 And pieces(p).Y = i + 4 Then
                    p3 = True
                End If
                If pieces(p).X = 6 - i - 3 And pieces(p).Y = i + 5 Then
                    p4 = True
                End If
            Next
            If p1 And p2 And p3 And p4 Then
                Return True
                Exit Function
            End If
            p1 = False
            p2 = False
            p3 = False
            p4 = False
        Next

        Return False

    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If MsgBox("Are you sure you want to quit?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Me.Close()
        End If

    End Sub

    Sub newgame()

        For i = 0 To 6
            For j = 0 To 5
                space(i, j) = 0
            Next
        Next

        ReDim player1pieces(0 To 0)
        ReDim player2pieces(0 To 0)

        player1turn = True
        commove = 0

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        newgame()
        Me.Refresh()

    End Sub

    Sub ComputerTurn()

        If player1turn = False Then

            If commove = 0 Then
                If space(3, 5) = 0 Then
                    player2pieces(UBound(player2pieces)) = New Point(3, 5)
                    ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                    space(3, 5) = 2
                    If checkwin(player2pieces) Then
                        player2wins = player2wins + 1
                        MsgBox("Player 2 Wins")
                        newgame()
                    End If
                    'player1turn = True
                Else
                    player2pieces(UBound(player2pieces)) = New Point(4, 5)
                    ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                    space(4, 5) = 2
                    If checkwin(player2pieces) Then
                        player2wins = player2wins + 1
                        MsgBox("Player 2 Wins")
                        newgame()
                    End If
                    'player1turn = True
                End If
                commove = commove + 1
            ElseIf commove > 0 Then
                For i = 0 To 6
                    For j = 0 To 5
                        For p = 0 To UBound(player2pieces) - 1
                            If player2pieces(p).X = i And player2pieces(p).Y <> j And space(i, j) = 0 And checkbelow(i, j) Then
                                player2pieces(UBound(player2pieces)) = New Point(i, j)
                                ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                                If checkwin(player2pieces) Then
                                    space(i, j) = 2
                                    GoTo exitfors
                                Else
                                    player2pieces(UBound(player2pieces)) = New Point(0, 0)
                                    ReDim Preserve player2pieces(0 To UBound(player2pieces) - 1)
                                End If
                            End If
                        Next
                    Next
                Next
                For i = 0 To 6
                    For j = 0 To 5
                        For p = 0 To UBound(player1pieces) - 1
                            If player1pieces(p).X = i And player1pieces(p).Y <> j And space(i, j) = 0 And checkbelow(i, j) Then
                                player1pieces(UBound(player1pieces)) = New Point(i, j)
                                ReDim Preserve player1pieces(0 To UBound(player1pieces) + 1)
                                If checkwin(player1pieces) Then
                                    player1pieces(UBound(player1pieces) - 1) = New Point(0, 0)
                                    ReDim Preserve player1pieces(0 To UBound(player1pieces) - 1)
                                    player2pieces(UBound(player2pieces)) = New Point(i, j)
                                    ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                                    space(i, j) = 2
                                    GoTo exitfors
                                Else
                                    player1pieces(UBound(player1pieces) - 1) = New Point(0, 0)
                                    ReDim Preserve player1pieces(0 To UBound(player1pieces) - 1)
                                End If
                            End If
                        Next
                    Next
                Next
                For i = 0 To UBound(player2pieces) - 1
                    If player2pieces(i).Y >= 1 Then
                        If space(player2pieces(i).X, player2pieces(i).Y - 1) = 0 Then
                            player2pieces(UBound(player2pieces)) = New Point(player2pieces(i).X, player2pieces(i).Y - 1)
                            ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                            space(player2pieces(i).X, player2pieces(i).Y - 1) = 2
                            GoTo exitfors
                        End If
                    End If
                Next
                For j = 0 To 5
                    For i = 0 To 6
                        If space(i, 5 - j) = 0 Then
                            player2pieces(UBound(player2pieces)) = New Point(i, 5 - j)
                            ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                            space(i, 5 - j) = 2
                            GoTo exitfors
                        End If
                    Next
                Next

exitfors:
            End If

            If checkwin(player2pieces) Then
                player2wins = player2wins + 1
                Me.Refresh()
                MsgBox("Computer Wins")
                newgame()
            End If

            player1turn = True

        End If

    End Sub

    Function checkbelow(i As Integer, j As Integer) As Boolean

        If j + 1 > 5 Then
            Return True
        Else
            If space(i, j + 1) = 0 Then
                Return False
            Else
                Return True
            End If
        End If

    End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Options.Show()
    End Sub

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If inputmouse = False Then
            If player1turn Then
                If e.KeyCode = Keys.A Then
                    If freespace.X > 0 Then
                        freespace.X = freespace.X - 1
                    Else
                        freespace.X = 0
                    End If
                    For i = 0 To 5
                        If space(freespace.X, 5 - i) = 0 Then
                            freespace.Y = 5 - i
                            Exit For
                        End If
                    Next
                ElseIf e.KeyCode = Keys.D Then
                    If freespace.X < 6 Then
                        freespace.X = freespace.X + 1
                    Else
                        freespace.X = 6
                    End If
                    For i = 0 To 5
                        If space(freespace.X, 5 - i) = 0 Then
                            freespace.Y = 5 - i
                            Exit For
                        End If
                    Next
                ElseIf e.KeyCode = Keys.W Then
                    player1pieces(UBound(player1pieces)) = New Point(freespace.X, freespace.Y)
                    ReDim Preserve player1pieces(0 To UBound(player1pieces) + 1)
                    space(freespace.X, freespace.Y) = 1
                    If freespace.Y > 0 Then
                        freespace.Y = freespace.Y - 1
                    Else
                        If freespace.X > 0 Then
                            freespace.X = freespace.X - 1
                        Else
                            freespace.X = freespace.X + 1
                        End If
                    End If
                    If checkwin(player1pieces) Then
                        player1wins = player1wins + 1
                        Me.Refresh()
                        MsgBox("Player 1 Wins")
                        newgame()
                    End If
                    player1turn = False
                End If
            Else
                If e.KeyCode = Keys.J Then
                    If freespace.X > 0 Then
                        freespace.X = freespace.X - 1
                    Else
                        freespace.X = 0
                    End If
                    For i = 0 To 6
                        If space(freespace.X, 5 - i) = 0 Then
                            freespace.Y = 5 - i
                            Exit For
                        End If
                    Next
                ElseIf e.KeyCode = Keys.L Then
                    If freespace.X < 6 Then
                        freespace.X = freespace.X + 1
                    Else
                        freespace.X = 6
                    End If
                    For i = 0 To 6
                        If space(freespace.X, 5 - i) = 0 Then
                            freespace.Y = 5 - i
                            Exit For
                        End If
                    Next
                ElseIf e.KeyCode = Keys.I Then
                    player2pieces(UBound(player2pieces)) = New Point(freespace.X, freespace.Y)
                    ReDim Preserve player2pieces(0 To UBound(player2pieces) + 1)
                    space(freespace.X, freespace.Y) = 2
                    If freespace.Y > 0 Then
                        freespace.Y = freespace.Y - 1
                    Else
                        If freespace.X > 0 Then
                            freespace.X = freespace.X - 1
                        Else
                            freespace.X = freespace.X + 1
                        End If
                    End If
                    If checkwin(player2pieces) Then
                        player2wins = player2wins + 1
                        Me.Refresh()
                        MsgBox("Player 2 Wins")
                        newgame()
                    End If
                    player1turn = True
                End If
            End If
        End If

        Me.Refresh()
        If computerplayer Then
            ComputerTurn()
            Me.Refresh()
        End If

    End Sub

End Class

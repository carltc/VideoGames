Public Class ChessBoard

    Dim allcells(), whites(), blacks() As Point
    Dim bk, bq, bkn1, bkn2, bb1, bb2, br1, br2, bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8 As position
    Dim wk, wq, wkn1, wkn2, wb1, wb2, wr1, wr2, wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8 As position
    Dim blackpieces(), whitepieces() As position
    Dim blpc(), whpc() As PictureBox
    Dim mousepoint, originalpoint As Point
    Dim mouseisdown As Boolean = False
    Dim possible(), takepossible() As Point
    Dim blackturn, check As Boolean

    Private Sub ChessBoard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        blackturn = False

        Do
            If ClientRectangle.Width > 700 Then
                Me.Width = Me.Width - 1
            ElseIf ClientRectangle.Width < 700 Then
                Me.Width = Me.Width + 1
            End If
        Loop Until Me.ClientRectangle.Width = 700
        Do
            If ClientRectangle.Height > 700 Then
                Me.Height = Me.Height - 1
            ElseIf ClientRectangle.Height < 700 Then
                Me.Height = Me.Height + 1
            End If
        Loop Until Me.ClientRectangle.Height = 700
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2)

        ReDim allcells(0 To 63)
        For i = 0 To 7
            For j = 0 To 7
                allcells((i * 8) + j) = New Point(50 + (i * 75), 50 + (j * 75))
            Next
        Next

        ReDim blacks(0 To 31)
        ReDim whites(0 To 31)
        Dim w, b As Integer
        w = 0
        b = 0
        For i = 0 To 7
            If isodd(i) Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) = False Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 8 To 15
            If isodd(i) = False Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 16 To 23
            If isodd(i) Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) = False Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 24 To 31
            If isodd(i) = False Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 32 To 39
            If isodd(i) Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) = False Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 40 To 47
            If isodd(i) = False Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 48 To 55
            If isodd(i) Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) = False Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next
        For i = 56 To 63
            If isodd(i) = False Then
                whites(w) = allcells(i)
                w = w + 1
            ElseIf isodd(i) Then
                blacks(b) = allcells(i)
                b = b + 1
            End If
        Next

        br1.col = 1
        br1.row = 1
        bkn1.col = 2
        bkn1.row = 1
        bb1.col = 3
        bb1.row = 1
        bk.col = 4
        bk.row = 1
        bq.col = 5
        bq.row = 1
        bb2.col = 6
        bb2.row = 1
        bkn2.col = 7
        bkn2.row = 1
        br2.col = 8
        br2.row = 1

        bp1.col = 1
        bp1.row = 2
        bp2.col = 2
        bp2.row = 2
        bp3.col = 3
        bp3.row = 2
        bp4.col = 4
        bp4.row = 2
        bp5.col = 5
        bp5.row = 2
        bp6.col = 6
        bp6.row = 2
        bp7.col = 7
        bp7.row = 2
        bp8.col = 8
        bp8.row = 2

        wr1.col = 1
        wr1.row = 8
        wkn1.col = 2
        wkn1.row = 8
        wb1.col = 3
        wb1.row = 8
        wk.col = 4
        wk.row = 8
        wq.col = 5
        wq.row = 8
        wb2.col = 6
        wb2.row = 8
        wkn2.col = 7
        wkn2.row = 8
        wr2.col = 8
        wr2.row = 8

        wp1.col = 1
        wp1.row = 7
        wp2.col = 2
        wp2.row = 7
        wp3.col = 3
        wp3.row = 7
        wp4.col = 4
        wp4.row = 7
        wp5.col = 5
        wp5.row = 7
        wp6.col = 6
        wp6.row = 7
        wp7.col = 7
        wp7.row = 7
        wp8.col = 8
        wp8.row = 7

        ReDim blackpieces(0 To 15)
        blackpieces = {bk, bq, bkn1, bkn2, bb1, bb2, br1, br2, bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8}
        blackpieces(0).piece = "blackking"
        blackpieces(1).piece = "blackqueen"
        blackpieces(2).piece = "blackknight"
        blackpieces(3).piece = "blackknight"
        blackpieces(4).piece = "blackbishop"
        blackpieces(5).piece = "blackbishop"
        blackpieces(6).piece = "blackrook"
        blackpieces(7).piece = "blackrook"
        For i = 8 To 15
            blackpieces(i).piece = "blackpawn"
        Next

        ReDim blpc(0 To 0)
        For i = 0 To UBound(blackpieces)
            Dim picbox As New PictureBox
            picbox.Size = New Size(32, 32)
            picbox.Location = blackpieces(i).toposchar
            If blackpieces(i).piece = "blackking" Then
                picbox.Image = changepic(My.Resources._12_King_icon)
                picbox.Name = "blackking"
            ElseIf blackpieces(i).piece = "blackqueen" Then
                picbox.Image = changepic(My.Resources._11_Queen_icon)
                picbox.Name = "blackqueen"
            ElseIf blackpieces(i).piece = "blackbishop" Then
                picbox.Image = changepic(My.Resources._10_Bishop_icon)
                picbox.Name = "blackbishop"
            ElseIf blackpieces(i).piece = "blackknight" Then
                picbox.Image = changepic(My.Resources._09_Knight_icon)
                picbox.Name = "blackknight"
            ElseIf blackpieces(i).piece = "blackrook" Then
                picbox.Image = changepic(My.Resources._08_Castle_icon)
                picbox.Name = "blackrook"
            ElseIf blackpieces(i).piece = "blackpawn" Then
                picbox.Image = changepic(My.Resources._07_Pone_icon)
                picbox.Name = "blackpawn"
            End If
            If isodd(blackpieces(i).col) Then
                If isodd(blackpieces(i).row) Then
                    picbox.BackColor = Color.Gray
                End If
            ElseIf isodd(blackpieces(i).col) = False Then
                If isodd(blackpieces(i).row) = False Then
                    picbox.BackColor = Color.Gray
                End If
            End If
            AddHandler picbox.MouseDown, AddressOf picboxdown
            AddHandler picbox.MouseMove, AddressOf picboxmove
            AddHandler picbox.MouseUp, AddressOf picboxup
            blpc(UBound(blpc)) = picbox
            ReDim Preserve blpc(0 To UBound(blpc) + 1)
            Me.Controls.Add(picbox)
        Next

        ReDim whitepieces(0 To 15)
        whitepieces = {wk, wq, wkn1, wkn2, wb1, wb2, wr1, wr2, wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8}
        whitepieces(0).piece = "whiteking"
        whitepieces(1).piece = "whitequeen"
        whitepieces(2).piece = "whiteknight"
        whitepieces(3).piece = "whiteknight"
        whitepieces(4).piece = "whitebishop"
        whitepieces(5).piece = "whitebishop"
        whitepieces(6).piece = "whiterook"
        whitepieces(7).piece = "whiterook"
        For i = 8 To 15
            whitepieces(i).piece = "whitepawn"
        Next

        ReDim whpc(0 To 0)
        For i = 0 To UBound(whitepieces)
            Dim picbox As New PictureBox
            picbox.Size = New Size(32, 32)
            picbox.Location = whitepieces(i).toposchar
            If whitepieces(i).piece = "whiteking" Then
                picbox.Image = changepic(My.Resources._06_King_icon)
                picbox.Name = "whiteking"
            ElseIf whitepieces(i).piece = "whitequeen" Then
                picbox.Image = changepic(My.Resources._05_Queen_icon)
                picbox.Name = "whitequeen"
            ElseIf whitepieces(i).piece = "whitebishop" Then
                picbox.Image = changepic(My.Resources._04_Bishop_icon)
                picbox.Name = "whitebishop"
            ElseIf whitepieces(i).piece = "whiteknight" Then
                picbox.Image = changepic(My.Resources._03_Knight_icon)
                picbox.Name = "whiteknight"
            ElseIf whitepieces(i).piece = "whiterook" Then
                picbox.Image = changepic(My.Resources._02_Castle_icon)
                picbox.Name = "whiterook"
            ElseIf whitepieces(i).piece = "whitepawn" Then
                picbox.Image = changepic(My.Resources._01_Pone_icon)
                picbox.Name = "whitepawn"
            End If
            If isodd(whitepieces(i).col) Then
                If isodd(whitepieces(i).row) Then
                    picbox.BackColor = Color.Gray
                End If
            ElseIf isodd(whitepieces(i).col) = False Then
                If isodd(whitepieces(i).row) = False Then
                    picbox.BackColor = Color.Gray
                End If
            End If
            AddHandler picbox.MouseDown, AddressOf picboxdown
            AddHandler picbox.MouseMove, AddressOf picboxmove
            AddHandler picbox.MouseUp, AddressOf picboxup
            whpc(UBound(whpc)) = picbox
            ReDim Preserve whpc(0 To UBound(whpc) + 1)
            Me.Controls.Add(picbox)
        Next

        Me.Refresh()

    End Sub

    Private Sub ChessBoard_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        Dim p1 As Point

        For i = 0 To UBound(blacks)
            p1 = New Point(blacks(i).X, blacks(i).Y)
            e.Graphics.FillRectangle(Brushes.Gray, p1.X, p1.Y, 75, 75)
        Next

        e.Graphics.DrawLine(Pens.Black, New Point(50, 50), New Point(50, 50 + (75 * 8)))
        e.Graphics.DrawLine(Pens.Black, New Point(50, 50), New Point(50 + (75 * 8), 50))
        e.Graphics.DrawLine(Pens.Black, New Point(50 + (75 * 8), 50 + (75 * 8)), New Point(50, 50 + (75 * 8)))
        e.Graphics.DrawLine(Pens.Black, New Point(50 + (75 * 8), 50), New Point(50 + (75 * 8), 50 + (75 * 8)))
        e.Graphics.DrawString("A", DefaultFont, Brushes.Black, New Point(88, 38))
        e.Graphics.DrawString("B", DefaultFont, Brushes.Black, New Point(88 + 75, 38))
        e.Graphics.DrawString("C", DefaultFont, Brushes.Black, New Point(88 + 150, 38))
        e.Graphics.DrawString("D", DefaultFont, Brushes.Black, New Point(88 + 225, 38))
        e.Graphics.DrawString("E", DefaultFont, Brushes.Black, New Point(88 + 300, 38))
        e.Graphics.DrawString("F", DefaultFont, Brushes.Black, New Point(88 + 375, 38))
        e.Graphics.DrawString("G", DefaultFont, Brushes.Black, New Point(88 + 450, 38))
        e.Graphics.DrawString("H", DefaultFont, Brushes.Black, New Point(88 + 525, 38))
        e.Graphics.DrawString("A", DefaultFont, Brushes.Black, New Point(88, 38 + 615))
        e.Graphics.DrawString("B", DefaultFont, Brushes.Black, New Point(88 + 75, 38 + 615))
        e.Graphics.DrawString("C", DefaultFont, Brushes.Black, New Point(88 + 150, 38 + 615))
        e.Graphics.DrawString("D", DefaultFont, Brushes.Black, New Point(88 + 225, 38 + 615))
        e.Graphics.DrawString("E", DefaultFont, Brushes.Black, New Point(88 + 300, 38 + 615))
        e.Graphics.DrawString("F", DefaultFont, Brushes.Black, New Point(88 + 375, 38 + 615))
        e.Graphics.DrawString("G", DefaultFont, Brushes.Black, New Point(88 + 450, 38 + 615))
        e.Graphics.DrawString("H", DefaultFont, Brushes.Black, New Point(88 + 525, 38 + 615))

        e.Graphics.DrawString("1", DefaultFont, Brushes.Black, New Point(38, 88))
        e.Graphics.DrawString("2", DefaultFont, Brushes.Black, New Point(38, 88 + 75))
        e.Graphics.DrawString("3", DefaultFont, Brushes.Black, New Point(38, 88 + 150))
        e.Graphics.DrawString("4", DefaultFont, Brushes.Black, New Point(38, 88 + 225))
        e.Graphics.DrawString("5", DefaultFont, Brushes.Black, New Point(38, 88 + 300))
        e.Graphics.DrawString("6", DefaultFont, Brushes.Black, New Point(38, 88 + 375))
        e.Graphics.DrawString("7", DefaultFont, Brushes.Black, New Point(38, 88 + 450))
        e.Graphics.DrawString("8", DefaultFont, Brushes.Black, New Point(38, 88 + 525))
        e.Graphics.DrawString("1", DefaultFont, Brushes.Black, New Point(38 + 615, 88))
        e.Graphics.DrawString("2", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 75))
        e.Graphics.DrawString("3", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 150))
        e.Graphics.DrawString("4", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 225))
        e.Graphics.DrawString("5", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 300))
        e.Graphics.DrawString("6", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 375))
        e.Graphics.DrawString("7", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 450))
        e.Graphics.DrawString("8", DefaultFont, Brushes.Black, New Point(38 + 615, 88 + 525))

        If showpossiblemoves Then
            If IsNothing(possible) = False Then
                If UBound(possible) > 0 Then
                    For i = 0 To UBound(possible) - 1
                        Dim p As New Point
                        Dim pen As New Pen(Brushes.Green)
                        pen.Width = 5
                        p = coordtopos(possible(i))
                        If p.X > 650 Or p.X < 50 Or p.Y < 50 Or p.Y > 650 Then
                        Else
                            e.Graphics.DrawRectangle(pen, p.X, p.Y, 32, 32)
                        End If
                    Next
                End If
            End If

            If IsNothing(takepossible) = False Then
                If UBound(takepossible) > 0 Then
                    For i = 0 To UBound(takepossible) - 1
                        Dim p As New Point
                        Dim pen As New Pen(Brushes.Red)
                        pen.Width = 5
                        p = coordtopos(takepossible(i))
                        If p.X > 650 Or p.X < 50 Or p.Y < 50 Or p.Y > 650 Then
                        Else
                            e.Graphics.DrawRectangle(pen, p.X, p.Y, 32, 32)
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Function isodd(value As Single)

        Dim val As Single
        Dim ival As Integer
        val = value / 2
        ival = value / 2
        If val - ival <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub picboxdown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If isblack(sender.name) And blackturn = False Then
            Exit Sub
        ElseIf isblack(sender.name) = False And blackturn Then
            Exit Sub
        End If

        mouseisdown = True
        originalpoint = coordtopos(findcoord(mousepoint.X, mousepoint.Y))

        If sender.name = "blackking" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
        ElseIf sender.name = "blackqueen" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        ElseIf sender.name = "blackpawn" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            If findcoord(sender.location.x, sender.location.y).Y = 2 Then
                For i = 1 To 2
                    possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                    possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                    If inwayb(possible(UBound(possible))) = False And inwayw(possible(UBound(possible))) = False Then
                        ReDim Preserve possible(0 To UBound(possible) + 1)
                    Else
                        Exit For
                    End If
                Next
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
            Else
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
                If inwayb(possible(UBound(possible))) = False And inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
            End If
        ElseIf sender.name = "blackknight" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 2
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 2
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 2
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 2
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayw(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayb(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
        ElseIf sender.name = "blackbishop" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        ElseIf sender.name = "blackrook" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayw(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        ElseIf sender.name = "whiteking" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
        ElseIf sender.name = "whitequeen" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        ElseIf sender.name = "whitepawn" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            If findcoord(sender.location.x, sender.location.y).Y = 7 Then
                For i = 1 To 2
                    possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                    possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                    If inwayw(possible(UBound(possible))) = False And inwayb(possible(UBound(possible))) = False Then
                        ReDim Preserve possible(0 To UBound(possible) + 1)
                    Else
                        Exit For
                    End If
                Next
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
            Else
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
                If inwayw(possible(UBound(possible))) = False And inwayb(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                End If
            End If
        ElseIf sender.name = "whiteknight" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 2
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 2
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 2
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 1
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 2
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
            possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - 2
            possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - 1
            If inwayb(possible(UBound(possible))) Then
                takepossible(UBound(takepossible)) = possible(UBound(possible))
                ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
            ElseIf inwayw(possible(UBound(possible))) = False Then
                ReDim Preserve possible(0 To UBound(possible) + 1)
            End If
        ElseIf sender.name = "whitebishop" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        ElseIf sender.name = "whiterook" Then
            ReDim possible(0 To 0)
            ReDim takepossible(0 To 0)
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y - i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y + i
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X - i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
            For i = 1 To 7
                possible(UBound(possible)).X = findcoord(sender.location.x, sender.location.y).X + i
                possible(UBound(possible)).Y = findcoord(sender.location.x, sender.location.y).Y
                If inwayb(possible(UBound(possible))) Then
                    takepossible(UBound(takepossible)) = possible(UBound(possible))
                    ReDim Preserve takepossible(0 To UBound(takepossible) + 1)
                    Exit For
                ElseIf inwayw(possible(UBound(possible))) = False Then
                    ReDim Preserve possible(0 To UBound(possible) + 1)
                Else
                    Exit For
                End If
            Next
        End If

        Me.Refresh()

    End Sub

    Sub picboxmove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If isblack(sender.name) And blackturn = False Then
            Exit Sub
        ElseIf isblack(sender.name) = False And blackturn Then
            Exit Sub
        End If

        mousepoint = New Point(sender.location.x + e.X, sender.location.y + e.Y)

        If mouseisdown Then
            sender.location = mousepoint
        End If

        'Label1.Text = findcoord(mousepoint.X, mousepoint.Y).ToString

    End Sub

    Sub picboxup(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If isblack(sender.name) And blackturn = False Then
            Exit Sub
        ElseIf isblack(sender.name) = False And blackturn Then
            Exit Sub
        End If

        If sender.name = "blackking" Or sender.name = "whiteking" Then
            If isblack(sender.name) Then
                For i = 0 To UBound(whpc) - 1
                    If ischeck(whpc(i).Name, whpc(i).Location) Then
                        sender.location = originalpoint
                        'If blackturn = False Then
                        '    blackturn = True
                        'Else
                        '    blackturn = False
                        'End If
                        ReDim possible(0 To 0)
                        ReDim takepossible(0 To 0)
                        mouseisdown = False
                        Exit Sub
                    End If
                Next
            Else
                For i = 0 To UBound(blpc) - 1
                    If ischeck(blpc(i).Name, blpc(i).Location) Then
                        sender.location = originalpoint
                        'If blackturn = False Then
                        '    blackturn = True
                        'Else
                        '    blackturn = False
                        'End If
                        ReDim possible(0 To 0)
                        ReDim takepossible(0 To 0)
                        mouseisdown = False
                        Exit Sub
                    End If
                Next
            End If
        End If

        If isodd(findcoord(mousepoint.X, mousepoint.Y).X) Then
            If isodd(findcoord(mousepoint.X, mousepoint.Y).Y) Then
                sender.BackColor = Color.Gray
            Else
                sender.backcolor = Nothing
            End If
        ElseIf isodd(findcoord(mousepoint.X, mousepoint.Y).X) = False Then
            If isodd(findcoord(mousepoint.X, mousepoint.Y).Y) = False Then
                sender.BackColor = Color.Gray
            Else
                sender.backcolor = Nothing
            End If
        End If
        If IsNothing(possible) = False And IsNothing(takepossible) = False Then
            If UBound(possible) > 0 And ispossible(mousepoint) Then
                sender.location = coordtopos(findcoord(mousepoint.X, mousepoint.Y))
                If blackturn = False Then
                    blackturn = True
                Else
                    blackturn = False
                End If
                If ischeck(sender.name, sender.location) Then
                    MsgBox("Check")
                End If
            ElseIf UBound(takepossible) > 0 And istake(mousepoint) Then
                sender.location = coordtopos(findcoord(mousepoint.X, mousepoint.Y))
                If blackturn = False Then
                    blackturn = True
                Else
                    blackturn = False
                End If
                If ischeck(sender.name, sender.location) Then
                    MsgBox("Check")
                End If
                If isblack(sender.name) = False Then
                    For i = 0 To UBound(blpc) - 1
                        If findcoord(blpc(i).Location.X, blpc(i).Location.Y) = findcoord(mousepoint.X, mousepoint.Y) Then
                            blpc(i).Dispose()
                            For j = i To UBound(blpc) - 1
                                blpc(j) = blpc(j + 1)
                            Next
                            ReDim Preserve blpc(0 To UBound(blpc) - 1)
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To UBound(whpc) - 1
                        If findcoord(whpc(i).Location.X, whpc(i).Location.Y) = findcoord(mousepoint.X, mousepoint.Y) Then
                            whpc(i).Dispose()
                            For j = i To UBound(whpc) - 1
                                whpc(j) = whpc(j + 1)
                            Next
                            ReDim Preserve whpc(0 To UBound(whpc) - 1)
                            Exit For
                        End If
                    Next
                End If
            Else
                sender.location = coordtopos(findcoord(originalpoint.X, originalpoint.Y))
            End If
        Else
            sender.location = coordtopos(findcoord(originalpoint.X, originalpoint.Y))
        End If

        ReDim possible(0 To 0)
        ReDim takepossible(0 To 0)
        mouseisdown = False

        If sender.name = "blackpawn" And findcoord(sender.location.x, sender.location.y).Y = 8 Then
            colour = "black"
            Dim diagres As DialogResult
            diagres = Dialog1.ShowDialog
            If diagres = Windows.Forms.DialogResult.OK Then
                sender.name = selectedpiece
                If selectedpiece = "blackking" Then
                    sender.Image = changepic(My.Resources._12_King_icon)
                ElseIf selectedpiece = "blackqueen" Then
                    sender.Image = changepic(My.Resources._11_Queen_icon)
                ElseIf selectedpiece = "blackbishop" Then
                    sender.Image = changepic(My.Resources._10_Bishop_icon)
                ElseIf selectedpiece = "blackknight" Then
                    sender.Image = changepic(My.Resources._09_Knight_icon)
                ElseIf selectedpiece = "blackrook" Then
                    sender.Image = changepic(My.Resources._08_Castle_icon)
                ElseIf selectedpiece = "blackpawn" Then
                    sender.Image = changepic(My.Resources._07_Pone_icon)
                End If
            End If
        End If
        If sender.name = "whitepawn" And findcoord(sender.location.x, sender.location.y).Y = 1 Then
            colour = "white"
            Dim diagres As DialogResult
            diagres = Dialog1.ShowDialog
            If diagres = Windows.Forms.DialogResult.OK Then
                sender.name = selectedpiece
                If selectedpiece = "whiteking" Then
                    sender.Image = changepic(My.Resources._06_King_icon)
                ElseIf selectedpiece = "whitequeen" Then
                    sender.Image = changepic(My.Resources._05_Queen_icon)
                ElseIf selectedpiece = "whitebishop" Then
                    sender.Image = changepic(My.Resources._04_Bishop_icon)
                ElseIf selectedpiece = "whiteknight" Then
                    sender.Image = changepic(My.Resources._03_Knight_icon)
                ElseIf selectedpiece = "whiterook" Then
                    sender.Image = changepic(My.Resources._02_Castle_icon)
                ElseIf selectedpiece = "whitepawn" Then
                    sender.Image = changepic(My.Resources._01_Pone_icon)
                End If
            End If
        End If

        Me.Refresh()

    End Sub

    Function findcoord(x As Integer, y As Integer) As Point

        If x <= 125 Then
            findcoord.X = 1
        ElseIf x <= 200 Then
            findcoord.X = 2
        ElseIf x <= 275 Then
            findcoord.X = 3
        ElseIf x <= 350 Then
            findcoord.X = 4
        ElseIf x <= 425 Then
            findcoord.X = 5
        ElseIf x <= 500 Then
            findcoord.X = 6
        ElseIf x <= 575 Then
            findcoord.X = 7
        ElseIf x > 575 Then
            findcoord.X = 8
        End If
        If y <= 125 Then
            findcoord.Y = 1
        ElseIf y <= 200 Then
            findcoord.Y = 2
        ElseIf y <= 275 Then
            findcoord.Y = 3
        ElseIf y <= 350 Then
            findcoord.Y = 4
        ElseIf y <= 425 Then
            findcoord.Y = 5
        ElseIf y <= 500 Then
            findcoord.Y = 6
        ElseIf y <= 575 Then
            findcoord.Y = 7
        ElseIf y > 575 Then
            findcoord.Y = 8
        End If

    End Function

    Private Sub Label1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        mousepoint = New Point(e.X, e.Y)
        'Label1.Text = findcoord(mousepoint.X, mousepoint.Y).ToString

    End Sub

    Function coordtopos(pt As Point) As Point

        coordtopos = New Point(71 + 75 * (pt.X - 1), 71 + 75 * (pt.Y - 1))

    End Function

    Function inwayb(coord As Point) As Boolean

        For i = 0 To UBound(blpc) - 1
            If coord = findcoord(blpc(i).Location.X, blpc(i).Location.Y) Then
                Return True
                Exit Function
            End If
        Next

        Return False

    End Function

    Function inwayw(coord As Point) As Boolean

        For i = 0 To UBound(whpc) - 1
            If coord = findcoord(whpc(i).Location.X, whpc(i).Location.Y) Then
                Return True
                Exit Function
            End If
        Next

        Return False

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Function ispossible(p As Point) As Boolean

        For i = 0 To UBound(possible) - 1
            If findcoord(p.X, p.Y) = possible(i) Then
                Return True
                Exit Function
            End If
        Next

        Return False

    End Function

    Function istake(p As Point) As Boolean

        For i = 0 To UBound(takepossible) - 1
            If findcoord(p.X, p.Y) = takepossible(i) Then
                Return True
                Exit Function
            End If
        Next

        Return False

    End Function

    Function isblack(nme As String) As Boolean

        If nme = "blackking" Or nme = "blackqueen" Or nme = "blackpawn" Or nme = "blackrook" Or nme = "blackbishop" Or nme = "blackknight" Then
            Return True
        Else
            Return False
        End If

    End Function

    Function ischeck(sender As String, location As Point) As Boolean
        If sender = "blackqueen" Then
            For i = 1 To 7
                For j = 0 To UBound(whpc)
                    If findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X - i And _
                        findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X - i And _
                    findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X + i And _
                findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X And _
                findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    ElseIf findcoord(whpc(j).Location.X, whpc(j).Location.Y).X = findcoord(location.X, location.Y).X And _
                findcoord(whpc(j).Location.X, whpc(j).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                        If j = 0 Then
                            Return True
                            Exit Function
                        End If
                        GoTo line1
                    End If
                Next
            Next
line1:
        ElseIf sender = "blackpawn" Then
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
                  findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
        ElseIf sender = "blackknight" Then
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 2 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 2 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 2 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
            findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 2 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 2 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 2 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 2 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
            If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 2 And _
             findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
        ElseIf sender = "blackbishop" Then
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
              findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
        ElseIf sender = "blackrook" Then
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(whpc(0).Location.X, whpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(whpc(0).Location.X, whpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
        ElseIf sender = "whitequeen" Then
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
        ElseIf sender = "whitepawn" Then
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
                  findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
        ElseIf sender = "whiteknight" Then
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
        findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 2 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 1 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 2 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 2 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 1 And _
            findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 2 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 2 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + 2 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 2 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + 1 Then
                Return True
                Exit Function
            End If
            If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - 2 And _
             findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - 1 Then
                Return True
                Exit Function
            End If
        ElseIf sender = "whitebishop" Then
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
              findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
        ElseIf sender = "whiterook" Then
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y - i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y + i Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X - i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
            For i = 1 To 7
                If findcoord(blpc(0).Location.X, blpc(0).Location.Y).X = findcoord(location.X, location.Y).X + i And _
               findcoord(blpc(0).Location.X, blpc(0).Location.Y).Y = findcoord(location.X, location.Y).Y Then
                    Return True
                    Exit Function
                End If
            Next
        End If

        Return False

    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        options.Show()
    End Sub

    Function pieceinway(pieces() As PictureBox) As Boolean



    End Function

End Class
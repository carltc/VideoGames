Public Class MainMenu

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ChessBoard.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        options.Show()
    End Sub

    Private Sub MainMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        showpossiblemoves = True

    End Sub
End Class

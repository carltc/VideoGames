Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Do
            ProgressBar1.Increment(1)
        Loop Until a1 = 16

        Me.Hide()

    End Sub

End Class
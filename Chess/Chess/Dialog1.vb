Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        If colour = "black" Then
            If ListBox1.SelectedIndex = 0 Then
                selectedpiece = "blackqueen"
            ElseIf ListBox1.SelectedIndex = 1 Then
                selectedpiece = "blackbishop"
            ElseIf ListBox1.SelectedIndex = 2 Then
                selectedpiece = "blackrook"
            ElseIf ListBox1.SelectedIndex = 3 Then
                selectedpiece = "blackqueen"
            End If
        ElseIf colour = "white" Then
            If ListBox1.SelectedIndex = 0 Then
                selectedpiece = "whitequeen"
            ElseIf ListBox1.SelectedIndex = 1 Then
                selectedpiece = "whitebishop"
            ElseIf ListBox1.SelectedIndex = 2 Then
                selectedpiece = "whiterook"
            ElseIf ListBox1.SelectedIndex = 3 Then
                selectedpiece = "whitequeen"
            End If
        End If

    End Sub
End Class

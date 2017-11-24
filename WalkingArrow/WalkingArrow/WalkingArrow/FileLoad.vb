Module FileLoad

    Public Sub LoadTool()

        ' Displays a SaveFileDialog so the user can save the Image
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Filter = "WalkingArrow Highscores File|*.wah"
        openFileDialog1.Title = "Load WalkingArrow Highscores"
        Dim response As DialogResult
        response = openFileDialog1.ShowDialog()
        If response = DialogResult.Cancel Then
            Exit Sub
        End If

        ' If the file name is not an empty string open it for saving.
        If openFileDialog1.FileName <> "" Then
            ' Saves the Image via a FileStream created by the OpenFile method.
            Dim fl As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(openFileDialog1.FileName)
            Dim rda As String
            Dim numberof As Integer

            ReDim scores(0 To 0)

            numberof = fl.ReadLine()
            rda = fl.ReadLine()

            For i = 0 To numberof

                scores(i).playerName = fl.ReadLine()
                scores(i).score = fl.ReadLine()
                scores(i).timetaken = fl.ReadLine()
                scores(i).enemiesdefeated = fl.ReadLine()
                scores(i).accuracy = fl.ReadLine()
                scores(i).bombs = fl.ReadLine()
                scores(i).difficulty = fl.ReadLine()
                rda = fl.ReadLine()

                ReDim Preserve scores(0 To UBound(scores) + 1)

            Next

        End If

    End Sub

End Module

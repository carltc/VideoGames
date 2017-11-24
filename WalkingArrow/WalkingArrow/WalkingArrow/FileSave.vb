Module FileSave

    Public Sub SaveTool()
        ' Displays a SaveFileDialog so the user can save the Image
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "WalkingArrow Highscores File|*.wah"
        saveFileDialog1.Title = "Save WalkingArrow Highscores"
        Dim response As DialogResult
        response = saveFileDialog1.ShowDialog()
        If response = DialogResult.Cancel Then
            Exit Sub
        End If

        On Error Resume Next

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            ' Saves the Image via a FileStream created by the OpenFile method.
            Dim fs As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(saveFileDialog1.FileName, False)
            ' Saves the Image in the appropriate ImageFormat based upon the
            ' file type selected in the dialog box.
            ' NOTE that the FilterIndex property is one-based.

            fs.WriteLine(UBound(scores) - 1)
            fs.WriteLine()

            For i = 0 To UBound(scores) - 1

                fs.WriteLine(scores(i).playerName)
                fs.WriteLine(scores(i).score)
                fs.WriteLine(scores(i).timetaken)
                fs.WriteLine(scores(i).enemiesdefeated)
                fs.WriteLine(scores(i).accuracy)
                fs.WriteLine(scores(i).bombs)
                fs.WriteLine(scores(i).difficulty)
                fs.WriteLine()

            Next

            fs.Close()

        End If
        Exit Sub

        Resume Next
        MsgBox("Could not save file. If overwriting previous file then make sure that it is not currently running")

    End Sub

End Module

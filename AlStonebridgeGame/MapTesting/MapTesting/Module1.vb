Imports System.IO

Module Module1

    Function cango(ByVal xnew As Integer, ByVal ynew As Integer, ByVal map As String) As Boolean

                Dim TextLine(0 To 0) As String
                Dim line(0 To 0) As String
                Dim i As Integer
                i = 0

                Dim fileReader As StreamReader
                fileReader = New StreamReader(map)

                Do
                    TextLine(i) = fileReader.ReadLine
                    ReDim Preserve TextLine(0 To UBound(TextLine) + 1)
                    i = i + 1

                Loop Until TextLine(i - 1) Is Nothing

                Dim j As Integer
                Do While j < UBound(TextLine)
            If xnew = Val(TextLine(j)) And ynew = Val(TextLine(j + 1)) Then
                Return False
                Exit Function
            ElseIf xnew = Val(TextLine(j)) + 10 And ynew = Val(TextLine(j + 1)) Then
                Return False
                Exit Function
            ElseIf xnew = Val(TextLine(j)) And ynew = Val(TextLine(j + 1)) + 10 Then
                Return False
                Exit Function
            ElseIf xnew = Val(TextLine(j)) + 10 And ynew = Val(TextLine(j + 1)) + 10 Then
                Return False
                Exit Function
            End If

            j = j + 2
        Loop

                Return True

    End Function

End Module

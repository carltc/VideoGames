Module Module1

    Public colour As String
    Public selectedpiece As String
    Public showpossiblemoves As Boolean

    Public Structure position

        Dim row As Integer
        Dim col As Integer
        Dim piece As String

        Function toposchar() As Point

            toposchar = New Point(71 + 75 * (col - 1), 71 + 75 * (row - 1))

            'If col = "a" Then
            '    toposchar = New Point(71, 71 + 75 * (row - 1))
            'ElseIf col = "b" Then
            '    toposchar = New Point(71 + 75, 71 + 75 * (row - 1))
            'ElseIf col = "c" Then
            '    toposchar = New Point(71 + 75 * 2, 71 + 75 * (row - 1))
            'ElseIf col = "d" Then
            '    toposchar = New Point(71 + 75 * 3, 71 + 75 * (row - 1))
            'ElseIf col = "e" Then
            '    toposchar = New Point(71 + 75 * 4, 71 + 75 * (row - 1))
            'ElseIf col = "f" Then
            '    toposchar = New Point(71 + 75 * 5, 71 + 75 * (row - 1))
            'ElseIf col = "g" Then
            '    toposchar = New Point(71 + 75 * 6, 71 + 75 * (row - 1))
            'ElseIf col = "h" Then
            '    toposchar = New Point(71 + 75 * 7, 71 + 75 * (row - 1))
            'End If

        End Function    'find point using characters


    End Structure

    Function changepic(bmp As Bitmap) As Bitmap

        changepic = New Bitmap(32, 32)
        For i = 0 To 31
            For j = 0 To 31
                If bmp.GetPixel(i, j).GetBrightness < 0.99 Then
                    changepic.SetPixel(i, j, bmp.GetPixel(i, j))
                End If
            Next
        Next

    End Function

End Module

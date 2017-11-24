Module Module2

    Public Function goanimation(ByVal time As Integer) As Image
        If direction = 1 Then
            If time = 1 Then
                goanimation = My.Resources.al_behind
            ElseIf time = 2 Then
                goanimation = My.Resources.al_behind2
            ElseIf time = 3 Then
                goanimation = My.Resources.al_behind
            ElseIf time = 4 Then
                goanimation = My.Resources.al_behind1
            ElseIf time = 5 Then
                goanimation = My.Resources.al_behind
            Else
                goanimation = My.Resources.al_behind
            End If
        ElseIf direction = 2 Then
            If time = 1 Then
                goanimation = My.Resources.al_right
            ElseIf time = 2 Then
                goanimation = My.Resources.al_right1
            ElseIf time = 3 Then
                goanimation = My.Resources.al_right
            ElseIf time = 4 Then
                goanimation = My.Resources.al_right2
            ElseIf time = 5 Then
                goanimation = My.Resources.al_right
            Else
                goanimation = My.Resources.al_right
            End If
        ElseIf direction = 3 Then
            If time = 1 Then
                goanimation = My.Resources.al_front
            ElseIf time = 2 Then
                goanimation = My.Resources.al_front3
            ElseIf time = 3 Then
                goanimation = My.Resources.al_front
            ElseIf time = 4 Then
                goanimation = My.Resources.al_front1
            ElseIf time = 5 Then
                goanimation = My.Resources.al_front
            Else
                goanimation = My.Resources.al_front
            End If
        ElseIf direction = 4 Then
            If time = 1 Then
                goanimation = My.Resources.al_left
            ElseIf time = 2 Then
                goanimation = My.Resources.al_left1
            ElseIf time = 3 Then
                goanimation = My.Resources.al_left
            ElseIf time = 4 Then
                goanimation = My.Resources.al_left2
            ElseIf time = 5 Then
                goanimation = My.Resources.al_left
            Else
                goanimation = My.Resources.al_left
            End If
        End If


    End Function

    Public Function golocationx(ByVal time As Integer, ByVal x As Integer) As Integer
        If direction = 2 Then
            golocationx = x - (2 * time)
        ElseIf direction = 4 Then
            golocationx = x + (2 * time)
        Else
            golocationx = x
        End If
    End Function

    Public Function golocationy(ByVal time As Integer, ByVal y As Integer) As Integer
        If direction = 3 Then
            golocationy = y - (2 * time)
        ElseIf direction = 1 Then
            golocationy = y + (2 * time)
        Else
            golocationy = y
        End If
    End Function


End Module

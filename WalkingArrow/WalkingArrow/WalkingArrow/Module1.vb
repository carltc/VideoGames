Module Module1

    Public finalscore As endscore
    Public scores(0 To 0) As endscore
    Public playername As String = "Default"
    Public difficulty As String = "Easy"


    Structure endscore

        Dim playerName As String
        Dim score As Integer
        Dim difficulty As String
        Dim timetaken As Single
        Dim enemiesdefeated As Integer
        Dim accuracy As Integer
        Dim bombs As Integer

        Public Sub New(ByVal PlayersName As String, ByVal FinalScore As Integer, ByVal DifficultySetting As String, _
                       ByVal Time As Single, ByVal Kills As Integer, ByVal HitRatio As Integer, _
                       BombsUsed As Integer)

            playerName = PlayersName
            score = FinalScore
            difficulty = DifficultySetting
            timetaken = Time
            enemiesdefeated = Kills
            accuracy = HitRatio
            bombs = BombsUsed

        End Sub


    End Structure


End Module

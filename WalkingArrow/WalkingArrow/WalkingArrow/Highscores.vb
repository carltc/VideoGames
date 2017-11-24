Public Class Highscores

    Private Sub Highscores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        For i = 0 To UBound(scores) - 1
            ListView1.Items.Add(scores(i).playerName)
            ListView1.Items(i).SubItems.Add(scores(i).score)
            ListView1.Items(i).SubItems.Add(scores(i).timetaken)
            ListView1.Items(i).SubItems.Add(scores(i).enemiesdefeated)
            ListView1.Items(i).SubItems.Add(scores(i).accuracy & "%")
            ListView1.Items(i).SubItems.Add(scores(i).bombs)
            ListView1.Items(i).SubItems.Add(scores(i).difficulty)
        Next

        'ListView1.Items.Add("finalscore")
        'ListView1.Items(0).SubItems.Add(finalscore.score)
        'ListView1.Items(0).SubItems.Add(finalscore.timetaken)
        'ListView1.Items(0).SubItems.Add(finalscore.enemiesdefeated)
        'ListView1.Items(0).SubItems.Add(finalscore.accuracy)
        'ListView1.Items(0).SubItems.Add(finalscore.bombs)
        ListView1.Sorting = SortOrder.None

        Dim s As New endscore("Carl", 400, "Hard", 20.3, 204, 80, 2)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        LoadTool()
        For i = 0 To UBound(scores) - 1
            ListView1.Items.Add(scores(i).playerName)
            ListView1.Items(i).SubItems.Add(scores(i).score)
            ListView1.Items(i).SubItems.Add(scores(i).timetaken)
            ListView1.Items(i).SubItems.Add(scores(i).enemiesdefeated)
            ListView1.Items(i).SubItems.Add(scores(i).accuracy & "%")
            ListView1.Items(i).SubItems.Add(scores(i).bombs)
            ListView1.Items(i).SubItems.Add(scores(i).difficulty)
        Next

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        SaveTool()

    End Sub

    Private Sub ListView1_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick

        'ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)

        If e.Column = 0 Or e.Column = 6 Then

            ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)

        ElseIf e.Column >= 1 And e.Column <= 5 Then

            ListView1.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Descending)

        End If

    End Sub
End Class

Class ListViewItemComparer
    Implements IComparer

    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
    End Function
End Class

Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal _
        sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As _
        Object) As Integer Implements _
        System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x,  _
            ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y,  _
            ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function
End Class
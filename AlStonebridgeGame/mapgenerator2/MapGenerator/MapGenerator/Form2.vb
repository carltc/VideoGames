Public Module loading
    Public a1 As Integer
End Module

Public Class Form2

    Dim image As Image
    Dim instance As Integer
    Dim nogo As Integer
    Dim goodimage As Integer
    Dim xmouse As Double
    Dim ymouse As Double
    Dim xmouse2 As Double
    Dim ymouse2 As Double
    Dim imagex(0 To 0) As Double
    Dim imagey(0 To 0) As Double
    Dim imagex2(0 To 0) As Double
    Dim imagey2(0 To 0) As Double
    Dim picture(0 To 0) As PictureBox
    Dim cursortype As Double

    Function roundtolocationx(ByVal xlocation As Double) As Integer
        Dim r As Integer
        r = xlocation / 20
        r = (r * 20)
        roundtolocationx = r
    End Function

    Function roundtolocationy(ByVal ylocation As Double) As Integer
        Dim r As Integer
        r = ylocation / 20
        r = (r * 20)
        roundtolocationy = r
    End Function

    Private Sub formclick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyClass.Click
        Dim coord As Point
        Dim x As Double
        Dim y As Double
        Dim point As Point
        Dim newPictureBox As New PictureBox
        Dim imagename As String

        If Me.Cursor = Cursors.Hand Then

            coord = MousePosition
            coord.X = xmouse
            coord.Y = ymouse
            x = roundtolocationx(xmouse - 10)
            y = roundtolocationy(ymouse - 10)
            point.X = x
            point.Y = y

            If goodimage = 1 Then
                ReDim Preserve imagex(0 To UBound(imagex) + 1)
                imagex(nogo) = x
                ReDim Preserve imagey(0 To UBound(imagey) + 1)
                imagey(nogo) = y
                nogo = nogo + 1
            End If

            imagename = "Picturebox" & instance + 2
            newPictureBox.Name = imagename
            newPictureBox.Image = image
            newPictureBox.Visible = True
            newPictureBox.Width = 20
            newPictureBox.Height = 20
            newPictureBox.Location = point
            newPictureBox.BringToFront()

            ReDim Preserve picture(0 To UBound(picture) + 1)
            picture(instance) = newPictureBox


            If point.X < 300 And point.Y < 300 Then
                Controls.Add(newPictureBox)
            Else
                MsgBox("Cannot add element outside of range")
            End If

            instance = instance + 1


        End If


    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        instance = 0
        nogo = 0
        goodimage = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button3.Click, Button4.Click, Button6.Click, Button7.Click, Button12.Click, Button15.Click, Button16.Click, Button17.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button27.Click, Button28.Click, Button29.Click
        image = sender.Image
        PictureBox1.Image = image
        Me.Cursor = Cursors.Hand
        goodimage = 0
    End Sub

    Private Sub Buttonnogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button5.Click, Button6.Click, Button13.Click, Button14.Click, Button18.Click, Button19.Click, Button24.Click, Button25.Click, Button26.Click
        image = sender.Image
        PictureBox1.Image = image
        Me.Cursor = Cursors.Hand
        goodimage = 1
    End Sub

    Private Sub form2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        xmouse = e.X
        ymouse = e.Y
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Cursor = Cursors.No
    End Sub

    Private Sub window_move(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyClass.MouseMove

        xmouse2 = e.X
        ymouse2 = e.Y
        If MyClass.Cursor = Cursors.No Then
            cursortype = 1
            For ij = 0 To (UBound(picture) - 2)
                AddHandler picture(ij).MouseClick, AddressOf Me.Picturedeleteclick
            Next ij
        Else
            cursortype = 0
            For ij = 0 To (UBound(picture) - 2)
                AddHandler picture(ij).MouseClick, AddressOf Me.Picturereplaceclick
            Next ij
        End If
    End Sub

    'Private Sub window_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyClass.Click
    '    If cursortype = 1 Then
    '        Dim i As Integer
    '        i = 0

    '        For i = 0 To instance - 1

    '            If imagex(i) = roundtolocationx(xmouse2 - 10) And imagey(i) = roundtolocationy(ymouse2 - 10) Then

    '                If instance = 1 Then
    '                    picture(0).Hide()
    '                Else
    '                    picture(i).Hide()
    '                End If


    '                instance = instance - 1

    '                For j = i To UBound(picture)
    '                    On Error Resume Next
    '                    picture(i) = picture(i + 1)
    '                    Resume Next
    '                Next
    '                ReDim Preserve picture(0 To UBound(picture) - 1)

    '                For j = i To UBound(imagex)
    '                    On Error Resume Next
    '                    imagex(i) = imagex(i + 1)
    '                    Resume Next
    '                Next
    '                ReDim Preserve imagex(0 To UBound(imagex) - 1)

    '                For j = i To UBound(imagey)
    '                    On Error Resume Next
    '                    imagey(i) = imagey(i + 1)
    '                    Resume Next
    '                Next
    '                ReDim Preserve imagey(0 To UBound(imagey) - 1)

    '                Label2.Text = instance
    '                Label4.Text = imagex.Length
    '                Label5.Text = imagey.Length

    '            End If

    '        Next i

    '    End If

    'End Sub


    Private Sub Picturedeleteclick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Controls.Remove(sender)

    End Sub

    Private Sub Picturereplaceclick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        sender.image = image

    End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim point As Point
        Dim point2 As Point
        Dim graph As Graphics = Nothing

        point.X = 0
        point.Y = 0
        point2.X = Me.Location.X
        point2.Y = Me.Location.Y

        If Dir("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & ".bmp") <> "" Then
            MsgBox("File already exists!" & vbCrLf & "Rename this file or delete other file.")
            Exit Sub
        End If

        Me.Location = point
        Try
            Dim bmp As New Bitmap(300, 300)
            graph = Graphics.FromImage(bmp)
            graph.CopyFromScreen((Me.Size.Width - ClientSize.Width) / 2, (Me.Size.Height - ClientSize.Height) - ((Me.Size.Width - ClientSize.Width) / 2), 0, 0, bmp.Size)
            bmp.Save("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & ".bmp")
        Catch ex As Exception
        End Try
        Me.Location = point2

        ProgressBar1.Maximum = 2 * UBound(imagex)

        For l = 0 To (UBound(imagex) - 1)

            My.Computer.FileSystem.WriteAllText("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & "text.txt", _
   (imagex(l)) _
   & vbCrLf & _
   (imagey(l)) _
   & vbCrLf, True)

            '            My.Computer.FileSystem.WriteAllText("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & "text.txt", _
            '(imagex(l)) _
            '& vbCrLf & _
            '(imagey(l) + 10) _
            '& vbCrLf, True)

            ProgressBar1.Increment(1)
            '            My.Computer.FileSystem.WriteAllText("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & "text.txt", _
            '(imagex(l) + 10) _
            '& vbCrLf & _
            '(imagey(l)) _
            '& vbCrLf, True)

            '            My.Computer.FileSystem.WriteAllText("C:\Dokumente und Einstellungen\ctc0103\Eigene Dateien\Eigene Bilder\files\" & TextBox1.Text & "text.txt", _
            '(imagex(l) + 10) _
            '& vbCrLf & _
            '(imagey(l) + 10) _
            '& vbCrLf, True)

            ProgressBar1.Increment(1)

        Next l

        MsgBox("File saved successfully.")

        ProgressBar1.Value = 0

    End Sub

    'Private Function GetControlScreenshot(ByVal width As Double, ByVal height As Double) As Bitmap
    '    Dim g As Graphics = control.CreateGraphics()
    '    Dim bitmap As Bitmap = New Bitmap(control.Width, control.Height)
    '    control.DrawToBitmap(bitmap, New Rectangle(control.Location, control.Size))

    '    GetControlScreenshot = bitmap
    'End Function

End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Highscores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Player_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Score = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Time_Taken = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Enemies_Defeated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Accuracy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bombs_Used = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Difficulty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(468, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Highscores"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Player_Name, Me.Score, Me.Time_Taken, Me.Enemies_Defeated, Me.Accuracy, Me.Bombs_Used, Me.Difficulty})
        Me.ListView1.Location = New System.Drawing.Point(12, 42)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(468, 183)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Player_Name
        '
        Me.Player_Name.Text = "Player Name"
        Me.Player_Name.Width = 76
        '
        'Score
        '
        Me.Score.Text = "Score"
        Me.Score.Width = 49
        '
        'Time_Taken
        '
        Me.Time_Taken.Text = "Time Taken"
        Me.Time_Taken.Width = 80
        '
        'Enemies_Defeated
        '
        Me.Enemies_Defeated.Text = "Kills"
        Me.Enemies_Defeated.Width = 57
        '
        'Accuracy
        '
        Me.Accuracy.Text = "Accuracy"
        Me.Accuracy.Width = 66
        '
        'Bombs_Used
        '
        Me.Bombs_Used.Text = "Bombs Used"
        Me.Bombs_Used.Width = 76
        '
        'Difficulty
        '
        Me.Difficulty.Text = "Difficulty"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "New Game"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(405, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Main Menu"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(292, 231)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Save Scores"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(389, 231)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Load Scores"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Highscores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = Global.WalkingArrow.My.Resources.Resources.walkingarrow_background
        Me.ClientSize = New System.Drawing.Size(492, 266)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Highscores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Highscores"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Time_Taken As System.Windows.Forms.ColumnHeader
    Friend WithEvents Enemies_Defeated As System.Windows.Forms.ColumnHeader
    Friend WithEvents Accuracy As System.Windows.Forms.ColumnHeader
    Friend WithEvents Bombs_Used As System.Windows.Forms.ColumnHeader
    Friend WithEvents Score As System.Windows.Forms.ColumnHeader
    Friend WithEvents Player_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Difficulty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class

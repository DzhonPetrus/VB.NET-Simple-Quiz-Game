Public Class MainMenu
    Public state As Integer = 0

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        homeState()
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        playState()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        homeState()
    End Sub

    Private Sub btnLevel_Click(sender As Object, e As EventArgs) Handles btnLevel.Click
        toggleLevel()
    End Sub

    Private Sub lblX_Click(sender As Object, e As EventArgs) Handles lblX.Click
        EndProg()
    End Sub

    Private Sub btnEasy_Click(sender As Object, e As EventArgs) Handles btnEasy.Click
        Game.level = "EASY"
        Game.Show()
        Me.Hide()
    End Sub

    Private Sub btnNormal_Click(sender As Object, e As EventArgs) Handles btnNormal.Click
        Game.level = "NORMAL"
        Game.Show()
        Me.Hide()
    End Sub

    Private Sub btnDifficult_Click(sender As Object, e As EventArgs) Handles btnDifficult.Click
        Game.level = "DIFFICULT"
        Game.Show()
        Me.Hide()
    End Sub

    Public xtra As Integer = 0
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        xtra += 1
        If xtra = 10 Then
            db.Show()
        End If
    End Sub
End Class

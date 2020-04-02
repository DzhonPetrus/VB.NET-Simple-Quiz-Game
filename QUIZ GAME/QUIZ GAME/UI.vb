Imports System.IO

Module UI
    Public toggleLvl As Integer = 1

    Public Sub homeState()
        ' SHOW BUTTONS ON HOME STATE
        MainMenu.btnPlay.Visible = True
        MainMenu.btnSettings.Visible = True
        MainMenu.btnHelp.Visible = True

        ' HIDE BUTTONS ON PLAY STATE
        MainMenu.btnLevel.Visible = False
        MainMenu.btnHome.Visible = False
        MainMenu.btnEasy.Visible = False
        MainMenu.btnNormal.Visible = False
        MainMenu.btnDifficult.Visible = False

        ' CHANGE THE STATE TO HOME STATE
        MainMenu.state = 0
    End Sub

    Public Sub playState()
        ' HIDE BUTTONS ON HOME STATE
        MainMenu.btnPlay.Visible = False
        MainMenu.btnSettings.Visible = False
        MainMenu.btnHelp.Visible = False

        ' SHOW BUTTONS ON PLAY STATE
        MainMenu.btnLevel.Visible = True
        MainMenu.btnHome.Visible = True
        MainMenu.btnEasy.Visible = True
        MainMenu.btnNormal.Visible = True
        MainMenu.btnDifficult.Visible = True

        ' CHANGE THE STATE TO PLAY STATE
        MainMenu.state = 1
    End Sub

    Public Sub toggleLevel()
        ' UI LEVEL MENU TOGGLE
        If toggleLvl = 0 Then
            toggleLvl = 1
            MainMenu.btnEasy.Visible = True
            MainMenu.btnNormal.Visible = True
            MainMenu.btnDifficult.Visible = True
        Else
            toggleLvl = 0
            MainMenu.btnEasy.Visible = False
            MainMenu.btnNormal.Visible = False
            MainMenu.btnDifficult.Visible = False
        End If
    End Sub

    Public Sub EndProg()
        ' CONFIRMATION ON EXITING/CLOSING THE PROGRAM
        Dim ans As Integer = MessageBox.Show("Do you want to exit?", "GRAMSIS - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If ans = MsgBoxResult.Yes Then
            End
        End If
    End Sub
End Module

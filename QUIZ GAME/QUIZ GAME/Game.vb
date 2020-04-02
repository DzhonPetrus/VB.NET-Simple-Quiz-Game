Imports System.Text

Public Class Game
    'ASCII Code A-Z = 65-90     a-z - 97 - 122

    Dim i As Integer = 1
    Dim generator As System.Random = New System.Random()


    Dim listWord As New List(Of String)({"Peter", "john", "fine"})
    Dim listQuestion As New List(Of String)({"Who are you?", "What's my name?", "How are you?"})
    Dim listWordCap As String = listWord.Capacity

    Dim generated As Integer = generator.Next(0, listWordCap)
    Dim word As String = listWord(generated)
    Dim question As String = listQuestion(generated)

    Dim selected As New List(Of Char)({})
    Dim selectedcnt As Integer = 0
    Dim selectedWORD As String = ""

    Public level As String
    Public guessletterscnt As Integer
    Dim randomString As String

    Dim intLeftSelected As Integer = 0

    Dim wordUpper As String = word.ToUpper
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Select Case level
            Case "EASY"
                guessletterscnt = 10
            Case "NORMAL"
                guessletterscnt = 10
            Case "DIFFICULT"
                guessletterscnt = 10
        End Select

        Dim cnt As Integer
        While cnt <> wordUpper.Length
            cnt = 0
            randomString = String.Empty
            generateLttr()

            'MessageBox.Show(randomString)

            For Each c As Char In wordUpper

                If randomString.Contains(c) Then
                    cnt += 1
                End If

            Next
        End While


        loadDynamicButtonList()
        loadQuestion()
        loadAnswers()
    End Sub


    Public Sub loadQuestion()
        lblQuestion.Text = question
    End Sub

    Private Sub lblX_Click(sender As Object, e As EventArgs) Handles lblX.Click
        EndProg()
    End Sub


    Private Sub loadAnswers()
        'variable save location of each button
        Dim intLeft As Integer = 0
        Dim intTop As Integer = 0

        'Variable save width and height of each button
        Dim intWidth As Integer = 50
        Dim intHeight As Integer = 50

        'GENERATOR (split the string to array of characters)
        Dim generatedSelection As Array = {}
        generatedSelection = wordUpper.ToCharArray

        'Loop from 1 to length of generated word to create button
        For i As Integer = 0 To generatedSelection.Length - 1

            If intLeft >= PanelSelection.Width - intWidth Then
                'new line
                intLeft = 0
                intTop += 60
            End If

            Dim btn As New Button
            ' what will be displayed
            btn.Text = String.Empty

            btn.Name = i + 10.ToString
            btn.Left = intLeft
            btn.Top = intTop
            btn.Width = intWidth
            btn.Height = intHeight
            btn.Cursor = Cursors.Hand
            btn.ForeColor = Color.Black
            btn.BackColor = Color.DodgerBlue

            btn.Visible = True

            'add event for button here
            AddHandler btn.Click, AddressOf OnButtonSel_Click

            'add btn control on form
            PanelSelected.Controls.Add(btn)
            'move next button to right of current button
            intLeft += intWidth + 5
        Next
    End Sub


    Private Sub loadDynamicButtonList()
        'variable save location of each button
        Dim intLeft As Integer = 0
        Dim intTop As Integer = 0

        'Variable save width and height of each button
        Dim intWidth As Integer = 50
        Dim intHeight As Integer = 50


        'GENERATOR (split the string to array of characters)
        Dim generatedSelection As Array = {}
        generatedSelection = randomString.ToCharArray

        'Loop from 1 to length of generated word to create button
        For i As Integer = 0 To generatedSelection.Length - 1

            If intLeft >= PanelSelection.Width - intWidth Then
                'new line
                intLeft = 0
                intTop += 60
            End If

            Dim btn As New Button
            ' what will be displayed
            btn.Text = generatedSelection(i)

            btn.Name = i.ToString
            btn.Left = intLeft
            btn.Top = intTop
            btn.Width = intWidth
            btn.Height = intHeight
            btn.Cursor = Cursors.Hand
            btn.ForeColor = Color.Black
            btn.BackColor = Color.DodgerBlue


            btn.Visible = True

            'add event for button here
            AddHandler btn.Click, AddressOf OnButton_Click

            'add btn control on form
            PanelSelection.Controls.Add(btn)
            'move next button to right of current button
            intLeft += intWidth + 5
        Next
    End Sub

    'create event OnClick for each button
    Private Sub OnButtonSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim btn As New Button
        btn = CType(sender, Button) ' convert object to button type

        'add letter to answers
        For Each item As Control In PanelSelection.Controls
            If (item.Visible = False And btn.Text = item.Text) Then
                item.Visible = True
                selected.Remove(btn.Text)
                btn.Text = String.Empty
                Exit For
            End If
        Next


    End Sub


    'create event OnClick for each button
    Private Sub OnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim btn As New Button
        btn = CType(sender, Button) ' convert object to button type

        'add letter to answers
        For Each item As Control In PanelSelected.Controls
            If (item.Text = String.Empty) Then
                item.Text = btn.Text
                selected.Add(btn.Text)
                Exit For
            End If
        Next

        btn.Visible = False

    End Sub

    Sub updateSELECTED()
        selected.Clear()
        For Each btn As Button In PanelSelected.Controls
            If btn.Text <> String.Empty Then
                selected.Add(btn.Text)
            End If
        Next
        selectedWORD = String.Concat(selected)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = "LEVEL: " & level

        updateSELECTED()

        lblQuestion.Text = selectedWORD

        If (selectedWORD.Length = word.Length) Then
            If (selectedWORD.ToUpper = wordUpper) Then
                lblQuestion.Text = "CONGRATS"
            End If
        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ' CONFIRMATION ON GOING BACK TO HOME
        Dim ans As Integer = MessageBox.Show("Do you want to go back to menu?", "GRAMSIS - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If ans = MsgBoxResult.Yes Then
            MainMenu.Show()
            Me.Hide()
        End If
    End Sub


    Sub generateLttr()
        Dim rand As New Random
        Dim asc As Integer
        For i As Integer = 0 To guessletterscnt - 1
            asc = rand.Next(65, 90)
            randomString += CChar(ChrW(asc))
        Next
    End Sub
End Class
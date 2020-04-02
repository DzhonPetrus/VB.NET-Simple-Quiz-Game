Public Class db

    Private Sub GAMEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles GAMEBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.GAMEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Database1DataSet1)

    End Sub

    Private Sub db_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet1.GAME' table. You can move, or remove it, as needed.
        Me.GAMETableAdapter.Fill(Me.Database1DataSet1.GAME)
        MainMenu.xtra = 0

    End Sub
End Class
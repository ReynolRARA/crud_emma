Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;Integrated Security=True" 'esta es unacadena de conexion la optines dando origenes de datos 
        'agregas un nuevo origen de datos le das base de datos depues conjunto de datosdepues selecionas sql sever 
        'despues le das en nueva conexion lel servidor del sql lo optines en sql server 
        'en donde dice slecciona para la conexion de la base de datos te apareceran las bases de datos que tiene tu sql server tu selecionas la que tenga la tabla que usaras 
        'le das en probar conexion si la coexion es correcta te vas a un costado dice avanzadas haasta abajo te da la cadena de coexion(nota es mejor que tu sql lo conectes con la autentificasion de window osea sin poner el usuario y contraseña de sql)

        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim adaptador As New SqlCommand("insert into alumno values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "',
'" & TextBox4.Text & "','" & TextBox5.Text & "')", cn) 'insert into (alumnos es la tabla de la base de datos) values
        cn.Open()
        adaptador.ExecuteNonQuery()
        MsgBox("se registro correctamente")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion


        Dim adaptador As New SqlDataAdapter("select*from alumno where codigo= '" & TextBox1.Text & "' ", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")
        If ds.Tables("datos").Rows.Count > 0 Then
            TextBox2.Text = ds.Tables("datos").Rows(0).Item(1).ToString
            TextBox3.Text = ds.Tables("datos").Rows(0).Item(2).ToString
            TextBox4.Text = ds.Tables("datos").Rows(0).Item(3).ToString
            TextBox5.Text = ds.Tables("datos").Rows(0).Item(4).ToString
        Else
            MsgBox("usuario no existe")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion

        Dim adaptador As New SqlCommand("UPDATE alumno set codigo='" & TextBox1.Text & "',Nombre='" & TextBox2.Text & "',
        Apellido_paterno='" & TextBox3.Text & "',Apellido_materno='" & TextBox4.Text & "',genero='" & TextBox5.Text & "' where codigo ='" & TextBox1.Text & "'", cn)
        cn.Open()
        adaptador.ExecuteNonQuery()
        MsgBox("datos actualizados")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        cn.Open()

        Dim comando As New SqlCommand("DELETE FROM alumno WHERE codigo='" & TextBox1.Text & "'", cn)
        comando.ExecuteNonQuery()
        MsgBox("se elimino correctamente")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'RegistroDataSet.alumno' Puede moverla o quitarla según sea necesario.
        Me.AlumnoTableAdapter.Fill(Me.RegistroDataSet.alumno)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        cn.Open()
        Dim sqll As String
        sqll = "select*from alumno "
        Dim adaptador As New SqlClient.SqlDataAdapter(sqll, cn)
        Dim obtenerdatos As New DataSet
        adaptador.Fill(obtenerdatos, "codigo")
        DataGridView1.DataSource = obtenerdatos
        DataGridView1.DataMember = "codigo"



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        End

    End Sub
End Class

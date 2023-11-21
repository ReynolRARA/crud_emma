Imports System.Data.SqlClient

Public Class login
    Dim connectionString As String = "Data Source=DESKTOP-UIQJHDL\MSSQLSERVER1;Initial Catalog=registro;
Integrated Security=True;"

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As String = txtUsuario.Text
        Dim contraseña As String = txtContraseña.Text

        If AutenticarUsuario(usuario, contraseña) Then
            MessageBox.Show("Inicio de sesión exitoso")

            Dim form1 As New Form1()
            form1.Show()


            'Me.Close()
        Else
            MessageBox.Show("Error de inicio de sesión. Verifica tus credenciales.")
        End If
    End Sub

    Private Function AutenticarUsuario(usuario As String, contraseña As String) As Boolean

        contraseña = contraseña.ToLower()

        Dim query As String = "SELECT COUNT(*) FROM usuarios WHERE usuario = @Usuario AND LOWER(Contraseña) = @Contraseña"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Usuario", usuario)
                command.Parameters.AddWithValue("@Contraseña", contraseña)

                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                Catch ex As Exception
                    MessageBox.Show("Error al conectar a la base de datos: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function
End Class

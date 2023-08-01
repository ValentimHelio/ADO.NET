using Azure.Core;
using eCommerce.API.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

/*
 *Connection => Estabelecer conexão com banco.
 * Command => INSERT, UPDATE, DELETE.
 * DataReader => Arq. Conectada. SELECT.
 * DataAdapter => Arq. Desconectada. SELECT.
 */

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        public List<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select * from Usuarios";
                command.Connection = (SqlConnection)_connection;

                _connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuarario = new Usuario();
                    usuarario.Id = dataReader.GetInt32("Id");
                    usuarario.Nome = dataReader.GetString("Nome");
                    usuarario.Email = dataReader.GetString("Email");
                    usuarario.Sexo = dataReader.GetString("Sexo");
                    usuarario.Rg = dataReader.GetString("RG");
                    usuarario.CPF = dataReader.GetString("CPF");
                    usuarario.NomeMae = dataReader.GetString("NomeMae");
                    usuarario.SituacaoCadastro = dataReader.GetString("SituacaoCadastro");
                    usuarario.DataCadastro = dataReader.GetDateTimeOffset(8);

                    usuarios.Add(usuarario);
                }

            }
            finally
            {
                _connection.Close();
            }

            return usuarios;
        }

        public Usuario GetById(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Usuarios WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Connection = (SqlConnection)_connection;

                _connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuarario = new Usuario();
                    usuarario.Id = dataReader.GetInt32("Id");
                    usuarario.Nome = dataReader.GetString("Nome");
                    usuarario.Email = dataReader.GetString("Email");
                    usuarario.Sexo = dataReader.GetString("Sexo");
                    usuarario.Rg = dataReader.GetString("RG");
                    usuarario.CPF = dataReader.GetString("CPF");
                    usuarario.NomeMae = dataReader.GetString("NomeMae");
                    usuarario.SituacaoCadastro = dataReader.GetString("SituacaoCadastro");
                    usuarario.DataCadastro = dataReader.GetDateTimeOffset(8);

                    return usuarario;
                }

            }
            finally
            {
                _connection.Close();
            }

            return null;
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Usuarios(Nome, Email, Sexo, RG, CPF, NomeMae, SituacaoCadastro, DataCadastro) VALUES (@Nome, @Email, @Sexo, @RG, @CPF, @NomeMae, @SituacaoCadastro, @DataCadastro); SELECT CAST(scope_identity() AS int)";
                command.Connection = (SqlConnection)_connection;
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                command.Parameters.AddWithValue("@RG", usuario.Rg);
                command.Parameters.AddWithValue("@CPF", usuario.CPF);
                command.Parameters.AddWithValue("@NomeMae", usuario.NomeMae);
                command.Parameters.AddWithValue("@SituacaoCadastro", usuario.SituacaoCadastro);
                command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);


                _connection.Open();
                usuario.Id = (int)command.ExecuteScalar();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, Sexo = @Sexo, RG = @RG, CPF = @CPF, NomeMae = @NomeMae, SituacaoCadastro = @SituacaoCadastro, DataCadastro = @DataCadastro WHERE Id = @Id";
                command.Connection = (SqlConnection)_connection;

                command.Connection = (SqlConnection)_connection;
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                command.Parameters.AddWithValue("@RG", usuario.Rg);
                command.Parameters.AddWithValue("@CPF", usuario.CPF);
                command.Parameters.AddWithValue("@NomeMae", usuario.NomeMae);
                command.Parameters.AddWithValue("@SituacaoCadastro", usuario.SituacaoCadastro);
                command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
                
                command.Parameters.AddWithValue("@Id", usuario.Id);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "DELETE FROM Usuarios WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Connection = (SqlConnection)_connection;

                _connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}

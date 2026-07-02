namespace TP04.Models;
using Dapper;
using Microsoft.Data.SqlClient;


public class BD
{
    private string _connectionString = @"Server=localhost;DataBase = TP04;integrated Security = True;TrustServerCertificate=True;";

    public List<Jugadores> ObtenerJugadores(){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
        List<Jugadores> Jugadores = connection.Query<Jugadores>("SELECT * FROM Jugadores").ToList();
        }
        return Jugadores;
    }

    public List<Jugadores> AbrirSobre(){
        Random rand = new Random();
        List<Jugadores> Sobre;
        List<Jugadores> Jugadores = ObtenerJugadores();
        for (int i = 0; i < 5;i ++){
            int numR = rand.Next(3,(Figus.Count + 1));
            Sobre.Add(Jugadores[numR]);
        }
        return Sobre;
    }

    public Figuritas VerificarFigurita(int IdJugador){
        Figuritas figu = null;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string Query = "SELECT IdJugador From Figuritas WHERE IdJugador = @pIdJugador";
        }
        return figu;
    }

    public void PegarFiguritas(){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
        connection.Query<Figuritas>("UPDATE Figuritas SET Estado = 1 WHERE IdFigurita = Sobre");
        }
    }

}
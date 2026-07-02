namespace TP04.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class BD
{
    private string _connectionString = @"Server=localhost;DataBase = TP04;integrated Security = True;TrustServerCertificate=True;";

    public List<Jugadores> ObtenerJugadores(){
        List<Jugadores> Jugadores = new List<Jugadores>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
        Jugadores = connection.Query<Jugadores>("SELECT * FROM Jugadores").ToList();
        }
        return Jugadores;
    }

    public List<Jugadores> AbrirSobre(){
        Random rand = new Random();
        List<Jugadores> Sobre = new List<Jugadores>();
        List<Jugadores> Jugadores = ObtenerJugadores();
        for (int i = 0; i < 5;i ++){
            int numR = rand.Next(3,(Jugadores.Count + 1));
            Sobre.Add(Jugadores[numR]);
        }
        return Sobre;
    }

    public int VerificarFigurita(int IdJugador){
        int figu = 0;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string Query = "SELECT IdJugador From Figuritas WHERE IdJugador = @pIdJugador";
            figu = connection.Query<int>(Query);
        }
        return figu;
    }

    public void PegarFiguritas(int idJugador){
        if(VerificarFigurita(idJugador) == 0){
            string query = "INSERT INTO Figuritas(IdJugador, Cantidad, Estado) VALUES (@pidJugador, 0, 0)";
            using(SqlConnection connection = new SqlConnection(_connectionString)){
                connection.Execute(query);
            }
        }
        else{
            using(SqlConnection connection = new SqlConnection(_connectionString)){
                string query = "UPDATE Figuritas SET Cantidad = Cantidad + 1 WHERE IdJugador = @idJugador";
            }
        }
    }

    public void PegarFigusXId(List<int> ids){
        for(int i = 0; i <= ids.Count; i++ ){
            PegarFiguritas(ids[i]);
        }
    }
}
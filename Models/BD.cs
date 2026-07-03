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
            int numR = rand.Next(0,(Jugadores.Count));
            Sobre.Add(Jugadores[numR]);
        }
        return Sobre;
    }

    public int VerificarFigurita(int IdJugador){
        int figu = 0;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT IdJugador From Figuritas WHERE IdJugador = @IdJugador";
            figu = connection.QueryFirstOrDefault<int>(query, new { IdJugador = IdJugador});
        }
        return figu;
    }

    public void PegarFiguritas(int IdJugador){
          Console.WriteLine("!!!!!!!!!" + IdJugador);
        if(VerificarFigurita(IdJugador) == 0){
            string query = "INSERT INTO Figuritas(IdJugador, Cantidad, Estado) VALUES (@IdJugador, 0, 0)";
            using(SqlConnection connection = new SqlConnection(_connectionString)){
                connection.Execute(query, new { IdJugador });
            }
        }
        else{
            using(SqlConnection connection = new SqlConnection(_connectionString)){
                string query = "UPDATE Figuritas SET Cantidad = Cantidad + 1 WHERE IdJugador = @IdJugador";
            }
        }
    }

    public void PegarFigusXId(List<int> ids){
        
        for(int i = 0; i < ids.Count; i++ ){
            PegarFiguritas(ids[i]);
            Console.WriteLine("!!!!!!!!!!!!!!!!" + ids[i]);
        }
    }
}
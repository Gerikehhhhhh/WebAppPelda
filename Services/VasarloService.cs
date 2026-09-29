using MySql.Data.MySqlClient;
using WebAppPelda.Models;
using WebAppPelda.DataManager;

namespace WebAppPelda.Services;

public class VasarloService {
    public List<Vasarlo> GetAllVasarlo() {
        using (MySqlConnection conn = new DBManager().CreateConnection()) {
            try
            {
                conn.Open();
                List<Vasarlo> result = new List<Vasarlo>();
                string sql = "SELECT * FROM vasarlo;";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Vasarlo ujVasarlo = new Vasarlo();
                    ujVasarlo.Id = reader.GetInt32("Id");
                    ujVasarlo.Nev = reader.GetString("Nev");
                    ujVasarlo.Cim = reader.GetString("Cim");
                    ujVasarlo.Telefon = reader.GetString("Telefon");
                    ujVasarlo.Email = reader.GetString("Email");
                    ujVasarlo.Pontszam = reader.GetInt32("Pontszam");
                    result.Add(ujVasarlo);
                }

                conn.Close();

                return result;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Vasarlo>() { new Vasarlo() { Nev = ex.Message } };
            }
        }
    }

    public Vasarlo GetById(int id) {
        try {
            Vasarlo result = new Vasarlo();
            using (MySqlConnection conn = new DBManager().CreateConnection()) {
                conn.Open();
                string sql = "SELECT * FROM vasarlo WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                result.Id = reader.GetInt32("Id");
                result.Nev = reader.GetString("Nev");
                result.Cim = reader.GetString("Cim");
                result.Telefon = reader.GetString("Telefon");
                result.Email = reader.GetString("Email");
                result.Pontszam = reader.GetInt32("Pontszam");
            }

            return result;
        }
        catch (Exception e) {
            Vasarlo hiba = new Vasarlo();
            hiba.Nev = e.Message;
            
            return hiba;
        }
    }
}
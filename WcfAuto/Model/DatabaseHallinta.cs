
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;




namespace WcfAuto.model
{
    
    public class DatabaseHallinta
    {
        //string yhteysTiedot;
        //SqlConnection dbYhteys;
        SqlConnection dbYhteys = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        

        public DatabaseHallinta()
        {
      
           
        }

        public bool connectDatabase()
        {
                        
            try
            { 
                dbYhteys.Open();
                return true;
            }
            catch(Exception e)
            { 
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;
            }
            
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;

            
        }

        public List<AutonMerkki> GetMerkit()
        {

            dbYhteys.Open();
            SqlCommand car = new SqlCommand("select * from AutonMerkki", dbYhteys);
            SqlDataReader dr = car.ExecuteReader();
            List<AutonMerkki> merkki = new List<AutonMerkki>();


            while (dr.Read())
            {

                AutonMerkki Marks = new AutonMerkki();
                Marks.Id = (int)dr["ID"];
                Marks.Merkkinimi = (string)dr["Merkki"];
                merkki.Add(Marks);

            }
            dbYhteys.Close();
            return merkki;
        }
       
        public List<Autonmallit> GetMallit(int MerkkiId)
        {
            
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("SELECT * FROM AutonMallit WHERE AutonMerkkiID ="+MerkkiId+" ",dbYhteys);
            SqlDataReader sdr = car1.ExecuteReader();
            List<Autonmallit> malli = new List<Autonmallit>();
            

            while (sdr.Read())
            {

                Autonmallit model = new Autonmallit();
                model.Id = (int)sdr["ID"];
                model.MalliNimi = (string)sdr["Auton_mallin_nimi"];
                model.MerkkiId = (int)sdr["AutonMerkkiID"];
                malli.Add(model);

            }
            dbYhteys.Close();
            return malli; 
            
        }
        public List<Polttoaine> GetPolttoaine()
        {
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("SELECT * FROM Polttoaine "  , dbYhteys);
            SqlDataReader sdr = car1.ExecuteReader();
            List<Polttoaine> aine = new List<Polttoaine>();


            while (sdr.Read())
            {

                Polttoaine polAine = new Polttoaine();
                polAine.Id = (int)sdr["ID"];
                polAine.Polttoaineennimi = (string)sdr["Polttoaineen_nimi"];
               
                aine.Add(polAine);

            }
            dbYhteys.Close();
            return aine;

        }
        public List<Vari> GetVarit()
        {
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("SELECT * FROM Varit ", dbYhteys);
            SqlDataReader sdr = car1.ExecuteReader();
            List<Vari> vari = new List<Vari>();


            while (sdr.Read())
            {

               Vari vari1 = new Vari();
               vari1.Id = (int)sdr["ID"];
               vari1.Varinnimi = (string)sdr["Varin_nimi"];

                vari.Add(vari1);

            }
            dbYhteys.Close();
            return vari;

        }
        public bool savecar(Auto biili)
        {
            dbYhteys.Open();
           
            SqlCommand car1 = new SqlCommand("INSERT INTO auto(Hinta, Rekisteri_paivamaara, Moottorin_tilavuus, Mittarilukema, AutonMerkkiID, AutonMalliID, VaritID, PolttoaineID)" +
            "VALUES(@Hinta1,@Rekisteri_paivamaara,@Moottorin_tilavuus1,@Mittarilukema1,@AutonMerkkiID1, @AutonMalliID1, @VaritID1,@PolttoaineID1 )", dbYhteys);
            SqlParameter Hinta = new SqlParameter("@Hinta1", biili.Hinta1);
            car1.Parameters.Add(Hinta);

            SqlParameter Rekisteri_paivamaara = new SqlParameter("@Rekisteri_paivamaara", biili.Rekisteri_paivamaara1);
            car1.Parameters.Add(Rekisteri_paivamaara);

            SqlParameter Moottorin_tilavuus1 = new SqlParameter("@Moottorin_tilavuus1", biili.Moottorin_tilavuus1);
            car1.Parameters.Add(Moottorin_tilavuus1);

            SqlParameter Mittarilukema1 = new SqlParameter("@Mittarilukema1", biili.Mittarilukema1);
            car1.Parameters.Add(Mittarilukema1);

            SqlParameter AutonMerkkiID1 = new SqlParameter("@AutonMerkkiID1", biili.AutonMerkkiID1);
            car1.Parameters.Add(AutonMerkkiID1);

            SqlParameter AutonMalliID1 = new SqlParameter("@AutonMalliID1", biili.AutonMalliID1);
            car1.Parameters.Add(AutonMalliID1);

            SqlParameter VaritID1 = new SqlParameter("@VaritID1", biili.VaritID1);
            car1.Parameters.Add(VaritID1);

            SqlParameter PolttoaineID1 = new SqlParameter("@PolttoaineID1", biili.PolttoaineID1);
            car1.Parameters.Add(PolttoaineID1);

            car1.ExecuteNonQuery();
            dbYhteys.Close();
            return true;
        }
        public Auto nextcar(int ID )

        {
            Auto seuraava = new Auto();
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("Select top 1 * from auto Where ID > " + ID + "  order by ID  asc   ", dbYhteys);
            SqlDataReader srauto = car1.ExecuteReader();
            while (srauto.Read())
            {
                seuraava.ID1 = (int)srauto["ID"];
                seuraava.AutonMerkkiID1 = (int)srauto["AutonMerkkiID"];
                seuraava.Hinta1 = (decimal)srauto["Hinta"];
                seuraava.Rekisteri_paivamaara1 = (DateTime)srauto["Rekisteri_paivamaara"];
                seuraava.Mittarilukema1 = (int)srauto["Mittarilukema"];
                seuraava.Moottorin_tilavuus1 = (decimal)srauto["Moottorin_tilavuus"];
                seuraava.PolttoaineID1 = (int)srauto["PolttoaineID"];
                seuraava.AutonMalliID1 = (int)srauto["AutonMalliID"];
                seuraava.VaritID1 = (int)srauto["VaritID"];

            }

            dbYhteys.Close();
            return seuraava;
        }
        public Auto prevcar(int ID)

        {
            Auto edellinen = new Auto();
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("Select top 1 * from auto Where ID < " + ID + "  order by ID  desc   ", dbYhteys);
            SqlDataReader srauto = car1.ExecuteReader();
            while (srauto.Read())
            {
                edellinen.ID1 = (int)srauto["ID"];
                edellinen.AutonMerkkiID1 = (int)srauto["AutonMerkkiID"];
                edellinen.Hinta1 = (decimal)srauto["Hinta"];
                edellinen.Rekisteri_paivamaara1 = (DateTime)srauto["Rekisteri_paivamaara"];
                edellinen.Mittarilukema1 = (int)srauto["Mittarilukema"];
                edellinen.Moottorin_tilavuus1 = (decimal)srauto["Moottorin_tilavuus"];
                edellinen.PolttoaineID1 = (int)srauto["PolttoaineID"];
                edellinen.AutonMalliID1 = (int)srauto["AutonMalliID"];
                edellinen.VaritID1 = (int)srauto["VaritID"];

            }

            dbYhteys.Close();
            return edellinen;
        }
        public Auto first()

        {
            Auto ensimmainen = new Auto();
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("Select  * from auto order by ID  asc   ", dbYhteys);
            SqlDataReader srauto = car1.ExecuteReader();
            while (srauto.Read())
            {
                ensimmainen.ID1 = (int)srauto["ID"];
                ensimmainen.AutonMerkkiID1 = (int)srauto["AutonMerkkiID"];
                ensimmainen.Hinta1 = (decimal)srauto["Hinta"];
                ensimmainen.Rekisteri_paivamaara1 = (DateTime)srauto["Rekisteri_paivamaara"];
                ensimmainen.Mittarilukema1 = (int)srauto["Mittarilukema"];
                ensimmainen.Moottorin_tilavuus1 = (decimal)srauto["Moottorin_tilavuus"];
                ensimmainen.PolttoaineID1 = (int)srauto["PolttoaineID"];
                ensimmainen.AutonMalliID1 = (int)srauto["AutonMalliID"];
                ensimmainen.VaritID1 = (int)srauto["VaritID"];
            }

            dbYhteys.Close();
            return ensimmainen;
        }
        public Auto Last()

        {
            Auto viimeinen = new Auto();
            dbYhteys.Open();
            SqlCommand car1 = new SqlCommand("Select * from auto order by ID  desc   ", dbYhteys);
            SqlDataReader srauto = car1.ExecuteReader();
            while (srauto.Read())
            {
                viimeinen.ID1 = (int)srauto["ID"];
                viimeinen.AutonMerkkiID1 = (int)srauto["AutonMerkkiID"];
                viimeinen.Hinta1 = (decimal)srauto["Hinta"];
                viimeinen.Rekisteri_paivamaara1 = (DateTime)srauto["Rekisteri_paivamaara"];
                viimeinen.Mittarilukema1 = (int)srauto["Mittarilukema"];
                viimeinen.Moottorin_tilavuus1 = (decimal)srauto["Moottorin_tilavuus"];
                viimeinen.PolttoaineID1 = (int)srauto["PolttoaineID"];
                viimeinen.AutonMalliID1 = (int)srauto["AutonMalliID"];
                viimeinen.VaritID1 = (int)srauto["VaritID"];
            }

            dbYhteys.Close();
            return viimeinen;
        }

    }
}

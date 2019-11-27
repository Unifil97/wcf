using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfAuto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
         bool TestDatabaseConnection();


        [OperationContract]
        bool saveAuto(Auto biili);

        [OperationContract]
         Auto seurcar(int ID);

        [OperationContract]
         Auto edellcar(int ID);

        [OperationContract]
         List<AutonMerkki> getAllAutoMakers();

        [OperationContract]
        List<Autonmallit> getAutoModels(int MerkkiId);

        [OperationContract]
        List<Polttoaine> GetFuel();

        [OperationContract]
        List<Vari> GetColor();
      

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Auto
    {
        [DataMember]
        public int ID1 { get; set; }
        [DataMember]
        public decimal Hinta1 { get; set; }
        [DataMember]
        public DateTime Rekisteri_paivamaara1 { get ; set; }
        [DataMember]
        public decimal Moottorin_tilavuus1 { get; set; }
        [DataMember]
        public int Mittarilukema1 { get; set; }
        [DataMember]
        public int AutonMerkkiID1 { get; set; }
        [DataMember]
        public int AutonMalliID1 { get; set; }
        [DataMember]
        public int VaritID1 { get; set; }
        [DataMember]
        public int PolttoaineID1 { get; set; }

    }
    [DataContract]
    public class AutonMerkki
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Merkkinimi { get; set; }
    }
    [DataContract]
    public class Autonmallit
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MalliNimi { get; set; }
        [DataMember]
        public int MerkkiId { get; set; }
    }
    [DataContract]
    public class Polttoaine
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Polttoaineennimi { get; set; }
    }
    [DataContract]
    public class Vari
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Varinnimi { get; set; }
    }
}



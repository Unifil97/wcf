using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfAuto.model;
using System.Data;
using System.Data.SqlClient;

namespace WcfAuto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DatabaseHallinta dbController = new DatabaseHallinta();


        public bool TestDatabaseConnection()
        {
            bool doesItWork = dbController.connectDatabase();
            return doesItWork;
        }

        public bool saveAuto(Auto biili)
        {
            bool didItGoIntoDatabase = dbController.savecar(biili);
            return didItGoIntoDatabase;
        }
        public Auto seurcar(int ID)
        {
            Auto uusi = dbController.nextcar(ID);
            if (uusi.ID1 == 0)
            {
                uusi = dbController.Last();
                return uusi;
            }

            else
            {
                return uusi;
            }

        }
        public Auto edellcar(int ID)
        {
            Auto uusi = dbController.prevcar(ID);
            if (uusi.ID1 == 0)
            {
                uusi = dbController.first();
                return uusi;
            }

            else
            {
                return uusi;
            }

        }

        public List<AutonMerkki> getAllAutoMakers()
        {
            return dbController.GetMerkit();
        }

        public List<Autonmallit> getAutoModels(int MerkkiId)
        {

            return dbController.GetMallit(MerkkiId);
        }
        public List<Polttoaine> GetFuel()
        {
            return dbController.GetPolttoaine();
        }
        public List<Vari> GetColor()
        {
            return dbController.GetVarit();
        }


    }
}

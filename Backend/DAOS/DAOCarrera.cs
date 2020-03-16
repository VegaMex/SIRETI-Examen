using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Connections;
using Backend.Models;

namespace Backend.DAOS
{
    public class DAOCarrera
    {
        public INewConnection connection;

        public DAOCarrera(INewConnection connection)
        {
            this.connection = connection;
        }

        public List<Carrera> GetCarreras()
        {
            var list = new List<Carrera>();
            IConnection localConnection = connection.Create();

            var data = localConnection.GetData("SELECT nombre_carrera FROM carreras WHERE id_carrera != 1", new string[0], new string[0]);

            Carrera carrera;

            foreach (DataRow row in data.Rows)
            {
                carrera = new Carrera();
                carrera.NombreCarrera = (string)row.ItemArray[0];
                list.Add(carrera);
            }

            return list;
        }
    }
}

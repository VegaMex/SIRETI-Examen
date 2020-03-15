using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Connections
{
    public interface IConnection
    {
        long Execute(string sqlCommand, string[] columns, object[] keys);
        DataTable Get(string sqlCommand, string[] columns, object[] keys);
    }
}

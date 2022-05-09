using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Sistemi
{
    class SQLBağlantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=HastaneOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }


    }
}

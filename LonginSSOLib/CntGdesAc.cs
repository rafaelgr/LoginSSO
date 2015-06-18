using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LonginSSOLib
{
    public static class CntGdesAc
    {
        #region Conexión a MySql

        public static MySqlConnection GetConnection(string connectionString)
        {
            // crear la conexion y devolverla.
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        #endregion

        #region Trabajadores

        public static AcTrabajador GetAcTrabajador(MySqlDataReader rdr)
        {
            if (rdr.IsDBNull(rdr.GetOrdinal("trabajadorId")))
                return null;
            AcTrabajador acTrabajador = new AcTrabajador();
            acTrabajador.TrabajadorId = rdr.GetInt32("trabajadorId");
            acTrabajador.Nombre = rdr.GetString("nombre");
            acTrabajador.Login = rdr.GetString("login");
            if (!rdr.IsDBNull(rdr.GetOrdinal("idioma")))
            {
                acTrabajador.Idioma = rdr.GetString("idioma");
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal("evaluador")))
            {
                acTrabajador.Evaluador= rdr.GetBoolean("evaluador");
            }
            return acTrabajador;
        }

        public static AcTrabajador GetAcTrabajadorLogin(string login, MySqlConnection conn)
        {
            AcTrabajador acTrabajador = null;
            MySqlCommand cmd = conn.CreateCommand();
            string sql = "SELECT * from trabajadores WHERE login = '{0}'";
            sql = String.Format(sql, login);
            cmd.CommandText = sql;
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                acTrabajador = GetAcTrabajador(rdr);
            }
            return acTrabajador;
        }

        public static OdTrabajador GetOdTrabajador(MySqlDataReader rdr)
        {
            if (rdr.IsDBNull(rdr.GetOrdinal("trabajadorId")))
                return null;
            OdTrabajador odTrabajador = new OdTrabajador();
            odTrabajador.TrabajadorId = rdr.GetInt32("trabajadorId");
            odTrabajador.Nombre = rdr.GetString("nombre");
            odTrabajador.Login = rdr.GetString("login");
            if (!rdr.IsDBNull(rdr.GetOrdinal("idioma")))
            {
                odTrabajador.Idioma = rdr.GetString("idioma");
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal("evaluador")))
            {
                odTrabajador.Evaluador = rdr.GetBoolean("evaluador");
            }
            return odTrabajador;
        }

        public static OdTrabajador GetOdTrabajadorLogin(string login, MySqlConnection conn)
        {
            OdTrabajador odTrabajador = null;
            MySqlCommand cmd = conn.CreateCommand();
            string sql = "SELECT * from trabajadores WHERE login = '{0}'";
            sql = String.Format(sql, login);
            cmd.CommandText = sql;
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                odTrabajador = GetOdTrabajador(rdr);
            }
            return odTrabajador;
        }

        #endregion
    }
}

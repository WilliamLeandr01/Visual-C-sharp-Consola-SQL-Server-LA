using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidarAgua.capa_base_datos
{
    class BaseDatos
    {
        // Conexion Bd
        private string cadenaConexion = "Data Source = WILLIAM\\SQLSERVERLOCAL; Initial Catalog = liquidarAgua; Integrated Security = True";

        // Registros
        public bool EjecutarDML(string DML)
        {
           
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand(DML, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
               
                return true;
            }
            else
            {
                
                return false;
            }
        }

 
        // Consultas
        public DataSet EjecutarConsulta(string sql, string nombreTabla)
        {   
            SqlConnection conexion = new SqlConnection(cadenaConexion);  
            DataSet datos = new DataSet(); 
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion); 
            adaptador.Fill(datos, nombreTabla);    
            return datos;
        }

        // Consulta Total Boletas
        public int EjecutarConsultaBoletas(string sql)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand(sql, conexion);
            int numeroTotalBoletas = Convert.ToInt16(comando.ExecuteScalar());
            if (numeroTotalBoletas > 0)
            {
                return numeroTotalBoletas;
            }
            else
            {
                return numeroTotalBoletas;
            }

        }
    }
}

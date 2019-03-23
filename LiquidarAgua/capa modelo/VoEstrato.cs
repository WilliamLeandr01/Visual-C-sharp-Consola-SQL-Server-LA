using LiquidarAgua.capa_base_datos;
using LiquidarAgua.strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidarAgua.capa_modelo
{
    class VoEstrato
    {
        // Variables globales
        private BaseDatos bd = new BaseDatos();
        private string nombreTabla = Utilidades.STRING_NOMBRE_TABLA_ESTRATO;
        private string query;

        #region atributos

        #region propiedades
        private string estrato;

        public string MetEstrato
        {
            get { return estrato; }
            set { estrato = value; }
        }

        private double metroCubico;

        public double MetMetroCubico
        {
            get { return metroCubico; }
            set { metroCubico = value; }
        }

        private double aseo;

        public double MetAseo
        {
            get { return aseo; }
            set { aseo = value; }
        }
        private double subsidio;

        public double MetSubsidio
        {
            get { return subsidio; }
            set { subsidio = value; }
        }
        
        #endregion

        #endregion

        #region metodos DML

        // Query estrato
        public DataSet ConsultaEstratoBd(string opcionEstrato)
        {
            query = "select * from tbl_estrato where estrato ='"+opcionEstrato+"'";
            return bd.EjecutarConsulta(query, nombreTabla);
        }
        #endregion
    }
}

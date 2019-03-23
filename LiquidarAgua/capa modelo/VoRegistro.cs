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
    class VoRegistro
    {
        private BaseDatos bd = new BaseDatos();
        private string nombreTabla = Utilidades.STRING_NOMBRE_TABLA_REGISTRO;
        private string query;
        #region atributos

        #region propiedades
        private string registro;

        public string MetRegistro
        {
            get { return registro; }
            set { registro = value; }
        }

        private string direccion;

        public string MetDireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string estrato;

        public string MetEstrato
        {
            get { return estrato; }
            set { estrato = value; }
        }

        private double lecturaActual;

        public double MetLecturaActual
        {
            get { return lecturaActual; }
            set { lecturaActual = value; }
        }

        private double lecturaAnterior;

        public double MetLecturaAnterior
        {
            get { return lecturaAnterior; }
            set { lecturaAnterior = value; }
        }

        private double consumo;

        public double MetConsumo
        {
            get { return consumo; }
            set { consumo = value; }
        }

        private double subsido;

        public double MetSubsidio
        {
            get { return subsido; }
            set { subsido = value; }
        }

        private double valorAgua;

        public double MetValorAgua
        {
            get { return valorAgua; }
            set { valorAgua = value; }
        }

        private double sobrecosto;

        public double MetSobrecosto
        {
            get { return sobrecosto; }
            set { sobrecosto = value; }
        }

        private double aseo;

        public double MetAseo
        {
            get { return aseo; }
            set { aseo = value; }
        }

        private double netoPagar;

        public double MetNetoPagar
        {
            get { return netoPagar; }
            set { netoPagar = value; }
        }

        private string numeroBoleta;

        public string MetNumeroBoleta
        {
            get { return numeroBoleta; }
            set { numeroBoleta = value; }
        }
           
        #endregion

        #endregion


        #region metodos DML
        // Query registro
        public bool RegistrarDatos(VoRegistro voRegistro)
        {
            query = "insert into tbl_registro (registro, direccion, " +
            "estrato, lectura_actual, lectura_anterior, consumo, subsidio, " +
            "valor_agua, sobrecosto, aseo, neto_pagar, numero_boleta) " +
            "values ('" + voRegistro.MetRegistro.ToString() + "','"
            + voRegistro.MetDireccion.ToString() + "','"
            + voRegistro.MetEstrato.ToString() + "','"
            + voRegistro.MetLecturaActual.ToString() + "','"
            + voRegistro.MetLecturaAnterior.ToString() + "','"
            + voRegistro.MetConsumo.ToString() + "','"
            + voRegistro.MetSubsidio.ToString() + "','"
            + voRegistro.MetValorAgua.ToString() + "','"
            + voRegistro.MetSobrecosto.ToString() + "','"
            + voRegistro.MetAseo.ToString() + "','"
            + voRegistro.MetNetoPagar.ToString() + "','"
            + voRegistro.MetNumeroBoleta.ToString() + "')";
            return bd.EjecutarDML(query);
            
        }

        // Query consulta
        public DataSet ConsultarRegistroBd(string numeroRegistro)
        {
            query = "select * from tbl_registro where registro ='"+numeroRegistro+"'";
            return bd.EjecutarConsulta(query, nombreTabla);
        }
        #endregion

        // Query Boletas
        public int ConsultarTotalBoletasBd()
        {
            query = "select count(numero_boleta) from tbl_registro";
            return bd.EjecutarConsultaBoletas(query);
        }

        // Query Boletas No Entregadas
        public int ConsultarTotalBoletasNoEntregaBd()
        {
            query = "select count(numero_boleta) from tbl_registro where numero_boleta ='"+"No participa"+"'";
            return bd.EjecutarConsultaBoletas(query);
        }

        // Query Neto a Pagar
        public DataSet ConsultarNetoPagarBd()
        {
            query = "select neto_pagar from tbl_registro";
            return bd.EjecutarConsulta(query, nombreTabla);
        }

        // Query Consumo
        public DataSet ConsultarConsumoBd()
        {
            query = "select consumo from tbl_registro";
            return bd.EjecutarConsulta(query, nombreTabla);
        }

        // Query Estrato Repetido
        public DataSet ConsultarEstratoRepetidoBd()
        {
            query = "select estrato, count(*) from tbl_registro group by estrato having count(*) > 1";
            return bd.EjecutarConsulta(query, nombreTabla);
        }
    }
}

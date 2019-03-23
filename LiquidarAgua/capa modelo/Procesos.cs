using LiquidarAgua.strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidarAgua.capa_modelo
{
    class Procesos
    {
        // Variables globales
        private VoEstrato voEstrato = new VoEstrato();
        private VoRegistro voRegistro = new VoRegistro();
        private DataSet datosVoEstratoBd;
        private double sobreCosto;
        private double netoPagar;
        private bool validarGenerarRecibo = false;


        // Agregar valores al objeto
        private void AgregarValoresVoEstrato()
        {
            voEstrato.MetEstrato = datosVoEstratoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_ESTRATO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_ESTRATO].ToString();
            voEstrato.MetMetroCubico = Convert.ToDouble(datosVoEstratoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_ESTRATO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_METRO_CUBICO].ToString());
            voEstrato.MetAseo = Convert.ToDouble(datosVoEstratoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_ESTRATO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_ASEO].ToString());
            voEstrato.MetSubsidio = Convert.ToDouble(datosVoEstratoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_ESTRATO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_SUBSIDIO].ToString());
        }

        // Operaciones del registro
        public bool OperacionesRegistro(VoRegistro voRegistro)
        {
            voEstrato = new VoEstrato();
            Random rd = new Random();
            datosVoEstratoBd = ConsultarEstrato(voRegistro.MetEstrato.ToString());
            AgregarValoresVoEstrato();

            voRegistro.MetConsumo = (voRegistro.MetLecturaActual - voRegistro.MetLecturaAnterior);
            voRegistro.MetSubsidio = voEstrato.MetSubsidio;
            voRegistro.MetValorAgua = (voRegistro.MetConsumo * voEstrato.MetMetroCubico);
            if (voRegistro.MetConsumo > voRegistro.MetLecturaAnterior)
	        {
                sobreCosto = (voRegistro.MetValorAgua * 10) / 100;
                voRegistro.MetSobrecosto = sobreCosto;
		 
	        }
            voRegistro.MetAseo = voEstrato.MetAseo;
            netoPagar = (voRegistro.MetValorAgua + voRegistro.MetSobrecosto + voRegistro.MetAseo) - voRegistro.MetSubsidio;
            voRegistro.MetNetoPagar = netoPagar;
            if (netoPagar >= 50000)
            {
                int numeroAleatorio = rd.Next(1000, 9000);
                voRegistro.MetNumeroBoleta = numeroAleatorio.ToString();
            }
            else
            {
                voRegistro.MetNumeroBoleta = Utilidades.STRING_MENSAJE_REGISTRO_NO_ENTREGA;
            }
            return RealizarRegistro(voRegistro);
        }

        // Llama metodo registro Bd
        private bool RealizarRegistro(VoRegistro voRegistro)
        {
            return voRegistro.RegistrarDatos(voRegistro);
        }

        // Llama metodo consulta de estratos Bd
        private DataSet ConsultarEstrato(string opcionEstrato)
        {
            return voEstrato.ConsultaEstratoBd(opcionEstrato);
        }

        // Llama metodo consulta registros Bd
        public DataSet ConsultarRegistroBd(string consultRegis)
        {      
            return voRegistro.ConsultarRegistroBd(consultRegis);
        }

        // Valida registro con mensaje
        public string ValidaRegistro(VoRegistro voRegistro)
        {
            if (OperacionesRegistro(voRegistro))
            {
                return Utilidades.STRING_MENSAJE_REGISTRO_VALIDO;
            }
            else
            {
                return Utilidades.STRING_MENSAJE_REGISTRO_NO_VALIDO;
            }
        }

        // Consulta Total Boletas Bd
        public int ConsultarTotalBoletasBd()
        {
            return voRegistro.ConsultarTotalBoletasBd();
        }

        // Consulta Total Boleta No Entregadas Bd
        public int ConsultarTotalBoletasNoEntregaBd()
        {
            return voRegistro.ConsultarTotalBoletasNoEntregaBd();
        }

        // Operacion Boletas
        public int OperacionesTotalBoletas(int totalBoletas, int totalBoletasNoEntrega)
        {
            int finalBoletas;
            return  finalBoletas = (totalBoletas - totalBoletasNoEntrega);
        }

        // Consulta Todo Neto a Pagar Bd
        public DataSet ConsultarNetoPagarBd()
        {
            return voRegistro.ConsultarNetoPagarBd();
        }

        // Suma Neto a Pagar Bd
        public double OperacionTotalRecibir(DataSet totalRecibir)
        {
            double sumaValor = 0;
            for (int i = 0; i < totalRecibir.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows.Count; i++)
            {
                sumaValor += Convert.ToDouble
                (totalRecibir.Tables
                [Utilidades.STRING_NOMBRE_TABLA_REGISTRO].
                Rows[i][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_NETO_PAGAR].ToString());
            }

            return sumaValor;
        }

        // Consulta Promedio Consumo
        public DataSet ConsultarConsumoBd()
        {
            return voRegistro.ConsultarConsumoBd();
        }


        // Operaciones Promedio Consumo
        public double OperacionesConsumo(DataSet consumoBd)
        {
            int cantidad = consumoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows.Count;
            double sumaConsumo = 0;
            double promedioConsumo = 0;
            for (int i = 0; i < consumoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows.Count; i++)
            {
                sumaConsumo += Convert.ToDouble
                (consumoBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[i]
                [Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_CONSUMO].ToString());
            }
            promedioConsumo = (sumaConsumo / cantidad);
            return promedioConsumo;
        }

        // Consultar Estrato Repetido
        public DataSet ConsultarEstratoRepetidoBd()
        {
            return voRegistro.ConsultarEstratoRepetidoBd();
        }

        public string OperacionesGenerarRecibo(DataSet valorRecibo)
        {
            DateTime fecha = DateTime.Today;
            string reciboFecha = Convert.ToString(fecha.Day + "/" + fecha.Month + "/" + fecha.Year);
            string menuRecibo = "Fecha de Entrega : " + reciboFecha + "\n" +
            "Valor Total a Pagar : " + valorRecibo.Tables["tbl_registro"].Rows[0]["neto_pagar"].ToString();
            EscribirReciboPago(menuRecibo);

            if (!validarGenerarRecibo)
            {
                return "Recibo Generado Con Exito !";
            }
            else
            {
                return "No se Genero el Recibo";
            }
           
        }

        private void EscribirReciboPago(string menuRecibo)
        {
            try
            {
                if (File.Exists(Utilidades.STRING_MENU_RECIBO_PAGAR_RUTA_ARCHIVO))
                {
                    File.Delete(Utilidades.STRING_MENU_RECIBO_PAGAR_RUTA_ARCHIVO);

                    StreamWriter escribir = new StreamWriter(Utilidades.STRING_MENU_RECIBO_PAGAR_RUTA_ARCHIVO, true);
                    escribir.WriteLine(menuRecibo);
                    escribir.Close();
                    validarGenerarRecibo = false;
                }
                else
                {

                    StreamWriter escribir = new StreamWriter(Utilidades.STRING_MENU_RECIBO_PAGAR_RUTA_ARCHIVO, true);
                    escribir.WriteLine(menuRecibo);
                    escribir.Close();
                    validarGenerarRecibo = false;
                }
                
            }
            catch (Exception)
            {
                validarGenerarRecibo = true;
                throw;           
            }
            
        }
    }
}

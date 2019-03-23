using LiquidarAgua.capa_modelo;
using LiquidarAgua.strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidarAgua.capa_vista
{
    class MenuPrincipal
    {
        // Variables globales
        private VoEstrato voEstrato;
        private VoRegistro voRegistro;
        private string menu;
        private string  opcionMenu;
        private Procesos proc = new Procesos();

        // Constructor
        public MenuPrincipal()
        {
            inicioMenu();
        }

        // Inicio del menu principal
        public void inicioMenu()
        {
            do
            {
                Console.Clear();
                menu = Utilidades.STRING_MENU_TITULO_PRINCIPAL;
                Console.WriteLine(menu);
                menu = Utilidades.STRING_MENU_OPCIONES_PRINCIPAL;
                Console.Write(menu);
                switch (opcionMenu = Console.ReadLine())
                {
                    case "1":
                       
                        Console.Clear();
                        voEstrato = new VoEstrato();
                        voRegistro = new VoRegistro();

                        menu = Utilidades.STRING_MENU_TITULO_REGISTRO;
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_OPCION_REGISTRO;
                        Console.Write(menu);
                        voRegistro.MetRegistro = Console.ReadLine();

                        menu = Utilidades.STRING_OPCION_DIRECCION;
                        Console.Write(menu);
                        voRegistro.MetDireccion = Console.ReadLine();

                        menu = Utilidades.STRING_OPCION_ESTRATO;
                        Console.Write(menu);
                        voRegistro.MetEstrato = Console.ReadLine();

                        menu = Utilidades.STRING_OPCION_LECTURA_ACTUAL;
                        Console.Write(menu);
                        voRegistro.MetLecturaActual = Convert.ToDouble(Console.ReadLine());

                        menu = Utilidades.STRING_OPCION_LECTURA_ANTERIOR;
                        Console.Write(menu);
                        voRegistro.MetLecturaAnterior = Convert.ToDouble(Console.ReadLine());

                        string confirma = proc.ValidaRegistro(voRegistro);
                        Console.Clear();
                        Console.WriteLine(confirma);
                        Console.ReadKey();

                        break;

                    case "2":

                        Console.Clear();
                        voRegistro = new VoRegistro();
                        menu = Utilidades.STRING_MENU_MOSTRAR_REGISTRO_TITULO;
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_MENU_MOSTRAR_REGISTRO_NUMERO;
                        Console.WriteLine(menu);
                        string consultRegis = Console.ReadLine();
                        Console.WriteLine();
                        DataSet datosVoRegistroBd = proc.ConsultarRegistroBd(consultRegis);

                        menu = Utilidades.STRING_NOMBRE_OPCION_REGISTRO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_REGISTRO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_DIRECCION +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_NOMBRE_DIRECCION].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_ESTRATO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_ESTRATO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_LECTURA_ACTUAL +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_LECTURA_ACTUAL].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_LECTURA_ANTERIOR +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_LECTURA_ANTERIOR].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_CONSUMO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_CONSUMO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_SUBSIDIO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_SUBSIDIO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_VALOR_AGUA +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_VALOR_AGUA].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_SOBRECOSTO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_SOBRECOSTO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_ASEO +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_ASEO].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_NETO_PAGAR +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_NETO_PAGAR].ToString();
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_NOMBRE_OPCION_NUMERO_BOLETA +
                        datosVoRegistroBd.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows[0][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_NUMERO_BOLETA].ToString();
                        Console.WriteLine(menu);
                        Console.ReadKey();

                        break;

                    case "3":
                        Console.Clear();
                        menu = Utilidades.STRING_MENU_NUMERO_BOLETAS_TITULO;
                        Console.WriteLine(menu);

                        int totalBoletas = proc.ConsultarTotalBoletasBd();
                        int totalBoletasNoEntrega = proc.ConsultarTotalBoletasNoEntregaBd();
                        int finalBoletas = proc.OperacionesTotalBoletas(totalBoletas, totalBoletasNoEntrega);

                        menu = Utilidades.STRING_MOSTRAR_NUMERO_BOLETAS_REGISTRADAS + totalBoletas;
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_MOSTRAR_NUMERO_BOLETAS_ENTREGADAS + finalBoletas;
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_MOSTRAR_NUMERO_BOLETAS_NO_ENTREGADAS + totalBoletasNoEntrega;
                        Console.WriteLine(menu);

                        Console.ReadKey();
                        break;

                    case "4":

                        Console.Clear();
                        menu = Utilidades.STRING_MENU_TOTAL_RECIBIR_TITULO;
                        Console.WriteLine(menu);

                        DataSet totalRecibir = proc.ConsultarNetoPagarBd();
                        double valorFinal = proc.OperacionTotalRecibir(totalRecibir);
                        menu = Utilidades.STRING_MENU_TOTAL_RECIBIR_VALOR + valorFinal;
                        Console.WriteLine(menu);
                        Console.ReadKey();
                        

                        break;

                    case "5":

                        Console.Clear();
                        menu = Utilidades.STRING_MENU_PROMEDIO_CONSUMO_TITULO;
                        Console.WriteLine(menu);

                        DataSet consumoBd = proc.ConsultarConsumoBd();
                        int promedioConsumo = Convert.ToInt16(proc.OperacionesConsumo(consumoBd));
                        menu = Utilidades.STRING_MENU_PROMEDIO_CONSUMO_VALOR + promedioConsumo;
                        Console.WriteLine(menu);
                        Console.ReadKey();

                        break;

                    case "6":

                        Console.Clear();
                        menu = Utilidades.STRING_MENU_ESTRATO_REPETIDO_TITULO;
                        Console.WriteLine(menu);

                        DataSet estrato = proc.ConsultarEstratoRepetidoBd();
                        for (int i = 0; i < estrato.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].Rows.Count; i++)
                        {
                            menu = Utilidades.STRING_MENU_ESTRATO_REPETIDO_VALOR +
                            estrato.Tables[Utilidades.STRING_NOMBRE_TABLA_REGISTRO].
                            Rows[i][Utilidades.STRING_FILAS_TABLA_REGISTRO_NOMBRE_ESTRATO].ToString();
                            Console.WriteLine(menu);
                        }

                        Console.ReadKey();

                        break;
                        
                    case "7":

                        Console.Clear();
                        menu = Utilidades.STRING_MENU_RECIBO_PAGAR_TITULO;
                        Console.WriteLine(menu);

                        menu = Utilidades.STRING_MENU_RECIBO_PAGAR_REGISTRO;
                        Console.WriteLine(menu);
                        string numeroRegistro = Console.ReadLine();

                        DataSet valorRecibo = proc.ConsultarRegistroBd(numeroRegistro);
                        string mensaje = proc.OperacionesGenerarRecibo(valorRecibo);
                        Console.Clear();
                        Console.WriteLine(mensaje);
                        
                        Console.ReadKey();

                        break;

                    case "8":

                        Console.Clear();
                        Console.Write(Utilidades.STRING_MENU_BYE);

                        break;

                    default:
                        break;
                }
            } while ((!opcionMenu.Equals("8")));
           
        }

       
    }
}

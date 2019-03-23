using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidarAgua.strings
{
    public class Utilidades
    {
        // Variables string del sistema

        // Menu principal

        public const string STRING_MENU_TITULO_PRINCIPAL                            = "***** MENU LIQUIDAR AGUA ***** \n";

        public const string STRING_MENU_OPCIONES_PRINCIPAL                          = "1. Ingresar Registro \n" +
                                                                                      "2. Consultar Registro \n" +
                                                                                      "3. Número Boletas Entregadas \n" +
                                                                                      "4. Total a Recibir \n" +
                                                                                      "5. Promedio de Consumo \n" +
                                                                                      "6. Estrato más Repetido \n" + 
                                                                                      "7. Generar Copia del Recibo a Pagar \n" +
                                                                                      "8. Salir \n";

        public const string STRING_MENU_BYE                                         = " Hasta pronto !! \n Enter para cerrar";
        
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Menu Registro

        public const string STRING_MENU_TITULO_REGISTRO                             = "***** MENU REGISTRO ***** \n";
        public const string STRING_OPCION_REGISTRO                                  = "Número Registro \n";
        public const string STRING_OPCION_DIRECCION                                 = "Dirección \n";
        public const string STRING_OPCION_ESTRATO                                   = "Estrato \n";
        public const string STRING_OPCION_LECTURA_ACTUAL                            = "Lectura Actual \n";
        public const string STRING_OPCION_LECTURA_ANTERIOR                          = "Lectura Anterior \n";

        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Tabla estrato

        public const string STRING_NOMBRE_TABLA_ESTRATO                             = "tbl_estrato";
        public const string STRING_FILAS_TABLA_NOMBRE_ESTRATO                       = "estrato";
        public const string STRING_FILAS_TABLA_NOMBRE_METRO_CUBICO                  = "metro_cubico";
        public const string STRING_FILAS_TABLA_NOMBRE_ASEO                          = "aseo";
        public const string STRING_FILAS_TABLA_NOMBRE_SUBSIDIO                      = "subsidio";

        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Menu Mostrar Registro

        public const string STRING_MENU_MOSTRAR_REGISTRO_TITULO                     = "***** CONSULTAS REGISTROS ***** \n";
        public const string STRING_MENU_MOSTRAR_REGISTRO_NUMERO                     = "Ingrese el número de registro a buscar \n";

        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Tabla Registro

        public const string STRING_NOMBRE_TABLA_REGISTRO                           = "tbl_registro";
        public const string STRING_NOMBRE_OPCION_REGISTRO                          = "- Registro : ";
        public const string STRING_FILAS_TABLA_NOMBRE_REGISTRO                     = "registro";

        public const string STRING_NOMBRE_OPCION_DIRECCION                         = "- Dirección : ";
        public const string STRING_FILAS_TABLA_NOMBRE_DIRECCION                    = "direccion";

        public const string STRING_NOMBRE_OPCION_ESTRATO                           = "- Estrato : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_ESTRATO             = "estrato";

        public const string STRING_NOMBRE_OPCION_LECTURA_ACTUAL                    = "- Lectura Actual : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_LECTURA_ACTUAL      = "lectura_actual";

        public const string STRING_NOMBRE_OPCION_LECTURA_ANTERIOR                  = "- Lectura Anterior : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_LECTURA_ANTERIOR    = "lectura_anterior";

        public const string STRING_NOMBRE_OPCION_CONSUMO                           = "- Consumo : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_CONSUMO             = "consumo";

        public const string STRING_NOMBRE_OPCION_SUBSIDIO                          = "- Subsidio : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_SUBSIDIO            = "subsidio";

        public const string STRING_NOMBRE_OPCION_VALOR_AGUA                        = "- Valor Agua : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_VALOR_AGUA          = "valor_agua";

        public const string STRING_NOMBRE_OPCION_SOBRECOSTO                        = "- Sobrecosto : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_SOBRECOSTO          = "sobrecosto";

        public const string STRING_NOMBRE_OPCION_ASEO                              = "- Aseo : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_ASEO                = "aseo";

        public const string STRING_NOMBRE_OPCION_NETO_PAGAR                        = "- Neto Pagar : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_NETO_PAGAR          = "neto_pagar";

        public const string STRING_NOMBRE_OPCION_NUMERO_BOLETA                     = "- Número de Boleta : ";
        public const string STRING_FILAS_TABLA_REGISTRO_NOMBRE_NUMERO_BOLETA       = "numero_boleta";

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Mensajes Generales del Sistema

        public const string STRING_MENSAJE_REGISTRO_NO_ENTREGA                     = "No participa";
        public const string STRING_MENSAJE_REGISTRO_VALIDO                         = "Se Realizó el registro :) !";
        public const string STRING_MENSAJE_REGISTRO_NO_VALIDO                      = "Error";

        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Menu Número Boletas Entregadas

        public const string STRING_MENU_NUMERO_BOLETAS_TITULO                       = "***** Número de Boletas Entregadas ***** \n";
        public const string STRING_MOSTRAR_NUMERO_BOLETAS_REGISTRADAS               = "- Total Boletas Registradas : ";
        public const string STRING_MOSTRAR_NUMERO_BOLETAS_ENTREGADAS                = "- Total Boletas Entregadas : ";
        public const string STRING_MOSTRAR_NUMERO_BOLETAS_NO_ENTREGADAS             = "- Total Boletas No Entregadas : ";

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Menu Total a Recibir

        public const string STRING_MENU_TOTAL_RECIBIR_TITULO                        = "***** Total a Recibir ***** \n";
        public const string STRING_MENU_TOTAL_RECIBIR_VALOR                         = "- Valor : ";

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Promedio de Consumo

        public const string STRING_MENU_PROMEDIO_CONSUMO_TITULO                     = "***** Promedio de Consumo ***** \n";
        public const string STRING_MENU_PROMEDIO_CONSUMO_VALOR                      = "- Valor : ";

        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Estrato mas Repetido

        public const string STRING_MENU_ESTRATO_REPETIDO_TITULO                     = "***** Estrato más Repetido ***** \n";
        public const string STRING_MENU_ESTRATO_REPETIDO_VALOR                      = "- Estrato : ";

        //////////////////////////////////////////////////////////////////////////////////////////////

        // Menu Generar Recibo a Pagar

        public const string STRING_MENU_RECIBO_PAGAR_TITULO                         = "***** Generar Recibo a Pagar ***** \n";
        public const string STRING_MENU_RECIBO_PAGAR_RUTA_ARCHIVO                   = "C:\\Users/WilliamLeandro/Desktop/liquidar-agua-.net-consola-sqlserver/LiquidarAgua/copias recibos/recibo.txt";
        public const string STRING_MENU_RECIBO_PAGAR_REGISTRO                       = "Ingrese el número de registro \n";







    }
}

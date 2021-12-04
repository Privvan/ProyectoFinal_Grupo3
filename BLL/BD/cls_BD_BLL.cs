using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DAL.BD;

namespace BLL.BD
{
    public class cls_BD_BLL
    {
        public float fValorBLL = 0;
        public void ejemplo()
        {

            fValorBLL = Convert.ToSingle(ConfigurationManager.AppSettings["tipo_cambio_dolares"].ToString());




        }

        public void Exec_DataAdapter(ref cls_BD_DAL Obj_BD_DAL)
        {
            //PASO #1 - CREAR EL OBJETO DE CONEXION CON EL APP CONFIG
            Obj_BD_DAL.Obj_SqlCnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_AUT"].ToString().Trim());


            //PASO #2 - ABRIR LA CONEXION Y AUTENTICARME A LA BASE DE DATOS
            //Se debe cerrar una vez se haya realizado la consulta para no desperdiciar recursos, no desperdiciar los CAL
            if (Obj_BD_DAL.Obj_SqlCnx.State == ConnectionState.Closed)
            {
                Obj_BD_DAL.Obj_SqlCnx.Open();
            }

            //PASO #3 - CREAR EL DATA ADAPTER, DEFINIR EL NOMBRE DEL STORE PROCEDURE A EJECUTAR Y EL TIPO DE SEGURIDAD
            Obj_BD_DAL.Obj_SqlDap = new SqlDataAdapter(
                Obj_BD_DAL.sNomSP, // NOMBRE DEL STORE PROCEDURE A EJECUTAR, ES DECIR PERMITE EJECUTAR CUALQUIER LISTADO
                Obj_BD_DAL.Obj_SqlCnx //OBJETO SQL CONNECTION ABIERTO (PASO 2)
                );

            Obj_BD_DAL.Obj_SqlDap.SelectCommand.CommandType = CommandType.StoredProcedure; //PARA NO ENVIAR DATOS QUEMADS
                                                                                           //PARA NO ACEPTAR TEXTO PLANO, SOLAMENTE OBJETOS PREVIAMENTE CREADOS


            //PASO #4 AGREGAR PARAMETROS AL DATA TABLE

            #region AGREGAR PARAMETROS
            try
            {

                if (Obj_BD_DAL.DtParametros != null)
                {
                    SqlDbType TipoDataSQL = SqlDbType.VarChar;

                    //RECORREMOS LINEA POR LINEA EL DATATABLE
                    foreach (DataRow dr in Obj_BD_DAL.DtParametros.Rows) //Que recorra todos los rows
                    {
                        switch (dr[1])
                        {
                            case "1":
                                {
                                    TipoDataSQL = SqlDbType.Int;
                                    break;
                                }
                            case "2":
                                {
                                    TipoDataSQL = SqlDbType.Decimal;
                                    break;
                                }
                            case "3":
                                {
                                    TipoDataSQL = SqlDbType.Float;
                                    break;
                                }
                            case "4":
                                {
                                    TipoDataSQL = SqlDbType.Char;
                                    break;
                                }
                            case "5":
                                {
                                    TipoDataSQL = SqlDbType.NChar;
                                    break;
                                }
                            case "6":
                                {
                                    TipoDataSQL = SqlDbType.VarChar;
                                    break;
                                }
                            case "7":
                                {
                                    TipoDataSQL = SqlDbType.NVarChar;
                                    break;
                                }
                            case "8":
                                {
                                    TipoDataSQL = SqlDbType.DateTime;
                                    break;
                                }
                            case "9":
                                {
                                    TipoDataSQL = SqlDbType.Bit;
                                    break;
                                }
                            case "10":
                                {
                                    TipoDataSQL = SqlDbType.Money;
                                    break;
                                }



                        }



                        Obj_BD_DAL.Obj_SqlDap.SelectCommand.Parameters.Add(dr[0].ToString(), //NOMBRE DE PARAMETRO
                                                                       TipoDataSQL // EL TIPO DE DATOS QUE SE ENTIENDE EL SQL -, 
                                                                        ).Value = dr[2].ToString(); // VALOR DEL PARAMETRO


                    }

                }

                #endregion


                //PASO #5 - LIMPIEZA DEL DATA SET Y EJECUCION DEL DATA ADAPTER
                Obj_BD_DAL.DS = new DataSet();

                Obj_BD_DAL.Obj_SqlDap.Fill(Obj_BD_DAL.DS, //LUGAR DONDE QUEDA LA INFORMACIN QUE TRAE EL STORE PROCEDURE, ES DECIR EJECUTO EL SQLDAP CONECTADO A LA BASE DE DATOS
                    Obj_BD_DAL.sNomTabla // NOMBRE LOGICO DEL DATA TABLE QUE VA A CREARSE EN EN EL DS(DATA SET)
                    );
                Obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                Obj_BD_DAL.sMsjError = ex.ToString();
            }
            finally
            {
                if (Obj_BD_DAL.Obj_SqlCnx.State == ConnectionState.Open)
                {
                    Obj_BD_DAL.Obj_SqlCnx.Close(); //cerramos la coneccion
                }
                Obj_BD_DAL.Obj_SqlCnx.Dispose(); //liberamos toda la memoria del servidor y el networking
            }


        }
        ///Metodo generico para crear Datatable
        ///
        public void Crear_DT_Parametros(ref cls_BD_DAL Obj_BD_DAL)
        {
            Obj_BD_DAL.DtParametros = new DataTable("PARAMETROS_SP");

            Obj_BD_DAL.DtParametros.Columns.Add("NOMBRE_PARAMETRO");
            Obj_BD_DAL.DtParametros.Columns.Add("TP_DATO_PARAMETRO");
            Obj_BD_DAL.DtParametros.Columns.Add("VALOR_PARAMETRO");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BLL.BD;
using BLL.Catalogos;
using DAL.BD;
using DAL.Catalogos;

namespace BLL.Catalogos
{
    public class cls_Pais_BLL
    {
        #region VARIABLES GLOBALES
        cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
        cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
        #endregion

        //VAMOS A HACER UN METODO PARA CADA ACCION BASICA DE LA TABLA
        // LISTAR - FILTRAR - INSERTAR - MODIFICAR - ELIMINAR

        public void Listar(ref cls_Pais_DAL obj_Pais_DAL)
        {
            obj_BD_DAL.sNomTabla = "PAIS";
            // INSTANCIAMOS AL STORE PROCEDURE QUE QUEREMOS INSTANCIAR DEL APPSETTINGS:
            obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["Listar_Pais"].ToString().Trim();

            obj_BD_DAL.DtParametros = null; // este es null porque este metodo trae todo lo de la tabla
            //no lo voy a filtrar sino a listar

            obj_BD_BLL.Exec_DataAdapter(ref obj_BD_DAL);

            obj_Pais_DAL.dtPais = obj_BD_DAL.DS.Tables[0];
            obj_Pais_DAL.sMsjError = obj_BD_DAL.sMsjError;



        }
        public void Filtrar(ref cls_Pais_DAL obj_Pais_DAL)
        {
            obj_BD_DAL.sNomTabla = "PAIS";
            // INSTANCIAMOS AL STORE PROCEDURE QUE QUEREMOS INSTANCIAR DEL APPSETTINGS:
            obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["Filtrar_Pais"].ToString().Trim();


            //en Filtrar debemos crear los parametros del datatable, aqui si lo creamos porque
            //aqui si recibe parametros

            obj_BD_BLL.Crear_DT_Parametros(ref obj_BD_DAL);

            //Ahora le agregamos los datos:
            obj_BD_DAL.DtParametros.Rows.Add("@filtro", "5", obj_Pais_DAL.sPaisDescription);

            obj_BD_BLL.Exec_DataAdapter(ref obj_BD_DAL);

            obj_Pais_DAL.dtPais = obj_BD_DAL.DS.Tables[0];
            obj_Pais_DAL.sMsjError = obj_BD_DAL.sMsjError;
        }
        public void Insertar(ref cls_Pais_DAL obj_Pais_DAL)
        {
            //Probando cambios!
        }
        public void Modificar(ref cls_Pais_DAL obj_Pais_DAL)
        {

        }
        public void Eliminar(ref cls_Pais_DAL obj_Pais_DAL)
        {

        }
    }
}

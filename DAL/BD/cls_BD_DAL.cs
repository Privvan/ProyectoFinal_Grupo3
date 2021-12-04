using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; ///El protocolo que te ayuda a manejar los elemento del SQL
using System.Data;


namespace DAL.BD
{
    public class cls_BD_DAL
    {
        //variables para manipular el SQL
        #region VARIABLES PRIVADAS

        private SqlConnection _Obj_SqlCnx; //crear coneccion a base de datos
        private SqlDataAdapter _Obj_SqlDap; //Rellenar un dataset, manejamos todos los selects con o sin filtros, para extraer datos, select siempre devuelve datos
        private SqlCommand _Obj_Sql_Cmd; //Son las ejecuciones, con esto hacemos el CURD

        private DataSet _DS; //Cache de datos en memoria

        private string _sMsjError, _sNomSP, _sNomTabla, _sValorScalar;

        private DataTable _DtParametros; //Esto lo llenamos con el SQL

        #endregion

        public SqlConnection Obj_SqlCnx { get => _Obj_SqlCnx; set => _Obj_SqlCnx = value; }
        public SqlDataAdapter Obj_SqlDap { get => _Obj_SqlDap; set => _Obj_SqlDap = value; }
        public SqlCommand Obj_Sql_Cmd { get => _Obj_Sql_Cmd; set => _Obj_Sql_Cmd = value; }
        public DataSet DS { get => _DS; set => _DS = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public string sNomSP { get => _sNomSP; set => _sNomSP = value; }
        public string sNomTabla { get => _sNomTabla; set => _sNomTabla = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public DataTable DtParametros { get => _DtParametros; set => _DtParametros = value; }
    }
}

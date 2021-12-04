using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Catalogos
{
    public class cls_Regiones_DAL
    {
        //vamos a crear una variable por cada columna

        private DataTable _dtRegiones;

        private int _iRegionID;

        private string _SRegionDescription, _sMsjError;
        private char _cBanderaAxn;

        public DataTable dtRegiones { get => _dtRegiones; set => _dtRegiones = value; }
        public int iRegionID { get => _iRegionID; set => _iRegionID = value; }
        public string sRegionDescription { get => _SRegionDescription; set => _SRegionDescription = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public char cBanderaAxn { get => _cBanderaAxn; set => _cBanderaAxn = value; }
    }
}

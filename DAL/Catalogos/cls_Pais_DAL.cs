using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Catalogos
{
    public class cls_Pais_DAL
    {
        private DataTable _dtPais;

        private int _iPaisID;

        private int _iDireccionID;

        private string _sPaisDescription, _sMsjError;
        private char _cBanderaAxn;

        public DataTable dtPais { get => _dtPais; set => _dtPais = value; }
        public int iPaisID { get => _iPaisID; set => _iPaisID = value; }
        public int iDireccionID { get => _iDireccionID; set => _iDireccionID = value; }
        public string sPaisDescription { get => _sPaisDescription; set => _sPaisDescription = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public char cBanderaAxn { get => _cBanderaAxn; set => _cBanderaAxn = value; }
    }
}

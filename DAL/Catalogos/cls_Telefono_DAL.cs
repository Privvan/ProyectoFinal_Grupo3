using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class cls_Telefono_DAL
    {
        private DataTable _dtTelefono;

        private int _iIDTelef;

        private int _iClienteID;
        //test
        private int _iNumTelef;
        private string  _sMsjError;
        private char _cBanderaCxn;

        public DataTable dtTelefonos { get => _dtTelefono; set => _dtTelefono = value; }
        public int IDTelef { get => _iIDTelef; set => _iIDTelef = value; }
        public int IdCliente { get => _iClienteID; set => _iClienteID = value; }
        public int NumeroTelefono { get => _iNumTelef; set => _iNumTelef = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public char cBanderaAxn { get => _cBanderaCxn; set => _cBanderaCxn = value; }
    }
}

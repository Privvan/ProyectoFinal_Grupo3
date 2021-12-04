using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Catalogos;
using DAL.Catalogos;

namespace PL1.Pantalla.Principal
{
    public partial class Regiones : Form
    {

        #region VARIABLES GLOBALES
        cls_Regiones_BLL obj_Regiones_BLL = new cls_Regiones_BLL();
        cls_Regiones_DAL obj_Regiones_DAL = new cls_Regiones_DAL();
        #endregion
        public Regiones()
        {
            InitializeComponent();
        }

        private void frm_1_Load(object sender, EventArgs e)
        {
            Cargar_Datos();

        }

        private void Cargar_Datos()
        {
            dgv_Regiones.DataSource = null;

            if (tstxt_Filtro.Text == string.Empty)
            {
                obj_Regiones_BLL.Listar(ref obj_Regiones_DAL);
            }
            else
            {
                obj_Regiones_DAL.sRegionDescription = tstxt_Filtro.Text;
                obj_Regiones_BLL.Filtrar(ref obj_Regiones_DAL);
            }



            if (obj_Regiones_DAL.sMsjError == string.Empty)
            {
                dgv_Regiones.DataSource = obj_Regiones_DAL.dtRegiones;
            }
            else
            {
                MessageBox.Show("Se presentó un error a la hora de listar las regiones de la " +
                    "base de datos \n\nERROR = [ " + obj_Regiones_DAL.sMsjError + " ]",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void txt_Filtro_TextChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}

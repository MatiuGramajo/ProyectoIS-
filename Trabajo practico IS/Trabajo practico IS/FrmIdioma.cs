using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_practico_IS
{
    public partial class FrmIdioma : Form
    {
        public FrmIdioma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = TXTnombre.Text;
                string sufijo = TXTsufijo.Text;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(sufijo))
                    throw new Exception("Debe completar el nombre y el sufijo.");

                BLL.IDIOMA gestorIdioma = new BLL.IDIOMA();

                // Ejecutamos la magia
                gestorIdioma.CrearIdioma(nombre, sufijo);

                MessageBox.Show("¡Idioma creado y autotraducido con éxito!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


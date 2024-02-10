using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class frmAutenticar : Form
    {
        public frmAutenticar()
        {
            InitializeComponent();
        }

        private void frmAutenticar_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioDA usuarioDA = new UsuarioDA();
            Usuario usuario = usuarioDA.ValidaLogin(textUsuario.Text,txtContrasena.Text);
            if (usuario.IdUsuario > 0)
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas");
            }
        }
      
    }
}

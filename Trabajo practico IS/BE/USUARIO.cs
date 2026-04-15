using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class USUARIO
    {
		private int id;

		public int Id 
		{
			get { return id; }
			set { id = value; }
		}
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private bool estado;

		public bool Estado
		{
			get { return estado; }
			set { estado = value; }
		}


	}

}

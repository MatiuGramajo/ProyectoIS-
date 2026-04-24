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
		private string contraseña;

		public string Contraseña
		{
			get { return contraseña; }
			set { contraseña = value; }
		}

		private bool estadoBloqueado;

		public bool EstadoBloqueado
		{
			get { return estadoBloqueado; }
			set { estadoBloqueado = value; }
		}
		private int intentosFallidos;

		public int IntentosFallidos
		{
			get { return intentosFallidos; }
			set { intentosFallidos = value; }
		}

		private int dni;

		public int Dni
		{
			get { return dni; }
			set { dni = value; }
		}
		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		private string rol;

		public string Rol
		{
			get { return rol; }
			set { rol = value; }
		}


	}

}

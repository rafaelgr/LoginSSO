using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LonginSSOLib
{
    public class OdTrabajador
    {
        private int trabajadorId;

        public int TrabajadorId
        {
            get { return trabajadorId; }
            set { trabajadorId = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string idioma;

        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }

        private bool evaluador;

        public bool Evaluador
        {
            get { return evaluador; }
            set { evaluador = value; }
        }
    }
}

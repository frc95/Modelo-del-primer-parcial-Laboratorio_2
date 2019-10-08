using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        #region ATRIBUTOS
        private string _apellido;
        private int _legajo;
        private string _nombre;
        private float _nota;
        #endregion

        #region PROPIEDADES
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public int Legajo
        {
            get { return this._legajo; }
            set { this._legajo = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public float Nota
        {
            get { return this._nota; }
            set { this._nota = value; }
        }
        #endregion

        #region CONSTRUCTORES
        public Alumno()
        {
            this.Apellido = "";
            this.Nombre = "";
            this.Nota = 0;
            this.Legajo = 0;
        }
        public Alumno(string apellido):this()
        {
            this.Apellido = apellido;
        }
        public Alumno(string apellido, string nombre):this(apellido)
        {
            this.Nombre = nombre;
        }
        public Alumno(int legajo, string nombre, string apellido):this(apellido,nombre)
        {
            this.Legajo = legajo;
        }
        public Alumno(int legajo, string nombre, string apellido, float nota):this(legajo,nombre,apellido)
        {
            this.Nota = nota;
        }
        #endregion

        #region METODOS
        private string Mostrar()
        {
            return this.Apellido+", "+this.Nombre+" - Legajo: "+this.Legajo+" - Nota: "+this.Nota+"\n";
        }
        public string Mostrar(Alumno alumno)
        {
            return alumno.Mostrar();
        }
        #endregion

        #region OPERADORES
        public static bool operator ==(Alumno a1, Alumno a2)
        {
            bool validar = false;
            if(!Object.Equals(a1,null) && !Object.Equals(a2,null))
            {
                if(a1.Legajo==a2.Legajo)
                {
                    validar = true;
                }
            }
            return validar;
        }
        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return !(a1==a2);
        }
        #endregion
    }
}

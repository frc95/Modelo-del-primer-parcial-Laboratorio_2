using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private EMateria _nombre;
        private static Random _notaParaUnAlumno;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public EMateria Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        #endregion

        #region OPERADORES DE CONVERSION
        public static explicit operator String(Materia materia)
        {
            return materia.Mostrar();
        }
        public static implicit operator float(Materia m)
        {
            float total = 0;
            foreach(Alumno alumno in m.Alumnos)
            {
                total = total + alumno.Nota;
            }
            total = total / m.Alumnos.Count;
            return total;
        }
        public static implicit operator Materia(EMateria nombre)
        {
            Materia materia = new Materia(nombre);
            
            return materia;
        }
        #endregion

        #region CONSTRUCTORES
        private Materia()
        {
            this.Alumnos = new List<Alumno>();
        }
        static Materia()
        {
            Materia._notaParaUnAlumno = new Random();
        }
        private Materia(EMateria nombre):this()
        {
            this.Nombre = nombre;
        }
        #endregion

        #region METODOS
        public void CalificarAlumnos()
        {
            for(int i=0;i<this.Alumnos.Count;i++)
            {
                this.Alumnos[i].Nota = Materia._notaParaUnAlumno.Next(1,10);
            }
        }
        private string Mostrar()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("\nMateria: " + this.Nombre);
            datos.AppendLine("*****************************");
            datos.AppendLine("*********ALUMNOS*************");
            foreach (Alumno alumno in this.Alumnos)
            {
                datos.AppendLine(alumno.Mostrar(alumno));
            }
            return datos.ToString();
        }
        #endregion

        #region OPERADORES DE == != + -
        public static bool operator ==(Materia m, Alumno a)
        {
            bool validar = false;
            if(!Object.Equals(m,null) && !Object.Equals(a,null))
            {
                foreach(Alumno alumno in m.Alumnos)
                {
                    if(alumno==a)
                    {
                        validar = true;
                    }
                }
            }
            return validar;
        }
        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m==a);
        }
        public static Materia operator +(Materia m, Alumno a)
        {
            if(m!=a)
            {
                m.Alumnos.Add(a);
                Console.WriteLine("Se agrego el alumno a la materia {0}!!!",m.Nombre);
            }
            else
            {
                Console.WriteLine("El alumno ya esta en la materia {0}!!!", m.Nombre);
            }
            
            return m;
        }
        public static Materia operator -(Materia m, Alumno a)
        {
            if(m==a)
            {
                m.Alumnos.Remove(a);
                Console.WriteLine("Se quito el alumno de la materia {0}!!!", m.Nombre);
            }
            else
            {
                Console.WriteLine("El alummno no esta en la materia {0}!!!", m.Nombre);
            }
            return m;
        }
        #endregion


    }
}

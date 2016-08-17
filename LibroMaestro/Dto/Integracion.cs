using System;
using System.Linq;

namespace LibroMaestro.Dto
{
    public class Integracion
    {
        private bool isSelected;
        private long binaryValue;
        private string descripcion;
        private int tipo;
        private bool esObligatorio;
        private int orden;
        
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }

        public long BinaryValue
        {
            get
            {
                return this.binaryValue;
            }
            set
            {
                this.binaryValue = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public int Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        public bool EsObligatorio
        {
            get
            {
                return this.esObligatorio;
            }
            set
            {
                this.esObligatorio = value;
            }
        }

        public int Orden
        {
            get
            {
                return this.orden;
            }
            set
            {
                this.orden = value;
            }
        }
    }
}

using System;
using System.Linq;

namespace LibroMaestro.Dto
{
    public class Integracion
    {
        private bool isSelected;
        private long binaryValue;
        private string descripcion;

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
    }
}

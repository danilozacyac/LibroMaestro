using System.ComponentModel;

namespace LibroMaestro.Dto
{
    public class TesisLibro : INotifyPropertyChanged
    {
        private int idTesis;
        private int idInstancia;
        private int idOrganismo;
        private int idEpoca;
        private int idMateria;
        private string numCarpeta;
        private int tesisInicio = 1;
        private int tesisFin = 2;
        private string recibida;
        private string aprobada;
        private string clave;
        private int numTesis;
        private int tatj;
        private int ius;
        private string rubro;
        private string precedentes;
        private string publicado;
        private int fojas =1;
        private int cancelada = 0;
        private bool cambioMateria = false;
        private string fileName;
        private bool tieneEjecutoria = false;
        private long elementos;
        private string observaciones;
        private int numEje;
        private int numVotos;

        public int IdTesis
        {
            get
            {
                return this.idTesis;
            }
            set
            {
                this.idTesis = value;
                this.OnPropertyChanged("IdTesis");
            }
        }

        public int IdInstancia
        {
            get
            {
                return this.idInstancia;
            }
            set
            {
                this.idInstancia = value; this.OnPropertyChanged("IdInstancia");
            }
        }

        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value; this.OnPropertyChanged("IdOrganismo");
            }
        }

        public int IdEpoca
        {
            get
            {
                return this.idEpoca;
            }
            set
            {
                this.idEpoca = value; this.OnPropertyChanged("IdEpoca");
            }
        }

        public int IdMateria
        {
            get
            {
                return this.idMateria;
            }
            set
            {
                this.idMateria = value; this.OnPropertyChanged("IdMateria");
            }
        }

        public string NumCarpeta
        {
            get
            {
                return this.numCarpeta;
            }
            set
            {
                this.numCarpeta = value; this.OnPropertyChanged("NumCarpeta");
            }
        }

        public int TesisInicio
        {
            get
            {
                return this.tesisInicio;
            }
            set
            {
                this.tesisInicio = value; this.OnPropertyChanged("TesisInicio");
            }
        }

        public int TesisFin
        {
            get
            {
                return this.tesisFin;
            }
            set
            {
                this.tesisFin = value; this.OnPropertyChanged("TesisFin");
            }
        }

        public string Recibida
        {
            get
            {
                return this.recibida;
            }
            set
            {
                this.recibida = value; this.OnPropertyChanged("Recibida");
            }
        }

        public string Aprobada
        {
            get
            {
                return this.aprobada;
            }
            set
            {
                this.aprobada = value; this.OnPropertyChanged("Aprobada");
            }
        }

        public string Clave
        {
            get
            {
                return this.clave;
            }
            set
            {
                this.clave = value; this.OnPropertyChanged("Clave");
            }
        }

        public int NumTesis
        {
            get
            {
                return this.numTesis;
            }
            set
            {
                this.numTesis = value; this.OnPropertyChanged("NumTesis");
            }
        }

        public int Tatj
        {
            get
            {
                return this.tatj;
            }
            set
            {
                this.tatj = value; this.OnPropertyChanged("Tatj");
            }
        }

        public int Ius
        {
            get
            {
                return this.ius;
            }
            set
            {
                this.ius = value; this.OnPropertyChanged("Ius");
            }
        }

        public string Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value; this.OnPropertyChanged("Rubro");
            }
        }

        public string Precedentes
        {
            get
            {
                return this.precedentes;
            }
            set
            {
                this.precedentes = value; this.OnPropertyChanged("Precedentes");
            }
        }

        public string Publicado
        {
            get
            {
                return this.publicado;
            }
            set
            {
                this.publicado = value; this.OnPropertyChanged("Publicado");
            }
        }

        public int Fojas
        {
            get
            {
                return this.fojas;
            }
            set
            {
                this.fojas = value; this.OnPropertyChanged("Fojas");
            }
        }

        public int Cancelada
        {
            get
            {
                return this.cancelada;
            }
            set
            {
                this.cancelada = value; this.OnPropertyChanged("Cancelada");
            }
        }

        public bool CambioMateria
        {
            get
            {
                return this.cambioMateria;
            }
            set
            {
                this.cambioMateria = value; this.OnPropertyChanged("CambioMateria");
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value; this.OnPropertyChanged("FileName");
            }
        }

        public bool TieneEjecutoria
        {
            get
            {
                return this.tieneEjecutoria;
            }
            set
            {
                this.tieneEjecutoria = value; this.OnPropertyChanged("TieneEjecutoria");
            }
        }

        public long Elementos
        {
            get
            {
                return this.elementos;
            }
            set
            {
                this.elementos = value; this.OnPropertyChanged("Elementos");
            }
        }

        public string Observaciones
        {
            get
            {
                return this.observaciones;
            }
            set
            {
                this.observaciones = value; this.OnPropertyChanged("Observaciones");
            }
        }

        public int NumEje
        {
            get
            {
                return this.numEje;
            }
            set
            {
                this.numEje = value; this.OnPropertyChanged("NumEje");
            }
        }

        public int NumVotos
        {
            get
            {
                return this.numVotos;
            }
            set
            {
                this.numVotos = value; this.OnPropertyChanged("NumVotos");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion // INotifyPropertyChanged Members
    }
}
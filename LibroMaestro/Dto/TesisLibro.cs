
namespace LibroMaestro.Dto
{
    public class TesisLibro
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
        private int fojas;
        private int cancelada;
        private bool cambioMateria = false;
        private string fileName;
        private bool tieneEjecutoria = false;
        private long elementos;
        private string observaciones;

        public int IdTesis
        {
            get
            {
                return this.idTesis;
            }
            set
            {
                this.idTesis = value;
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
                this.idInstancia = value;
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
                this.idOrganismo = value;
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
                this.idEpoca = value;
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
                this.idMateria = value;
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
                this.numCarpeta = value;
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
                this.tesisInicio = value;
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
                this.tesisFin = value;
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
                this.recibida = value;
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
                this.aprobada = value;
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
                this.clave = value;
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
                this.numTesis = value;
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
                this.tatj = value;
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
                this.ius = value;
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
                this.rubro = value;
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
                this.precedentes = value;
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
                this.publicado = value;
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
                this.fojas = value;
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
                this.cancelada = value;
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
                this.cambioMateria = value;
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
                this.fileName = value;
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
                this.tieneEjecutoria = value;
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
                this.elementos = value;
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
                this.observaciones = value;
            }
        }
    }
}

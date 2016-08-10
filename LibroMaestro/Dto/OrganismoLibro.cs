using System;
using System.Collections.ObjectModel;
using System.Linq;
using DirectorioApi.Dao;

namespace LibroMaestro.Dto
{
    public class OrganismoLibro : Organismos
    {
        private ObservableCollection<TesisLibro> tesis;

        private int idInstancia;

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

        public ObservableCollection<TesisLibro> Tesis
        {
            get
            {
                return this.tesis;
            }
            set
            {
                this.tesis = value;
            }
        }
    }
}

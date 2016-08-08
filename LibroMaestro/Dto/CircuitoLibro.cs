using DirectorioApi.Dao;
using System.Collections.Generic;

namespace LibroMaestro.Dto
{
    public class CircuitoLibro : Circuito
    {
        private List<OrganismoLibro> organismosLibro;
        public List<OrganismoLibro> OrganismosLibro
        {
            get
            {
                return this.organismosLibro;
            }
            set
            {
                this.organismosLibro = value;
            }
        }
    }
}

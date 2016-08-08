using DirectorioApi.Dao;
using DirectorioApi.Models;
using LibroMaestro.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibroMaestro.Model
{
    public class CircuitoLibroModel
    {


        public List<CircuitoLibro> GetCircuito()
        {
            List<Circuito> circuitos = new CircuitosModel().GetCircuitos(0);

            List<CircuitoLibro> cirLibro = new List<CircuitoLibro>();

            foreach (Circuito circuito in circuitos)
            {
                CircuitoLibro libro = new CircuitoLibro();
                libro.IdCircuito = circuito.IdCircuito;
                libro.Descripcion = String.Format("{0} Circuito", circuito.Descripcion);
                libro.OrganismosLibro = new List<OrganismoLibro>();
                libro.OrgCircuito = new List<Organismos>();

                List<Organismos> orgs = new OrganismosModel().GetOrganismos(circuito);

                foreach (Organismos org in orgs)
                {
                    OrganismoLibro newOrg = new OrganismoLibro();
                    newOrg.IdOrganismo = org.IdOrganismo;
                    newOrg.Organismo = org.Organismo;
                    libro.OrgCircuito.Add(org);
                    libro.OrganismosLibro.Add(newOrg);
                }

                cirLibro.Add(libro);
            }

            return cirLibro;
        }

    }
}

using System.ComponentModel;

namespace Pokedex_EF.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento? Tipo { get; set; }
        public int? TipoId { get; set; }
        public Elemento? Debilidad { get; set; }
        public int? DebilidadId { get; set; }
    }
}

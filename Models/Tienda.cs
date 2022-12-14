namespace TallerCORE.Models
{
    public class Tienda
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string email { get; set; }
        public string telefonos { get; set; }

        public Tienda(decimal id = 0,  string n="", string d="", string l="", string e="", string t="")
        {
            this.id = id;
            nombre = n;
            direccion = d;
            localidad = l;
            email = e;
            telefonos = t;
        }
    }
}

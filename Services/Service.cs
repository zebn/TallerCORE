using TallerCORE.Models;

namespace TallerCORE.Services
{
    public class Service
    {
        public static List<Tienda> getTiendas()
        {
            var list = new List<Tienda>();

            Tienda t1 = new Tienda(1, "Central", "calle del pez, 1", "Alicante", "central@empresa.com", "965222324");
            list.Add(t1);

            Tienda t2 = new Tienda(2, "Playa", "calle del mar, 10", "Playa Sant Joan", "playa@empresa.com", "965266677");
            list.Add(t2);

            Tienda t3 = new Tienda(3, "Alcoi", "calle de la montaña, 100", "Alcoi", "alcoi@empresa.com", "965403938");
            list.Add(t3);

            return list;
        }
    }
}

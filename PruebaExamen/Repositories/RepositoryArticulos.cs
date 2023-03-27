using PruebaExamen.Helpers;
using PruebaExamen.Models;
using System.Xml.Linq;

namespace PruebaExamen.Repositories
{
    public class RepositoryArticulos
    {
        private HelperPathProvider helper;
        private XDocument documentArticulos;
        private string pathArticulos;

        public RepositoryArticulos(HelperPathProvider helper)
        {
            this.helper = helper;
            this.pathArticulos = this.helper.MapPath("articulos.xml", Folders.documents);
            documentArticulos = XDocument.Load(this.pathArticulos);
        }

        public ArticuloXML GetArticuloXPosicion(int posicion, ref int numeroarticulos)
        {
            //VOY A RECUPERAR LA COLECCION DE ESCENAS DE UNA PELICULA
            //PARA ELLO, UTILIZAMOS EL METODO ANTERIOR
            List<ArticuloXML> listaarticulos = this.GetAllArticulos();
            numeroarticulos = listaarticulos.Count;
            //VAMOS A PAGINAR DE UNO EN UNO
            ArticuloXML articulo = listaarticulos.Skip(posicion).Take(1).FirstOrDefault();
            return articulo;
        }


        public List<ArticuloXML> GetAllArticulos() {

            var consulta = from datos in documentArticulos.Descendants("articulo")
                           select datos;

            List<ArticuloXML> listaarticulos = new List<ArticuloXML>();
            foreach (XElement tag in consulta)
            {
                ArticuloXML articulo = new ArticuloXML();
                articulo.IdArticulo = int.Parse(tag.Attribute("idarticulo").Value);
                articulo.Nombre = tag.Element("nombre").Value;
                articulo.Descripcion = tag.Element("descripcion").Value;
                articulo.Calorias = int.Parse(tag.Element("calorias").Value);
                articulo.Proteinas = int.Parse(tag.Element("proteinas").Value);
                articulo.Hidratos = int.Parse(tag.Element("hidratos").Value);
                articulo.Glucosa = int.Parse(tag.Element("glucosa").Value);
                articulo.Cantidad = int.Parse(tag.Element("cantidad").Value);

                listaarticulos.Add(articulo);
            }
            return listaarticulos;
        }
    }
}

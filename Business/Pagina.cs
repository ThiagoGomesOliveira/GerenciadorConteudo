using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }



        public List<Pagina> Listar()
        {
            var paginaDb =  new Database.Pagina();
            var lista = new List<Pagina>();

            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                lista.Add(new Pagina() { Id = Convert.ToInt32(row["Id"]) ,
                                       Nome = row["Nome"].ToString() ,
                                   Conteudo = row["Conteudo"].ToString(),
                                       Data = Convert.ToDateTime(row["Data"])});
            }
            return lista;
        }

        public void Save()
        {
            var paginaDb = new Database.Pagina();
            paginaDb.Save(this.Id, this.Nome, this.Conteudo, this.Data);
        }

        public static Pagina BuscarPorId(int id)
        {
            var paginaDb = new Database.Pagina();
            var pagina = new Pagina();
            foreach (DataRow row in paginaDb.BuscarPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["Id"]);
                pagina.Nome = row["Nome"].ToString();
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["Data"]);
            }
            return pagina;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    public class banco
    {
        public static List<Filme> filmesList = new List<Filme>();
        public static List<Plataforma> PlataformasList= new List<Plataforma>();
    }

    public class Service1 : banco, IService1 
    {

        public List<Filme> ListFilmes()
        {
            return filmesList;
        }
        public int AddFilme(int id, Filme filme)
        {
            filmesList.Add(filme);
            return id;
        }

        public Filme GetFilme(int value)
        {
            return null;
        }
        public bool DelFilme(int id)
        {
            //foreach (var item in filmesHash)
            //{
            //    if (item.Key == id)
            //    {
            //        filmesHash.Remove(id);
            //        return true;
            //    }
            //}
            return false;
        }

        public bool UptFilme(int id, Filme filme)
        {
            //foreach (var item in filmesHash)
            //{
            //    if (item.Key == id)
            //    {
            //        filmesHash.Remove(id);
            //        filmesHash.Add(id, filme);
            //        return true;
            //    }
            //}
            return false;
        }

        public Plataforma GetPlataforma(int value)
        {
            //foreach (var item in PlataformasList)
            //{
            //    if (item.Key == value)
            //    {
            //        return item.Value;
            //    }
            //}
            return null;
        }

        public List<Plataforma> ListPlataforma()
        {
            return PlataformasList;
        }

        public bool AddPlataforma(int key, Plataforma plataforma)
        {
            PlataformasList.Add(plataforma);
            return true;
        }
        public bool DelPlataforma(int id)
        {
            //foreach (var item in PlataformasList)
            //{
            //    if (item.Key == id)
            //    {
            //        PlataformasList.Remove(id);
            //    }
            //    return true;
            //}
            return false;
        }
        public bool UptPlataforma(int id, Plataforma plataforma)
        {
            //foreach (var item in filmesHash)
            //{
            //    if (item.Key == id)
            //    {
            //        PlataformasList.Remove(id);
            //        PlataformasList.Add(id, plataforma);
            //        return true;
            //    }
            //}
            return false;
        }
    }
}

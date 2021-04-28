using Client.Models;
using Client.WebServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class FilmeController : Controller
    {
        WebServico.Service1Client y = new WebServico.Service1Client();

        // GET: Filme
        public ActionResult Index()
        {
            List<FilmeModels> temp = new List<FilmeModels>();

            foreach (var item in y.ListFilmes())
            {
                temp.Add(new FilmeModels() { dataLancamento = item.dataLancamento, descricao = item.descricao, duracao = item.duracao, nome = item.nome });
            }
            return View(temp);
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        public ActionResult Create(Filme obj)
        {
            try
            {
                y.AddFilme(1, new Filme() { dataLancamento = obj.dataLancamento, descricao = obj.descricao, duracao = obj.duracao, nome = obj.nome });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Filme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

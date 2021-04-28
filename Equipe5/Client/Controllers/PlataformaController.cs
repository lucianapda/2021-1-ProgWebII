using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class PlataformaController : Controller
    {
        WebServico.Service1Client y = new WebServico.Service1Client();


        // GET: Plataforma
        public ActionResult Index()
        {
            List<PlataformaModels> temp = new List<PlataformaModels>();

            foreach (var item in y.ListPlataforma())
            {
                temp.Add(new PlataformaModels() { filmes = item.filmes, tipo = item.tipo, valor = item.valor });
            }
            return View(temp);
        }
        // GET: Plataforma/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plataforma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataforma/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plataforma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plataforma/Edit/5
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

        // GET: Plataforma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plataforma/Delete/5
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

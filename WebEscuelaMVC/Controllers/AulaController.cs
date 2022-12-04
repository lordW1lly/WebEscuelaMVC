using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscuelaMVC.Models;
using System.Globalization;
using WebEscuelaMVC.Data;
using System.Data.Entity;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        // instancia del context

        private EscuelaDBMVCContext context = new EscuelaDBMVCContext();
        // GET: Aula

        public ActionResult Index()
        {
            List<Aula> listAulas = context.aulas.ToList();
            return View("Index", listAulas);
        }

        //GET: Aula/Create
        public ActionResult Create()
        {
            Aula newAula = new Aula();
            return View("Create", newAula);
        }

        [HttpPost]

        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.aulas.Add(aula);
                context.SaveChanges();
            return RedirectToAction("Index");
            } 
            else
            {
                return View("Register");
            }

        }

        public ActionResult Detail(int id)
        {
            Aula aula = context.aulas.Find(id);
            if( aula == null )
            {
                return HttpNotFound();
            }
            else
            {
                return View(aula);
            }
        }

        public ActionResult Edit (int id)
        {
            Aula aula = context.aulas.Find(id);

            if(aula == null)
            {
                return HttpNotFound();
            } else
            {
                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return View("Modified", aula);
            }

        }

        public ActionResult ListarPorEstado(string estado)
        {
            List<Aula> aulaEstado = (from e in context.aulas where estado == e.Estado select e).ToList();
            return View("Index", aulaEstado);

        }

        public ActionResult TraerPorNumero(int num)
        {
            dynamic aulaNum = (from a in context.aulas where num == a.Numero select a).ToList();
            return View("Detail", aulaNum);
        }
    }
}
using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class DossierController : Controller
    {
        IDossierService serviceDossier;
        IServiceAvocat serviceAvocat;
        IServiceClient serviceClient;

        public DossierController(IDossierService serviceDossier, IServiceAvocat serviceAvocat,
        IServiceClient serviceClient)
        {
            this.serviceDossier = serviceDossier;
            this.serviceClient = serviceClient;
            this.serviceAvocat = serviceAvocat;
        }

        // GET: DossierController
        public ActionResult Index(string nomSearch)
        {
            if (nomSearch == null)
            {
                return View(serviceDossier.GetMany());
            }
            else
                return View(serviceDossier.GetMany(c => c.Avocat.Nom.Contains(nomSearch)));
        }

        // GET: DossierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DossierController/Create
        public ActionResult Create()
        {
            ViewBag.listClient = new SelectList(serviceClient.GetMany(), "CIN", "Nom");
            ViewBag.listAvocat = new SelectList(serviceAvocat.GetMany(), "AvocatId", "Nom");


            return View();
        }

        // POST: DossierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dossier collection)
        {
            try
            {
                serviceDossier.Add(collection);
                    serviceDossier.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DossierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DossierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DossierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DossierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

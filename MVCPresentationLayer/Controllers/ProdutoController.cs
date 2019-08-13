using MVCPresentationLayer.FakeRepository;
using MVCPresentationLayer.Models;
using MVCPresentationLayer.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class ProdutoController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProdutoViewModel model)
        {
            FakeRepository.FakeProducttRepository.Add(model);
            return RedirectToAction("Index");
        }

        //meusite.com/Produto/Index
        //meusite.com/Produto
        public ActionResult Index()
        {
            return View(FakeRepository.FakeProducttRepository.GetAll());
        }

        //meusite.com/Produto/Edit/
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            List<ProdutoViewModel> produtos =
            FakeProducttRepository.GetAll();
            ProdutoViewModel viewModel = produtos.FirstOrDefault(p => p.ID == id);

            if (viewModel == null)
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
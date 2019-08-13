using BLL;
using DataAccessLayer;
using DataTypeObject;
using MVCPresentationLayer.FakeRepository;
using MVCPresentationLayer.Models;
using MVCPresentationLayer.WEB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class ClienteController : BaseController
    {
        //HttpGet -> Acesso via URL, histórico ou click em hyperlink
        //site.com/Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ClienteViewModel model)
        {
            ClienteBLL bll = new ClienteBLL();
            Cliente cliente = CustomAutoMapper<ClienteViewModel, Cliente>.Map(model);
            try
            {
                bll.Inserir(cliente);
            }
            //Erro nas validações do BLL
            catch (HotelException ex)
            {
                //Forma de comunicar a View que existem erros!
                //Pode-se utilizar também o TempData["Errors"]
                ViewBag.Errors = ex.GetErrorMessage();
                return View();
            }
            //Erro no banco
            catch(Exception ex)
            {
                ViewBag.Errors = "Erro no banco de dados, contate o adm";
                return View();
            }
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Index()
        {
            //Retornará a View com a Lista de ClienteViewModel passada
            //como parâmetro. A view então, percorrerá cliente por cliente
            //e o renderizará em uma table (html)
            return View(FakeClientRepository.GetAll());
        }


        //meusite.com/Cliente/Edit/15
        //Uso de inicialização de parâmetro, onde o mvc irá dar
        //um valor pro ID, mesmo que a rota não possua o ID
        public ActionResult Edit(int id = 0)
        {
            //Retorna pra página inicial do Cliente caso o ID seja inválido
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            List<ClienteViewModel> clientes = FakeClientRepository.GetAll();

            ClienteViewModel cliente = clientes.FirstOrDefault(c => c.ID == id);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            FakeClientRepository.Edit(cliente);
            return RedirectToAction("Index");
        }


    }
}
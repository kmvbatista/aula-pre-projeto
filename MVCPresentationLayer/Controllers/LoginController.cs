using BLL;
using DataTypeObject;
using MvcPresentationLayer.WEB;
using MVCPresentationLayer.Models;
using MVCPresentationLayer.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            UsuarioBLL bll = new UsuarioBLL();
            try
            {
                Usuario user = bll.Autenticar(login.UserName, login.Password);
                if (user == null)
                {
                    ViewBag.Errors = "Usuario e/ou senha inválidos.";
                    return View();
                }

                //Linha que CRIA o cookie
                Cookie.Set(Cookie.CookieName, user.ToString());

                //Como ler o usuário que esta usando o sistema
                //Usuario usuario = Usuario.Parse(Cookie.Get(Cookie.CookieName));

            }
            catch (HotelException ex)
            {
                ViewBag.Errors = ex.GetErrorMessage();
                return View();
            }
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoginViewModel login)
        {
            UsuarioBLL bll = new UsuarioBLL();
            bll.Inserir(CustomAutoMapper<LoginViewModel, Usuario>.Map(login));
            return View();
        }
    }
}
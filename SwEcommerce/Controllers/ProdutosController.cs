using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SwEcommerce.Models;
using NHibernate;
using NHibernate.Linq;

namespace SwEcommerce.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Produtoss = session.Query<Produtos>().ToList();
                return View(Produtoss);
            }
            return View();
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            List<SelectListItem> Promocoes = new List<SelectListItem>();
            Promocoes.Add(new SelectListItem { Value = "", Text = "...Selecione", Selected = true });
            Promocoes.Add(new SelectListItem { Value = "1;2", Text = "Pague 1 e Leve 2", });
            Promocoes.Add(new SelectListItem { Value = "3;10", Text = "3 por 10 reais", });
            ViewBag.Promocoes = Promocoes.ToList();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produtos Produtos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Produtos);
                        transaction.Commit();
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Produtos = session.Get<Produtos>(id);
                return View(Produtos);
            }
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produtos Produtos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var ProdutostoUpdate = session.Get<Produtos>(id);

                    ProdutostoUpdate.identificador = Produtos.identificador;
                    ProdutostoUpdate.Nome = Produtos.Nome;
                    ProdutostoUpdate.Preco = Produtos.Preco;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(ProdutostoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Produtos = session.Get<Produtos>(id);               
                return View(Produtos);
            }
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produtos Produtos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        Produtos.identificador = id;
                        session.Delete(Produtos);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using SwEcommerce.Models;
using System;
namespace SwEcommerce.Controllers
{

    public class CarrinhoController : Controller
    {
        List<Produtos> Compras = new List<Produtos>();
        // GET: Carrinho
        public ActionResult Index(Produtos produto, List<Produtos> Comprados)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Criando Dropdownlist de Promoções
                List<SelectListItem> Promocoes = new List<SelectListItem>();
                Promocoes.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "...Selecione",
                    Selected = true
                });
                Promocoes.Add(new SelectListItem
                {
                    Value = "1",
                    Text = "Pague 1 e Leve 2",
                });
                Promocoes.Add(new SelectListItem
                {
                    Value = "3",
                    Text = "3 por 10 reais",
                });

                ViewBag.Promocoes = Promocoes.ToList();

                // Criando Dropdownlist de Produtos
                var Produtoss = session.Query<Produtos>().ToList();
                
                //Adiciono um produto vazio para que o seletor venha com nada preenchido para poder , e no onchange colocar preco no produto atraves do cadastro no model.
                Produtoss.Add(null);
                
                //Passando para a view para criar o dropdown de escolha.
                //  ViewBag.Compras = produto;
                ViewBag.Produtoss = Produtoss;

                if (produto.identificador != 0)
                {
                    if (Session["Compras"] != null)
                    {
                        foreach (Produtos prd in Session["Compras"] as IEnumerable<Produtos>)
                        {
                            Compras.Add(prd);
                        }

                    }

                    //Implementando Promoções
                    switch (produto.PromoId)
                    {
                        case 1:
                            produto.Quantidade = 2;
                            break;

                        case 3:
                            //Se o produto encontrado tiver a promocção de 3x10 então ele tratará cada unidade como multiplo de 3 e o valor unitario como R$10.
                            produto.Preco = produto.Quantidade * 10;
                            produto.Quantidade = produto.Quantidade * 3;

                            break;
                    }
                    Compras.Add(produto);
                    

                    Session["Compras"] = Compras;

                    //produto = (SwEcommerce.Models.Produtos) Session["Compras"];
                    ViewBag.compras = Compras;
                }
                return View();

            }
        }
        [HttpPost]
        public ActionResult Index(Produtos produto)
        {
            //Simular comprar sem persistencia
            //return View("Index",produto);
            return RedirectToAction("Index", produto);

        }

        //Recupera dados para preencher combos e campos dinamicamente 
        public JsonResult GetDadosProdutos(int id)
        {
            object ProdutoPrecoNome;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                ProdutoPrecoNome = new
                {
                    Nome = session.Get<Produtos>(id).Nome.Trim(),
                    Preco = session.Get<Produtos>(id).Preco
                };
            }
            return Json(ProdutoPrecoNome, JsonRequestBehavior.AllowGet);
        }


    }


}
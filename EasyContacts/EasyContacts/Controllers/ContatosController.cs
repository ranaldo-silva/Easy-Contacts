using EasyContacts.Models;
using EasyContacts.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Para usar o SelectList
using System;
using System.Linq; // Para usar o Select

namespace EasyContacts.Controllers
{
    public class ContatosController : Controller
    {
        // GET: Contatos (READ - Listar todos)
        // Também tratará a pesquisa 
        public IActionResult Index(string pesquisaNome)
        {
            List<Contato> contatos;
            if (string.IsNullOrEmpty(pesquisaNome))
            {
                contatos = ContatoRepository.Listar(); // Lista todos
            }
            else
            {
                // Sua funcionalidade de "pesquisa por nome"
                contatos = ContatoRepository.PesquisarPorNome(pesquisaNome);
                ViewBag.Pesquisa = pesquisaNome; // Para manter o valor no campo de busca
            }
            return View(contatos);
        }

        // GET: Contatos/Details/5 (READ - Detalhes)
        public IActionResult Details(int id)
        {
            var contato = ContatoRepository.ObterPorId(id);
            if (contato == null) return NotFound();
            return View(contato);
        }

        // GET: Contatos/Create (CREATE - Mostrar formulário)
        public IActionResult Create()
        {
            // Requisito: Enviar dados do Controller para a View 
            // Vamos enviar a lista de Tipos de Contato (Enum)
            ViewBag.TiposContato = new SelectList(
                Enum.GetValues(typeof(TipoContato)).Cast<TipoContato>()
            );
            return View();
        }

        // POST: Contatos/Create (CREATE - Salvar dados)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                ContatoRepository.Criar(contato);
                return RedirectToAction(nameof(Index));
            }
            // Se o modelo for inválido, reenvia os dados do Enum para o formulário
            ViewBag.TiposContato = new SelectList(
                Enum.GetValues(typeof(TipoContato)).Cast<TipoContato>()
            );
            return View(contato);
        }

        // GET: Contatos/Edit/5 (UPDATE - Mostrar formulário)
        public IActionResult Edit(int id)
        {
            var contato = ContatoRepository.ObterPorId(id);
            if (contato == null) return NotFound();

            // Envia os dados do Enum para a View 
            ViewBag.TiposContato = new SelectList(
                Enum.GetValues(typeof(TipoContato)).Cast<TipoContato>(),
                contato.Tipo // Pré-seleciona o valor atual
            );
            return View(contato);
        }

        // POST: Contatos/Edit/5 (UPDATE - Salvar dados)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contato contato)
        {
            if (id != contato.Id) return NotFound();

            if (ModelState.IsValid)
            {
                ContatoRepository.Atualizar(contato);
                return RedirectToAction(nameof(Index));
            }
            // Se o modelo for inválido, reenvia os dados do Enum
            ViewBag.TiposContato = new SelectList(
                Enum.GetValues(typeof(TipoContato)).Cast<TipoContato>(),
                contato.Tipo
            );
            return View(contato);
        }

        // GET: Contatos/Delete/5 (DELETE - Mostrar confirmação)
        // Requisito: Confirmação da remoção 
        public IActionResult Delete(int id)
        {
            var contato = ContatoRepository.ObterPorId(id);
            if (contato == null) return NotFound();
            return View(contato);
        }

        // POST: Contatos/Delete/5 (DELETE - Executar remoção)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ContatoRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
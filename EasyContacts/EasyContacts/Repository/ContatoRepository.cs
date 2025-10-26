using EasyContacts.Models;
using System.Collections.Generic;
using System.Linq;

namespace EasyContacts.Repository
{
    public static class ContatoRepository
    {
        // Lista estática para simular o banco de dados
        private static List<Contato> _contatos = new List<Contato>();
        private static int _nextId = 1; // Para simular o Auto-Incremento do ID

        // Operação READ (Listar Todos)
        public static List<Contato> Listar()
        {
            return _contatos;
        }

        // Operação READ (Buscar por Id)
        public static Contato ObterPorId(int id)
        {
            return _contatos.FirstOrDefault(c => c.Id == id);
        }

        // Operação CREATE
        public static void Criar(Contato contato)
        {
            contato.Id = _nextId++;
            _contatos.Add(contato);
        }

        // Operação UPDATE
        public static void Atualizar(Contato contatoAtualizado)
        {
            var contatoExistente = _contatos.FirstOrDefault(c => c.Id == contatoAtualizado.Id);
            if (contatoExistente != null)
            {
                contatoExistente.Nome = contatoAtualizado.Nome;
                contatoExistente.Telefone = contatoAtualizado.Telefone;
                contatoExistente.Email = contatoAtualizado.Email;
                contatoExistente.DataNascimento = contatoAtualizado.DataNascimento;
                contatoExistente.Tipo = contatoAtualizado.Tipo;
            }
        }

        // Operação DELETE
        public static void Remover(int id)
        {
            var contato = _contatos.FirstOrDefault(c => c.Id == id);
            if (contato != null)
            {
                _contatos.Remove(contato);
            }
        }

        // Operação SEARCH (Pesquisa por nome) 
        public static List<Contato> PesquisarPorNome(string nome)
        {
            return _contatos
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
                .ToList();
        }
    }
}
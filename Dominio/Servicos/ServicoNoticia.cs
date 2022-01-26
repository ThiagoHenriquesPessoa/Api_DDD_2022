using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoNoticia : IServicoNoticia
    {
        private readonly INoticia _INoticia;

        public ServicoNoticia(INoticia iNoticia)
        {
            _INoticia = iNoticia;
        }

        public async Task AdicionaNoticia(Noticia noticia)
        {
            var vallidarTitulo = noticia.ValidaPropriedadeString(noticia.Titulo, "Titulo");
            var vallidarInformacao = noticia.ValidaPropriedadeString(noticia.Informacao, "Informacao");
            if (vallidarTitulo && vallidarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Adicionar(noticia);
            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var vallidarTitulo = noticia.ValidaPropriedadeString(noticia.Titulo, "Titulo");
            var vallidarInformacao = noticia.ValidaPropriedadeString(noticia.Informacao, "Informacao");
            if (vallidarTitulo && vallidarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Atualizar(noticia);
            }
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _INoticia.ListarNoticias(n => n.Ativo);
        }
    }
}

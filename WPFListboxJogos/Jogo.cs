using System;

namespace WPFListboxJogos
{
    public class Jogo
    {

        public string Id { get; set; }
        public string Titulo { get; set; }

        public string Preco { get; set; }
        public string imagem;
        public string Imagem { get { return imagem; } set { imagem = value; } }

        public Uri UriImagem { get { return new Uri("http://cstrix.com/teste/imagens/jogos/" + imagem); } }

        public Jogo(string id, string titulo, string preco, string imagem)
        {
            Id = id;
            Titulo = titulo;
            Preco = preco;
            this.imagem = imagem;
        }
    }
}

using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        
        [Fact]
        public void RertornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Parse("2024-10-28"), DateTime.Parse("2024-11-02"));
            double precoSemDesconto = 100.00;
            double desconto = 20.00;
            double precoComDesconto = precoSemDesconto - desconto;

            OfertaViagem Oferta = new OfertaViagem(rota, periodo, precoSemDesconto);
            

            //act
            Oferta.Desconto = desconto;
            Oferta.Descontar();

            //assert
            Assert.Equal(precoComDesconto, Oferta.Preco);

        }

        [Fact]
        public void RertornaDescontoMáximoQuandoValorDescontoMaiorQuePreco()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Parse("2024-10-28"), DateTime.Parse("2024-11-02"));
            double precoSemDesconto = 100.00;
            double desconto = 220.00;
            double precoComDesconto = 30;

            OfertaViagem Oferta = new OfertaViagem(rota, periodo, precoSemDesconto);


            //act
            Oferta.Desconto = desconto;
            Oferta.Descontar();

            //assert
            Assert.Equal(precoComDesconto, Oferta.Preco);

        }

        [Fact]
        public void RertornaPrecoNormalQuandoValorDescontoNegativo()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Parse("2024-10-28"), DateTime.Parse("2024-11-02"));
            double precoSemDesconto = 100.00;
            double desconto = -100;
            double precoComDesconto = 100;

            OfertaViagem Oferta = new OfertaViagem(rota, periodo, precoSemDesconto);


            //act
            Oferta.Desconto = desconto;
            Oferta.Descontar();

            //assert
            Assert.Equal(precoComDesconto, Oferta.Preco);

        }




    }
}

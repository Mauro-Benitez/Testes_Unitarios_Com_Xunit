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

        [Theory]
        [InlineData(220.00, 30)]
        [InlineData(100.00, 30)]            
        public void RertornaDescontoMáximoQuandoValorDescontoMaiorOuIgualAoPreco(double desconto, double precoComDesconto)
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Parse("2024-10-28"), DateTime.Parse("2024-11-02"));
            double precoSemDesconto = 100.00;


             OfertaViagem Oferta = new OfertaViagem(rota, periodo, precoSemDesconto);


            //act
            Oferta.Desconto = desconto;
            Oferta.Descontar();

            //assert
            Assert.Equal(precoComDesconto, Oferta.Preco);

        }

        [Theory]
        [InlineData(-100, 100.00)]       
        public void RertornaPrecoNormalQuandoValorDescontoMenorQueZero(double desconto, double precoComDesconto)
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Parse("2024-10-28"), DateTime.Parse("2024-11-02"));
            double precoSemDesconto = 100.00;
           

            OfertaViagem Oferta = new OfertaViagem(rota, periodo, precoSemDesconto);


            //act
            Oferta.Desconto = desconto;
            Oferta.Descontar();

            //assert
            Assert.Equal(precoComDesconto, Oferta.Preco);

        }






    }
}

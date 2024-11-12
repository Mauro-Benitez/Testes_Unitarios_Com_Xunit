using JornadaMilhasV1.Modelos;
using System.Runtime.ConstrainedExecution;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("",null, "2024-01-01", "2024-01-02",0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-10-28", "2024-11-02", 100.0, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Vitoria" , "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]

        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda,
            string dataVolta, double preco, bool validacao)
        {
            //cenario - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));
            

            //ação - act
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //validação - assert
            Assert.Equal(validacao, ofertaViagem.EhValido);


        }


        [Fact]
        public void RetornaMensagemDeErroDeRotaNulaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 10, 28), new DateTime(2024, 11, 02));
            double preco = 100.0;

          


            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);



            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", ofertaViagem.Erros.Sumario);

            Assert.False(ofertaViagem.EhValido);
        }


        [Fact]
        public void RetornaMensagemDeErroDePeriodoInvalidosQuandoPeriodoInvalido()
        {
            //cenario - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste"); 
            Periodo periodo = new Periodo(new DateTime(2024, 11, 02), new DateTime(2024, 10, 28));
            double preco = 100.0;

            //ação - act
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //validação - assert
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta", ofertaViagem.Erros.Sumario);
            Assert.False(ofertaViagem.EhValido);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void RetornaMensagemDeErroDePrecoInvalidosQuandoPrecoMenorQueZero(double preco)
        {
            // arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 10, 28), new DateTime(2024, 11, 02));
            

            //act
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", ofertaViagem.Erros.Sumario);

        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
        {
            // arrange
            Rota rota =  null;
            Periodo periodo = new Periodo(new DateTime(2025, 10, 28), new DateTime(2024, 11, 02));
            int quantidadeErro = 3;

            //act
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, -10);
          


            //assert
            Assert.Equal(quantidadeErro, ofertaViagem.Erros.Count());
           
        }
    }
}
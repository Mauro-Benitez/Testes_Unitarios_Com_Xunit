using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            //cenario - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 10, 28), new DateTime(2024, 11, 02));
            double preco = 100.0;
            var validacao = true;


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


        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidosQuandoPrecoMenorQueZero()
        {
            // arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 10, 28), new DateTime(2024, 11, 02));
            double preco = -100.0;

            //act
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", ofertaViagem.Erros.Sumario);
           





        }
    }
}
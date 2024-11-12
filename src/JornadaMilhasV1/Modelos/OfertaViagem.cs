using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class OfertaViagem: Valida
{
    public const double DESCONTOMAXIMO = 0.70;
    public int Id { get; set; }
    public Rota Rota { get; set; } 
    public Periodo Periodo { get; set; }
    public double Preco { get; set; }
    public double Desconto { get; set; }


    public OfertaViagem(Rota rota, Periodo periodo, double preco)
    {
        
        Rota = rota;
        Periodo = periodo;
        Preco = preco;    

        Validar();


    }
    public OfertaViagem(Rota rota, Periodo periodo, double preco, double desconto)
    {    
        Rota = rota;
        Periodo = periodo;
        Preco = preco - desconto;
        Validar();
    }

    //desconto maximo 70%
    public void Descontar()
    {      

        if (Desconto >= Preco)
        {
            Preco -= Preco * DESCONTOMAXIMO;
        }
        else if(Desconto > 0) Preco -= Desconto;

        Preco = Preco;
    }


    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {Periodo.DataInicial.ToShortDateString()}, Data de Volta: {Periodo.DataFinal.ToShortDateString()}, Preço: {Preco:C}";
    }

    protected override void Validar()
    {
        if (!Periodo.EhValido)
        {
            Erros.RegistrarErro(Periodo.Erros.Sumario);
        } 
        if (Rota == null || Periodo == null)
        {
            Erros.RegistrarErro("A oferta de viagem não possui rota ou período válidos.");
        } 
        if (Preco <= 0)
        {
            Erros.RegistrarErro("O preço da oferta de viagem deve ser maior que zero.");
        }
    }
}

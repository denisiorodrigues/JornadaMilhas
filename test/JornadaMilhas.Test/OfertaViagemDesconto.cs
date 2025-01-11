using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAtualizadoQunadoAplicadoDesconto()
    {
        //arrange
        Rota rota = new Rota("origem", "destino");
        Periodo periodo = new Periodo(new DateTime(2025,01,01), new DateTime(2025,02,01));
        double precoOriginal = 100.00;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        //act
        oferta.Desconto = desconto;
        
        //arrenge
        Assert.Equal(precoComDesconto, oferta.Preco);
    }
}
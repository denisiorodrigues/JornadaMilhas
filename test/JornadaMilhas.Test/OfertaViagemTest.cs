using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        Rota rota = new Rota("OrigemTest", "DestinoTest");
        Periodo periodo = new Periodo(new DateTime(2025, 01, 08), new DateTime(2025, 02, 02));
        double preco = 100.00;
        var validacao = true;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Equal(validacao, oferta.EhValido);
    }
    
    [Fact]
    public void TestandoOfertaComRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 01, 08), new DateTime(2025, 02, 02));
        double preco = 100.00;
        var validacao = true;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}
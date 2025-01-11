using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class GerenciadorDeOfertasRecuperaMaiorDesconto
{
    [Fact]
    public void RecuperaOfertaNulaQuandoListaVazia()
    {
        //arrange
        List<OfertaViagem> listaOferta = new List<OfertaViagem>();
        GerenciadorDeOfertas gerenciador = new GerenciadorDeOfertas(listaOferta);
        //gerenciadorDeOfertas.
        Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
        
        //act
        var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
        
        //assert
        Assert.Null(oferta);
    }
}
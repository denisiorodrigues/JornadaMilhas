using Bogus;
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
    
    // [Fact]
    // public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
    // {
    //     //arrange
    //     List<OfertaViagem> listaOferta = new List<OfertaViagem>();
    //     GerenciadorDeOfertas gerenciador = new GerenciadorDeOfertas(listaOferta);
    //     //gerenciadorDeOfertas.
    //     Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
    //     var precoEsperado = 40;
    //     
    //     //act
    //     var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
    //     
    //     //assert
    //     Assert.NotNull(oferta);
    //     Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
    // }

    [Fact]
    public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
    {
        //arrange
        var fakerPeriodo = new Faker<Periodo>()
            .CustomInstantiator(f =>
            {
                DateTime dataInicio = f.Date.Soon();
                return new Periodo(dataInicio, dataInicio.AddDays(30));    
            });
        
        var rota = new Rota("Curitiba", "São Paulo");

        var fakeOfertas = new Faker<OfertaViagem>()
            .CustomInstantiator(f => new OfertaViagem(
                rota,
                fakerPeriodo.Generate(),
                100 * f.Random.Int(1, 100))
            )
            .RuleFor(o => o.Desconto, f => 40)
            .RuleFor(o => o.Ativa, f => true);

        var ofertaEscolhida = new OfertaViagem(rota, fakerPeriodo.Generate(), 80)
        {
            Desconto = 40,
            Ativa = true,
        };

        var ofertaInativa = new OfertaViagem(rota, fakerPeriodo.Generate(), 70)
        {
            Desconto = 40,
            Ativa = false,
        };
        
        List<OfertaViagem> listaOferta = fakeOfertas.Generate(200);
        listaOferta.Add(ofertaEscolhida);
        listaOferta.Add(ofertaInativa);
        
        GerenciadorDeOfertas gerenciador = new GerenciadorDeOfertas(listaOferta);
        Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
        var precoEsperado = 40;
        
        //act
        var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
        
        //assert
        Assert.NotNull(oferta);
        Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
    }
}
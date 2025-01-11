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
        
        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        //arrenge
        Assert.Equal(precoComDesconto, oferta.Preco);
    }
    
    [Fact]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
    {
        //arrange
        Rota rota = new Rota("origem", "destino");
        Periodo periodo = new Periodo(new DateTime(2025,01,01), new DateTime(2025,02,01));
        double precoOriginal = 100.00;
        double desconto = 120.00;
        double precoComDesconto = 30;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        //act
        oferta.Desconto = desconto;
        
        //arrenge
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
    
    [Fact]
    public void RetornarPrecoOriginalQuandoDescontoForNegativo()
    {
        //arrange
        Rota rota = new Rota("origem", "destino");
        Periodo periodo = new Periodo(new DateTime(2025,01,01), new DateTime(2025,02,01));
        double precoOriginal = 100.00;
        double desconto = -1;
        double precoComDesconto = 100.00;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        //act
        oferta.Desconto = desconto;
        
        //arrenge
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }

    [Theory]
    [InlineData(120,30)]
    [InlineData(100,30)]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualAoPreco(double desconto, double precoComDesconto)
    {
        //arrange
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2025, 01, 01), new DateTime(2025, 02, 01));
        double precoOriginal = 100.00;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        //act
        oferta.Desconto = desconto;
        
        //assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}
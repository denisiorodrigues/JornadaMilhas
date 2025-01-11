using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
    [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
    public void RetornaOfertaValidaQuandoDadosValidos(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Equal(validacao, oferta.EhValido);
    }
    
    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 01, 08), new DateTime(2025, 02, 02));
        double preco = 100.00;
        var validacao = true;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
    
    [Fact]
    public void RetornaMensagemDeErroDePeriodoQuandoDataInicialMaiorQueFinal()
    {
        Rota rota = new Rota("OrigemTest", "DestinoTest");
        Periodo periodo = new Periodo(new DateTime(2025, 01, 08), new DateTime(2024, 02, 02));
        double preco = 100.00;
        var validacao = true;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-250)]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero(double preco)
    {
        // arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2025, 01, 08), new DateTime(2025, 02, 02));
        string mensagemErroRetorno = "O preço da oferta de viagem deve ser maior que zero.";

        // act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        // assert
        Assert.Contains(mensagemErroRetorno, oferta.Erros.Sumario);
    }

    [Fact]
    public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPRecoSaoInvalidos()
    {
        //arrange
        int quantidadeErros = 3;
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 06, 08), new DateTime(2025, 02, 02));
        double preco = -100.00;
        
        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        //assert
        Assert.Equal(quantidadeErros, oferta.Erros.Count());
    }
}
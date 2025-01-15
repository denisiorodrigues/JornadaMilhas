using Bogus;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class MusicaTest
{
    [Theory]
    [InlineData("")]
    [InlineData("Minha História")]
    public void InicializaNomeCorretamenteQuandoCastradaNovaMusica(string nome)
    {
        //Arrange
        
        //Act
        var musica = new Musica(nome);
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(nome, musica.Nome);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(0)]
    public void ValidaroSeOIndetificadorDaMusicaFoiInicializado(int id)
    {
        //Arrange
        string nomeDaMusica = new Faker("pt_BR").Lorem.Word();;

        //Act
        var musica = new Musica(nomeDaMusica) { Id = id };
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(id, musica.Id);
    } 
    
    [Theory]
    [InlineData("Música Teste", "Nome: Música Teste")]
    [InlineData("Outra Música", "Nome: Outra Música")]
    [InlineData("Mais uma Música", "Nome: Mais uma Música")]
    public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoToString
        (string nome, string saidaEsperada)
    {
        // Arrange
        Musica musica = new Musica(nome);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        musica.ExibirFichaTecnica();
        string saidaAtual = stringWriter.ToString().Trim();

        // Assert
        Assert.Equal(saidaEsperada, saidaAtual);
    }
    
    [Fact]
    public void RetornarToStringDoObjetoEValidandoORsultadoEsperado()
    {
        //Arrange
        int id = new Faker().Random.Int();
        string nome = new Faker("pt_BR").Lorem.Word();
        var musica = new Musica(nome) { Id = id };
        string toStringEsperado = $"Id: {id} Nome: {nome}";
        
        //Act
        string resultado = musica.ToString();
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(resultado, toStringEsperado);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void RetornarAnoDeLancamentoMaiorQueZero(int anoLancamento)
    {
        //Arrange
        string nome = new Faker("pt_BR").Lorem.Word();
        Musica musica = new Musica(nome);
        
        //Act
        musica.AnoLancamento = anoLancamento;
        
        //Assert
        Assert.Null(musica.AnoLancamento);
    }
    
    [Theory]
    [InlineData(null, "Artista desconhecido")]
    [InlineData("", "Artista desconhecido")]
    [InlineData("mario", "mario")]
    public void RetornaArtistaDesconhecidoQuandoValorInseridoEhNulo(string? nomeArtista, string nomeEsperado)
    {
        //Arrange
        string nome = new Faker("pt_BR").Lorem.Word();
        Musica musica = new Musica(nome);
        
        //Act
        musica.Artista = nomeArtista;
        
        //Assert
        Assert.Equal(nomeEsperado, musica.Artista);
    }
}
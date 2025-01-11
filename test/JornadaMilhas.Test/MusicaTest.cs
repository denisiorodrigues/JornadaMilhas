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
        string nomeDaMusica = "JornadaMilhas.Test";

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
    
    [Theory]
    [InlineData(1, "Música Teste", "Id: 1 Nome: Música Teste")]
    [InlineData(2, "Outra Música", "Id: 2 Nome: Outra Música")]
    [InlineData(3, "Mais uma Música", "Id: 3 Nome: Mais uma Música")]
    public void RetornarToStringDoObjetoEValidandoORsultadoEsperado(int id, string nome, string toStringEsperado)
    {
        //Arrange
        var musica = new Musica(nome) { Id = id };
        
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
        Musica musica = new Musica("musica1");
        
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
        Musica musica = new Musica("musica1");
        
        //Act
        musica.Artista = nomeArtista;
        
        //Assert
        Assert.Equal(nomeEsperado, musica.Artista);
    }
}
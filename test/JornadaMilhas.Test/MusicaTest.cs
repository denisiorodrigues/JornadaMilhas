using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class MusicaTest
{
    [Fact]
    public void ValidarNomeDaMusica()
    {
        //Arrange
        string nomeDaMusica = "JornadaMilhas.Test";
        
        //Act
        var musica = new Musica(nomeDaMusica);
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(nomeDaMusica, musica.Nome);
    }
    
    [Fact]
    public void ValidaroIndetificaroDaMusicaFoiinicializado()
    {
        //Arrange
        string nomeDaMusica = "JornadaMilhas.Test";
        int id = 1;

        //Act
        var musica = new Musica(nomeDaMusica) { Id = id };
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(id, musica.Id);
    } 
    
    [Fact]
    public void ValidaroRetornoToStringDeUmObjetoMusica()
    {
        //Arrange
        string nomeDaMusica = "JornadaMilhas.Test";
        int id = 1;
        var musica = new Musica(nomeDaMusica) { Id = id };
        string resultadoEsperado = $"Id: {id} Nome: {nomeDaMusica}";
        
        //Act
        string resultado = musica.ToString();
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(resultado, resultadoEsperado);
    } 
}
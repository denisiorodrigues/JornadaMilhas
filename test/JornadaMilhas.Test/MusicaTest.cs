using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class MusicaTest
{
    [Theory]
    [InlineData("")]
    [InlineData("Minha História")]
    public void RetornaNomeDaMusica(string nome)
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
    [InlineData(1, "nome da musica")]
    [InlineData(2, "")]
    public void RetornarToStringDoObjetoEValidandoORsultadoEsperado(int id, string nome)
    {
        //Arrange
        var musica = new Musica(nome) { Id = id };
        string resultadoEsperado = $"Id: {id} Nome: {nome}";
        
        //Act
        string resultado = musica.ToString();
        
        //Assert
        Assert.NotNull(musica);
        Assert.Equal(resultado, resultadoEsperado);
    } 
}
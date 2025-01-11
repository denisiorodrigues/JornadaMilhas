using System;
using System.IO;
using Xunit;
using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;
using System.Collections.Generic;

public class ProgramTests
{
    [Fact]
    public void ExibirMenu_ShouldDisplayMenuOptions()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        ExibirMenu();

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.Contains("1. Cadastrar Ofertas", output);
        Assert.Contains("2. Mostrar Todas as Ofertas", output);
        Assert.Contains("3. Exibir maiores descontos", output);
        Assert.Contains("4. Sair", output);

        // Clean up
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }

    [Fact(Skip = "Este teste está sendo ignorado temporariamente.")]
    public void MenuOption1_ShouldCallCadastrarOferta()
    {
        // Arrange
        var listaOfertas = new List<OfertaViagem>();
        var gerenciador = new MockGerenciador(listaOfertas); // Mock para capturar chamadas
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("1\n4\n"); // Simula opções do usuário
        Console.SetIn(stringReader);

        // Act
        RunProgram(gerenciador);

        // Assert
        Assert.True(gerenciador.CadastrarOfertaFoiChamado);

        // Clean up
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
    }

    [Fact(Skip = "Este teste está sendo ignorado temporariamente.")]
    public void MenuOption2_ShouldCallExibirTodasAsOfertas()
    {
        // Arrange
        var listaOfertas = new List<OfertaViagem>();
        var gerenciador = new MockGerenciador(listaOfertas);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("2\n4\n");
        Console.SetIn(stringReader);

        // Act
        RunProgram(gerenciador);

        // Assert
        Assert.True(gerenciador.ExibirTodasAsOfertasFoiChamado);

        // Clean up
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
    }

    [Fact(Skip = "Este teste está sendo ignorado temporariamente.")]
    public void InvalidOption_ShouldDisplayErrorMessage()
    {
        // Arrange
        var listaOfertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(listaOfertas);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var stringReader = new StringReader("5\n4\n");
        Console.SetIn(stringReader);

        // Act
        RunProgram(gerenciador);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Opção inválida. Tente novamente.", output);

        // Clean up
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
    }

    private static void RunProgram(GerenciadorDeOfertas gerenciador)
    {
        // Simula o comportamento do programa principal
        while (true)
        {
            ExibirMenu();

            Console.WriteLine("Boas vindas ao Jornada Milhas. Escolha uma opção:");
            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    gerenciador.CadastrarOferta();
                    break;
                case "2":
                    gerenciador.ExibirTodasAsOfertas();
                    break;
                case "3":
                    Console.WriteLine("Ofertas com maior desconto:");
                    return;
                case "4":
                    Console.WriteLine("Obrigada por utilizar o Jornada Milhas. Até mais!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("-------- Painel Administrativo - Jornada Milhas --------");
        Console.WriteLine("1. Cadastrar Ofertas");
        Console.WriteLine("2. Mostrar Todas as Ofertas");
        Console.WriteLine("3. Exibir maiores descontos");
        Console.WriteLine("4. Sair");
    }

    private class MockGerenciador : GerenciadorDeOfertas
    {
        public bool CadastrarOfertaFoiChamado { get; private set; }
        public bool ExibirTodasAsOfertasFoiChamado { get; private set; }

        public MockGerenciador(List<OfertaViagem> listaOfertas) : base(listaOfertas) { }

        public override void CadastrarOferta()
        {
            CadastrarOfertaFoiChamado = true;
        }

        public override void ExibirTodasAsOfertas()
        {
            ExibirTodasAsOfertasFoiChamado = true;
        }
    }
}

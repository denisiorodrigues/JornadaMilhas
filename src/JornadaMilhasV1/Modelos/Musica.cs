namespace JornadaMilhasV1.Modelos;

public class Musica
{    
    private int? anoLancamento;
    private string? artista;

    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }

    public string? Artista
    {
        get => artista;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                artista = "Artista desconhecido";
            }
            else
            {
                artista = value;
            }
        }
    }

    public int? AnoLancamento { 
        get => anoLancamento;
        set
        {
            if (value > 0)
            {
                anoLancamento = value;
            }
        }
    }
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
    }

    public override string ToString()
    {
        return @$"Id: {Id} Nome: {Nome}";
    }
}
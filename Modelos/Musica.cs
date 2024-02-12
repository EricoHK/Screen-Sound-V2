using System.Text.Json.Serialization;

namespace ScreenSound_04.Modelos;

internal class Musica
{
    // Definindo propriedades que correspondem aos campos do JSON

    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("year")]
    public string? AnoString { get; set; }
    [JsonPropertyName("key")]
    public int KeyInt { get; set; }

    public string Key
    {
        get
        {
            string KeyString = "";
            switch (KeyInt)
            {
                case 0: KeyString = "C";
                    break;
                case 1: KeyString = "C#";
                    break;
                case 2: KeyString = "D";
                    break;
                case 3: KeyString = "D#";
                    break;
                case 4: KeyString = "E";
                    break;
                case 5: KeyString = "F";
                    break;
            }

            return KeyString;
        }
    }
    
    public int Ano
    {
        get
        {
            return int.Parse(AnoString!);
        }
    }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração Em Segundos: {Duracao / 1000}");
        Console.WriteLine($"Gênero Musical: {Genero}");
        Console.WriteLine($"Tonalidade: {Key}");
    }
}

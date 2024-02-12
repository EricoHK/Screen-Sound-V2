using ScreenSound_04.Filtros;
using ScreenSound_04.Modelos;
using System.Text.Json;

using (HttpClient client = new())
{
    // Esse HttpClient vai ser usado só aqui.
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        // Desserialização
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!; // "!" = Não pode ser nulo.
        musicas[0].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltarMusicasPorArtista(musicas, "U2");
        //LinqFilter.FiltrarMusicasPorAno(musicas, 2014);

        var musicasPreferidasDoErico = new MusicasPreferidas("Erico");
        musicasPreferidasDoErico.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoErico.AdicionarMusicasFavoritas(musicas[2]);
        musicasPreferidasDoErico.AdicionarMusicasFavoritas(musicas[3]);
        musicasPreferidasDoErico.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasDoErico.AdicionarMusicasFavoritas(musicas[5]);

        musicasPreferidasDoErico.ExibirMusicasFavoritas();

        var musicasPreferidasDoAlfredo = new MusicasPreferidas("Alfredo");
        musicasPreferidasDoAlfredo.AdicionarMusicasFavoritas(musicas[20]);
        musicasPreferidasDoAlfredo.AdicionarMusicasFavoritas(musicas[19]);
        musicasPreferidasDoAlfredo.AdicionarMusicasFavoritas(musicas[18]);
        musicasPreferidasDoAlfredo.AdicionarMusicasFavoritas(musicas[17]);
        musicasPreferidasDoAlfredo.AdicionarMusicasFavoritas(musicas[16]);

        musicasPreferidasDoAlfredo.ExibirMusicasFavoritas();
        musicasPreferidasDoErico.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
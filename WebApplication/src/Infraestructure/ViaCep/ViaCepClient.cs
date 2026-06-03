using System.Text.Json;
public class ViaCepClient : IViaCepClient
{
    private readonly HttpClient _httpClient;


    public ViaCepClient (HttpClient httpClient)
    {
        _httpClient = httpClient; 
    }

    //Criando metodo assincrono para pegar a request e converter para string
    public async Task<ViaCepDTOs> GetCepAsync(string cep)
    {
        var response = await _httpClient.GetAsync(
            $"https://viacep.com.br/ws/{cep}/json/"
        );

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ViaCepDTOs>(json);
    }
    

}
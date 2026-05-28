using System.Text.Json;
public class ViaCepClient
{
    private readonly HttpClient _httpClient;


    public ViaCepClient (HttpClient httpClient)
    {
        _httpClient = httpClient; 
    }

    //Criando metodo assincrono para pegar a request e converter para string
    public async Task<string> JsonConvert(string cep)
    {
        var response = await _httpClient.GetAsync(
            $"https://viacep.com.br/ws/{cep}/json/"
        );

        return await response.Content.ReadAsStringAsync();
    }
    //Agora aqui eu vou converter a string para objeto
    public async Task<ViaCep> GetCep(string cep)
    {
        string json  = await JsonConvert(cep);

       return JsonSerializer.Deserialize<ViaCep>(json); 
    }
    
}
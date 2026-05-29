public interface IViaCepClient
{
    Task<ViaCepDTOs> GetCepAsync(string cep);
}
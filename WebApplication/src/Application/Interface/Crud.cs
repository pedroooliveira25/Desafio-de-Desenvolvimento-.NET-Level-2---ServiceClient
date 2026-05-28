public interface Crud<T>
{
    Task AddAsync();
    Task<T> GetByIdAsync();
    Task UpdateAsync();
    Task DeleteAsync();
    Task SaveChangesAsync();
  
}

 //No projeto N1 eu criei umas 300 interfaces, o que me fez refletir sobre a falta de necessidade daquela ação. 
//Então, aqui vou criar algo mais genérico e reutilizável.
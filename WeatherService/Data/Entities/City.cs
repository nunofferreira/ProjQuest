namespace WeatherService.Data.Entities;

// 1. Alteração do modelo
// 2. Criar a migração add-migration <nome-migração>
// 3. Correr migrações update-database

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Temperature { get; set; }
    public DateTime LastUpdated { get; set; }

    // Por convenção, permite criar a FK para Country
    // usando o nome da entidade (Country), seguido da prop (Id) que representa a PK
    public int CountryId { get; set; }

    public Country Country { get; set; }
    // Não é necessário para fazer o relacionamento Country→City
    // Para se precisarmos, no futuro, guardar os dados do país associados a uma determinada cidade
}
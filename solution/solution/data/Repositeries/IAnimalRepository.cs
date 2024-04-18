using Microsoft.AspNetCore.Mvc;

namespace database_api.data;
using database_api.data.Model;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int animalId);
    public int UpdateAnimal(int animalId, Animal updatedAnimal);
    public int DeleteAnimal(int animalId);
    public int AddAnimal([FromBody] Animal animal);
}
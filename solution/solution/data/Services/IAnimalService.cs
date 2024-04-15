using database_api.data.Model;

namespace database_api.data.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int animalId);
    void UpdateAnimal(Animal animal);
}
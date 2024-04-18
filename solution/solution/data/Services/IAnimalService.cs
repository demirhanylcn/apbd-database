using database_api.data.Model;

namespace database_api.data.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public Animal GetAnimal(int animalId);
    public int UpdateAnimal(int animalId, Animal updatedAnimal);

    public int DeleteAnimal(int animalId);
    public int AddAnimal(Animal animal);
}
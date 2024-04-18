using database_api.data;
using database_api.data.Model;
using database_api.data.Services;
using Microsoft.AspNetCore.Mvc;


public class AnimalService : IAnimalService
{
    private IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        IEnumerable<Animal> animals = _animalRepository.GetAnimals();
        if (!string.IsNullOrEmpty(orderBy))
        {
            switch (orderBy.ToLower())
            {
                case "name":
                    animals = animals.OrderBy(animal => animal.name).ToList();
                    break;
                case "description":
                    animals = animals.OrderBy(animal => animal.description).ToList();
                    break;
                case "id":
                    animals = animals.OrderBy(animal => animal.Id).ToList();
                    break;
                case "category":
                    animals = animals.OrderBy(animal => animal.category).ToList();
                    break;
                case "area":
                    animals = animals.OrderBy(animal => animal.area).ToList();
                    break;
                default:
                    animals = animals.OrderBy(animal => animal.name).ToList();
                    break;
            }
        }

        return animals;
    }

    public Animal GetAnimal(int animalId)
    {
        return _animalRepository.GetAnimal(animalId);
    }


    public int UpdateAnimal(int animalId, [FromBody] Animal updatedAnimal)
    {
        var animal = _animalRepository.GetAnimal(animalId);
        animal.name = updatedAnimal.name;
        animal.description = updatedAnimal.description;
        animal.category = updatedAnimal.category;
        animal.area = updatedAnimal.area;
        _animalRepository.UpdateAnimal(animalId, updatedAnimal);

        return _animalRepository.UpdateAnimal(animalId, updatedAnimal);
    }

    public int DeleteAnimal(int animalId)
    {
        return _animalRepository.DeleteAnimal(animalId);
    }

    public int AddAnimal([FromBody] Animal animal)
    {
        return _animalRepository.AddAnimal(animal);
    }
}
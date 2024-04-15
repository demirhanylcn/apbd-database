using System.ComponentModel.DataAnnotations;

namespace database_api.data.Model;

public class Animal
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string name { get; set; }
    [MaxLength(200)]
    public string description { get; set; }
    [Required]
    [MaxLength(200)]
    public string category { get; set; }
    [Required]
    [MaxLength(200)]
    public string area { get; set; }
}
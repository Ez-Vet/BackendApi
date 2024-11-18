namespace EzvetApi.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    
    public string Owner { get; set; }
    
    public string img { get; set; }
        
    public int Age { get; set; } 
    public string Gender { get; set; }
    public string Description { get; set; } 
}
using System.ComponentModel.DataAnnotations;

namespace ServiceTrack.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public ICollection<Ticket>? Tickets { get; set; }
}
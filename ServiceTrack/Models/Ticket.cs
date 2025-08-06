using System.ComponentModel.DataAnnotations;

namespace ServiceTrack.Models;

public enum TicketStatus { New, Assigned, InProgress, Done, Canceled }
public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    public string? Title { get; set; } = default!;
    public string? Description { get; set; } 
    public TicketStatus? Status { get; set; } =  TicketStatus.New;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ServiceTrack.Models;

public class RepairRequest
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ProblemDescription { get; set; }

    [Required]
    public string LicensePlate { get; set; }

    [Required]
    public string VehicleSideNumber { get; set; }

    [Required]
    public string Mileage { get; set; }

    public DateTime? IncidentDate { get; set; }

    [Required]
    public string ReporterName { get; set; }

    [Required]
    public string ContactNumber { get; set; }

    [Required]
    public string Location { get; set; }

    public DateTime RequestDate { get; set; } = DateTime.Now;

    // ความสัมพันธ์แบบ One-to-Many: 1 Request มีได้หลายไฟล์
    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();
}
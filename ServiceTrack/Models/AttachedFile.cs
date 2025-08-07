using System.ComponentModel.DataAnnotations;

namespace ServiceTrack.Models;

public class AttachedFile
{
    [Key]
    public int Id { get; set; }

    [Required] public string FileName { get; set; } // ชื่อไฟล์ต้นฉบับ

    [Required]
    public string StoredFileName { get; set; } // ชื่อไฟล์ที่เก็บจริงบน Server (เพื่อป้องกันชื่อซ้ำ)

    [Required]
    public string FilePath { get; set; } // Path ที่เก็บไฟล์บน Server

    // Foreign Key กลับไปยัง RepairRequest
    public int RepairRequestId { get; set; }
    public virtual RepairRequest RepairRequest { get; set; }
}
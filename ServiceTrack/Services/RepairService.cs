using Microsoft.EntityFrameworkCore;
using ServiceTrack.Components.Pages;
using ServiceTrack.Data;
using ServiceTrack.Models;

namespace ServiceTrack.Services;

public class RepairService : IRepairService
{
    private readonly AppDb _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public async Task<List<RepairRequest>> GetRequestsAsync()
    {
        // ดึงข้อมูลทั้งหมดโดยเรียงจากใหม่ไปเก่า และดึงข้อมูลไฟล์ที่เกี่ยวข้องมาด้วย
        return await _context.RepairRequests
            .Include(r => r.AttachedFiles) // ดึงข้อมูลไฟล์ที่แนบมาด้วย (เผื่อใช้ในอนาคต)
            .OrderByDescending(r => r.RequestDate) // เรียงลำดับให้รายการใหม่ล่าสุดอยู่บน
            .ToListAsync();
    }

    // Inject DbContext และ WebHostEnvironment เพื่อใช้หา Path ของ wwwroot
    public RepairService(AppDb context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task CreateRequestAsync(CreateRepairRequestDialog.NewRepairRequestModel model)
    {
        // 1. แปลงจาก UI Model เป็น Database Entity
        var newRequest = new RepairRequest
        {
            ProblemDescription = model.ProblemDescription,
            LicensePlate = model.LicensePlate,
            VehicleSideNumber = model.VehicleSideNumber,
            Mileage = model.Mileage,
            IncidentDate = model.IncidentDate,
            ReporterName = model.ReporterName,
            ContactNumber = model.ContactNumber,
            Location = model.Location,
            RequestDate = model.RequestDate
        };

        // 2. จัดการไฟล์ที่แนบมา
        if (model.AttachedFiles.Any())
        {
            // สร้างโฟลเดอร์สำหรับเก็บไฟล์ถ้ายังไม่มี
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in model.AttachedFiles)
            {
                // สร้างชื่อไฟล์ใหม่ที่ไม่ซ้ำกัน
                var storedFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine(uploadPath, storedFileName);

                // บันทึกไฟล์ลง Server
                await using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.OpenReadStream(long.MaxValue).CopyToAsync(stream);
                }

                // สร้าง Entity สำหรับไฟล์และเพิ่มเข้าไปใน Request
                var attachedFile = new AttachedFile
                {
                    FileName = file.Name,
                    StoredFileName = storedFileName,
                    FilePath = "/uploads/" + storedFileName // Path สำหรับเรียกดูผ่านเว็บ
                };
                newRequest.AttachedFiles.Add(attachedFile);
            }
        }
        
        // 3. บันทึกข้อมูลทั้งหมดลงฐานข้อมูล
        _context.RepairRequests.Add(newRequest);
        await _context.SaveChangesAsync();
    }
}
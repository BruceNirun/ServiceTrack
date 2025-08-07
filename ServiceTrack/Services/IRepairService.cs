using ServiceTrack.Components.Pages;
using ServiceTrack.Models;

namespace ServiceTrack.Services;

public interface IRepairService
{
    Task CreateRequestAsync(CreateRepairRequestDialog.NewRepairRequestModel model);
    
    Task<List<RepairRequest>> GetRequestsAsync(); 
}
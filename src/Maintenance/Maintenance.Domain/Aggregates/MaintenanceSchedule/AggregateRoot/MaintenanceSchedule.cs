using Maintenance.Domain.Aggregates.MaintenanceSchedule.Enums;

namespace Maintenance.Domain.Aggregates.MaintenanceSchedule.AggregateRoot;

public class MaintenanceSchedule : Common.Base.AggregateRoot
{
    public int VehicleId { get; private set; }
    public string MaintenanceType { get; private set; } = null!;
    public DateTime ScheduledDate { get; private set; }
    public string? Notes { get; private set; }
    public MaintenanceStatus Status { get; private set; }

    private MaintenanceSchedule() { }
    
    private MaintenanceSchedule(
        int vehicleId, 
        string maintenanceType, 
        DateTime scheduledDate, 
        string? notes)
    {
        VehicleId = vehicleId;
        MaintenanceType = maintenanceType;
        ScheduledDate = scheduledDate;
        Notes = notes;
        Status = MaintenanceStatus.Scheduled;
    }
    
    public static MaintenanceSchedule Schedule(
        int vehicleId, 
        string maintenanceType, 
        DateTime scheduledDate, 
        string? notes)
    {
        if (string.IsNullOrWhiteSpace(maintenanceType))
            throw new ArgumentNullException(nameof(maintenanceType));
            
        if (scheduledDate < DateTime.UtcNow)
            throw new ArgumentException("Scheduled date cannot be in the past", nameof(scheduledDate));
            
        return new MaintenanceSchedule(vehicleId, maintenanceType, scheduledDate, notes);
    }
    
    public void Complete()
    {
        if (Status != MaintenanceStatus.Scheduled)
            throw new InvalidOperationException("Only scheduled maintenance can be completed");
            
        Status = MaintenanceStatus.Completed;
    }
    
    public void Cancel(string reason)
    {
        if (Status != MaintenanceStatus.Scheduled)
            throw new InvalidOperationException("Only scheduled maintenance can be cancelled");
            
        Status = MaintenanceStatus.Cancelled;
        Notes = reason;
    }
    
    public void Reschedule(DateTime newScheduledDate)
    {
        if (Status != MaintenanceStatus.Scheduled)
            throw new InvalidOperationException("Only scheduled maintenance can be rescheduled");
            
        if (newScheduledDate < DateTime.UtcNow)
            throw new ArgumentException("New scheduled date cannot be in the past", nameof(newScheduledDate));
     
        ScheduledDate = newScheduledDate;
    }
}
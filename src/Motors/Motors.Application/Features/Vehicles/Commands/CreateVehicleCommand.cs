using MediatR;

namespace Motors.Application.Features.Vehicles.Commands;

public record CreateVehicleCommand : IRequest<int>
{
    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly? Date { get; set; }
}
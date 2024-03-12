using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Notifications
{
    public record ProductUpdatedNotification(Product Product) : INotification;
}

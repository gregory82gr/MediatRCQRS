using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;

}

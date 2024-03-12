using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Commands
{
    public record DeleteProductCommand(int id) : IRequest;
}

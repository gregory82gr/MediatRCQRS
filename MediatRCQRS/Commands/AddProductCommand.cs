using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
    
}

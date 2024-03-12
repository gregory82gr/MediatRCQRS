using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Commands
{
        public record UpdateProductCommand(Product Product) : IRequest<Product>;
}

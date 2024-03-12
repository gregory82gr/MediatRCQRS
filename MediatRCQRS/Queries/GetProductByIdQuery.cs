using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}

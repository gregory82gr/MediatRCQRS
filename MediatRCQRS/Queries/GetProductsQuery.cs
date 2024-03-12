using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}

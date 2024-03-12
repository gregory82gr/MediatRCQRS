using MediatR;
using MediatRCQRS.Commands;
using MediatRCQRS.DataStore;
using MediatRCQRS.Models;

namespace MediatRCQRS.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public UpdateProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.UpdateProduct(request.Product);

            return request.Product;
        }
    }
}

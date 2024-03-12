using MediatR;
using MediatRCQRS.Commands;
using MediatRCQRS.DataStore;
using MediatRCQRS.Models;

namespace MediatRCQRS.Handlers
{
  
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly FakeDataStore _fakeDataStore;

        public DeleteProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteProduct(request.id);

            return;
        }
    }
}

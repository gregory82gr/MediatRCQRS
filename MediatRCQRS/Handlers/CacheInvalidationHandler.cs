﻿using MediatR;
using MediatRCQRS.DataStore;
using MediatRCQRS.Notifications;

namespace MediatRCQRS.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}

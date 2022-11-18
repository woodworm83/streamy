﻿using Microsoft.Extensions.DependencyInjection;

namespace Streamy.EventStore;

internal sealed class EventStoreProvider : IEventStoreProvider
{
    public void RegisterServices(IServiceCollection services, Type aggregateIdType)
        => services
            .AddTransient(
                typeof(IEventStore<>).MakeGenericType(aggregateIdType), 
                typeof(EventStore<>).MakeGenericType(aggregateIdType))
            .AddTransient(
                typeof(IEventSerializer<>).MakeGenericType(aggregateIdType), 
                typeof(EventSerializer<>).MakeGenericType(aggregateIdType))
            .AddSingleton(
                typeof(IEventTypeResolver<>).MakeGenericType(aggregateIdType),
                typeof(EventTypeResolver<>).MakeGenericType(aggregateIdType))
            .AddTransient(
                typeof(IStreamNamingConvention<>).MakeGenericType(aggregateIdType),
                typeof(StreamNamingConvention<>).MakeGenericType(aggregateIdType));
}
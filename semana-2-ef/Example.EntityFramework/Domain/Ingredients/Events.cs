using Example.EntityFramework.Domain.Core;

namespace Example.EntityFramework.Domain.Ingredients;

public class AddIngredientEvent(Guid id, Guid entityId, object? data) : OutboxEvent(id, entityId, OutboxEventType.Add, data) { }

public class RemoveIngredientEvent(Guid id, Guid entityId, object? data) : OutboxEvent(id, entityId, OutboxEventType.Remove, data) { }

---
uid: DOM_events
---

# DOM events

A DOM manager sends out various events when actions are done on the DOM objects. These can be create, read, update, or delete (CRUD) events or a status transition event.

## CRUD events

These types of events contain lists with the created, updated, and deleted objects. They also have a *ModuleId* property, which contains the module ID of the DOM manager that generated them.

| Event name | Description |
|--|--|
| DomInstancesChangedEventMessage | Generated when a `DOMInstance` is created, updated, or deleted. |
| DomTemplatesChangedEventMessage | Generated when a `DOMTemplate` is created, updated, or deleted. |
| DomDefinitionsChangedEventMessage | Generated when a `DOMDefinition` is created, updated, or deleted. |
| DomSectionDefinitionsChangedEventMessage | Generated when a `SectionDefinition` is created, updated, or deleted. |
| DomBehaviorDefinitionsChangedEventMessage | Generated when a `DOMBehaviorDefinition` is created, updated, or deleted. |

### Filtering CRUD events

When subscribing to event messages you can use the `ModuleEventSubscriptionFilter` to only receive the messages of a specific type and for a specific module ID.

```csharp
// In this example we take the Connection object from the script's Engine object
var connection = engine.GetUserConnection();

// Create a random set ID that identifies our subscription
var setId = $"DomInstanceSubscription_{Guid.NewGuid()}"

// Create the filter for the DomInstance events, and with the module ID of our DomManager
var subscriptionFilter = new ModuleEventSubscriptionFilter<DomInstancesChangedEventMessage>("a_module_id");

// Attach a callback when a new event message arrives
connection.OnNewMessage += (sender, args) =>
{
    // Handle the events
}

// Subscribe
connection.AddSubscription(setId, subscriptionFilter);
```

## Status transition event

In addition to the CRUD Events, there is also a `DomInstanceStatusChangedEventMessage` event. This event is sent when a status transition happens on a `DOMInstance` (see [status system](xref:DOM_status_system).

This event contains a list of changes as well as the `ModuleId` of the `DomManager` that generated the transition. A change contains the following items:

- `DomInstanceID`: The ID of the `DOMInstance` of which the status changed.

- `FromStatus`: The status of the `DOMInstance` before the transition.

- `ToStatus`: The status of the `DOMInstance` after the transition.

- `Username`: The username of the user who executed the transition.

> [!NOTE]
>
> - Exposers (`DomInstanceStatusChangedEventExposers`) are available for the filtering for each of these fields.
> - The event contains a list of changes. However, at present, this only consists of a single change. Nevertheless, we recommend that any API consumer is able to handle more changes, since this behavior could change in the future (e.g. batching of events).

### Filtering status transition events

Apart from the [module filter](#filtering-crud-events), which can also be used for the status events, you can also configure a filter on the event contents. To do so, use a `SubscriptionFilter` that contains a `FilterElement`. If you use this as a second filter, for example, you will only receive status events for a specific `DOMInstance` and when the status changes to a specific type.

> [!NOTE]
>
> - Only one `ModuleEventSubscriptionFilter` is supported for each subscription set. If you want to subscribe to events of multiple DOM managers, you will have to create another subscription for each one.
> - The ***ModuleEventSubscriptionFilter* takes precedence over any other filter for a module event** (e.g. DOM CRUD or status events). When such a filter is defined and the module event does not match the specified module ID, it will never be returned for that subscription. If it is a match, it will be returned depending on the remaining filters. If there are no other filters, it is simply returned. This does not influence non-module events.

```csharp
// In this example we take the Connection object from the script's Engine object
var connection = engine.GetUserConnection();

// Create a random set ID that identifies our subscription
var setId = $"DomInstanceStatusSubscription_{Guid.NewGuid()}"

// Create the filter for the DomInstanceStatusChange events, and with the module ID of our DomManager
var subscriptionFilter = new ModuleEventSubscriptionFilter<DomInstanceStatusChangedEventMessage>("a_module_id");

// Create a filter to only receive events for a specific DomInstance with a specific 'to status'
var subscriptionFilterTwo = new SubscriptionFilter<DomInstanceStatusChangedEventMessage, DomInstanceStatusChange>(
    new ANDFilterElement(DomInstanceStatusChangedEventExposers.DomInstanceId.Equal(domInstance.ID.Id), DomInstanceStatusChangedEventExposers.ToStatus.Equal("to_status_id")));

// Attach a callback when a new event message arrives
connection.OnNewMessage += (sender, args) =>
{
    // Handle the events
}

// Subscribe
connection.AddSubscription(setId, subscriptionFilter, subscriptionFilterTwo);
```

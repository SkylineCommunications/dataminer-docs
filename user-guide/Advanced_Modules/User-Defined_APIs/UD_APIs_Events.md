---
uid: UD_APIs_Events
---

# User-Defined APIs Events

The User-Defined APIs manager sends out various events when actions are done on the `ApiToken` or `ApiDefinition` objects. These can be create, update, or delete (CRUD) events. These types of events contain lists with the created, updated, and deleted objects.

| Event name | Description |
|--|--|
| ApiTokenChangedEventMessage  | Generated when a [ApiToken](xref:UD_APIs_Objects_ApiToken) is created, updated, or deleted. |
| ApiDefinitionChangedEventMessage  | Generated when a [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) is created, updated, or deleted. |

> [!NOTE]
> These event messages are available from DataMiner 10.4.6/10.5.0 onwards.

## Filtering CRUD events

When subscribing to event messages you can use the `SubscriptionFilter` to only receive the messages matching a filter.

```csharp
// In this example we take the Connection object from the script's Engine object
var connection = engine.GetUserConnection();

// Create a random set ID that identifies our subscription
var setId = $"ApiTokenSubscription_{Guid.NewGuid()}"

// Create the filter for the ApiToken events, only enabled tokens should match
var filter = ApiTokenExposers.IsDisabled.Equal(false);
var subscriptionFilter = new SubscriptionFilter<ApiTokenChangedEventMessage, ApiToken>(filter);

// Attach a callback when a new event message arrives
connection.OnNewMessage += (sender, args) =>
{
    // Handle the events
}

// Subscribe
connection.AddSubscription(setId, subscriptionFilter);
```

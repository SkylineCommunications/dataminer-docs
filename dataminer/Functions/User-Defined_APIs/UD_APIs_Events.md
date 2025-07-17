---
uid: UD_APIs_Events
---

# User-Defined API events

The User-Defined API manager will send out an event whenever an `ApiToken` or `ApiDefinition` object is created, updated, or deleted.

| Event name | Description |
|---|---|
| ApiTokenChangedEventMessage       | Generated when an [ApiToken](xref:UD_APIs_Objects_ApiToken) is created, updated, or deleted. |
| ApiDefinitionChangedEventMessage  | Generated when an [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) is created, updated, or deleted. |

> [!NOTE]
> These event messages are available from DataMiner 10.4.6/10.5.0 onwards.<!-- RN 39117 --> From DataMiner 10.3.0 [CU17]/10.4.0 [CU5]/10.4.8 onwards, Cube will subscribe to these events and update the Automation module and the *System Center* > *User-Defined APIs* page with any recent changes.<!-- RN 39238 -->

## Filtering CRUD events

When subscribing to event messages, you can use the `SubscriptionFilter` to only receive the messages matching a specific filter. See the following example.

```csharp
// In this example, the Connection object is taken from the script's Engine object
var connection = engine.GetUserConnection();

// Create a random set ID that identifies the subscription
var setId = $"ApiTokenSubscription_{Guid.NewGuid()}"

// Create the filter for the ApiToken events; only enabled tokens should match
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

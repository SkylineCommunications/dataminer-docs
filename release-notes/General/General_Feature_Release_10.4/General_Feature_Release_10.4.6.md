---
uid: General_Feature_Release_10.4.6
---

# General Feature Release 10.4.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.6](xref:Cube_Feature_Release_10.4.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.6](xref:Web_apps_Feature_Release_10.4.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### User-defined APIs: An event will now be sent when an ApiToken or ApiDefinition is created, updated or deleted [ID_39117]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, the user-defined API manager will send out an event whenever an `ApiToken` or `ApiDefinition` object is created, update or deleted.

| Event name | Description |
|---|---|
| ApiTokenChangedEventMessage      | Generated when an [ApiToken](xref:UD_APIs_Objects_ApiToken) is created, updated, or deleted. |
| ApiDefinitionChangedEventMessage | Generated when an [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) is created, updated, or deleted. |

When subscribing to event messages, you can use the `SubscriptionFilter` to only receive the messages matching a specific filter. See the following example.

```csharp
// In this example, you will take the Connection object from the script's Engine object
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

#### Storage as a Service: Support for data migration towards a STaaS system using a proxy server [ID_39313]

<!-- MR 10.5.0 - FR 10.4.6 -->

As from DataMiner version 10.4.5, Storage as Service (STaaS) supports the use of a proxy server.

From now on, it is also possible to migrate data towards a STaaS system that is using a proxy server.

## Changes

### Enhancements

#### Service & Resource Management: Enhanced performance when activating function DVEs [ID_38972]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when activating function DVEs.

#### Enhanced performance when processing changes made to service properties [ID_39011]

<!-- MR 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing changes made to service properties.

#### NATS configuration files will now use plain JSON syntax [ID_39078]

<!-- MR 10.5.0 - FR 10.4.6 -->

All NATS configuration files will now use plain JSON syntax.

#### GQI: Changing the minimum log level no longer requires an SLHelper restart [ID_39309]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, when you changed the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config`, the change would only take effect after an SLHelper restart.

From now on, when you change this setting, the change will take effect the moment you save the configuration file. Restarting SLHelper will no longer be necessary.

### Fixes

*No fixes have been added yet.*

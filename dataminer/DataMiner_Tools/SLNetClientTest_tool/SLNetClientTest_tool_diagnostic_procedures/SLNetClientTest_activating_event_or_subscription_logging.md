---
uid: SLNetClientTest_activating_event_or_subscription_logging
---

# Activating event cache or subscription logging

Available from DataMiner 10.6.3/10.7.0 onwards<!--RN 44361-->.

To activate event cache or subscription logging:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *EventCacheLogOptions* (Logs to *SLEventCache.txt*) or *SubscriptionLogOptions* (Logs to *SLSubscriptionLog.txt*).

   A list of the Agents in the cluster will be displayed, indicating for each of them whether the selected option is active and what options are used.

1. In the *Value* column, right-click and select *Edit value* (or double click) the value for the Agent for which you wish to edit the used options (the available options are listed below).

1. Specify one of the filter values mentioned below, and click *OK*.

> [!NOTE]
> The specified filter options will be saved into the file *MaintenanceSettings.xml* under the `<SLNet>` tag as `<EventCacheLogOptions>` and `<SubscriptionLogOptions>`. This is not synchronized across Agents in the DMS.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Event type and cache key filtering (for both event cache and subscription logging)

You can apply a filter so that only logging for specific event types (for example, *ParameterChangeEventMessage*) and/or specific cache keys (for example, DataMinerID/ElementID/ParameterID) is recorded.

To do so, provide a value **prefixed** by `filter=`. Multiple values can be combined using a semicolon (";") as separator.

For filtering on event types, you can use the following values:

- **element** (short for *ElementInfoEventMessage*)
- **alarm** (short for *AlarmEventMessage*)
- **dma** (short for *DataMinerExtendedStateEvent*)
- **parameter** (short for *ParameterChangeEventMessage*)
- **alarmfocusevent** (short for *Skyline.DataMiner.Analytics.AlarmFocus.AlarmFocusEvent*)
- **radgroupinfoevent** (short for *Skyline.DataMiner.Analytics.Rad.RadGroupInfoEvent*)
- **stateiconchangeevent** (short for *Skyline.DataMiner.Analytics.Arrows.StateIconChangeEvent*)
- any other message type from the *Skyline.DataMiner.Net.Messages* namespace

For filtering on cache keys, the available formats are:

- HostingDataMinerID/DataMinerID/ElementID/ParameterID
- DataMinerID
- DataMinerID/ElementID
- DataMinerID/ElementID/ParameterID

## Event action type logging (only for event cache logging)

You can apply a filter so that only specific types of event actions are included in the event cache logging.

To do so, provide one of the values listed below. **No prefix** is required for this. However, you can combine this filter with *filter=* prefixed values. Multiple values can be combined using a semicolon (";") as separator.

For filtering on event actions, you can use the following values:

- **adds**: Logs when an event is added to the cache, also mentioning which exact event.
- **clears**: Logs when an event is cleared from the cache, without mentioning which exact event.
- **detailed_clear**: Logs when an event is cleared from the cache, also mentioning which exact event.
- **send_initial**: Logs when initial events are forwarded to a subscribed client, also mentioning which exact events.
- **detailed_send**: Logs when events are forwarded to subscribed clients, also mentioning which exact events.
- **all**: Combines the *adds*, *clears*, and *send_initial* options.
- **all_detailed**: Combines the *all*, *detailed_clear*, and *detailed_send* options.

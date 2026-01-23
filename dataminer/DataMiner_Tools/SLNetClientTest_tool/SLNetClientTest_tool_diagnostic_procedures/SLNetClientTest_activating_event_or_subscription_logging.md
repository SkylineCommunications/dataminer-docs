---
uid: SLNetClientTest_activating_event_or_subscription_logging
---

# Activating event cache or subscription logging

To activate event cache or subscription logging:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *EventCacheLogOptions* (will log to *SLEventCache.txt*) or *SubscriptionLogOptions* (will log to *SLSubscriptionLog.txt*).

   A list of the Agents in the cluster will be displayed, indicating for each of them whether the selected option is active and what options are used.

1. In the *Value* column, right-click and select *Edit value* (or double click) the value for the Agent for which you wish to edit the used options (the available options are listed below).

1. Enter “true” and click *OK*.

## Event type and cache key filtering (for both *EventCacheLogOptions* and *SubscriptionLogOptions*)

You can filter these logs on specific event types (e.g. *ParameterChangeEventMessage*) and/or specific cache keys (e.g. DataMinerID/ElementID/ParameterID).

To do so you have to provide a value prefixed by *filter=*. Multiple values can also be provided, separated by a semicolon *;*.

For filtering on event types the options are:

- element (shorthand for *ElementInfoEventMessage*)
- alarm (shorthand for *AlarmEventMessage*)
- dma (shorthand for *DataMinerExtendedStateEvent*)
- parameter (shorthand for *ParameterChangeEventMessage*)
- alarmfocusevent (shorthand for *Skyline.DataMiner.Analytics.AlarmFocus.AlarmFocusEvent*)
- radgroupinfoevent (shorthand for *Skyline.DataMiner.Analytics.Rad.RadGroupInfoEvent*)
- stateiconchangeevent (shorthand for *Skyline.DataMiner.Analytics.Arrows.StateIconChangeEvent*)
- any other message type from the *Skyline.DataMiner.Net.Messages* namespace

For filtering on cache keys the available formats are:

- HostingDataMinerID/DataMinerID/ElementID/ParameterID
- DataMinerID
- DataMinerID/ElementID
- DataMinerID/ElementID/ParameterID

## Type of logging (only for *EventCacheLogOptions*)

You can filter the event log on types of event actions, for this no prefix is required. This can also be combined with *filter=* prefixed values, or multiple values can be provided by separating with a semicolon *;*.

For filtering on event actions the options are:

- adds: will log when an event is added to the cache, also mentioning which exact events
- clears: will log when an event is cleared from the cache, without mentioning which exact events
- detailed_clear: will log when an event is cleared from the cache, also mentioning which exact events
- send_initial: will log when initial events are forwarded to a subscribed client, also mentioning which exact events
- detailed_send: will log when events are forwarded to subscribed clients, also mentioning which exact events
- all: a combination of adds, clears and send_initial
- all_detailed: a combination of all, detailed_clear and detailed_send

> [!NOTE]
> This option is saved into the file *MaintenanceSettings.xml* under the *\<SLNet>* tag. It is not synchronized across Agents in the DMS.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

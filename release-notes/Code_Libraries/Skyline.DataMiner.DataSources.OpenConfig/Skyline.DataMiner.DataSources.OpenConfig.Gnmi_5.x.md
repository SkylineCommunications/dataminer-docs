---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_5.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 5.x

## 5.0.0

#### Fix - Stored cell values not cleared on row deletion in the DataMinerConnectorDataMapper [ID 41379]

The `DataMinerConnectorDataMapper` retains the last known value for each cell in memory. Previously, when a gNMI notification was received to delete a row, the corresponding cell values were not cleared from memory. This issue has now been resolved.

#### Support for notification throttling in the DataMinerConnectorDataMapper [ID 41177]

The `DataMinerConnectorDataMapper` implementation now includes a new `ThrottleInterval` configuration option.

This setting allows you to define the time interval (in milliseconds) during which gNMI notifications are applied to the in-memory data model. Once the interval elapses, the accumulated updates are bundled and forwarded to SLProtocol as a complete row update. This reduces the frequency of SLProtocol calls, potentially improving overall throughput.

By default, this feature is enabled with a `ThrottleInterval` set to 2 seconds. However, notifications from `ON_CHANGE` subscriptions are never throttled.

This feature addresses scenarios where subscription updates are sent cell by cell. By using a `ThrottleInterval`, cell updates are aggregated, and entire rows are updated at once, optimizing performance.

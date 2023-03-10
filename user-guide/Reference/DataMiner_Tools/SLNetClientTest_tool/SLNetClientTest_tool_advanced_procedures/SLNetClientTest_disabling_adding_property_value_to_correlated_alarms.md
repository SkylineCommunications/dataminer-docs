---
uid: SLNetClientTest_disabling_adding_property_value_to_correlated_alarms
---

# Disabling adding of alarm property value to correlated alarms

From DataMiner 10.3.4/10.4.0 onwards, it is possible to disable the behavior that automatically adds the alarm property value to correlated alarms in the case a correlation rule was configured to use alarm grouping via an alarm property.

To do so, add the `NewAlarmOptions.DisableGroupedProperty` flag to the `NewAlarmActionDefinition.Properties` using the SLNetClientTest tool.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

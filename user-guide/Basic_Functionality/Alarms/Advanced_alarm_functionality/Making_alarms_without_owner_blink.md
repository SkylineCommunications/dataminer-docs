---
uid: Making_alarms_without_owner_blink
---

# Making alarms without owner blink

In DataMiner Cube, parameters, elements, services, redundancy groups and views can be set to blink if they have an alarm of which nobody has taken ownership.

There can for instance be:

- Blinking elements, services and redundancy groups in the Surveyor, in card headers and in view card summaries.

- Blinking parameters on data display pages, data display page buttons, and parameter search results.

- Blinking shapes in Visual Overview, depending on the Visual Overview configuration.

The settings that control this blinking behavior are configured in the *\<AlarmSettings>* section of the file *MaintenanceSettings.xml*.

It is also possible to specify alarm filters, so that blinking is only enabled based on conditions specified in the filters. This is possible on four different levels: on view level, on service level, on element level and on alarm level. You can also specify an additional service severity filter for services that have a severity limit.

> [!NOTE]
> If you activate blinking, this is applied on all elements, services, views, etc. This means that if no filter of a particular type is applied, that type of item will blink. In other words, filters are not exclusive. If, for example, you configure a view filter, it only applies to views, not to elements.

- [Activating alarm blinking on a DMA](#activating-alarm-blinking-on-a-dma)

- [Overview of filter attributes](#overview-of-filter-attributes)

> [!TIP]
> See also:
>
> - [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)
> - [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions)

## Activating alarm blinking on a DMA

1. Stop the DataMiner software.

1. On a DataMiner Agent, open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

1. In the *\<AlarmSettings>* tag, specify a *\<Blinking>* tag like the following one:

   ```xml
   <AlarmSettings>
     <Blinking enabled="true"
       alarmFilter="MyPublicAlarmFilter"
       elementFilter="MyPublicElementFilter"
       serviceFilter="MyPublicServiceFilter"
       viewFilter="MyPublicViewFilter"
       serviceSeveritiesFilter="minor,major"
       blankInterval="200"
     blinkInterval="1000" />
   </AlarmSettings>
   ```

1. Save the file and restart the DMA.

   In case DataMiner Cube was open while you edited the settings, the changes will only be applied after you close and reopen Cube.

> [!NOTE]
> Only public alarm filters can be used, not private filters.

## Overview of filter attributes

The following filter attributes can be used:

| Attribute | Description |
|--|--|
| alarmFilter | The name of a shared, public alarm filter. Alarms will only blink if they match the filter. |
| elementFilter | The name of a shared, public alarm filter. Elements will only blink if they match the filter. |
| serviceFilter | The name of a shared, public alarm filter. Services will only blink if they match the filter. |
| viewFilter | The name of a shared, public alarm filter. Views will only blink if they match the filter. Note that any alarm that is contained in a view that matches the filter will blink, and any other views that contain that same alarm will also blink. |
| serviceSeveritiesFilter | Comma-separated list of alarm severities. If the overall alarm severity of a service matches one of the listed severities, it will blink. |

> [!NOTE]
> If you only set the *serviceFilter* attribute and not the *serviceSeveritiesFilter*, you could see services blink that are not supposed to blink. This is because the alarm severity of a service can be limited to a certain level during service creation. However, if only a *serviceFilter* is set, then alarms that are not within the set limit could still make the service blink. By specifying a *serviceSeveritiesFilter*, you can correct this unwanted behavior, by adding the specific severities for which the service is allowed to blink.

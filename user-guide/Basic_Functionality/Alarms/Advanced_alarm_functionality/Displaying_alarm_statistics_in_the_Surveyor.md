---
uid: Displaying_alarm_statistics_in_the_Surveyor
---

# Displaying alarm statistics in the Surveyor

In the Surveyor, statistical alarm data can be displayed next to elements, services and views.

The settings that control the data being displayed have to be configured in *MaintenanceSettings.xml* and are synchronized across all DMAs in the DMS.

> [!TIP]
> See also: [Surveyor – Displaying alarm statistics](https://community.dataminer.services/video/surveyor-displaying-alarm-statistics/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Configuration in MaintenanceSettings.xml

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml.*

1. In the *Surveyor* tag, configure the *ViewStatistics*, *ServiceStatistics* and *ElementStatistics* subtags.

   To do so, enter strings consisting of fixed text, placeholders and section separators. These strings will determine which information will be displayed and how it will be displayed.

   - The following placeholders can be used:

     | Elements            | Services              | Alarms              |
     |-----------------------|-----------------------|---------------------|
     | \[#CriticalElements\] | \[#CriticalServices\] | \[#CriticalAlarms\] |
     | \[#MajorElements\]    | \[#MajorServices\]    | \[#MajorAlarms\]    |
     | \[#MinorElements\]    | \[#MinorServices\]    | \[#MinorAlarms\]    |
     | \[#WarningElements\]  | \[#WarningServices\]  | \[#WarningAlarms\]  |
     | \[#NormalElements\]   | \[#NormalServices\]   | \[#NormalAlarms\]   |
     | \[#TimeoutElements\]  | \[#TimeoutServices\]  | \[#TimeoutAlarms\]  |
     | \[#NoticeElements\]   |                      | \[#NoticeAlarms\]   |
     | \[#ErrorElements\]    |                      | \[#ErrorAlarms\]    |
     | \[#MaskedElements\]   |                      | \[#MaskedAlarms\]   |
     | \[#TotalElements\]    | \[#TotalServices\]    | \[#TotalAlarms\]    |

   - Use three hash signs (“###”) to separate sections in the *ViewStatistics*, *ServiceStatistics* and *ElementStatistics* string.

     A section is only displayed if the current value of the placeholder it contains is different from 0.

     Examples:

     ```txt
     ###[#TotalAlarms] Active alarms ###(Including [#CriticalAlarms] Critical)###
     ###[#TotalAlarms] Active Alarms: ###[#CriticalAlarms] Cr ###[#MajorAlarms] Ma ###[#MinorAlarms] Mi ###[#WarningAlarms] Wa ###[#NormalAlarms]
     Clearable ###[#NoticeAlarms] Notice ###[#ErrorAlarms] Error ###[#MaskedAlarms] Masked ###[#TimeoutAlarms] Timeout ###
     ```

     > [!NOTE]
     > On a DMA with a ticketing gateway, it is also possible to display ticket statistics, or to combine ticket statistics with alarm statistics in the Surveyor. For more information, see [Displaying ticket statistics in the Surveyor](xref:Displaying_ticket_statistics_in_the_Surveyor).

1. Save your changes and restart DataMiner.

> [!NOTE]
> If the DMA is part of a DMS, the setting will be applied across the DMS during the midnight synchronization. Alternatively, you can also force an immediate synchronization. See [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents).

## Example of a Surveyor configuration in MaintenanceSettings.xml

```xml
<MaintenanceSettings>
  ...
  <Surveyor>
    <ViewStatistics>[#TotalAlarms] Active Alarms</ViewStatistics>
    <ServiceStatistics>[#TotalAlarms] Active Alarms</ServiceStatistics>
    <ElementStatistics>[#TotalAlarms] Active Alarms</ElementStatistics>
  </Surveyor>
  ...
</MaintenanceSettings>
```

> [!TIP]
> See also: [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)

## View statistics in Visio drawings

Using the same syntax as in *MaintenanceSettings.xml*, view statistics can also be displayed in Visio drawings.

> [!TIP]
> See also: [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to)

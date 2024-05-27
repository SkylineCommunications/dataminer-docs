---
uid: Displaying_ticket_statistics_in_the_Surveyor
---

# Displaying ticket statistics in the Surveyor

In the Surveyor, ticket statistics can be displayed next to elements, services and views.

The settings that control the data being displayed have to be configured in *MaintenanceSettings.xml* and are synchronized across all DMAs in the DMS.

To do so:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml.*

1. In the *\<Surveyor>* tag, add the *\[#Tickets\]* placeholder to the *\<ViewStatistics>*, *\<ServiceStatistics>* and/or *\<ElementStatistics>* tag.

   For example:

   ```xml
   <MaintenanceSettings>
     ...
     <Surveyor>
       <ViewStatistics>[#Tickets] tickets</ViewStatistics>
       <ServiceStatistics>[#Tickets] tickets</ServiceStatistics>
       <ElementStatistics>[#Tickets] tickets</ElementStatistics>
     </Surveyor>
     ...
   </MaintenanceSettings>
   ```

   > [!NOTE]
   > From DataMiner 9.5.3 onwards, you can also add the domain name in the *\[#Tickets\]* placeholder, in order to only show statistics for a particular domain. For example: *\[#Tickets:Internal\]*

1. Save and close the file, and restart the DMA.

    > [!NOTE]
    > If the DMA is part of a DMS, the setting will be applied across the DMS during the midnight synchronization. Alternatively, you can also force an immediate synchronization. See [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents).

> [!NOTE]
>
> - It is possible to combine ticket statistics with alarm statistics in the Surveyor. For more information, see [Displaying alarm statistics in the Surveyor](xref:Displaying_alarm_statistics_in_the_Surveyor).
> - Using the same placeholder as mentioned above, ticket statistics can also be displayed in Visio drawings. See [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

> [!TIP]
> See also: [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)

---
uid: General_parameters
---

# General parameters

For each element in DataMiner, a *GENERAL PARAMETERS* page can be displayed in Cube. This page contains parameters that apply to the DataMiner element itself, rather than the device the element represents. Depending on the type of element, some general parameters may or may not be available. An overview of these parameters can be found below.

> [!NOTE]
> Replicated elements only replicate the \[Lock status\], \[Lock owner\] and \[Timer base\] general parameters.

> [!TIP]
> See also:
> [Rui’s Rapid Recap – General parameters](https://community.dataminer.services/video/ruis-rapid-recap-general-parameters/) ![Video](~/user-guide/images/video_Duo.png)

### \[Lock status\]

This general parameter indicates whether the element is locked or unlocked.

### \[Lock owner\]

If an element is locked, this general parameter indicates the user who locked the element. Otherwise the parameter is “Not initialized”.

### \[Number of active alarms\]

This general parameter indicates how many alarms are present on the element.

### \[Number of active ... alarms\]

These general parameters indicate how many alarms of particular alarm levels are present on the element.

### \[Element alarm state\]

This general parameter indicates the overall alarm state of the element, i.e. the alarm state of the non-masked alarm with the highest alarm level on the element.

### \[Number of masked alarms\]

This general parameter indicates how many masked alarms are present on the element.

### \[Latch state\]

This general parameter indicates the highest alarm level that has occurred on the element since the last time the latch state was reset. To reset the latch state, click the *Reset* button underneath this parameter.

### \[RCA Level\]

If the element is part of an RCA chain, this general parameter indicates its RCA level.

> [!TIP]
> See also:
> [Working with the Connectivity Editor](xref:Working_with_the_Connectivity_Editor)

### \[Priority Level\]

This general parameter is used in order to indicate the priority level of various elements within a redundancy group.

> [!TIP]
> See also:
> [Priority in a redundancy group](xref:About_redundancy_groups#priority-in-a-redundancy-group)

### \[Timer base\]

This parameter can be used to adjust the polling speed of the element.

> [!TIP]
> See also:
> [Changing the polling speed of an element](xref:Changing_the_polling_speed_of_an_element)

### \[Alarm System Type\]

Available from DataMiner 9.6.11 onwards. If no topology cell is defined for a monitored parameter, the value of the alarm property “System Type” will be set to the value of this general parameter.

> [!NOTE]
> - If no alarm property named "System Type" exists within the DataMiner System, it will not be created. Only creating an element with a topology cell definition will cause this alarm property to be created.
> - Updating this general parameter will not cause the values defined by a topology cell definition to be overwritten.
> - Updating this general parameter will trigger a "Property Changed" update on the active alarms of the element, even on alarms relying on the topology cell definition in the protocol rather than this general parameter.
> - Exported DVE elements will not inherit the value of this parameter from the main element. However, virtual functions (used in the SRM Solution) do inherit this parameter from the main element.

### \[Alarm System Name\]

Available from DataMiner 9.6.11 onwards. If no topology cell is defined for a monitored parameter, the value of the alarm property “System Name” will be set to the value of this general parameter.

> [!NOTE]
> - If no alarm property named "System Name" exists within the DataMiner System, it will not be created. Only creating an element with a topology cell definition will cause this alarm property to be created.
> - Updating this general parameter will not cause the values defined by a topology cell definition to be overwritten.
> - Updating this general parameter will trigger a "Property Changed" update on the active alarms of the element, even on alarms relying on the topology cell definition in the protocol rather than this general parameter.
> - Exported DVE elements will not inherit the value of this parameter from the main element. However, virtual functions (used in the SRM Solution) do inherit this parameter from the main element.

### \[Properties\]

This table contains an overview of the element properties.

> [!TIP]
> See also:
> [Element properties](xref:Element_properties)

### \[Communication info state\]

This general parameter can be used to determine whether the *\[Communication Info\]* table is updated.

### \[Communication Info\]

This table contains an overview of the different connections. For each connection, the name, type and communication state is displayed. Depending on the type of connection, additional info can be displayed.

> [!TIP]
> See also:
> [Checking the connection state of an element](xref:Checking_the_connection_state_of_an_element)

### DataMiner Connectivity Framework

The DataMiner Connectivity Framework subpage, which can be accessed via the *Configure* page button on the *General Parameters* page, contains information regarding element connectivity.

> [!TIP]
> See also:
> [Advanced Connectivity configuration](xref:Advanced_Connectivity_configuration)

### Replication Info

The Replication Info subpage, which can be accessed via the *View* page button on the *General Parameters* page, contains information about replicated elements. This subpage contains the following general parameters:

- **\[Replicated element\]**: Indicates whether the current element is a replicated element.

- **\[Remote DMA IP\]**: The IP or name of the DMA from which the element is replicated.

- **\[Remote Element Name\]**: The name of the original element that is being replicated.

- **\[Connected Replication DMAs Count\]**: Shows how many connected DMAs are replicating the element.

- **\[Connected Replication DMAs\]**: Displays all connected DMAs that replicate the element and the status of their link.

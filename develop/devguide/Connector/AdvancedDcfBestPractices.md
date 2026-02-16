---
uid: AdvancedDcfBestPractices
---

# DCF best practices

DCF allows components to be linked and enables active path highlighting. DCF connections should not be removed automatically or accidentally as this can lead to an outage of a service that users are providing to their end users (e.g., because of a reboot of the equipment, the polling request only returns partial data). Additionally, depending on the number of connections, setting up and removing these can increase the load on the system. Therefore, creating duplicate connections/interfaces or updating these too often should be avoided.

This is similar to DVEs, where automatic removal could result in a significant impact such as loss of stored data.

## Best practices for interface tables within a connector

A table should be as static as possible and implemented in a way that is similar to DVEs:

- [RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay) must be set to *true*.
- A state column should be used to track the lifespan of an interface.
- Logic should be present to remove a "Deleted" interface:
  - Automatically with a toggle button.
  - Manually with delete button in the row.
  - With a button to delete all rows with deleted status.

  > [!TIP]
  > See: [Data Handling](xref:Data_handling)

Tables generating DCF interfaces should not be updated or changed often, as this can result in an increased load on SLElement, SLProtocol and SLNet. Additionally, QActions that trigger on a change of a table generating DCF interfaces is not advised because this can cause deadlocks. DCF interfaces are created asynchronously so the QAction triggered may not immediately see the update.

For large SNMP tables, it is recommended to that you use a custom table and copy the information needed to the custom table. This allows for full control over the table rows and information. Larger tables will have a greater impact on DMA performance. Filtering via bandwidth or otherwise is advised (consult the TAM and/or customer on what the best option is).

> [!NOTE]
> The [Group@isInternal](xref:Protocol.ParameterGroups.Group-isInternal) attribute can be used to specify that a DCF interface is internal.<!-- RN 29326 --> These interfaces will not be shown to the user and will only be available internally, limiting what is shown.

### Interface alarm monitoring

A pitfall for DCF interfaces is alarm monitoring. Every update to a table will initiate a recalculation for every interface created by that table. This means that for large tables with frequent updates (e.g., bit rates), there will be a lot of DCF alarm updates, which will consume a lot of resources.

You can minimize or avoid this impact but will lose the functionality of seeing the interface alarm color linked to the alarm thresholds defined on the original table. To avoid this, you can either use the custom table method (described above) or make use of the [Group@calculateAlarmState](xref:Protocol.ParameterGroups.Group-calculateAlarmState) attribute to disable the interface state calculation.

## Best practices for creating connections

### Internal

Use the [DCF Helper](xref:AdvancedDcfHelper), which contains methods for you to create connections safely using SLNet. Make sure these connections are only updated or created as necessary. Additional updates will increase the load on the SLProtocol and SLNet processes.

### External

External connections can be managed in several ways:

- **Manager Element**: A manager element is responsible for creating connections between elements.
- **Automation script**: An automation script is used to edit connections (for example, via the EditConnection SLNet message).
- **Manual Configuration**: Users create and define the connections themselves.
- **Distributed setup: element to element**: Each element manages its connections to other elements. Note: This is risky because of overlap between elements and needs to be managed properly.

The **Skyline Generic Provisioning** connector allows provisioning of DCF external connections using Excel spreadsheets. You can export, import, and manipulate the connections using Excel. Additionally, the connector can validate some common issues such as missing or duplicate connections and provides a table with the ability to fix these.

### Using IDP

For DataMiner Systems using DataMiner IDP, IDP can be used to provision DCF connectivity for the elements in the managed inventory.

A custom script “Connectivity Discovery” per CI type can be run for an element (see [Implementing the Connectivity Discovery script](xref:ConnectivityDiscoveryScript)). Like with any custom script, it integrates with the connector and the element (the digital twin of the equipment).

In that way, existing protocols (e.g., LLDP, CDP, ARP, etc.) that expose information about a device's neighbors can be leveraged to discover and provision connectivity.

The DataMiner IDP package comes with an example script, IDP_Example_Custom_ConnectivityDiscovery, which you can use as a starting point for the development of a custom script for the connectors in the project.

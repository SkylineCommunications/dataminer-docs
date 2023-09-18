---
uid: Connector_help_Telenor_EPM_Manager
---

# Telenor EPM Manager

This connector is used to aggregate information coming from one or more collectors (see [Telenor EPM Collector](xref:Connector_help_Telenor_EPM_Collector)). These in turn aggregate their data through MAM events and Agama FireHouse export files (see [Telenor EPM Agama Consumer](xref:Connector_help_Telenor_EPM_Agama_Consumer) and Telenor EPM MAM Consumer). The connector then presents this information to the end user.

The connector has two levels of complexity:

- On the back-end (BE) level, the **BE Manager** is responsible for a specific **county**. At this level, you can define how many collectors there are. The BE Manager is responsible for managing the load balance between these elements, as well as aggregating information from the county to the front-end level.
- On the front-end (FE) level, the **FE Manager** is responsible for aggregating the information from all BE Managers (i.e. from all the counties) and presenting the result to the end user. It is the FE Manager that creates and controls the BE Manager elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                          | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Telenor EPM Agama Consumer](xref:Connector_help_Telenor_EPM_Agama_Consumer) Telenor EPM MAM Consumer [Telenor EPM Collector](xref:Connector_help_Telenor_EPM_Collector) [Telenor Propaganda](xref:Connector_help_Telenor_Propaganda) (not required - see "General" section below) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

First you need to configure an **FE Manager**. To do this, follow these steps:

1. Log in to DataMiner Cube as Administrator, so that you can see the data pages of the element.

1. Go to the **General** page, and set **Element Manager Type** to *Front-End* and **County to Monitor** to *N/A* (the default setting).

1. Go to the **Configurations** page, and specify the time configuration:

   - **Starting Period Minute**: Indicates when the first new period with collector data after the hour starts (e.g. if a new period starts each time at xx:01, set the parameter to 1).

   - **Period Length**: Indicates how long a period takes (e.g. 4 minutes). This period should be seen as the periodicity for the generation of Agama files.

   - **Period Margin**: Indicates how long the connector should wait before starting the aggregation cycle. There are two different margins, depending on the type of the element you are configuring (FE or BE). After the period margin has passed, data will be written into the parameter tables.

1. Also on the **Configurations** page, specify the **Provisioning Share Location LPI Folder** and **Provisioning Share Location SDP Folder** and add the credentials to access these folders.

1. On the **Configurations** page, you can also define the path where the FE Manager can create **logging files**. These will contain information on the inconsistencies that the FE Manager encounters when trying to build the infrastructure topology diagram.

When you have configured the FE Manager element, you can configure a **BE Manager**. The connector includes logic to facilitate the creation of a BE Manager. To do this, follow these steps:

1. Restart the element. After the restart, the FE Manager will check the paths where provisioning is configured and read how many counties there are at most. It will then check if any have already been configured.

1. Go to the **Back-End Elements** page, click **Add New Back-End**, and select a county to generate a BE Manager in the **Select County** drop-down list. Then specify the **DataMiner ID** of the DMA where the element should be created and click **Add**.

1. Go to the **Configuration** page of the newly generated element to set up its configuration.

1. Go to the **Collector Elements** page of the new element, click **Add New Collector** and specify the necessary collector elements to link to the BE Manager in the **Collector Reference** parameter, in the format DMA ID/element ID.

Once the FE Manager and BE Managers have been configured, **provisioning** must be done in the FE Manager and on all BE Managers. This can be done with the following provisioning settings on the **General** page:

- **Execute and Redistribute**: Attempts to redistribute the load (households) among the available collectors.

- **Execute**: Keeps the same infrastructure as before.

This distinction is only important for BE Managers. For the FE Manager, it does not matter which of these settings is used.

## How to Use

As this is an EPM Manager, most users should only ever use the **visual pages**. These show the content of each topology in a much more user-friendly way. For this reason, **only administrators can see the data pages**. You can find more information on these pages below.

### General

This page shows as which kind of manager the element is used: FE or BE. If the element type is set to BE, the page also shows for which county the element is responsible.

The **Telenor Propaganda** connector is used to monitor EPM Manager information, such as alarms, active devices, etc. at the end of an aggregation cycle (FE Manager). If you want to use this connector with the EPM Manager, fill in the parameter **Propaganda Element ID** in the **FE Manager** element.
There is also a button to force the synchronization between the two connectors (**Propaganda Synchronization**).

**Note:** Some parameters on the General page are read-only, but these can be changed on the **Configurations** page.

This same page also shows the **Aggregation Status** and allows you to configure the **Aggregation Downtime.** This is the number of minutes that the aggregation must wait during reprovisioning, connector update or DMA restart. The goal of this setting is to prevent aggregation being done based on an incomplete set of data, resulting in unwanted alarms and unwanted effects on trend graphs.

The **Aggregation Control** button allows you to "Resume" or "Halt" the aggregation. The **Time to Resume Aggregation** shows a countdown until the next aggregation is resumed. This happens automatically to prevent situations where a user interrupts aggregation and forgets to activate it again. You can also force aggregation to start (**Force Start Aggregations**) at any time. The total time will be displayed by the **Last Aggregation Total Time** parameter.

Finally, this page is also where you can force provisioning to start and get an overview of the provisioning process when it is done.

### Service Tree Pages

These 6 pages contain data related to the service tree topology.

### Device Type Tree Pages

These 4 pages contain data related to the device tree topology.

### Infrastructure Tree Pages

These 12 pages contain data related to the infrastructure tree topology.

### Thresholds

On this page, you can configure the **Minimum Device Monitoring Threshold**. This parameter is used to control the number of alarms that are generated. It is for instance possible to only generate an alarm in QoE if there are at least "X" devices present.

Another parameter you can configure here is the **Small Node Threshold**. Telenor monitors the Active Devices parameter at node level through smart baselines (daily pattern). In some cases, it can occur that the current value of Active Devices is 0, while the calculated baseline is not, which results in an alarm. This mainly affects smaller nodes, as it is more likely that the number of devices drops to 0 for those. This parameter allows you to configure a threshold, which can be used to configure an alarm template in such a way that false alarms are avoided for such small nodes.

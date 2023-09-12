---
uid: Connector_help_Telenor_Propaganda
---

# Telenor Propaganda

This driver is used to aggregate and summarize information from the **Telenor Channel Correlation Service Protocol**, **Telenor Service Overview Manager** and **Telenor EPM Manager** elements. It summarizes all information related to services, channels and infrastructure components (e.g. devices, households, RHE, etc.) in one single location.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                                                  | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Telenor EPM Manager](/Driver%20Help/Telenor%20EPM%20Manager.aspx) [Telenor Channel Correlation Service Protocol](/Driver%20Help/Telenor%20Channel%20Correlation%20Service%20Protocol.aspx) (version 1.0.0.3 or higher) [Telenor Service Overview Manager](xref:Connector_help_Telenor_Service_Overview_Manager) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

To make sure the element can display information, first configure all the parameters on the **Configurations** page: **EPM Manager**, **DVB-C SOM Element ID**, **Provisioning Folder**, **Credentials** and all the **EPM BE Managers** in the Back-End Elements table.

Then go to the **General** page and click **Execute Provisioning**. If the path to the folder contains all the necessary files (County.csv and Municipal.csv) and they are as expected, the **Last Provisioning State** parameter should display OK.
If the content of the files changes, execute provisioning again.

Finally, in the **Telenor EPM FE Manager** element, specify the DMA ID/element ID of this propaganda element to start receiving updates (see [Telenor EPM Manager](xref:Connector_help_Telenor_EPM_Manager) for more information).

## How to Use

### General

This page shows the **status of the element** (*Listening* or *Processing*). If the element is correctly configured, it will wait for new information from the linked components (= listening mode) and then process this information (= processing mode).

You can also provision the element on this page.

### Configurations

See "Initialization" section above.

### Service, Device and Infrastructure pages

These pages show the aggregated data for all linked components.

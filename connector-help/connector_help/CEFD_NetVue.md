---
uid: Connector_help_CEFD_NetVue
---

# CEFD NetVue

This is a virtual connector that can be used to configure a DataMiner System according to an input file. It will automatically generate all the views, services and elements. The input file has a fixed format and the content is checked before it is provisioned in the system.

## About

With this connector, you can select a CSV file saved in the Documents folder of the CEFD NetVue Element in order to provision it. Before provisioning starts, there will be a format and config check of the content of the document. If the content is OK, the views, services and elements defined in the CSV file will be installed on or removed from the system. During provisioning, it is not possible to start another provisioning action. A logging list allows you to keep track of what is being executed at a specific time.

Remote items (connectors, Automation scripts) can also interact with this connector to provision the system.

### Version Info

| **Range** | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Provisioning for NetVue 2.5.9 | No                  | Yes                     |
| 1.1.0.x          | Provisioning for NetVue 3.1.7 | No                  | Yes                     |
| 1.2.0.x          | Provisioning for NetVue 3.2   | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Input Files

The CSV file containing the configuration of the system needs to be saved in the documents folder of the **CEFD NetVue** element. You can do this on the **Documents** page of the CEFD NetVue **element card** in DataMiner Cube. The file needs to be saved in the **CEFD NetVue** folder. The format of the CSV file is fixed.

### Clustering

To enable the clustering of elements during provisioning, the **DMAs** in the system must be detected first. To have the connector detect the DMAs, click **Refresh DMA List** on the **Clustering Config** page. It is advised to make a scheduling task to trigger this action from time to time or to perform this action manually again when changes are made to the DataMiner System setup.

## Usage

### General

To start the provisioning, select the CSV file containing the configuration of the system. Then press the *Start* *provisioning* button. In the **Logging Table**, information will be added on the current actions of the connector, e.g. *NetVue Provisioning Started*. The table will also contain the name of the selected file. During provisioning, the progress bars **Provisioning Total Progress** and **Provisioning Task Progress** will display the progress of the system installation.

When **spectrum elements** are configured in the CSV file, all the **spectrum monitoring** items are generated as well. **Monitor scripts,** **preset measurements** and **point details** are retrieved where necessary to allow spectrum monitoring. For example, if on "Equipment A", a Tx and Rx frequency are filled in, spectrum monitoring items will be created using this information. When the information is removed from the file, the spectrum monitoring items will be removed from the system again. When the spectrum equipment itself is removed from the file, all of the spectrum monitoring items are deleted before the element itself is deleted.

### High Level Stats

This page displays statistics of items managed by the connector in the system, such as Number of Networks, Number of Circuits, Managed Elements (i.e. active equipment), etc.

### Network

The **Network Table** displays all the **views** created in the system after provisioning has been executed successfully. It also shows the positioning of the network item displayed in Visual Overview.

### Circuit

The **Circuit Table** displays all the **services** created in the system after provisioning has been executed successfully. It also shows the positioning of the circuit item displayed in Visual Overview.

### Equipment

The **Equipment** **Table** displays all the **elements** created in the system after provisioning has been executed successfully, along with their communication details.

### Spectrum

This page provides an overview of all the created spectrum components.

### Clustering Config

Here it is possible to configure the load balancing of the **service areas** manually. Each service area can be linked to an existing **DataMiner Agent** in the system. During provisioning, a **HUB** will always be created on the Agent that is indicated with a *Main* priority.

Elements will be added to this main Agent until it has reached the **Element Threshold**. Then elements will be populated on the Agent with the next priority until everything is created.

Services will be generated on the Agent where the HUB is located. With the **Refresh DMA List** button, you can update the overview of all the **DMAs** in the cluster.

## Notes

As this is a virtual connector, no connection to a real device is needed.

The following **spectrum** **connectors** are currently supported:

- **SED Decimator 8 port**
- **Agilent E441B**
- **Anritsu MS2721B**

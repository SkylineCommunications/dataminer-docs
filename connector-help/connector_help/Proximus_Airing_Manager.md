---
uid: Connector_help_Proximus_Airing_Manager
---

# Proximus Airing Manager

The **Proximus Airing Manager** is a manager protocol that interacts with the **EBU Synopsis Web Service** protocol to extract **transmissions** matching specific configurations and group them together in **airings**.

## About

The **Proximus Airing Manager** protocol retrieves its data by **subscribing** on the **synopses** list and **satellite** information available in the **EBU Synopsis Web Service** protocol. Note that only 1 element should be created with the EBU Synopsis Web Service protocol.

When a new synopsis is polled by the EBU Synopsis Web Service and retrieved by the Proximus Airing Manager, the Proximus Airing Manager will **extract transmissions** from that synopsis if certain conditions are met.

**Multiple transmissions** (m x n) can be exported from 1 single synopsis:

- m is the number of **matching destinations** (= 1 if product code is UNI)
- n is the number of **matching satellites**
- For more information, refer to the "Filters" subsection in the "Usage" section of this page.

When transmissions are exported, the Proximus Airing Manager will check if they can be grouped together in **airings** (all transmissions will by default be included in an airing) and a (**Resource Manager**) **reservation** will be created for each of these airings.

### Version Info

| **Range** | **Description**                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                          | No                  | Yes                     |
| 1.0.1.x          | Support multiple technicalSystems instances (in same synopsis) Primary key change in Transmissions table | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Airings

This page contains the **Airings** table, which provides an overview of all the airings that have been generated.

### Transmissions

On this page, the **Transmission** table displays all transmissions that were extracted from the synopses.

Refer to the "Filters" section below for more information about the exact details that are checked to extract a transmission.

### Synopses

On this page, the **Synopses** table displays all synopses that were received (via subscription) from the **EBU Synopsis Web Service** element.

All synopses are stored in the **Documents** folder of the DMA, and when a new synopsis is received, the **Proximus Airing Manager** will read out the **synopsis XML** to extract the necessary information.

Synopses have a specific **ID** and **version**. When a synopsis is received in the Proximus Airing Manager, it will only be processed when it is a **new synopsis**, i.e. a synopsis with a new ID or an updated version.

When a change is done to one of the filters (see "Filters" section below), this change will only be used for newly received synopses. However, if you want a synopsis to be reprocessed, click the **Reprocess** button in the **Synopses** table and the updated filters will be used.

### Channels

On this page, the **Channels** table displays the channel information that was included in the received synopses.

This information is only used by the **Manual Transmission Creation** script to add default values so any **manual transmissions** can be configured more easily.

### Filters

This page contains tables that are used as checks to export transmissions from a synopsis.

The **Destination Filters** table is a custom table where destinations can be added. Only transmissions matching these **destinations** (or **UNI** transmissions) will be extracted.

The **Satellite Families** and **Satellites** tables contain all entries received from EBU Synopsis Web Service. You can **manually enable** these satellites (if they can be used) and only transmissions matching these satellites will be extracted.

### Configuration

This page allows you to configure a number of additional settings.

You can also verify the **subscription state** of the **EBU Synopsis Web Service** here and enable **Debug Logging**.

## Notes

This protocol is intended to be used with the **Proximus Airing Manager Visio** file.

### Switching ranges

When upgrading from the **1.0.0.x** range to the **1.0.1.x** range, some actions are required to make sure that transmissions and airings are correctly generated, as the **primary keys** in the **Transmissions** table have been updated.

To make sure that the airing manager is correctly updated, follow the following procedure:

1. Clear the current transmissions and airings, using the **Clear** button on the **Configurations** page.

   Note that this will not clear the configurations.

1. Enable Synopses Processing, via **Process Synopses** on the **Synopses** page.

   This will reenable the processing of synopses and the transmissions and airings will be generated again.

---
uid: Connector_help_Skyline_SCTE_Manager
---

# Skyline SCTE Manager

The SCTE Monitor Manager provides a tracking mechanism to validate the on-time appearance of SCTE marker information in the downstream, taking as a reference a monitor start point that could be SCTE 104 or SCTE 35. As a result of this tracking, the manager generates alarms when any of the configured SCTE monitor elements do not report a matching marker during a predefined amount of time.

The SCTE Monitor Manager retrieves the information directly from Elasticsearch indexes created by any SCTE-capable connector using an agreed logger table structure. With this architecture, any video monitor solution with SCTE capability can seamlessly integrate with the SCTE Manager.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the General page, the following settings can be configured:

- By default, the connector will connect with the **Elasticsearch server** at localhost. If a different server should be used, configure this on the General page.
- The Elasticsearch user and password are empty by default, which means no credentials will be used for the queries to Elasticsearch. If **credentials** are required, configure them on the General page.

## How to Use

To configure a manager element using this connector, follow these steps:

1. **Add a new monitor:**

   1. On the **Monitors** page, click the **Monitors Configuration** button.
   1. In the pop-up window, specify the name of the **SCTE Source** and **SCTE Destination** elements, and click **Add Monitor**.

      The connector will validate the provided information and create new rows in the Source and Destination Monitor tables if they do not exist already. The created combination will start as "disabled" and will have empty program mappings. If an element does not exist in the DMS, only a message in the manager's log will be created.

1. **Configuring the mappings**: Every destination monitor should have a **program mapping** to complete the matching logic implemented in the manager. A mapping is a pair of strings indicating the program or stream name in the reference SCTE monitor and the program name in the destination SCTE monitor. More than one mapping is possible. Mappings can be created on the Mapping Configuration page.

   1. Click **Mapping Configuration**. This will display two tables, **Channel Mappings** and **Channel Mapping Relation**.
   1. If necessary, in the **Channel Mappings** table, add a new row with the strings in the source reference and destination monitors (i.e. the stream in the SCTE 104 reference and the program name in the SCTE 35 monitor).
   1. Once a mapping configuration string is available, in the **Relation Destination** and **Relation Mapping** boxes, select the **string configuration and destination pair** you created earlier.
   1. Click **Add Relation** to add the new mapping.
   1. Click **Update Mappings** to recreate the list of mappings of the destination pairs monitors. This will effectively implement the new mapping configuration.

1. **Configure the detect threshold:** In the **Destination Monitors** table, the column Detect Threshold defines the amount of time the manager should allow when matching a detected reference source marker with the configured destination monitor(s). Adjust this setting per destination pair relation to cover the maximum expected delay time.

The **Follow Up** table will contain the entries for events. The events will be added with a *Waiting* status. If a match is detected on the corresponding destination, the status will be changed to *Pass*. If no match is found on the defined detect threshold for a specific monitor, the event will be marked as *Fail*. Events will be kept in the table based on their Pass/Fail status. You can define how long should the events will be kept.

---
uid: Connector_help_Atlassian_Jira_Manager
---

# Atlassian Jira Manager

This connector is designed to sync DataMiner Ticketing with the Jira software. It syncs all Jira tickets from a selected project with a DataMiner Ticketing domain. Changes made in DataMiner are also synced back to the Jira platform.

## About

### Version Info

| **Range**            | **Key Features**                                                                          | **Based on** | **System Impact**                                                     |
|----------------------|-------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                          | \-           | \-                                                                    |
| 2.0.0.x \[SLC Main\] | Atlassian Jira dependency removed. Element configuration improved. Unicode support added. | \-           | Existing elements using this connector must be removed and recreated. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8080*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Fill in the **Jira User Name** and **Jira Password** on the Configuration page. Note that from **June 2019 onwards**, basic authentication with passwords is deprecated and instead of the password an **API token** **needs to be used** (see also [Manage API tokens for your Atlassian account \| Atlassian Support](https://support.atlassian.com/atlassian-account/docs/manage-api-tokens-for-your-atlassian-account/)).

In the 1.0.0.x range of the connector, also fill in the **Jira Element** parameter on this same page with the name of the Atlassian Jira element that handles the communication. In addition, specify the **DataMiner User Name** and **DataMiner Password** to connect to the Ticketing module.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use \[2.0.0.x\]

First fill in the **Jira User Name** and **Jira Password** to log on to the Jira software. However, note that from **June 2019 onwards**, basic authentication with passwords is deprecated and instead of the password an **API token** **needs to be used** (see also [Manage API tokens for your Atlassian account \| Atlassian Support](https://support.atlassian.com/atlassian-account/docs/manage-api-tokens-for-your-atlassian-account/)).

Use the **Select Project** parameter to select the Jira project to sync with DataMiner. **Ticketing Domain** determines the ticket domain name in DataMiner.

On the **Configure Fields** subpage, you can configure the Jira statuses and determine which fields are displayed.

When everything has been configured, click the **Create** button to create the ticketing domain in DataMiner. If this succeeds, the **Resolver Status** will be *OK*.

## Notes

- The fields table only shows fields that are connected to the selected project.
- Some field types are not supported in the DataMiner Ticketing module. These field values are shown as JSON strings in DataMiner Ticketing.
- If at some point the ticket domain is out of sync because new fields or values have been created in the Jira software, click the **Create** button again to sync the ticket domain.

## How to use \[1.0.0.x\]

The element created with this connector consists of the data pages described below.

### General

On this page, the **MetaData** status parameters show if metadata is polled correctly or if additional configuration is needed.

The page also contains multiple page buttons to subpages where you can view and manually poll the different metadata. The **Poll All MetaData** button can be used to trigger polling of all metadata from the Jira platform.

The **Configure Resolver** button can be used to create or adjust the ticketing domain in DataMiner.

**Jira Manager Access** determines in which mode the connector will run on. Depending on the selected option, some commands will not be available. You can see the commands that are allowed on the **Commands** page.

### Configuration

On this page, you can configure the connection to the Jira platform and the DataMiner Ticketing module. To connect to Jira, you need to provide the **Jira User Name** and **Jira Password** (See "Initialization" section above). For the **Jira Element**, fill in the name of the Atlassian Jira element that handles the communication. The **Wait Timer** determines how long the connector will wait for a response from Jira.

To connect to the Ticketing module, provide the **DataMiner User Name** and **DataMiner Password**. **Domain** determines which ticket domain (also known as resolver) will be used in DataMiner.

**Ticket Changes** shows how many changes there are in the DataMiner domain. **Amount of Changes** indicates how many changes can occur before ticket synchronization is triggered.

### Jira Pending Issues

On this page, you can find the **Sync Time**, **Process Pending Issues time** and **Cleanup Time**. The **Jira Pending Issues** table shows all commands that have been or will be sent to the Jira platform. With **Delete Failed Request**, you can clean up this table.

The **Request Tickets** page button opens a subpage where you can configure how often all tickets should be polled, as well as poll the updated tickets from within a certain time.

### Json Tickets

On this page, you can see all the new tickets that have been received from the Jira platform and need to be created in DataMiner.

### Commands

On this page, the **Jira Implemented Commands** table shows all commands that are available in the connector. Depending the Jira Manager Access mode configured on the General page, some commands may be disabled. If the connector is set to *Custom*, you can enable or disable every command.

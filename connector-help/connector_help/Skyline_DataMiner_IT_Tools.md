---
uid: Connector_help_Skyline_DataMiner_IT_Tools
---

# Skyline DataMiner IT Tools

DataMiner IT Tools (DITT) is a solution that addresses some of the basic industry-standard IT operations. The solution is a combination of visuals, connectors and workflows that together provide specific features, which add value to the management of IT ecosystems.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial release  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you first start using this element, navigate to the **Configuration** page. A number of configuration options are available that can change the behavior of the connector.

**Settings -** **Request Processing:**

- *Enabled*: Incoming requests are served in a FIFO fashion.
- *Disabled*: Incoming requests are ignored.
- Default: *Enabled*.

**Other Setting - Debug**:

- *Enabled*: Shows Debug page and enables debug logging.
- *Disabled*: Hides Debug page and disables debug logging.
- Default: *Disabled*.

### Redundancy

There is no redundancy defined.

## How to use

As this is a virtual connector, **no data traffic** will be shown **in the Stream Viewer**.

There are two workflows to process incoming requests:

- **CLI Commands:** Communicates with connectors (ex. Generic Powershell) to retrieve the results of supported CLI commands requested by the user in the visual layer.
  The information related to each request is displayed in the **Operation Overview** table, and includes operation type, operation status, user name, in request (incoming request from visual), out request (request sent to connector), and result.
  Note: You can **add connectors** to the Subscription table via its right-click menu.
- **Application Launch**: Allows you to open local application such as Putty.
  When you click on a Visual Overview button connected to an application path, DITT validates whether the application is in the registration table. If it is in the table, the application will be launched; otherwise, a pop-up box is displayed where you need to enter the required information.
  Note: You can also **add entries** to this registration table via its right-click menu.

## Notes

This connector requires specific Correlation rules and Automation scripts for communication with auxiliary connectors such as **Generic Powershell**. The Correlation rules and Automation scripts must be configured and enabled in order to get the full functionality of this connector.

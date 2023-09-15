---
uid: Connector_help_Prometheus_Data_Exporter
---

# Prometheus Data Exporter

This connector can be used to subscribe to table columns of other elements and return those metrics using the built-in web service.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port that the web service will listen to (default: *3000*).
  - **Accepted IP address:** Allows you to configure from which IP addresses your element will accept requests.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector has the following data pages:

- **General**: From here you can enable or disable the web service feature. (***This will be implemented in a future update.***)
- **Configuration:** From the **Subscription Parameters** table, you can add entries that can represent single or multiple parameters subscriptions (**Currently only supported for table columns**).
  To add a row, right-click the table and select **Add**. Then configure the necessary fields. Only the Protocol, Version, Table ID, Parameter ID and Metric Name fields must always be filled in.
  You can also delete entries using the **Delete** option in the right-click menu.
- **Available parameters:** A table here contains all the subscription values that were configured in the Subscription Parameters table.
- **Debug:** The request received by the web service and response sent back to the client will be shown here for debugging purposes.

## Notes

- The web service only responds to *http://\[dmaip\]:\[configuredport\]/metrics*.
- Subscription parameters can only be configured for int/double column parameters. They are not compatible with string columns or with any type of standalone parameters.
- As of version 1.0.0.1, the toggle button on the General page is only a placeholder.

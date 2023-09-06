---
uid: Connector_help_Intinor_Direkt_Router
---

# Intinor Direkt Router

The Intinor Direkt router receives video and audio from Direkt link and other Direkt routers via computer networks, monitors it, and resends it to one or multiple destinations.

This connector monitors a given router and is able to send new settings to the device.

## About

### Version Info

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version contains:- Network inputs- Video inputs- Video outputs | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.6.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The polling device serial number, e.g. D00369.

### Initialization

When the element is created, the connector will use the specified bus address to create the links to access the network input, video inputs, etc.

To **set up the connection to the API**, fill in the username and password on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

Since the API will store all the changes under one category in one go (for example "Network Inputs"), the following steps are needed to make changes:

1.  Switch the item from **Polling Mode** to **Edit Mode**.
2.  Make the changes in the main category and/or its subcategories.
3.  Click the **Apply Changes** button for the item in the main category.

When an item is set to **Edit**,it will be colored **blue** to indicate (along with the Mode value itself) that this data will no longer be updated via polling.

Once the changes have been applied, polling will kick in again and the mode will change back to *Polling*.

To cancel changes, switch back to polling mode without applying the changes.

For example, to change network input IP stream in 1:

1.  On the **Network Inputs** page, toggle the **Mode** from *Polling* to *Edit*. This will make the columns writable and color the row blue.On the additional Network Input pages such as **Network Destinations**, the linked data row or rows will also switch to edit mode, making the columns editable and coloring the row blue.
2.  Make the necessary changes.
3.  Go back to the **Network Inputs** page and click **Apply Changes**. This will send the changes to the router and enable polling again.

**Caution:** Polling is disabled when Edit mode is enabled. To make sure you do not miss any updates, do not stay in Edit mode any longer than is strictly necessary.

## Note

This integration makes use of an auto-generated file **IntinorDirecktRouter.dll**. This is based on the swagger.json available from Intinor. In case the Intinor API is updated, the new swagger file must be used to generate a new DLL. Then the generated serialization methods should be copied to the connector. The DLL is not intended to be used with version 1.0.0.x of the connector.

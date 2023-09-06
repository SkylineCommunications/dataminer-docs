---
uid: Connector_help_Socomec_Diris_Digiware_DC
---

# Socomec Diris Digiware DC

This connector will poll the Socomec Digiware DC. The Digiware DC is a meter with a display with one port for a sensor. When you have a sensor connected to this device, you can poll data from it over the configured bus address. However, note that you must configure this bus address via a USB cable or via special software from Socomec. The sensor can be chained, which means that one sensor is connected to the meter, but you can connect another sensor to that sensor and another one to that one, and so on. Note that these bus addresses also need configuration. These sensors have different types and different architectures to poll data (different registers). For the initial version of this connector, only the I30 DC is supported.

## About

### Version Info

| **Range**            | **Key Features**                                                                                               | **Based on** | **System Impact**              |
|----------------------|----------------------------------------------------------------------------------------------------------------|--------------|--------------------------------|
| 1.0.0.x \[Obsolete\] | Initial release (only supports I30-DC).                                                                        | \-           | \-                             |
| 1.0.1.x \[SLC Main\] | \- Modules can now be given a custom name.- Display keys will now include the custom name given to the module. | 1.0.1.2      | Elements need to be recreated. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                  |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Socomec Diris Digiware DC - I30 DC](xref:Connector_help_Socomec_Diris_Digiware_DC_-_I30_DC) |
| 1.0.1.x   | No                  | Yes                     | \-                    | [Socomec Diris Digiware DC - I30 DC](xref:Connector_help_Socomec_Diris_Digiware_DC_-_I30_DC) |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

You need to manually add the bus addresses to the **Modbus Addresses** table (on the General page of the element).

### Redundancy

There is no redundancy defined.

## How to use

When you start using this connector, you need to configure the bus addresses of the meters connected to the Socomec Digiware DC unit. You can do so in the **Modbus Addresses** table on the General page, using the right-click menu of the table. When this configuration is done, the connector will display various information on its other pages.

On the General page, you can also reset a specific meter in the Modbus Addresses table or reset all meters in one go using the button at the top of the page.

Finally, DVEs can also be generated for the I30 DC power supply measurement module. DVE creation and automatic removal can be managed on the **DVE Configuration** page.

## Notes

Every 5 minutes, the product information will be polled from the meter (e.g. I-30 DC) configured in the Modbus Addresses table. "ProductInformation 2" is polled first in order to retrieve the vendor and product name. This is necessary for the connector to know the type of device, so that it can send the correct commands.

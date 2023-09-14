---
uid: Connector_help_Generic_RF_Switch
---

# Generic RF Switch

The Generic RF Switch virtual driver can be linked to an IO gateway element.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|--|--|--|--|
| 1.0.0.1 | Initial version | \- | \- |
| 1.1.0.x \[SLC Main\] | Send '2' to the write command that allows the contact to send the 'm' command (temporarily close the contact and open it again). Must use driver ILC IO Link Intelligent 96 IO version 1.0.0.10. | \- | \- |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.1   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

Configure the element connections in DataMiner Cube in the Element Connections module. For more information, see [Virtual elements used for element connections](xref:Virtual_elements#virtual-elements-used-for-element-connections).

## How to use

On the General page of this driver, you can find the Switch Status. The Switch Position A and the Switch Position B are displayed on the Switch Details page.

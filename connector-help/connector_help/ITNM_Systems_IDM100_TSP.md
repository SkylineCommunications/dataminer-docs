---
uid: Connector_help_ITNM_Systems_IDM100_TSP
---

# ITNM Systems IDM100 TSP

This connector is used to retrieve the services from one particular transport stream of the ITNM Systems IDM100 analyzer. The connector uses a serial connection to send HTTP commands to the device.

The connector only polls the services from one of the transport streams of the ITNM Systems IDM100. It is then possible to create a new element for every service retrieved from the device. These elements will in turn use the [ITNM Systems IDM100 Service](xref:Connector_help_ITNM_Systems_IDM100_Service) driver.

## About

### Version Info

| **Range**            | **Key Features**                                                                | **Based on** | **System Impact**                                                                                    |
|----------------------|---------------------------------------------------------------------------------|--------------|------------------------------------------------------------------------------------------------------|
| 1.1.0.7              | Initial version.                                                                | \-           | \-                                                                                                   |
| 1.1.1.x \[SLC Main\] | Normalized parameters removed. New display key for Transport Stream PIDs table. | 1.1.0.7      | \- Loss of normalized parameters. - Loss of trend and alarm data in the Transport Stream PIDs table. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                     |
|-----------|---------------------|-------------------------|-----------------------|-------------------------------------------------------------------------------------------------------------|
| 1.1.0.x   | No                  | No                      | \-                    | [ITNM Systems IDM100 Service](xref:Connector_help_ITNM_Systems_IDM100_Service) (generated via button) |
| 1.1.1.x   | No                  | No                      | \-                    | [ITNM Systems IDM100 Service](xref:Connector_help_ITNM_Systems_IDM100_Service) (generated via button) |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The port of the connected device, e.g. *81.*
  - **Bus address**: The bus address of the device.

### Initialization

A bus address is required for the connector to work.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **Services** page displays the **Transport Stream Services** table. This table contains an entry for each service in this particular transport stream.

To create an element for each of these services, click the **Create Elements** page button. The elements will be created with a name starting with the prefix specified in the **Use Prefix** parameter.

The new elements will use the **ITNM Systems IDM100 Service** protocol. As such, it is important that this protocol is available on the DMA.

## Notes

Elements using this connector are often created from an element running the **ITNM Systems IDM100 General**.

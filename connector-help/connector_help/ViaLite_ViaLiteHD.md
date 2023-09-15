---
uid: Connector_help_ViaLite_ViaLiteHD
---

# ViaLite ViaLiteHD

The **ViaLite ViaLiteHD** connector is used to display and configure information of the attached modules.

## About

The ViaLiteHD system comprises up to 13 rack-mounted cards and an SNMP card, all of which are plugged into a 19" 3U chassis with dual power supplies.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V1.04.21                    |

### Exported connectors

| **Exported Connector**                                                                                        | **Description**      |
|--------------------------------------------------------------------------------------------------------------|----------------------|
| [ViaLite ViaLiteHD Dual Transmitter](xref:Connector_help_ViaLite_ViaLiteHD_Dual_Transmitter)           | Dual Transmitter     |
| [ViaLite ViaLiteHD Dual Receiver](xref:Connector_help_ViaLite_ViaLiteHD_Dual_Receiver)                 | Dual Receiver        |
| [ViaLite ViaLiteHD Splitter](xref:Connector_help_ViaLite_ViaLiteHD_Splitter)                             | Splitter             |
| [ViaLite ViaLiteHD Dual Transmitter LNB](xref:Connector_help_ViaLite_ViaLiteHD_Dual_Transmitter_LNB) | Dual Transmitter LNB |
| [ViaLite ViaLiteHD Switch](xref:Connector_help_ViaLite_ViaLiteHD_Switch)                                 | Switch               |
| [ViaLite ViaLiteHD Receiver](xref:Connector_help_ViaLite_ViaLiteHD_Receiver)                             | Receiver             |
| ViaLite ViaLiteHD Transmitter                                                                                | Transmitter          |
| ViaLite ViaLiteHD SER                                                                                        | SER                  |

## Configuration

### Connections

#### SNMP main connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the ViaLiteHD Chassis, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Initialization

On the **Modules** page of the main element, all modules are shown in the **Module Table**.

To remove a virtual element, set the **Create DVE** toggle button to "*NO*" for that virtual element.

## How to use

The ViaLite ViaLiteHD protocol creates a main element and virtual elements for each supported module. The virtual elements receive a name that consists of the **Main Element Name** followed by the relevant **Slot Number** and **Type**, for instance: *ViaLiteHD Slot 6 (Receiver)*.

### Main Element

The connector's main element has the following pages:

- **General**: General system parameters of the chassis. The **System Details** page button provides access to more detailed information.
- **Modules**: For every module slot, an entry is created in the **Module Table**. The **Invalid DVE Table** page button provides access to a table that tracks the hanging/invalid DVEs, with an option to remove them.
- **Receiver,** **Transmitter,** **Switch, LNB, SER:** Module-specific information.
- **Webpage:** Link to the webpage of the device

### Virtual Elements

Each of the DVEs has the following main page:

- **General**: A page with general information about the created DVE child element: **Type**, **HW Version**, etc.

Every supported module type of the ViaLiteHD also has specific module information.

## Notes

This connector does not support traps.

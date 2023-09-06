---
uid: Connector_help_Sony_PWS-110SC1
---

# Sony PWS-110SC1

The Sony PWS-110SC1 is a vision mixer controller to which different cards can be attached:

- Vision Mixer System Interface Units: MKS-X7700/X2700/X7099
- Vision Mixer Processor: XVS-6000/7000/8000/9000
- Vision Mixer Panel: ICP-X7000 (not supported by this connector)
- Vision Mixer Menu Panel: MKS-X7011

## About

### Version Info

| **Range**            | **Key Features**                                                                              | **Based on** | **System Impact**                                                                                                        |
|----------------------|-----------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                              | \-           | \-                                                                                                                       |
| 1.0.1.x              | Support for monitoring of Sony 2110 devices.Support for manual deletion and creation of DVEs. | 1.0.0.24     | Columns of Device table renamed.NMI table renamed to IP IV Interfaces table; columns were also renamed.NMI page renamed. |
| 1.0.2.x \[SLC Main\] | Added DCF support                                                                             | 1.0.1.9      | \-                                                                                                                       |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V2.61                  |
| 1.0.2.x   | V2.61                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                              |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Sony PWS-110SC1 - XVS-8000Sony PWS-110SC1 - MKS-X2700Sony PWS-110SC1 - MKS-X7011Sony PWS-110SC1 - MKS-X7099Sony PWS-110SC1 - XVS-7000Sony PWS-110SC1 - XVS-6000Sony PWS-110SC1 - XVS-9000Sony PWS-110SC1 - MKS-X7700 |
| 1.0.1.x   | No                  | Yes                     | \-                    | Sony PWS-110SC1 - XVS-8000Sony PWS-110SC1 - MKS-X2700Sony PWS-110SC1 - MKS-X7011Sony PWS-110SC1 - MKS-X7099Sony PWS-110SC1 - XVS-7000Sony PWS-110SC1 - XVS-6000Sony PWS-110SC1 - XVS-9000Sony PWS-110SC1 - MKS-X7700 |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | Sony PWS-110SC1 - XVS-8000Sony PWS-110SC1 - MKS-X2700Sony PWS-110SC1 - MKS-X7011Sony PWS-110SC1 - MKS-X7099Sony PWS-110SC1 - XVS-7000Sony PWS-110SC1 - XVS-6000Sony PWS-110SC1 - XVS-9000Sony PWS-110SC1 - MKS-X7700 |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection for Ember+ communication and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default value *public*.
- **Set community string**: The community string used when setting values on the device, by default value *private*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use - Range 1.0.0.x

### Range 1.0.0.x

The element created using this range of the connector has the following data pages:

- **General**: This page contains general information, such as the **System Description**, **System Up Time**, **System Contact**, **Name**, and **Location**. It also displays an overview of the **OSI Model** of the availability of each layer.
- **Network**: This page displays the **Interfaces** and **Address Translation** tables. The Interfaces table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables. The **Product Information Table** is used to create the DVEs. On this page, you can also find the setting **DVE Automatic Removal**. When this setting is enabled, the connector will take care of the automatic removal of DVEs. When a card is replaced, removed, or switched, for example, the element will delete and create the corresponding DVE respectively, so that the element is always completely in sync with the connected device.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is cleared when a "Coldstart" trap is received.
- **Configuration**: This page displays the **CTRL1, 2, 3,** and **4** configuration settings and the **SWR1** and **SWR2** configuration settings. Each has a **Status**; this can be enabled or disabled. When a resource is created, these statuses will be taken into consideration. When the status is enabled, the resource will contain this parameter; otherwise, it will not contain this parameter.
- **DVE**: This page displays the **DVE** tables.
- **NMI**: This page allows you to check which NMI element is connected to which slot via the **NMI** table. There is a **Resubscribe** button to reset all the created subscriptions.
- **Tree**: This page allows you to see the entire Ember+ Tree.

### Range 1.0.1.x

The element created using this range of the connector has the following data pages:

- **General**: This page contains general information, such as the **System Description**, **System Up Time**, **System Contact**, **Name**, and **Location**. It also displays an overview of the **OSI Model** of the availability of each layer.
- **Network**: This page displays the **Interfaces** and **Address Translation** tables. The Interfaces table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables. The **Product Information Table** is used to create the DVEs. On this page, you can also find the setting **DVE Automatic Removal**. When this setting is enabled, the connector will take care of the automatic removal of DVEs. When a card is replaced, removed, or switched, for example, the element will delete and create the corresponding DVE respectively, so that the element is always completely in sync with the connected device.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is cleared when a "Coldstart" trap is received.
- **Configuration**: This page displays the **CTRL1, 2, 3,** and **4** configuration settings and the **SWR1** and **SWR2** configuration settings. Each has a **Status**; this can be enabled or disabled. When a resource is created, these statuses will be taken into consideration. When the status is enabled, the resource will contain this parameter; otherwise, it will not contain this parameter.
- **DVE**: This page displays the **DVE** tables.
- **IP IV Interfaces**: This page allows you to check which interface element is connected to which slot using the **IP IV Interface** table. With the **Resubscribe** button, you can reset all the created subscriptions.
- **Tree**: This page allows you to see the entire Ember+ Tree.

## Notes

The following connectors are exported by the Sony PWS-110SC1 connector:


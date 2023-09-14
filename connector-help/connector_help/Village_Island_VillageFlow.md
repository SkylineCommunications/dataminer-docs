---
uid: Connector_help_Village_Island_VillageFlow
---

# Village Island VillageFlow

## About

The **Village** **Island** **VillageFlow** connector is used to monitor the data coming from the VillageFlow Server. The connector uses a serial connection. It will listen to a certain port and will receive the data that will be sent to this port.

### Version Info

| **Range** | **Description**                                                                                                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                   |
| 1.1.0.x          | This range is compatible with the VillageFlow software if the DriverVersion attribute in the VF_CONF.xml is set to 6 or higher, if it is set to 5 or lower, use the 1.0.0.x range |

## Configuration

### Connections

This connector uses a **Serial** connection and needs following user information:

**SERIAL CONNECTION**:

- **IP address/host**: the polling IP, should be set to 127.0.0.1 or "any".

- **IP port**: the port of the connected device, e.g. 2222*.

## Usage

### Inputs page

On the Inputs page the **DVB-S**, **DVB-S2**, **QAM**, **IP**, **ASI** and **DVB-T2** tables can be viewed.

### Transport Streams page

On this page the **Transport streams**, **Services** and **PIDs** can be viewed.

### Treeview page

The treeview page displays a tree structure of all the inputs, with their corresponding streams, services and PIDs.

All PIDs are grouped in three groups: **Service PIDs**, **Table PIDs** and **Other PIDs**.
All error parameters are displayed in the best fitting view.

In addition to all Input specific parameters, the **DVB-T2** inputs have additional **PLP**, **Auxiliary Stream** and **RF Channel** information.

### Configuration page

The configuration page allows to enter the IP address of the VFMON Server, to be able to access the **web interface**.

On this page it is possible to enable/disable the **creation of XML fi**les. If the creation of XML files is enabled, all xml files retrieved from the server software will be saved at "C:\Skyline DataMiner\Documents\VillageFlow".

### Web Interface page

If the IP address of the VFMON server software is provided in the configuration page, it is possible to view the web interface in the DataMiner GUI.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface."

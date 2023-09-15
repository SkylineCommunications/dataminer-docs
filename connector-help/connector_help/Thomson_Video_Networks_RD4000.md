---
uid: Connector_help_Thomson_Video_Networks_RD4000
---

# Thomson Video Networks RD4000

The **Thomson Video Networks RD4000** connector has been designed to monitor and manage a single Distribution Receiver Decoder RD4000 device. This device is used for terrestrial, cable, satellite and IPTV headends to receive and decode feeds for local re-encoding, analog delivery or confidence monitoring.

## About

With this connector, the device can be managed directly. The connector displays information on several pages, as described in the "Usage" section below. The connector uses **SNMP** to establish communication with the device.

### Version Info

| **Range**     | **Description**                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                                  | No                  | No                      |
| 1.0.1.x \[SLC Main\] | Based on: 1.0.0.2 Names and descriptions were changed for the new range. UX improvements based on web interface. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |
| 1.0.1.x          | 1.0                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

## Usage

### General

This page displays the **System Up Time**, **Serial Number**, **System Type**, and **Unit Identifier LED**.

### Unit

This page is used to identify who is in charge of this device. You can specify **Contact** and **Name** information here.

There is also a **System Description** parameter that provides more information on the system.

### Inputs

This page contains the Input Table, with **Primary Source** and **Backup Source** information.

Below that, the **DVB S2 Input Table** contains the **Connection Mode** and **States**.

Finally, the **DVB S2 Input Status Table** shows the **Active** **Port**, **Tuning Frequency**, **Modulation Type**, and more.

### Services

This page contains the **Service Selection Table**, which is used to change the **Mode** of the **Backup State**.

It also contains the **Audio Service table**, which can be used to change the **Operational Mode**, **Audio Service**, **Format Mode**, and more.

### Audio

This page contains the **Selected Audio Table**, the **Audio Table**, and the **SDI Audio Table**. These tables allow changes to **Group Pair 1** and **2** and to **Default Type**, and display monitoring information about the **PID**.

### Video

This page is similar to the **Audio Page**, but displays information about the video card, such as **PCR PID**, **Frame rate**, **Scan Type**, **Raster Color**, **Internal Manual Format**, and **Internal Current Output Format**.

### SI

This page contains the **SI Service Table**, with the **Service Number**, **Service Name**, **PCR PID**, and **Scrambled** columns.

Below that, the **SI** **Audio Table** shows information about the **Service Number**, **PID**, **Type**, **Language**, **Bit Rate**, and **Coding Mode**.

Finally, the **SI Video Table** shows the **Service** **Number**, **PID**, and **Type**.

### TS

This page contains the **TS Input Source Table**, which displays the **Type**, **ID**, **Bit Rate** and **TS Sync**, and also allows you to view and set the **State**.

Below this, the **TS Output Source Table** allows you to view and set the **State** of the output sources, as well as to monitor the **ID** and **Type**.

### HD

On this page, the **HD Aspect Ratio** **Table** allows you to set the **Display Mode** and **Auto Conversion**. The **HD SDI Table** contains parameters that can be viewed and set regarding the **Video Loss Mode**, **CC CEA708**, **RDD11**, **EN301775**, **SCTE127**, and more.

### SD

This page displays the **SD Aspect Ratio** **Table**, with **Display mode** and **Auto Conversion**, similar to the **HD Aspect Ratio Table**.

The **SD SDI Table** below this is very similar to the **HD SDI Table**.

### CAM

The **CAM Slot Table** and the **Cam Optical Table** display information on the **State**, **Label**, **Name**, **Condition**, **Manual Reset** and **Optical Mode**.

### Lock

On this page, the **Service Lock Table** allows you to select a **Lock Mode** and change the **Service Name**, **Tune Number** and **Backup Service**.

The **PID Lock Table** can be used to set or check the **PCR PID**, **Video PID**, **Video Type**, **Backup Video** and **ES Type Mismatch**.

Finally, the **Audio PID Lock Table** contains the **PID**, **Type**, **Backup PID**, and **Backup Type**.

### ANC

This page contains the **ANC Decoder Table**, which shows the status of different items. The **ANC Line Conflict** **Table** shows the **State Conditions** for the parameters.

### ASI Input

This page contains the **ASI Input Table**, with the **TS Sync Loss** and the **Null Stripped State**.

### Format

This page contains the **Format Table**, with the **ID** and **Label**.

### Latency

This page contains the **Low Latency Table**, which shows the **Buffer Mode**.

### Overlay

This page contains the **Overlay Table**, with the columns **Type**, **CC Type**, **NTSC CC Data**, **DTV CC Data Type**, **DVB Subtitle Language**, and **DVB Subtitle PID**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_2WCOM_IP-4C
---

# 2WCOM IP-4C

This is an SNMP connector that is used to monitor and configure the **2WCOM IP-4C** audio-over-IP codec equipment.

## About

The information in the element is retrieved via **SNMP** communication.

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact**     |
|----------------------|---------------------------------------|--------------|-----------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                      | \-           | \-                    |
| 1.0.1.x \[SLC Main\] | Changed display keys for most tables. | 1.0.0.3      | Alarm and trend data. |
| 1.0.2.x              | Updated Alarm page layout.            | 1.0.1.1      |                       |
| 1.1.0.x              | Support for new firmware.             | 1.0.2.3      |                       |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.28.20                |
| 1.0.1.x   | 1.28.20                |
| 1.0.2.x   | 1.28.20                |
| 1.1.0.x   | 2.01                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

The connector also uses traps to receive alarm status updates.

### Initialization

The connector does not require credentials, so setting it up is rather straightforward. To make sure the device can be polled, define the port where the device can be found.

The port setting can be found on the General page and is called **Web Interface Port**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

Most tables in the connector contain the following buttons:

- **Save**: After you have made changes to a table, it is important that you click the "Save" button. This process is linked to the inner workings of the device:

  - Every change you make in the table will be sent to the device. The device will save this change in its front-end SNMP table.
  - After the changes are done, the device requires a signal, telling it to save and deploy all front-end changes.
  - As long as the save button has not been clicked, the changes will only reside in the front-end table and they will not be deployed.

- **Add**: This will duplicate the selected row.

- **Remove**: This will remove the selected row.

The element created with this connector has the following data pages:

- **General**: Displays system information, including the System Description, System Location, System Name, System Contact and System Up Time. This is also where you can configure a **port** to be used to access the web interface.
- **Audio Decoder Status:** Displays the overview of audio decoders.
- **Codec Pages (TS/IP, TS/SRT, TS Demux, Elementary Streams, Livewire, SRT, SIP, Icecast, File and XLR)**: These pages are used to control/configure codecs.
- **Audio Profiles**: Allows you to add or delete audio profiles.
- **TS Multiplexer**: Displays generic settings for each multiplexer. There are also page buttons that allow access to additional settings for each multiplexer, such as **RTP** and **SRT Outputs** and **Payload**.
- **Decoder Source Assignment**: Allows you to assign a codec to each audio source.
- **Encoder**: Allows you to link an input source to a profile.
- **Switch Criteria**: Allows you to specify switching criteria for each codec.
- **SIP Phonebook**: Contains the audio phonebook table.
- **Easy2Connect**: Contains the SIP phonebook table.
- **Interface Settings**: Contains **DTE Input/Output Baud Rates** and **Headphone** settings.
- **AoIP Settings**: Contains specific AoIP settings for **Livewire**, **SAP** and **RTSP**.
- **Alarm**: Contains the device and audio input/output alarm settings. Also displays the external clock alarms.

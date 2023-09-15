---
uid: Connector_help_SES_S.A._TEMOS
---

# SES S.A. TEMOS

TEMOS is a system at SES S.A. that is able to retrieve satellite telemetry data from a server named TLMCore. The TLMCore is a socket server that handles XML requests. This connector allows users to view the telemetry data in a table of channels.

## About

Depending on the version, this connector functions in a very different way:

- Version **1.0.0.x** of the connector uses a **serial** connection to obtain the telemetry data from the TLMCore server.
- Version **1.0.1.x** of the connector uses a **virtual** connection to display satellite telemetry data. The connector obtains the data by creating an **SES S.A. TEMOS Probe** element per satellite to retrieve the information from the TLMCore server.

### Version Info

| **Range** | **Description**                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                     | No                  | Yes                     |
| 1.0.1.x          | Initial version as a virtual connector | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Serial Main Connection
<p>This connector range uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Direct connection:
<ul>
<li><strong>Baudrate</strong>: Baudrate specified in the manual of the device.</li>
<li><strong>Databits</strong>: Databits specified in the manual of the device.</li>
<li><strong>Stopbits</strong>: Stopbits specified in the manual of the device.</li>
<li><strong>Parity</strong>: Parity specified in the manual of the device.</li>
<li><strong>FlowControl</strong>: FlowControl specified in the manual of the device.</li>
</ul></li>
<li>Interface connection:
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device.</li>
</ul></li>
</ul></td>
</tr>
<tr class="odd">
<td>1.0.1.x</td>
<td><h4 id="virtual-connection">Virtual Connection</h4>
<p>This connector range uses a virtual connection and does not require any input during element creation.</p></td>
</tr>
</tbody>
</table>

## Usage \[1.0.0.x\]

### Channels

On this page, you can select an LRV CSV file that must be uploaded to the element. To do so, select the file from the **LRV File** drop-down list and press the button **Load LRV File**. This file must be located in the following folder:

- C:\Skyline DataMiner\Documents\SES S.A. TEMOS\LRVs\\

The Channel CSV file also has to be uploaded to the element. This file must be placed in the following web location:

- <https://lamp.dino.astra.ses/bro-tools/chlist/start.php?page=dataminer-channel-list>

The file will be loaded automatically every 10 minutes, but you can also load it by pressing the button **Load Channel File**.

The CSV files must contain the following data, in the same order as specified below:

- **Channel:**

  1. Orbital Position
  1. Tube
  1. BW
  1. ULF
  1. UL Pol
  1. DLF
  1. DL Pol
  1. L
  1. Uplink
  1. Uplink Chain
  1. Customer
  1. Modulation
  1. Satellite
  1. DCMS Name
  1. DCMS Display Key

- **LRV:**

  1. Satellite
  1. Tube
  1. Sat I/P LRV
  1. Mode LRV
  1. Nominal ALC LRV
  1. Nominal FG LRV
  1. TWT Status LRV
  1. High Voltage Status LRV
  1. DCC Status LRV
  1. RF Status LRV
  1. FCA LRV
  1. GCA LRV
  1. Helix LRV

> [!NOTE]
>
> - If any value does not exist, it must be left empty in the CSV file.
> - The names of the **Satellites** and **Tubes** must be exactly the same in both CSV files.

The **Refresh Files** button can be used to refresh the drop-down list if necessary.

This page also contains the **Channel Table**, which shows the data from the Channel CSV file that was uploaded and the telemetry data of each channel.

### LRV

This page contains the **LRV Table**, which displays all the data from the LRV file that was uploaded.

### Tube Configuration

This page contains the **Tube Configuration Table**, which allows you to select when the telemetry data of each tube should be requested.

In the **Polling** column of the table, you can select one of the following options:

- *Slow*: This option indicates that the SAT I/P and Mode of the tube will be polled every 30 seconds and the rest of the parameters every 10 minutes.
- *Fast*: This option indicates that all the parameters will be polled every 5 seconds.
- *Inactive*: The tube will not be polled.

> [!NOTE]
> Slow is the default option.

### Satellite Connections

This page contains the **Satellite Connection Table**, which shows the current state of the connection of each satellite.

### Tube LRV Errors

This page contains the **Error Tube LRV Table**, which shows the tubes that have negative responses when trying to retrieve telemetry data.

## Usage \[1.0.1.x\]

### Channel

This page displays the **Channel Table**, which shows the data from the uploaded **Channel CSV** file and the telemetry data of each channel.

The **Channel CSV** file is loaded automatically after the LRV file has been loaded (See "LRV" section below). The Channel CSV file should be placed in the following web location: <https://lamp.dino.astra.ses/bro-tools/chlist/start.php?page=dataminer-channel-list>. The file is loaded automatically every 10 minutes in case there are changes. The **Import Channel File** button allows you to update the file manually. For more information on the configuration of the file, refer to the "Notes" section below.

Via the **Configuration** subpage of the Channels page, you can configure the **User** and **Password** that will be used to access the **Channel CSV** file in the web location. This web location can also be edited on this subpage. In addition, the **IP address** and **Port** that will be used when creating the Probe elements can also be edited on this subpage.

### LRV

On this page, you can select the **LRV CSV** file that must be uploaded to the element. To do so, select the file from the **LRV File** drop-down list and press the button **Import** **LRV File**. This file must be located in the following folder: "*C:\Skyline DataMiner\Documents\SES S.A. TEMOS\LRVs\\*". For more information on the configuration of the file, refer to the "Notes" section below.

This page contains the **LRV Table**, which displays all the data from the LRV file that was uploaded. You can import and export the table in CSV format and add or delete a row in this table.

### Tube Configuration

This page contains the **Tube Configuration Table**, which allows you to select when the telemetry data of each tube should be requested.

In the **Polling** column of the table, you can select one of the following options:

- *Slow*: This option indicates that the SAT I/P, Mode, Nominal ALC, Nominal FG and Helix are polled every 30 or 60 seconds and the rest of the parameters every hour.
- *Fast*: This option indicates that SAT I/P, Mode, Nominal ALC, Nominal FG and Helix are polled every 5, 10, 15 or 20 seconds and the rest of the parameters every hour.
- *Inactive*: The tube will not be polled.

> [!NOTE]
> Slow is the default option.

### Satellite Information

This page displays the **Satellite Information Table**. This table contains information related to the **SES S.A. Probe** elements that where created by the connector.

The table contains the following columns:

- **Satellite**: Name of the satellite.
- **Connection ID**: ID of the connection obtained with the TLMCore server.
- **Connection State**: State of the connection (*Active*, *Connection Error* or *Pending*).
- **Fast Polling**: Time interval of the fast polling for the satellite (5, 10, 15 or 20 seconds).
- **Slow Polling**: Time interval of the slow polling for the satellite (30 or 60 seconds).
- **Element Name**: Name of the SES S.A. Probe element.
- **Element State**: State of the SES S.A. Probe element (*Present* or *Deleted*).
- **Delete**: A button to delete the table row when the element state is *Deleted*.
- **Sync**: Pressing this button will sync the LRV information from the manager element with the satellite probe element, if present.

At the bottom of the page, the **Sync All** button allows you to sync all LRV and timing information from the manager element with the probes.

### LRV Errors

This page contains the **LRV Error Table**, which shows the channels that have negative responses when trying to retrieve telemetry data.

### Alarm Preset

To facilitate the process of creating alarm templates, the **Channel** table has an **Alarm Preset column**. The content of this column corresponds to the content of the **Alarm Preset Table** on this page.

Configuring presets in the **Alarm Preset Table** can be done by importing a CSV file. To do so:

1. Select the CSV file using the **Select Alarm Preset File** drop-down list. Use the **Refresh** button to update the **Select Alarm Preset File** drop-down list if necessary.

   The connector looks for the CSV files in the following directory: "*C:\Skyline DataMiner\Documents\SES S.A. TEMOS\Configuration Alarm Presets"*

1. Click the button **Import File**.

You can also add a preset in the table by selecting **Create Preset** in the table's context menu. This way, you can add the presets one by one. To delete a preset, right-click the entry in the table and select **Delete Preset**. The **Remove All** button can be used to delete all the entries from the table at once. To save an alarm preset in a CSV file, click the button **Export Alarm Preset**.

Once an alarm preset has been assigned to a certain channel, this preset name can be used as a filter when you create alarm templates in DataMiner. This will allow you to configure different thresholds for the same parameter depending on the alarm preset filter.

## Notes \[1.0.1.x\]

The Channel CSV and LRV CSV files must contain the following data, in the same order as specified below:

- **Channel:**

  1. Orbital Position
  1. Tube
  1. BW
  1. ULF
  1. UL Pol
  1. DLF
  1. DL Pol
  1. L
  1. Uplink
  1. Uplink Chain
  1. Customer
  1. Modulation
  1. Satellite
  1. DCMS Name
  1. DCMS Display Key

- **LRV:**

  1. Satellite
  1. Tube
  1. Sat I/P LRV
  1. Mode LRV
  1. Nominal ALC LRV
  1. Nominal FG LRV
  1. TWT Status LRV
  1. High Voltage Status LRV
  1. DCC Status LRV
  1. RF Status LRV
  1. FCA LRV
  1. GCA LRV
  1. Helix LRV
  1. Custom Nominal ALC
  1. Custom Nominal FG
  1. Mode Nominal ALC
  1. Mode Nominal FG

Note:

- If any value does not exist, it must be left empty in the CSV file.
- The names of the **Satellites** and **Tubes** must be exactly the same in both CSV files (LRV and Channel).

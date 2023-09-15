---
uid: Connector_help_Sydney_Trains_PBX_Manager
---

# Sydney Trains PBX Manager

The **Sydney Trains PBX Manager** is used to setup **PSTN** phone calls by using the **Asterisk PBX API**.

## About

The **PBX** connector does not start **PSTN** calls on its own, instead it can be used by different sources to request a call to be set up.

Other elements in **DataMiner** can use the PBX Manager to start calls by setting a request on parameter 10/11 (read/write). The request needs to have the following format:

- **START**: \[ID\]\|\[DMA ID/Element ID\]\|\[PID\]\|START\|\[STATION NAME\] (this will trigger the PBX Manager to start a phone call to the configured station)
- **STOP**: \[ID\]\|\[DMA ID/Element ID\]\|\[PID\]\|STOP (this will stop the call that was previously started - ID needs to match)

There is also a second interface on this connector, which is used by the **Sittig DVA**, who can also request scheduled PSTN calls via this connector.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Device Firmware Version</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><p>Asterisk API 1.3</p>
<p>Sittig Routing Interface v0202</p></td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### Smart-Serial Main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: \[The IP port of the device. *Default 5038*.\]

#### Smart-Serial SITTIG Interface connection

This connector uses a smart-serial connection and requires the following input during element creation:

SITTIG INTERFACE:

- Interface connection:

  - **IP address/host**: *localhost* (DataMiner acts as server)
  - **IP port**: \[The DataMiner IP port used by Sittig DVA to send requests to. *Default 7531*.\]

### Configuration of Asterisk PBX credentials

Before communication with the **Asterisk PBX** is established, the **Username** and **Password** need to be provided. These can be configured on the **Connection** page of the PBX Manager connector.

## Usage

### Announcements

The announcements page can be used to access all current and history callsof the last x days.

The **Announcements** table contains the most recent calls, while the **Announcement History** table (available on Announcement History popup page) has the entries for older calls. When an announcement is moved from the **Announcements** table to the **Announcement History** table can be configured, as well as when the announcements should be removed from the **Announcement History** table.

### Channels

The **Channels** table contains the fixed **8 channels** that are available in the Asterisk PBX. This table also displays extra information about which channel is currently being used by which call and since when.

### Stations

The **Stations** table contains the stations that can be used to call to.

These stations can be imported (**Impo**rt popup page) via a CSV file, which should contain their **name**, **acronym** and **phone number**. The acronym is used in the **Sittig DVA** commands and should also be used by DMA element requests when requesting a call.

### Connection

The **Connection** page displays the state of the connection to the **Asterisk PBX** and the **Sittig DVA**.

For the Asterisk PBX, it's possible to configure the **Username** and **Password**.

### Configuration

This page displays some extra **configurations** that are available.

It's possible starting from 1.0.0.3, to *disable* the **DTMF** command using the **Play DTMF** parameter.

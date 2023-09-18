---
uid: Connector_help_Cisco_Monitor+
---

# Cisco Monitor+

The **Cisco Monitor+** is an integrated and customizable product used to monitor NDS customer headend systems and platforms. It helps broadcasters to monitor health status, performance statistics and availability of web applications, standalone applications, and platforms in a headend.

## About

This connector retrieves the configuration of the device and polls the data for all valid components. By default, this data is the Process Information, as well as any group that was implemented and contains data in the response. (Note: .NET Framework 4.5/4.6 is required).

Implemented data 'groups':

- **Process Information**
- **Server Connections**
- **Counters**
- **Services**
- **Service**
- **Full Scrape Statistics** with **Assets Statistics** and **Traxis Connections**
- **API Details**
- **Last Build Statistics** with **Compressed Database Sizes** and **Uncompressed Database Sizes**
- **Fixed Bitrate Info** with **Last Fixed Bitrate Statistics** and **Stack Bitrates**

### Version Info

| **Range** | **Description**                                                                             |
|------------------|---------------------------------------------------------------------------------------------|
| 1.0.0.x          | Initial version                                                                             |
| 2.0.0.x          | Version created to be able to filter the alarms table on a different column Arquiva request |

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
<td><p>NDS Console v3.42.3-0</p>
<p>Monitor+ v2.76.0-0</p></td>
</tr>
</tbody>
</table>

### Version 1.0.0.3

From this version onwards, the configuration of the device is retrieved, which fixes a problem with alarm table polling when the headend name is no longer the default one. Additionally, several of the data groups found under components have been implemented.

### In version 1.0.0.1 and 1.0.0.2

In these versions, the connector only consists of an alarm table.

## Installation and configuration

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP** **CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*

**HTTP** **Settings:**

- **Bus address**: This field is used to bypass the proxy. By default, *bypassproxy* is filled in.

Note: On older DMAs this will be called the SERIAL connection and settings, instead of HTTP.

## Usage

### Components Treeview

This is the tree control combining all the data tables into a structure reminiscent of the web interface. Each component has a node. The enabled data groups are subnodes, and the nodes below this are the individual data entries.

### Components

The **Components Table** is where old components can be deleted and data groups have their polling enabled or disabled.

### Data table pages

The tables containing the polled data are added on separate pages. The following pages and tables are available:

- Process Info page:

- **Process info Table**

- Server Connections page:

- **Server Connections Table**

- Counters page:

- **Counters Table**

- Services page:

- **Services Table**

- Service page

- **Service Table**

- Full Scrape Statistics page:

- **Full Scrape Statistics Table**
  - **Assets Statistics Table**
  - **Traxis Connections Table**

- API Details page:

- **API Details Table**

- Last Build Statistics page

- **Last Build Statistics Table**
  - **Compressed Database Sizes Table**
  - **Uncompressed Database Sizes Table**

- Fixed Bitrate Info page:

- **Fixed Bitrate Info Table**
  - **Last Fixed Bitrate Statistics Table**
  - **Stack Bitrates Table**

### Alarms

On this page, an **Alarm Table** is displayed with general and detailed information, e.g. **Description**, **State**, **Threshold Value**, etc.

To refresh the table, click the **Refresh** button. This will clear the table and query all the alarms again.

The timestamp of when the table was **Last Updated** is shown at the top.

### Web Interface

This page displays the web interface. However, the client machine has to be able to access the device, as otherwise it is not possible to open the web interface. Because of problems due to HTTPS security and signatures, this can often be the case.

## Notes

After every startup, the System Tree is polled. It contains the necessary information to retrieve all other data, i.e. the headend name needed for the alarm table, and the components available in the device. Whenever a new component is detected, it will be added to the **Components Table** with the **Enable** parameters set to *Awaiting Response*. As soon as the component has been polled, the availability can be determined for the data tables. The data groups that have at least one value will then be enabled, and everything else will be disabled. Afterwards, you can make changes using the toggle buttons.

Behavioral traits:

- A component will only be added to the components table if it has an entity name, an instance entity name and an instance hostname. These values are required to be able to poll the component.
- If a data group is disabled, all rows related to this component will be deleted from the relevant tables.
- If a component is removed from the System Tree, the component's **Instance Status** will be changed to *Deleted*, but all data will be preserved until the **Delete Row** button is clicked. The polling of the data will also be halted for this component.
- If a component's data cannot be retrieved, the existing values will not be overwritten or deleted.
- If a component's response does not contain specific rows for a data group, the missing rows will be deleted from the table.
- Process information is currently added for every component. This cannot be disabled.

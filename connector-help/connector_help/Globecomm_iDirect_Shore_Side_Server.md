---
uid: Connector_help_Globecomm_iDirect_Shore_Side_Server
---

# Globecomm iDirect Shore Side Server

This DataMiner connector can be used to monitor remotes that are available through the Globecomm iDirect Shore Side Server web API.

## About

The Globecomm Shore Side Server groups together data from a number of remotes, each of which consolidates data gathered from a number of devices, situated at the remote. The shore side server provides a local store of the data of the remotes and manages connections and data transfers to and from the remotes.

Multiple shore side servers can be added for system scaling or to partition remotes across business needs. In that case, an element will be created for each server.

The shore side server provides a Web API for use with an NMS. This connector uses that API to retrieve all the data.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors".

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Initial version</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>1.0.1.x [SLC Main]</td>
<td><p>Based on version 1.0.0.5</p>
<p>Added tables for each device type in order to export new standalone parameters: device type and communication state.</p>
<p>Changed device names (page names of exported elements) to generic names.</p>
<p>Removed static data sections in the connector.</p></td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | API v1                      |
| 1.0.1.x          | API v1                      |

### Exported connectors

| **Exported Connector**                        | **Description**                       |
|----------------------------------------------|---------------------------------------|
| Globecomm iDirect Shore Side Server - Remote | Represents a remote with its devices. |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration

When required for the shore side server web API, specify the API username and password on the **Configuration page**.

## Usage

### Remotes

The shore side server maintains the data for all remotes in the system. On this page, a table is shown with all the remotes that are managed by the shore side server. The details for each remote are available in the DVEs.

There is a page button that opens the **Remotes Enable/Disable** subpage, which contains the **Remotes Table Overview**. This is a table similar to the main Remotes table, but with extra option to enable or disable each virtual element. The subpage also contains controls to enable or disable automatic removal of DVEs and to completely delete virtual elements.

### Devices

An onboard data collector application communicates with each device and consolidates the collected information. The table on this page provides a list with all the devices of all remotes. A particular communication state is associated with each device and with the onboard data collector.

### Static Data

This page displays a tree view that provides additional data that is relevant to the networks, teleports and beams.

### Configuration

This page contains general configuration settings. The settings are saved in the element.

- **API Username and Password**: The credentials that should be used for authentication with the server.
- **Extended logging**: When enabled, more logging will be written to the file.

## Revision History

DATE VERSION AUTHOR COMMENTS

05/02/2016 1.0.0.1 TWA, Skyline Initial version.

28/04/2016 1.0.0.2 TWA, Skyline Bugfix: show static data in all remote redundancy instances.

30/05/2016 1.0.0.3 TWA, Skyline Fixed exception that occurred when DiskSize and DiskFree are not available.

Several changes that were necessary for the DataMiner Maps implementation.

11/07/2016 1.0.0.4 TWA, Skyline Added trending on communication state parameters.

30/08/2016 1.0.0.5 TWA, Skyline Added the elevation start and stop to the combined blocking zone parameter.

Fixed an XML data parsing issue.

21/05/2018 1.0.1.1 HPE, Skyline Added ability to enable/disable DVEs.

Added tables for each device type in order to export new standalone parameters: *device type* and *communication state.*

Changed device names (page names of exported elements) to generic names.

Removed static data sections in the connector.

Modified/improved some code in QActions.

## Notes

**Impact of changes implemented in range 1.0.1.x :**

- The following page names were changed in the exported protocol:

- iDirect Evolution X7 Satellite Router to VSAT Modem
  - Sailor 900 ACU to ACU
  - CISCO Router 2900 to Router
  - WTI RSM8R8 to Console Server
  - Xiplink XA TCP/IP Accelerator to Network Optimizer
  - EATON UPS Evolution 1550 to UPS
  - SAILOR 500 FBB and Iridium Broadband Subscriber Unit were joined to L-band Modem.
  - CISCO SPA112 ATA to VOIP
  - NIMBUS to NIMBUS/GCPro

> This could affect Visio drawings. A shape can be linked to an alarm state and it can be used to display the entire page in a dashboard.

- Parameters associated to static data were removed. As a consequence, it may be necessary to reconfigure DataMiner filters, Automation scripts, Visio files, reports, web API usage, etc. using these parameters.

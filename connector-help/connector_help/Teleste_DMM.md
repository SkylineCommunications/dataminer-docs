---
uid: Connector_help_Teleste_DMM
---

# Teleste DMM

This connector monitors and manages controller devices like the Teleste DMM and all of its modules. It polls and sets parameters both of the controller device itself and of the attached modules.

## About

Several parameters of the controller itself are polled with a timer. With a separate timer, all of the modules are polled one after another. When a set occurs on one of the attached modules, this polling cycle is interrupted (as soon as the current polling of the current module is finished) in order to give priority to the set.

Every module has its own interface (i.e. IP address and port). This is the reason why 2 serial connections are used in the connector, one for the controller device and one for the modules. The modules connection changes for every module that needs to be polled/set.

This connector exports different connectors based on the retrieved data. A list can be found in the section "Exported connectors" below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

### Exported connectors

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Exported Protocol</strong></td>
<td><strong>Description</strong></td>
</tr>
<tr class="even">
<td>Teleste DMM DBM100</td>
<td>DBM100</td>
</tr>
<tr class="odd">
<td>Teleste DMM DVO101</td>
<td>DVO101</td>
</tr>
<tr class="even">
<td>Teleste DMM DVO202</td>
<td>DVO202 (from v1.0.0.2)</td>
</tr>
<tr class="odd">
<td>Teleste DMM DVO202 S</td>
<td><p>DVO202 S (from v1.0.0.11) DVO202 NL (from v1.0.0.12)</p></td>
</tr>
<tr class="even">
<td>Teleste DMM DVO421</td>
<td>DVO421 (from v1.0.0.7)</td>
</tr>
<tr class="odd">
<td>Teleste DMM DVO624</td>
<td>DVO624 (from v1.0.0.2)</td>
</tr>
<tr class="even">
<td>Teleste DMM DVO802</td>
<td>DVO802 (from v1.0.0.2)</td>
</tr>
<tr class="odd">
<td>Teleste DMM DVO902</td>
<td><p>DVO902/2E (from v1.0.0.11) DVO902/5E (from v1.0.0.11) DVO902/8E (from v1.0.0.15)</p></td>
</tr>
<tr class="even">
<td>Teleste DMM DVO902_8</td>
<td>DVO902/5 (from v1.0.0.15)
<p>DVO902/8 (from v1.0.0.5)</p></td>
</tr>
<tr class="odd">
<td>Teleste DMM DVP332</td>
<td>DVP332</td>
</tr>
<tr class="even">
<td>Teleste DMM DVP432</td>
<td>DVP432 (from v1.0.0.2)</td>
</tr>
<tr class="odd">
<td>Teleste DMM DVP532</td>
<td>DVP532</td>
</tr>
<tr class="even">
<td>Teleste DMM HDO903</td>
<td>HDO903 (from v1.0.0.11)</td>
</tr>
<tr class="odd">
<td>Teleste DMM HDO905</td>
<td>HDO905 (from v1.0.0.11)</td>
</tr>
<tr class="even">
<td>Teleste DMM HDO906</td>
<td>HDO906 (from v1.0.0.11)</td>
</tr>
<tr class="odd">
<td>Teleste DMM HDP230</td>
<td>HDP230 (from v1.0.0.13)</td>
</tr>
<tr class="even">
<td>Teleste DMM HDO202</td>
<td>HDO202 (from v1.0.0.16)</td>
</tr>
</tbody>
</table>

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection to request data from the **controller**. This connection requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### Serial Modules connection

This additional serial connection is used to request data from the **modules**.

No user configuration is required. The connector will dynamically set the IP address and IP port depending on which module is polled.

## Usage

### Properties

This page displays general information about the hardware and software.

### DVX Devices

This page displays an overview of the modules attached onto the DVX bus.

For each of the attached modules, an entry is made in the DVX device table on this page and a new DVE child element is created.

### Addresses

This page displays network information for the controller device.

### Statistics

This page displays supply voltage and controller information for the controller device.

### Modem

This page displays modem functions.

### Settings

This page displays controller-specific settings.

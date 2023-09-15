---
uid: Connector_help_Snell_Wilcox_IQMDDM_SNMP
---

# Snell Wilcox IQMDDM SNMP

The IQMDDM is an ASI 2 to 1 switch, distribution amplifier and transport stream monitor. With up to 8 outputs in double width, or 4 outputs in single width.

The inputs are transformer coupled and equalized to \> 200 m of high quality cable. All outputs are re-clocked and transformer coupled. There is independent control of the input to be passed to the distribution amplifier outputs and the input to be passed to the transport stream monitor.

The IQMDDM have as features:

- Indepent selection of monitored stream and distribution amplifier input.
- User programmable minimum and maximum TS bitrate thresholds.
- Fully programmable TR101290 monitoring to match each transmission system specifications.

The IQMDDM monitors the legality of the MPEG2 transport stream to ETR 290 Priority 1. In addition, some priority 2 and 3 parameters are also checked.

On the double width module a GPI port is available which may be configured to any control or reporting parameter.

All control and monitored parameters are available for access over the RollCall remote control network. The RollCall logging utility enables selected events to be logged on a remote server(s).

## About

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
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td><ul>
<li>Initial version.</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |



## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: \[The bus address of the device.\]

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page contains info related with **Serial Number** and **Software Version**.

Additional information can be displayed and set on **Logging** subpage.

#### Logging

In this subpage you can control the generation of error messages to be logged. It consists of a list of all the possible error events that can trigger a RollCall log message. Each can be individually enabled or disabled.

### Bitrate

Bitrate page display information on **Bitrate Status**, **Bitrate Current**, **Bitrate Maximum**, **Bitrate Minimum** and **Bitrate Continuous Update**. It also has a Configuration subpage tha allows you to configure the **Bitrate Minimum Threshold**, **Bitrate Maximum Threshold**, **Bitrate Enable Updates** and configure if minimum or maximum threshold are enabled.

### Errors

Errors page display information on **All Errors Status**, **Current I/P Status**, **Mon Input Status**, **RSV Status**, **Sync Status**, **ETR290 Status** and **Template Status**.

### GPI

GPI page display GPI 1 & 2 information, namely: **Mode**, **Output Trigger**, **Output Invert**, **Input Invert** and **Status**.

### Input

Input page displays technical information related with **Input (D/A)**, **Input (MON)**, **Input 1** and **Input 2**.

### Programs/Pmts

Programs/Pmts page aims to load and display the List of **Available Services.**

### Template

This page shows the selection, naming and prioritisation of SI/PSI templates.

A template contains the set of data described in the Template Categories subpage. Used as a reference, templates are particularly useful to check some high-level parameters contained in the transport stream.

#### Template Categories

This page contains a toogle button for each parameter contained in a template.

The template comparison will only be performed for enabled parameters in this subpage. The parameters listed are:

**Network ID -** The network identification number.

**TS ID -** The transport stream identification number found in the Program Association Table (PAT).

**Packet Format -** The total length of the transport stream packets: 188,204 or 208 bytes, depending upon whether and which Reed Solomon (RS) protection codes have been used.

**TS Bitrate** - The transport stream bitrate.

**Service ID** - A 16-bit number uniquely identifying each service (program) in the transport stream. Also known as the program_number.

**PCR PIDs** - The Packet IDentification (PID) numbers of all transport stream packets carrying Program Clock Reference (PCR) timestamps. The PCR PID for each program is found in its associated Program Map Table (PMT).

**Service Bitrates** - The service bitrates.

**Component PIDs -** The PID of each component in every program in the transport stream as defined in the relevant PMT.

**Component Types -** The type of each component (video, audio, etc.) as found in the PMTs.

**Component Bitrates -** The bitrate of each component.

**Scrambling control** - The scrambling control bits

**Number of Services** - The total number of services (programs) defined in the PAT. If this category is not enabled the template matcher will only check that all of the services defined in the template are present in the stream and generate an error if any are absent. If it is enabled then the presence of any extra services will also cause an error.

**Number of components -** The total number of components in each service defined in the PMT for that service. If this category is not enabled the template matcher will only check that all of the components defined in the template are present in the stream and generate an error if any are absent. If it is enabled then the presence of any extra components will also cause an error.

**Template Switching Delay -** This field allows the user to change the delay between comparing templates in the template sequence (see Template Selection Menu). This delay is to account for the time required to acquire all of the relevant information in the stream. Any value may be entered but it will be rounded to the nearest 0.5 seconds. The parameter will not be changed on the module until the right arrow send button is pressed.

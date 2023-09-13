---
uid: Connector_help_Acorde_ACTX-KA
---

# Acorde ACTX-KA

This driver allows the monitoring and control of the Block Up Converter via serial (RS232/RS485) or TCP telnet.

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
<td><p>User configurable connection mode (serial / tcp)</p>
<p>Monitor &amp; Control</p></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | ACFIRM-M9-TX-V232-COD-01-00 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
- **IP port**: \[The IP port of the destination. (default: *50*)\]
- **Bus address**: \[The bus address of the device. (default: *0000*) (range: *0000* - *9999*)\]

### Initialization

By default, *Telnet* (TCP) will be selected as the **Connection Mode**. The default password (0000) will be used to log in.
The **Connection Mode** can be changed in the **Connection Settings** page available via the **Connect** page button on the **General** page.
It is possible to switch this mode between *Telnet* (TCP) and *Serial* (RS232/RS485).

The **Polling Status** will indicate if data is being retrieved. For example: when it is not possible to log in via the Telnet, the **Polling Status** will indicate *Disabled* and no data will be retrieved until the Telnet connection could be established.
An automatic log in attempt is done every hour.

### Redundancy

There is no redundancy defined.

## How to use

In case the **Connection Mode** is set to *Telnet*, the log in session must succeed before data is retrieved. This will be indicated via the **Polling Status**.
When during polling via Telnet would return a Timeout or an unsupported message, a re-login attempt will be executed. This because a timeout closes the Telnet session.
In case the re-login would time out the retrieval of data is stopped and the **Polling Status** set to *Disabled* until the automatic re-login or a manual log in was successful.

## Notes

When no data is being retrieved / updated, always first check the **Polling Status**. When this is indicating *Disabled* it means the Telnet session could not log in.

Using a serial connection requires correct serial configuration before communication is possible.
These settings are dong in the communication interface that links the data source with the network.

- Serial settings:

- **Baudrate**: \[Baudrate specified in the manual of the device, e.g. *9600*.\]
  - **Databits**: \[Databits specified in the manual of the device, e.g. *7*.\]
  - **Stopbits**: \[Stopbits specified in the manual of the device, e.g. *1*.\]
  - **Parity**: \[Parity specified in the manual of the device, e.g. *No*.\]
  - **FlowControl**: \[FlowControl specified in the manual of the device, e.g. *No*.\]

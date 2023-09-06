---
uid: Connector_help_General_Dynamics_Low_Power_Rack_SSPA
---

# General Dynamics Low Power Rack SSPA

This driver can be used to monitor the GD Satcom Low Power Rack SSPA using an SNMP (range 1.0.0.x) or serial (range 2.0.0.x) connection.

## About

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact**                                                                                                                            |
|----------------------|-----------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version with SNMP connection.   | \-           | \-                                                                                                                                           |
| 2.0.0.x \[SLC Main\] | Initial version with serial connection. | \-           | \- Existing elements using this driver need to be reconfigured when you switch to this range. - Some parameters IDs were removed or changed. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

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
<td>Range 1.0.0.x</td>
<td><h4 id="snmp-main-connection">SNMP Main Connection</h4>
<p>This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161</em>.</li>
<li><strong>Get community string</strong>: The community string used when reading values from the device, by default <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string used when setting values on the device, by default <em>private</em></li>
</ul></td>
</tr>
<tr class="odd">
<td>Range 2.0.0.x</td>
<td><h4 id="serial-main-connection">Serial Main Connection</h4>
<p>This driver uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device.</li>
<li><strong>Bus address</strong>: The bus address of the device.</li>
</ul></li>
</ul></td>
</tr>
</tbody>
</table>

## How to Use

From range 2.0.0.x onwards, the element created with this driver contains the following data pages:

- **General**: Displays generic information about the module, such as the **Unit Type**, **Firmware version**, **Operation Time** and **RF State**.
- **Module**: Displays specific information about the module, such as **General Status**, **Gate Voltage** and **Temperature**.
- **Settings**: Allows you to change device settings such as **Mode**, **Control** and **Attenuation**.
  Note: RF Power Fault Limits only work in dBm because of a device issue when values are set in dBW or Watts. The logic for the other units of measure is still in the driver, but hidden.
- **Active Faults**: Displays the module active faults, such as **Logic Board**, **Fan** and **Power Supply**.
- **Detailed Faults**: Displays the **Detailed Fault Table**, with detailed information about module failures.
- **Events**: Displays the **Event Log Table**, with information about the historical module failures.

## Notes

In range 1.0.0.x, a device issue can occur that makes it impossible to process the detailed fault information.

In range 2.0.0.x, RF Power Fault Limits only work in dBm because of a device issue when values are set in dBW or Watts. The logic for the other units of measure is still in the driver, but hidden.

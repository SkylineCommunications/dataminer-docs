---
uid: Connector_help_VodafoneZiggo_Witbe_Maestro
---

# VodafoneZiggo Witbe Maestro

The VodafoneZiggo Witbe Maestro is used to manage and schedule tests on Witbe robots. This driver will create a DVE for each device of each robot that is managed by the Maestro. The driver also provides an overview of all test tasks that are scheduled for devices, collects and forwards results, and keeps a history of the performed tests.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

<table>
<colgroup>
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
<col style="width: 20%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
<td><strong>Linked Components</strong></td>
<td><strong>Exported Components</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>No</td>
<td>Yes</td>
<td><ul>
<li><em>WitBe Robot Manager</em> protocol</li>
<li><em>Schedule WitBe Maintenance</em> Automation script</li>
<li><em>Skyline SmartRec Application</em> protocol</li>
</ul></td>
<td><ul>
<li><a href="/Driver%20Help/VodafoneZiggo%20Witbe%20Maestro%20-%20Device.aspx">VodafoneZiggo Witbe Maestro - Device</a></li>
</ul></td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### Serial IP Connection - Robot POST Messages Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: Restricts the interfaces that can be listened to. Use "any" if you do not want to apply any restrictions.
  - **IP port**: The IP port (default: *8013).*

### Initialization

To make sure the driver can communicate with the Maestro, you need to specify credentials. To do so, fill in the **Email Address** and **Password** parameters on the **Configuration** page. The **Session Status** parameter will indicate if the credentials have been accepted.

In addition, you can configure the driver to convert test result codes to human-readable descriptions of the status. To do so, create a CSV file containing all error codes and descriptions, and store it in the folder *C:\Skyline DataMiner\Documents\VodafoneZiggo Witbe Maestro\Error Translation*. The file can then be ingested from the **Robot Translation** page.

### Redundancy

There is no redundancy defined.

## How to use

The driver uses the public REST API to poll data from the Witbe Maestro.

The **General** page of the element lists all past, currently running and future tests for all devices. The driver will poll running tests every 30 seconds to retrieve test results (as recommended in the API documentation).

You can manually add test jobs to a device on the **Add Test** page of the DVEs.

For information about the Witbe robot, go to the **Robots** page.

For an overview of all test scenarios, go to the **Scenarios** and **Scenario** **Instances** pages.

Additional configuration is available on the **Configuration** page.

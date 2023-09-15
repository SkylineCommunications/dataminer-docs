---
uid: Connector_help_Witbe_Robot
---

# WitBe Robot

The WitBe Robot is an appliance designed to test any application running on Microsoft Windows computers or IOS/Android devices. It replicates real user actions to provide information on the availability and performance of applications.

This connector will manage the test tasks that are scheduled for the robot, collect and forward results, and keep a history of the performed test tasks.

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
<td>1.0.0.x [Obsolete]</td>
<td>Initial version</td>
<td>-</td>
<td></td>
</tr>
<tr class="odd">
<td>1.1.0.x [Obsolete]</td>
<td>New robot firmware</td>
<td>1.0.0.5</td>
<td>-</td>
</tr>
<tr class="even">
<td>1.2.0.x [SLC Main]</td>
<td><p>Maestro Public API</p></td>
<td>1.1.0.12</td>
<td><p>To make sure running tasks are handled correctly when you update to this version:</p>
<ol>
<li>Disable all carousels and stacks on the WitBe Robot Manager.</li>
<li>Cancel and clear all queued tasks.</li>
<li>Update the WitBe Robot Manager.</li>
<li>Update the WitBe Robots.</li>
<li>Enable carousels and stacks on the WitBe Robot Manager.</li>
</ol></td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | v4.5.1.5               |
| 1.2.0.x   | v6.2                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                               | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------|-------------------------|
| 1.2.0.x   | No                  | Yes                     | \- *WitBe Robot Manager* connector - *Schedule WitBe Maintenance* Automation script | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the robot.
- **IP port**: The IP port of the robot rest API service (default: *4334*).
- **Device address**: The bus address of the device. If the proxy server must be bypassed, specify *BypassProxy*.

#### Serial Smart-Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION

- **IP address/host**: Specify "*any".*
- **IP port**: The IP port that DataMiner should listen to.

This connection will be used to listen for HTTP POST requests from the robot.

#### HTTP Maestro HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the Maestro.
- **IP port**: The IP port of the Maestro (default: *80*).
- **Device address**: The bus address of the device. If the proxy server must be bypassed, specify *BypassProxy*.

### Initialization

A **WitBe Robot Manager** element with the same Maestro IP address is required for the robot to be able to communicate with the Maestro. The Manager element needs to have valid credentials for the Maestro REST API.

A robot will respond with an **exit code** after running a task. This error code can be translated to a human-readable status and description. An **error translation CSV** file needs to be ingested by the element for this functionality to work. It is possible to modify this file so the exit codes can be translated into a status specific to the application. To make it possible to ingest the file, place it in the **Skyline DataMiner\Documents\Witbe Robot\Error Translation\\** directory. The file can then be selected and ingested from the **Robot Translation page**.

Test result messages received through the smart-serial connection can be forwarded to other elements, such as elements using the **Skyline SmartRec application connector**. You can configure this with the **Message Forward parameter**.

### Redundancy

There is no redundancy defined.

## How to use

### Scheduling tests

Tests can be scheduled for the robot in different ways.

You can **manually** schedule a test by adding it via the **Add Test page**:

1. On the **Tests** page, click the **Add Test** button.

1. Specify a name for the test, select the script to run and set the input test parameters.

   The input test parameters must have the following format: *param1:value1,param2:value2, ... ,paramN:valueN*

Tests can also be **automatically** scheduled by an element with the **WitBe Robot Manager connector**. Refer to the connector help page of the WitBe Robot Manager for more information.

### Queued Tests table

On the Tests page, the Queued Tests table **lists the scheduled tests**. The table not only keeps a record of all queued tests but also shows the current running test and all tests that have finished running.

You can cancel a queued test by clicking the **cancel button** or the **Cancel All Tests button**.

The Queued Tests table will store the status of up to 100 finished tests. You can change this default with the **Maximum Finished Tests parameter** on the **Configuration page**.

## Notes

If the element is in timeout, check if the WitBe Robot Manager has valid credentials for the Maestro API. Also check if the WitBe Robot Manager and the WitBe Robot connect to the same Maestro with the same IP address.

The Maestro REST API does not allow the canceling of running tasks. The previous task will still run on the robot after it is canceled. If a new task is pushed after a task is canceled, the canceled task will be added again.

A Visio drawing is available for this connector.

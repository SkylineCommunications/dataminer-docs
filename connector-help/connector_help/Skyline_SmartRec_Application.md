---
uid: Connector_help_Skyline_SmartRec_Application
---

# Skyline SmartRec Application

This connector works in combination with the **Ericsson RedBee EPG**, **Witbe Robot** and **WitBe Robot Manager** connectors. The goal is to **monitor** the **replay/startover functionality** of **set-top boxes**. The connector **manages** which **assets/programs** need to be tested and also **aggregates** the **test results**.

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
<td>-</td>
</tr>
<tr class="odd">
<td>2.0.0.x [Obsolete]</td>
<td>DVE elements for each channel</td>
<td>1.0.0.12</td>
<td>-</td>
</tr>
<tr class="even">
<td>2.0.1.x [SLC Main]</td>
<td>Split in separate elements for each platform</td>
<td>2.0.0.17</td>
<td><ul>
<li>Recreation of element is required</li>
<li>Loss of all trend data</li>
</ul></td>
</tr>
</tbody>
</table>

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
<td>2.0.1.x</td>
<td>No</td>
<td>Yes</td>
<td><ul>
<li>Ericsson RedBee EPG</li>
<li>WitBe Robot Manager</li>
<li>WitBe Robot</li>
<li>Ziggo Set Reservation Color</li>
</ul></td>
<td>Skyline SmartRec Application - Channel</td>
</tr>
</tbody>
</table>

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

A **channel number** needs to be set for each entry in the **Channel Status table**.

The **script** to be run by the WitBe robot needs to be configured via the **StartOver Configuration** and **Replay Configuration** parameters on the **Configuration page**.

### Redundancy

There is no redundancy defined.

## How to use

The **Channel Status** **page** shows the monitored channels for which tests are managed. You can remove the child DVE element by pressing the delete button; however, this is only possible when the channel is no longer monitored.

The **EPG Bookings table** contains a list of all program broadcasts that are in the resource manager. Programs in this table will be sent to the WitBe Robots for testing. The WitBe Robot Manager will handle the distribution of these program test campaigns. The aggregated result of all performed tests is shown in the **Program Status Column**.

The **Configuration page** is used to configure various aspects of the tests and the connector:

- Ignoring of startover tests that are performed too close to the end of the program.
- Configuration of the minimum number of test results required to aggregate the result.
- Configuration of test scripts to be used by WitBe robots.
- Enabling or disabling debug logging.
- Sending test results to the staging environment.

The **Ignored Assets pop-up page** allows you to create filters to ignore test results of certain programs.

The color of programs in the resource manager will be set to the color of the alarm of the **Program Status** in the **EPG Bookings table**.

The **EPG Result table** shows whether a program has already been tested.

The **StartOver Tests table** contains the aggregated results of all startover tests on a program. Startover tests are performed on programs that are currently airing. If the status is ***pending***, this means that there are not enough test results yet to show an aggregated result.

The **Replay Tests table** is similar, but contains results for replay tests. Replay tests are performed on programs that have finished broadcasting.

The **Robot Test page** contains data about all individual test results received from the **WitBeRobots**.

The **StartOver Channel Issues page** shows if many sequential programs are failing. This provides information as to the root cause of the issue that is causing the programs to fail.

The **Daily Aggregation page** provides an overview of the kind of issues that have occurred each day.

The **Weekly Aggregation page** provides an overview of the kind of issues that have occurred over a week.

This connector will export the Skyline SmartRec Application - Channel connector. An element will be created automatically for each monitored channel in the resource manager.

## Notes

Temporarily unassign all alarm templates when you start, stop or restart the element or its exported elements.

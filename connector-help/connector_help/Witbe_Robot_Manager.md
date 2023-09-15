---
uid: Connector_help_Witbe_Robot_Manager
---

# WitBe Robot Manager

The WitBe Manager is used to control the WitBe Robots. It works closely together with the Ericsson Redbee EPG connector (1.0.0.x range) and the Skyline SmartRec Application. It controls the flow of the Startover and Replay checks done on TV program information provided by the EPG connector. The WitBe Robots perform the tests and forward them towards the Skyline SmartRec Application, which aggregates the results.

## About

Tests are divided in 3 categories:

- **Replay**: Checks if the program can still be replayed successfully a few days after it has aired.
- **Replay day 0**: Checks if the program can still be replayed on the same day as it aired.
- **Startover**: Checks if the program can be replayed while it is still live.

These tests are put into tasks that the connector manages. Different kinds of tasks have different parameters. Communication between this connector and the SmartRec Application connector will provide the correct parameters for each task.

These tasks are put in two types of queues, which determine how the tasks are executed:

- **Carousel:** A carousel is used for **Replay** and **Startover** tests. A carousel with assigned tasks is basically an infinite loop. It tries to continuously assign tasks to its assigned robots. The next task to be executed will be the task with the lowest execution number. Carousel tasks remain in the carousel forever, unless they are deleted by the user. The tasks only specify the channel and replay day; the CRIDs of TV programs that comply with these parameters will be retrieved from the SmartRec Application.
- **Stack**: A stack is used for **Replay day 0** tests. Stacks do not use an infinite loop. They only keep running as long as they have tasks. The Skyline SmartRec Application connector is responsible for creating the tasks. The only thing the user must do to configure the stack is define which channel(s) it should monitor.

A wide variety of tasks can be created and assigned to their parent. The connector will automatically detect all WitBe Robots available on the DMA. Each robot can be assigned to a certain carousel/stack or set to automatic, which makes it available for all tasks. Whenever a robot executes a task, it will remove it from the stack task table.

The manager is a virtual element and uses JSON messages to communicate with the WitBe Robot and Skyline SmartRec Application connectors. This means that no data will be seen in the Stream Viewer.

The manager is accompanied by an Automation script that makes it easier for the end user to configure and create the carousel/stacks and attached tasks.

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
<td>initial version</td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.1.0.x [SLC Main]</td>
<td>Use Maestro Public API</td>
<td>1.0.0.12</td>
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
| 1.1.0.x   | v6.2                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                    | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- *WitBe Robot* connector - *Skyline SmartRec Application* connector - *Ericsson Redbee EPG* connector - *WitBe Manager Wizard* Automation script - *End of Program* Automation script                                                  | \-                      |
| 1.1.0.x   | No                  | Yes                     | \- *WitBe Robot* connector - *Skyline SmartRec Application* connector - *Ericsson Redbee EPG* connector - *WitBe Manager Wizard* Automation script - *End of Program* Automation script - *Schedule WitBe Maintenance* Automation script | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the Maestro.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server must be bypassed, specify *BypassProxy*.

### Initialization

Credentials for the Maestro REST API need to be entered on the **Maestro Configuration page**, which you can access from the **Configuration page**. The **Test button** allows you to check if the credentials are valid.

### Redundancy

There is no redundancy defined.

## How to use

### Robots

This page contains a table listing all available WitBe Robots found in the DMS. This list is automatically updated every hour. To **manually update** the list of available robots and their states, click the **Refresh Robots** button in the lower right corner.

Within this **Robot Table**, you can change the state of a robot. The right-click menu allows you to start, stop, or pause a selected robot. In addition, an **Execute Next** button is available for each robot. Clicking this button will add the next task in line to the queue of the robot. However, note that this will only work if there is a stack or carousel assigned to the robot.

The **Delete** button next to each robot can only be used in case the robot element was removed from the DMS. Otherwise, this button will remain disabled.

### Maintenance

This page is used to monitor the health of the robots. It has a **Maintenance table** that keeps track of all the failures of the robots. The Maintenance table also allows you to configure a maintenance task for each robot. When you notice that a robot is failing more than is allowed, you can manually schedule this task on the robot using the **Execute button**.

It is also possible to automatically schedule a maintenance task once a day using the **Maintenance Window column**. An hourly task needs to be created using the **DataMiner Scheduler** for this functionality to work. The **Schedule WitBe Maintenance Automation script** needs to be configured as the **action** of the scheduler task. When this is correctly configured, Scheduler will run the Automation script every hour, and the script will then schedule a maintenance task on the robots that allow it.

All failures within the last hour are stored in the **Failures table**. You can access this table via the **Failures** **button**.

### Carousels

This page displays a table listing all available configured carousels. A carousel can be enabled or disabled. When a carousel is enabled, it will start pushing tasks to the robots. When it is disabled, the robots and tasks will be cleared.

### Carousel Tasks

This page contains a table listing all carousel tasks. These tasks can be configured by the user, either via the context menu of this table or via an interactive Automation script. For each carousel task, the table contains the name of the script that should execute it, the name of the task, and a collection of parameters that will be translated by the Replay application.

Based on the execution numbers of the tasks, the WitBe Manager chooses the next task to be executed by the robots. If the robot does not run the script that was assigned to the task, it will ignore the task and try another one.

Whenever a task was executed, it gets a new execution number assigned, which will be the highest one compared to the rest of the tasks. This means that at that point, the task receives the lowest priority to be executed by the robot.

### Carousel Overview

This page provides a clear overview of the carousels, robots, and assigned tasks, making it easier to navigate through the configurations.

### Stacks

This page is similar to the Carousels page but contains an additional **Matching List** column. This matching list is a collection of channel names that will be monitored by the stack. Based on the matching list, the Redbee EPG connector will create a stack task for every program that ended.

### Stack Tasks

This page lists all the stack tasks. These stack tasks **cannot be created manually** but are instead created by the Redbee EPG connector via an Automation script.

The tasks contain information for the WitBe Robots so they know which program exactly they should test. This works differently for stack tasks than for carousel tasks. When a stack task is picked up by the robot, it will be **removed** from the stack. Because of this, stacks will not go into an infinite loop. The **priority system** is also slightly different. When a stack task enters the system, it will increment the counter of the **other tasks assigned to the same channel** by one. The manager always gives priority to the tasks with the **lowest** counter.

There is automatic cleanup active for this table, which can be configured on the Configuration page (see below).

### Stack Overview

Like the carousel overview, the stack overview provides a clear overview of the stack configuration with its attached tasks and robots.

### Configuration

On this page, you need to specify the DataMiner ID/Element ID of the **Replay Element**. In addition, you can configure the **automatic cleanup** of stack tasks.

Every day, the stack tasks from the day before are automatically cleaned up, at the time determined by the **Stack Tasks Cleanup Hour** setting. With the **Stack Tasks to Keep** setting, you can specify how many tasks should be kept. The cleanup of the Stack Tasks table is necessary because a stack can contain many tasks, potentially even more tasks than the robots can handle. Every time the table gets cleared, the number of removed tasks is saved in the stack configuration. This way, you can check how many tasks were removed, and assign more robots to a stack if necessary.

## Notes

The manager comes with an Automation script that makes it easy to create and configure tasks. There are many filters available in the Automation script that interact with the Resource Manager module. If there is no data available in the EPG Redbee connector and Resource Manager module, the Automation script will not be usable.

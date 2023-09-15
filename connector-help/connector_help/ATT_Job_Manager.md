---
uid: Connector_help_ATT_Job_Manager
---

# ATT Job Manager</h1>

The **ATT Job Manager** protocol is a virtual connector used to execute **Automation Scripts (Jobs)** when certain conditions are met. It works together with the **ATT Channel Manager** protocol (version 1.0.1.9 and later). **The ATT Job Manager** listens for notifications from the **ATT Channel Manager** and executes **Automation Scripts** in response.

## About

The **ATT Job Manager** allows registering **Automation Scripts (Jobs)** that accept at least three input parameters: **Command**, **Result** and **Feedback**. It is possible to create a wide variety of jobs and assign them to a specific trigger. The connector will automatically execute the registered **Jobs** when a matching notification is received.

The **Command** parameter is used to send information to the Automation Script.

The **Result** parameter is a numeric value used to notify the ATT Job Manager about execution result of the Automation Script and can be:

**Failed** = 2, **Succeeded** = 3

The **Feedback** parameter is used to send information from the Script to the ATT Job Manager about the possible cause of the Automation Script failure, and it will be displayed in the Queue Table.

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | -                     |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Jobs

The **Jobs** page contains a table with all of the available **Jobs**. Using a context menu it's possible to add new **Jobs** or remove existing **Jobs**.

### Queue

The **Queue** page contains a table with all of the enqueued **Jobs** to be executed. **Jobs** in the queue are executed sequentially. The time interval between the execution of two jobs can be configured. Using the buttons **Remove** and **Execute Now** it is possible to delete **Jobs** from the queue or execute them without waiting for the execution interval.

### Executed Jobs

The **Executed Jobs** page contains a table with all of the enqueued **Jobs** that were executed with success. **Jobs** in this table can be removed manually. This table implements an **Auto Cleanup** functionality that can be configured using a pop-up page.

### Failed Jobs

The **Failed Jobs** page contains a table with all of the enqueued **Jobs** that failed to execute. **Jobs** in this table can be executed manually or permanently deleted. This table implements an **Auto Cleanup** functionality that can be configured using a pop-up page.

## Notes

The **ATT Job Manager** works together with the **ATT Channel Manager** protocol and certain **Automation Scripts**, for example: **Script_ATT IPX Update_V2**

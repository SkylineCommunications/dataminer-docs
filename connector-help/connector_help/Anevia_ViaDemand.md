---
uid: Connector_help_Anevia_ViaDemand
---

# Anevia ViaDemand

Monitors and controls what content should be played, how long and when it should be played.
You can also edit the settings of the tasks.

## About

The connector is the same as the scheduled play of the webpage, it gives an overview of all the tasks that are scheduled to play and the possibility to create a new task or edit them.

## Installation and configuration

### Creation

This connector uses a **HTTP** connection and needs following user information:

**SERIAL CONNECTION**:

- **IP address/host**: the polling IP or URL of the destination eg *10.24.5.10*
- **IP port**: the port of the destination eg *80*

The credentials for authorization are set on the **General page** by clicking the page button **Credentials**.
There you can set the **username** and **password** wich are default *admin* and *paris*.

## Usage

### General

This is the same as the Anevia Soap System connector.

On this page you get an overview of some general server parameters.
You can view the **RAM memory** parameters, **API version** and CPU usage.
When you press the **Credentials** button, you can set your username en password to communicate with the server.
On this page, you also have the ability to reboot your server.

### Configurations

On this page you can export and import configuration from/to the device. The status of the export/import can be seen in the **Import/Export Status** parameter.

The exported configurations are stored under the folder `C:\Skyline DataMiner\Documents\Anevia ViaDemand`.

### Tasks

This page gives an overview of all the tasks that are scheduled to play.
You can create a new task to play.
In the table you can see the **task ID**, which is used to edit a task.
Via the parameter **Select Task** you can choose a task and then press **Edit** to edit that task.
On the **Edit** page you can fill in all the settings for the task and then choose for a new task or to edit this task. Some task parameters can't be edited like **source** and **destination**, so these will automatically become a new task.

### Disk Overview

This page is also in the Anevia Soap System connector.

On this page you can find information about the used memory of the hard discs.

### Interfaces

This page is also in the Anevia Soap System connector.

On this page you can find information about the different interfaces that you can use to play a scheduled task.

### Web Interface

This page shows the webpage of the device by the polling IP.

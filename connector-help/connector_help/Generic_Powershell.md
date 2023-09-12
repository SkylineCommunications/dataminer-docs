---
uid: Connector_help_Generic_Powershell
---

# Generic Powershell

The Generic Powershell connector allows you to send commands to your command line shell and monitor the responses.

PowerShell is a task-based command line shell and scripting language built on .Net. PowerShell, which helps system administrators and power users to rapidly automate tasks that manage operating systems (Linux, MacOS, and Windows) and processes. PowerShell commands allow you to you manage computers from the command line.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

### General

This page contains a table listing the PowerShell commands that are executed by the connector. By right-clicking the table, you can add a command. By right-clicking an existing command, you can remove that command.

The **Timer Configuration** parameter allows you to configure how fast the commands in the table have to be executed.

For **Remote Commands** execution, the PowerShell Remoting option needs to be enabled, as specified in the [Enable-PSRemoting documentation](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/enable-psremoting?view=powershell-7.2).

Note that double-clicking the response parameter allows you to check the full response text.

### Commands Template

This page contains the templates table, where you can define a command template and associate it with a description.

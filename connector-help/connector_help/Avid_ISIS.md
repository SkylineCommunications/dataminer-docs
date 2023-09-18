---
uid: Connector_help_Avid_ISIS
---

# Avid ISIS

This connector monitors ISIS-related system events on the associated **Avid ISIS System Director**.

## About

This connector uses **SNMP** Get calls to extract the relevant information used to monitor and manage Avid ISIS events.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.7.3 15400                 |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 10.205.0.11
- **Device address**: not required

SNMP Settings:

- **Port number**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

This connector presents the system events in four different data display pages on the element card.

### General

This page contains information about the system:

- **Product Name**: Name of the ISIS product line.
- **Version**: Version of the ISIS install.

### Status

This page contains information regarding the overall status of the system:

- **System Director State:** State of the system director.
- **Check Event Log:** Information regarding the check event log flag.
- **Workspace Redistributing Count:** Current number of workspaces performing a redistribution.

### Performance

This page contains information on the overall system performance:

- **Megabytes Per Second:** Total data rate for all connected clients.
- **Read Megabytes Per Second:** Read data rate for all connected clients.
- **Write Megabytes Per Second:** Write data rate for all connected clients.
- **Messages Per Second:** Number of messages per second the system director is processing.
- **Open Files:** Number of opened files.
- **Active Client Count:** Number of active clients.
- **Maximum Client Count:** Maximum number of active clients.

### Usage

This page contains system usage information:

- **Highest Disk Used Percentage:** Highest percentage of disk usage.
- **Total System Size:** Total system storage capacity.
- **Total Allocated Size:** Total allocated capacity across all workspaces.
- **Total Used Size:** Total capacity usage across all workspaces.
- **File Count:** Existing number of files across all workspaces.
- **Folder Count:** Existing number of folders across all workspaces.
- **Workspace Count:** Total number of workspaces.

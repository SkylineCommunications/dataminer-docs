---
uid: Connector_help_Agama_Technologies_Analyzer
---

# Agama Technologies Analyzer

This connector is used to monitor and control **Agama Technologies Analyzer** devices.

## About

With this connector, you can monitor and control Agama Technologies Analyzer devices. This is a serial connector. Communication goes through SSH.

In an element using this protocol, all the tested monitors are visible. Monitors can be started and stopped.

## Configuration

### Connections

This is an SSH connector. The IP address needs to be configured during creation of the element.

**SSH CONNECTION**:

- **Type of port**: TCP/IP
- **IP address**: The IP of the device, e.g. *10.11.12.13*.
- **IP Port**: The IP port of the device, by default *22*.

### Initialization

To make sure there is communication with the device, you must fill in the SSH username and password on the **Configuration** page of the element.

## Usage

### General page

This page displays the **version** number, **CPU usage** and **memory usage** of the analyzer.

The **Analyzer** and **Aksusbd** Linux service status are also available here, and it is possible to start, stop and restart the services.

### Active Alarms page

This page displays the **Active Alarms Table**.

The SSH interface of the analyzer does not have commands to retrieve alarm information, but that information is available on the Agama Enterprise server. An Agama Enterprise server DataMiner element can be configured to forward active alarms information to this table.

### Monitors page

This page contains a table with all the monitors and their status.

### Backup/Restore page

On this page, you can back up and restore the entire analyzer, or only its configuration. The SSH user needs to have write access to the specified backup path.

### Configuration page

On this page, you must enter the username and password to log on to the SSH session. Root access is not necessary. Refer to the "Notes" section below for more information on user access.

To automatically log in on the web interface page, fill in the username and password of a user with web interface access.

The **Default Agama Path** parameter must contain the path where the analyzer software is installed. By default this is "*/usr/local/ria/analyzer/bin/*".

The **Thumbnail Link Template** parameter is used to provide a link to the video thumbnail, in the **Monitors Table**. The "*{0}*" placeholder will be replaced by the URL-encoded thumbnail link.

### Web Interface page

This page allows access to the web interface of the device. The web interface credentials on the configuration page are used to log on automatically here.

The client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

For the execution of some SSH commands used by this connector, root privileges are required, though it is not necessary to log in as root.

To allow the execution of those commands as a normal user, please configure the device to allow sudo without password for the following commands:

- /etc/init.d/analyzer status
- backup
- restore
- service analyzer
- service aksusbd

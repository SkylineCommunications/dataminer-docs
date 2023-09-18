---
uid: Connector_help_Agama_Technologies_OTT_Analyzer
---

# Agama Technologies OTT Analyzer

This connector is used to monitor and control an **Agama Technologies Analyzer OTT** device. This device monitors a set of QoS parameters from the physical layer to the transport stream, even up to the level of the audio and video content.

## About

With this connector, you can monitor and control Agama Technologies Analyzer devices. This is a serial connector. Communication goes through SSH.

In an element using this protocol, all the tested assets are displayed, and there is also more detailed status information for each test quality. Assets can be added or removed, and individual tests can be removed. Other elements can send commands to add or remove assets on the analyzer.

## Installation and Configuration

### Creation

This is an SSH connector. The IP address needs to be configured during creation of the element.

**SSH CONNECTION**:

- **Type of port**: TCP/IP
- **IP address**: The IP of the device, e.g. *10.11.12.13*.
- **IP Port**: The IP port of the device, by default *22*.

### Configuration

To make sure there is communication with the device, you must fill in the SSH username and password on the **Configuration** page of the element.

## Usage

### General Page

This page displays general information, such as the **version** number, **CPU usage** and **memory usage** of the analyzer.

The **Analyzer** and **Aksusbd** Linux Service status are also available here, and it is possible to start, stop and restart the services.

### Active Alarms Page

This page displays the **Active Alarms Table**.

The SSH interface of the analyzer does not have commands to retrieve alarm information, but that information is available on the Agama Enterprise server. An Agama Enterprise server DataMiner element can be configured to forward active alarm information to this table.

### Overview Page

This page displays a tree view with all **assets and associated tests**.

### Templates Page

This page contains a table with the **test templates** defined on the device. The service type needs to be configured by the user, and is used to determine the scope in the link URLs.

### Assets Page

This page displays a table with the assets that are being monitored, and the number of defined tests. Assets can also be added and deleted.

Active alarms are grouped for each asset, and the highest severity is displayed in the severity column.

### Tests Page

This page contains two tables: a table with all defined tests, and a table with all tests running on the analyzer. Tests can be deleted.

Active alarms are grouped for each test, and the highest severity is displayed in the severity column.

### Backup/Restore Page

On this page, you can back up and restore the entire analyzer, or only its configuration. The SSH user needs to have write access to the specified backup path.

### Configuration Page

On this page, you must enter the username and password to log on to the SSH session. Root access is not necessary. Refer to the "Notes" section below for more information on user access.

To automatically log in on the web interface page, fill in the username and password of a user with web interface access.

The **Default Agama Path** parameter must contain the path where the analyzer software is installed. By default this is "*/usr/local/ria/analyzer/bin/*".

### Web Interface Page

This page allows access to the web interface of the device. The web interface credentials on the configuration page are used to log on automatically here.

The client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

For the execution of some SSH commands used by this connector, root privileges are required, though it is not necessary to log in as root.

To allow the execution of those commands as a normal user, configure the device to allow sudo without password for the following commands:

- /etc/init.d/analyzer status
- backup
- restore
- service analyzer
- service aksusbd

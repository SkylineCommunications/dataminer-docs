---
uid: Connector_help_MIT-XPERTS_iMux
---

# MIT-Xperts iMux

The MIT-Xperts iMux is a Stream Multiplexer for broadcasting. It supports different source types (Carousels, Transport Streams (TCP, UDP, File.)) for the input, and associates these with configured services and applications. The device also provides an SNMP interface for monitoring (alarms and traps).

## About

In addition to its incorporated web interface, the MIT-Xperts iMux exposes a Java API for communication and configuration of the device. This protocol accesses said Java API in order to control the iMux device. (See *'Configuration'* below).

For monitoring and alarming, an SNMP connection is used. The device supports some basic traps that inform when the alarm table states have changed and should be polled again.

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Configuration

After you create the element, you still have to set the user credentials to access the device. To do so:

1. Go to the **Overview** page, and click **Connection Options.**
1. Enter the username, password and device IP address.
1. Click the **Connect** button.

Note that this is only necessary immediately after the element is created or when these values change.

In order for DataMiner to be able to communicate with the device, the Java API has to be compiled into a C# .dll library. For this, an open source solution (IKVM) has been used. This software compiles exposed C# methods that are run on top of an integrated java VM. As such, this protocol also requires an installation of the Java runtime environment (the version depends on IKVM requirements).

Both the compiled iMux API .dll library (iMuxTwo.dll) and the IKVM .dll (IKVM.OpenJDK.Core.dll) are included with the protocol. These files have dependencies on additional .dlls, and as such the included IKVM.7z file should be extracted to the folder *C:\Skyline DataMiner\ProtocolScripts*. This .7z file contains all the .dll files required to run the protocol.

Newer iMux API versions must also be compiled into a new .dll file in order to be used, and the file iMuxTwo.dll must be replaced with the newer version.

## Usage

### Overview Page

On this page, you can configure the connection credentials (with the **Connection Options.** page button), activate the current configuration, and see a list of messages related to that activation. Error messages in the configuration will be displayed in the **Activation Message Details** textbox.

It is also possible to view the Multiplexer Settings by clicking the appropriate page buttons. These values are read-only as the iMux API does not support setting of these parameters.

### DSMCC-Carousels Page

On this page, you can access and configure the list of DSMCC Carousels of the device. It is possible to edit existing Carousels and create new ones.

An overview of each Carousel is displayed in the **DSMCC Carousels** table. To edit a specific Carousel or to get additional information on it, click the **Select** button. Then click **Edit Selected Carousel.** to open the **Edit** page and edit the Carousel information.

### Transport Streams / Sections Page

The functionality of this page is similar to that of the **DSMCC Carousels** page. A list of available Transport Streams is displayed and you can select each one individually to get additional information and edit it.

Different types of Transport Streams will include different parameters. On the **Edit Transport Stream** page some values will display "*NA*" for the selected Transport Stream. These represent parameters not used by this Transport Stream's specific type, which will therefore be ignored when the **Save All Changes** button is clicked.

You can also create new Transport Streams by clicking the respective page button ("**TCP/IP Transport Stream.**", "**UDP/IP Transport Stream.**", "**Transport Stream File.**", "**EIT Data.**", "**Sections File.**"). Then fill in the appropriate parameter values and click the **Create** button.

### Applications Page

The functionality of this page is also similar to that of the **DSMCC Carousels** page. A list of configured applications is shown and additional information for each application can be displayed by selecting the desired application and clicking the **Edit Selected Application.** page button. Values set to "*NA*" are not used by the specific application type and will therefore be ignored when the **Save All Changes** button is pressed.

To create a new application, click the respective New Application page button for the desired type ("**DVB-HTML Application.**", "**DVB-J (MHP) Application.**", "**MHEG Application.**", "**HBBTV/CE-HTML Application.**"). Then fill in the correct values for each parameter and click the **Create** button.

### Services Page

The functionality of this page is similar to that of the previous pages. A list of services is displayed and you can select the desired service in order to see additional information on it. Click the various **Edit Service** page buttons ("**AC: Transport Stream.**", "**AC: DSMCC-Carousels.**", "**AC: Dummies.**", "**Application List (AIT).**", "**Edit Selected Carousel.**") to access the respective information.

The **Create New Service.** page button allows you to create a new service. Fill in the correct parameter values and then click the **Create** button.

### Alarming Page

This page displays the current overall state of the device. It includes five tables:

- **iMux Carousel Table**: Displays the list of all configured Carousels and their current state.
- **iMux Tstream Table**: Displays the list of all configured Transport Streams and their current state.
- **iMux Application Table**: Displays a list of all configured applications and their current state.
- **iMux AITTable**: Displays a list of all configured AITs and their current state.
- **iMux Service Table**: Displays a list of all configured services and their current state.

These table entries are updated every minute, or when the corresponding SNMP trap is sent.

### Web Interface Page

This page provides access to the device's web interface page.

---
uid: Connector_help_Ateme_SR1000
---

# Ateme SR1000

This is an SNMP connector responsible for the control and the monitoring of a statistical bitrate allocator.

## About

This connector retrieves status information and allows the user to configure system parameters and change the network configuration of the device, both through SNMP.

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device, e.g. *10.24.4.9*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

## Usage

### General

This page displays general system information, such as the **System Time**, **Name** and **ID** parameters, but also the **Status** (**System Failure, Temperatures, FANs status, Ethernet configurations**) and **License** information. Some of those parameters can be configured (**names, system time, interface names** and **status**, ...).

### Configuration

On this page, you can manage configurations by **loading** or **storing** them (**SR Configuration Management** section). The page contains a table displaying all the **Configuration names**. You can also configure the pools through page buttons.

Via the **New Channel** page button, you can perform the following operations: specify on which pool you which to make a change through the **New Channel to Pool** parameter. Then, you can add channels one by one by filling in the **New Channel** parameters. Then, when all the information is correct, you can press the **Add** button to create a channel. The minimum information to provide to create a channel is the **New Channel Minimum Bitrate, New Channel Maximum Bitrate** and **New Channel Fallback Bitrate**. The New **Channel Status** and **New Channel Error** indicate you if the operation succeeded. With the **New Configuration** parameter you can provide a full pool configuration (the one selected in the **New Channel to Pool Parameter**). The information must be a *pipe* and *semi-column* separated list: pipes split the channels and semi-columns split the fields for a particular channel.

Here is an example to configure a pool with 2 channels:

channel_0;1.2.3.4;500;1;true;false;7.8.9.10;600;12;100000;500000;300000;50\|channel_2;1.2.3.4;500;2;true;true;100.15.104.41;14;2;100000;500000;300000;55

channel 1 will be configured with the following information:

- **Channel Name:** *channel_0*
- **Channel IP:** *1.2.3.4*
- **Channel Port:** *500*
- **Channel Number:** *1*
- **Channel Backup Is Enabled:** *Yes*
- **Channel Backup Is Auto:** *No*
- **Channel IP Backup:** *7.8.9.10*
- **Channel Port Backup:** *600*
- **Channel Number Backup:** *12*
- **Minimum Bitrate: 100000 bps**
- **Maximum Bitrate:** *500000bps*
- **Fallback Bitrate:** *300000bps*
- **Quality:** *50%*

**New Configuration Status** informs you about the success or failing of the operation.**
**

### Network

This page contains two tables that display information about the **Ethernet** (**DHCP**, **Address**, **Netmask**, **MTU**, **VLAN**, ...) and **Route** configuration (**Type, VLAN ID, Address, Netmask, Gateway,** etc.). All the parameters on this page can be configured.

### Status

This page displays the **names** and the **bitrates** of the pools. Each page button displays a table containing status information of each channel of the corresponding pool.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

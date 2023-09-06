---
uid: Connector_help_VMWare_vCenter
---

# VMWare vCenter

VMware vCenter Server provides a centralized platform for managing your VMware vSphere environments, allowing you to automate and deliver a virtual infrastructure across the hybrid cloud with confidence.

## About

The VMWare vCenter driver enables DataMiner to communicate with a VMWare vCenter Server allowing a user to remotly monitor and operate a vCenter server.

### Ranges of the driver

| **Driver Range** | **Description**                                                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version                                                              | No                  | True                    |
| 1.0.1.x          | Improve perfomance when polling big amounts of data (multi-threaded timers). | No                  | True                    |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | API Version 6.5             |
| 1.0.1.x          | API Version 6.5             |

## Installation and configuration

### Creation

#### HTTP Main Connection

This driver uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. *default is 443.*

At first run the user must access the Login Setup page and edit the Username Field and the Password field and then press Authenticate button in order for the protocol to start polling data correctly.

## Usage

### General

In this page a variaty of general data is displayed. The available data features mostly system and product related data and a variaty of subpages such as:

- **Advanced Networking**
- **Health**
- **Networking**
- **Partitions**
- **Security**
- **Services**
- **SNMP Settings**

This page and all subpages are populated using the **Appliance API**.

### Polling Configurations

In this page it is possible to setup the login credentials so that the driver can communicate successfully with the VMWare vCenter Server.

At first run it is advised to setup **Username** and **Password** and then press the Authenticate button.

If the login is successfull the REST vCenter API Status, REST Appliance API Status and the Web Service API Status will eventually be sucessfull.

**An adequate toogle button is provided for enabling each API.**

The user must enable the APIs that he would like to enable polling. Currently the driver supports the **vCenter API** (Datacenters, Clusters, Hosts, Virtual Machines, Datastores and Networks), **Appliance API** (General Data)and the **Web Services API** (Performances Data).

Refer to the driver log if the login is unsuccessfull.

### Datacenter Topology

In this page contains the datacenter topology as well as its assigned clusters, hosts and virtual machines.

A variety of data is provided in this topology.

Hosts and Virtual Machines performances are also available in the Tree.

### Hosts

This page displays all the Hosts present in the VMWare vCenter Server.

### Virtual Machines

This page displays all the Virtual Machines configured in the VMWare vCenter Server.

### Storage

This page displays all the available storages so that it is possible to check the storage capacity and the free capacity of the system.

### Networks

This page displays all the configured networks in the VMWare vCenter Server.

### Hosts Sensor Info

This page displays Numeric Sensor Information for the hosts.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

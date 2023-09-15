---
uid: Connector_help_Imagine_Communications_VHE_Manager
---

# Imagine Communications VHE Manager

The **Imagine Communications VHE Manager** is a DataMiner application that is used to monitor and control the family of modules of a Selenio platform.

The application discovers all the recognized modules in a Selenio frame after the IP address, mask and community string of the frame-controlled module inside the frame are set. The resulting discovered inventory is presented in the **Device and Module** tables where the user can create corresponding DataMiner elements or remove existing ones.

The name of the discovered elements is based on a user-configurable column of the **Device** table, which initially contains the IP address of the selection frames found during the network scanning process.

The module-related information depends on the model of each discovered card, with an initial **Visio** view assigned.

## About

The connector uses the SNMP protocol to discover the modules of a frame controller and then creates the specific DataMiner elements with the corresponding protocol and IP addresses based on the IP of the found controller and the slot position.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation of the VHE Manager

One VHE Manager must be created on a DataMiner Agent. However, this is usually done with a DataMiner installer.

The IP address that you configure during the creation of this manager is not really important, so it can be configured as the loopback *127.0.0.1*.

### Discovery of Selenio frames

1. Open the **Imagine Communications VHE Manager** and go to the data category **Settings**.

1. Configure the IP address, network mask and read community string to be used for the discovery process.

1. Once these are configured, go to the data category **Devices** and press the button **Scan Network** to begin the discovery process over the configured IP address and network mask.

   Note that this process could find more than one Selenio frame in the network. In that case, the Device table will contain each of these frames, identified by their specific IP addresses.

## Usage

### Creation of the modules in a frame

For each device in the **Device** table, the connector will automatically create the corresponding module of each slot in the **Module** table. It will also create the corresponding DataMiner element, provided that the model of the card has been defined in the connector.

However, it is possible to create or delete a complete frame using the buttons **Create** and **Delete** in the **Device** table.

**WARNING:** Due to the discovery and automatic synchronization process, the connector will **remove** any manually created module not recognized by the VHE Manager connector. As such, any new Selenio model connector will also be included in the VHE Manager protocol.

### Connections

This page contains an overview of the existing connections and provides access to pop-up pages with more connections details.

### Services

This page displays a list of existing services. The name of the services can be specified.

### Settings

This page contains configurable settings for the protocol, such as the **IP Address**, **Subnet Mask**, and **Read Community Strings**.

## Notes

A custom Visio file is needed (Imagine Communications VHE Manager Visio File).

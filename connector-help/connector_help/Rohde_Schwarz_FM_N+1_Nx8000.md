---
uid: Connector_help_Rohde_Schwarz_FM_N+1_Nx8000
---

# Rohde Schwarz FM N+1 Nx8000

The **Rohde Schwarz FM N+1 Nx8000** connector is used to display and configure information of the related device.

## About

This protocol can be used to monitor and control the Rohde Schwarz FM N+1 Nx8000 device. An SNMP connection is used in order to successfully retrieve information and configure the device. There are also different alarm monitoring and trending possibilities available for the supported transmitters.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/Host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

This connector delivers two types of DataMiner elements: a parent element representing the device, and a virtual element for each configured transmitter.

### Main Element

The connector's main element contains the following pages:

- **Switchover Unit:** General switchover unit statuses and configuration. Two sub-pages are available:

- **Log:** Logbook of the device.
  - **Product Info:** Product information for the configured transmitters.

- **Summary:** Overview of all configured transmitters and their statuses.

- **Transmitter:** Overview of all configured transmitters and their settings.

- **Exciter:** Overview of all exciters.

### Virtual Elements

For every configured **transmitter** on the device, a Dynamic Virtual Element (**DVE**) is created with a specific name (**Main Element Name** followed by the related **Transmitter Name**, for instance: *FM N+1 Nx8000.Transmitter A1*). Each of these DVEs contains the following pages:

- **Summary:** Information about the related transmitter, such as **Summary Fault**, **Summary Warning**, **Forward Power**, etc.
- **Transmitter:** Transmitter-related settings, such as **Tx Reset Sum Fault**, **MPX**, **AES**, **AUX,** etc.
- **Exciter:** Overview table of the transmitter-related Exciter statuses, such as **Nominal**, **Current dBu**, etc.

## Monitoring

The Rohde Schwarz FM N+1 Nx8000 protocol allows the use of DataMiner alarm monitoring and trending: for every configured transmitter DVE, monitoring and trending can be configured specifically for the transmitter in question.

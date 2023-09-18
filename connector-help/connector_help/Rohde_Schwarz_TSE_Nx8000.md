---
uid: Connector_help_Rohde_Schwarz_TSE_Nx8000
---

# Rohde Schwarz TSE Nx8000

With this connector you can gather and view information from the **Rohde Schwarz TSE Nx8000** TSEs.

## About

This connector uses SNMP to monitor the **Rohde Schwarz DVB-T N+1 Nx8000** device. **Four elements** should be created for the four TSEs in the device (A1, A2, A3, B).

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.62*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *171* for Tx A1, *172* for Tx A2, *173* for Tx A3 and *179* for Tx B
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the TSE, such as the **Operation Mode**, **Input state** and **Auto Switch Configuration**.

### Events

This page displays the **Event Table**, which contains information necessary for handling alarms.

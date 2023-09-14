---
uid: Connector_help_Axon_GDR10
---

# Axon GDR10

The **Axon GDR10** is a 3 GB/s, HD, SD 1 to 8 distribution amplifier with reclocked outputs (ASI/DVB compatible).

## About

With this connector, you can monitor and configure the state, lock status, etc. of the cards available in the equipment.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection**

- **IP address/host:** The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 2 pages available.

### General

This page contains the relevant information coming from the standard **MIB-2** (**system description**, **location**, etc.).

### Cards

On this page, you can see **how many cards are installed** in this equipment, as well as configure parameters associated with them. You can use the **name of the card**, as well as its index **to filter entries** in the table or to configure alarm templates.

## Notes

No web interface was reported for this model.

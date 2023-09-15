---
uid: Connector_help_Rohde_Schwarz_DVB_NV7000
---

# Rohde Schwarz DVB NV7000

Liquid-cooled transmitters for analog and digital TV consisting of exciters, power amplifiers and a transmitter rack. The connector monitors a controller controlling two exciters (A and B or main and backup). For each exciter a DVE is created.

## About

This connector uses **SNMPv2** to poll data from the device and display it accordingly. Traps are not implemented. This connector will export one connector (see "Exported Connectors" below).

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Exported connectors

| **Exported Connector**              | **Description**                                |
|------------------------------------|------------------------------------------------|
| Rohde Schwarz DVB NV7000 - Exciter | Exciter A and B containing their summary fault |

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Configuration of the Output Power Percentage parameter

After element creation, the **Output Power Percentage** parameter will not yet be correct.
To correctly compute this parameter, the **Nominal Power** parameter must be set on the **General** page.

### Configuration of the SNMP Interface parameter

This connector supports two different MIBs to interface with this device. These contain the same parameters, but have slightly different OIDs. The connector should automatically detect the installed SNMP protocol for the device and select the correct interface, but in some situations it is possible that this will not work. This can for example be if the IP address is wrong, if the read community string is wrong or if a firewall blocks the traffic to the device. In those cases, the communication problem should be fixed first. Once it is fixed, restart the element and it will try to auto detect the required network interface again.

However, once an interface has been selected (either automatically or manually) the connector will not change this setting anymore. So if the interface changes, for example because the device was replaced by another using the other SNMP interface, then a manual action will be required to change the SNMP interface. For this, you must use the parameter **SNMP Interface** on the **General** page to select the correct OIDs for the parameters for SNMP communication.

Devices using MIB "rs_xx7000_dtv_dd.mib" use OIDs in range 1.3.6.1.4.2566.10.7.x and should select "*NETCCU700 SNMP-Interface*".
Devices using MIB "rs_nv7000_dd.mib" use OIDs in range 1.3.6.1.4.2566.10.2.x and should select "*Netlink ZR700-N SNMP-Interface*".

## Usage

The connector contains three pages and an additional page with the device's web interface. It also generates 2 DVE elements.

The DVE elements each only contain one parameter, **Summary Fault**, which has the same value as found in the **ET - Summary Fault** column in the **Exciters Table** on the **Exciter** page. The DVEs can be used to build redundancy groups and associated logic.

### General

On this page, several status and configuration parameters can be found.

The most important status parameters are:

- **Summary Fault**
- **Summary Warning**
- **Rf Present**
- **Rf Ok**
- **Forwarded Power**
- **Reflected Power**

The most important configuration parameters are:

- **Operation Mode Tx**
- **Operation Mode Standby**
- **Preselect Exciter**
- **Preselect Exciter A Input**
- **Preselect Exciter B Input**

There is also a **Nominal** **Power** parameter, which can be configured with the expected output power for the transmitter. Once this parameter has been set, the **Output Power Percentage** parameter will contain the **Forward Power** multiplied by *100* and then divided by the **Nominal Power**.
Note: as long as this parameter has not been set, the calculated percentage will show *Infinity.*

Finally, there is one last important parameter: **SNMP Interface**. This parameter is used to select the correct OIDs for the parameters for SNMP communication.
Normally there should be no need to set this parameter, because it should be automatically configured after first startup. But in some circumstances, in particular when the device is replace by another using different MIBs, it may be necessary to override this setting. Refer to the section "Configuration of the SNMP Interface parameter" above for more information.

### Exciter

This page displays information about the two exciters of the device, named *A* and *B*. For each exciter, you can find the active input, a parameter to select an input and the status of the two input signals. There is also a parameter that indicates which exciter is currently active and what the status of the automatic change is.

This page also contains the **Exciters Table**, which should contain two records (*A* and *B*). Those records generate two virtual elements, called *\[ElementName\].Exciter A* and *\[ElementName\].Exciter B*.
The last column in the table, **ET - EID**, contains the DataMiner ID and Element ID of the virtual element.

### Registers

This page contains the number of warnings and faults for these registers:

- Exc A (Exciter A)
- Exc B (Exciter B)
- Ccu (Core Computing Unit)
- Amp (Amplifier)

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

---
uid: Connector_help_Telenet_eMTA_Collector
---

# Telenet eMTA Collector

The **Telenet eMTA Collector** is part of the CPE setup, and works together with the **Telenet CPE Manager**, **Telenet STB Collector** and **Telenet CM Collector** connector. This connector is responsible for the polling of the eMTAs.

## About

This connector will poll all the eMTAs in two poll cycles:

- one fast poll cycle that will poll all eMTAs over a 15-minute period.
- one slow poll cycle that will poll all eMTAs over a 24-hour period.

The polled data will be offloaded into CSV files and will be aggregated by the CPE Manager element. The CPE Manager element will provision the eMTA Collector with the eMTAs that need to be polled and their IP addresses.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: 127.0.0.1 (IP addresses will be dynamically filled in)
- **Device address**: Not needed

**SNMP Settings:**

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: Not needed, because the connector will not perform sets.

Note: All polled eMTAs will use the same settings.

### Configuration of the offload parameters

The eMTA Collector's data display pages are not intended to be opened. Instead, the configuration should be performed either through a multiple set or via a Visio file.

The parameter **Data Offload Folder** contains the location of the slow offload files. The parameter **RCCV Data Offload Folder** contains the location of the IVR files.

## Usage

As described above, the eMTA Collector is not intended to be used separately. The resulting data should be consulted with the CPE Manager interface of the CPE Manager elements.

## Generated CSV files

The eMTA collector will generate tab-separated CSV files. For more information on the location of these files, refer to the Configuration chapter above.

### Slow offload structure

1\. MAC Address CM
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Chassis
7. FQDN 1.3.6.1.4.1.7432.1.1.1.4.0
8. End Point Count 1.3.6.1.4.1.7432.1.1.1.5.0
9. Dev Enabled 1.3.6.1.4.1.7432.1.1.1.6.0
10. DynamicOID1
11. DynamicOID2
12. DynamicOID3

### IVR offload structure

1\. MAC Address CM
2. Prov Phase 1.3.6.1.4.1.7432.1.1.2.16.0
3. End Point Status 1 1.3.6.1.4.1.7432.2.1.2.1.1.31.9 (Motorola) or 1.3.6.1.2.1.2.2.1.8.9 (Arris)
4. End Point Status 2 1.3.6.1.4.1.7432.2.1.2.1.1.31.10 (Motorola) or 1.3.6.1.2.1.2.2.1.8.10 (Arris)
5. Timestamp
6. SAPID
7. Another Operator

---
uid: Connector_help_Telenet_CM_Collector
---

# Telenet CM Collector

The **Telenet CM Collector** is part of the CPE setup, and works together with the **Telenet CPE Manager**, **Telenet STB Collector** and **Telenet eMTA Collector** connector. This connector is responsible for the polling of the CMs.

## About

This connector will poll all the CMs in two poll cycles:

- one fast poll cycle that will poll all CMs over a 15-minute period.
- one slow poll cycle that will poll all CMs over a 24-hour period.

In addition, there is another poll cycle that will poll the CMTS to request the US data of all the CMs over a 15-minute period. The polled data will be offloaded into CSV files and will be aggregated by the CPE Manager element. The CPE Manager element will provision the CM Collector with the CMs that need to be polled and their IP addresses. The CM Collector will send traps towards Adlex Nouveau.

## Installation and configuration

### Creation

This connector uses two Simple Network Management Protocol (SNMP) connections. The first SNMP connection is used to connect to the CM and the second one to connect to the CMTS.

The following input is required during element creation:

**SNMP Connection:**

- **IP address/host**: 127.0.0.1 (IP addresses will be dynamically filled in).
- **Device address**: Not needed.

**SNMP Settings:**

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: Not needed, because the connector will not perform sets.

Note: All polled CMs will share the same settings, and all polled CMTSs will share the same settings.

### Configuration of the offload parameters

The CM Collector's data display pages are not intended to be opened. Instead the configuration should be performed either through a multiple set or via a Visio file.

The parameter **Data Offload Folder** contains the location of the fast and slow offload files. To find the location where the HGW files are offloaded, go one level higher in the folder structure, and check the HGW directory. The parameter **RCCV Data Offload Folder** contains the location of the IVR files.

### Configuation of the threshold parameters

The threshold parameters are used during aggregation. If the parameter in the CPE manager is %CM With DS SNR \< T, then the DS SNR parameter is compared with the DS SNR Low Threshold. If the SNR is below the value in the configuration parameter, then the CM is taken into account.

The following parameters can be configured: **DS CR High Threshold, DS CS High Threshold**, **DS Level High Threshold**, **DS Level Low Threshold**, **DS SNR Low Threshold, DS UR High Threshold**, **US CR High Threshold**, **US CS High Threshold**, **US Level High Threshold**, **US Level Low Threshold**, **US SNR Low Threshold** and **US UR High Threshold**.

Other threshold parameters are used to determine whether or not to offload a value. With the **Minimum Variation DS SNR** and **Minimum Variation US SNR** parameters, you can make sure that there will only be a change of the parameter value if the difference between the polled value and the previous value is larger than the setting in this minimum variation parameter. The **CR Offload Threshold, CS Offload Threshold** and **UR Offload Threshold** parameter are used to ensure that there will always be an offload if the polled value is larger than or equal to the configured value.

### Configuration of the home gateway parameters

**Homestatistics Polling** enables the polling of the home gateway statistics. These statistics are polled once per day per modem. The client stats are polled between 7 p.m. and 9 p.m. in order to get the stats during the internet peak. With the parameter **Poll Clientstats 15 Min**, this polling interval can be changed, so that the client stats are then polled every 15 minutes. Polling of other statistics (channel loading, connected clients, client errors, connected power line, lan user, powerline network) is always spread over the entire day.

### Configuration of the Adlex Nouveau parameters

The CM Collector checks the current internet usage of the cable modem to determine the class to which it belongs. This info is then sent towards Adlex Nouveau in a trap. Adlex Nouveau will perform tests on modems that are not in use, in order to determine the maximum upload and download speed that can be reached. You can enable this functionality by setting the **Poll Classification** parameter to *Enabled*.

The **Trap Table** contains the IP addresses of the Adlex DMAs to which the traps can be sent. You can add IP addresses to this table by setting the parameter **Add Trap IP**. You can remove them again with the **Delete Trap IP** parameter.

The **Hardware Table** contains all the types of modems for which traps may be sent towards Adlex. You can add hardware types by setting the parameter **Add Hardware Type**, and remove them again with the **Delete Hardware Type** parameter.

The **Classification** table contains the definitions of all the classes. You can add rows to this table by clicking the **Add Class** button, and remove them again with the **Delete Class** parameter.

- **Product Type** is the internet product.
- **Flow Direction** determines if it is a classification for upstream or downstream.
- **Class** determines the class.
- **Byte Count Delta** contains the maximum delta between this polling and previous polling to suffice for this class. E.g. if byte count delta class 1 is 1,000,000 and byte count delta class 2 is 5,000,000, this means that if there is a delta of 3,000,000, this will be a class 2 modem at this moment.

## Usage

As described above, the CM Collector is not intended to be used separately. The resulting data should be consulted with the CPE Manager interface of the CPE Manager elements.

## Generated CSV files

The CM Collector will generate tab-separated CSV files. For more information on the location of these files, refer to the Configuration chapter above.

### Slow offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Chassis
7. HardwareVersion 1.3.6.1.2.1.1.1.0
8. ModelType 1.3.6.1.2.1.1.1.0
9. HardwareClass 1.3.6.1.2.1.1.1.0
10. DocsisType 1.3.6.1.2.1.10.127.1.1.5.0
11. SW Version 1.3.6.1.2.1.69.1.3.5.0
12. Last Change Datetime Calculated out of itf last change 1.3.6.1.2.1.2.2.1.9.1 and System Uptime 1.3.6.1.2.1.1.3.0
13. System Uptime 1.3.6.1.2.1.1.3.0
14. Downstream Maxtrafficrate 1.3.6.1.2.1.10.127.7.1.2.2.6, Docsis 2.0 from CMTS 1.3.6.1.2.1.10.127.7.1.2.2.6, Docsis 3.0 1.3.6.1.4.1.4491.2.1.21.1.2.1.6
15. Upstream MaxTrafficrate 1.3.6.1.2.1.10.127.7.1.2.2.6, Docsis 2.0 from CMTS 1.3.6.1.2.1.10.127.7.1.2.2.6, Docsis 3.0 1.3.6.1.4.1.4491.2.1.21.1.2.1.6
16. Physical Address \[Media\] 1.3.6.1.2.1.4.22.1.2
17. System Contact 1.3.6.1.2.1.1.4.0
18. Homegateway RouterMAC 1.3.6.1.2.1.2.2.1.6.1 (Motorola 2.0) or 1.3.6.1.2.1.2.2.1.6.20 (Motorola 3.0) or 1.3.6.1.2.1.2.2.1.6.20 (CBN 3.0) or 1.3.6.1.2.1.2.2.1.6.20 (UBEE 3.0)
19. Homegateway ChannelNumber 1.3.6.1.4.1.1166.1.19.51.1.5.1.2.0 (Motorola 2.0) or 1.3.6.1.4.1.1166.1.19.51.1.5.1.2.0 (Motorola 3.0) or 1.3.6.1.4.1.35604.1.19.51.1.5.1.2.0 (CBN 3.0) or 1.3.6.1.4.1.4684.54.1.1.4.1.32.1 (UBEE 3.0)
20. Homegateway ChannelWidth 1.3.6.1.4.1.1166.1.19.51.1.5.1.19.0 (Motorola 2.0) or 1.3.6.1.4.1.1166.1.19.51.1.5.1.19.0 (Motorola 3.0) or 1.3.6.1.4.1.35604.1.19.51.1.5.1.19.0 (CBN 3.0) or 1.3.6.1.4.1.4684.54.1.1.4.1.7.1 (UBEE 3.0)
21. DynamicOID1
22. DynamicOID2
23. DynamicOID3

### Fast offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Chassis
7. DynamicOID1
8. DynamicOID2
9. DynamicOID3

### Fast DS tuner offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Chassis
7. Tuner ID Instance of 1.3.6.1.2.1.10.127.1.1.1.1
8. DS Frequency 1.3.6.1.2.1.10.127.1.1.1.1.2
9. DS SNR 1.3.6.1.2.1.10.127.1.1.4.1.5
10. DS Rx Power 1.3.6.1.2.1.10.127.1.1.1.1.6
11. DS Microreflections 1.3.6.1.2.1.10.127.1.1.4.1.6
12. Modulation Type 1.3.6.1.2.1.10.127.1.1.1.1.4
13. CR Calculated out of Unerroreds 1.3.6.1.2.1.10.127.1.1.4.1.2, Correcteds 1.3.6.1.2.1.10.127.1.1.4.1.3, Uncorrectables 1.3.6.1.2.1.10.127.1.1.4.1.4
14. UR Calculated out of Unerroreds 1.3.6.1.2.1.10.127.1.1.4.1.2, Correcteds 1.3.6.1.2.1.10.127.1.1.4.1.3, Uncorrectables 1.3.6.1.2.1.10.127.1.1.4.1.4
15. DS Main Frequency 1.3.6.1.4.1.4491.2.1.20.1.9.1.3

### Fast US tuner offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Chassis
7. Tuner ID 1.3.6.1.2.1.10.127.1.1.2.1.1
8. US Frequency 1.3.6.1.2.1.10.127.1.1.2.1.2
9. US Channel Width 1.3.6.1.2.1.10.127.1.1.2.1.3
10. US Channel Modulation 1.3.6.1.2.1.10.127.1.1.2.1.15
11. US Tx 1.3.6.1.4.1.4491.2.1.20.1.2.1.1 or 1.3.6.1.2.1.10.127.1.2.2.1.3.2 (Docsis 2.0)
12. US SNR Polled from CMTS 1.3.6.1.4.1.4491.2.1.20.1.4.1.4
13. CR Polled from CMTS, calculated out of Unerroreds 1.3.6.1.4.1.4491.2.1.20.1.4.1.7, Correcteds 1.3.6.1.4.1.4491.2.1.20.1.4.1.8, Uncorrectables 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
14. UR Polled from CMTS, calculated out of Unerroreds 1.3.6.1.4.1.4491.2.1.20.1.4.1.7, Correcteds 1.3.6.1.4.1.4491.2.1.20.1.4.1.8, Uncorrectables 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
15. CS Calculated out of Status Resets 1.3.6.1.4.1.4491.2.1.20.1.1.1.3, Lost Syncs 1.3.6.1.4.1.4491.2.1.20.1.1.1.4, T1 timeouts 1.3.6.1.4.1.4491.2.1.20.1.1.1.9, T2 timeouts 1.3.6.1.4.1.4491.2.1.20.1.1.1.10, T3 timeouts 1.3.6.1.4.1.4491.2.1.20.1.2.1.2, T4 timeouts 1.3.6.1.4.1.4491.2.1.20.1.2.1.3, Rangings aborted 1.3.6.1.4.1.4491.2.1.20.1.2.1.4

### IVR offload structure

1\. MAC Address
2. State
3. Timestamp
4. SAPID
5. Another Operator

### Clientstats offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. 2.4 G or 5 G
5. BSS
6. MAC Address Client 1.3.6.1.4.1.35604.1.19.51.5.1.1.2 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.2 (5G)
7. RSSI 1.3.6.1.4.1.35604.1.19.51.5.1.1.5 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.5 (5G)
8. Tx 1.3.6.1.4.1.35604.1.19.51.5.1.1.6 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.6 (5G)
9. Rx 1.3.6.1.4.1.35604.1.19.51.5.1.1.7 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.7 (5G)
10. Mode 1.3.6.1.4.1.35604.1.19.51.5.1.1.8 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.8 (5G)
11. Authentication 1.3.6.1.4.1.35604.1.19.51.5.1.1.9 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.9 (5G)
12. Encryption 1.3.6.1.4.1.35604.1.19.51.5.1.1.10 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.2.1.10 (5G)
13. Another Operator

### Channeloading offload structure

1\. SAPID
2. Timestamp
3. Mac Address CM
4. 2.4 G or 5 G
5. Channel Nr
6. Channel Loading 1.3.6.1.4.1.35604.1.19.51.1.7.1.1.2 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.3.3.1.1.2 (5G)
7. Channel AP Count 1.3.6.1.4.1.35604.1.19.51.1.7.1.1.3 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.3.3.1.1.3 (5G)
8. Another Operator

### Connectedclients offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. 2.4 G or 5 G
5. BSS
6. Time Interval 1.3.6.1.4.1.35604.1.19.51.5.3.1.3 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.4.1.3 (5G)
7. Connected Clients 1.3.6.1.4.1.35604.1.19.51.5.3.1.4 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.4.1.4 (5G)
8. Max Simultaneous Clients 1.3.6.1.4.1.35604.1.19.51.5.3.1.5 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.4.1.5 (5G)
9. Max Simul Clients Timestamp 1.3.6.1.4.1.35604.1.19.51.5.3.1.6 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.4.1.6 (5G)
10. Rejected Clients 1.3.6.1.4.1.35604.1.19.51.5.3.1.7 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.4.1.7 (5G)
11. Another Operator

### Clienterrors offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. 2.4 G or 5 G
5. BSS
6. Error Type
7. Rejected Clients 1.3.6.1.4.1.35604.1.19.51.5.5.2.1.2 (2,4G) or 1.3.6.1.4.1.35604.1.19.51.5.6.2.1.2 (5G)
8. Another Operator

### Connectedpowerline offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. MAC Address Powerline 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.2
5. Location 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.3
6. Vendor 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.4
7. Firmware 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.5
8. Chipset 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.6
9. Tx 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.10
10. Rx 1.3.6.1.4.1.35604.1.19.62.1.1.6.1.11
11. Another Operator
12.n CPE Client 1.n Mac 1.3.6.1.4.1.35604.1.19.62.1.1.7.1.2

### Lanuser offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. MAC Address LAN 1.3.6.1.4.1.35604.1.19.201.1.1.1.3
5. LAN Interface 1.3.6.1.4.1.35604.1.19.201.1.1.1.4
6. Another Operator

### Powerlinenetwork offload structure

1\. SAPID
2. Timestamp
3. MAC Address CM
4. Polling Interval 1.3.6.1.4.1.35604.1.19.62.1.1.2.0
5. HPAV Network 1.3.6.1.4.1.35604.1.19.62.1.1.4.0
6. HPAV CCO 1.3.6.1.4.1.35604.1.19.62.1.1.5.0
7. Another Operator

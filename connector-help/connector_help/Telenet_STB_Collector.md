---
uid: Connector_help_Telenet_STB_Collector
---

# Telenet STB Collector

The **Telenet STB Collector** is part of the CPE setup, and works together with the **Telenet CPE Manager**, **Telenet eMTA Collector** and **Telenet CM Collector** connector. This connector is responsible for the polling of the STBs.

## About

This connector will poll all the STBs in two poll cycles:

- one fast poll cycle that will poll all STBs over a 15-minute period.
- one slow poll cycle that will poll all STBs over a 24-hour period.

The polled data will be offloaded into CSV files and will be aggregated by the CPE Manager element. The CPE Manager element will provision the STB Collector with the STBs that need to be polled and their IP addresses.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: 127.0.0.1 (IP addresses will be dynamically filled in).
- **Device address**: Not needed.

**SNMP Settings:**

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: Not needed, because the connector will not perform sets.

Note: All polled STBs will use the same settings.

### Configuration of the offload parameters

The STB Collector's data display pages are not intended to be opened. Instead, the configuration should be performed either through a multiple set or via a Visio file.

The parameter **Data Offload Folder** contains the location of the fast and slow offload files. The parameter **RCCV Data Offload Folder** contains the location of the IVR files.

### Configuration of the threshold parameters

The threshold parameters are used during aggregation. If the parameter in the CPE manager is %STB With DS SNR \< T, then the DS SNR parameter is compared with the DS SNR Low Threshold. If the SNR is below the value in the configuration parameter, then the STB is taken into account.

The following parameters can be configured: **STB DS BER High Threshold**, **STB DS SNR Low Threshold**, **STB Level High Threshold**, **STB Level Low Threshold**.

### Configuration of the hardware parameters

Different types of STBs will be polled. As such, some parameters need to be polled from another OID. Different groups with parameter OIDs have been defined in the connector, and it is possible to configure which poll group a certain type of STB should use, in the **STB HW Types** table.

Rows will be added automatically when the collector detects a new type, but you can also add rows to this table manually, with the **Add STB Entry** parameter. In that case, use the following format: *HWType;FWType;MatchType;GroupID*.

- **Matchtype** can be 0 (exact), 1 (anywhere), 2 (starts with) or 3 (ends with).
- **GroupID** can be 100 (initial group), 20 (multiple tuner) or 21 (multiple tuner and temp).
- **HW Type Name** contains the type of hardware.
- A firmware version can also be entered in **FW Version**. This value can be empty, a full version, or part of a version. **HW Type Match** determines what kind of value is filled in.
- With **HW Sequence**, you can define an order. If multiple rows match the wildcard, the row with the lowest sequence value is taken.
- **Group For Fast STB Type** and **Group For Slow STB Type** define the type of group that should be used during the fast and slow poll cycle.

You can remove a row again by entering the HW Type ID value in the **Delete STB Type Entry** parameter.

## Usage

As described above, the STB Collector is not intended to be used separately. The resulting data should be consulted with the CPE Manager interface of the CPE Manager elements.

## Generated CSV files

The STB Collector will generate tab-separated CSV files. For more information on the location of these files, refer to the Configuration section above.

### Slow offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. HW Version 1.3.6.1.4.1.23423.5.1.2.0
7. System Description 1.3.6.1.2.1.1.1.0
8. Navigator Build Version 1.3.6.1.4.1.23423.5.1.1.0
9. Firmware Version 1.3.6.1.4.1.23423.5.1.3.0
10. Loader HW Version 1.3.6.1.4.1.23423.5.5.1.1.0
11. Loader Version 1.3.6.1.4.1.23423.5.5.1.3.0
12. Download Time 1.3.6.1.4.1.23423.5.5.1.5.0
13. Loader SW Version 1.3.6.1.4.1.23423.5.5.1.4.0
14. CA Serial 1.3.6.1.4.1.23423.5.5.2.2.0 (smartcard) or caCasStbId 1.3.6.1.4.1.23423.5.5.7.5.0
15. CA Software Version 1.3.6.1.4.1.23423.5.5.2.3.0 (smartcard) or caSSMSoftVer 1.3.6.1.4.1.23423.5.5.7.3.0
16. CA SmartCard Serial 1.3.6.1.4.1.23423.5.5.2.4.0 (smartcard) or caCheckCode 1.3.6.1.4.1.23423.5.5.7.4.0
17. CA SmartCard DNSAP Version 1.3.6.1.4.1.23423.5.5.2.5.0 (smartcard) or caGlueSoftVer 1.3.6.1.4.1.23423.5.5.7.2.0
18. CA SmartCard Provider 1.3.6.1.4.1.23423.5.5.2.6.0
19. Uptime 1.3.6.1.2.1.1.3.0
20. Power Mode 1.3.6.1.4.1.23423.5.4.6.0
21. Low Power Standby Mode 1.3.6.1.4.1.23423.5.5.8.1.0
22. View Info 1.3.6.1.4.1.23423.10.2.0 or 1.3.6.1.4.1.23423.10.13.0
23. AD Build Version 1.3.6.1.4.1.23423.10.1.0
24. HDMI Info 1.3.6.1.4.1.23423.5.6.2.0
25. Temperature 1.3.6.1.4.1.14810.2.10.10.0
26. DynamicOID1
27. DynamicOID2
28. DynamicOID3

### Fast offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Had Restart
7. Power Mode 1.3.6.1.4.1.23423.5.4.6.0
8. Low Power Standby Mode 1.3.6.1.4.1.23423.5.5.8.1.0
9. View Info 1.3.6.1.4.1.23423.10.2.0 or 1.3.6.1.4.1.23423.10.13.0
10. Temperature 1.3.6.1.4.1.14810.2.10.10.0
11. DynamicOID1
12. DynamicOID2
13. DynamicOID3

### Fast tuner offload structure

1\. MAC Address 1.3.6.1.2.1.2.2.1.6.2
2. SAPID
3. Another Operator
4. Node
5. Timestamp
6. Tuner Number
7. Lock Status 1.3.6.1.4.1.23423.4.2.1.7
8. Frequency 1.3.6.1.4.1.23423.4.2.1.10
9. Level 1.3.6.1.4.1.23423.4.2.1.8
10. SNR 1.3.6.1.4.1.23423.4.2.1.5
11. BER 1.3.6.1.4.1.23423.4.2.1.6
12. Error Packets 1.3.6.1.4.1.23423.4.2.1.9

### IVR offload structure

1\. MAC Address
2. State
3. Timestamp
4. SAPID
5. Another Operator

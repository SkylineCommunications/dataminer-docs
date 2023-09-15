---
uid: Connector_help_Telenet_CPE_Manager
---

# Telenet CPE Manager

The **Telenet CPE Manager** is part of the CPE setup, and works together with the **Telenet CM Collector**, **Telenet STB Collector** and **Telenet eMTA Collector** connector. This connector is responsible for aggregating the data and providing the user interface.

## About

Different elements will be needed:

- One front-end element, responsible for provisioning and distribution of the syslog messages The CPE interface of this element allows the operator to see the data of all the headends.
- Multiple back-end elements, each responsible for one headend. This element will perform the aggregation of the data coming from the collector elements and the distribution of the online/offline traps from the CMTS. The CPE interface of this element allows the operator to only see the data of the headend that this element is responsible for.

### Version Info

| **Range**     | **Description**                                                                                                                                                                                                                                                                                                                                                                                              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 2.1.0.x \[Obsolete\] | Initial version after POC.                                                                                                                                                                                                                                                                                                                                                                                   | No                  | No                      |
| 2.2.0.x \[Obsolete\] | Based on 2.1.0.30. Relabel for next version.                                                                                                                                                                                                                                                                                                                                                                 | No                  | No                      |
| 2.2.1.x \[Obsolete\] | Based on 2.1.0.1. Store partition VOD/UAU and Channel file for STB provisioning.                                                                                                                                                                                                                                                                                                                             | No                  | No                      |
| 2.2.2.x \[Obsolete\] | Based on 2.2.1.3. Reporting of service changed on node and street level.                                                                                                                                                                                                                                                                                                                                     | No                  | No                      |
| 3.0.0.x \[Obsolete\] | Based on 2.2.2.0. Feature 58 forward node name to CPE collectors.                                                                                                                                                                                                                                                                                                                                            | No                  | No                      |
| 4.0.0.x \[Obsolete\] | Based on 3.0.0.1. Baseline changed.                                                                                                                                                                                                                                                                                                                                                                          | No                  | No                      |
| 5.0.0.x \[Obsolete\] | Based on 4.0.0.0 Added ratings and VoD check in provisioning                                                                                                                                                                                                                                                                                                                                                 | No                  | No                      |
| 6.0.0.x              | Complete redesign of the connector. In previous versions, the front end contained all topology information, including all CPE MAC addresses. This was too much for one element to handle. All tables and their provisioning needed to be changed so it was possible to shift the topology from front-end to back-end elements. Because of this redesign, this version is not compatible with previous versions. | No                  | No                      |
| 6.0.1.x              | Based on 6.0.0.18. The SFR cluster only contains cable modems. The connector had to be adapted so the STB and eMTA were removed from the tables, the provisioning, and the collector elements. Only parameters were removed, so switching to this version with an existing element using the 6.0.0.x range is possible if necessary.                                                                            | No                  | No                      |
| 6.0.2.x \[SLC Main\] | Based on 6.0.0.19. Removed VoD, BCQ and BO chains. Street level has been changed to Amplifier level and some KPIs have been removed from different levels.                                                                                                                                                                                                                                                   | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                                                    |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| x.x.x.x          | This connector listens to incoming syslog messages. These do not have a firmware version. The incoming traps are from the generic MIB and also do not rely on a firmware version. |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection to receive the syslog messages, and requires the following input during element creation:

**Serial Connection:**

- **IP address/host**: The IP of the DMA where the syslog messages are received.
- **IP Port**: The port that the connector will be listening to, by default *514*.
- **Bus address**: Not needed.

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive the traps coming from the CMTSs, and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: 127.0.0.1.
- **Device address**: Not needed.

**SNMP Settings:**

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: Not needed, because the connector will not perform sets.

### Configuration of the front-end offload parameters

The CPE Manager's data display pages are not intended to be opened. Instead the configuration should be performed either through a multiple set or via a Visio file.

The **CPE Manager Type** should be set to *Front-end* for the front-end element.

**Ratings Offload Folder** contains the location of the offload files with the view ratings. **PROV Source Folder** contains the location of the provisioning files.

### Configuration of the front-end aggregation parameters

**CPE Manager Chassis Aggregation**, **CPE Manager Street Aggregation** and **CPE Manager UAU Aggregation** should always be set to *Off* because the front end does not contain data for these levels.

**CPE Manager Aggregation State** can be set to *Active* to enable all aggregation. This parameter is automatically changed and set to *Hold* when provisioning is going on.

**CPE Manager Region Aggregation** can be set to *On* to enable the aggregation on Telenet level.

**Ratings Aggregation Timer State** can be set to *On* to enable the aggregation of the view ratings. The front-end manager will offload the view ratings every 15 minutes.

### Configuration of the front-end provisioning parameters

When the provisioning files are processed, new data files will be available that the back-end CPE manager elements can use to provision. These files will be retrieved through a shared folder. **Frontend Agent** contains the IP address, **Frontend Share Username**, **Frontend Share Password** and **Frontend Share Domain** contain the credentials of the shared folder.

You can start provisioning by setting the button **Start Provisioning** to *Now*. The back-end elements and collectors will also provision. With **Allow Error in Provisioning Files**, you can define whether provisioning should continue when there are errors in the provisioning files. You can check if the provisioning files contain errors without actually provisioning by setting **Start Provisioning Check** to *Now*.

PROV Result Table and PROV Logging are both tables that contain more info about the provisioning. You can clear these tables by setting the buttons **PROV Clear Result Table** and **PROV Clear Logging Table** to *Now.*

### Configuration of the back-end offload parameters

The **CPE Manager Type** should be set to *Back-end* for the back-end elements.

The parameter **Data Offload Folder** contains the location of the offload files with aggregation results.

To enable sending traps to Adlex Nouveau per chassis, set the parameter **Chassis AN Enabled** to *Enabled*.

### Configuration of the back-end aggregation parameters

**CPE Manager RegionAggregation** should always be set to *off* because the back end does not contain data for these levels.

To enable the aggregation that is executed every 5 minutes on different levels, set the parameters **CPE Manager UAU Aggregation**, **CPE Manager Chassis Aggregation** and **CPE Manager Street Aggregation** to *On*.

To enable the OOS aggregation that is executed every minute, set the parameter **BE OOS Aggregation Timer State** to *On*.

To enable the aggregation of the view ratings from the STB collectors every 5 minutes, set the **Ratings Aggregation Timer State** to *On*. These view ratings of all the back-end managers will then be merged by the front-end manager every 15 minutes.

To enable the offload of the node and the node frequency data every 15 minutes, set **Node-Offload Timer State** to *On*.

To enable the calculation of the OOS rate every 2 minutes, set the **Change Rate Timer State** to *On*. This calculation is done on the Street and Node level for the OOS of CM, eMTA and STB.

### Configuration of the back-end headend parameters

Fill in the headend name that the back-end manager will be responsible for in the parameter **Backend Responsible for Headend**.

Add the DMAID/EID of the collectors in the parameters **Add Backend CM Collector**, **Add Backend STB Collector** and **Add Backend EMTA Collector**. This will add rows to the tables **Backend CM Collector Table**, **Backend STB Collector Table** and **Backend EMTA Collector Table**. You can remove these rows again with the **Remove Backend Collector** column in the table.

During provisioning, the back-end manager will divide the number of CMTSs equally over the collector elements. The **Rearrange Collector Spreading** parameter should be used with extreme care, as this will reassign all MAC addresses, which could cause a huge load to remove and add everything to the collector elements. Once this configuration is done, the button **Send Config To Frontend** should be set to *Send*.

When the collector elements are not located on the same DMA as the back-end manager element, they must be able to retrieve the provisioning data through a share folder. You can configure the credentials for this share folder with the parameters **Backend Share Username**, **Backend Share Password** and **Backend Share Domain**.

The **Frontend Agent ID** parameter needs to be filled in with the DMAID/EID of the front-end manager element, so that the back-end manager knows to which front end to send its configuration.

### Configuration of the back-end alarm parameters

You can configure certain settings to influence the alarms.

With **Minimum \# CM Monitoring Threshold**, **Minimum \# MTA Monitoring Threshold**, **Minimum \# STB Monitoring Threshold** and **Minimum \# STB VoD Monitoring Threshold**, you can configure that there will only be an alarm if the parameter represents a minimum amount of CPEs.

With the **Correction Factor** parameters, you can adjust the normalization value per type of CPE and per level. This way, the normalization value can be adjusted throughout the day, because the load in the morning can be different (generate no alarm with this value) from the load in the evening (generate an alarm with this value).

### Configuration of the back-end normalization parameters

The baseline values used for normalization are based on the trending values of the past days. The way the normalization is calculated is defined in the **Baseline Lookup Table**. You can fill in this table by setting the **Baseline** button either to the value *Import* to load the data from a CSV file, or to the value *Add* to manually add a row. This CSV file must have the name *BaselineInfo.csv* and must be stored in the folder *C:\Skyline DataMiner\Protocols\Telenet CPE Manager\Production*.

For most of the calculations, the trending database is queried. Out of these values, the median value is taken as baseline value. The OOS type will take the data of yesterday, and the other types will take the data of the past week.

The rows in the CSV file need to have the following format (semicolon-separated):

1\. **PID**: PID of the parameter for which the normalization should be calculated.
2. **Table**: The table ID where the parameter is located.
3. **Nominal Column**: 1-based index where the nominal column is located.
4. **Total Column**: 1-based index where the total number of CPEs column is located (only used with OOS type).
5. **Multiplier/Default**: Default value when no trending found: Multiplier \* Total if OOS type or default value.
6. **Type**: Value 1 if OOS, otherwise other value.
7. **Description**: A description for this line.
8. **Pct Limit Jump**: Used in frequency calculations.
9. **Lower Limit**: Used in frequency calculations.
10. **Upper Limit**: Used in frequency calculations.

Because the frequency tables contain too much data in the database to be processed, a different approach is taken. Cumulative average values will be calculated during runtime without looking at the database. As long as the value is between "current baseline - Lower Limit" and "current baseline + Upper Limit", the average is calculated as the baseline value for the next day. If the value is outside these limits, then the baseline will increase or decrease once per day with a percentage of the upper or lower limit. Suppose, for example, that the baseline is 15, the Pct Limit Jump is 20 and the Upper Limit is 3. When the value is 19, then this is higher than 15+3, so the new baseline will increase with 20% of 3, or 0.6, which makes the new baseline value 15.6. If the next value is 20, this will have no effect on the baseline because there was already one jump this day. This way, we avoid that exceptional high values have too much influence on the average baseline calculation. When Upper Limit is not filled in, the same value as Lower Limit is taken.

## Usage

As described above, the data pages of the CPE Manager are not intended to be used.

If you open the card in Cube, the CPE interface will be displayed, with different chains/branches providing a different topology view.

If you fill in one of the filters (on the left side), the topology diagram view is displayed. If you click a KPI item in this diagram view, a pop-up window with parameters opens. In most of the cases, you can also click next to the diagram tab and display all the CMs/STBs or eMTAs that are under this topology level.

You can also right-click an alarm in Cube and select **Open** \>*CPE Manager element name*. This will open the CPE Manager with the filter already filled in at the right position, so the topology is immediately shown.

## Provisioning csv files

The front-end manager needs the following files and format (semicolon-separated) to be able to perform provisioning. It will analyze these files and will create new CSV files per headend, which the back-end manager can pick up and use for provisioning.

### hfc_cpe_iaa.csv

1\. Node
2. DS Group
3. US Group
4. House number
5. House letter
6. Letter box
7. Street
8. Postal
9. City
10. SAP ID
11. Another Operator
12. CM Mac
13. INT line
14. CM HW Type
15. eMTA MAC
16. eMTA lines
17. \# of STB
18. 18 + \# of STB; STB MAC

### GIGIntf.csv

1\. Chassis Name
2. Chassis Public IP
3. Chassis Private IP

### Channel.csv

1\. Headend Name
2. Packet
3. Program
4. Frequency
5. Port
6. Slot
7. Ring

### Network.csv

1\. Headend Name
2. Service
3. Service element
4. Chassis Name
5. RF Card Name
6. RF Port Name
7. DS/US RF Channel
8. DS/US RF Spectrum map
9. DS/US group
10. Node-ID1.Node-IDn

### UAUInfo.csv

1\. Node
2. Sub UAU
3. Main UAU
4. Packet

### vod_buildout.csv

1\. Headend Name
2. Node Name
3. Frequency
4. Vod RF Port
5. Vod RF Card
6. Vod Chassis Name
7. Vod SG Group

## Generated node offload csv files

In one file, the back-end manager will offload the node data as well as the frequency data. Depending on the type, there will be a different number of offloaded fields (tab-separated).

### Node data structure

1\. Timestamp
2. Node Name
3. \#CM OOS
4. \#eMTA OOS
5. \#STB OOS
6. %CM With DS CR \> T
7. %CM With DS UR \> T
8. %CM With US CR \> T
9. %CM With US UR \> T
10. %MTA Not In Pass
11. %MTA Not In Operational
12. %STB With Restart
13. %CM With US Level \> T
14. CM Avg RTT
15. {INFO_ID++} *(fixed)*

### Node CM DS frequency data structure

1\. {REF_ID++} *(fixed)
*2. {INFO_ID} *(fixed)
*3. 5 or 6 or 11 or 12
4. Frequency
5. Avg Level or Avg SNR or %CM With DS CR \> T or %CM With DS UR \> T

### Node CM US frequency data structure

1\. {REF_ID++} *(fixed)*
2. {INFO_ID} *(fixed)
*3. 9 or 10 or 13 or 14
4. Frequency
5. Avg Level or Avg SNR or %CM With US CR \> T or %CM With US UR \> T

### Node STB frequency data structure

1\. {REF_ID++} *(fixed)
*2. {INFO_ID} *(fixed)
*3. 1 or 2 or 3 or 7
4. Frequency
5. Avg Level or Avg SNR or Avg BER or %STB With Errors

## Generated view ratings offload CSV files

The front-end manager will offload the view ratings in two files. State offload will contain the number of STBs that are not watching a channel. View offload will contain the number of STBs that are watching a channel, as well as the exact channel and type. These files are semicolon-separated.

### State offload structure

1\. Timestamp
2. Region
3. \#STB Unknown State
4. \#STB Standby State
5. \#STB VOD State

### View offload structure

1\. Timestamp
2. Region
3. LIVE or TSB or REC
4. Channel
5. \#STB

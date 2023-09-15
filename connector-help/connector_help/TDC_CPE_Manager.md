---
uid: Connector_help_TDC_CPE_Manager
---

# TDC CPE Manager

The **TDC CPE Manager** is part of a CPE setup and is responsible for aggregating the data and providing the user interface. It works together with the following connectors:

- **CISCO CMTS**
- **Generic DOCSIS Cable Modem Collector**
- **Generic DOCSIS eMTA Collector**
- **Generic IP Resolve JSON**
- **Huawei MA5800-MA5633**
- **Skyline IAM Database**
- **Skyline IAM DB Provision**
- **TDC Humax STB Collector**
- **TDC OLT CM Collector**
- **Teleste Amplifier Collector**

## About

### Version Info

| **Range**                | **Key Features**                                        | **Based on** | **System Impact**             |
|--------------------------|---------------------------------------------------------|--------------|-------------------------------|
| 1.0.0.x **\[Obsolete\]** | Initial version                                         | \-           | \-                            |
| 3.0.1.x **\[Obsolete\]** | New CPE integration                                     | 3.0.0.4      | \-                            |
| 3.0.2.x **\[SLC Main\]** | Added CpeConfigHelper to get and set CPE configuration. | 3.0.1.25     | Increased minimum DMA version |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                     | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                                        | \-                      |
| 3.0.1.x   | No                  | Yes                     | \-                                        | \-                      |
| 3.0.2.x   | No                  | Yes                     | TDC OLT CM Collector connector (view tables) | \-                      |

## Installation and configuration

### Configuration of elements

Two types of elements are needed for this setup:

- A single front-end element (CPE FE), responsible for aggregating data at the top levels.
- Multiple back-end elements (CPE BE), each responsible for some OLT devices. These elements will perform the aggregation of the data coming from the collector elements.

### Configuration of parameters

The CPE Manager's Data Display pages are not intended to be opened. Instead, any configuration should be performed via a visual overview or multiple set.

### Configuration of offload

The following parameters can be set via **multiple set** in order to configure the offload mechanism to all related elements:

- **Offload CMC State**: Enables or disables the offload CMC data mechanism. Default value: *Disabled*.

- **Offload AMP State**: Enables or disables the offload AMP data mechanism. Default value: *Disabled*.

- **Offload CMC Cleanup State**: Enables or disables the file cleanup mechanism.
  - If this parameter is enabled, all files in the **Offload CMC Directory** that are older than the age defined in the **Offload** **File Age Threshold** parameter will be deleted.
  - This parameter is automatically enabled when the **Offload CMC State** is also enabled.
  - Default value: *Disabled*.

- **Offload CMC Directory**: The root directory where the offload files will be stored.

- The directory can be a shared folder. The credentials for the folder can be set using the **Offload Shared Folder Username** and **Offload Shared Folder Password** parameters.
  - A folder will be created per OLT with its name - the **OLT Name.**
  - Default value: *\\80.62.121.234\c\$\Skyline_Data\BE Manager Offload\\*

- **Offload AMP Directory**: The root directory where the offload files will be stored.
  - The directory can be a shared folder. The credentials for the folder can be set using the **Offload Shared Folder Username** and **Offload Shared Folder Password** parameters.
  - A folder will be created per OLT with its name - the **OLT Name.**
  - Default value: *\\80.62.121.234\c\$\Skyline_Data\AMP\\*

- **Offload File Age Threshold**: Determines for how long files are stored in the **Offload CMC Directory** before they are deleted to free up space.

- Range between *8 hours* and *1 year*, with 8-hour increments.
  - Default value: *2 weeks*

- **Force Offload / Offload To Disk**: Set this button to manually execute the offload of the files, regardless of both **Offload State (CMC/AMP)** values.

- **Debug Log Times**: Enables or disables extra logging related to the offload.

- If this parameter is enabled, upon a successful offload, the time and number of rows will be added in the element's log.

- **Offload Config String \[table name\]**: Contains all the column parameters that should be offloaded for the related table (specified in brackets).

- Multiple columns can be specified, with a comma (",") as separator.
  - The primary key will always be offloaded as the first column.
  - Information template column names are not supported.

The offload will not occur to front-end managers.

The offload files will always contain the primary key of the tables and a column with the **OLT Name** linked to each entry.

The files will be separated per OLT, inside the **Offload CMC Directory** and **Offload AMP Directory**. This means that each file will only contain the entries of a table related to a single OLT.

## Usage

If you open the card for this element in Cube, the CPE interface will be displayed, with different chains providing a different topology view.

If you fill in one of the filters (on the left), the topology diagram view is displayed. If you click a KPI item in this diagram view, a pop-up window with parameters opens.

### AMP Chain Export

The **BE Managers** have the possibility to export AMP Chain data to be further ingested by the **CM Collectors** (*TDC OLT CM Collector*). This data is useful to map the CM's channels to amplifiers.

If **CM AMP Chain Export State** is *enabled*, the **BE Manager** elements will create these files in the directory specified as the **CM AMP Chain Export Folder**, during the full provisioning. The result status is displayed by the **CM AMP Chain Export Status** parameter.

A file is created per **CM Collector** and contains 2 columns: the cable modem *MAC addresses* and the respective *AMP Chains*. The files can be identified by the *dmaId/elementId* of the **CM Collector** element responsible for ingesting them.

Only the newest files will be ingested by the **CM Collector**. Older files are moved to a backup folder (under the original one).

For maintenance purposes, files older than 7 days are deleted.

## IAM DB

The entire CPE setup is provisioned via a MySQL database called IAM.

There is also a fully automatic system to create new elements, assign properties and place the elements in the correct views based on the info from the IAM DB. The connector responsible for this is **Skyline IAM DB Provision**.

### Configuration of IAM Database

- DB Server Settings:

- DB Name: IAM
  - Server Name: IP address
  - DB Username
  - DB Password

## KPIs & KQIs

Key Performance Indicators (KPIs) are calculated on different levels. Below, you can find an overview of the KPIs per level.

### Generic KPIs

| **Description**               | **Information**                                                           |
|-------------------------------|---------------------------------------------------------------------------|
| \#CM                          | Total number of cable modems                                              |
| \#eMTA                        | Total number of eMTAs                                                     |
| \#STB                         | Total number of STBs                                                      |
| \#Address                     | Total number of addresses                                                 |
| \#3.0CM                       | Total number of cable modems per DOCSIS type (2.0, 3.0 or 3.1)            |
| \#Reg 3.0CM                   | Total number of registered cable modems per DOCSIS type (2.0, 3.0 or 3.1) |
| \#CM Reg / \#CM Dereg         | Total number of registered / deregistered cable modems \[%\]              |
| %CM Reg                       | Deregistered cable modems / (registered + deregistered cable modems)      |
| \#CM Resp (Ping)              | Total number of cable modems responding to ping command                   |
| \#CM Data Unavail on CMTS     | Total number of cable modems that are found in the OLT/CMTS               |
| %CM Data Avail on CMTS        | Available cable modems / (available + unavailable cable modems) \[%\]     |
| Avg CM Jitter                 | Average jitter of cable modems \[ms\]                                     |
| Avg CM Latency                | Average latency of cable modems \[ms\]                                    |
| Avg CM Packet Loss Rate       | Average packet loss ratio of the cable modems \[%\]                       |
| \#STB img Dist Low            | Total number of STBs breaching the low quality threshold                  |
| \#STB img Dist Very Low       | Total number of STBs breaching the very low quality threshold             |
| Current STB img Dist Low      | \#STB image disturbance low / \#STB                                       |
| Current STB img Dist Very Low | \#STB image disturbance very low / \#STB                                  |

### Generic Channel KPIs

| **Description** | **Information**                           |
|-----------------|-------------------------------------------|
| \#Act Ch        | Total number of active channels           |
| Bitrate         | Calculated bitrate \[Mbps\]               |
| Cap             | Capacity \[Mbps\]                         |
| Load            | Bitrate / capacity \[%\]                  |
| Ch Util         | Channel utilization measured by OLT \[%\] |

### KQIs

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Description</strong></td>
<td><strong>Information</strong></td>
</tr>
<tr class="even">
<td>%DM DOCSIS Avail</td>
<td><p>DM DOCSIS availability [%] = (Aggregated device availability / aggregated subscribers) * 100</p>
<p><strong>DM device availability</strong></p>
<p><em>Calculated by DataMiner: status if device is responding (i.e. not in timeout) and has operational status = ON.</em> <em>Operational status = ON if DataMiner element is in active state (i.e. not paused or stopped) and element severity &lt; Major.</em></p>
<p><strong>Aggregated</strong> <strong>device availability</strong> = DM device availability * (aggregated sum of device availability)</p>
<p><em>This parameter is the sum of device availability of all equipment available below the current topology level multiplied with the device availability of the current topology level.</em></p>
<p><em>Note that if no aggregated sum of device availability values is available (NA), the default value 1 is used.</em></p>
<p><strong>Aggregated subscribers</strong></p>
<p><em>This parameter is the sum of subscribers (cable modems)</em> <em>of all equipment available below the current topology level.</em></p></td>
</tr>
<tr class="odd">
<td>Exp %DM DOCSIS Avail /Network</td>
<td>Expected DM DOCSIS availability [%] = Smart baseline value of the %DM DOCSIS availability</td>
</tr>
<tr class="even">
<td>Avg BB Avail /Network</td>
<td>Broadband availability, average [%] = DM DOCSIS availability / expected DM DOCSIS availability</td>
</tr>
<tr class="odd">
<td>Worst 2% BB Avail /Network</td>
<td><p>Broadband availability, worst 2% [%] = Average for 2% customers with worst availability</p>
<p><em>Calculates the weighted average of the DM DOCSIS availability KQI for 2% of the total number of customers above the smart baseline.</em></p></td>
</tr>
<tr class="even">
<td>Avg Current TV Service Avail</td>
<td><p>Current TV service availability, average [%] = Weighted average availability from AMP up to CMC, OLT, region and TDC network.</p>
<p><strong><em>Base parameters</em></strong><em>:</em></p>
<p><em>Result of pre-configured measurements on the amplifier and comparison of the values with pre-defined output level thresholds. In case any of the thresholds is breached, the TV service is unavailable and the Current TV Service Unavailable parameter will be set.</em></p></td>
</tr>
<tr class="odd">
<td>Worst 2% Current TV Service Avail /Network</td>
<td><p>Current TV service availability, worst 2% [%]</p>
<p><em>Calculates the weighted average of the current TV service availability KQI for 2% of the total number of subscribers.</em></p></td>
</tr>
<tr class="even">
<td>Avg TV Service Avail</td>
<td><p>TV service availability, average [%] = Weighted average availability from AMP up to CMC, OLT, region and TDC network.</p>
<p><strong><em>Base parameters</em></strong><em>:</em></p>
<p><em>Result of pre-configured measurements on the amplifier and comparison of the values with pre-defined output level thresholds. In case any of the thresholds is breached, the TV service is unavailable and the TV Service Unavailable parameter will be set.</em></p></td>
</tr>
<tr class="odd">
<td>Worst 2% TV Service Avail /Network</td>
<td><p>TV service availability, worst 2% [%]</p>
<p><em>Calculates the weighted average of the TV service availability KQI for 2% of the total number of subscribers.</em></p></td>
</tr>
<tr class="even">
<td>Avg Worst 5% Current NQI /Network</td>
<td><p>Current network quality index, average worst 5% [%] = Average current NQI value of the worst 5% of segments (CMCs)</p>
<p><strong><em>Base parameters</em></strong><em>:</em></p>
<p><em>AMP Current NQI = The DataMiner amplifier collector compares the actual value with the expected value after each polling cycle. In case the expected value is breached, the current NQI reduction is set as 0%, otherwise it is set as 100%.</em></p></td>
</tr>
<tr class="odd">
<td>Avg Worst 5% NQI /Network</td>
<td><p>Network quality index, average worst 5% [%] = Average NQI value of the worst 5% of segments (CMCs)</p>
<p><em><strong>Base parameters</strong>:</em></p>
<p><em>AMP NQI = 100 - sum of reductions if no incident available for the current timestamp and amplifier.</em></p>
<p><em>NQI reduction (penalty score)</em></p>
<p><em>The DataMiner amplifier collector compares the actual value with the expected value after each polling cycle. In case the expected value is breached, the NQI reduction is increased with the reduction value, otherwise the value will not be changed.</em></p>
<p><em>Note that DataMiner <em>takes</em> the complete interval <em>into account</em> in case thresholds are breached.</em></p>
<p><em>At the beginning of each month, the NQI reduction will be reset.</em></p></td>
</tr>
<tr class="even">
<td>Max Cap Load of a Segment - BB</td>
<td><p>Maximum capacity load of a segment (broadband) [%] = (äSEG<sub>OK</sub> / total segments) * 100</p>
<p><em>SEG</em><sub><em>OK</em></sub> <em>= 1 if (max capacity of segment - weekly peak hour traffic rate per segment) ò higher class of service</em></p>
<p><em>Max capacity of segment: Configurable per segment.</em></p>
<p><em>Weekly peak: Average of daily peaks within the week, excluding the highest and lowest.</em></p>
<p><em>Daily peak: Maximum of the parameter Bitrate of a segment per day.</em></p>
<p><em>Higher class of service is configurable.</em></p></td>
</tr>
<tr class="odd">
<td>Max Cap Load of a Segment - VoD</td>
<td><p>Maximum capacity load of a segment (VoD) [%] = (äSEG<sub>OK</sub> / total segments) * 100</p>
<p><em>SEG</em><sub><em>OK</em></sub> <em>= 1 if (max capacity of segment - weekly peak hour traffic rate per segment) ò highest quality stream * 5</em></p>
<p><em>Max capacity of segment: Sum of bandwidth of all active EQAM channels linked to this segment.</em></p>
<p><em>Weekly peak: Average of daily peaks within the week, excluding the highest and lowest.</em></p>
<p><em>Daily peak: Maximum of the parameter Bitrate of a segment per day.</em></p>
<p><em>Highest quality stream: Currently approx. 8 Mbps, but the whole threshold (highest quality stream * 5) is configurable.</em></p></td>
</tr>
<tr class="even">
<td>Speed Success Rate</td>
<td><p>Speed success rate [%] = 100 - 100 * ( äC<sub>ij</sub> / än<sub>i</sub> )</p>
<p><em>For every customer, per type of segment (US/DS/QAM/OFDM), this evaluates:</em></p>
<p><em>C</em><sub><em>ij</em></sub> <em>= 1 if s</em><sub><em>i</em></sub><em>ò p</em><sub><em>j</em></sub> <em>,</em> <em>0 otherwise</em></p>
<p><em>s</em><sub><em>i</em></sub> <em>=</em> <em>Spare capacity of segment</em></p>
<p><em>Spare capacity = Max capacity - weekly peak load</em></p>
<p><em>p</em><sub><em>j</em></sub> <em>=</em> <em>Purchased speed per customer</em></p>
<p><em>än</em><sub><em>i</em></sub> <em>= Total number of broadband customers (QAM: #2.0CM + #3.0CM, OFDM: #3.1CM)</em></p></td>
</tr>
<tr class="odd">
<td>STB Img Dist Low /Network</td>
<td>Monthly calculation of total number of STBs with image disturbance low / total number of STBs</td>
</tr>
<tr class="even">
<td>STB Img Dist Very Low /Network</td>
<td>Monthly calculation of total number of STBs with image disturbance very low / total number of STBs</td>
</tr>
</tbody>
</table>

## Notes

As the data pages are not accessible, to provide an easier way to configure the settings, a custom visual overview can be used.

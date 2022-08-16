---
uid: EPM_6.1.0_I-DOCSIS
---

# EPM 6.1.0 I-DOCSIS

## New features

#### CCAP decoupled from Generic DOCSIS CM Collector connector \[ID_32627\]

To improve performance, the CCAP connection and all associated logic have been removed from the Generic DOCSIS CM Collector connector. Parameters that were filled in based on CCAP data have also been removed.

In addition, a number of new parameters have been introduced:

- *SNMP Interval* and *Virtual Interval*: These parameters allow you to configure the frequency at which the different SNMP and virtual are polled, respectively.
- Virtual Execution Time: This parameter shows how long it takes for a command to be executed on the virtual interface.

#### Improvements related to the decoupling of CCAPs from the CM collector \[ID_32630\]

To further support the removal of CCAPs from the CM collector, the CM Overview, CM US QAM, CM DS QAM, QAM US and QAM DS tables have been adjusted to reflect the fact that CCAPs have been decoupled from the CM collector.

In addition, in the Arris E6000 CCAP Platform, Casa Systems CCAP Platform, CISCO CBR-8 CCAP Platform and Huawei 5688-5800 CCAP Platform connectors, the following new parameters have been introduced:

- *SNMP Fast Interval*, *SNMP Slow Interval* and *Virtual Interval*: These parameters allow you to configure the frequency of fast and slow polling for the SNMP interface and the polling frequency for the virtual interface, respectively.
- Various interface status parameters, such as *SNMP Fast Status*, *SNMP Fast Last Update* and *SNMP Fast Execution Time*, which allow you to monitor how long it takes for the connector to process commands for each interface.

## Changes

### Enhancements

#### Multiple I-DOCSIS front-end enhancements \[ID_32629\]

Multiple enhancements have been implemented to the I-DOCSIS front end:

- A message buffer was implemented to better handle multiple requests from the CCAPs and to allow requests to be handled per element.
- To improve performance, InterApp calls are now used for communication between different DataMiner components.
- Multiple tables have been adjusted to reflect the fact that CCAP data has been decoupled from the CM collectors.
- Collector registration has been adjusted. Now the IDs for CCAP and CM collector are both placed in the table, in the format CCAPDataMinerID/CCAPElementID\|CMCollectorDataMinerID/CMCollectorElementID.

#### Multiple I-DOCSIS back-end enhancements \[ID_32631\]

Multiple enhancements have been implemented to the I-DOCSIS back end:

- A message buffer was implemented to better handle multiple requests from the CCAPs and to allow requests to be handled per element.
- To improve performance, InterApp calls are now used for communication between different DataMiner components.
- Multiple tables have been adjusted to reflect the fact that CCAP data has been decoupled from the CM collectors.
- Collector registration has been adjusted. Now the IDs for CCAP and CM collector are both placed in the table, in the format CCAPDataMinerID/CCAPElementID\|CMCollectorDataMinerID/CMCollectorElementID.
- A back-end registration table has been added, which makes it possible to map view tables.

#### New messaging Automation scripts using InterApp communication \[ID_32632\]

The existing EPM messaging logic using Correlation and Automation has been replaced with 3 new Automation scripts that use InterApp communication:

- *CcapToEpmFe*: This script is triggered by a CCAP and sends an InterApp message to the front-end element.
- *EpmFeToEpmBe*: This script is triggered by the front end and sends an InterApp message to the back-end element.
- *EpmBeToCcapPair*: This script is triggered by the back end and sends an InterApp message to one or more collector pairs (CCAP/CM collector).

### Fixes

\-

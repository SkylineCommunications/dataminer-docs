---
uid: GPON_KPI
---

# GPON KPI

These are the aggregations available by topology level defined in the GPON EPM solution. To see the parameters acquired for the ONT please see [ONT Operational Data](xref:GPON_ONT)

## KPIs & KQIs per Aggregation level

|KPI|Network|Market|Hub|OLT|Slot|Port|
|:--|:--:|:--:|:--:|:--:|:--:|:--:|
|**Number Market**|X||||||
|**Number Hub**|X|X|||||
|**Number OLT**|X|X|X||||
|**Number ONT**|X|X|X|X|X|X|
|**Number ONT Online**|X|X|X|X|X|X|
|**Number ONT Offline**|X|X|X|X|X|X|
|**Percentage ONT Online**|X|X|X|X|X|X|
|**Percentage ONT Offline**|X|X|X|X|X|X|
|**Number Bias Current OOS**|X|X|X|X|X|X|
|**Percentage Bias Current OOS**|X|X|X|X|X|X|
|**Number Supply Voltage OOS**|X|X|X|X|X|X|
|**Percentage Supply voltage OOS**|X|X|X|X|X|X|
|**Number Rx Power OOS**|X|X|X|X|X|X|
|**Percentage Rx Power OOS**|X|X|X|X|X|X|
|**Number Tx Power OOS**|X|X|X|X|X|X|
|**Percentage Tx Power OOS**|X|X|X|X|X|X|
|**Number Transceiver Temperature OOS**|X|X|X|X|X|X|
|**Percentage Transceiver Temperature OOS**|X|X|X|X|X|X|
|**Number ONT No Data State**|X|X|X|X|X|X|
|**Percentage No Data State**|X|X|X|X|X|X|

Each KPI calculates a value that can be used to generate alarms and make decisions according to the network behavioral pattern

- **Number Market**: Displays the markets that are contained by this network
- **Number Hub**: Displays the Hubs that are contained by this network
- **Number OLT**: Displays the OLTs that are contained by this network
- **Number ONT**: Displays the ONTs that are contained by this network
- **Number ONT Online**: Displays the ONTs that have the state Online
- **Number ONT Offline**: Displays the total ONT from which the system hasn't received a data package in the last 30 minutes (2 polling cycles with the default 15 minutes polling time)
- **Percentage ONT Online**: The calculated percentage of online ONTs
- **Percentage ONT Offline**: The calculated percentage of offline ONTs
- **Number Bias Current OOS**: Displays the ONTs that have the Bias Current OOS
- **Percentage Bias Current OOS**: The calculated percentage of ONT with Bias current OOS
- **Number Supply Voltage OOS**: Displays the ONTs that have the Bias Current OOS
- **Percentage Supply voltage OOS**: The calculated percentage of ONTs with Supply Voltage OOS
- **Number Rx Power OOS**: Displays the ONTs that have the Rx Power OOS
- **Percentage Rx Power OOS**: The calculated percentage of ONTs with Rx Power OOS
- **Number Tx Power OOS**: Displays the ONTs that have the Tx Power OOS
- **Percentage Tx Power OOS**: The calculated percentage of ONTs with Tx Power OOS
- **Number Transceiver Temperature OOS**: Displays the ONTs that have the Transceiver Temperature OOS
- **Percentage Transceiver Temperature OOS**: The calculated percentage of ONTs with the transceiver Temperature OOS
- **Number ONT No Data State**: Displays the total ONT from which the system hasn't received a data package since the last restart
- **Percentage No Data State**: The calculated percentage of ONTs with No data.

> [!IMPORTANT]
> For a detailed explanation of the OOS (Out of Spec) calculation and the different States that can be assigned to an ONT, see the [Thresholds page](xref:GPON_parameters_thresholds)

## System parameters

- _**Aggregation Level**_ **ID**: Internal unique identifier for this Network
- _**Aggregation Level**_ **Name [IDX]**: Human readable Unique identifier for the network. This value will be used in all alarms and references to this level.

---
uid: GPON_KPI
---

# Available parameters in EPM GPON

This page lists the parameters available per topology level defined in the GPON EPM solution, except the parameters acquired for the ONT. Those are listed under [EPM GPON ONT parameters](xref:GPON_ONT)

## KPIs & KQIs per aggregation level

|KPI|Network|Market|Hub|OLT|Slot|Port|
|:--|:--:|:--:|:--:|:--:|:--:|:--:|
|Number Market|X||||||
|Number Hub|X|X|||||
|Number OLT|X|X|X||||
|Number ONT|X|X|X|X|X|X|
|Number ONT Online|X|X|X|X|X|X|
|Number ONT Offline|X|X|X|X|X|X|
|Percentage ONT Online|X|X|X|X|X|X|
|Percentage ONT Offline|X|X|X|X|X|X|
|Number Bias Current OOS|X|X|X|X|X|X|
|Percentage Bias Current OOS|X|X|X|X|X|X|
|Number Supply Voltage OOS|X|X|X|X|X|X|
|Percentage Supply voltage OOS|X|X|X|X|X|X|
|Number Rx Power OOS|X|X|X|X|X|X|
|Percentage Rx Power OOS|X|X|X|X|X|X|
|Number Tx Power OOS|X|X|X|X|X|X|
|Percentage Tx Power OOS|X|X|X|X|X|X|
|Number Transceiver Temperature OOS|X|X|X|X|X|X|
|Percentage Transceiver Temperature OOS|X|X|X|X|X|X|
|Number ONT No Data State|X|X|X|X|X|X|
|Percentage No Data State|X|X|X|X|X|X|

For each KPI, a value is calculated that can be used to generate alarms and make decisions according to the network behavioral pattern.

- **Number Market**: The markets in this network.

- **Number Hub**: The hubs in this network.

- **Number OLT**: The OLTs in this network.

- **Number ONT**: The ONTs in this network.

- **Number ONT Online**: The ONTs that have the state *Online*.

- **Number ONT Offline**: The total number of ONTs from which the system has not received a data package in the last 30 minutes (i.e. 2 polling cycles with the default 15 minutes polling time).

- **Percentage ONT Online**: The calculated percentage of online ONTs.

- **Percentage ONT Offline**: The calculated percentage of offline ONTs.

- **Number Bias Current OOS**: The ONTs with Bias Current OOS.

- **Percentage Bias Current OOS**: The calculated percentage of ONTs with Bias current OOS.

- **Number Supply Voltage OOS**: The ONTs with Bias Current OOS.

- **Percentage Supply voltage OOS**: The calculated percentage of ONTs with Supply Voltage OOS.

- **Number Rx Power OOS**: The ONTs with Rx Power OOS.

- **Percentage Rx Power OOS**: The calculated percentage of ONTs with Rx Power OOS.

- **Number Tx Power OOS**: The ONTs with Tx Power OOS.

- **Percentage Tx Power OOS**: The calculated percentage of ONTs with Tx Power OOS.

- **Number Transceiver Temperature OOS**: The ONTs with Transceiver Temperature OOS.

- **Percentage Transceiver Temperature OOS**: The calculated percentage of ONTs with transceiver Temperature OOS.

- **Number ONT No Data State**: The total number of ONTs from which the system has not received a data package since the last restart.

- **Percentage No Data State**: The calculated percentage of ONTs for which no data has been received since the last restart.

> [!NOTE]
> For a detailed explanation of the OOS (Out of Spec) calculation and the different states that can be assigned to an ONT, see [EPM GPON parameter thresholds](xref:GPON_parameters_thresholds).

## System parameters

- ***Aggregation Level* ID**: Internal unique identifier for this network.

- ***Aggregation Level* Name [IDX]**: Human-readable unique identifier for the network. This value will be used in all alarms and references to this level.

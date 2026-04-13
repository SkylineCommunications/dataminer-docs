---
uid: ReservedIDsParameters
---

# Reserved parameter IDs

The DataMiner software reserves a parameter ID range for internal parameters. These parameter IDs cannot be used for user-defined parameters.

The following table gives an overview of the available parameter IDs that can be used by a protocol.

|Range|Owner|Minimum DMA version|Allowed|
|--- |--- |--- |--- |
|[[1, 63 999]](#1-63-999)|Protocol|1.0.0|Yes*|
|[[64 000, 64 299]](#64-000-64-299)|DataMiner/Protocol|1.0.0|Yes*|
|[[64 300, 69 999]](#64-300-69-999)|DataMiner|1.0.0|No|
|[[70 000, 79 999]](#70-000-79-999)|Protocol|7.5.6|Yes*|
|[[80 000, 99 999]](#80-000-99-999)|DataMiner/Protocol|9.0.4 (RN 13161)|Yes*|
|[[100 000, 999 999]](#100-000-999-999)|DataMiner|9.0.4 (RN 13161)|No|
|[[1 000 000, 9 989 999]](#1-000-000-9-989-999)|Protocol|9.0.4 (RN 13161)|Yes*|
|[[9 990 000 - 9 999 999]](#9-990-000---9-999-999)|DataMiner/Protocol|9.0.4 (RN 13161)|No|
|[[10 000 000, 10 999 999]](#10-000-000-10-999-999)|DataMiner (Data API)|10.4.0/10.4.1 (RN 37837)|Yes*|

\* See below for more restrictions that might be applicable.

## [1, 63 999]

In general, the range [1, 63 999] can be used in a protocol for parameters. However, for some specific types of protocols, additional restrictions apply:

|Protocol type|Restricted range|Owner|Description|
|--- |--- |--- |--- |
|Aggregation|[1-4 999]|DataMiner|Parameters in this range are used for communication between DataMiner and aggregation connectors.|
|Enhanced Service|[1, 999]|DataMiner|This range must only be used to communicate with DataMiner via predefined parameters.|
|SLA|[1, 2 999]|DataMiner|Parameters in this range are used for communication between DataMiner and SLA connectors.|
|Spectrum Analyzer|[50 000, 60 000]|DataMiner|This range is used by the SLSpectrum process to create dynamic parameters for spectrum monitoring results.|

## [64 000, 64 299]

Only to be used for communication with DataMiner modules. This range contains parameters that can be implemented in protocols to communicate with DataMiner (e.g., enhanced service protocols, spectrum analyzer protocols, ticketing protocols, etc.). A registry of assigned parameters is maintained. Only these specific parameter IDs can be implemented in the protocol.

## [64 300, 69 999]

> [!IMPORTANT]
> This parameter range cannot be used for user-defined parameters.

## [70 000, 79 999]

Only to be used in mediation/base protocols.

## [80 000, 99 999]

Only to be used for communication with DataMiner modules. This range contains parameters that can be implemented in protocols to communicate with DataMiner (e.g., enhanced service protocols, spectrum analyzer protocols, ticketing protocols, etc.). A registry of assigned parameters is maintained. Only these specific parameter IDs can be implemented in the protocol.<!-- RN 13161 -->

## [100 000, 999 999]

> [!IMPORTANT]
> This parameter range cannot be used for user-defined parameters.

## [1 000 000, 9 989 999]

Must only be used in case all parameters in the range [1, 63 999] are already in use.<!-- RN 13161 -->

## [9 990 000 - 9 999 999]

Parameters in this range are reserved for Flow Engineering (FLE) to track the as-is path of a flow.

See [Support FLE in connectors](https://github.com/SkylineCommunications/SLC-C-Example_FlowEngineering/blob/main/README.md) for more information.

## [10 000 000, 10 999 999]

Only to be used by Data API (introduced in DataMiner 10.4.0/10.4.1<!-- RN 37837 -->) to generate parameters.

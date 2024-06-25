---
uid: ID_range
---

# ID range

- The following table contains an overview of the available IDs that can be used by a protocol.

  | Range                 | Owner              | Minimum DMA version | Allowed       |
  |-------------------------|--------------------|---------------------|---------------|
  | \[1–63999\]             | Protocol           | 1.0.0               | Yes\*         |
  | \[64000–64299\]         | DataMiner/Protocol | 1.0.0               | Yes\*\*       |
  | \[64300–69999\]         | DataMiner          | 1.0.0               | No            |
  | \[70000–79999\]         | Protocol           | 7.5.6               | Yes\*\*\*     |
  | \[80000–99999\]         | DataMiner/Protocol | 9.0.4               | Yes\*\*\*\*   |
  | \[100000–999999\]       | DataMiner          | 9.0.4               | No            |
  | \[1 000 000–9 999 999\] | Protocol           | 9.0.4               | Yes\*\*\*\*\* |

  - \* In general, the range \[1, 63999\] can be used in a protocol for parameters. However, for some specific types of protocols, additional restrictions apply:

    | Protocol type                                | Restricted range | Owner     | Description                                                                                                |
    |------------------------------------------------|------------------|-----------|------------------------------------------------------------------------------------------------------------|
    | **Enhanced Service**  | \[1–999\]        | DataMiner | This range must only be used to communicate with DataMiner via predefined parameters.                      |
    | **Spectrum Analyzer** | \[50000–60000\]  | DataMiner | This range is used by the SLSpectrum process to create dynamic parameters for spectrum monitoring results. |
    | **SLA**               | \[1–2999\]       | DataMiner | Parameters in this range are used for communication between DataMiner and SLA protocols.                     |
    | **Aggregation**       | \[1–4999\]       | DataMiner | Parameters in this range are used for communication between DataMiner and aggregation protocols              |

  - \*\* Only to be used for communication with DataMiner modules. This range contains parameters that can be implemented in protocols to communicate with DataMiner (e.g. a spectrum analyzer). A registry of assigned parameters is maintained. Only these specific parameter IDs can be implemented in the protocol.

  - \*\*\* Only to be used in mediation/base protocols.

  - \*\*\*\* Only to be used for communication with DataMiner modules. This range contains parameters that can be implemented in protocols to communicate with DataMiner (e.g. enhanced service protocols, spectrum analyzer protocols, ticketing protocols, etc.). A registry of assigned parameters is maintained. Only these specific parameter IDs can be implemented in the protocol.

  - \*\*\*\*\* Must only be used in case all parameters in the range \[1, 63999\] are already in use.

- IDs from the range \[1 000 000-9 999 999\] must only be used in case all IDs from the range \[1-63999\] are already used.

- Protocol.ParameterGroups: IDs larger than or equal to 10000 must not be used for existing protocols or protocols intended to be used on DataMiner Agents prior to version 9.0.4.

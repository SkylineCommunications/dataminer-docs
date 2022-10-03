---
uid: FAQ_Bandwidth_data_acquisition
---

# How much bandwidth must be provided for data acquisition on data sources?

Bandwidth used for data acquisition on devices in the managed ecosystem is defined by a plethora of variables, including but not limited to the protocol used, physical interface and communication speed (e.g. IP, serial, etc.), acquisition techniques (e.g. polling versus unsolicited messages such as SNMP traps), polling speed, the amount of information contained in the specific device, and more.

It is therefore extremely difficult to provide the theoretical bandwidth or traffic load that will be used for acquisition in a complex heterogeneous ecosystem. The example below is based on a benchmark in a live environment and can be used as a guide, but with the necessary reservations.

**SNMP rule of thumb**: "10 SNMP Gets and their associated response in 1 second results in 1 kB of data transfer in that second."

Example: Polling 100 readings at a rate of once every 5 seconds would result in 2 kBps. If this is done on 100 devices in parallel, this will result in 200 kBps.

Note that DataMiner provides a plethora of techniques enabling operators to balance the acquisition traffic to their specific needs. This includes, for example, support of an unlimited number of time-based polling cycles within a single connector to differentiate between mission-critical and more trivial information, event-triggered polling cycles (including events such as a UI being accessed or a button being pushed in the UI), and more.

Devices in DataMiner also have a generic parameter that enables users to influence time perception. This way, the polling cycles defined on connector level can be accelerated or decelerated using manual, time-based, or event-based triggers, resulting in numerous applications.

> [!TIP]
> See also: [DataMiner metrics](xref:dataminer_metrics)

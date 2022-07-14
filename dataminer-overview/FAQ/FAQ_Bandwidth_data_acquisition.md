---
uid: FAQ_Bandwidth_data_acquisition
---

# How much bandwidth is to be foreseen for data acquisition on data sources?

Bandwidth used for the data acquisition on devices in the managed ecosystem is defined by a plethora of variables, including but not limited to protocol used, physical interface and communication speed (e.g. IP, serial, etc.), acquisition techniques (e.g. polling versus unsolicited messages such as SNMP traps), polling speed, the amount of information contained in the specific device, and more.

Therefore, it is extremely difficult to provide the theoretical bandwidth or traffic load that will be used for acquisition in a complex heterogeneous ecosystem. The example below is based on a benchmark in a live environment, and can be used as a guidance, but with the necessary reservations.

SNMP rule of thumb: “10 SNMP Gets and their associated response in 1 second results in 1kB of data transfer in that second”. Example: polling 100 readings at a rate of one time each 5 seconds would result in 2kBps. If this is done on 100 devices in parallel, this will result in 200kBps.
Note that DataMiner provides a plethora of techniques enabling operators to balance the acquisition traffic to their specific needs. This includes for example support of an unlimited number of time based polling cycles within a single driver to differentiate between mission critical and more trivial information, event triggered polling cycles (including events such as a UI being accessed, or a button being pushed on the UI), and more.
Devices in DataMiner also have a generic parameter, which enables the user to influence on its time perception. This way the polling cycles defined on a driver level can be accelerated or decelerated using manual, time or event based triggers, resulting in numerous applications.

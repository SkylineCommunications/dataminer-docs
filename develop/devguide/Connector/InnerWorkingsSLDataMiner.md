---
uid: InnerWorkingsSLDataMiner
---

# SLDataMiner

For each element, DataMiner introduces an additional thread (called "SetParameterThread") in the SLDataMiner process. The SetParameterThread thread handles external sets for the corresponding element. External sets can be a click on a button via the client, WFM, Visio, element connections, data distribution, etc. (i.e., all sets coming from outside the protocol). Keep in mind that when the protocol polls a device and gets a response, this is not considered an external set.

When an external set is triggered, the SetParameterThread will place this on a queue and handle the sets one by one. It will transfer the set to the SLProtocol process and trigger e.g., a QAction, but only when SLProtocol is not busy processing data from polling processes (i.e., SLPort or SLSNMPManager).

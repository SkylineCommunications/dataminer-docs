---
uid: Polling_xml
---

# Polling.xml

When a protocol is added to a DMA, the timer information in that protocol is checked to find out the approximate polling intervals of the different parameters. If information about polling intervals is found, it is copied in a file named *Polling.xml*, which is then placed in the same folder as the protocol.

The information in the *Polling.xml* file is made available to the DataMiner clients via ParameterInfo and is used to check the [hysteresis settings entered by users when configuring alarm templates](xref:Configuring_alarm_hysteresis).

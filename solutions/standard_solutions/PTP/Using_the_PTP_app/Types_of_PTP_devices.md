---
uid: Types_of_PTP_devices
---

# Types of PTP devices

The DataMiner PTP app currently supports the following types of devices:

| Devices | Description |
|--|--|
| Grandmaster clocks<br> ![](~/user-guide/images/PTP_GrandMaster.jpg) | Devices from which the time is retrieved.<br>Typically, a PTP environment will include multiple grandmaster clocks. The DataMiner PTP app allows you to identify them and tag one or more of them as preferred grandmasters. |
| Boundary clocks<br> ![](~/user-guide/images/PTP_BC.jpg) | Devices that take the time from a grandmaster clock, recreate it, and act as a clock.<br> Slave devices connected to a boundary clock will take their time from that boundary clock. Although they can be aware of the grandmaster clock, they will not communicate directly with it. |
| Transparent clocks<br> ![](~/user-guide/images/PTP_TC.jpg) | Devices that, unlike boundary clocks, do not act as a clock, but that simply pass the time they retrieve from either a boundary clock or a grandmaster clock.<br> Compared to non-PTP-aware switches, transparent clocks eliminate any time-varying delays. |
| Slave devices<br> ![](~/user-guide/images/PTP_Slave.jpg) | All endpoint devices that retrieve the time from a boundary clock, a transparent clock, or directly from a grandmaster clock.<br> Note: Slave devices that have been specially assigned to monitor and analyze the PTP signal they retrieve from a clock are called PTP analyzers. |

---
uid: Types_of_PTP_devices
description: "Explore the types of PTP devices supported by the PTP app: grandmaster clocks, boundary clocks, transparent clocks, and follower clocks."
---

# Types of PTP devices

The PTP app supports the following types of devices:

| Devices | Description |
|--|--|
| Grandmaster clocks<br> ![](~/dataminer/images/PTP_GrandMaster.jpg) | Devices from which the time is retrieved.<br>Typically, a PTP environment will include multiple grandmaster clocks. The PTP app allows you to identify them and tag one or more of them as preferred grandmasters. |
| Boundary clocks<br> ![](~/dataminer/images/PTP_BC.jpg) | Devices that take the time from a grandmaster clock, recreate it, and act as a clock.<br> Follower clocks connected to a boundary clock will take their time from that boundary clock. Although they can be aware of the grandmaster clock, they will not communicate directly with it. |
| Transparent clocks<br> ![](~/dataminer/images/PTP_TC.jpg) | Devices that, unlike boundary clocks, do not act as a clock, but that simply pass the time they retrieve from either a boundary clock or a grandmaster clock.<br> Compared to non-PTP-aware switches, transparent clocks eliminate any time-varying delays. |
| Follower clocks<br> ![](~/dataminer/images/PTP_Slave.jpg) | All endpoint devices that retrieve the time from a boundary clock, a transparent clock, or directly from a grandmaster clock.<br> Note: Follower clocks were formerly referred to as slave clocks in earlier versions of the PTP standard and solution. Follower clocks that have been specially assigned to monitor and analyze the PTP signal they retrieve from a clock are called PTP analyzers. |

## Supported vendor connectors

To see the list of supported vendor connectors and third-party devices integrated with the PTP solution, refer to [Skyline PTP Technical](https://docs.dataminer.services/connector/doc/Skyline_PTP_Technical.html). That page serves as the single source of truth for connector compatibility.

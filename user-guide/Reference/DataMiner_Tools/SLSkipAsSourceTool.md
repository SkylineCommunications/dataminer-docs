---
uid: SLSkipAsSourceTool
---

# SLSkipAsSourceTool

This tool can be of use when odd communication behavior is reported for a Failover DMA. If *SkipAsSource* has been enabled for all the network interfaces, it is not possible to do any network action at all originating from that machine, while the reason might not be obvious. This tool allows you to verify and fix the state of the SkipAsSource flags on IP addresses.

To run this tool:

1. Go to the folder `C:\Skyline DataMiner\Tools` on one of the DMAs in the Failover setup.

1. Run *SLSkipAsSourceTool.exe* as administrator. If you do not run the tool as administrator, it will not be possible to apply changes.

A window similar to the following example will be displayed:

![SLSkipAsSourceTool](~/user-guide/images/SLSkipAsSource-Failover-Expected.png)

On the right, the tool displays an output status window. On the left, it displays a tree view with all the network interfaces and the assigned IP addresses.

If *SkipAsSource* is enabled for an IP address, the check box in front of this address is selected. When a Failover DMA goes online, DataMiner should add the virtual IP address and mark all other IP addresses on the same interface with *SkipAsSource=true*, which means that only the check box for the virtual IP addresses should not be selected. For non-Failover Agents or offline Failover Agents, the check box should not be selected.

If you made sure to run the tool as administrator, you can manually change the selection of the check boxes and click *Apply Changes* to execute the changes.

For reference, this is the Failover setup (in DataMiner 10.1.0) corresponding with the example above:

![Failover config](~/user-guide/images/SLSkipAsSource-Failover-Config.png)

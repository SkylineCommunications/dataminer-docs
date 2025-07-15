---
uid: Creating_SNMP_simulations
---

# Creating SNMP simulations

To create an SNMP simulation file:

1. In the menu bar of the Skyline Device Simulator tool, select *Tools* > *Create SNMP Simulation file*.

   The following window will then open:

   ![](~/develop/images/QADS_CreateSNMP.png)
   <br>Create SNMP simulation file window

1. Specify the IP address and port of the device and configure the appropriate SNMP security settings.

1. Click the *Walk* button. The tool will start capturing all data from the device and keep it in memory.

1. Once the device data has been captured, click the *Create File* button to store the simulation file.

> [!NOTE]
> In the latest version of the tool, the *Direct Writes* option is available. When this option is selected, all data will be directly written to a file instead of being kept in memory. The advantage of this last approach is that it is more memory friendly. Also, if something were to go wrong, you would still have the data that was already written away. However, it is important to note that this feature does not yet completely work for SNMPv3. If *Direct Writes* is used, the engine ID attribute will still be empty. This will be fixed in a future version of the simulator.

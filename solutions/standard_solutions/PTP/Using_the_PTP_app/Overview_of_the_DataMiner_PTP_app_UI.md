---
uid: Overview_of_the_DataMiner_PTP_app_UI
---

# Overview of the DataMiner PTP app UI

In DataMiner Cube’s navigation pane, the DataMiner PTP app is available in the *Applications* section of the *Apps* tab.

From PTP version 1.1.0 onwards, the app consists of the following tabs:

- [The Summary tab](#the-summary-tab)

- [The Nodes tab](#the-nodes-tab)

- [The Topology tab](#the-topology-tab)

- [The Admin tab](#the-admin-tab)

- [The Help tab](#the-help-tab)

## The Summary tab

This tab shows an overall summary of the entire PTP stack.

The information in this tab is displayed in several separate blocks.

- The **PTP system summary** block in the top-left corner shows:

    - At the top, the number of PTP nodes that are reporting the current active grandmaster. Clicking the table icon next to this counter opens a window listing all nodes. The *Status* column in this overview, which allows alarm monitoring, provides more information about node synchronization status. This column can have the following values:

        - *Synced With Active Preferred Grandmaster*: The node is synchronized with the active grandmaster.

        - *Synced With Preferred Grandmaster*: The node is synchronized with the preferred grandmaster, but this grandmaster is not active at the moment.

        - *Synced With Non-Preferred Grandmaster*: The node is synchronized with a grandmaster that is not configured as a preferred grandmaster.

        - *Synced With Other Device*: The node is synchronized with another node, which is not a grandmaster. This situation is typically to be avoided.

        - *Unknown*: The Node is synchronized with a node that is not known by the PTP application.

    - From left to right, the total number of grandmaster, boundary clock, transparent clock, and slave devices in the configured PTP domain, or in the entire system if no domain is configured. For each of these, a summary icon displays the alarm color of the most severe PTP-related alarm on these devices. Clicking this icon opens a filtered alarm tab with the relevant alarms.

    - On the right, the currently active probe. This is the probe in charge of identifying the current active grandmaster clock in the PTP topology. A cogwheel icon next to the probe allows you to select a different probe.

- The **alarms** block in the top-right corner shows a summary of the PTP-related alarms (total, critical, major, minor and warning). If no domain is specified for the app, all alarms in the system are taken into account. Otherwise, only the alarms for the specified domain are taken into account. (See [The Admin tab](#the-admin-tab).)

    Clicking the list icon next to the total alarm count will open an alarm tab listing all these alarms. Clicking one of the four other alarm counters will open an alarm tab with these alarms filtered on the alarm severity in question.

- In the **grandmaster** block, you can find the following information:

    - On the left, a block with general information about the grandmaster:

        - The name of the current grandmaster clock (i.e. the grandmaster clock reported by the PTP probe). A toggle button next to the name allows you to switch between the element name in DataMiner or the alias.

        - The ID of the current grandmaster clock.

        - The role of the current grandmaster clock. This can be either *Potential* or *Preferred*. If it is *Preferred*, this means that this grandmaster should always be used to synchronize if possible.

        - The time of the DMA or the grandmaster clock. A toggle button allows you to switch between these. The DMA time is the local time of the DataMiner Agent, which is not equal to the PTP time, unless the DataMiner Agent is synchronized with the PTP domain.

    - Next to this, the *Settings GM* block is displayed. This shows the *Settings*, *BMCA* (Best Master Clock Algorithm), and *Message Rates* information related to the grandmaster. To the right of each column header, a list icon is available that opens a filtered alarm tab when clicked. On the right side of each column, aggregated alarm information is displayed if available. This information is aggregated either for all nodes in the configured PTP domain, or for the entire system if no domain is configured.

      > [!NOTE]
      >
      > - A number of parameters in this block are of specific note. For more information on these parameters, see [Special PTP parameters in the Summary tab](#special-ptp-parameters-in-the-summary-tab).
      > - The *Delay Response* parameter is retrieved from the PTP probe instead of the grandmaster. Clicking the probe icon will open a tool tip with this information.
      > - Prior to PTP 1.1.3 CU1, the aggregated alarm information is displayed in a separate *Nodes Summary* tab, which also contains the list icons to open filtered alarm tabs. Next to the tab names, an icon is available that can be clicked to switch between “play” and “stop” mode. In “play” mode, the app will automatically switch between the two tabs at regular intervals. In “stop” mode, only the last selected tab remains displayed.

    - In the top-right corner, the name of the current grandmaster interface is displayed. Click the cogwheel button next to this name to select a different interface.

- The **performance** block at the bottom of the tab allows you to track the overall PTP performance by monitoring PTP metrics that have trending activated (e.g. *Offset From Master* and *Mean Path Delay*). Below the trend graph, you can select any trended PTP parameter from any PTP node. If you want to display the trend graph in full-screen mode, click the full-screen icon in the top-right corner of this block.

### Special PTP parameters in the Summary tab

Below you can find more information on certain parameters in the *Summary* tab.

#### Clock Source

This parameter can have the following values:

- **Atomic Clock** (0x10): Any device that is based on atomic resonance for frequency and that has been calibrated against international standards for frequency and, if the PTP timescale is used, time, or a device directly connected to such a device.

- **GPS** (0x20): Any device synchronized with a satellite system that distributes time and frequency tied to international standards.

- **Terrestrial Radio** (0x30): Any device synchronized via any of the radio distribution systems that distribute time and frequency tied to international standards.

- **PTP** (0x40): Any device synchronized to a PTP-based source of time external to the domain.

- **NTP** (0x50): Any device synchronized via NTP or Simple Network Time Protocol (SNTP) to servers that distribute time and frequency tied to international standards.

- **Hand Set** (0x60): Any device of which the time has been set to a value within the claimed clock accuracy by means of a human interface based on observation of a source of time tied to international standards.

- **Other** (0x90): Any other source of time and/or frequency not covered by other values.

- **Internal Oscillator** (0xA0): Any device of which the frequency is not based on atomic resonance or calibrated against international standards for frequency, but instead based on a free-running oscillator with epoch determined in an arbitrary or unknown manner.

#### Clock Class

This parameter can have the following values:

- **6**: Indicates a clock that is synchronized to a primary reference time source. The timescale distributed is PTP. A class-6 clock can never be a slave to another clock in the domain.

- **7**: Indicates a clock that has previously been designated as a class-6 clock but that has lost the ability to synchronize to a primary reference time source and is in holdover mode and within holdover specifications. The timescale distributed is PTP. A class-7 clock can never be a slave to another clock in the domain.

- **13**: Indicates a clock that is synchronized to an application-specific source of time. The timescale distributed is ARB\*1. A class-13 clock can never be a slave to another clock in the domain.

- **14**: Indicates a clock that has previously been designated as a class-13 clock but that has lost the ability to synchronize to an application-specific source of time and is in holdover mode and within holdover specifications. The timescale distributed is ARB \*1. A class-14 clock can never be a slave to another clock in the domain.

- **52**: Degradation alternative A for a class-7 clock that is not within holdover specifications. A class-52 clock can never be a slave to another clock in the domain.

- **58**: Degradation alternative A for a class-14 clock that is not within holdover specifications. A class-58 clock can never be a slave to another clock in the domain.

- **187**: Degradation alternative B for a class-7 clock that is not within holdover specifications. A class-187 clock can be a slave to another clock in the domain.

- **193**: Degradation alternative B for a class-14 clock that is not within holdover specifications. A class-193 clock can be a slave to another clock in the domain.

- **248**: Default. This clock class is used if none of the other clock class definitions apply.

- **255**: Indicates a slave-only clock.

#### Clock Accuracy

This parameter can have the following values:

- **32** (0x20): Accurate to within 25 ns.

- **33** (0x21): Accurate to within 100 ns.

- **34** (0x22): Accurate to within 250 ns.

- **35** (0x23): Accurate to within 1 µs.

- **36** (0x24): Accurate to within 2.5 µs.

- **37** (0x25): Accurate to within 10 µs.

- **38** (0x26): Accurate to within 25 µs.

- **39** (0x27): Accurate to within 100 µs.

- **40** (0x28): Accurate within 250 µs.

- **41** (0x29): Accurate to within 1 ms.

- **41** (0x2A): Accurate to within 2.5 ms.

- **43** (0x2B): Accurate to within 10 ms.

- **44** (0x2C): Accurate to within 25 ms.

- **45** (0x2D): Accurate to within 100 ms.

- **46** (0x2E): Accurate to within 250 ms.

- **47** (0x2F): Accurate to within 1 s.

- **48** (0x30): Accurate to within 10 s.

- **49** (0x31): Accurate to \>10 s.

- **254** (0xFE): Unknown.

#### Clock Variance

Log-scaled statistic that represents the jitter and wander of the clock’s oscillator over a Sync message interval.

## The Nodes tab

This tab consists of the following subtabs:

- **Summary**: Lists all PTP nodes in the system, grouped by PTP role, with icons showing the element alarm state for each node. Clicking such an icon will open the element card for this device.

  For each device type, the nodes are sorted by severity.

- **Grandmasters**: Allows you to compare a number of parameters as well as the PTP interfaces of two grandmaster clocks.

    Above the element name or alias of each displayed grandmaster clock, three icons are available:

    - A toggle icon that allows you to switch between displaying the name of the grandmaster clock or its alias.

    - An icon that opens the element card for the grandmaster clock.

    - A cogwheel icon that allows you to select a different grandmaster clock to compare.

- **Boundary clocks**: Allows you to compare a number of parameters of two boundary clocks.

    Two random boundary clocks are selected by default. Above the name of each displayed boundary clock, two icons are available:

    - An icon that will open the element card of the boundary clock, which contains in-depth information on all PTP interfaces of the clock.

    - A cogwheel icon that allows you to select a different boundary clock to compare with.

- **Transparent clocks**: Lists all transparent clocks in the PTP topology.

- **Slave clocks**: Lists all slave clocks in the PTP topology, each with a number of PTP-related parameters.

- **Analyzers**: Allows you to compare a number of parameters of two PTP analyzers, i.e. slave devices that have been specially assigned to monitor and analyze the PTP signal they retrieve from a clock.

    Above the element name of each displayed PTP analyzer, two icons are available:

    - An icon that will open the element card of the PTP analyzer.

    - A cogwheel icon that can be used to select a different PTP analyzer to compare with.

## The Topology tab

This tab shows a graphical overview of how the different PTP nodes are connected, using DataMiner DCF. For each node, an icon is displayed indicating the type of node. For more information on these icons, see [Types of PTP devices](xref:Types_of_PTP_devices). Note that for the grandmaster clocks, the current active grandmaster (as detected by the PTP probe) is indicated by a small clock icon on the left.

Clicking the name of a PTP node opens the element card of the node. Clicking the icon marking the type of node opens the PTP alarm tab, showing the list of active PTP alarms associated with the node. Clicking a connection line will open a pop-up window, showing more information about the connection.

To change the position of the nodes, right-click anywhere on the topology overview, click *Arrange*, and drag and drop the nodes to the position where you want them. To exit arrange mode, click *Apply* in the top-right corner.

Alarm states are indicated as follows:

- The color of the border around the name of the PTP node indicates the overall alarm state of that node (taking into account all parameters of the node).

- The color of the icon marking the type of node indicates the PTP alarm state of that node (taking into account only the PTP-related parameters of the node).

- If a line connecting two nodes has an alarm color, this means that there is an alarm on the interface table (e.g. interface not connected).

> [!NOTE]
> New PTP nodes are automatically displayed in the top-left corner of the topology page.

## The Admin tab

This tab consists of three different sections:

- In the **Domain** section, you can click the *Set* button to specify a different PTP domain for this PTP app instance. There can be different instances of the app, each monitoring a different domain. When a PTP domain has been specified for an instance of the app, the corresponding element will be renamed to *DataMiner PTP - {domain name}*.

- In the **All Domains** section, all the configured PTP domains are listed. You can add more domains using the *Add* button.

- In the **Configuration** section, two buttons are available:

    - **Setup**: Launches the setup wizard again, allowing you to reconfigure the PTP topology. If there are several instances of the app, each with their own domain, the setup wizard will only allow you to reconfigure the PTP topology for the domain of the app instance you are currently using.

        > [!TIP]
        > See also:
        > [Installing the DataMiner PTP app](xref:Installing_the_DataMiner_PTP_app)

    - **Role assignment**: Launches the role assignment wizard, allowing you to change the roles that were assigned to the different PTP devices, or to assign roles to newly added devices.

## The Help tab

This tab contains links to this section of the DataMiner Help and to a page with more information about PTP in general. It also displays version information for the PTP app.

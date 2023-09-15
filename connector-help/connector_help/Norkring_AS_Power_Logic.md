---
uid: Connector_help_Norkring_AS_Power_Logic
---

# Norkring AS Power Logic

This is a virtual connector used to monitor the power station status in the Norkring AS DMA system.

## About

The **Norkring AS Power Logic** connector provides information on each different power station present in the Norkring network.

### Version Info

| **Range**     | **Description**              | **DCP Integration** | **Cassandra Compliant** |
|----------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version              | No                  | No                      |
| 2.0.0.x \[SLC Main\] | Version 2 station monitoring | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |
| 2.0.0.x          | 1.0                         |

## Installation and configuration

### General

#### Virtual connection

This connector uses a virtual connection and requires no input during element creation.

### Configuration for Range 1.0.0.x

After the element has been created, the **Protocol Info Table** should be filled in with the correct power logic information.

#### Regarding the power logic

If no Power Info elements are present on a station, this means that there are no power equipment or environment controllers at the station. This is usually the case at stations not owned by Norkring. In this case, power logic 1 needs to be used. Note that power logic 1 should only be applied if the **Station Status** is not *timeout*.

If there are Power Info elements available, the maximum severity of power logic 1 and 2 should be assigned.

**Logic 1**

- 230V AC:

- Major: If **230V AC Present** is *true* and all elements of the station using only 230V AC are in timeout.
  - OK: In any other situation.

- 48V DC UPS:

- Major: If **48V DC UPS Present** is *true* and all elements of the station using only 48V DC are in timeout.
  - OK: In any other situation.

- 230V AC UPS:

- Major: If **230V AC UPS Present** is *true* and all elements of the station using only 230V AC UPS are in timeout.
  - OK: In any other situation.

**Logic 2**

- 230V AC:

- Critical: If a power info element has an alarm of parameter type **Nettutfall** and there is no alarm of parameter type **Generator Running**.
  - Major: If a power info element has an alarm of parameter type **Nettfeil** or there is an alarm of parameter type **Powerloss 230V AC** or if a power info element has an alarm of parameter type **Nettutfall** and there is an alarm of parameter type **Generator Running**.
  - OK: In any other situation.

- 48V DC UPS:

- Critical: If there is an alarm of parameter type **Rectifier** with severity **Major**.
  - OK: In any other situation.

- 230V AC UPS:

- Critical: If there is an alarm of parameter type **Inverter** with severity **Major**.
  - Major: If there is an alarm of parameter type **Inverter** with severity **Minor**.
  - OK: In any other situation.

## Usage (Range 1.0.0.x)

It is possible to configure parameter types and power sources based on parameter IDs, table index filters and protocol names. The information for each station is updated every 15 minutes.

### Power Logic Page

This page contains a full-page table displaying the following information regarding each station present in the DMS:

- **Total Number of Elements**: Total count of network elements available on the station in the DataMiner System.
- **Total Number of Elements in Timeout**: Total count of network elements in timeout on the station in the DataMiner System.
- **Total Number of Power Info Elements**: Total count of network elements available on the station of which the protocol is configured in the Power Info Table as non-excluded (see below). A "Power Info Node" is a monitored network element that can provide power status information. There is a distinction between Power Info Nodes monitoring power directly and indirectly.
- **Total Number of 230V AC Elements**: Total count of network elements on the station in the DataMiner System using 230V AC power only.
- **Total Number of 48V DC Elements**: Total count of network elements on the station in the DataMiner System using 48V DC power only.
- **Total Number of 230V AC UPS Elements**: Total count of network elements on the station in the DataMiner System using 230V AC UPS power only.
- **Total Number of combined Power Elements**: Total count of network elements on the station in the DataMiner System using a combination of power sources.
- **Total Number of 230V AC Elements in Timeout:** Total count of network elements in timeout on the station in the DataMiner System using 230V AC power only.
- **Total Number of 48V DC Elements in Timeout**: Total count of network elements in timeout on the station in the DataMiner System using 48V DC power only.
- **Total Number of 230V AC UPS Elements in Timeout**: Total count of network elements in timeout on the station in the DataMiner System using 230V AC UPS power only.
- **Total Number of combined Power Elements in Timeout**: Total count of network elements in timeout on the station in the DataMiner System using a combination of power sources.
- **230V AC Present**: True if Total Number of 230V AC Elements \> 0
- **230V AC Status**: Summary status for 230V AC on the station, set by the DataMiner Power Logic element based on power logic calculations.
- **48V DC UPS Present**: True if Total Number of 48V DC UPS Elements \> 0
- **48V DC UPS Status**: Summary status for 48V DC UPS on the station, set by the DataMiner Power Logic element based on power logic calculations.
- **230V AC UPS Present**: True if Total Number of 230V AC UPS Elements \> 0
- **230V AC UPS Status**: Summary status for 230V AC UPS on the station, set by the DataMiner Power Logic element based on power logic calculations.
- **Station Status**: Summary status for the station: highest severity of the individual power sources.
- **Last Update Time**: Timestamp of last power status calculation.
- **Processing Time**: Duration in ms of the time it took for this view to retrieve the power logic information.
- **Number of Messages**: Number of messages sent to retrieve the power logic information.
- **Recalculate Power Status**: Triggers the recalculation of the power status for this station manually. This set will be made available on the Power Tab of the station view.

### Statistics Page

This page displays general information regarding the performance of this connector.

### Configuration Page

This page displays buttons to force the retrieval of the power info and the protocols for this DataMiner System. It also contains the configurable information on how to process the power logic.

The **Power Info Table** allows you to add, edit and remove power info configuration by adding protocols and linking parameters to a power status. Protocols can also be excluded from the power logic:

- **Protocol:** Protocol of the Power Info element.
- **Parameter:** Optionally, one or multiple parameters of which the alarm state should be taken into account (comma-separated, e.g. "*104,105*").
- **Filter:** Optionally, specify a mask in the Filter column to apply the calculation only to a filtered selection of available rows of the dynamic table.
- **Parameter Type:** Optionally, specify a parameter type used in the power logic, e.g. Nettutfall, Nettfeil, Generator Running and Rectifier.
- **Power Source:** Exclude a power source linked to the selection (*230VAC*, *48VDC UPS*, *230VAC UPS*, *Internal Battery* or *Exclude*).

## Usage (Range 2.0.0.x)

Indoor and outdoor temperature parameter sources from other elements on the current DMA can be configured. In order to detect any significant differences between the indoor temperature and the outdoor temperature, the Temperature Threshold, Delta Temperature and Occurrence Counter must be defined for these. The temperature values will be checked every 15 minutes.

### General Page

On this page, you can track the current **Indoor Temperature**, the **Outdoor Temperature** and the **Alarm Status**.

The Alarm Status can be:

- *Normal*: If the Indoor Temperature is less than the **Indoor Temperature Threshold** defined on the Configuration page.
- *Minor*: If the Indoor Temperature is greater than the threshold and the **Occurrence Counter** value is not reached at each temperature check, or the difference between the Indoor Temperature and the Outdoor Temperature is smaller than the **Delta Temperature** value.
- *Major*: If the Indoor Temperature is greater than the defined threshold, and the variance of temperature between Indoor and Outdoor is greater than the Delta Temperature, or the Occurrence Counter limit has been reached.

### Configuration Page

This page allows you to configure the Indoor **Temperature Threshold**, the **Delta Temperature** and the **Occurrence Counter** limit.

This page also lists the status of the selected elements and the indoor and outdoor source parameters to read the temperature from:

- **Indoor/Outdoor Element Status:** Status of the selected element.
- **Indoor/Outdoor Temperature Element**: Source element from which the temperature must be read.
- **Indoor/Outdoor Temperature Parameter**: The parameter with the temperature value.
- **Indoor/Outdoor Temperature Row Key**: In case the temperature value is in a table, the row key or display key for the temperature value.

**Indoor/Outdoor Element Status** can have the following values:

- *No Element Selected*: The option "No Element" is selected and element status and temperature parameters will no longer be updated.
- *Element Unavailable*: The selected element exists, but the current element is unable to communicate with it (the selected element is not in active state).
- *Indoor/Outdoor Parameter Missing*: The selected element exists, but no temperature parameter was selected.
- *Element No Longer Exists*: The selected element can no longer be found in the DMS.
- *Element Exists*: The selected element exists and the temperature parameter has been selected.

The **Refresh Elements** button will refresh the Indoor/Outdoor Temperature Element drop-down lists. If such lists are not updated and a non-existing parameter is selected, a dialog box will pop up, mentioning that the lists will be refreshed and the previously selected element will remain selected.

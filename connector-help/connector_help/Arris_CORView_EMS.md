---
uid: Connector_help_Arris_CORView_EMS
---

# Arris CORView EMS

The Arris CORView EMS is an **Element Manager**.

## About

This connector **only** supports **SNMP traps** for the Arris CORView EMS.

### Version Info

| **Range** | **Description**                                                                                 |
|------------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Initial version.                                                                                |
| 1.0.1.x          | Added "Down" or "Mismatch" to the DisplayKey when there is a Module Communication Status Event. |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

This connector has only one page.

### Alarms

This page displays the **Alarm** table, which is updated when SNMP traps are received. It contains a button to **Remove All** the alarms of the table. It also has a parameter to **Remove all Alarms by Interface** with a drop-down list showing the available choices.

If the connector receives an alarm/trap with severity "*Clear*", it will update the severity in the relevant row and then remove the alarm from the table.

The display key of the table is composed of the following data, which comes directly from the **trap bindings**:

- Location
- System/Device Name
- IP Address
- Chassis Name
- Chassis Address/Number
- Module Alias
- Slot Number
- Alarm Description
- Interface Number

The exact format for this is: Location: **Location**/NE: **Device Name** (**IP Address**)/Chassis: **Chassis Name** (**Chassis Number**)/Module: **Module Alias** (**Slot Number**)/ **Alarm Description**, **Interface Number**.

This page also contains the **CSV File Synchronization Configuration** page button. Via this button, you can enable or disable **Automatic Alarm File Synchronization**, change the (Automatic) **Polling Period** and the **File Path**, and execute a **Re-Sync**. The page button displays the **Supported MIB Object Traps Table**, listing the MIB Object **Names** and the corresponding **OIDs**, which will be used when synchronizing with the CSV file.

## Notes

About the **Alarm Description**, **Chassis Number**, **Slot Number** and **Interface Number**:

- The Alarm Description (or **heCommonLogText** in the device documentation) comes in the **6th position** in the trap bindings, together with a severity description. The latter is not needed, as it is possible to get the severity from the 4th position of the trap bindings (heCommonLogState).

- The heCommonLogOID (2nd position) has the **EntPhysicalIndex**, which indicates the **Chassis** and **Slot Number**. If an OID follows the EntPhysicalIndex, it is an **Interface Number** and will be concatenated with the **Alarm Description**.

- Note: It is possible that the EntPhysicalIndex is not always in the same logOID position. Up till now, it was detected between the 15th and 17th position. However, if there is a trap for which the EntPhysicalIndex is in another position in the logOID, the connector will need to be changed in order to process this.

- Trap Bindings:
  1.3.6.1.4.1.5591.1.11.2.1.1.1.2.3.1.2.11 (heCommonLogOID) = 1.3.6.1.4.1.5591.1.11.1.1.1.1.3.1.8.**101.1** - 101 is the EntPhysicalIndex and 1 is the interface number.
  1.3.6.1.4.1.5591.1.11.2.1.1.1.2.3.1.3.11 (heCommonLogValue) = 2
  1.3.6.1.4.1.5591.1.11.2.1.1.1.2.3.1.4.11 (heCommonLogState) = heCommonNominal (1) - Severity Level
  1.3.6.1.4.1.5591.1.11.2.1.1.1.2.3.1.5.11 (heCommonLogTime) = 2015/07/14 07:59:15.00 -07:00
  1.3.6.1.4.1.5591.1.11.2.1.1.1.2.3.1.6.11 (heCommonLogText) = **Transmitter Output Status Alarm**, Operational - Alarm Description

- The **Chassis Number** is obtained by dividing EntPhysicalIndex by 100, while the **Slot Number** is obtained by doing entPhysicalIndex MOD 100. The **Interface Number** is identified by the index that comes next to the entPhysicalIndex in the OID. For example, if the OID ends with ".103.2", the EntPhysicalIndex is 103, so the Interface Number is 2, the Chassis Number is 1 and the Slot Number is 3.

- If the **Transmitter** and **Receiver** alarms have an **OID Index following the EntPhysicalIndex**, that OID Index indicates the **Interface number**. If the description (trap binding) contains a Receiver or Transmitter, it **concatenates the Alarm Description** with **Rx** or **Tx** and the Interface Number. It is possible that a trap has the Interface Number but does not have the Receiver or Transmitter in the description. In this case, the Interface Number is added to the description without adding Rx/Tx.
  For example:

- A trap has the alarm description "Receiver RF Channel Status Alarm", with the last OID Indexes "101.2". The EntPhysicalIndex is 102 and the interface number is 2. As the trap has "Receiver" in the description, "Receiver RF Channel Status Alarm Rx2" will be added to the display key.
  - A trap has the description "Optical Amplifier Laser Bias Current Alarm" and interface number 1. "Optical Amplifier Laser Bias Current Alarm 1" will be added to the display key.

The **Supported MIB Object Traps Table** is only taken into consideration upon the CSV alarm file synchronization and not when a new trap is received.

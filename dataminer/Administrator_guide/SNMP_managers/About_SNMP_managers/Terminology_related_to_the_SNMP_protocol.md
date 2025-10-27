---
uid: Terminology_related_to_the_SNMP_protocol
---

# Terminology related to the SNMP protocol

When dealing with the SNMP protocol, you have to be familiar with the following terminology.

- **SNMP agent**: The part of an element that provides information about the element in the format described in the SNMP protocol.

- **SNMP manager**: A software application that manages SNMP agents.

- **SNMP MIB**: A text file that describes the format of the information provided by an element (e.g. temperature, output level, etc.).

  In a DataMiner System, you can find two kinds of MIBs: general MIBs and protocol-specific MIBs.

  - **General MIBs**: These describe the default SNMP notifications sent by the DataMiner System, and are shipped with every version of the DataMiner Agent software. On a DataMiner Agent, the general MIBs can be found in the folder `C:\Skyline DataMiner\MIBs\`.

    > [!NOTE]
    > For detailed information about the contents of the default DataMiner notifications, see [DataMiner SNMP notification definition](xref:Default_DataMiner_notification).

  - **Protocol-specific MIBs**: These are MIBs for specific DataMiner protocols that are not supplied by default. They have to be generated manually.

    > [!TIP]
    > See also: [Generating a protocol-specific MIB](xref:Advanced_protocol_functionality#generating-a-protocol-specific-mib)

- **SNMP Get**: An SNMP message sent by an SNMP manager to an SNMP agent requesting the latter to return the current value of a particular element parameter.

- **SNMP Set**: An SNMP message sent by an SNMP manager to an SNMP agent ordering the latter to update the value of a particular element parameter.

- **SNMP trap**: An SNMP notification sent by an SNMP agent to an SNMP manager informing the latter that an alarm event occurred on a particular element.

  > [!NOTE]
  >
  > - SNMP traps are unsolicited UDP messages. They are forwarded by an SNMP agent to an SNMP manager without establishing any connection with that SNMP manager. There is no verification whatsoever. If, for some reason, an SNMP trap gets lost, neither the SNMP manager nor the SNMP agent will be aware of it.
  > - When a DataMiner Agent in a cluster receives an SNMP trap (or an inform message), this trap will be distributed to other DataMiner Agents in the cluster that have at least one element that is interested in the trap.

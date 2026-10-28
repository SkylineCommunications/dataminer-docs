---
uid: Packet_configuration_and_bindings
description: "Use packet configuration and bindings to set an IP address and port for any SNMP version, then review fields and OIDs with types and values."
---

# Packet configuration and bindings

![](~/develop/images/QADS_TrapSenderPacketConfig.png)
<br>Trap Sender packet configuration and bindings

When a packet is selected in the pane on the left, the middle section of the SNMP Trap Sender window displays the following two sections:

- *Packet configuration*:

  - The *IP Address* and *Port* fields are applicable for all SNMP versions

  - The other fields are different for each SNMP version, i.e., they are SNMP version-specific. If you select an SNMPv1 trap, you will see different fields than when you select an SNMPv3 trap.

- *Bindings*: Regardless of the SNMP version, this section displays a list of OIDs, with their type and value.

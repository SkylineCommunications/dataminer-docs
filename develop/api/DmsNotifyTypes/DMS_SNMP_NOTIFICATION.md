---
uid: DMS_SNMP_NOTIFICATION
---

# DMS_SNMP_NOTIFICATION (73)

> [!WARNING]
>
> - The use of DMS Notify types is deprecated. Use types from [Class library](xref:ClassLibraryIntroduction) instead.

Sends an SNMP trap or inform message.

## Parameters

- type (int): Specifies the notify type. To perform a DMS_SNMP_NOTIFICATION call, set this to 73.
- subType (int): Specifies the sub type. Not applicable for DMS_SNMP_NOTIFICATION calls. Set this to 0.
- messageType (int): Defines the type of message that will be sent:
  - 21 = SNMPv1 Trap
  - 22 = SNMPv2 Trap
  - 23 = SNMP Inform
- generalInfo (object[]): General information about the message. The content depends on the message type:
  
    |  |SNMPv1 Trap  |SNMPv2 Trap  |SNMP Inform  |
    |---------|---------|---------|---------|
    |generalInfo[0]     |(int) Element ID         |(int) Element ID         |(int) Element ID         |
    |generalInfo[1]     |(int) parameter ID (obsolete)         |(int) parameter ID (obsolete)         |(int) parameter ID (obsolete)         |
    |generalInfo[2]     |(string) destination address         |(string) destination address         |(string) destination address         |
    |generalInfo[3]     |(string) community (obsolete)         |(string) community (obsolete)         |(string) community (obsolete)         |
    |generalInfo[4]     |(string) enterprise OID (obsolete)         |(string) enterprise OID (obsolete)         |(string) enterprise OID (obsolete)         |
    |generalInfo[5]     |(string) source address         |(int) destination port Optional, default 162         |(int) (N)ACK element ID*** Optional, default -1         |
    |generalInfo[6]     |(int) destination port Optional, default 162         |(int) codepage* Optional, default 0         |(int) ACK parameter ID**** Optional, default -1         |
    |generalInfo[7]     |(int) codepage* Optional, default 0         |(bool) sys up binding** Optional, default false         |(int) NACK parameter ID**** Optional, default -1         |
    |generalInfo[8]     |-         |(string) trap OID binding Optional, default empty         |(int) (N)ACK ID***** Optional, default -1         |
    |generalInfo[9]     |-         |(int) timeout time (ms) Optional, default 30000         |(int) timeout time (ms) Optional, default 30000         |
    |generalInfo[10]     |-         |(int) retries Optional, default 20         |(int) retries Optional, default 20         |
    |generalInfo[11]     |-         |-         |(int) destination port Optional, default 162         |
    |generalInfo[12]     |-         |-         |(int) codepage* Optional, default 0         |
    |generalInfo[13]     |-         |-         |(bool) sys up binding** Optional, default false         |

   \* codepage: how to decode the strings.
    - 0: ANSI code page
    - 1: OEM code page
    - 2: MAC code page
    - 3: Current thread's ANSI code page
    - 42: SYMBOL translations
    - 65000: UTF-7 translation
    - 65001: UTF-8 translation

    ** sys up binding: When set to true, this indicates that the first binding is the system up time tick binding (type: TimeTicks).

    *** (N)ACK element ID: ID of the element that contains the parameter to which the (N)ACK data will be set.

    ****: (N)ACK parameter ID: ID of the parameter that will be used to hold the (N)ACK data.

    *****: Integer value containing a unique message ID (create a static variable in the QAction and let it increase each time a message is sent).

- bindings (object[]): An array containing the bindings that are included in the message. For each binding, include an array as follows:
  - binding[0] (string): OID
  - binding[1] (string): value
  - binding[2] (int or string): SNMP type. The type can be one of the following strings:
    - Integer
    - Integer32
    - OctetString
    - OctetStringHex
    - OctetStringASCII
    - OID
    - IpAddress
    - Counter32
    - Counter64
    - Gauge32
    - TimeTicks
    - Opaque
    - NSAPAddress
    - UInteger32
    - NULL

## Remarks

- When sending a message to localhost, provide a random community string.
- If you try to send an SNMPv2 trap while using a general object of size 9, no traps will be sent. If you try to send an SNMP Inform message while using a general object of size 5, the SNMP Inform will be sent, but DataMiner will not be able to process the ACK message that is returned, so the inform message will be repeated every 30 seconds for 10 minutes (20 times in total).
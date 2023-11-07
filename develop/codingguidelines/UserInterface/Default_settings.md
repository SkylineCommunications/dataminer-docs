---
uid: Default_settings
---

# Default settings

- The port settings must contain as many default settings as possible and must be as strict as possible. This also includes disabling options that are not applicable (e.g. disabling irrelevant options: in case of a HTTP driver, we should not be able to select type of port as "Serial").

    The default bus address "bypassProxy" must be used in drivers of type HTTP.

The recommended port support per type

    - SNMP: UDP only
    - SNMPv1: UDP only
    - SNMPv2: UDP only
    - Serial: TCP, UDP and Serial
    - Serial single: TCP, UDP and Serial
    - Smart-Serial: TCP and UDP
    - Smart-Serial single: TCP and UDP
    - HTTP: TCP only
    - GPIB: TCP only
    - Virtual: None
    - OPC: TCP only
    - SLA: None

    Make sure to disable any of the ports that aren't possible for this specific protocol.

    For HTTP for example:
       <PortSettings>
              <BusAddress>
                     <DefaultValue>ByPassProxy</DefaultValue>
              </BusAddress>
              <IPport>
                     <DefaultValue>80</DefaultValue>
              </IPport>
              <PortTypeUDP>
                     <Disabled>true</Disabled>
              </PortTypeUDP>
              <PortTypeSerial>
                     <Disabled>true</Disabled>
              </PortTypeSerial>
       </PortSettings>

    Some Ports are disabled within the client already.
    The ones we still need to check and add are:
    Serial: When using SSH: "Serial" and "UDP" need to be disabled in the protocol.
    Smart-serial: "Serial" needs to be disabled in the protocol.
    Smart-serial single:  "Serial" needs to be disabled in the protocol.
    HTTP: "Serial" and "UDP" need to be disabled in the protocol.

---
uid: ConnectionsSnmp
---

# SNMP

The Simple Network Management Protocol (SNMP) is a widely used application layer protocol for managing network elements.

The SNMP architectural model consists of network elements (e.g., routers, hosts, servers, etc.) and network management stations (NMS), e.g., a DataMiner Agent, that monitor and control the network elements. The SNMP protocol is used to communicate between the management stations and the network elements. The SNMP protocol is part of the Internet Standard Management Framework (which is also sometimes referred to as SNMP).

The Internet Standard Management Framework consists of the following components:

- Structure of Management Information (SMI): data definition language describing how managed objects present in the Management Information Base (MIB) are defined.
- Management Information Base (MIB): Managed objects are accessed via a virtual information store, the so-called Management Information Base (MIB).
- Simple Network Management Protocol (SNMP): Defines the protocol used to manage the objects contained in the MIB.
- Security and administration.

The NMS manages a network element by communicating with the network element using the SNMP protocol. The network element runs an SNMP Agent allowing to inspect (get) and alter (set) objects exposed by the MIB.

The management data that an SNMP Agent exposes (often referred to as managed objects or variables) are described by the Management Information Base (MIB). The MIB is a hierarchical structure containing object identifiers (OIDs), where each OID identifies a variable.

Three versions of SNMP are currently defined: SNMPv1, SNMPv2 and SNMPv3. DataMiner supports all three versions.

The following illustration displays a conceptual overview of a DataMiner Agent hosting an element running a protocol that communicates with a network element via SNMP.

```mermaid
flowchart LR
    subgraph dataminer["DataMiner Agent"]
        direction TB
            subgraph element["Element A"]
                protocol["Runs protocol X vA.B.C.D"]
            end
    end
    subgraph device["Device A"]
        subgraph snmpagent[SNMP Agent]
        end
    end
    element["Element A"]-->snmpagent[SNMP Agent]
    style dataminer fill:#005880,stroke:#333,color:#fff,stroke-width:1px
    style device fill:#eee,stroke:#333,stroke-width:1px,color:#000
    style element fill:#eee,stroke:#333,stroke-width:1px,color:#000
    style protocol fill:#eee,stroke:#333,stroke-width:0px,color:#000
```

Typically, a protocol with an SNMP connection contains logic to:

- Poll the device (i.e., inspect managed objects exposed by the MIB) by sending SNMP Get messages (e.g., GetNext, GetBulk).
- Change parameter values on the device by sending SNMP Set messages.
- Receive unsolicited SNMP traps from the device.

DataMiner runs three processes with the name *SLSNMPManager* (one for each version of SNMP), which control all communication from and to devices running SNMP agents.

## See also

- [Slow poll mode ping group](xref:ConnectionsPingGroup)

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.SNMP](xref:Protocol.Params.Param.SNMP)
- [Protocol.Params.Param.SNMP.OID](xref:Protocol.Params.Param.SNMP.OID)
- [Protocol.Params.Param.SNMP.TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)
- [Protocol.Groups.Group.Content@multipleGet](xref:Protocol.Groups.Group.Content-multipleGet)
- [Protocol.Params.Param@options](xref:Protocol.Params.Param-options)
- [Protocol.Params.Param@snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet)

DataMiner Class Library:

- <xref:DMS_SNMP_NOTIFICATION>
- <xref:NT_GET_BITRATE_DATA>

> [!NOTE]
> For more information related to SNMP, refer to:
>
> - <http://www.snmp.com/protocol/snmp_rfcs.shtml>
> - <https://www.rfc-editor.org/search/rfc_search_detail.php?title=SNMP&page=All>
> - <http://www.snmplink.org> 
> - <http://en.wikipedia.org/wiki/Simple_Network_Management_Protocol>

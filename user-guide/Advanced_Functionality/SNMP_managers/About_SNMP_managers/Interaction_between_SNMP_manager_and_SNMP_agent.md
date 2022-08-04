---
uid: Interaction_between_SNMP_manager_and_SNMP_agent
---

# Interaction between SNMP manager and SNMP agent

The SLSNMPManager and SLSNMPAgent processes allow a DataMiner Agent to exchange SNMP messages with devices and third-party SNMP managers.

> [!TIP]
> See also:
>
> - [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports)
> - [Configuring SNMP agent community strings](xref:Configuring_SNMP_agent_community_strings)

## Graphical representation

![](~/user-guide/images/SNMPafter903.jpg)

## SLSNMPManager

The SLSNMPManager process communicates with devices acting as SNMP agents.

- It polls devices by sending SNMP Get messages.

- It sets parameter values on devices by sending SNMP Set messages.

- It uses SNMP++ to receive notifications from devices.

The UDP ports to be used are set as follows:

- The port on which the device will listen for Get and Set messages (i.e. the “polling port”) has to be specified during the creation of the element associated with that device. Default: 161

- By default, only the SNMPv3 process will receive notifications, on port 162. It will then forward them to the SNMPv1 and SNMPv2 processes when necessary:

  - The SNMPv1 process will receive all notifications (SNMPv1, SNMPv2 and SNMPv3).

  - The SNMPv2 process will receive the SNMPv2 and SNMPv3 notifications.

  To receive the notifications of any version on a different port, specify this in the file *DataMiner.xml*. See [Customizing the trap reception ports of a DMA](xref:Changing_SNMP_agent_ports#customizing-the-trap-reception-ports-of-a-dma).

## SLSNMPAgent

The SLSNMPAgent process communicates with third-party applications acting as SNMP managers (e.g. HP OpenView, IBM NetCool, etc.).

- It receives SNMP Get and SNMP Set messages.

- It sends out SNMP notifications to all external SNMP managers defined in the DataMiner System.

- It uses SNMP++ for SNMPv1 traps and SNMPv3 traps and inform messages, and the WinSNMP API for SNMPv2 traps and inform messages. From DataMiner 10.0.13 onwards, it also uses SNMP++ for SNMPv2 traps and inform messages.

The UDP ports to be used are set as follows:

- The port on which SLSNMPAgent will listen for Get and Set messages has to be specified in the *\<SNMP>* tag of the file *DataMiner.xml*. Default: 161.

- The port (on an external SNMP manager) to which SNMP notifications will be sent can be specified in the file *SNMP Managers.xml*. Default: 162.

  Example:

  ```xml
  <SnmpManagers>
    ...
    <SnmpManager ...>
      <Name>MyName</Name>
      <IP port="361">201.120.212.0</IP>
      ...
    </SnmpManager>
    ...
  </SnmpManagers>
  ```

> [!NOTE]
>
> - From DataMiner 9.6.11 onwards, the DataMiner SNMP agent function is disabled by default. It can be enabled in the file *DataMiner.xml* (see [Enabling DataMiner SNMP agent functionality](xref:Enabling_DataMiner_SNMP_agent_functionality)). Note that this only affects DataMiner itself, not the virtual SNMP agents that can be enabled for elements, so that only active alarms and general DataMiner information cannot by polled by default.
> - By default, the SLSNMPAgent process listens for Get and Set messages using the same port as the Windows SNMP service. As such, if the latter has to run alongside SLSNMPAgent, either change the port used by the Windows SNMP service or change the port used by SLSNMPAgent. For more information, see [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports).

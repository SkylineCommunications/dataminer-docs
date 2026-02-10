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

![Interaction between SNMP manager and agent](~/dataminer/images/SNMPafter903.jpg)

## SLSNMPManager

The SLSNMPManager process communicates with devices acting as SNMP agents.

- It polls devices by sending SNMP Get messages.

  > [!NOTE]
  > From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44329-->, if the response to an SNMP Get message cannot be mapped, an error is logged in the element log file and in `C:\Skyline DataMiner\Logging\SLErrorsInProtocol.txt`.

- It sets parameter values on devices by sending SNMP Set messages.

- By default, it uses SNMP++ to receive notifications from devices.

- For each SNMP version (SNMPv1, SNMPv2, and SNMPv3), there is a separate SLSNMPManager process.

The UDP ports to be used are set as follows:

- The port on which the device will listen for Get and Set messages (i.e. the "polling port") has to be specified during the creation of the element associated with that device. Default: 161

- By default, only the SLSNMPManager process for SNMPv3 will receive notifications, on port 162. It will then forward them to the SNMPv1 and SNMPv2 processes when necessary:

  - The SNMPv1 process will receive all notifications (SNMPv1, SNMPv2 and SNMPv3).

  - The SNMPv2 process will receive the SNMPv2 and SNMPv3 notifications.

  To receive the notifications of any version on a different port, specify this in the file *DataMiner.xml*. See [Customizing the trap reception ports of a DMA](xref:Changing_SNMP_agent_ports#customizing-the-trap-reception-ports-of-a-dma).

## SLSNMPAgent

The SLSNMPAgent process communicates with third-party applications acting as SNMP managers (e.g. HP OpenView, IBM NetCool, etc.).

- It receives SNMP Get and SNMP Set messages.

- It sends out SNMP notifications to all external SNMP managers defined in the DataMiner System.

- It uses SNMP++ for all traps and inform messages.

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
> - The DataMiner SNMP agent function is disabled by default. It can be enabled in the file *DataMiner.xml* (see [Enabling DataMiner SNMP agent functionality](xref:Enabling_DataMiner_SNMP_agent_functionality)). Note that this only affects DataMiner itself, not the virtual SNMP agents that can be enabled for elements, which means that only active alarms and general DataMiner information cannot be polled by default.
> - By default, the SLSNMPAgent process listens for Get and Set messages using the same port as the Windows SNMP service. As such, if the latter has to run alongside SLSNMPAgent, either change the port used by the Windows SNMP service or change the port used by SLSNMPAgent. For more information, see [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports).

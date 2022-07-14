---
uid: Changing_SNMP_agent_ports
---

# Changing SNMP agent ports

By default, a DataMiner Agent acting as an SNMP agent uses UDP port 161. The same port is normally also used by the Windows SNMP service.

To prevent any conflicts between DataMiner Agents and Windows SNMP services, you can either change the port used by DataMiner Agents or the port used by the Windows SNMP services.

For more information about how DataMiner exchanges SNMP messages with devices and third-party SNMP managers, see [Interaction between SNMP manager and SNMP agent](xref:Interaction_between_SNMP_manager_and_SNMP_agent).

## Changing the SNMP port used by a Windows SNMP service

If you want the Windows SNMP service of a particular computer to use a non-default port, open the following file and change the port used by the SNMP service:

- %systemroot%\\system32\\drivers\\etc\\services

In the following example, the SNMP service uses port 161 (i.e. the default port):

```txt
snmp 161/udp #SNMP
```

## Changing the SNMP port used by a DataMiner Agent

If you want DataMiner to use another port when acting as an SNMP agent, open the file *C:\\Skyline DataMiner\\DataMiner.xml*, and change the port specified in the SNMP tag.

In the following example, DataMiner uses port 461:

```xml
<DataMiner>
  <SNMP port="461"/>
</DataMiner>
```

### Checking which port DataMiner is using

To check which port is used by DataMiner when it acts as an SNMP agent, look in the file *C:\\Skyline DataMiner\\Logging\\SLSNMPAgent.txt*.

If the default port is used, you will find a line like the following one:

```txt
2010/08/09 10:33:52.070|SNMPAgent|6336|6664|SNMP Agent Port|DBG|1|  Local SNMP Port set to 161 (DEFAULT)
```

If a non-default port is used, you will find a line like the following one:

```txt
2010/08/09 10:35:13.621|SNMPAgent|3288|3428|SNMP Agent Port|DBG|1|  Local SNMP Port set to 461 (OVERRULED)
```

> [!NOTE]
> This information is only included if the log file if the log level is set to 1 or higher.

## Customizing the trap reception ports of a DMA

In the file *DataMiner.xml*, you can specify a custom SNMPv3 trap reception port. If you do not do so, port 162 is used by default.

To specify a custom SNMPv3 trap reception port:

1. Open *C:\\Skyline DataMiner\\DataMiner.xml*.

1. Add an *\<SNMPv3>* tag in the DataMiner tag, and specify the trap reception port in the *trapPort* attribute.

   For example:

   ```xml
   <DataMiner>
     ...
     <SNMPv3 trapPort=”10162”/>
     ...
   </DataMiner>
   ```

Please note the following regarding the customization of trap reception ports:

- When you specify a custom port, you must also do the following:

  - Check the inbound rules of your firewall and add an exception to allow UDP traffic on the port in question.

  - Make sure that no other application is using the specified port.

- You can improve the trap processing capacity for SNMPv1 and v2 by configuring a custom port for SNMPv3 trap reception, e.g. 362. In that case, SNMPv1 and SNMPv2 trap reception are handled by WinSNMP. For this, the above-mentioned line *\<SNMPv3 trapPort="362"/>* must be specified in *DataMiner.xml*.

> [!TIP]
> See also: [Interaction between SNMP manager and SNMP agent](xref:Interaction_between_SNMP_manager_and_SNMP_agent)

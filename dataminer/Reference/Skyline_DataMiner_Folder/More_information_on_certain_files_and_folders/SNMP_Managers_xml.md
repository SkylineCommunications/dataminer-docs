---
uid: SNMP_Managers_xml
---

# SNMP Managers.xml

The file *SNMP Managers.xml* is used for the configuration of remote SNMP Managers and is located in the following folder: `C:\Skyline DataMiner\`.

Note that this file is only partially synchronized in a DMS. The [Configuration](xref:SNMP.Configuration) section of this file is not synced. Each DMA only reads the entry in this section that matches its own DataMiner ID.

> [!IMPORTANT]
> To implement any manual changes to *SNMP Managers.xml*, first stop the DMA and then restart it after your changes have been saved.

## Configuration section

For each DataMiner Agent in the DMS, the [Configuration](xref:SNMP.Configuration) section of this file contains an [Agent](xref:SNMP.Configuration.Agent) tag with the following subtags:

- [AuthoritativeEngineID](xref:SNMP.Configuration.Agent.AuthoritativeEngineID): The engine ID used by the DMA for northbound SNMP traffic.
- [EngineBoots](xref:SNMP.Configuration.Agent.EngineBoots): The number of engine restarts of the DMA.

For more information about the use of AuthoritativeEngineID and EngineBoots, refer to [About snmpEngineID, snmpEngineBoots, snmpEngineTime and timeliness](xref:ConnectionsSnmpSnmpv3#about-snmpengineid-snmpengineboots-snmpenginetime-and-timeliness).

  > [!NOTE]
  > It is possible to change the engine ID using the SLNetClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme care. See [Modifying the engine ID of a DMA](xref:SLNetClientTest_modifying_engine_id).

## SnmpManagers section

This section contains the configuration of the SNMP managers: third party systems to which DataMiner has to forward SNMP notifications. 

For more information about SNMP managers, refer to [About SNMP Managers](xref:About_SNMP_managers).
For more information about how to configure SNMP managers, refer to [Configuring an SNMP manager in DataMiner Cube](xref:Configuring_an_SNMP_manager_in_DataMiner_Cube).

## Example of the \<Configuration> section in the SNMP Managers.xml file

```xml
<SNMP xmlns="http://www.skyline.be/config/snmpmanagers">
  <Configuration>
    <Agent id="232" type="Octets"value="3e:e4:7d:1b:16:30:41:f4:b0:aa:2a:13:30:85:b8:75">
      <AuthoritativeEngineID>80:00:22:6d:05:3e:e4:7d:1b:16:30:41:f4:b0:aa:2a:13:30:85:b8:75</AuthoritativeEngineID>
      <EngineBoots>5</EngineBoots>
    </Agent>
    <Agent id="237" type="Text" value="MyAgent">
      <AuthoritativeEngineID>80:00:22:6D:04:4D:79:41:67:65:6E:74</AuthoritativeEngineID>
      <EngineBoots>11</EngineBoots>
    </Agent>
  </Configuration>
  <SnmpManagers>
    ...
  </SnmpManagers>
</SNMP>
```

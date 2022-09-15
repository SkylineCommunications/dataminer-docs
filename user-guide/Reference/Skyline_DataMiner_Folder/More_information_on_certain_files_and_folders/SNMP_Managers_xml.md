---
uid: SNMP_Managers_xml
---

# SNMP Managers.xml

The file *SNMP Managers.xml* is used for the configuration of remote SNMP Managers.

- This file is located in the following folder:

  *C:\\Skyline DataMiner\\*

- For each DataMiner Agent in the DMS, the *\<Configuration>* section of this file contains an *\<Agent>* tag with the following subtags:

  - *\<AuthoritativeEngineID>*: The engine ID used by the DMA for northbound SNMP traffic.

  - *\<EngineBoots>*: The number of engine restarts of the DMA.

> [!NOTE]
>
> - The *\<Configuration>* section of this file is not synced in the cluster. Each DMA only reads the entry in this section that matches its DataMiner ID.
> - It is possible to change the engine ID using the SLNetClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme care. See [Modifying the engine ID of a DMA](xref:SLNetClientTest_modifying_engine_id).

- From DataMiner 9.5.9 onwards, each *\<SnmpManager>* tag can have a *codepage* attribute, which makes it possible to select a code page. Its value is an integer. For example:

  | Attribute configuration | Description            |
  |---------------------------|------------------------|
  | codepage="65001"          | Equals unicode=”true”  |
  | codepage="0"              | Equals unicode=”false” |

    For a list of all possible code pages, see <https://msdn.microsoft.com/en-us/library/windows/desktop/dd317756(v=vs.85).aspx>.

> [!NOTE]
> To implement any manual changes to *SNMP Managers.xml*, first stop the DMA and then restart it after your changes have been saved.

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

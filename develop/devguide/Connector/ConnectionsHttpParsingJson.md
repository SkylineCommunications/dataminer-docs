---
uid: ConnectionsHttpParsingJson
---

# Parsing JSON

In order to process JSON-formatted data, the Json.NET framework can be used. This library is included in DataMiner.

For extensive documentation and examples illustrating how to use this framework, refer to https://www.newtonsoft.com/json/help/html/Introduction.htm

## Included Newtonsoft.Json versions

From DataMiner 9.5.9 onwards, DataMiner includes the Newtonsoft.Json DLL in the ProtocolScripts folder. DataMiner versions prior to 9.5.9 will use the Newtonsoft.Json DLL from the files folder instead.

The version of the included DLL is updated whenever necessary to prevent known security risks. As such, the available functionality may change. Connectors should therefore indicate a minimum required version if necessary, and they may also require an update when the included version changes.

| NewtonSoft.Json version | Minimum DataMiner version |
| -- | -- |
| 13.0.1 | 10.2.10<br>10.2.0 (CU6)<br>10.1.0 (CU18) |
| 12.0.2 | 9.6.9<br>9.6.0 (CU3) |
| 10.0.2 | 9.5.9 |

> [!NOTE]
> When you develop a connector, we recommend that you reference the Newtonsoft.Json NuGet package instead of the DLL from the ProtocolScripts folder. This requires the connector to be written as a [solution](xref:Developing_connectors_as_Visual_Studio_solutions).

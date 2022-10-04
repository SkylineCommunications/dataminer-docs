---
uid: ConnectionsHttpParsingJson
---

# Parsing JSON

In order to process JSON-formatted data, the Json.NET framework can be used. This library is included in DataMiner.

For extensive documentation and examples illustrating how to use this framework, refer to https://www.newtonsoft.com/json/help/html/Introduction.htm

## Included Newtonsoft.Json versions
Since 9.5.9, DataMiner has included Newtonsoft.Json DLL in the ProtocolScripts folder. DataMiner versions prior to 9.5.9 will use the Newtonsoft.Json DLL from the files folder instead. The included DLL has been updated when there are known security risks. Therefore, the available functionality might change and connectors should indicate a minimum required version if necessary, and may also require an update when the provided version changes.

| NewtonSoft.Json version | Minimum DataMiner version |
| -- | -- |
| 13.0.1 | 10.2.10<br>10.2.0 (CU6)<br>10.1.0 (CU18) |
| 12.0.2 | 9.6.9<br>9.6.0 (CU3) |
| 10.0.2 | 9.5.9 |

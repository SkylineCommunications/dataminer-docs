---
uid: GPON_ONT_Json_definition
---

# Standard GPON EPM ONT JSON definition

To be able to use the Kafka data stream properly in the EPM GPON solution, make sure your data is parsed in the following JSON format:

```json
{
    "doNotPublish": false,
    "host": {
        "name": "SERVER_NAME"
    },
    "entityId": "00000000-0000-0000-0000-000000000000",
    "oui": "OUI_ID",
    "serial": "ONT_SERIAL_NUMBER",
    "productClass": "ONT_MODEL",
    "deviceModelId": "00000000-0000-0000-0000-000000000000",
    "id": "UNIQUE_ONT_IDENTIFIER",
    "noOfParams": 15,
    "params": {
        "InternetGatewayDevice.DeviceInfo.UpTime": "1126066",
        "InternetGatewayDevice.DeviceInfo.Manufacturer": "VENDOR",
        "InternetGatewayDevice.DeviceInfo.HardwareVersion": "HARDWARE REVISION",
        "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.RXPower": "-20.86",
        "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.TransceiverTemperature": "54.97",
        "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.SupplyVoltage": "3.21",
        "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.TXPower": "2.51",
        "InternetGatewayDevice.WANDevice{i}GponInterfaceConfig.Status": "Up",
        "InternetGatewayDevice.DeviceInfo.Description": "DESCRIPTION TEXT",
        "InternetGatewayDevice.DeviceInfo.SerialNumber": "ONT_SERIAL_NUMBER",
        "InternetGatewayDevice.DeviceInfo.MemUsed": "31",
        "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.BiasCurrent": "14700",
        "InternetGatewayDevice.DeviceInfo.CpuUsed": "3%;2%",
        "InternetGatewayDevice.DeviceInfo.ModelName": "ONT_MODEL",
        "InternetGatewayDevice.DeviceInfo.SoftwareVersion": "SOFTWARE VERSION"
    },
    "@timestamp": "2023-07-06T01:01:39.362Z"
}
```

> [!NOTE]
> The naming structure for the total parameters follows the TR-069 protocol defined by the [Broadband Forum](https://wiki.broadband-forum.org/display/RESOURCES/Broadband+Forum+Published+Resources#tf-filters=%7B%22selectfilters%22%3A%5B%5D%2C%22userfilters%22%3A%5B%22Number%22%5D%2C%22numberfilters%22%3A%5B%5D%2C%22datefilters%22%3A%5B%5D%2C%22globalfilter%22%3Atrue%2C%22columnhider%22%3Afalse%2C%22iconfilters%22%3A%5B%5D%2C%22defaults%22%3A%5B%22TR-106%22%2C%22%22%5D%2C%22width%22%3A%5B%22150%22%2C%22150%22%5D%2C%22inverse%22%3A%5Bfalse%2Cfalse%5D%2C%22order%22%3A%5B0%2C1%5D%2C%22ddSeparator%22%3A%5B%5D%2C%22ddOperator%22%3A%5B%5D%2C%22sorts%22%3A%5B%22Date%20%E2%87%A9%22%5D%7D). You can find the complete structure here: [TR-069 Full Model](https://cwmp-data-models.broadband-forum.org/tr-069-1-0-0-full.xml).

## Field details

| Field Name | Description | Required |
|:--|:--|:--:|
| **host.name** | Includes the server name, to identify the server sending the data. | Yes |
| **entityId** | Unique identifier for this ONT in the ACS or third-party application | No |
| **oui** | The ID of the OUI. This should be defined by the ACS or the vendor. | Yes |
| **serial**| ONT serial number as reported by the vendor. This will be used as the index to associate the ONT to ports and OLTs. | Yes |
| **productClass**| The ONT model as defined by the vendor. | Yes |
| **deviceModelId**| Unique identifier for this ONT model in the ACS or third-party application. | No |
| **id**| Unique ONT identifier. This should not be repeated in the system per ONT. | Yes |
| **noOfParams**| Total count of reported parameters. | Yes |
| **params**| All reported parameters should be listed here. All names must be aligned with the [Broadband Forum](https://wiki.broadband-forum.org/display/RESOURCES/Broadband+Forum+Published+Resources#tf-filters=%7B%22selectfilters%22%3A%5B%5D%2C%22userfilters%22%3A%5B%22Number%22%5D%2C%22numberfilters%22%3A%5B%5D%2C%22datefilters%22%3A%5B%5D%2C%22globalfilter%22%3Atrue%2C%22columnhider%22%3Afalse%2C%22iconfilters%22%3A%5B%5D%2C%22defaults%22%3A%5B%22TR-106%22%2C%22%22%5D%2C%22width%22%3A%5B%22150%22%2C%22150%22%5D%2C%22inverse%22%3A%5Bfalse%2Cfalse%5D%2C%22order%22%3A%5B0%2C1%5D%2C%22ddSeparator%22%3A%5B%5D%2C%22ddOperator%22%3A%5B%5D%2C%22sorts%22%3A%5B%22Date%20%E2%87%A9%22%5D%7D) and [TR-069 Full Model](https://cwmp-data-models.broadband-forum.org/tr-069-1-0-0-full.xml). | Yes |
| **\@timestamp** | The timestamp indicating when the file was created. | Yes |

> [!NOTE]
> If you need to monitor any other parameter not listed in this example, contact the Skyline Sales team or your Technical Account Manager to evaluate your options.

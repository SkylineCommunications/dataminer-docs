---
uid: WS_v1_examples
---

# Examples

## SOAP examples

### CreateElement request

```xml
POST https://dma.local/api/v1/soap.asmx HTTP/1.1
Host: localhost
Content-Type: text/xml; charset=utf-8
Content-Length: length
SOAPAction: "http://www.skyline.be/api/v1/CreateElement"

<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
    <soap:Body>
        <CreateElement xmlns="http://www.skyline.be/api/v1">
            <connection>string</connection>
            <dmaID>int</dmaID>
            <viewIDs>
                <int>int</int>
            </viewIDs>
            <configuration>
                <Name>string</Name>
                <Description>string</Description>
                <ProtocolName>string</ProtocolName>
                <ProtocolVersion>string</ProtocolVersion>
                <Type>string</Type>
                <AlarmTemplate>string</AlarmTemplate>
                <TrendTemplate>string</TrendTemplate>
                <ForceAgent>string</ForceAgent>
                <CreateDVEs>boolean</CreateDVEs>
                <EnableSnmpAgent>boolean</EnableSnmpAgent>
                <EnableTelnet>boolean</EnableTelnet>
                <IsHidden>boolean</IsHidden>
                <IsReadOnly>boolean</IsReadOnly>
                <IsReplicationActive>boolean</IsReplicationActive>
                <KeepOnline>boolean</KeepOnline>
                <State>string</State>
                <Ports>
                    <DMAElementBasePortInfo xsi:type="DMAElementSNMPPortInfo">
                        <SNMPVersion>2</SNMPVersion>
                        <DeviceAddress>string</DeviceAddress>
                        <IPAddress>string</IPAddress>
                        <Network>string</Network>
                        <PortNumber>int</PortNumber>
                        <GetCommunity>string</GetCommunity>
                        <SetCommunity>string</SetCommunity>
                        <ElementTimeoutTime>int</ElementTimeoutTime>
                        <TimeoutTime>int</TimeoutTime>
                        <Retries>int</Retries>
                    </DMAElementBasePortInfo>
                    <DMAElementBasePortInfo xsi:type="DMAElementSNMPV3PortInfo">
                        <DeviceAddress>string</DeviceAddress>
                        <IPAddress>string</IPAddress>
                        <Network>string</Network>
                        <PortNumber>int</PortNumber>
                        <Username>string</Username>
                        <AuthType>string</AuthType>
                        <PrivType>string</PrivType>
                        <SecurityLevel>string</SecurityLevel>
                        <AuthPassword>string</AuthPassword>
                        <PrivPassword>string</PrivPassword>
                        <ElementTimeoutTime>int</ElementTimeoutTime>
                        <TimeoutTime>int</TimeoutTime>
                        <Retries>int</Retries>
                    </DMAElementBasePortInfo>
                </Ports>
            </configuration>
        </CreateElement>
    </soap:Body>
</soap:Envelope>
```

### GetAlarms request

```xml
POST https://dma.local/api/v1/soap.asmx HTTP/1.1
Host: localhost
Content-Type: text/xml; charset=utf-8
Content-Length: length
SOAPAction: "http://www.skyline.be/api/v1/GetAlarms"

<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
    <soap:Body>
        <GetAlarms xmlns="http://www.skyline.be/api/v1">
            <connection>862844db-4e3c-42f4-a6a2-a26764f05663</connection>
            <filter>
                <History>false</History>
                <SlidingWindow>false</SlidingWindow>
                <FilterItem xsi:type="DMAAlarmFilterSavedFilter">
                    <Filter>sharedusersettings:My public alarm filter</Filter>
                    <Match>true</Match>
                </FilterItem>
                <StartTime>0</StartTime>
                <EndTime>0</EndTime>
                <Masked>false</Masked>
                <InfoEvents>false</InfoEvents>
                <Columns></Columns>
                <Limit>-1</Limit>
                <SortBy></SortBy>
                <SortAscending>true</SortAscending>
            </filter>
        </GetAlarms>
    </soap:Body>
</soap:Envelope>
```

## JSON examples

### CreateElement request

```json
POST https://dma.local/API/v1/Json.asmx/CreateElement
Content-Type: application/json

{
    "connection": "3295ab57-56e8-456d-94d0-70f98fb3c7b9",
    "dmaID": 157,
    "viewIDs": [4],
    "configuration": {
        "ElementName": "Test Element",
        "ProtocolName": "Some protocol",
        "ProtocolVersion": "Production",
        "Ports": [
            { "__type": "Skyline.DataMiner.Web.Common.v1.DMAElementSerialPortInfo", "SerialPort": "COM3", "Baudrate": "2800kbps" },
            { "__type": "Skyline.DataMiner.Web.Common.v1.DMAElementSNMPPortInfo", "IPAddress": "127.0.0.1", "GetCommunity": "public", "SetCommunity": "secret_key" },
            { "__type": "Skyline.DataMiner.Web.Common.v1.DMAElementSNMPV3PortInfo", "IPAddress": "127.0.0.1", "AuthType": "MD5", "AuthPassword": "Skyline321" }
        ]
    }
}
```

### GetAlarms request

```json
POST https://dma.local/API/v1/Json.asmx/GetAlarms
Content-Type: application/json

{
    "connection": "862844db-4e3c-42f4-a6a2-a26764f05663",
    "filter": {
        "History": false,
        "SlidingWindow": false,
        "FilterItem": {
            "__type": "Skyline.DataMiner.Web.Common.v1.DMAAlarmFilterSavedFilter",
            "Filter": "sharedusersettings:My public alarm filter",
            "Match": true
        },
        "StartTime": 0,
        "EndTime": 0,
        "Masked": false,
        "InfoEvents": false,
        "Columns": [],
        "Limit": -1,
        "SortBy": null,
        "SortAscending": true
    }
}
```

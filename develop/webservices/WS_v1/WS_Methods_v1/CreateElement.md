---
uid: CreateElement
---

# CreateElement

Use this method to create a new element on the specified DataMiner Agent.

## Input

| Item          | Format                   | Description                                                                         |
|---------------|--------------------------|-------------------------------------------------------------------------------------|
| connection    | String                   | The connection string. See [ConnectApp](xref:ConnectApp).                           |
| dmaID         | Integer                  | The DataMiner Agent ID.                                                             |
| viewIDs       | Array of Integer         | The IDs of the views in which the element should be created.                        |
| configuration | DMAElementConfiguration  | See [DMAElementConfiguration](xref:DMAElementConfiguration).                        |

> [!NOTE]
>
> - When you create an element, the "State" property of the DMAElementConfiguration object should be *Active*, *Paused* or *Stopped*.
> - It is possible to specify a different SNMP version than is configured in the protocol. For more information on the configuration, refer to the examples below.

## Output

| Item                | Format          | Description                                         |
|---------------------|-----------------|-----------------------------------------------------|
| CreateElementResult | Array of string | The DataMiner ID and element ID of the new element. |

## Examples

### Request specifying SNMPv2 for an SNMPv1, SNMPv2 or SNMPv3 protocol

```xml
<CreateElement xmlns="http://www.skyline.be/api/v1">
...
   <configuration>
   ...
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
      </Ports>
   </configuration>
</CreateElement>
```

### Request specifying SNMPv3 for an SNMPv1, SNMPv2 or SNMPv3 protocol

```xml
<CreateElement xmlns="http://www.skyline.be/api/v1">
...
   <configuration>
   ...
      <Ports>
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
```

---
uid: Metadata
---

# Metadata

Every connector contains the following metadata:

|Item  |Description  |
|---------|---------|
|[Name](xref:Protocol.Name)     | The name of the protocol.        |
|[Description](xref:Protocol.Description)     | A short textual description of the protocol.         |
|[Version](xref:Protocol.Version)     | A number or text indicating the protocol version. For more information, refer to [Protocol version semantics](xref:ProtocolVersionSemantics).        |
|[Vendor](xref:Protocol.Vendor)     | The name of the vendor of the device.         |
|[VendorOID](xref:Protocol.VendorOID)     | The OID of the vendor of the device. Typically, this OID will start with the prefix 1.3.6.1.4.1, which identifies private enterprises.         |
|[DeviceOID](xref:Protocol.DeviceOID)     | The OID of the device.         |
|[Type](xref:Protocol.Type)     | The type of protocol (e.g. SNMP, SNMPv3, serial).         |
|[ElementType](xref:Protocol.ElementType)     | A short text indicating the type of device.         |
|[Provider](xref:Protocol.Provider)     | The name of the company or organization that created the protocol.         |
|[IntegrationID](xref:Protocol.IntegrationID)     | The integration ID.         |
|[VersionHistory](xref:Protocol.VersionHistory)     | The version history of the protocol. Available from DataMiner 9.5.11 onwards.         |

## See also

Coding guidelines:

- [Administrative Metadata](xref:CODAdminMetadata)

---
metadata_version: 1
uid: Metadata
description: "Define protocol metadata such as name, version, vendor, OIDs, type, provider, and version history while using the required XML namespace."
---

# Metadata

Every protocol contains the following metadata:

**Schema requirement:** The root element of a *Protocol.xml* file must use the exact namespace `http://www.skyline.be/protocol`.

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
```

| Item                                           | Description                                                                                                                                   |
|------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| [Name](xref:Protocol.Name)                     | The name of the protocol.                                                                                                                     |
| [Description](xref:Protocol.Description)       | A short textual description of the protocol.                                                                                                  |
| [Version](xref:Protocol.Version)               | A number or text indicating the protocol version. For more information, refer to [Protocol version semantics](xref:ProtocolVersionSemantics). |
| [Vendor](xref:Protocol.Vendor)                 | The name of the vendor of the device.                                                                                                         |
| [VendorOID](xref:Protocol.VendorOID)           | The unique vendor OID of the monitored data source, used when defining MIB objects.                                                          |
| [DeviceOID](xref:Protocol.DeviceOID)           | The OID of the device.                                                                                                                        |
| [Type](xref:Protocol.Type)                     | The type of protocol (e.g., SNMP, SNMPv3, serial).                                                                                             |
| [ElementType](xref:Protocol.ElementType)       | A short text indicating the type of device.                                                                                                   |
| [Provider](xref:Protocol.Provider)             | The name of the company or organization that created the protocol.                                                                            |
| [IntegrationID](xref:Protocol.IntegrationID)   | The integration ID.                                                                                                                           |
| [VersionHistory](xref:Protocol.VersionHistory) | The version history of the protocol.                                                                                                          |

**Schema behavior:** The generated [VendorOID](xref:Protocol.VendorOID) documentation says that this value must be unique and is provided by the data-source vendor or, on request, by Skyline. It typically starts with `1.3.6.1.4.1`, the private-enterprise branch.

**Unresolved question:** The current schema and Connector documentation do not establish whether every connector should use a product/vendor enterprise OID or a protocol-specific OID assigned by Skyline. Do not infer that decision from an example; confirm it with the vendor or Skyline before assigning the value.

## See also

Best practices:

- [Administrative Metadata](xref:Comment_metadata)

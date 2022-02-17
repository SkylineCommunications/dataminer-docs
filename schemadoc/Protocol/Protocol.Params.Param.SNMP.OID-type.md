---
uid: Protocol.Params.Param.SNMP.OID-type
---

# type attribute

Specifies how the OID is constructed.

## Content Type

[EnumOIDType](xref:Protocol-EnumOIDType)

## Parent

[OID](xref:Protocol.Params.Param.SNMP.OID)

## Remarks

The following values are supported:


|Type|Description
|--- |--- |
|auto|The resulting OID is the combination of vendor OID + device OID + parameter ID.|
|complete|The resulting OID is the SNMP.OID value of this parameter.|
|composed|The resulting OID is the combination of vendor OID + device OID + SNMP.OID value of this parameter.|
|wildcard|The resulting OID is the SNMP.OID value of this parameter prepended with the content of the parameter referred to by the id attribute.|

When no type (or any other value for the type attribute) is specified, this will result in the following behavior:

- In case SNMP.OID is empty: Acts as “auto”.
- In case SNMP.OID is not empty and does not exceed 10 characters: Acts as “composed”.
- In case SNMP.OID is not empty and exceeds 10 characters: Acts as “complete”.

> [!NOTE]
> It is advised to always explicitly specify a type.

### auto

The resulting OID is the combination of vendor OID + deviceOID + parameter ID.

Examples:

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
    <VendorOID>1.3.6.1.4.1.8813.2.1</VendorOID>
    <DeviceOID>1000</DeviceOID>
    <Params>
        <Param id="40" trending="false">
            ...
            <SNMP>
                ...
                <OID type="auto"></OID>
            </SNMP>
            ...
        </Param>
    </Params>
    ...
</Protocol>
```

In the example above, the requested OID is “1.3.6.1.4.1.8813.2.1.1000.40”.

### complete

The type "complete" is used when SNMP.OID specifies a complete OID.

> [!NOTE]
> The type “complete” also supports using a wildcard (‘*’). Using the id attribute, you can then refer to a parameter that holds the content that should be used as a replacement for the wildcard.

Examples:

In the following example, the OID is completely specified in SNMP.OID.

```xml
<OID type="complete">1.3.6.1.2.1.1.5.0</OID>
```

In the following example, a wildcard is used. The content of parameter with ID 100 is “1.3.6.1.2.1.1.5.0”.

```xml
<OID type="complete" id="100">*</OID>
```

The resulting requested OID is “1.3.6.1.2.1.1.5.0”.

In the following example, a wildcard is used. The content of parameter with ID 101 is “1.1.5.0”.

```xml
<OID type="complete" id="101">1.3.6.1.2.*</OID>
```

The resulting requested OID is “1.3.6.1.2.1.1.5.0”.

### composed

The OID used for polling is the combination of the vendor OID + device OID + SNMP.OID value of this parameter.

Remarks

> [!NOTE]
> The type "composed" also supports using a wildcard ('*'). Using the id attribute, you can then refer to a parameter that holds the content that should be used as a replacement for the wildcard.

Examples:

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
    <VendorOID>1.3.6.1.4.1.8813.2.1</VendorOID>
    <DeviceOID>1000</DeviceOID>
    <Params>
        <Param id="40" trending="false">
            ...
            <SNMP>
                ...
                <OID type="composed">20</OID>
            </SNMP>
            ...
        </Param>
    </Params>
    ...
</Protocol>
```

In the example above, the requested OID is “1.3.6.1.4.1.8813.2.1.1000.20”.

### wildcard

The type "wildcard" is used to prepend the content of SNMP.OID with the content specified by the parameter referred to by the id attribute.

You can also specify a complete OID in SNMP.OID and not use the id attribute to refer to another parameter.

> [!NOTE]
>
> - Using the type "complete" is favored over the type "wildcard", as the type "complete" covers the functionality of the type "wildcard" (and extends it).
> - When using type “wildcard”, you must not use a wildcard character (‘*’).

Examples:

The content of parameter with ID 102 is “1.3.6.1.2”.

```xml
<OID type="wildcard" id="102">.1.1.5.0</OID>
```

The resulting requested OID is “1.3.6.1.2.1.1.5.0”.

In the following example, the content of parameter with ID 100 is “1.3.6.1.2.1.1.5.0”.

```xml
<OID type="wildcard" id="100"></OID>
```

The resulting requested OID is “1.3.6.1.2.1.1.5.0”.

## Examples

```xml
<OID type="complete">1.3.6.1.4.1.1773.1.1.1.1.0</OID>
```

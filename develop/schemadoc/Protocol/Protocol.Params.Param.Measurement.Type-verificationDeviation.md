---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Type-verificationDeviation
description: "Reference the DataMiner connector protocol schema entry for verificationDeviation attribute, including its documented structure, attributes, values, and c."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# verificationDeviation attribute

Specifies a deviation on analog parameters.<!-- RN 4944 -->

## Content Type

decimal

## Parent

[Type](xref:Protocol.Params.Param.Measurement.Type)

## Remarks

Verification of a set done via the UI is done via a confirmation/negation of the user. In case of a remote set (e.g., SNMP set), the verification will check if the write corresponds with the read. It will also take the number of decimals into account.

This verification is done on single and on table parameters. The ExecutionVerification is configured in the ProtocolSettings in *MaintenanceSettings.xml*. However, the changes will only take effect after a restart of the DMA.

With verificationDeviation, it is possible to specify a deviation on analog parameters.

This is set on the READ param.

## Examples

```xml
<Param>
    <Measurement>
        <Type verificationDeviation="0.1">analog</Type>
    </Measurement>
</Param>
<Param>
    <Measurement>
        <Type verificationDeviation="0.1">number</Type>
    </Measurement>
</Param>
```

## See also

- [Protocol.Params.Param](xref:Protocol.Params.Param)

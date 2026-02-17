---
uid: Protocol.Params.Param-verificationTimeout
---

# verificationTimeout attribute

<!-- RN 3925 -->

Overrides the default verification timeout (or the verification timeout value set in MaintenanceSettings.xml) for this parameter with the specified value (in ms).

## Content Type

unsignedInt

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Verification of a set done via the UI is done via a confirmation/negation by the user. In case of a remote set (e.g., SNMP set), the verification will check if the write corresponds with the read. It will also take the number of decimals into account.

This verification is done on standalone and on table parameters. ExecutionVerification is configured in the ProtocolSettings section of the MaintenanceSettings.xml file. However, the changes will only take effect after a restart of the DMA.

Via the verificationTimeout attribute it is possible to change the default timeout of 30000 ms.

This is set on the READ param.

> [!NOTE]
> In case a deviation on an analog or numeric parameter is needed, see [verificationDeviation](xref:Protocol.Params.Param.Measurement.Type-verificationDeviation)

**Special case: number as HEX**

With the hex attribute, it is possible to display a number in HEX format:

```xml
<Param>
  <Measurement>
     <Type hex="true">NUMBER</Type>
  </Measurement>
```

In this case, the WRITE is of type STRING (write in HEX format)

When using the verification, the number value on the read can be compared with the string value of the write. This is done internally by converting the string to the correct decimal value. When the convert fails, for example in case of invalid HEX characters, a "-1 unable to verify" information event will be generated.

Example of information events:

- Succeeded to Set "parameter name" "optional displaykey" to "displayvalue"
- Failed to Set "parameter name" "optional displaykey" to "displayvalue"
- Succeeded to Set "parameter name" "optional displaykey" to "displayvalue" +- "your deviation"
- Failed to Set "parameter name" "optional displaykey" to "displayvalue" +- "your deviation"
- Failed to verify "parameter name" "optional displaykey"

The parameter ID for these information events is 65046, and is called Execution Verification.

## Examples

```xml
<Param verificationTimeout="1000">
```

---
uid: Protocol.Params.Param.SNMP.TrapOID-ipid
---

# ipid attribute

Specifies the ID of the parameter holding IP addresses.

## Content Type

string

## Parent

[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)

## Remarks

By default, only the traps received from the polling IP address of an element will be captured. However, using the ipid attribute, you can point to a parameter that contains other IP addresses.

If you use the ipid attribute, only traps received from the IP addresses found in the parameter referred to by the ipid attribute will be captured. Traps originating from the polling IP address will be disregarded.

If you specify an asterisk instead of a parameter ID, then all traps will be captured, no matter where they come from.

## Examples

```xml
<TrapOID setBindings="2,12502" ipid="100">1.3.6.1.4.1.4981.2.4.0.2</TrapOID>
```

The parameter specified in the ipid attribute (parameter 100 in the example above) can contain a single IP address or a comma-separated list of IP addresses. These addresses can even contain * and ? wildcards. See the examples below:

```none
10.10.12.1,10.10.15.1
10.10.12.*,10.10.22.1
10.10.12.1?,10.*.12.12
*
```

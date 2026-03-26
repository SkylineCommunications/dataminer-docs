---
uid: ConnectionsSnmpAlteringMultipleVariables
---

# Altering multiple variables

The SNMP protocol allows a set to be performed with multiple variable bindings, i.e., to set multiple variables in one request.

In a protocol, this is enabled by using an action of type "set" on a group. The referenced group (200 in the example below) then contains the write parameters to be set. This will result in a set request being sent with multiple variable bindings.

```xml
<Action id="110">
   <Name>Multiple Set</Name>
   <On id="200">group</On>
  <Type>set</Type>
</Action>
```

> [!NOTE]
>
> - There needs to be more than one parameter in the group. Otherwise the set will fail with "could not resolve OID".
> - When a set request is received, the SNMP agent performs a number of checks before the objects listed in the variable bindings list are set. One of these checks is ensuring that all variables in the variable bindings list are available in the MIB view. As soon as one object listed in the variable bindings list is not available in the MIB view, the set request is considered invalid and no set is performed. Only when all checks succeed, are the sets performed. According to the SNMP specification, this should be effected as a simultaneous set by the device. See <https://tools.ietf.org/html/rfc3416#section-4.2.5>.

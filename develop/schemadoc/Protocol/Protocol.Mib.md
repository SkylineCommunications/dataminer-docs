---
uid: Protocol.Mib
description: "Use the Mib element in a DataMiner protocol to add SMI-compliant content to the protocol's generated MIB."
---

# Mib element

Allows you to provide additional content (conforming the SMI specification) that must be included in the generated MIB.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Protocol](xref:Protocol)

## Examples

```xml
<Protocol>
  <Mib>
     <![CDATA[

        traps
        OBJECT IDENTIFIER ::= { newNewtecSatIPManager 100 }
 
 
 
 
        -- RTN Permanent Link Change
        trapPermLinkRtnChange NOTIFICATION-TYPE
        OBJECTS
            {
           trapPermLinkRtnChangeId
           }
        STATUS  current
        DESCRIPTION
           "Trap generated when modifying, adding an entry in the RTn PAMA link table"
        ::= { traps 1 }
 
        ...
     ]]>
  </Mib>
</Protocol>
```

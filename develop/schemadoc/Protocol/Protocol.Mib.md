---
metadata_version: 1
uid: Protocol.Mib
description: "Learn how to use the Mib element to add SMI-compliant content to the connector's generated MIB in a DataMiner connector protocol."
---

# Mib element

Allows providing additional content (conforming the SMI specification) that must be included in the generated MIB.

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

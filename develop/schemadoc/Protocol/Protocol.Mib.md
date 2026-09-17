---
metadata_version: 1
uid: Protocol.Mib
description: "Reference the DataMiner connector protocol schema entry for Mib element, including its documented structure, attributes, values, and constraints."
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

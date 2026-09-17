---
metadata_version: 1
uid: Protocol.Triggers.Trigger.Time-case
description: "Reference the DataMiner connector protocol schema entry for case attribute, including its documented structure, attributes, values, and constraints."
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

# case attribute

Specifies the condition operator: equal, not equal, greater, less, or a logical combination of those operators.

## Content Type

string

## Parent

[Time](xref:Protocol.Triggers.Trigger.Time)

## Examples

In the following example, the trigger will be executed when the value of the Parameter with ID 1 is equal to 2:


```xml
<Time id="1" case="equal" value="2">
```




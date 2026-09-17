---
metadata_version: 1
uid: Protocol.Groups.Group.Condition
description: "Reference the DataMiner connector protocol schema entry for Condition element, including its documented structure, attributes, values, and constraints."
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

# Condition element

Specifies a condition that must be met in order for the group to execute.

## Type

string

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

If you specify a condition, the group will only be executed when the condition is met.
Note that a condition can be enclosed in a CDATA tag.

Refer to <xref:LogicConditions> for more information about conditions.

> [!IMPORTANT]
> When the group has a condition, `before group` and `after group` triggers will only go off if the condition result is `true`. Note that prior to DataMiner 10.4.8 [CU1] and 10.4.0 [CU5], `before group` triggers will go off regardless of the group condition result, but this is no longer the case in later DataMiner versions.

## Examples

In the following example, the group will be executed when the value of parameter 500 is equal to “Active”:

```xml
<Group id="200">
  <Condition>id:500 == "Active"</Condition>
</Group>
```

In the following example, the group will be executed when the value of parameter 5 is equal to 1:

```xml
<Group id="200">
  <Condition><![CDATA[(id:5 == 1)]]></Condition>
</Group>
```

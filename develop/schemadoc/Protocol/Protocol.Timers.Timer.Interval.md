---
metadata_version: 1
uid: Protocol.Timers.Timer.Interval
description: "Reference the DataMiner connector protocol schema entry for Interval element, including its documented structure, attributes, values, and constraints."
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

# Interval element

Specifies the interval (in milliseconds) between consecutive executions.

## Type

unsignedInt

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Remarks

Specifies the interval (in ms)

- between two consecutive groups within a timer, as well as
- between two consecutive pairs within a group.

## Examples

```xml
<Timer id="1">
  <Time>600000</Time>
  <Interval>100</Interval>
  <Content>
     <Group>4000</Group>
  </Content>
</Timer>
...
<Group id="4000">
  <Name>Example</Name>
  <Description>Example</Description>
  <Content>
     <Pair>220</Pair>
     <Pair>222</Pair>
     <Pair>224</Pair>
     <Pair>225</Pair>
     <Pair>226</Pair>
  </Content>
</Group>
```

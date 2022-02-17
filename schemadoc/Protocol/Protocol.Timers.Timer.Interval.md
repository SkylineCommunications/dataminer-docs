---
uid: Protocol.Timers.Timer.Interval
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

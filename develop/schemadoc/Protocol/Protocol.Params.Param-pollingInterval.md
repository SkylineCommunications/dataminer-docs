---
uid: Protocol.Params.Param-pollingInterval
---

# pollingInterval attribute

Specifies the polling interval (ms) as a hint for the real-time trend graph.<!-- RN 5580 -->

## Content Type

unsignedInt

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

In case you have real-time trending enabled on a parameter and the value of that parameter does not change often, the graph would only be drawn until the time when the parameter value last changed.

Using this attribute, you can specify what the expected polling interval is (in ms). This allows DataMiner to update the graph to a more recent point (when compared to not using this option). This attribute can e.g., be useful in case values are set from a QAction.

## Examples

```xml
<Param id="1203" trending="true" duplicateAs="11203" pollingInterval="900000">
```

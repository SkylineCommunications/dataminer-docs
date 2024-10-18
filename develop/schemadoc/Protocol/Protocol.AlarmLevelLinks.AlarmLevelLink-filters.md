---
uid: Protocol.AlarmLevelLinks.AlarmLevelLink-filters
---

# filters attribute

Specifies the column parameter ID where the result of the alarm level needs to be set.<!-- RN 5964 -->

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[AlarmLevelLink](xref:Protocol.AlarmLevelLinks.AlarmLevelLink)

## Remarks

By default, linking can be done via primary key or display key. When linking is used, for every key a link is made with the aggregator element. Use filters to specify another column in the table that acts as a filter. If you specify a filter, the alarm level link will only be made when the condition is met.

## Examples

In the following example, the link will only be made if parameter 204 contains "1":

```xml
<AlarmLevelLink id="1" remoteElement="207:200:203" filters="VALUE=204 === 1" destination="203:DISPLAY_NOLINK:202" />
```

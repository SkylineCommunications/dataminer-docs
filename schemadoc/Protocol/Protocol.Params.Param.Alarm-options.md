---
uid: Protocol.Params.Param.Alarm-options
---

# options attribute

Specifies a number of options, separated by semicolons (”;”). These options can only be used if the table is linked to another table.

## Content Type

string

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

The options attribute allows you to specify the following options:

### properties

In this option, specify the format of the properties to be added to the alarm tab. Always start the properties string with the character used to separate the different formats. Each property in the string is either a parameter ID or a combination of text and parameter IDs separated by an asterisk (“\*”). If the characters between “\*” are solely numbers, then they are considered a parameter ID.

### propertyNames

In this option, specify the property labels to be added to the alarm tab. Multiple names are separated by a comma.

Note that it is possible to refer to columns from other linked tables, as illustrated in the following example (where parameter 1005 is part of table 1000 and parameter 2002 is part of table 2000):

```xml
<Alarm options="propertyNames:Property 1,Property 2;properties:|1005|2002">
```

### threshold

When using this option, specify two parameter IDs, separated by a comma. If the value of the second parameter is less than the value of the first parameter, no alarm will be generated.

## Examples

In the following example, if the value on the same row in column 2206 is smaller than the value in parameter 102, no alarm will be generated.

If an alarm is generated, two extra alarm property columns will be added:

- The “Type” column will contain the value found in parameter 4
- The “Descr” column will contain the value “INT:”, followed by the value found in parameter 303.

```xml
<Alarm options="threshold:102,2206;propertyNames:Type,Descr;properties:|4|*INT:*303">
```

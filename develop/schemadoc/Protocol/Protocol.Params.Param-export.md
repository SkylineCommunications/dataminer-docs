---
uid: Protocol.Params.Param-export
---

# export attribute

Allows exporting a parameter to an exported protocol used by a dynamic virtual element (DVE).

## Content Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Possible values:

|Value|Description
|--- |--- |
|true|The parameter will be exported to all of the exported protocols.|
|Table parameter ID(s)|The parameter will only be exported to the exported protocol used for the specified table(s). Multiple table IDs must be separated by a semicolon.|

## Examples

```xml
<Param id="1" export="true"></Param>
<Param id="2" export="10000"></Param>
<Param id="10" trending="false" export="100;200"></Param>
```

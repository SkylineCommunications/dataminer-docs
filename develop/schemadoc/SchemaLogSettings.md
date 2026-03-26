---
uid: SchemaLogSettings
---

# LogSettings schema

DataMiner LogSettings XML schema.

For more information about LogSettings, refer to [LogSettings.xml](xref:LogSettings_xml).

## Root element

[Log](xref:LogSettingsLog)

## Example

```xml
<Log xmlns="http://www.skyline.be/config/log">
   <File name="">
      <Levels info="0" error="0" debug="0" />
   </File>
   <General>
      <LinesPerIteration>50</LinesPerIteration>
      <SLLogMaxMemory>100</SLLogMaxMemory>
   </General>
</Log>
```

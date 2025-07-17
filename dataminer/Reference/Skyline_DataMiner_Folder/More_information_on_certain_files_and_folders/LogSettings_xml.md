---
uid: LogSettings_xml
---

# LogSettings.xml

This file allows you to tweak the SLLog log queue cleaning behavior.

You can tweak the SLLog queue cleaning behavior with the following settings in the file:

| Setting | Description |
|---------|-------------|
| [LinesPerIteration](xref:Log.General.LinesPerIteration) | The maximum number of lines that SLLog will move from a buffer to a log file.<br>Default: 100 lines. |
| [SLLogMaxMemory](xref:Log.General.SLLogMaxMemory) | The maximum amount of memory (in MB) that SLLog can use before it will clean up the largest stack that has not yet been written to a file.<br>Default: 500 MB. |

The file also contains the log level configuration. However, this should be configured in DataMiner Cube.

For more information about the contents of this file, see the [LogSetting XML schema](xref:SchemaLogSettings) documentation.

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

## LogSettings.xml

From DataMiner 10.1.9/10.2.0 onwards, this file allows you to tweak SLLog stack cleaning behavior. The file also contains the log level configuration; however, this should be configured via the Cube UI instead of directly in the file.

You can tweak the SLLog stack cleaning behavior with the following settings in the file:

| Setting           | Description                                                                                                                                              |
|-------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------|
| LinesPerIteration | The maximum number of lines that SLLog will move from a buffer to a log file. Default: 100.                                                              |
| SLLogMaxMemory    | The maximum amount of memory (in MB) that SLLog can use before it will clean up the largest stack that has not yet been written to a file. Default: 500. |

For example:

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

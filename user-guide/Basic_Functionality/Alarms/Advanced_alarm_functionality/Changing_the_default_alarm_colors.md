---
uid: Changing_the_default_alarm_colors
---

# Changing the default alarm colors

In the *DataMiner.xml* file, you can specify the colors you want to assign to each of the alarm states:

1. Open the file *DataMiner.xml* in a text file editor (e.g. Microsoft Notepad), from the folder *C:\\Skyline DataMiner\\*.

1. In the *\<Colors>* tag, modify the alarm colors.

   In the value attribute of each of the *\<Color>* tags, you can specify a color as a set of RGB values.

1. Save *DataMiner.xml*

1. Restart DataMiner.

1. Force a synchronization of the *DataMiner.xml* file throughout your DataMiner System:

   1. In DataMiner Cube, go to *Apps* > *System Center*.

   1. Go to the *Tools* tab and select *synchronization*.

   1. In the drop-down list next to *Type*, select *File*.

   1. In the *File* box, specify the following path: *C:\\Skyline Dataminer\\DataMiner.xml*.

   1. Click the *Sync now* button.

> [!NOTE]
> The alarm colors have to be specified in the *\<Colors>* tag of the *DataMiner.xml* file. If the *\<Colors>* tag is missing, it should be added. In that case, we recommend adding the tag you find in the example below. It contains all default colors.

> [!TIP]
> See also:
>
> - [Alarm severity levels](xref:Alarm_types#alarm-severity-levels)
> - [DataMiner.xml](xref:DataMiner_xml#dataminerxml)

## Example

In the following example, the default alarm colors up to DataMiner 9.6.4 have been configured:

```xml
<DataMiner>
  <Colors>
    <Color type="normal" value="0,255,0" />
    <Color type="warning" value="0,0,255" />
    <Color type="minor" value="0,255,255" />
    <Color type="major" value="255,255,0" />
    <Color type="critical" value="255,0,0" />
    <Color type="notMonitored" value="192,192,192" />
    <Color type="initial" value="242,242,242" />
    <Color type="timeout" value="255,128,0" />
    <Color type="masked" value="128,0,128" />
    <Color type="error" value="192,192,192" />
    <Color type="notice" value="192,192,192" />
    <Color type="information" value="192,192,192" />
  </Colors>
</DataMiner>
```

The following color configuration matches the default alarm colors from DataMiner 9.6.4 onwards:

```xml
<DataMiner>
  <Colors>
    <Color type="normal" value="22,198,12"/>
    <Color type="warning" value="59,120,255"/>
    <Color type="minor" value="97,214,214"/>
    <Color type="major" value="245,210,40"/>
    <Color type="critical" value="240,50,65"/>
    <Color type="notMonitored" value="204,204,204"/>
    <Color type="initial" value="242,242,242"/>
    <Color type="timeout" value="255,155,15"/>
    <Color type="masked" value="136,23,152"/>
    <Color type="error" value="204,204,204"/>
    <Color type="notice" value="204,204,204"/>
    <Color type="information" value="204,204,204"/>
  </Colors>
</DataMiner>
```

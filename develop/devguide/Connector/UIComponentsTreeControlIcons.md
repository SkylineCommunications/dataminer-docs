---
uid: UIComponentsTreeControlIcons
---

# Icons

Custom icons can be used for the nodes in a tree control to enhance the visual experience:

![alt text](~/develop/images/uiicons.png "Example tree control with icons")

A global icon set can be found in C:\Skyline DataMiner\Protocols\Icons.xml. All protocols can link to icons from this file.

By default, the icon in the tree items will be chosen according to this priority:

1. The `<Icon>...</Icon>` defined on the table parameter.
1. The `<Icon ref="...">` defined on the table parameter (referencing an icon in C:\Skyline DataMiner\Protocols\Icons.xml).
1. A default icon if no `<Icon>` is defined on the table parameter.

By specifying a column in OverrideIconColumns (under the TreeControl tag), you can apply a custom icon based on a cell value in that row. The column must be a parameter of type “discreet” and all discrete values must have an iconRef attribute referring to an icon. If the iconRef attribute is empty or invalid, or the value is “Not Initialized”, a default icon will be displayed.

```xml
<Discreets>
  <Discreet iconRef="audio">
    <Value>0</Value>
    <Display>Off</Display>
  </Discreet>
  <Discreet iconRef="video">
    <Value>1</Value>
    <Display>Right</Display>
  </Discreet>
</Discreets>
```

|Icon|Icon Key|Description|
|--- |--- |--- |
|![alt text](~/develop/images/ANALYZERCARDS.png "Analyzer card")|ANALYZERCARDS|Analyzer card.|
|![alt text](~/develop/images/APPLICATION.png "Application")|APPLICATION|Application.|
|![alt text](~/develop/images/arrowDown.png "Arrow pointing down")|arrowDown|Arrow pointing down|
|![alt text](~/develop/images/arrowUp.png "Arrow pointing up")|arrowUp|Arrow pointing up|
|![alt text](~/develop/images/ASIPort.png "ASI port")|ASIPort|ASI port.|
|![alt text](~/develop/images/ATSC.png "ATSC")|ATSC|ATSC.|
|![alt text](~/develop/images/Backup.png "Backup")|Backup|Backup (See also “Main”).|
|![alt text](~/develop/images/Carrier.png "Carrier")|Carrier|Carrier.|
|![alt text](~/develop/images/CAT.png "Conditional Access Table, contains EMM PID")|CAT|Conditional Access Table, contains EMM PID.|
|![alt text](~/develop/images/DATA.png "Data PID")|DATA|Data PID.|
|![alt text](~/develop/images/DATACAROUSEL.png "Data carousel")|DATACAROUSEL|Data carousel.|
|![alt text](~/develop/images/Device.png "Device")|Device|Device.|
|![alt text](~/develop/images/DirectConnection.png "Direct connection")|DirectConnection|Direct connection.|
|![alt text](~/develop/images/DVBSCard.png "DVBS card")|DVBSCard|DVBS card.|
|![alt text](~/develop/images/ECM.png "ECM")|ECM|Contains encrypted key for EMM.|
|![alt text](~/develop/images/EIT.png "EIT")|EIT|Event Information Table.|
|![alt text](~/develop/images/EMM.png "EMM")|EMM|Encrypted Message.|
|![alt text](~/develop/images/FixedInput.png "Fixed input")|FixedInput|Fixed input.|
|![alt text](~/develop/images/FixedOutput.png "Fixed output")|FixedOutput|Fixed output.|
|![alt text](~/develop/images/GBEPort.png "GBE port")|GBEPort|GBE port.|
|![alt text](~/develop/images/General.png "General")|General|General|
|![alt text](~/develop/images/GeneralInput.png "General input")|GeneralInput|General input.|
|![alt text](~/develop/images/GeneralPID.png "General PID")|GeneralPID|General PID.|
|![alt text](~/develop/images/GeneralService.png "General service")|GeneralService|General service.|
|![alt text](~/develop/images/GeneralTransportStream.png "General transport stream")|GeneralTransportStream|Obsolete: Use GT instead.|
|![alt text](~/develop/images/GT.png "General transport stream")|GT|General transport stream|
|![alt text](~/develop/images/IDP-NOK.png "IDP not OK")|IDP-NOK|IDP not OK. Available from DataMiner 9.6.11 onwards.|
|![alt text](~/develop/images/IDP-OK.png "IDP OK")|IDP-OK|IDP OK. Available from DataMiner 9.6.11 onwards.|
|![alt text](~/develop/images/IDP-Running.png "IDP-Running")|IDP-Running|IDP running. Available from DataMiner 9.6.11 onwards.|
|![alt text](~/develop/images/IDP-Unknown.png "IDP-Unknown")|IDP-Unknown|IDP unknown. Available from DataMiner 9.6.11 onwards.|
|![alt text](~/develop/images/Input.png "Input")|Input|Input.|
|![alt text](~/develop/images/InputAndOutput.png "Input and output")|InputAndOutput|Input and output.|
|![alt text](~/develop/images/InputTransportStream.png "Input transport stream")|InputTransportStream|Input transport stream.|
|![alt text](~/develop/images/LED-Blue.png "Blue LED")|LED-Blue|Blue LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/LED-Cyan.png "Cyan LED")|LED-Cyan|Cyan LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/LED-Lime.png "Lime green LED")|LED-Lime|Lime green LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/LED-Red.png "Red LED")|LED-Red|Red LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/LED-Silver.png "Silver LED")|LED-Silver|Silver LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/LED-Yellow.png "Yellow LED")|LED-Yellow|Yellow LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](~/develop/images/Main.png "Main")|Main|Main (See also “Backup”)|
|![alt text](~/develop/images/Matrix.png "Matrix")|Matrix|Matrix.|
|![alt text](~/develop/images/MIP.png "MIP")|MIP|MIP.|
|![alt text](~/develop/images/MPE.png "MPE")|MPE|MPE.|
|![alt text](~/develop/images/MPEG2_AUDIO.png "Audio PID")|MPEG2_AUDIO|Audio PID.|
|![alt text](~/develop/images/MPEG2_VIDEO.png "Video PID")|MPEG2_VIDEO|Video PID.|
|![alt text](~/develop/images/newItem.png "New item")|New-Item|New item. Available from DataMiner 10.0.13 (RN 28060) onwards.|
|![alt text](~/develop/images/NIT.png "Network Information Table")|NIT|Network Information Table: Info about muxes and TS, private stream info, e.g. Teletext.|
|![alt text](~/develop/images/OBJECTCAROUSEL.png "Object carousel")|OBJECTCAROUSEL|Object carousel.|
|![alt text](~/develop/images/Output.png "Output")|Output|Output.|
|![alt text](~/develop/images/OutputTransportStream.png "Output Transport Stream")|OutputTransportStream|Output Transport Stream.|
|![alt text](~/develop/images/PAT.png "Program Association Table")|PAT|Program Association Table: All programs available in TS.|
|![alt text](~/develop/images/PCR.png "Program Clock Reference")|PCR|Program Clock Reference.|
|![alt text](~/develop/images/PD.png "PD")|PD|PD.|
|![alt text](~/develop/images/PES.png "Packetized elementary stream")|PES|Packetized elementary stream.|
|![alt text](~/develop/images/PMT.png "Program Map Table")|PMT|Program Map Table: Info about program.|
|![alt text](~/develop/images/Primary.png "Primary")|Primary|Primary (See also “Secondary”)|
|![alt text](~/develop/images/Processor.png "Processor")|Processor|Processor.|
|![alt text](~/develop/images/RADIO.png "Radio")|RADIO|Service of type Radio.|
|![alt text](~/develop/images/RECT-AliceBlue.png "Rectagnle")|RECT-\[ColorName\]|Filled rectangle, where \[ColorName\] is a color name (e.g. RECT-AliceBlue). For a full list of the available color names, refer to https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=netframework-4.8. Available from DataMiner 9.6.11 onwards.|
|![alt text](~/develop/images/RST.png "RST")|RST|RST.|
|![alt text](~/develop/images/Satellite.png "Satellite")|Satellite|Satellite.|
|![alt text](~/develop/images/SDT.png "Service Description Table")|SDT|Service Description Table.|
|![alt text](~/develop/images/Secondary.png "Secondary")|Secondary|Secondary (See also “Primary”)|
|![alt text](~/develop/images/SI.png "SI")|SI|SI.|
|![alt text](~/develop/images/StorageCellEmpty.png "Empty storage cell")|StorageCellEmpty|Empty storage cell.|
|![alt text](~/develop/images/StorageCellFull.png "Full storage cell")|StorageCellFull|Full storage cell.|
|![alt text](~/develop/images/StorageTape.png "Storage tape")|StorageTape|Storage tape.|
|![alt text](~/develop/images/SUBTITLE.png "Subtitle")|SUBTITLE|Subtitle.|
|![alt text](~/develop/images/TDT.png "Time and date Table")|TDT|Time and date Table.|
|![alt text](~/develop/images/TELETEXT.png "Teletext PID")|TELETEXT|Teletext PID.|
|![alt text](~/develop/images/Transponder.png "Transponder")|Transponder|Transponder.|
|![alt text](~/develop/images/TransponderLeased.png "Leased transponder")|TransponderLeased|Leased transponder.|
|![alt text](~/develop/images/Trash.png "Trash can")|Trash|Trash can. Available from DataMiner 10.0.13 (RN 28060) onwards.|
|![alt text](~/develop/images/TV.png "Service of type Television")|TV|Service of type Television.|
|![alt text](~/develop/images/Unknown.png "Unknown")|Unknown|Unknown.|
|![alt text](~/develop/images/VSAT.png "VSAT")|VSAT|VSAT.|

```xml
<Param id="1000" trending="false">
  <Name>PIDTable</Name>
  <Description>PID Table</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
    <ColumnOption idx="0" pid="1001" type="custom" options=";"/>
    <ColumnOption idx="1" pid="1002" type="custom" options=";"/>
  </ArrayOptions>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Icon ref="GeneralPID" />
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet iconRef="CAT">
        <Display>CAT</Display>
        <Value>1</Value>
      </Discreet>
      <Discreet iconRef="DATA">
        <Display>DATA</Display>
        <Value>2</Value>
      </Discreet>
      <Discreet iconRef="ECM">
        <Display>ECM</Display>
        <Value>3</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

Now, in the tree control, we need to define the parameter ID of the column containing the iconRef.

```xml
<TreeControls>
  <TreeControl parameterId="5000" readOnly="true">
     ...
    <OverrideIconColumns>1002</OverrideIconColumns>
  </TreeControl>
</TreeControls>
```

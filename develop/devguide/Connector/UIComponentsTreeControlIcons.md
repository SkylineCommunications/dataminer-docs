---
uid: UIComponentsTreeControlIcons
---

# Icons

Custom icons can be used for the nodes in a tree control to enhance the visual experience:

![alt text](../../images/uiicons.png "Example tree control with icons")

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
|![alt text](../../images/ANALYZERCARDS.png "Analyzer card")|ANALYZERCARDS|Analyzer card.|
|![alt text](../../images/APPLICATION.png "Application")|APPLICATION|Application.|
|![alt text](../../images/arrowDown.png "Arrow pointing down")|arrowDown|Arrow pointing down|
|![alt text](../../images/arrowUp.png "Arrow pointing up")|arrowUp|Arrow pointing up|
|![alt text](../../images/ASIPort.png "ASI port")|ASIPort|ASI port.|
|![alt text](../../images/ATSC.png "ATSC")|ATSC|ATSC.|
|![alt text](../../images/Backup.png "Backup")|Backup|Backup (See also “Main”).|
|![alt text](../../images/Carrier.png "Carrier")|Carrier|Carrier.|
|![alt text](../../images/CAT.png "Conditional Access Table, contains EMM PID")|CAT|Conditional Access Table, contains EMM PID.|
|![alt text](../../images/DATA.png "Data PID")|DATA|Data PID.|
|![alt text](../../images/DATACAROUSEL.png "Data carousel")|DATACAROUSEL|Data carousel.|
|![alt text](../../images/Device.png "Device")|Device|Device.|
|![alt text](../../images/DirectConnection.png "Direct connection")|DirectConnection|Direct connection.|
|![alt text](../../images/DVBSCard.png "DVBS card")|DVBSCard|DVBS card.|
|![alt text](../../images/ECM.png "ECM")|ECM|Contains encrypted key for EMM.|
|![alt text](../../images/EIT.png "EIT")|EIT|Event Information Table.|
|![alt text](../../images/EMM.png "EMM")|EMM|Encrypted Message.|
|![alt text](../../images/FixedInput.png "Fixed input")|FixedInput|Fixed input.|
|![alt text](../../images/FixedOutput.png "Fixed output")|FixedOutput|Fixed output.|
|![alt text](../../images/GBEPort.png "GBE port")|GBEPort|GBE port.|
|![alt text](../../images/General.png "General")|General|General|
|![alt text](../../images/GeneralInput.png "General input")|GeneralInput|General input.|
|![alt text](../../images/GeneralPID.png "General PID")|GeneralPID|General PID.|
|![alt text](../../images/GeneralService.png "General service")|GeneralService|General service.|
|![alt text](../../images/GeneralTransportStream.png "General transport stream")|GeneralTransportStream|Obsolete: Use GT instead.|
|![alt text](../../images/GT.png "General transport stream")|GT|General transport stream|
|![alt text](../../images/IDP-NOK.png "IDP not OK")|IDP-NOK|IDP not OK. Available from DataMiner 9.6.11 onwards.|
|![alt text](../../images/IDP-OK.png "IDP OK")|IDP-OK|IDP OK. Available from DataMiner 9.6.11 onwards.|
|![alt text](../../images/IDP-Running.png "IDP-Running")|IDP-Running|IDP running. Available from DataMiner 9.6.11 onwards.|
|![alt text](../../images/IDP-Unknown.png "IDP-Unknown")|IDP-Unknown|IDP unknown. Available from DataMiner 9.6.11 onwards.|
|![alt text](../../images/Input.png "Input")|Input|Input.|
|![alt text](../../images/InputAndOutput.png "Input and output")|InputAndOutput|Input and output.|
|![alt text](../../images/InputTransportStream.png "Input transport stream")|InputTransportStream|Input transport stream.|
|![alt text](../../images/LED-Blue.png "Blue LED")|LED-Blue|Blue LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/LED-Cyan.png "Cyan LED")|LED-Cyan|Cyan LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/LED-Lime.png "Lime green LED")|LED-Lime|Lime green LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/LED-Red.png "Red LED")|LED-Red|Red LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/LED-Silver.png "Silver LED")|LED-Silver|Silver LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/LED-Yellow.png "Yellow LED")|LED-Yellow|Yellow LED. Available from DataMiner 10.1.2 onwards (RN 28566).|
|![alt text](../../images/Main.png "Main")|Main|Main (See also “Backup”)|
|![alt text](../../images/Matrix.png "Matrix")|Matrix|Matrix.|
|![alt text](../../images/MIP.png "MIP")|MIP|MIP.|
|![alt text](../../images/MPE.png "MPE")|MPE|MPE.|
|![alt text](../../images/MPEG2_AUDIO.png "Audio PID")|MPEG2_AUDIO|Audio PID.|
|![alt text](../../images/MPEG2_VIDEO.png "Video PID")|MPEG2_VIDEO|Video PID.|
|![alt text](../../images/newItem.png "New item")|New-Item|New item. Available from DataMiner 10.0.13 (RN 28060) onwards.|
|![alt text](../../images/NIT.png "Network Information Table")|NIT|Network Information Table: Info about muxes and TS, private stream info, e.g. Teletext.|
|![alt text](../../images/OBJECTCAROUSEL.png "Object carousel")|OBJECTCAROUSEL|Object carousel.|
|![alt text](../../images/Output.png "Output")|Output|Output.|
|![alt text](../../images/OutputTransportStream.png "Output Transport Stream")|OutputTransportStream|Output Transport Stream.|
|![alt text](../../images/PAT.png "Program Association Table")|PAT|Program Association Table: All programs available in TS.|
|![alt text](../../images/PCR.png "Program Clock Reference")|PCR|Program Clock Reference.|
|![alt text](../../images/PD.png "PD")|PD|PD.|
|![alt text](../../images/PES.png "Packetized elementary stream")|PES|Packetized elementary stream.|
|![alt text](../../images/PMT.png "Program Map Table")|PMT|Program Map Table: Info about program.|
|![alt text](../../images/Primary.png "Primary")|Primary|Primary (See also “Secondary”)|
|![alt text](../../images/Processor.png "Processor")|Processor|Processor.|
|![alt text](../../images/RADIO.png "Radio")|RADIO|Service of type Radio.|
|![alt text](../../images/RECT-AliceBlue.png "Rectagnle")|RECT-\[ColorName\]|Filled rectangle, where \[ColorName\] is a color name (e.g. RECT-AliceBlue). For a full list of the available color names, refer to https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=netframework-4.8. Available from DataMiner 9.6.11 onwards.|
|![alt text](../../images/RST.png "RST")|RST|RST.|
|![alt text](../../images/Satellite.png "Satellite")|Satellite|Satellite.|
|![alt text](../../images/SDT.png "Service Description Table")|SDT|Service Description Table.|
|![alt text](../../images/Secondary.png "Secondary")|Secondary|Secondary (See also “Primary”)|
|![alt text](../../images/SI.png "SI")|SI|SI.|
|![alt text](../../images/StorageCellEmpty.png "Empty storage cell")|StorageCellEmpty|Empty storage cell.|
|![alt text](../../images/StorageCellFull.png "Full storage cell")|StorageCellFull|Full storage cell.|
|![alt text](../../images/StorageTape.png "Storage tape")|StorageTape|Storage tape.|
|![alt text](../../images/SUBTITLE.png "Subtitle")|SUBTITLE|Subtitle.|
|![alt text](../../images/TDT.png "Time and date Table")|TDT|Time and date Table.|
|![alt text](../../images/TELETEXT.png "Teletext PID")|TELETEXT|Teletext PID.|
|![alt text](../../images/Transponder.png "Transponder")|Transponder|Transponder.|
|![alt text](../../images/TransponderLeased.png "Leased transponder")|TransponderLeased|Leased transponder.|
|![alt text](../../images/Trash.png "Trash can")|Trash|Trash can. Available from DataMiner 10.0.13 (RN 28060) onwards.|
|![alt text](../../images/TV.png "Service of type Television")|TV|Service of type Television.|
|![alt text](../../images/Unknown.png "Unknown")|Unknown|Unknown.|
|![alt text](../../images/VSAT.png "VSAT")|VSAT|VSAT.|

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

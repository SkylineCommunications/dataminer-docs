---
uid: UIComponentsTreeControlIcons
---

# Icons

Custom icons can be used for the nodes in a tree control to enhance the visual experience:

![Example tree control with icons](~/develop/images/uiicons.png)

A global icon set can be found in `C:\Skyline DataMiner\Protocols\Icons.xml`. All protocols can link to icons from this file.

By default, the icon in the tree items will be chosen according to this priority:

1. The `<Icon>...</Icon>` defined on the table parameter.
1. The `<Icon ref="...">` defined on the table parameter (referencing an icon in `C:\Skyline DataMiner\Protocols\Icons.xml`).
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
|![Analyzer card](~/develop/images/ANALYZERCARDS.png)|ANALYZERCARDS|Analyzer card.|
|![Application](~/develop/images/APPLICATION.png)|APPLICATION|Application.|
|![Arrow pointing down](~/develop/images/arrowDown.png)|arrowDown|Arrow pointing down|
|![Arrow pointing up](~/develop/images/arrowUp.png)|arrowUp|Arrow pointing up|
|![ASI port](~/develop/images/ASIPort.png)|ASIPort|ASI port.|
|![ATSC](~/develop/images/ATSC.png)|ATSC|ATSC.|
|![Backup](~/develop/images/Backup.png)|Backup|Backup (See also "Main").|
|![Carrier](~/develop/images/Carrier.png)|Carrier|Carrier.|
|![Conditional Access Table, contains EMM PID](~/develop/images/CAT.png)|CAT|Conditional Access Table, contains EMM PID.|
|![Data PID](~/develop/images/DATA.png)|DATA|Data PID.|
|![Data carousel](~/develop/images/DATACAROUSEL.png)|DATACAROUSEL|Data carousel.|
|![Device](~/develop/images/Device.png)|Device|Device.|
|![Direct connection](~/develop/images/DirectConnection.png)|DirectConnection|Direct connection.|
|![DVBS card](~/develop/images/DVBSCard.png)|DVBSCard|DVBS card.|
|![ECM](~/develop/images/ECM.png)|ECM|Contains encrypted key for EMM.|
|![EIT](~/develop/images/EIT.png)|EIT|Event Information Table.|
|![EMM](~/develop/images/EMM.png)|EMM|Encrypted Message.|
|![Fixed input](~/develop/images/FixedInput.png)|FixedInput|Fixed input.|
|![Fixed output](~/develop/images/FixedOutput.png)|FixedOutput|Fixed output.|
|![GBE port](~/develop/images/GBEPort.png)|GBEPort|GBE port.|
|![General](~/develop/images/General.png)|General|General|
|![General input](~/develop/images/GeneralInput.png)|GeneralInput|General input.|
|![General PID](~/develop/images/GeneralPID.png)|GeneralPID|General PID.|
|![General service](~/develop/images/GeneralService.png)|GeneralService|General service.|
|![General transport stream](~/develop/images/GeneralTransportStream.png)|GeneralTransportStream|Obsolete: Use GT instead.|
|![General transport stream](~/develop/images/GT.png)|GT|General transport stream|
|![IDP not OK](~/develop/images/IDP-NOK.png)|IDP-NOK|IDP not OK.|
|![IDP OK](~/develop/images/IDP-OK.png)|IDP-OK|IDP OK.|
|![IDP-Running](~/develop/images/IDP-Running.png)|IDP-Running|IDP running.|
|![IDP-Unknown](~/develop/images/IDP-Unknown.png)|IDP-Unknown|IDP unknown.|
|![Input](~/develop/images/Input.png)|Input|Input.|
|![Input and output](~/develop/images/InputAndOutput.png)|InputAndOutput|Input and output.|
|![Input transport stream](~/develop/images/InputTransportStream.png)|InputTransportStream|Input transport stream.|
|![Blue LED](~/develop/images/LED-Blue.png)|LED-Blue|Blue LED. <!-- RN 28566 -->|
|![Cyan LED](~/develop/images/LED-Cyan.png)|LED-Cyan|Cyan LED.<!-- RN 28566 -->|
|![Lime green LED](~/develop/images/LED-Lime.png)|LED-Lime|Lime green LED.<!-- RN 28566 -->|
|![Red LED](~/develop/images/LED-Red.png)|LED-Red|Red LED.<!-- RN 28566 -->|
|![Silver LED](~/develop/images/LED-Silver.png)|LED-Silver|Silver LED.<!-- RN 28566 -->|
|![Yellow LED](~/develop/images/LED-Yellow.png)|LED-Yellow|Yellow LED.<!-- RN 28566 -->|
|![Main](~/develop/images/Main.png)|Main|Main (See also “Backup”)|
|![Matrix](~/develop/images/Matrix.png)|Matrix|Matrix.|
|![MIP](~/develop/images/MIP.png)|MIP|MIP.|
|![MPE](~/develop/images/MPE.png)|MPE|MPE.|
|![Audio PID](~/develop/images/MPEG2_AUDIO.png)|MPEG2_AUDIO|Audio PID.|
|![Video PID](~/develop/images/MPEG2_VIDEO.png)|MPEG2_VIDEO|Video PID.|
|![New item](~/develop/images/newItem.png)|New-Item|New item.<!-- RN 28060 -->|
|![Network Information Table](~/develop/images/NIT.png)|NIT|Network Information Table: Info about muxes and TS, private stream info, e.g. Teletext.|
|![Object carousel](~/develop/images/OBJECTCAROUSEL.png)|OBJECTCAROUSEL|Object carousel.|
|![Output](~/develop/images/Output.png)|Output|Output.|
|![Output Transport Stream](~/develop/images/OutputTransportStream.png)|OutputTransportStream|Output Transport Stream.|
|![Program Association Table](~/develop/images/PAT.png)|PAT|Program Association Table: All programs available in TS.|
|![Program Clock Reference](~/develop/images/PCR.png)|PCR|Program Clock Reference.|
|![PD](~/develop/images/PD.png)|PD|PD.|
|![Packetized elementary stream](~/develop/images/PES.png)|PES|Packetized elementary stream.|
|![Program Map Table](~/develop/images/PMT.png)|PMT|Program Map Table: Info about program.|
|![Primary](~/develop/images/Primary.png)|Primary|Primary (See also “Secondary”)|
|![Processor](~/develop/images/Processor.png)|Processor|Processor.|
|![Radio](~/develop/images/RADIO.png)|RADIO|Service of type Radio.|
|![Rectangle](~/develop/images/RECT-AliceBlue.png)|RECT-\[ColorName\]|Filled rectangle, where \[ColorName\] is a color name (e.g. RECT-AliceBlue). For a full list of the available color names, refer to <https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=netframework-4.8>.|
|![RST](~/develop/images/RST.png)|RST|RST.|
|![Satellite](~/develop/images/Satellite.png)|Satellite|Satellite.|
|![Service Description Table](~/develop/images/SDT.png)|SDT|Service Description Table.|
|![Secondary](~/develop/images/Secondary.png)|Secondary|Secondary (See also “Primary”)|
|![SI](~/develop/images/SI.png)|SI|SI.|
|![Empty storage cell](~/develop/images/StorageCellEmpty.png)|StorageCellEmpty|Empty storage cell.|
|![Full storage cell](~/develop/images/StorageCellFull.png)|StorageCellFull|Full storage cell.|
|![Storage tape](~/develop/images/StorageTape.png)|StorageTape|Storage tape.|
|![Subtitle](~/develop/images/SUBTITLE.png)|SUBTITLE|Subtitle.|
|![Time and date Table](~/develop/images/TDT.png)|TDT|Time and date Table.|
|![Teletext PID](~/develop/images/TELETEXT.png)|TELETEXT|Teletext PID.|
|![Transponder](~/develop/images/Transponder.png)|Transponder|Transponder.|
|![Leased transponder](~/develop/images/TransponderLeased.png)|TransponderLeased|Leased transponder.|
|![Trash can](~/develop/images/Trash.png)|Trash|Trash can.<!-- RN 28060 -->|
|![Service of type Television](~/develop/images/TV.png)|TV|Service of type Television.|
|![Unknown](~/develop/images/Unknown.png)|Unknown|Unknown.|
|![VSAT](~/develop/images/VSAT.png)|VSAT|VSAT.|

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

---
uid: Protocol.Params.Param.Dashboard
---

# Dashboard element

Specifies the configuration for use in dashboards.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Dashboard.Type)|[0, 1]|Indicates the type of button panel.|
|&nbsp;&nbsp;[DashboardOptions](xref:Protocol.Params.Param.Dashboard.DashboardOptions)||Groups the options that will determine how the button panel is displayed.|

## Remarks

*Feature introduced in DataMiner 9.6.11 (RN 22855, RN 22874, RN 22875, RN 23080, RN 23084, RN 23097, RN 23103, RN 23173, RN 23176, RN 23245, RN 23249, RN 23281, RN 23293).*

> [!NOTE]
> From DataMiner 10.0.3 to DataMiner 10.3.9/10.4.0, the button panel component is only available in soft launch. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

## Examples

```xml
<Param id="100">
   <Name>mainButtonPanel</Name>
   <Description>Main Button Panel</Description>
   <Type>array</Type>
   <ArrayOptions index="0" options=";naming=/101,102">
      <ColumnOption idx="0" pid="101" type="retrieved" options=""/>
      <ColumnOption idx="1" pid="102" type="retrieved" options=";save" />
      <ColumnOption idx="2" pid="103" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="104" type="retrieved" options=";save" />
      <ColumnOption idx="4" pid="105" type="retrieved" options=";save" />
      <ColumnOption idx="5" pid="106" type="retrieved" options=";save" />
      <ColumnOption idx="6" pid="107" type="retrieved" options=";save" />
      <ColumnOption idx="7" pid="108" type="retrieved" options=";save" />
      <ColumnOption idx="8" pid="109" type="retrieved" options=";save" />
      <ColumnOption idx="9" pid="110" type="retrieved" options=";save" />
      <ColumnOption idx="10" pid="111" type="retrieved" options=";save;foreignKey=200" />
      <ColumnOption idx="11" pid="112" type="retrieved" options=";save" />
      <ColumnOption idx="12" pid="139" type="retrieved" options="" />
      <ColumnOption idx="13" pid="140" type="displaykey" options="" />
   </ArrayOptions>
   <Dashboard>
      <Type>button panel</Type>
      <DashboardOptions>
         <DashboardOption type="idx" name="panelButtonName">1</DashboardOption>
         <DashboardOption type="idx" name="xpos">3</DashboardOption>
         <DashboardOption type="idx" name="ypos">4</DashboardOption>
         <DashboardOption type="idx" name="height">5</DashboardOption>
         <DashboardOption type="idx" name="width">6</DashboardOption>
         <DashboardOption type="idx" name="panelButtonType">8</DashboardOption>
         <DashboardOption type="idx" name="advancedLayout">9</DashboardOption>
         <DashboardOption type="pid" name="panelAdvancedLayout">147</DashboardOption>
         <DashboardOption type="pid" name="css">148</DashboardOption>
         <DashboardOption type="idx" name="container">10</DashboardOption>
         <DashboardOption type="pid" name="activeContainer">149</DashboardOption>
         <DashboardOption type="idx" name="panelButtonPossibleOperations">11</DashboardOption>
         <DashboardOption type="idx" name="panelButtonOperation">12</DashboardOption>
      </DashboardOptions>
   </Dashboard>
</Param>
```

---
uid: ConnectorsVisChainsFields
---

# Visibility of chains and fields

Within the EPM Manager connector, it is possible to configure the visibility of a chain or a field.

To enable this functionality:

- Add a `<display>` tag within the corresponding chain or field.
- Create a read-write parameter for each chain or field. This parameter will make it possible to configure the visibility of these items when necessary.

## Example parameter

```xml
   <Param id="301" trending="false" save="true">
      <Name>chainVisibilityCustomer</Name>
      <Description>Customer Topology</Description>
      <Type>read</Type>
      <Information>...</Information>
      <Interprete>...</Interprete>
      <Display>...</Display>
      <Measurement>
         <Type>discreet</Type>
         <Discreets>
            <Discreet>
               <Display>Disabled</Display>
               <Value>1</Value>
            </Discreet>
            <Discreet>
               <Display>Enabled</Display>
               <Value>2</Value>
            </Discreet>
         </Discreets>
      </Measurement>
   </Param>
   <Param id="351" setter="true">
      <Name>chainVisibilityCustomer</Name>
      <Description>Customer Topology</Description>
      <Type>write</Type>
      <Interprete>...</Interprete>
      <Display>...</Display>
      <Measurement>
         <Type>togglebutton</Type>
         <Discreets>
            <Discreet>
               <Display>Disabled</Display>
               <Value>1</Value>
            </Discreet>
            <Discreet>
               <Display>Enabled</Display>
               <Value>2</Value>
            </Discreet>
         </Discreets>
      </Measurement>
   </Param>
```

## Example chain

```xml
<Chain name="Customer Topology">
    <Display>
        <Visibility default="true">
            <Standalone pid="301">
                <Value>1</Value>
            </Standalone>
        </Visibility>
    </Display>
    <Field name="Customer" options="displayInFilter;showCPEChilds;ignoreEmptyFilterValues;tabs:3500-KPI;details:3500;ShowBubbleupAndInstanceAlarmLevel" pid="3502">
        <Display>
            <Selection>
                <Visibility default="true">
                    <Standalone pid="308">
                        <Value>1</Value>
                    </Standalone>
                </Visibility>
            </Selection>
        </Display>
    </Field>
    <Field name="Device" options="displayInFilter;ignoreEmptyFilterValues;tabs:2500-KPI;details:2500;ShowBubbleupAndInstanceAlarmLevel" pid="2501">
        <Display>
            <Selection>
                <Visibility default="true">
                    <Standalone pid="310">
                        <Value>1</Value>
                    </Standalone>
                </Visibility>
            </Selection>
        </Display>
    </Field>
</Chain>
```

### Chain configuration

| Tag            | Attribute | Description                                                                                                                                       |
|----------------|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------|
| `<Visibility>` | `default` | Specifies if the chain or field should be displayed by default (`true` or `false`).                                                               |
| `<Standalone>` | `pid`     | Specifies the ID of the configurable parameter linked to toggle visibility.                                                                       |
| `<Value>`      |           | Defines one of the possible values the parameter must have to toggle the visibility to the opposite setting in relation to the default attribute. |

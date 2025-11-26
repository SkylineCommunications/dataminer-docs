---
uid: UIComponentsDropDownList
---

# Dropdown list

## Creating a dropdown list

A dropdown list is a control that allows the user to choose one value from a list.

To define a dropdown list, create a parameter of type "write", set type to "discreet" and provide a list of discrete values.

```xml
<Param id="3105">
  <Name>ethernetLinkMgmtSpeed</Name>
  <Description>Link Speed</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet>
        <Display>All</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>10 Bt Half Duplex</Display>
        <Value>1</Value>
      </Discreet>
      <Discreet>
        <Display>10 Bt Full Duplex</Display>
        <Value>2</Value>
      </Discreet>
      <Discreet>
        <Display>100 Bt Half Duplex</Display>
        <Value>3</Value>
      </Discreet>
      <Discreet>
        <Display>100 Bt Full Duplex</Display>
        <Value>4</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
<Param id="3135" setter="true">
  <Name>ethernetLinkMgmtSpeed</Name>
  <Description>Link Speed</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet>
        <Display>All</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>10 Bt Half Duplex</Display>
        <Value>1</Value>
      </Discreet>
      <Discreet>
        <Display>10 Bt Full Duplex</Display>
        <Value>2</Value>
      </Discreet>
      <Discreet>
        <Display>100 Bt Half Duplex</Display>
        <Value>3</Value>
      </Discreet>
      <Discreet>
        <Display>100 Bt Full Duplex</Display>
        <Value>4</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![DataMiner Cube Dropdown List UI Component](~/develop/images/uidropdownlist.png)

## Creating a dropdown list with a checkbox

When you add a dropdown list, it is possible to show a checkbox for one entry by using the state attribute and setting its value to disabled. Note that the corresponding read parameter should interpret this as an exceptional value.

```xml
<Param id="1032">
  <Name>OutputFormat</Name>
  <Description>Output Format</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>signed number</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
    <Exceptions>
      <Exception id="1" value="0">
        <Display state="disabled">Disabled</Display>
        <Value>0</Value>
      </Exception>
    </Exceptions>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet>
        <Display state="disabled">None</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>720p</Display>
        <Value>1</Value>
      </Discreet>
      <Discreet>
        <Display>1080p</Display>
        <Value>2</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
<Param id="1033" setter="true">
  <Name>OutputFormat</Name>
  <Description>Output Format</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet>
        <Display state="disabled">Disabled</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>720p</Display>
        <Value>1</Value>
      </Discreet>
      <Discreet>
        <Display>1080p</Display>
        <Value>2</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![DataMiner Cube dropdown list with checkbox](~/develop/images/uidropdownlistwithcheckbox.png)

## Creating a dynamic dropdown list

When a standard dropdown list is configured, the items to choose from are statically defined in the protocol. Alternatively, you can also create a dynamic dropdown list. To do so, create a parameter that holds the dynamic entries in a parameter (by providing a semicolon-separated list of entries) and refer to this parameter using the dependencyId attribute.

```xml
<Param id="400" trending="false">
  <Name>DynamicDependencyLinkSpeed</Name>
  <Description>Link Speed</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>string</Type>
  </Measurement>
</Param>
<Param id="401" setter="true">
  <Name>DynamicDependencyLinkSpeed</Name>
  <Description>Link Speed</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets dependencyId="402" />
  </Measurement>
</Param>
<Param id="402" trending="false">
  <Name>DynamicDependencyValuesLinkSpeed</Name>
  <Description>Dynamic Dependency Values Link Speed</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
    <DefaultValue>10 Bt Half Duplex;10 Bt Full Duplex;100 Bt Half Duplex;100 Bt Full Duplex</DefaultValue>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>string</Type>
  </Measurement>
</Param>
```

![DataMiner Cube dynamic dropdown list](~/develop/images/uidropdownlistdynamic.png)

This also works for tables (from DataMiner 8 onwards (RN 5817)). It is not only possible to refer to a standalone parameter, another column of the same table can also be specified. This makes it possible to have a list of different items for every row.

> [!NOTE]
> The column that is referred to by the dependencyId attribute must be displayed in the table.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type: discreet](xref:Protocol.Params.Param.Measurement.Type#discreet)
- [Protocol.Params.Param.Measurement.Discreets](xref:Protocol.Params.Param.Measurement.Discreets)
- [Protocol.Params.Param.Measurement.Discreets.Discreet@dependencyId](xref:Protocol.Params.Param.Measurement.Discreets-dependencyId)

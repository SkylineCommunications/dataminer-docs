---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet-dependencyValues
---

# dependencyValues attribute

When the parameter depends on the current value of another parameter, dependencyValues can be used to specify whether the discreet value should be available.

## Content Type

string

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Remarks

If the other parameter has one of the values specified in the attribute, the discreet will be displayed, otherwise it will not.

- All the discreets must have a dependencyValues attribute, or the discreet will never be shown.
- Multiple entries can be provided in the dependencyValues attribute, separated by a semicolon.
- This will use the displayed value and not the value in case it is linked to another discreet.
- The dependencyValues attribute can be combined with the table:selection and table:singleselection options.

When the value of the parameter with ID 55 is equal to A, the discreet "Display 1" will be available. When it is equal to B, the discreet "Display 2" will be available:

```xml
<Measurement>
    <Type>discreet</Type>
    <Discreets dependencyId="55">
        <Discreet dependencyValues="A">
            <Display>Display 1</Display>
            <Value>1</Value>
        </Discreet>
        <Discreet dependencyValues="B">
            <Display>Display 2</Display>
            <Value>2</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

This does not work for tables. However, there is one exception. When the column is exported to a DVE as a single parameter and the parameter used for the dependencyId is also exported, it can also be an exported column from a table.

> [!NOTE]
> The parameter using the dependency needs to be of type write.

In case of a ContextMenu parameter (of which the name is identical to that of the table with "_ContextMenu" suffix), the dependencyValues will first ask the user to enter the value of each parameter specified in this attribute.

```xml
<Param id="1000" trending="false">
    <Name>tblSites</Name>
    <Type>array</Type>
    ...
```

In the following example, after a right click in the table with parameter ID 1000, the values for column parameter ID 1001, 1002 and 1003 need to be filled in. A QAction can be defined to for example capture these values and add a row. Feature introduced in DMA v8.0.2.3 (RN 5967).

```xml
<Param id="1099">
    <Name>tblSites_ContextMenu</Name>
    <Type>write</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>discreet</Type>
        <Discreets>
            <Discreet dependencyValues="1001;1002;1003">
                <Display>Add new row...</Display>
                <Value>add</Value>
            </Discreet>
        </Discreets>
    </Measurement>
</Param>
```

In the dependencyValues attribute of a menu item, you can specify the following:

|Option|Description
|--- |--- |
|1005|The user MUST enter a value using (write) parameter 1005.|
|1005?|The user CAN enter a value using (write) parameter 1005.|
|1005:default|The user MUST enter a value using (write) parameter 1005, and a default value is specified. `<default>` represents either a fixed value (e.g. 1005:10) or uses a placeholder (See [Placeholders](xref:UIComponentsCustomTableContextMenu#placeholders) for more information about the available placeholders) (e.g. 1005:[value:1005]).|
|1005?:default|The user CAN enter a value using (write) parameter 1005, and a default value is specified. `<default>` represents either a fixed value (e.g. 1005?:10) or uses a placeholder (See [Placeholders](xref:UIComponentsCustomTableContextMenu#placeholders) for more information about the available placeholders) (e.g. 1005?:[value:1005]).|

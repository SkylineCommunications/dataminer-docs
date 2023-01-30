---
uid: AdvancedEPMLaunchEPMObjectsTableCellButtons
---

# Launching EPM objects by clicking buttons in Data Display table cells

Starting from DataMiner 10.2.3 (RN 32368), a different way of adding links to EPM objects in a Data Display table is supported.

When you configure a cell button in a protocol as shown below, the table cell will display the SystemType and SystemName defined in the EPM object. Clicking the link will open a new card for that object.

Example:

```xml
<Measurement>
    <Type>button</Type>
    <Discreets>
        <Discreet>
            <Display>{linkedItemName}</Display>
            <Value type="open">{pid:530}</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

The discreet value can contain the SystemType and SystemName of the object, or a reference like “{pid:530}”. In the example above, the identifier is stored in the column with parameter ID 530, which can be the read parameter of the same column or a different column.

If you know the type of the EPM object, you can add a type prefix ("epm" or "view"), followed by an equal sign and (a reference to) the identifier.

The `<Display>` tag of the discreet can contain the same references as the `<Value>` tag. One extra keyword is possible (and recommended): `{linkedItemName}`. This keyword will be replaced with the name of the object referred to in the `<Value>` tag.

If you want to specify the page to be selected by default, add a suffix to the identifier in the `<Value>` tag containing the root page name and the page name, separated by a colon. See the following examples:

- EPM=Cable/SF Cable1:Topology:Total
- VIEW=436:BelowThisObject:STB
- VIEW=436:BelowThisView:Elements

In each of the examples above, the card will be opened on a particular page:

- “Topology:Total” or “t:Total” will open the topology page named “Total”.
- “BelowThisObject:STB” or “bto:STB” will open the CPE card page named “STB”.
- “BelowThisView:Elements” or “btv:Elements” will open the view card page named “Elements”.

> [!NOTE]
> From DataMiner 10.2.3 onwards, EPM cards can be saved in workspaces; however, this is only supported when the card layout is set to “Tab layout”.

Starting from DataMiner 10.2.6 (RN 33295), if the SystemName contains colons (e.g. a MAC address), you can replace the default separator (i.e. a colon) by another one (e.g. a pipe character) by placing a `[sep:XY]` prefix in front of the SystemName. See the following example:

```xml
<Value type="open">{EPM=[sep::|]CPE/'00:01:08:01:08:01|DATA|CPE Frequencies}</Value>
```

From DataMiner 10.2.9 onwards (RN 33857), you can specify a second custom separator to also replace the existing separator inside the SystemType and/or SystemName. Since the default separator between the SystemType and the SystemName is "/", this would mean that neither the systemType nor the SystemName would be allowed to contain that character ("/").

In the following example, a second [sep:XY] is used to replace the "/" inside the SystemType ("CPE/CPE") with another character ("$").

```xml
<Value type="open">{EPM=[sep::|][sep:/$]CPE/CPE$00:01:08:01:08:01|DATA|CPE Frequencies}</Value>
```

In short,

- the first `[sep:XY]` will replace the separator between the arguments, and
- the second `[sep:XY]` will replace the separator inside the SystemType and/or SystemName.

> [!NOTE]
> If you want to replace the separator inside the name, you must specify both the first `[sep:XY]` and the second `[sep:XY]`, even if there are no arguments.

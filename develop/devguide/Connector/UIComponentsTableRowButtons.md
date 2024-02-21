---
uid: UIComponentsTableRowButtons
---

# Configuring buttons to open DataMiner objects from table cells

From DataMiner 10.1.9 (RN 30413) onwards, it is possible open elements, services, redundancy groups and views by clicking buttons in Data Display table cells.

For this purpose, the cell button must be configured as illustrated below. The table cell will then display an icon that includes the severity and, if necessary, the name. Clicking the link will open the linked object in a new card.

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

The "discreet" value can contain the name or the ID of the object, or a reference like "{pid:530}". In the example above, the identifier is stored in the column with parameter ID 530, which can be the read parameter of the same column or a different column.

If you know the type of the object, you can add a type prefix (element, redundancygroup, view or service), followed by an equals sign and (a reference to) the identifier. If you refer to the name of the object, it is recommended to use "element=", as an element can have the same name as a view.

The `<Display>` tag of the discreet can contain the same references as the `<Value>` tag. One extra keyword is possible (and recommended): {linkedItemName}. This keyword will be replaced with the name of the object referred to in the `<Value>` tag.

If you want to specify the page to be selected by default, add a suffix to the identifier in the `<Value>` tag containing the root page name and the page name, separated by a colon. For example:

- element=MyElementName:Data:Performance
- 212/13:Visual:MyVisioPage

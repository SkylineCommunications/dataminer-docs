---
uid: Icons
---

# Icons

The `C:\Skyline DataMiner\Icons\` directory contains any custom icons that have been configured for elements, services, redundancy groups and views, as well as rules that dictate when they should be displayed.

The icons and the icon rules are specified in the following XML files:

- `C:\Skyline DataMiner\Icons\CustomIcons.xml`

- `C:\Skyline DataMiner\Icons\IconSelectionRules.xml`

> [!NOTE]
>
> - If you have made any changes to these files, restart DataMiner to implement your changes.
> - This file is only synchronized in a DMS during the midnight sync or if a [synchronization is forced](xref:Synchronizing_data_between_DataMiner_Agents). It does not get synchronized instantly or on startup.

## CustomIcons.xml

In the *CustomIcons.xml* file, each *\<Icon>* tag can either contain XAML code or refer to an image file located in the folder `C:\Skyline DataMiner\Icons\Refs\`. See the following example.

```xml
<Icons>
  <Icon key="aUniqueKey" ref="icon1.png" theme="light" />
  <Icon key="anotherUniqueKey" theme="dark">
    <![CDATA[myXamlCode]]>
  </Icon>
</Icons>
```

The icon tag can have the following attributes:

- **key**: Unique identifier of the icon within a particular theme.

- **ref**: Name of the image file, which must be located in the folder `C:\Skyline DataMiner\Icons\Refs\`.

  - Preferred format: PNG. SVG is also supported
  
  - Size: 16x16 px

- **theme**: Theme to which the icon belongs:

  - dark (default theme; can also be referred to with “black”)
  
  - light (can also be referred to with “white”)

> [!NOTE]
> If both XAML code and an image file are available for the same icon, the XAML code will be used.

## IconSelectionRules.xml

In the *IconSelectionRules.xml* file, you can specify when the icons defined in *CustomIcons.xml* have to be used. See the following example.

```xml
<Rules>
  <SelectIcon type="element" key="aUniqueKey">
    <When>
      <Field type="property" name="status" value="^regex^^.*in use.*$" />
      <Field type="operator" operator="and" />
      <Field type="protocol" value="Microsoft Platform" />
    </When>
  </SelectIcon>
  <SelectIcon type="element" key="anotherUniqueKey">
    <When>
      <Field type="property" name="status" value="idle" />
    </When>
  </SelectIcon>
  <SelectIcon type="element" key="timeout" layer="overlay">
    <When>
      <Field type="property" name="connection status" value="not connected" />
    </When>
  </SelectIcon>
</Rules>
```

The following tags and attributes are available:

### SelectIcon tag

Attributes:

- **type**: The type of object to which the icon applies: “element”, “service”, “redundancy”, or “view”.

- **key**: The key of the icon as defined in *CustomIcons.xml*.

- **layer**: The layer (optional, in case of multiple layers)

  > [!NOTE]
  > To determine which icon is displayed for a particular object, in case of multiple layers, the rules that apply to the same object type are checked from top to bottom. For each layer, the first matching icon is added to the object.

### Field tag

Attributes:

- **type**: The type of field within the rule: “operator”, “name”, “property”, “elementtype”, “protocol”, or “functionguid”.

  > [!NOTE]
  > - “elementtype” can only be used if SelectIcon type is “element”.
  > - “protocol” can only be used if SelectIcon type is “element” or “service” and if the element or service has a protocol assigned.
  > - “functionguid” allows icons to be configured for specific elements linked to protocol functions.

- **operator**: If field type is “operator”, field operator can be set to “)”, “(“, “and”, “or”, or “not”.

- **name**: If field type is “property”, field name must contain the property name.

- **value**: The value to be checked:

  - A fixed value
  
  - A value with \* and ? wildcards
  
  - A regular expression (syntax identical to that of the regular expressions used in service template definitions)
  
    > [!NOTE]
    > In case of values with wildcards or regular expressions, a full match is expected. Example: “A?C” will not match “XXX.ABC.YYY”

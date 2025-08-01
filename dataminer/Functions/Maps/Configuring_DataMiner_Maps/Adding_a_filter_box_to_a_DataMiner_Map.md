---
uid: Adding_a_filter_box_to_a_DataMiner_Map
---

# Adding a filter box to a DataMiner Map

In a DataMiner Maps configuration file, you can specify that a filter box should be displayed on a DataMiner Map.

## Filtering on name

If you want the map to contain a filter box that allows users to filter map items based on their name, then add a simple `<FilterBox>` tag as shown in the following example:

```xml
<MapConfig ...>
  ...
  <FilterBox visible="true" />
  ...
</MapConfig>
```

## Filtering on alarm severity

If you want the map to contain a filter box that allows users to filter map items based on their alarm severity level, then add a `<FilterBox>` tag that contains a checkbox for every alarm severity level:

```xml
<MapConfig ...>
  ...
  <FilterBox visible="true">
    <CheckBoxes>
      <CheckBox alarmLevel="Normal" name="connected" />
      <CheckBox alarmLevel="Critical" name="not connected" />
      <CheckBox alarmLevel="Undefined" name="unknown" />
    </CheckBoxes>
  </FilterBox>
  ...
</MapConfig>
```

Every `<CheckBox>` tag has to have the following attributes:

- **alarmLevel**: The default name of the DataMiner alarm severity.
- **name**: The name of the severity that has to appear in the filter box.
- **checked**: Determines whether the checkbox is selected or cleared by default. Possible values: true or false. If this attribute is not specified for a checkbox, that checkbox will be selected by default. Available from DataMiner 10.1.9/10.2.0 onwards.

## Configuring auto-zoom upon filtering

To make a map automatically zoom to its maximum level (keeping all markers visible) when a user enters a value in the filter box, add the attribute autoFit in the `<FilterBox>` tag and set it to "true".

For example:

```xml
<FilterBox visible="true" autoFit="true">
  <CheckBoxes>
    <CheckBox alarmLevel="Normal" name="connected" />
    <CheckBox alarmLevel="Critical" name="not connected" />
    <CheckBox alarmLevel="Undefined" name="undefined" />
  </CheckBoxes>
</FilterBox>
```

## Specifying the location of a filter box

It is possible to specify the exact location of a filter box on a map. To do so, you must specify the *closeable* attribute in the FilterBox tag, and specify a *Location* subtag.

For example:

```xml
<FilterBox visible="true" autoFit="true" closeable="false">
  <Location bottom="50px" left="10px" />
</FilterBox>
```

### closeable attribute

When *closeable* is set to "false", the filter box will always be displayed, and users will not be able to close it.

Default: closeable="true"

### Location tag

In the *Location* tag, you can specify the exact location of the filter box on the map.

Typically, only two distances need to be specified. You can for example specify top and left, bottom and left, top and right, or bottom and right.

If you specify a location, the filter box will always appear at that same location, even when the browser window is resized.

Default: top="10px" left="0"

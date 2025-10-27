---
uid: PropertyConfiguration_xml
---

# PropertyConfiguration.xml

In the *PropertyConfiguration.xml* file, you can define custom properties to be linked to elements, parameters and alarms.

- This file is located in the following folder: `C:\Skyline DataMiner\`

Several custom options can be configured in this file:

- [Customizing how properties are displayed in the Surveyor](#customizing-how-properties-are-displayed-in-the-surveyor)

- [Configuring alarm properties to motivate actions](#configuring-alarm-properties-to-motivate-actions)

- [Configuring properties for Alarm Console grouping](#configuring-properties-for-alarm-console-grouping)

- [Disabling alarm updates for changes of read-only alarm properties](#disabling-alarm-updates-for-changes-of-read-only-alarm-properties)

- [Having a property value copied to an alarm field](#having-a-property-value-copied-to-an-alarm-field)

## Customizing how properties are displayed in the Surveyor

If, while creating or editing a property, you select *Display this property in the Surveyor*, the property will be displayed next to the item in the Surveyor in the format *\[Property name\]*: *\[Property value\]*.

However, it is possible to have only the property values displayed instead, by customizing the configuration in *PropertyConfiguration.xml*.

To do so:

1. Stop the DMA.

1. Open the file *PropertyConfiguration.xml*.

1. In the main *\<PropertyConfiguration>* tag, add the attribute *surveyorMode="ValueOnly"*.

   For example:

   ```xml
   <PropertyConfiguration xmlns="http://www.skyline.be/config/propertyconfiguration" surveyorMode="ValueOnly">
   ```

1. Start the DMA.

> [!TIP]
> See also: [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item)

## Configuring alarm properties to motivate actions

If you define an alarm property, you can specify that users have to motivate their intention to take a particular alarm action (mask, unmask, clear, etc.). For more information, see [Enforcing motivation of alarm actions](xref:Enforcing_motivation_of_alarm_actions).

## Configuring properties for Alarm Console grouping

If property columns are added for service or view properties in the Alarm Console, and an alarm affects more than one service or view, this can result in multiple comma-separated property values in the property columns in the Alarm Console. When you apply grouping in the Alarm Console based on property columns, by default such an entry with multiple property values is taken as a whole for the grouping.

However, it is possible to configure alarm properties so that a group is created per value in the column, and the alarm is added to each of the groups.

To do so:

1. Open the file `C:\Skyline DataMiner\PropertyConfiguration.xml`.

1. In the XML file, define a *contentDescription* and *contentSeparator* attribute for each relevant property:

   - **contentDescription**: Describes the content of the property field. Configure this attribute using letters separated by the separator defined in *contentSeparator*.

     The number of letters specified should be equal to the maximum number of different property values that could occur for this property. For example, if you specify `a,b,c,d,e,f`, up to 6 property values can be displayed, separated by a comma. If there are more property values than specified in *contentDescription*, the last specified item will contain all the following values as well.

   - **contentSeparator**: Describes the separator used for different property values. Set this attribute to the separator used in *contentDescription*.

     > [!NOTE]
     > As soon as a *contentSeparator* has been specified for a particular property in *PropertyConfiguration.xml*, duplicate and empty values will no longer be displayed in the corresponding property column.

   Example:

   ```xml
   <Property id="36" type="Service" name="Class" filterEnabled="true" visibleInSurveyor="false" contentSeparator=";" contentDescription="a;b;c">
     <Entry metric="0">Gold</Entry>
     <Entry metric="0">Silver</Entry>
     <Entry metric="0">Bronze</Entry>
   </Property>
   ```

1. If the DMA is part of a cluster of several DMAs, force a synchronization of the file *PropertyConfiguration.xml* throughout your DataMiner System:

   1. In DataMiner Cube, go to *Apps* > *System Center*.

   1. Go to the *Tools* tab and select *synchronization*.

   1. In the drop-down list next to *Type*, select *File*.

   1. In the *File* box, specify the following path: `C:\Skyline DataMiner\PropertyConfiguration.xml`.

   1. Click the *Sync now* button.

1. Restart DataMiner.

## Disabling alarm updates for changes of read-only alarm properties

In a DataMiner protocol, a property can be configured on a parameter to get its value from another parameter in that same protocol. This property will then be available as a read-only property in the system.

To disable alarm updates on changes of such a read-only property:

1. Open the file `C:\Skyline DataMiner\PropertyConfiguration.xml`.

1. In the XML file, set the attribute *doUpdateAlarmOnValueChange* for the relevant property to `false`.

   For example:

   ```xml
   <Property type="Alarm" name="Hidden" readOnly="true" filterEnabled="true" doUpdateAlarmOnValueChange="false" id="19"/>
   ```

1. If the DMA is part of a cluster of several DMAs, force a synchronization of the file *PropertyConfiguration.xml* throughout your DataMiner System:

   1. In DataMiner Cube, go to *Apps* > *System Center*.

   1. Go to the *Tools* tab and select *synchronization*.

   1. In the drop-down list next to *Type*, select *File*.

   1. In the *File* box, specify the following path: `C:\Skyline DataMiner\PropertyConfiguration.xml`.

   1. Click the *Sync now* button.

1. Restart DataMiner.

## Having a property value copied to an alarm field

It is possible to have the value of a property that is available for an alarm copied to a predefined field of the alarm (i.e. the *Owner*, *Comment*, *Element Name*, or *Parameter Name* field) or to another property.

To do so:

1. Open the file `C:\Skyline DataMiner\PropertyConfiguration.xml`.

1. In the *XML* file, add the *copyToAlarmField* attribute to the *Property* tag of the property that needs to be copied, and set it to the correct keyword:

   | Field                        | Keyword                   |
   |--------------------------------|---------------------------|
   | Comment                        | \[COMMENT\]               |
   | Element Name                   | \[ENAME\]                 |
   | Owner                          | \[OWNER\]                 |
   | Parameter Name                 | \[PNAME\]                 |
   | Alarm property called "name"   | \[PROPERTY:ALARM:name\]   |
   | Element property called "name" | \[PROPERTY:ELEMENT:name\] |
   | Service property called "name" | \[PROPERTY:SERVICE:name\] |
   | View property called "name"    | \[PROPERTY:VIEW:name\]    |

   For example:

   ```xml
   <Property id="21" type="Element" name="Location" copyToAlarmField="[ENAME]" />
   ```

1. If the DMA is part of a cluster of several DMAs, force a synchronization of the file *PropertyConfiguration.xml* throughout your DataMiner System:

   1. In DataMiner Cube, go to *Apps* > *System Center*.

   1. Go to the *Tools* tab and select *synchronization*.

   1. In the drop-down list next to *Type*, select *File*.

   1. In the *File* box, specify the following path: `C:\Skyline DataMiner\PropertyConfiguration.xml`.

   1. Click the *Sync now* button.

1. Restart DataMiner.

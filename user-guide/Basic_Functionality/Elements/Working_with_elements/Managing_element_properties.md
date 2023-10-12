---
uid: Managing_element_properties
---

# Managing element properties

## Accessing element properties

To access the properties of an element:

1. Right-click the element in the Surveyor or on the *Elements* page of a view card.

1. Select *Properties*.

   The *Properties* window will open, with a separate tab for general and for custom properties.

> [!NOTE]
> To access properties of views and services, you can also use the Surveyor right-click menu.

## Adding a custom property to an item

> [!TIP]
> See also: [DataMiner Cube – Adding properties to elements, views and services](https://community.dataminer.services/video/dataminer-cube-adding-properties-to-elements-views-and-services/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

To add a custom property to a DataMiner item, which can be an element, but also a service, a view, or an alarm:

1. Right-click the item and select *Properties*.

1. In the *Properties* dialog box, go to the *Custom* tab.

1. Click the cogwheel button in the lower left corner, and select *Add*.

1. Enter a name for the custom property.

1. Specify the following options:

   - **Make this property available for alarm filtering**: Select this checkbox if you want the property to be used in the Alarm Console, in filters and in Correlation rules.

     > [!NOTE]
     > This option is not available for alarm properties, as these are always available for alarm filtering.

   - **Display this property in the Surveyor**: Select this checkbox if you want the property to be visible next to the DataMiner item in the Surveyor.

     > [!NOTE]
     >
     > - By default, the property will be displayed next to the item in the Surveyor in the format *\[Property name\]*: *\[Property value\]*. However, it is possible to configure the DMA to display only the property value. See [Customizing how properties are displayed in the Surveyor](xref:PropertyConfiguration_xml#customizing-how-properties-are-displayed-in-the-surveyor).
     > - From DataMiner 10.0.12 onwards, properties can also be displayed for views in the Surveyor of the Monitoring app.

   - **Update alarms on value changed**: If you want alarms to be updated when the value of the property changes, make sure this option is selected; otherwise make sure this checkbox is cleared.

     > [!NOTE]
     > This option is available from DataMiner 9.5.12 onwards, if *Make this property available for alarm filtering* is selected. However, note that in some cases a protocol may contain read-only properties. Disabling this option for such properties is only possible from DataMiner 9.5.14 onwards.

   - **No format specified**: If you do not want to restrict the allowed values, select this option.

   - **Format (regular expression)**: If you want to restrict the allowed values by means of a regular expression, select this checkbox and enter a regular expression in the text box.

   - **Possible values**: If you want to specify a list of allowed values, select this checkbox and add all allowed values to the list.

1. In the *Edit* dialog box, click *OK*.
1. In the *Properties* dialog box, click *OK*.

## Editing custom properties

> [!NOTE]
> If an element has been created by another parent element, it is possible that some of its properties cannot be edited, except by an Administrator or via the parent element.

1. Right-click the item in the Surveyor and select *Properties*.

   Alternatively, to view properties for several elements at a time, on the *Elements* page of a view card, select several elements by holding the *Ctrl* key while you click them, then right-click one of the elements and select *Properties*.

1. In the *Properties* dialog box, go to the *Custom* tab.

1. To change a property value, enter the property value you want and click *OK*.

   > [!NOTE]
   > If you selected several elements, and these have different property values, the value field will display *(Multiple Values)*.

1. To change a property’s configuration, select the property you want to edit, click the cogwheel button in the lower left corner, and select *Edit*.

   The same options will be available as when adding a new property.

   > [!NOTE]
   >
   > - If you change the property name, the value of that property will be lost.
   > - From DataMiner 9.5.0 CU8/9.5.12 onwards, changing the property name via the *Edit* option is no longer possible. Instead, you will need to delete the property with the old name and create a property with the new name.

## Deleting a custom property

1. Right-click the item and select *Properties*.

1. In the *Properties* dialog box, go to the *Custom* tab.

1. Select the property you want to edit.

1. Click the cogwheel button in the lower left corner, and select *Delete*.

1. Click *OK* to confirm.

> [!NOTE]
> If an element has been created by another parent element, it is possible that some of its properties cannot be deleted, except by an Administrator or via the parent element.

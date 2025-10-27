---
uid: Element_properties
---

# Element properties

By adding properties to views, elements, services, and alarms, you can link all kinds of additional information to those DataMiner items. This information can be displayed in the Alarm Console and can be used when creating filters and Correlation rules.

The *Properties* window of an element includes the following tabs:

- **General**: Displays all [general properties](#general-element-properties), which are managed by the DataMiner System and cannot be edited.

- **Custom**: Displays all [custom properties](xref:Managing_element_properties), which can be freely added and edited by DataMiner users.

- **Connectivity**: Only available for elements that have in/out interfaces defined in their protocol. This tab allows you to [view the element connections](xref:Viewing_element_connections).

## Accessing element properties

To access the properties of an element:

1. Right-click the element in the Surveyor or on the *Elements* page of a view card.

1. Select *Properties*.

   The *Properties* window will open, with a separate tab for general and for custom properties.

> [!NOTE]
> To access properties of views and services, you can also use the Surveyor right-click menu.

## General element properties

The *general* tab of an element's *Properties* window displays the following information at the top:

![General element properties](~/dataminer/images/General_Element_Properties.png)<br>*Properties window in DataMiner 10.5.8*

- Element state icon (1): Indicates the current state of the element. See also: [Icons](xref:DataMiner_Cube_sidebar#icons).

- Element name (2): Displays the name assigned to the element.

- Element ID (3): Displays the element's unique ID in the format `DMAID\ElementID`.

- Masking status (4): Indicates whether the element is currently masked or not.

Additionally, the following properties are available:

| Property | Description |
|--|--|
| Host | Available from DataMiner 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8 onwards<!--RN 42807-->. The name and ID of the DMA currently hosting the element. |
| Created | The date and time the element was created, along with the user who created it. |
| Modified | The date and time of the last modification to the element, along with the user who made the change. |
| Alarm template | The date and time the alarm template was assigned, along with the user who assigned it. |
| Trend template | The date and time the trend template was assigned, along with the user who assigned it. |
| State changed | The last time the element state was changed, along with the user who made the change. |

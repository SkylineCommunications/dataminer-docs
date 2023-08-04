---
uid: Linking_a_shape_to_an_EPM_object
---

# Linking a shape to an EPM object

From DataMiner 10.1.0/10.0.4 onwards, it is possible to link a shape to an EPM object using its system name and system type. Clicking the shape will then navigate to that EPM object on the current card. The context menu of the shape will allow you to navigate to the object on the current card, on a new card, or on a new undocked card.

> [!IMPORTANT]
> This feature is currently only available if the *CPEIntegration* soft-launch option is enabled. See [Soft-launch options](xref:SoftLaunchOptions).

> [!NOTE]
> A shape linked to an EPM object supports inheritance, which means that child shapes will automatically be linked to the EPM object. You can disable this using the [AllowInheritance=False](xref:Overview_of_page_and_shape_options#allowinheritancefalse) option.

## Basic shape data configuration

To link a shape to an EPM object, add the **SystemType** and **SystemName** shape data fields, and specify the system type and system name of the object as their respective values.

For example:

| Shape data field | Value |
|--|--|
| SystemType | OLT |
| SystemName | MyOLTName |

## Configuring the alarm color of the shape

By default, the background color of the shape will be the color of the instance alarm level of the EPM object. You can customize this using the **AlarmLevel** shape data field, which can be set to the following values:

- *Instance*: Default value. The shape will show the instance alarm level of the EPM object.
- *BubbleUp*: The shape will show the bubble-up alarm level of the EPM object.
- *Summary*: The shape will show the highest alarm severity of the instance and its underlying objects (i.e. the highest severity of the instance and bubble-up alarm levels).

For example:

| Shape data field | Value |
|--|--|
| SystemType | OLT |
| SystemName | MyOLTName |
| AlarmLevel | Summary |

## Showing the system type and/or system name in the shape text

To make the shape text display the system name or system type, add an **Info** shape data field and set it to *System Type* or *System Name*. Then set the shape text to a "*" character. This character will be replaced by the requested information. See [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

Alternatively, you can use the placeholders [System Name] and [System Type] in the text.

## Showing statistics for the EPM object in the shape text

<!-- RN 35222 -->

From DataMiner 10.3.2/10.4.0 onwards, you can make the shape text display statistics for the EPM object:

1. Add an asterisk in the shape text.

1. Add an **Info** shape data field and set its value to `EPM STATISTICS:###[<statistics>]`.

   Instead of `<statistics>`, use one of the values below, depending on the type of statistics you want to display:

    - `#TotalAlarms`
    - `#CriticalAlarms`
    - `#MajorAlarms`
    - `#MinorAlarms`
    - `#WarningAlarms`
    - `#NormalAlarms`
    - `#TimeoutAlarms`
    - `#NoticeAlarms`
    - `#ErrorAlarms`

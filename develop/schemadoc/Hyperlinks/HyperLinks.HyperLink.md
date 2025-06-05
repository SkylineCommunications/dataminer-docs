---
uid: HyperLinks.HyperLink
---

# HyperLink element

Defines a custom command that will be displayed in the shortcut menu of the Alarm Console.

## Type

string

## Content Type

string

### Content

#### [Second-generation hyperlink content](#tab/secondgenerationcontent)

In the *\<HyperLink>* tag, enter the following content, depending on the type of hyperlink specified in the *type* attribute (see [type](#type)):

- **Type "url"**: The URL that should be opened.

- **Type "execute"**: The name of the executable file.

  The path to the executable file can include spaces, but only if it is enclosed in double quotation marks. Anything that is added after a space and is not enclosed within quotation marks will be interpreted as an argument. For example: *\<HyperLink id="20" version="2" type="execute" name="MyApp" menu="root" \>"C:\\Program Files (x86)\\MyApp\\App.exe" \[ENAME\]\</HyperLink>*

- **Type "script"**: The Automation script execution command. This should be configured in the same way as when you link a shape to an Automation script in a Visio drawing. See [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script) for more information.

  > [!NOTE]
  > It is not necessary to use the "Script:" prefix in a second-generation hyperlink, as the *type* attribute already makes it clear an Automation script is referred to.

- **Type "OpenCPE"**: The EPM card.

  Supported from DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!-- RN 42221 -->, or with the *CPEIntegration* [soft-launch option](xref:SoftLaunchOptions) in earlier DataMiner versions.<!-- RN 22125 -->

  For example, to add an "Open OLT" hyperlink to the Alarm Console context menu to open the EPM card of the object that generated the selected alarm: `<HyperLink  name="Open OLT" menu="root" type="OpenCPE" version="2" id="18">:visual:pagename</HyperLink>`.

  Hyperlinks of this type can also be shown or hidden based on a filter configured with the [filterElement](xref:HyperLinks.HyperLink-filterElement) attribute. For example: `<HyperLink filterElement="AlarmEventMessage.PropertiesDict.&quot;System Type&quot;[String] == 'OLT'" name="Open OLT" menu="root" type="OpenCPE" version="2" id="18">[EID]:visual:qam ds</HyperLink>`.

- **Type "openview"**: The view ID. Alternatively, you can use the \[VID\] placeholder to open the view of the selected alarm.

  You can also have the view opened on a particular page, using the same syntax as in a [Cube argument](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page) (e.g. *\[VID\]::Aggregation*).

- **Type "openservice"**: The service ID. Alternatively, you can use the \[SID\] placeholder to open the service of the selected alarm.

  You can also have the service opened on a particular page, using the same syntax as in a [Cube argument](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page) (e.g. *\[SID\]:d:Australia Service*).

- **Type "openelement"**: The element ID. Alternatively, you can use the \[EID\] placeholder to open the element of the selected alarm.

  You can also have the element opened on a particular page, using the same syntax as in a [Cube argument](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page) (e.g. *\[EID\]:Data:Performance/Ping*).

- **Type "openparameter"**: The parameter ID. Alternatively, you can use the \[PID\] placeholder to open the parameter of the selected alarm.

- **Type "reference"**: The ID of a legacy hyperlink. See [Upgrading legacy hyperlinks to second-generation hyperlinks](xref:Hyperlinks_xml#upgrading-legacy-hyperlinks-to-second-generation-hyperlinks).

> [!NOTE]
> The string you specify can contain:
>
> - [Keywords](xref:Hyperlinks_xml#keywords), which allow you to insert real-time data in the command name that is displayed.
> - [Placeholders](xref:Hyperlinks_xml#placeholders), which allow you to insert parts of the value of the alarm or information event in the command that is displayed.

> [!TIP]
> See also: [type](#type)

#### [Legacy hyperlink content](#tab/legacycontent)

Inside the *\<HyperLink>* tag, enter the actual command that has to be displayed on the shortcut menu.

The string you specify can contain:

- [Keywords](xref:Hyperlinks_xml#keywords), which allow you to insert real-time data in the command name that is displayed.
- [Placeholders](xref:Hyperlinks_xml#placeholders), which allow you to insert parts of the value of the alarm or information event in the command that is displayed.

---

## Parents

[HyperLinks](xref:HyperLinks)

## Attributes

### [Second-generation hyperlink attributes](#tab/secondgenerationattrs)

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [alarmAction](xref:HyperLinks.HyperLink-alarmAction) | string |  | Set to "acknowledge" if you want the selected alarm or alarms to be acknowledged automatically when a hyperlink is executed. |
| [alarmColumn](xref:HyperLinks.HyperLink-alarmColumn) | boolean |  | Set to "true" if you want a hyperlink to appear not only in the Alarm Console shortcut menu but also as a column in the Alarm Console. |
| [combineParameters](xref:HyperLinks.HyperLink-combineParameters) | boolean |  | Set to "true" in order to combine parameters in case multiple alarms have been selected. |
| [descriptionParsing](xref:HyperLinks.HyperLink-descriptionParsing) | string |  | Specifies that the command should appear only in the shortcut menu of alarms and information events with a specific description. |
| [filterElement](xref:HyperLinks.HyperLink-filterElement) | string |  | Defines a conditional hyperlink. The hyperlink will only be displayed for alarms matching the specified filter. |
| [id](xref:HyperLinks.HyperLink-id) | integer | Yes | Specifies the unique identifier of the hyperlink. Used primarily for synchronization purposes. |
| [menu](xref:HyperLinks.HyperLink-menu) | string |  | Configures where in the shortcut menu (a specific submenu or the root) the item should appear. |
| [name](xref:HyperLinks.HyperLink-name) | string |  | Specifies the name of the command as it has to appear in the user interfaces. |
| [type](xref:HyperLinks.HyperLink-type) | string | Yes | Specifies the hyperlink type. |
| [valueParsing](xref:HyperLinks.HyperLink-valueParsing) | string |  | Configures the command to appear only in the shortcut menu of alarms and information events with a specific value. |
| [version](xref:HyperLinks.HyperLink-version) | integer | Yes | In second-generation hyperlinks, this mandatory attribute has to be set to "2". |

### [Legacy hyperlink attributes](#tab/legacyattrs)

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [id](xref:HyperLinks.HyperLink-id) | integer | Yes | Specifies the unique identifier of the hyperlink. Used primarily for synchronization purposes. |
| [valueParsing](xref:HyperLinks.HyperLink-valueParsing) | string |  | Configures the command to appear only in the shortcut menu of alarms and information events with a specific value. |

---

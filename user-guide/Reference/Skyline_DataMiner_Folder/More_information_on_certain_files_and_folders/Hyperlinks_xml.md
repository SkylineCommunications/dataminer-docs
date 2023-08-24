---
uid: Hyperlinks_xml
---

# Hyperlinks.xml

In the file *Hyperlinks.xml*, you can [define custom commands](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu) that will be displayed in the shortcut menu of the Alarm Console.

DataMiner administrators will often create custom commands that open a web page, start an executable file or execute an Automation script.

> [!NOTE]
> When you make changes to *Hyperlinks.xml*, you should also force a synchronization of the file and reopen DataMiner Cube. For more details, see [Adding a custom command to the Alarm Console shortcut menu](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu).

> [!TIP]
> See also: [Alarm Console – Extending the right-click menu](https://community.dataminer.services/video/alarm-console-extending-the-right-click-menu/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## File syntax

The *Hyperlinks.xml* file has to have a *\<HyperLinks>* root tag containing a *\<HyperLink>* tag for every custom command.

There are two types of hyperlinks:

- Second-generation hyperlinks
- Legacy hyperlinks

See the following example:

```xml
<HyperLinks>
  <!-- SECOND-GENERATION HYPERLINKS -->
  <HyperLink id="29"
          version="2"
          name="Send QA report by e-mail"
          menu="Scripts"
          type="script"
          alarmColumn="true">
    QA report by e-mail||||Tooltip|NoConfirmation
  </HyperLink>
  <HyperLink id="50"
          version="2"
          name="Open Element"
          menu="root/Elements"
          type="openelement"
          alarmColumn="true">
    [EID]
  </HyperLink>
  <!-- LEGACY HYPERLINKS -->
  <HyperLink id="10">http://www.skyline.be</HyperLink>
  <HyperLink id="15">Script:QA report by e-mail|Dummy1=179/15601|||Tooltip|</HyperLink>
</HyperLinks>
```

> [!NOTE]
> When you specify an Automation script in a hyperlink, you only need to use the “Script:” prefix in legacy hyperlinks. In second-generation hyperlinks, this prefix has no function, as the *type* attribute clearly specifies that it concerns a reference to an Automation script.

## Syntax of second-generation hyperlinks

In the syntax of a second-generation hyperlink, the ID, the version, the type and the actual command must always be specified. In addition to this mandatory configuration, several optional attributes can be configured.

A second-generation hyperlink can for instance have the following syntax:

```xml
<HyperLink id="..."
        version="2"
        name="..."
        menu="..."
        type="..."
        alarmColumn="..."
        valueParsing="...">
  [Hyperlink]
</HyperLink>
```

Or:

```xml
<HyperLink id="..."
        version="2"
        name="..."
        menu="..."
        type="..."
        alarmColumn="..."
        descriptionParsing="...">
  [Hyperlink]
</HyperLink>
```

### Content of the Hyperlink tag

In the *\<HyperLink>* tag, enter the following content, depending on the type of hyperlink specified in the *type* attribute (see [type](#type)):

- **Type "url"**: The URL that should be opened.

- **Type "execute"**: The name of the executable file.

  From DataMiner 9.0.5 onwards, you can specify a path to the executable file that includes spaces, but only if it is enclosed in double quotation marks. Anything that is added after a space and is not enclosed within quotation marks will be interpreted as an argument. For example: *\<HyperLink id="20" version="2" type="execute" name="MyApp" menu="root" \>"C:\\Program Files (x86)\\MyApp\\App.exe" \[ENAME\]\</HyperLink>*

- **Type "script"**: The Automation script execution command. This should be configured in the same way as when you link a shape to an Automation script in a Visio drawing. See [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script) for more information.

  > [!NOTE]
  > It is not necessary to use the “Script:” prefix in a second-generation hyperlink, as the *type* attribute already makes it clear an Automation script is referred to.

- **Type "openview"**: The view ID. Alternatively, you can use the \[VID\] placeholder to open the view of the selected alarm.
  
  From DataMiner 9.6.3 onwards, you can also have the view opened on a particular page, using the same syntax as in a Cube URL (e.g. *\[VID\]::Aggregation*). See [Opening a card on a particular page](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page).

- **Type "openservice"**: The service ID. Alternatively, you can use the \[SID\] placeholder to open the service of the selected alarm.

  From DataMiner 9.6.3 onwards, you can also have the service opened on a particular page, using the same syntax as in a Cube URL (e.g. *\[SID\]:d:Australia Service*). See [Opening a card on a particular page](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page).

- **Type "openelement"**: The element ID. Alternatively, you can use the \[EID\] placeholder to open the element of the selected alarm.

  From DataMiner 9.6.3 onwards, you can also have the element opened on a particular page, using the same syntax as in a Cube URL (e.g. *\[EID\]:Data:Performance/Ping*). See [Opening a card on a particular page](xref:Options_for_opening_DataMiner_Cube#opening-a-card-on-a-particular-page).

- **Type "openparameter"**: The parameter ID. Alternatively, you can use the \[PID\] placeholder to open the parameter of the selected alarm.

- **Type "reference"**: The ID of a legacy hyperlink. See [Upgrading legacy hyperlinks to second-generation hyperlinks](#upgrading-legacy-hyperlinks-to-second-generation-hyperlinks) for more information.

> [!NOTE]
> The string you specify can contain:
>
> - Keywords, which allow you to insert real-time data in the command name that is displayed. See [Keywords](#keywords).
> - Placeholders, which allow you to insert parts of the value of the alarm or information event in the command that is displayed. See [Placeholders](#placeholders).

> [!TIP]
> See also: [type](#type)

### Attributes of the Hyperlink tag

- [alarmAction](#alarmaction)
- [alarmColumn](#alarmcolumn)
- [filterElement](#filterelement)
- [combineParameters](#combineparameters)
- [descriptionParsing](#descriptionparsing)
- [id](#id)
- [menu](#menu)
- [name](#name)
- [type](#type)
- [valueParsing](#valueparsing)
- [version](#version)

#### alarmAction

If you want the selected alarm or alarms to be acknowledged automatically when a hyperlink is executed, add an *alarmAction* attribute to the *\<HyperLink>* tag and set its value to “acknowledge”.

This attribute is optional.

#### alarmColumn

If you want a hyperlink to appear not only in the Alarm Console shortcut menu but also as a column in the Alarm Console, add an *alarmColumn* attribute to the *\<HyperLink>* tag and set its value to “true”.

This attribute is optional.

#### filterElement

Available from DataMiner 9.5.7 onwards. This optional attribute can be used to add a conditional hyperlink. The hyperlink will only be displayed for alarms matching the specified filter.

For example, to create a hyperlink that is only available on alarms that have a property called "PropName" of which the value is "PropValue", add the following hyperlink tag to *Hyperlinks.xml*:

```xml
<HyperLink id="20" version="2" name="RootTime_v2" type="url" menu="/root" filterElement="(AlarmEventMessage.PropertiesDict.PropName[String] =='PropValue')"> [DMAID]</HyperLink>
```

To test a filter that you want to specify for a conditional hyperlink, you can use the SLNetClientTest tool. See [Checking a hyperlink filter](xref:SLNetClientTest_checking_hyperlink_filter).

From DataMiner 9.6.9 onwards, this attribute supports alarm properties containing a space. These need to be contained in double quotes (or *"* in XML), for example:

```txt
filterElement="(AlarmEventMessage.PropertiesDict.&quot;Property Name&quot;[String] == 'PropValue')"
```

From DataMiner 10.0.12 onwards, it is possible to use a filter that checks whether a specific key exists. For example:

```xml
<HyperLink id="1" version="2" name="Issue_ID blank" type="script" alarmColumn="true"
 menu="root/JIRA" combineParameters="true"
 filterElement="(AlarmEventMessage.PropertiesDict.KeyExists:Issue_ID[Bool] == False) OR (AlarmEventMessage.PropertiesDict.Issue_ID[String]=='')">
  Script:dummy script||||Tooltips|NoConfirmation,CloseWhenFinished
</HyperLink>
```

> [!NOTE]
> The KeyExists filter is not recommended for data retrieval from Cassandra or Elasticsearch, as the filter will only be applied after data is retrieved from these databases.

#### combineParameters

In order to combine parameters in case multiple alarms have been selected, add the optional *combineParameters* attribute to the *\<HyperLink>* tag and set its value to “true”.

By default, the different parameters will be separated by means of *+* characters. If you want to specify a custom separator, add a separator attribute, and specify the separator.

Example:

```xml
<HyperLink id="1"
        version="2"
        name="Automation Script"
        menu="root/utils"
        type="script"
        combineParameters="true"
        separator="&amp;">
  Information Generator||Parameter=[ENAME]||Tooltip|
</HyperLink>
```

> [!NOTE]
> When you use an XML reserved character as a separator, it has to be escaped. (e.g. “&amp;” instead of “&”).

#### descriptionParsing

Use this optional attribute if you want the command to appear only in the shortcut menu of alarms and information events with a specific description.

If you specify a string in this attribute, the command will only appear in the shortcut menu of alarms and information events of which the description matches the string you specified.

If you leave this attribute empty, the command will appear in the shortcut menu of every alarm and information event.

The string you specify in this *descriptionParsing* attribute can contain wildcards (question marks and asterisks) as well as placeholders. See [Placeholders](#placeholders).

> [!NOTE]
> Alternatively, you can use the attribute *valueParsing* to have the command appear only for alarms and information events with a particular value.

#### id

In this mandatory attribute, specify the unique identifier of the hyperlink. It is primarily used for synchronization purposes.

#### menu

If you add a hyperlink to *Hyperlinks.xml*, by default, it will appear in the “Hyperlinks” submenu of the Alarm Console shortcut menu. However, if you want it to appear in another submenu (or in the root) of the shortcut menu, add the optional *menu* attribute to the *\<HyperLink>* tag and specify a location.

Examples:

- Enter “root” to make it appear in the root of the shortcut menu.
- Enter e.g. “root/MyLinks” to make it appear in the “MyLinks” submenu.
- Enter e.g. “root/MyLinks/Scripts” to make it appear in the “MyLinks/Scripts” submenu.

> [!NOTE]
> If you do not specify a *menu* attribute or if you do not start the value of the menu attribute with “root”, the hyperlink will be added to the default “Hyperlinks” submenu.

#### name

In this optional attribute, specify the name of the command as it has to appear in the user interfaces.

If you want a hyperlink of type “script” (i.e. a hyperlink that starts an Automation script) to have a custom name, then enter that name in the *name* attribute. If you leave the *name* attribute empty, the hyperlink will have the name of the script.

#### type

In this mandatory attribute, specify the hyperlink type. The following types are supported:

- **url**: Opens a URL in a web browser.
- **execute**: Runs an executable file.
- **script**: Runs an Automation script. For information on how to specify the script to be run, see [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script).

  > [!NOTE]
  > It is not necessary to use the “Script:” prefix in a second-generation hyperlink, as the *type* attribute already makes it clear an Automation script is referred to.

- **openview**: Opens a DataMiner view in a new card. If the \[VID\] placeholder is used in the \<Hyperlink> tag, the view of the selected alarm is opened.
- **openservice**: Opens a DataMiner service in a new card. If the \[SID\] placeholder is used in the \<Hyperlink> tag, the service of the selected alarm is opened.
- **openelement**: Opens a DataMiner element in a new card. If the \[EID\] placeholder is used in the \<Hyperlink> tag, the element of the selected alarm is opened.
- **openparameter**: Opens a DataMiner parameter in a new card. If the \[PID\] placeholder is used in the \<Hyperlink> tag, the parameter of the selected alarm is opened.
- **reference**: Refers to a legacy hyperlink. See [Upgrading legacy hyperlinks to second-generation hyperlinks](#upgrading-legacy-hyperlinks-to-second-generation-hyperlinks) for more information.

> [!TIP]
> See also: [Content of the Hyperlink tag](#content-of-the-hyperlink-tag)

#### valueParsing

Use this optional attribute if you want the command to appear only in the shortcut menu of alarms and information events with a specific value.

If you specify a string in this attribute, the command will only appear in the shortcut menu of alarms and information events of which the value matches the string you specified.

If you leave this attribute empty, the command will appear in the shortcut menu of every alarm and information event.

The string you specify in this *valueParsing* attribute can contain wildcards (question marks and asterisks) as well as placeholders. See [Placeholders](#placeholders).

> [!NOTE]
> Alternatively, you can use the attribute *descriptionParsing* to have the command appear only for alarms and information events with a particular description.

#### version

In second-generation hyperlinks, this mandatory attribute has to be set to “2”.

## Syntax of legacy hyperlinks

A legacy hyperlink must have the following syntax:

```xml
<HyperLink id="..." valueParsing="...">[Hyperlink]</HyperLink>
```

### Content of the Hyperlink tag (legacy)

Inside the *\<HyperLink>* tag, enter the actual command that has to be displayed on the shortcut menu.

The string you specify can contain:

- [Keywords](#keywords), which allow you to insert real-time data in the command name that is displayed.
- [Placeholders](#placeholders), which allow you to insert parts of the value of the alarm or information event in the command that is displayed.

### Attributes of the Hyperlink tag (legacy)

#### id (legacy)

In this attribute, specify the unique identifier of the hyperlink. It is primarily used for synchronization purposes.

#### valueParsing (legacy)

Use this attribute if you want the command to appear only in the shortcut menu of specific alarms and information events.

If you specify a string in this attribute, the command will only appear in the shortcut menu of alarms and information events of which the value matches the string you specified.

If you leave this attribute empty, the command will appear in the shortcut menu of every alarm and information event.

The string you specify in this *valueParsing* attribute can contain wildcards (question marks and asterisks) as well as placeholders. See [Placeholders](#placeholders).

## Upgrading legacy hyperlinks to second-generation hyperlinks

In a *Hyperlinks.xml* file, you can easily “upgrade” legacy hyperlinks to second-generation hyperlinks.

For each of your legacy hyperlinks, create a second-generation hyperlink of type “reference” and put the ID of the old hyperlink in the tag of the new hyperlink.

Example:

```xml
<!-- FIRST GENERATION -->
<HyperLink id="10">http://www.skyline.be</HyperLink>
<!-- SECOND GENERATION -->
<HyperLink id="100"
        version="2"
        name="Web page"
        menu="root"
        type="reference"
        alarmColumn="true">
  10
</HyperLink>
```

## Keywords

The string you specify inside the *\<HyperLink>* tag can contain the following keywords. These will be replaced by real-time data in the command that is displayed on the shortcut menu.

| Keyword | Description |
|--|--|
| \[ALARMID\] | The ID of the alarm or the information event. |
| \[ALARMTYPE\] | The type of the alarm. |
| \[COMMENT\] | The comment added to the alarm. |
| \[DISPLAYVALUE\] | The value of a discrete parameter. Supported from DataMiner 10.0.6 onwards, and in second-generation hyperlinks only. |
| \[DMAID\] | The ID of the DataMiner Agent. |
| \[EID\] | The ID of the element. |
| \[ENAME\] | The element name. |
| \[OWNER\] | The owner of the alarm. |
| \[PID\] | The ID of the parameter. |
| \[PNAME\] | The parameter name. |
| \[POLLINGIP\] | The IP address of the device. |
| \[PROPERTY:ALARM:name\] | The value of the alarm property called “name”. See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
| \[PROPERTY:ELEMENT:name\] | The value of the element property called “name”. See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
| \[PROPERTY:VIEW:name\] | The value of the view property called “name”. See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
| \[RCA\] | The RCA level of the alarm. |
| \[ROOTKEY\] | The ID of the root alarm. See [About the \[ROOTTIME\] and \[TIME\] keywords](#about-the-roottime-and-time-keywords). |
| \[ROOTTIME\] | The root time of the alarm. See [About the \[ROOTTIME\] and \[TIME\] keywords](#about-the-roottime-and-time-keywords). |
| \[SEVERITY\] | The severity level of the alarm. |
| \[SID\] | The ID of the service. |
| \[STATUS\] | The status of the alarm. |
| \[TIME\] | The time of the alarm. |
| \[USERSTATUS\] | The user status of the alarm. |
| \[VALUE\] | The value of the alarm. |
| \[VID\] | The ID of the view. See [About the \[VID\] keyword](#about-the-vid-keyword). |

### About the \[ROOTTIME\] and \[TIME\] keywords

By default, the \[ROOTTIME\] and \[TIME\] keywords in second-generation hyperlinks (in *Hyperlinks.xml*) format time strings as ShortDate strings, which are culture-dependent, while legacy hyperlinks use the format of the alarm itself.

However, for second-generation hyperlinks, it is possible to specify custom formatting for these keywords from 9.5.7 onwards.

For example:

```txt
[ROOTTIME:yyyy-MM-dd HH:mm:ss]
```

- E.g. 2017-12-06 14:04:00

```txt
[TIME:yyyy-MM-dd]
```

- E.g. 2017-12-06

For more information on the supported formatting, refer to the following articles:

- <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>
- <https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings>

> [!NOTE]
> In addition to the illegal characters described in the mentioned articles, the “\]” and “\[“ characters are also illegal in these keywords.

### About the \[PROPERTY:\] keywords

Prior to DataMiner 10.2.7/10.3.0, the \[PROPERTY:ALARM:name\], \[PROPERTY:ELEMENT:name\], and \[PROPERTY:VIEW:name\] keywords can only be used in second-generation hyperlinks of type "url", "execute", and "script".

From DataMiner 10.2.7/10.3.0 onwards, these keywords can also be used in second-generation hyperlinks of type "openview", "openservice", "openelement" and "openparameter".

For example, if a hyperlink of type "openelement" contains the following content, and an alarm is selected that has a valid ID defined for the "Booking Manager Element ID" property, you can use this hyperlink to open that element:

```txt
[PROPERTY:ALARM:Booking Manager Element ID]
```

> [!NOTE]
>
> - If you want to use a view property, service property, or element property in a hyperlink, make sure the option *Make this property available for alarm filtering* is enabled for that property. See [Managing element properties](xref:Managing_element_properties).
> - If you use a view property on an alarm of an element contained in multiple views, the hyperlink will use the property of the view with the lowest ID.

### About the \[VID\] keyword

From DataMiner 9.5.1 onwards, it is possible to specify a view filter with the \[VID\] keyword in second-generation hyperlinks of type “Script”, “Execute”, “Url” and “OpenView’”

For example:

- **\[VID\]**: The view of the selected alarm as well as all its parent views up to and including the root view.
- **\[VID:0;1\]**: The view of the selected alarm as well as two view levels up (level 0 being the parent views, and level 1 being the “grandparent” views).
- **\[VID:0\]**: The view of the selected alarm as well as one view level up (level 0 being the parent views).

The view levels do not need to be specified in any particular order. For example, all of the following view filters are valid: \[VID:0;1;2;3\], \[VID:1;3\], \[VID:0;5\].

## Placeholders

Special placeholders allow you to use (parts) of the value of the alarm or information event in the command name that is displayed in the shortcut menu.

The example below shows four legacy hyperlink definitions. In the first definition, the name of the Automation script, indicated by the placeholder “\[1\]” in the *valueParsing* attribute, will appear at the end of the command name displayed in the shortcut menu. As such, if you right-click an alarm or an information event of which the value starts with e.g. “Set by Automation script MyScript to”, the shortcut menu will contain a custom command named “ExecuteScript.exe –n MyScript”.

Example:

```xml
<HyperLinks>
  <HyperLink id="1" valueParsing="Set by Automation-script [1] to *">ExecuteScript.exe -n [1]</HyperLink>
  <HyperLink id="2">http://www.skyline.be</HyperLink>
  <HyperLink id="3">http://intranet/troubleticket.aspx?ID=[ALARMID]</HyperLink>
  <HyperLink id="4">Script:MyScript|ph1=1/2;ph2=1/2|Parameter1=12;Parameter2=15|Mem1=memoryfile1;Mem2=memoryFile2</HyperLink>
</HyperLinks>
```

> [!TIP]
> See also: [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script)

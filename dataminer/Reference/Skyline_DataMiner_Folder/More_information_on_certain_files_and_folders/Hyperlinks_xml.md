---
uid: Hyperlinks_xml
---

# Hyperlinks.xml

In the file *Hyperlinks.xml*, you can [define custom commands](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu) that will be displayed in the shortcut menu of the Alarm Console.

DataMiner administrators will often create custom commands that open a web page, start an executable file or execute an automation script.

> [!NOTE]
> When you make changes to *Hyperlinks.xml*, you should also force a synchronization of the file and reopen DataMiner Cube. For more details, see [Adding a custom command to the Alarm Console shortcut menu](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu).

## File syntax

The *Hyperlinks.xml* file has to have a [\<HyperLinks>](xref:HyperLinks) root tag containing a [\<HyperLink>](xref:HyperLinks.HyperLink) tag for every custom command.

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
> When you specify an automation script in a hyperlink, you only need to use the "Script:" prefix in legacy hyperlinks. In second-generation hyperlinks, this prefix has no function, as the [type](xref:HyperLinks.HyperLink-type) attribute clearly specifies that it concerns a reference to an automation script.

### [Second-generation hyperlink syntax](#tab/secondgenerationsyntax)

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

### [Legacy hyperlinks syntax](#tab/legacysyntax)

A legacy hyperlink must have the following syntax:

```xml
<HyperLink id="..." valueParsing="...">[Hyperlink]</HyperLink>
```

---

> [!TIP]
> Refer to [HyperLink](xref:HyperLinks.HyperLink) for more information about the content of this tag and the possible attributes.

## Upgrading legacy hyperlinks to second-generation hyperlinks

In a *Hyperlinks.xml* file, you can easily "upgrade" legacy hyperlinks to second-generation hyperlinks.

For each of your legacy hyperlinks, create a second-generation hyperlink of type "reference" and put the ID of the old hyperlink in the tag of the new hyperlink.

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
| \[DISPLAYVALUE\] | The value of a discrete parameter. Supported in second-generation hyperlinks only. |
| \[DMAID\] | The ID of the DataMiner Agent. |
| \[EID\] | The ID of the element. |
| \[ENAME\] | The element name. |
| \[OWNER\] | The owner of the alarm. |
| \[PID\] | The ID of the parameter. |
| \[PNAME\] | The parameter name. |
| \[POLLINGIP\] | The IP address of the device. |
| \[PROPERTY:ALARM:name\] | The value of the alarm property called "name". See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
| \[PROPERTY:ELEMENT:name\] | The value of the element property called "name". See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
| \[PROPERTY:VIEW:name\] | The value of the view property called "name". See [About the \[PROPERTY:\] keywords](#about-the-property-keywords). |
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

However, for second-generation hyperlinks, it is possible to specify custom formatting. For example:

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
> In addition to the illegal characters described in the mentioned articles, the "\]" and "\[" characters are also illegal in these keywords.

### About the \[PROPERTY:\] keywords

The \[PROPERTY:ALARM:name\], \[PROPERTY:ELEMENT:name\], and \[PROPERTY:VIEW:name\] keywords can be used in second-generation hyperlinks of type "url", "execute", "script", "openview", "openservice", "openelement", and "openparameter".

For example, if a hyperlink of type "openelement" contains the following content, and an alarm is selected that has a valid ID defined for the "Booking Manager Element ID" property, you can use this hyperlink to open that element:

```txt
[PROPERTY:ALARM:Booking Manager Element ID]
```

> [!NOTE]
>
> - If you want to use a view property, service property, or element property in a hyperlink, make sure the option *Make this property available for alarm filtering* is enabled for that property. See [Managing custom properties](xref:Managing_element_properties).
> - If you use a view property on an alarm of an element contained in multiple views, the hyperlink will use the property of the view with the lowest ID.

### About the \[VID\] keyword

It is possible to specify a view filter with the \[VID\] keyword in second-generation hyperlinks of type "url", "execute", "script", and "openview".

For example:

- **\[VID\]**: The view of the selected alarm as well as all its parent views up to and including the root view.
- **\[VID:0;1\]**: The view of the selected alarm as well as two view levels up (level 0 being the parent views, and level 1 being the "grandparent" views).
- **\[VID:0\]**: The view of the selected alarm as well as one view level up (level 0 being the parent views).

The view levels do not need to be specified in any particular order. For example, all of the following view filters are valid: \[VID:0;1;2;3\], \[VID:1;3\], \[VID:0;5\].

## Placeholders

Special placeholders allow you to use (parts) of the value of the alarm or information event in the command name that is displayed in the shortcut menu.

The example below shows four legacy hyperlink definitions. In the first definition, the name of the automation script, indicated by the placeholder "\[1\]" in the *valueParsing* attribute, will appear at the end of the command name displayed in the shortcut menu. As such, if you right-click an alarm or an information event of which the value starts with e.g., "Set by automation script MyScript to", the shortcut menu will contain a custom command named "ExecuteScript.exe –n MyScript".

Example:

```xml
<HyperLinks>
  <HyperLink id="1" valueParsing="Set by automation script [1] to *">ExecuteScript.exe -n [1]</HyperLink>
  <HyperLink id="2">http://www.skyline.be</HyperLink>
  <HyperLink id="3">http://intranet/troubleticket.aspx?ID=[ALARMID]</HyperLink>
  <HyperLink id="4">Script:MyScript|ph1=1/2;ph2=1/2|Parameter1=12;Parameter2=15|Mem1=memoryfile1;Mem2=memoryFile2</HyperLink>
</HyperLinks>
```

> [!TIP]
> See also: [Linking a shape to an automation script](xref:Linking_a_shape_to_an_Automation_script)

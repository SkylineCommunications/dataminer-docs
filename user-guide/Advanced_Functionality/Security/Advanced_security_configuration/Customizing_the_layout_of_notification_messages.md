---
uid: Customizing_the_layout_of_notification_messages
---

# Customizing the layout of notification messages

By default, all notification messages have a standard, hard-coded layout. However, if necessary, you can design custom notification message templates and store them in a file called *NotifyTemplates.xml*.

## Creating a NotifyTemplates.xml file

If you want to customize the layout of all or some of the notification messages sent by a particular DataMiner Agent, do the following:

1. Create a file called *NotifyTemplates.xml* and store it in the folder *C:\\Skyline DataMiner\\* of that DataMiner Agent.

1. In the *NotifyTemplates.xml* file, create a *\<Template>* tag inside the *\<NotifyTemplates>* root tag for every type of notification message for which you do not want to use the default, hard-coded layout.

1. Save the file and restart the DataMiner Agent.

> [!NOTE]
>
> - If you define any templates in this file, you must use the mandatory template names listed in [Template names](#template-names).
> - If you want to use special characters in this file, see [Using special characters in NotifyTemplates.xml](#using-special-characters-in-notifytemplatesxml).
> - The *NotifyTemplates.xml* file is not synchronized across the DMS. In other words, every DMA can have its own *NotifyTemplates.xml* file.

## Template names

When defining notification message templates in the *NotifyTemplates.xml* file, make sure each template has one of the following mandatory names.

- **\[Format\]-correlation-infoheader**

  Template of the base Alarm section’s header in the notification message sent as a result of a triggered Correlation rule.

- **\[Format\]-correlation-infoitem**

  Template of a base Alarm item in the base Alarm section of the notification message sent as a result of a triggered Correlation rule.

- **\[Format\]-correlation-infofooter**

  Template of the base Alarm section’s footer in the notification message sent as a result of a triggered Correlation rule.

- **\[Format\]-notifications**

  The notification message sent independently (not as a result of a Correlation rule).

> [!TIP]
> For more information on how to configure a Correlation rule to send a notification message, see [Sending an email](xref:Sending_an_email)

### Template name prefixes indicating the message format

In the above-mentioned template names, *\[Format\]* must be replaced by one of the following words that indicate the format of the template:

| Format | Description                          |
|--------|--------------------------------------|
| text   | Email message containing plain text. |
| html   | Email message containing HTML.       |
| sms    | Cellphone text message.              |

Example: The template called “text-notifications” should contain the template for notification messages sent in plain-text emails.

> [!NOTE]
> HTML templates will be inserted into the *\[contents\]* placeholder located in the *\<body>* tag of the file *C:\\Skyline DataMiner\\NotifyMail.html*.

## Using special characters in NotifyTemplates.xml

1. Open *NotifyTemplates.xml* in a text editor that supports file encodings.

1. Set encoding to UTF-8.

1. At the top of the file, add the following XML processing instruction:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   ```

1. Enter all necessary text, which can now contain all kinds of special characters.

## Example of a NotifyTemplates.xml file

The following example shows a *NotifyTemplates.xml* file in which two templates have been defined: one for plain-text notifications and another one for HTML notifications:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<NotifyTemplates>
  <Template name="text-notifications" options="">
    <Content>
        <![CDATA[
        Filter '[filtername]' has been triggered[if:multiple]
        ([occurrences] times for similar alarms)[endif] (Alarm Id ='[alarmid]')
        -Dataminer: [dmaname] (id = [dmaid])
        -Element: [elementname] (id='[elementkey]')
        [if:description] -Element Description: [elementdesc][endif]
        -Parameter: [paramname] (id='[paramid]')
        -Value: [value]
        -Owner: [owner]
        -Severity: [severity] ([severitylevel])
        -Source: [source]
        -State: [state]
        -Time: [time]
        -Type: [type]
        -UserStatus: [userstatus]
        -Comment: [comment]
        -RootKey: [rootkey]
        More Info: http://[dmaip]/SystemDisplay.htm[if:element] and
        http://[dmaip]/ElementDisplay.htm?id=[dmaid]/[elementid][endif]
      ]]>
    </Content>
  </Template>
  <Template name="html-notifications" options="">
    <Content>
      <![CDATA[
      <p>Filter '[filtername]' has been triggered[if:multiple]
      ([occurrences] times for similar alarms)[endif],
      based on Alarm with Id = '[alarmid]' (RootKey: '[rootkey]'):</p>
      <table class="notification_table">
      <tr class="header">
        <th>DataMiner</th>
        <th>Element</th>
        [if:description]<th>Element Description</th>[endif]
        <th>Parameter</th>
        <th>Value</th>
        <th>Owner</th>
        <th>Severity</th>
        <th>Source</th>
        <th>State</th>
        <th>Time</th>
        <th>Type</th>
        <th>UserStatus</th>
        <th>Comment</th>
      </tr>
      <tr class="alternate">
        <td>[dmaname]</td>
        <td>[elementname]</td>
        [if:description]<td>[elementdesc]</td>[endif]
        <td>[paramname]</td>
        <td>[value]</td>
        <td>[owner]</td>
        <td class="severity[severityid]">[severity] [severitylevel]</td>
        <td>[source]</td>
        <td>[state]</td>
        <td>[time]</td>
        <td>[type]</td>
        <td>[userstatus]</td>
        <td>[comment]</td>
      </tr>
      </table>
      <p>More Info: <a href="http://[dmaip]/SystemDisplay.htm">SystemDisplay</a>
      [if:element]
      and <a href="http://[dmaip]/ElementDisplay.htm?id=[dmaid]/[elementid]">
      ElementDisplay</a>
      [endif]
      </p>
      ]]>
    </Content>
  </Template>
</NotifyTemplates>
```

> [!NOTE]
> In the example above, a number of placeholders are enclosed in square brackets. For more information, see [Notification template placeholders](#notification-template-placeholders).

## Notification template placeholders

When defining a notification message template in the *NotifyTemplates.xml* file, you can use the following placeholders.

Some can only be used in templates for notification messages sent as a result of a triggered Correlation rule, while others can only be used in templates for notification messages that are sent independently (not as a result of a triggered Correlation rule). See the **Correlation** and **Notifications** columns.

| Name               | Description | Correlation | Notifications |
|--------------------|-------------|-------------|---------------|
| alarmid            | The alarm ID (without DataMiner ID) | X | X |
| alarmvalue         | Legacy correlation message placeholder \[AlarmValue\] | X<br>(Most recent base alarm) | X |
| alternate:xxx      | Every second time this placeholder is used, the string “xxx” will appear in the notification message. | X | X |
| comment            | Alarm comment | | X |
| creationtime       | Alarm creation time | | X |
| dmaid              | DMA ID of the DMA where the element was created | X | X |
| dmaip              | IP address of DMA where the element was created | | X |
| dmaname            | Name of DMA where the element was created | | X |
| element            | Legacy correlation message placeholder \[Element\] | X<br>(Most recent base alarm) | X |
| elementdesc        | Element description | X | X |
| elementid          | Element ID | X | X |
| elementkey         | DmaID/ElementID | X | X |
| elementname        | Element name | X | X |
| elementtype        | Element type | | X |
| endif              | Closing tag of an IF clause. | X | X |
| filtername         | The notification message filter. | | X |
| if:description     | Opening tag of the IF clause that will check the existence of an element description.<br> The contents of the IF clause will only appear in the notification message when an element description exists. | | X |
| if:element         | Opening tag of the IF clause that will check the existence of any element-level information.<br> The contents of the IF clause will only appear in the notification message when element-level information exists. | X |
| if:multiple        | Opening tag of the IF clause that will check the existence of multiple occurrences of the same item.<br> The contents of the IF clause will only appear in the notification message when there are multiple occurrences of the same item. | | X |
| info               | Legacy correlation message placeholder \[Info\]<br> This placeholder will be replaced by the three “correlation message” templates (Either the default, hard-coded ones or the customized ones defined in the file *NotifyTemplates.xml*. See [Template names](#template-names). | X | |
| link               | Legacy correlation message placeholder \[Link\]<br> (Deprecated) | X<br>(Most recent base alarm) | |
| occurrences        | If there are multiple occurrences of the same item, this placeholder will contain the number of occurrences.<br> See also: \[if:multiple\] | | X |
| owner              | The owner of the alarm | X | X |
| parameter          | Legacy correlation message placeholder \[Parameter\]<br> The name of the parameter (in case of Correlation: the name of the parameter in the most recent base alarm) | X<br>(Most recent base alarm) | X |
| paramid            | Parameter ID | X | X |
| paramidx           | Row index of dynamic table | X | X |
| paramname          | The parameter name | X | X |
| pollingip          | Polling IP address of the element | | X |
| prevkey            | ID of the previous alarm in the alarm tree | X | X |
| property:xxx       | The value of the property named “xxx”<br> “xxx” must be e.g. Element.MyProperty, Service.MyProperty or Alarm.MyProperty (the property name itself is case insensitive). | X | X |
| rca:element        | Element RCA level | X | X |
| rca:parameter      | Parameter RCA level | X | X |
| rca:service        | Service RCA level | X | X |
| rootkey            | Root key of the alarm | X | X |
| rootcreationtime   | Root creation time of the alarm | X |
| roottime           | Root time of the alarm | | X |
| ruleState          | Legacy correlation message placeholder \[RuleState\]<br> Possible values: up, down | X | |
| serviceimpact      | Amount of affected services | X | X |
| serviceimpact:text | Names of the affected services | | X |
| severity           | Legacy correlation message placeholder \[Severity\]<br> Examples: Critical, Major, Normal, Timeout | X<br>(Most recent base alarm) | X |
| severityid         | Severity ID | X | X |
| severitylevel      | Severity level<br> Examples: High, Low, Normal | X | X |
| severitytext       | Severity + Severity level<br> Examples: Critical High, Major Low.<br> Note: If level is “Normal”, it will be omitted. E.g. “Warning Normal” will be “Warning”. | X | X |
| source             | Examples: DataMiner System, Correlation Engine, External | X | X |
| sourceid           | Source ID | X | X |
| state              | Alarm state<br> Examples: Open, Mask, Cleared, Clearable | X | X |
| stateid            | Alarm state ID | X | X |
| time               | Timestamp | X | X |
| time:short         | Shortened timestamp used in cellphone text messages (time only, no date) | X | X |
| type               | Alarm type<br> Examples: New Alarm, Escalated From, Dropped From | X | X |
| typeid             | Alarm type ID | X | X |
| userstatus         | User status<br> Examples: Not Assigned, Acknowledged, Unresolved | X | X |
| userstatusid       | User status ID | X | X |
| value              | Alarm value | X | X |
| value:short        | Shortened alarm value used in cellphone text messages (max 50 characters). | X | X |

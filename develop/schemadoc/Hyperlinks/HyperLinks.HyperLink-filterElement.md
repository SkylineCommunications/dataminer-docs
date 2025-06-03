---
uid: HyperLinks.HyperLink-filterElement
---

# filterElement attribute

Defines a conditional hyperlink. The hyperlink will only be displayed for alarms matching the specified filter.

## Content Type

string

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

For example, to create a hyperlink that is only available on alarms that have a property called "PropName" of which the value is "PropValue", add the following hyperlink tag to *Hyperlinks.xml*:

```xml
<HyperLink id="20" version="2" name="RootTime_v2" type="url" menu="/root" filterElement="(AlarmEventMessage.PropertiesDict.PropName[String] =='PropValue')"> [DMAID]</HyperLink>
```

To test a filter that you want to specify for a conditional hyperlink, you can use the SLNetClientTest tool. See [Checking a hyperlink filter](xref:SLNetClientTest_checking_hyperlink_filter).

This attribute supports alarm properties containing a space, but these need to be contained in double quotes (or `&quot;` in XML), for example:

```txt
filterElement="(AlarmEventMessage.PropertiesDict.&quot;Property Name&quot;[String] == 'PropValue')"
```

You can also use a filter that checks whether a specific key exists. For example:

```xml
<HyperLink id="1" version="2" name="Issue_ID blank" type="script" alarmColumn="true"
 menu="root/JIRA" combineParameters="true"
 filterElement="(AlarmEventMessage.PropertiesDict.KeyExists:Issue_ID[Bool] == False) OR (AlarmEventMessage.PropertiesDict.Issue_ID[String]=='')">
  Script:dummy script||||Tooltips|NoConfirmation,CloseWhenFinished
</HyperLink>
```

> [!NOTE]
> The KeyExists filter is not recommended for data retrieval from Cassandra or an indexing database, as the filter will only be applied after data is retrieved from these databases.
---
uid: Making_a_shape_filter_Alarm_Console_tabs_when_clicked
---

# Making a shape filter Alarm Console tabs when clicked

If you add a shape data field of type **AlarmFilter** to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > ALARM]* page.

## Configuring the shape data field

Add a shape data field of type **AlarmFilter** to the shape, and enter an alarm filter as the value, using the same syntax as in the Alarm Console quick filter.

You can for instance use the following syntax:

- *alarmid:DMAID/AlarmID* (e.g. alarmid:420/1570635).
- *alarmdescription:Description* (e.g. alarmdescription:Test)
- *alarmtype:Type* (e.g. alarmtype:Acknowledged)
- *category:CategoryName* (e.g. category:Configuration)
- *comment:CommentText* (e.g. comment:This is a comment)
- *componentinfo:ComponentInfo* (e.g. componentinfo:This is the info of the component)
- *correctiveaction:CorrectiveAction* (correctiveaction:This is the corrective action)
- *datamineragent:DMAName* (e.g. datamineragent:SLC-H48-G01)
- *datamineragent:DMAID* (e.g. datamineragent:420)
- *element:ElementName* (element:Paris)
- *element:DMAID/ElementID* (e.g. datamineragent:420)
- *elementtype:Type* (e.g. elementtype:DVE)
- *virtualfunction:FunctionName* (e.g. virtualfunction:RT_DCF_DVE_Encoder.Encoder.1)
- *virtualfunction:DMAID/FunctionID* (e.g. virtualfunction:420/502)
- *virtualfunctionimpact:Impact* (e.g. virtualfunctionimpact:1)
- *interface:InterfaceName* (e.g. interface:inout01)
- *interfaceimpact:Impact* (e.g. interfaceimpact:1)
- *keypoint:KeyPoint* (e.g. keypoint:This is the key point)
- *offlineimpact:Impact* (e.g. offlineimpact:No Impact)
- *owner:Username* (e.g. owner:Skyline2/Michael)
- *parameterdescription:DMAID/ElementID/ParameterID* (e.g. parameterdescription:420/50119/1)
- *parameterdescription:ProtocolName:Version/ParameterID* (e.g. parameterdescription:MyTestProtocol:1.0.0.1/1)
- *protocol:ProtocolName:Version* (e.g. protocol:MyTestProtocol:Production)
- *rcalevel:RCALevel* (e.g. rcalevel:0.0.0)
- *service:ServiceName* (e.g. service:Paris)
- *service:DMAID/ServiceID* (e.g. service:49/1)
- *serviceimpact:Impact* (e.g. serviceimpact:1)
- *severity:SeverityLevel* (e.g. severity:Critical)
- *severityrange:Range* (e.g. severityrange:High)
- *source:Source* (e.g. source:DataMiner System)
- *status:Status* (e.g. status:Cleared)
- *userstatus:UserStatus* (e.g. userstatus:Acknowledged)
- *value:ParameterValue* (e.g. value:69.5)
- *view:ViewName* (e.g. view:Root View)
- *view:ViewID* (e.g. view:-1)
- *viewimpact:Impact* (e.g. viewimpact:1)
- For an alarm property: *Alarm:PropertyName:PropertyValue* (e.g. Alarm.System Type:CMC )
- For an element property: *Element:PropertyName:PropertyValue* (e.g. Element.Latitude:90)
- For a service property: *Service:PropertyName:PropertyValue* (e.g. Service.Status:Running)
- For a view property: *View:PropertyName:PropertyValue* (e.g. View.Location:Izegem)
- For a predefined alarm filter, specify the filter name. However, note that this is only supported for public alarm filters.

> [!NOTE]
> Using [dynamic values](xref:Placeholders_for_variables_in_shape_data_values) in the **AlarmFilter** shape data value is supported from DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!--RN 40228-->.

### Examples of alarm filters

- To filter out all alarms and information events containing the word "BBC World":

  ```txt
  BBC World
  ```

- To filter out all critical alarms:

  ```txt
  severity:critical
  ```

- To filter out all alarms and information events of which the *Value* column contains "50":

  ```txt
  value:50
  ```

- To filter out all alarms with a service impact less than 2:

  ```txt
  "Service Impact"<2
  ```

- To filter out alarms based on a dynamic value stored in the session variable `myAlarmFilterVariable`:

  ```txt
  [var:myAlarmFilterVariable]
  ```

  This example dynamically applies the filter based on the current value stored in the `myAlarmFilterVariable`. This dynamic value allows you to change the filter without needing to edit it directly. Dynamic values are supported from DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!--RN 40228-->.

> [!TIP]
> See also: [Using quick filters](xref:Using_quick_filters)

## Placeholders

In some cases, it is possible to use placeholders in the filter condition:

- In EPM environments, the filter condition can contain the \[servicefilter\] and \[servicefiltername\] placeholder.
- If a Service Overview Manager element is used, the filter condition can contain the placeholder \[ServiceFilterIdx\].

> [!TIP]
> See also:
>
> - [\[ServiceFilterName\]](xref:Placeholders_for_variables_in_shape_data_values#servicefiltername)
> - [\[ServiceFilter\]](xref:Placeholders_for_variables_in_shape_data_values#servicefilter)
> - [\[ServiceFilterIdx\]](xref:Placeholders_for_variables_in_shape_data_values#servicefilteridx)

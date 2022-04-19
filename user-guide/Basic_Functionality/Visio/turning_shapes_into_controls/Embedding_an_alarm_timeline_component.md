---
uid: Embedding_an_alarm_timeline_component
---

# Embedding an alarm timeline component

Using an alarm timeline component, you can visualize the alarm history of parameters as a dynamic timeline.

> [!NOTE]
>
> - For examples of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The examples can be found on the Visual page _controls > TIMELINE1_ and _TL2_.

To configure a shape as an alarm timeline component:

1. Add a shape data field of type **Options** to the shape, and set its value to “_alarmtimelines_”.

2. Add a shape data field of type **Parameters**, and set its value as follows in order to define the timeline bands and parameters:

   - Define the parameters in a band definition by specifying an element, a list of parameter IDs, an index, and the necessary options, separated as follows:

     ```txt
     element:pid:index;options
     ```

     | Components | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
     | ---------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
     | element    | The element, which can be specified as a wildcard character “\*”, in the format DMA ID/Element ID (e.g. 320/510), or with the element name.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
     | pid        | The parameter, which can be specified by means of the parameter ID, or with a _\[ServiceSelectionFilter\]_ placeholder.<br> Note: If you want to show the communication state timeline of a particular element (indicating the timeouts), use parameter 64501.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
     | index      | If, in _pid_, you specified a table parameter, you can specify a table column index (or a variable containing an index) here. <br> Alternatively, you can also omit the index and specify a subscription filter in an additional shape data field of type **SubscriptionFilter**. If this filter returns multiple rows, the different timelines will be aggregated into one.<br> For more info on the syntax that can be used in the SubscriptionFilter shape data field, refer to [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).                                                                                                                                                                                                                                                                                                                                                                                       |
     | options    | The following options can be specified, separated by semicolons (“;”).<br> - _IncludeInSummary_: If you specify this option, the parameter will be included in the calculation of the summary alarm timeline, which is displayed at the bottom of the control.<br> - _DisplayName=XXX_: Use this option to specify the band name to be displayed. If you do not specify this option, the default band name will be “_elementName/parameterName/Index_”.<br>Note: This option can only be specified for a parameter for which you have also specified the _IncludeInSummary_ option (since there can only be one title per band).<br> - _Height=0.xx_: If you specify this option, the parameter will take up xx% of the total band height. The specified height has to be a number between 0 and 1 (e.g. 0.75 means 75%). Each parameter within a particular band will have a top and bottom margin of 0.05 (i.e. 5% of the band height). |

   - Separate the parameter definitions by hyphens (“-”) within a band definition.

     ```txt
     parameterDefinition-parameterDefinition-parameterDefinition
     ```

   - Separate the different band definitions by pipe characters (“\|”).

     ```txt
     bandDefinition|bandDefinition|bandDefinition|bandDefinition
     ```

   For example, with the configuration below, the timeline control will have two bands. The first band will show two parameters, and the second band will show one parameter.

   ```txt
   320/508910:1019;Height=.20-320/508910:350;IncludeInSummary; Height=.65|183/67:1007:1;IncludeInSummary;Height=.60
   ```

3. If necessary, add the following additional options in the **Options** shape data field, separated by pipe characters:

   - To display custom text if the timeline control does not contain any timelines, add “_EmptyText=_”, followed by the text to be displayed.

   - If dynamic placeholders are used in the shape data field of type **Parameters** and some dynamic placeholders cannot be resolved, by default the entire time line control will not be displayed. If you want the timeline control to instead disregard the bands for which no data could be retrieved and display those bands for which data could be retrieved, add “_AllowEmptyDynamicValues_”.

   For example:

   ```txt
   alarmtimelines|EmptyText=No service selected|AllowEmptyDynamicValues
   ```

4. Optionally, you can add a shape data field of type **AlarmFilter**, so that you can pass an alarm filter to the Alarm Console by right-clicking a section of the timeline control and selecting _Show alarms in new tab_, or _Show alarms in linked tab_ in case a linked Alarm Console tab is already open. The new tab page will show the alarms corresponding with the filter at the moment of the timeline where you clicked.

   The following syntax is supported for this alarm filter:

   - _alarmid:DMAID/AlarmID_ (e.g. alarmid:420/1570635).

   - _alarmdescription:Description_ (e.g. alarmdescription:Test)

   - _alarmtype:Type_ (e.g. alarmtype:Acknowledged)

   - _category:CategoryName_ (e.g. category:Configuration)

   - _comment:CommentText_ (e.g. comment:This is a comment)

   - _componentinfo:ComponentInfo_ (e.g. componentinfo:This is the info of the component)

   - _correctiveaction:CorrectiveAction_ (correctiveaction:This is the corrective action)

   - _datamineragent:DMAName_ (e.g. datamineragent:SLC-H48-G01)

   - _datamineragent:DMAID_ (e.g. datamineragent:420)

   - _element:ElementName_ (element:Paris)

   - _element:DMAID/ElementID_ (e.g. datamineragent:420)

   - _elementtype:Type_ (e.g. elementtype:DVE)

   - _virtualfunction:FunctionName_ (e.g. virtualfunction:RT_DCF_DVE_Encoder.Encoder.1)

   - _virtualfunction:DMAID/FunctionID_ (e.g. virtualfunction:420/502)

   - _virtualfunctionimpact:Impact_ (e.g. virtualfunctionimpact:1)

   - _interface:InterfaceName_ (e.g. interface:inout01)

   - _interfaceimpact:Impact_ (e.g. interfaceimpact:1)

   - _keypoint:KeyPoint_ (e.g. keypoint:This is the key point)

   - _offlineimpact:Impact_ (e.g. offlineimpact:No Impact)

   - _owner:Username_ (e.g. owner:Skyline2/Michael)

   - _parameterdescription:DMAID/ElementID/ParameterID_ (e.g. parameterdescription:420/50119/1)

   - _parameterdescription:ProtocolName:Version/ParameterID_ (e.g. parameterdescription:MyTestProtocol:1.0.0.1/1)

   - _protocol:ProtocolName:Version_ (e.g. protocol:MyTestProtocol:Production)

   - _rcalevel:RCALevel_ (e.g. rcalevel:0.0.0)

   - _service:ServiceName_ (e.g. service:Paris)

   - _service:DMAID/ServiceID_ (e.g. service:49/1)

   - _serviceimpact:Impact_ (e.g. serviceimpact:1)

   - _severity:SeverityLevel_ (e.g. severity:Critical)

   - _severityrange:Range_ (e.g. severityrange:High)

   - _source:Source_ (e.g. source:DataMiner System)

   - _status:Status_ (e.g. status:Cleared)

   - _userstatus:UserStatus_ (e.g. userstatus:Acknowledged)

   - _value:ParameterValue_ (e.g. value:69.5)

   - _view:ViewName_ (e.g. view:Root View)

   - _view:ViewID_ (e.g. view:-1)

   - _viewimpact:Impact_ (e.g. viewimpact:1)

   - For an alarm property: _Alarm:PropertyName:PropertyValue_ (e.g. Alarm.System Type:CMC )

   - For an element property: _Element:PropertyName:PropertyValue_ (e.g. Element.Latitude:90)

   - For a service property: _Service:PropertyName:PropertyValue_ (e.g. Service.Status:Running)

   - For a view property: _View:PropertyName:PropertyValue_ (e.g. View.Location:Izegem)

   - For a predefined alarm filter, simply specify the filter name. However, note that this is only supported for public alarm filters.

   > [!NOTE]
   >
   > - Prior to DataMiner 9.6.0 \[CU21\]/10.0.0 \[CU9\]/10.1.1, only filters with properties are supported.
   > - You can define a custom name for the alarm tab page by adding "_TabName=_" followed by the custom name to the value of the **AlarmFilter** data field, separated from the actual alarm filter with a pipe character (“\|”).
   > - In certain EPM environments, filters can be specified to the left of the timeline in Visual Overview. You can insert these filters in the alarm filter by using the following placeholders:
   >   - _\[ServiceFilterName\]_ refers to the left column.
   >   - _\[ServiceFilterName2\]_ refers to the right column.
   >   - Example: _Alarm.Service:"\[\[ServiceFilterName\]\]" Alarm.Tx:"\[\[ServiceFilterName2\]\]"_

   > [!TIP]
   > See also:
   > [Making a shape filter Alarm Console tabs when clicked](xref:Making_a_shape_filter_Alarm_Console_tabs_when_clicked)

5. Normally, as long as not all configured timelines have been received by the client, a “Loading” message will be displayed in Visual Overview. Optionally, you can disable this, by adding "_EnableLoading=False_" to the **Options** shape data field.

   ```txt
   alarmtimelines|...|EnableLoading=False
   ```

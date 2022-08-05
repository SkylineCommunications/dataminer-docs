---
uid: Making_a_shape_filter_Alarm_Console_tabs_when_clicked
---

# Making a shape filter Alarm Console tabs when clicked

If you add a shape data field of type **AlarmFilter** to a shape, clicking the shape will cause Alarm Console tabs of type *Active alarms linked to cards* only to show alarms that match the alarm filter specified in the field value.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > ALARM]* page.

## Configuring the shape data field

Add a shape data field of type AlarmFilter to the shape, and enter an alarm filter as the value, using the same syntax as in the Alarm Console quick filter.

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

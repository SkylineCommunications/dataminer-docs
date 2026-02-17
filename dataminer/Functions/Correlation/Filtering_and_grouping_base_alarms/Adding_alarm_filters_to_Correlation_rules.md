---
uid: Adding_alarm_filters_to_Correlation_rules
---

# Adding alarm filters to correlation rules

In the Correlation module, the *Alarm Filter* section of the details pane allows you to create a filter to limit the alarms that will be evaluated by the correlation rule.

1. Click *Select a Filter*

1. Select one of the listed properties and create an alarm filter, or select "Saved filters" and select an existing alarm filter.

   - If this is the first (or only) filter condition, select "Is" or "Is Not" to indicate whether the condition has to be true or false.

   - If this is not the first (or only) filter condition, select the operator linking it to the previous one (and, and not, or, or not).

   > [!NOTE]
   > Private alarm filters are not available for use in correlation rules.

1. If you want to add another condition to the filter, click *Add a Filter* and go back to step 2.

1. If you want to delete one of the filter conditions, click the X to the right of the filter.

> [!NOTE]
>
> - If no alarm filtering is applied, the conditions will be evaluated for all alarms. As such, it is generally good practice to use alarm filtering whenever possible in order to reduce the load on the system.
> - In case you want a correlation rule to be triggered upon DataMiner startup, an information event is generated after startup that can be used for this purpose. The event has the following properties:
>   - Element Name: *\[name of the DMA\]*
>   - Parameter Description: Correlation engine (DataMiner Element Control Protocol)
>   - Value: Started
> - Hidden elements are supported in correlation rule alarm filters from DataMiner 10.1.0 [CU13], 10.2.0 [CU1], and 10.2.4 onwards.

---
uid: Excluding_alarms_that_affect_the_SLA
---

# Excluding alarms that affect the SLA

It is also possible to keep a currently active alarm from being included in the SLA calculation. This can be done as follows:

1. Go to the *Current Service Alarms* page of the SLA element.

    > [!NOTE]
    > - If you are using a version of the *Skyline SLA Definition Basic* protocol prior to 2.0.0.15, this page is named the *Affecting Alarms* page instead. The naming of the column headers is also different, mentioning “Affecting Alarm” instead of “Current Active Service Alarm”.
    > - The active alarms will only be displayed on this page if *Active Alarms* is set to *Show* on the *Advanced Configuration* page of the SLA. Note that you need at least security level 3 to change this setting.

2. In the list of alarms, in the column *Current Active Service Alarm Overruled Inclusion State*, select *Not included*.

In addition, you can also exclude real-time and history alarms from the Alarm Console.

To make sure you can use this option, the *PropertyConfiguration.xml* file has to be configured correctly for the custom alarm property. It is of particular importance that the *slaField* attribute is specified and set to “affecting”, and that the values are “No” and “Yes” for the custom alarm property. For instance:

```xml
<Property id="20" type="Alarm" name="SLA Affecting" filterEnabled="true" slaField="affecting" readOnly="false">
  <Entry metric="1">No</Entry>
  <Entry metric="1">Yes</Entry>
</Property>
```

Once this has been configured, make sure you can see the column with this property in the Alarm Console. For more information, see [Changing the layout of the Alarm Console](xref:Working_with_the_Alarm_Console#changing-the-layout-of-the-alarm-console).

Then do the following to exclude or include an alarm from the Alarm Console:

1. Right-click the alarm in the Alarm Console and select *Properties*.

2. In the *Properties* window, go to the *Custom* tab.

3. For the property *SLA Affecting*, change the value as required.

> [!NOTE]
> - The default value of the *SLA Affecting* property is *Yes*.
> - Masked alarms do not affect the SLA calculation.
> - Excluded alarms will also be excluded from SLA reports.
>

---
uid: Excluding_alarms_that_affect_the_SLA
---

# Excluding alarms that affect the SLA

## Excluding currently active alarms from the SLA calculation

You can keep a currently active alarm from being included in the SLA calculation. This can be done as follows:

## [Skyline SLA Definition Basic > 2.0.0.15](#tab/tabid-2)

1. Go to the *Active Service Alarms* page of the SLA element.

   > [!NOTE]
   > The active alarms will only be displayed on this page if *Active Alarms* is set to *Show* on the *Advanced Configuration* page of the SLA. Note that you need at least security level 3 to change this setting.

1. In the list of alarms, in the column *Current Active Service Alarm Overruled Inclusion State*, select *Not included*.

## [Skyline SLA Definition Basic < 2.0.0.15](#tab/tabid-1)

1. Go to the *Affecting Alarms* page of the SLA element.

   > [!NOTE]
   > The active alarms will only be displayed on this page if *Active Alarms* is set to *Show* on the *Advanced Configuration* page of the SLA. Note that you need at least security level 3 to change this setting.

1. In the list of alarms, in the column *Affecting Alarm Overruled Inclusion State*, select *Not included*.

***

## Excluding alarms from the Alarm Console

You can also exclude real-time and history alarms from the Alarm Console.

To make sure you can use this option, the *PropertyConfiguration.xml* file has to be configured correctly for the custom alarm property. It is of particular importance that the *slaField* attribute is specified and set to “affecting”, and that the values are “No” and “Yes” for the custom alarm property. For instance:

```xml
<Property id="20" type="Alarm" name="SLA Affecting" filterEnabled="true" slaField="affecting" readOnly="false">
  <Entry metric="1">No</Entry>
  <Entry metric="1">Yes</Entry>
</Property>
```

Once this has been configured, make sure you can see the column with this property in the Alarm Console. For more information, see [Changing the layout of the Alarm Console](xref:ChangingTheAlarmConsoleLayout).

Then do the following to exclude or include an alarm from the Alarm Console:

1. Right-click the alarm in the Alarm Console and select *Properties*.

1. In the *Properties* window, go to the *Custom* tab.

1. For the property *SLA Affecting*, change the value as required.

> [!NOTE]
>
> - The default value of the *SLA Affecting* property is *Yes*.
> - Excluded alarms will also be excluded from SLA reports.
> - By default, masked alarms affect the SLA calculation. However, you can exclude these automatically by configuring a violation filter that gives them an impact of 0 %. See [Setting a violation filter](xref:Configuring_the_alarm_settings_for_an_SLA#setting-a-violation-filter).

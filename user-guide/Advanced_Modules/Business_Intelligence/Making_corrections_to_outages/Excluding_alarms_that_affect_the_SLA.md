---
uid: Excluding_alarms_that_affect_the_SLA
---

# Excluding alarms that affect the SLA

It is also possible to keep a currently active alarm from being included in the SLA calculation. This can be done as follows:

## [Skyline SLA Definition Basic protocol prior to 2.0.0.15](#tab/tabid-1)

The page is named *Affecting Alarms*.

## [Skyline SLA Definition Basic protocols in the 2.0.0.x range and later](#tab/tabid-2)

The page is named *Active Service Alarms*, with different column headers.

***

1. Go to the above mentioned page of the SLA element(depending on the version of your protocol).

    > [!NOTE]
    >
    > - Depending on the version of the protocol, the column headers will be named differently.
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

Once this has been configured, make sure you can see the column with this property in the Alarm Console. For more information, see [Changing the layout of the Alarm Console](xref:ChangingTheAlarmConsoleLayout).

Then do the following to exclude or include an alarm from the Alarm Console:

1. Right-click the alarm in the Alarm Console and select *Properties*.

2. In the *Properties* window, go to the *Custom* tab.

3. For the property *SLA Affecting*, change the value as required.

> [!NOTE]
> - The default value of the *SLA Affecting* property is *Yes*.
> - Masked alarms do not affect the SLA calculation.
> - Excluded alarms will also be excluded from SLA reports.
>

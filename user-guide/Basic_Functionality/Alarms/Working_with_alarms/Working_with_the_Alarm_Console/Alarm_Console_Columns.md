---
uid: AlarmConsoleColumns
---

# Alarm Console columns

> [!TIP]
> See also: [Alarm Console – Adding columns to the Alarm Console](https://community.dataminer.services/video/alarm-console-adding-columns-to-the-alarm-console/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

Below, all columns available in the Alarm Console are listed. By default, not all columns are shown in Cube. The mentioned column names are the default column names; however, these names can be customized in Cube.

For more information on changing the column layout, see [Changing the column layout in an alarm tab](xref:ChangingTheAlarmConsoleLayout#changing-the-column-layout-in-an-alarm-tab).

- **Icon**: Alarm icon colored according to the alarm severity.

  - For new alarms, the icon is a single vertical line.

  - For correlated alarms and alarm groups, it is a vertical, dashed line.

  - For updated alarm records, a second, thinner vertical line is added next to the first.

- **Focus**: Available from DataMiner 10.0.0/10.0.2 onwards on systems with a Cassandra database. This column displays a focus icon if an alarm is unexpected. See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).

- **Element \> Element name**: The name of the element.

- **Element \> Element description**: The description of the element.

- **Element \> Element type**: The element type, as defined in the protocol.

- **Element \> Polling IP**: The IP address that is used to communicate with the element.

- **Element \> Protocol**: The name of the protocol that the DMA uses to communicate with the element.

- **Parameter description**: User-friendly name of the parameter that triggered the alarm.

- **Parameter**: Name of the parameter that triggered the alarm.

- **Value**: The value of the parameter that triggered the alarm.

- **Time**: The date and time when the alarm event occurred on the device. This can also be the time when the alarm was escalated from a different alarm level.

- **Root time**: The date and time when the first of a series of related alarms occurred on the device.

- **Severity**: The severity level of the alarm, e.g. Warning, Major, Critical, etc.

- **Parameter key**: The display key of the parameter that triggered the alarm, in case of a table parameter.

- **Service impact**: The number of services the alarm has an impact on.

- **Services**: The services the alarm has an impact on.

- **RCA level**: Three values representing the distance to the most probable cause of the alarm for services, elements, and parameters respectively.

- **Alarm type**: One of the following alarm types:

  - **New alarm**: A new alarm event. This means that before this alarm event, the parameter was in normal state.
  
  - **Dropped from** ... : An alarm of which the severity level has dropped from a higher level.

  - **Escalated from** ... : An alarm of which the severity level has increase from a lower level.

  - **Flipped**: An alarm of which the severity level has gone from “low” (e.g. “critical low”) to “high” (e.g. “critical high”) or vice versa.

  - **Acknowledged**: An alarm of which a DataMiner user has taken ownership.

  - **Unresolved**: An alarm of which a DataMiner user has released ownership.

  - **Mask**: An alarm that has been masked by a DataMiner user.

  - **Unmask**: An alarm that has been unmasked by a DataMiner user.

  - **Comment** added: An alarm to which a comment has been added.

  - **Name** changed: An alarm caused by a parameter of which the name has been changed.
  
  - **Service** impact changed: An alarm for which the number of affected services has changed.

  - **View impact changed**: An alarm for which the affected views have changed.

- **Severity duration**: The length of time that the alarm has had its current severity

  > [!NOTE]
  > If history tracking is disabled, prior to DataMiner 10.0.5, no severity duration is displayed. This column is only available in history tabs from DataMiner 10.0.5 onwards, and only in case no filter is applied, or the filter is related to the element ID, DMA ID, element type, parameter ID, protocol ID or source ID. If the duration cannot be calculated, for example because the next alarm is not within the time span of the history tab, "N/A" will be displayed.

- **Owner**: The name of the DataMiner user who has taken ownership of the alarm. If no one has taken ownership of the alarm yet, the field remains empty.

- **Status**: The current status of the alarm:

  - **Open**: The alarm is active, and the parameter that caused the alarm is currently in an alarm state.

  - **Cleared**: The alarm is no longer active; the parameter that caused the alarm has returned to a normal state.

  - **Masked**: The alarm is active, but is currently masked; the parameter that caused the alarm is currently in an alarm state.

- **Extra status**: The masking status of the alarm. This column is available from DataMiner 10.2.0/10.1.4 onwards. It indicates whether an alarm is masked or not.

- **User status**: The ownership status of the alarm:
  
  - **Not Assigned**: None of the DataMiner users have taken ownership of the alarm yet.

  - **Acknowledged**: A DataMiner user has taken ownership of the alarm.

  - **Unresolved**: A DataMiner user took ownership of the alarm but has already released that ownership.

- **Comment**: This column can contain both comments added by DataMiner users and extra information generated by the system.

- **Source**: The creator of the alarm. Usually, this is the DataMiner System, but it can for instance also be the Correlation Engine.

- **Alarm ID**: The unique ID that identifies the alarm record. This ID is for instance used to link alarms to trouble tickets.

- **Root alarm ID**: The ID of the root alarm.

- **Creation time**: The time when the alarm was created in DataMiner.

- **Root creation time**: The time when the first of a series of related alarms was created in DataMiner.

- **Category**: Custom category that can be assigned to a parameter using the information template.

- **Alarm description**: User-friendly description of the alarm, which can be customized with the information template.

- **Corrective action**: Description of corrective actions that should be taken, which can be customized with the information template.

- **Component info**: Contains more information about the nature of the alarm. Used in DataMiner Business Intelligence.

- **Key point**: The exact location in the signal chain where the error has occurred. Used in DataMiner Business Intelligence.

- **Offline impact**: Indicates whether the alarm has an impact during the offline window of an SLA. Used in DataMiner Business Intelligence.

- **Interface impact**: The number of interfaces on which the alarm has an impact.

- **Interfaces**: The interfaces on which the alarm has an impact.

- **View impact**: The number of views affected by the alarm.

- **Views**: The views affected by the alarm.

- **Custom icons**: The custom icon of the element or service. This column is only available in case custom icons have been configured in the system. See [Icons](xref:Icons).

- **Trend**: If average trending is activated on the parameter in alarm, this column displays the trend graph for the last 24 hours.

- **Function impact**: The number of functions the alarm has an impact on. This functionality is part of the Service & Resource Management module. See [Service and Resource Management](xref:SRM#service-and-resource-management).

- **Functions**: The functions the alarm has an impact on. This functionality is part of the Service & Resource Management module. See [Service and Resource Management](xref:SRM#service-and-resource-management).

- **Heatlines \> Element heatline**: This column displays a heatline depicting the element alarm state over the last 24 hours. Only displayed on systems using a Cassandra database.

- **Heatlines \> Parameter heatline**: This column displays a heatline depicting the parameter alarm state over the last 24 hours. For a table parameter, heatlines are generated per table row. Only displayed on systems using a Cassandra database.

- **Actions \> Ownership**: Action button that allows the user to take or release ownership of an alarm.

- **Actions \> Masking**: Action button that allows the user to mask or unmask an alarm.

- **Actions \> Clear alarm**: Action button that allows the user to clear clearable alarms.

- **Actions \> Copy full alarm**: Action button that allows the user to copy all information regarding an alarm in one click.

- **Actions \> Adding comment**: Action button that allows the user to add a comment.

- **Actions \> SMS**: Action button that allows the user to send a text message to a DataMiner user.

- **Actions \> View connectivity**: Action button that allows the user to view the connectivity chain for the parameter, element or service in alarm state.

- **Alarm properties**: Any available custom alarm properties.

- **Element properties**: Any available custom element properties.

- **Service properties**: Any available custom service properties.

- **View properties**: Any available custom view properties.

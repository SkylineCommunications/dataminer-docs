---
uid: Best_practices_for_assigning_alarm_severity_levels
---

# Best practices for assigning alarm severity levels

When assigning [alarm severity levels](xref:Alarm_types#alarm-severity-levels) in an alarm template, keep the best practices below in mind.

## Only assign the severity levels you need

Carefully select your alarm severity levels and always make sure they make sense. After all, alarm messages should be meaningful.

- **Do not monitor parameters just because you can**. It is not necessary and even not advisable to always use every possible severity level.

- Make sure the severity levels are **not too strict**. If you do, this could lead to alarm floods in which critical alarms might get overlooked.

- Make sure the severity levels are **strict enough**, to ensure that the alarms you need do get raised.

- **Constantly evaluate and question** the alarm severity levels you have set and, if necessary, adjust them.

### Analog parameters

In case of analog parameters, different values can be assigned so-called high and low levels.

A parameter like "audio output level" could be assigned the following alarm severity levels.

| Parameter value   | Alarm severity level |
|-------------------|----------------------|
| Lower than -2     | Critical low         |
| Between -2 and 0  | Major low            |
| Between 0 and 3   | Warning low          |
| Equal to 7        | Normal               |
| Between 12 and 15 | Minor high           |
| Higher than 15    | Critical high        |

Note that in the example above, some levels have been left out.

### Discrete parameters

In case of discrete parameters, each value can be assigned a severity level.

A parameter like "fan status" could be assigned the following alarm severity levels.

| Parameter value | Alarm severity level |
|-----------------|----------------------|
| On              | Minor                |
| Off             | Normal               |

A parameter like "input level" could be assigned the following alarm severity levels.

| Parameter value | Alarm severity level |
|-----------------|----------------------|
| Extreme         | Critical             |
| High            | Major                |
| Medium          | Minor                |
| OK              | Normal               |
| Low             | Warning              |
| Very Low        | Critical             |

## Keep alarm trees from growing too large

[Alarm trees](xref:Alarm_trees) "group" the different alarm records representing the lifecycle of an alarm. A record gets added whenever the severity of the alarm changes, as well as when alarm properties change, comments get added, etc.

We recommend keeping the number of alarm records in a single alarm tree **below 1000**. Having too many alarms in a single alarm tree can have a negative impact on the performance of the DMA and the stability of the cluster.

Keeping the alarm tree size under control starts with the alarm template configuration:

- Avoid alarms that **keep toggling between severities without clearing**. Use [hysteresis](xref:Configuring_alarm_hysteresis) to prevent this, or if you get this issue even with hysteresis, check whether the configuration of the alarm template or possibly even the architecture of the protocol needs to be reviewed to avoid toggling frequent alarm updates.

- **Do not disable the [autoclear parameter](xref:Setting_the_autoclear_option_in_alarm_template)** if this is not really necessary. Especially in larger systems, we recommend keeping autoclear enabled. If you do disable autoclear, strict control of a limited number of alarms will be needed to make sure this implementation is successful.

However, other factors may also influence whether you will get excessively large alarm trees:

- Avoid large numbers of alarm **metadata changes** (e.g. properties or comments) leading to large alarm trees. These can for example be caused by Automation scripts or apps triggering a large number of property changes. The impact of these changes can be partially reduced by enabling [alarm squashing](xref:MaintenanceSettings_xml#alarmsettingsmustsquashalarms) in *MaintenanceSettings.xml*, as this will combine such updates in one record in the DataMiner client software, as long as there has not been a severity update in between them.

- When [masking alarms](xref:Masking_and_unmasking_alarms), avoid using the option "**Mask until unmasking**" if possible, as this could hide situations where many alarm updates occur, causing you to remain unaware of this. Instead, either mask for a limited time, or if this is not possible, make sure to review your masked alarms from time to time.

- Avoid keeping **correlated alarms** open for a long time. Alarms triggered by the [Correlation engine](xref:About_DMS_Correlation) that remain open for a long time while ingesting many alarms, have a similar effect on the system. To prevent this, we recommend periodically checking whether older correlated alarms can be cleared.

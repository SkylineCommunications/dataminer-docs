---
uid: Special_parameters_available_in_DMS_Automation_scripts
---

# Special parameters available in Automation scripts

In an Automation script, a number of special parameters allow you to access information about users, redundancy states and correlation information.

The following table lists the special parameters available in Automation scripts.

| Name | ID | Description |
|------|----|-------------|
| \<User Description> | 65000 | The displayed name of the user (only if the script was executed manually by a particular user). |
| \<User Name> | 65001 | The logon name of the user (only if the script was executed manually by a particular user). |
| \<Redundancy Type> | 65003 | The type of redundancy group switch (only if the execution of the script was caused by a redundancy group switch).<br> Values:<br> -  SWITCH_OVER<br> -  SWITCH_BACK |
| \<Redundancy Cause> | 65004 | The cause of a redundancy group switch (only if the execution of the script was caused by a redundancy group switch).<br> Values:<br> -  prioritychanged<br> -  manual<br> -  automatic |
| \<Correlation State> | 65002 | Whether the Correlation rule was triggered because the trigger condition matched the alarm (“up”) or whether it was triggered because the trigger condition no longer matched the alarm (“down”) (only if the script was executed via a Correlation rule).<br> Values:<br> -  up<br> -  down |
| \<Correlation Alarm ID> | 65005 | The ID of the alarm that triggered the Correlation rule (only if the script was executed via a Correlation rule). |
| \<Correlation Alarm Info> | 65006 | A pipe-separated string containing information about the alarm that triggered the Correlation rule (only if the script was executed via a Correlation rule):<br>*0:alarmId\|1:agentId\|2:elementId\|3:parameterId\|4:parameterIdx\|5:rootAlarmId\|6:previousAlarmId\|7:severity\|8:type\|9:status\|10:alarmvalue\|11:alarmTime\|12:serviceRca\|13:elementRca\|14:parameterRca\|15:severityRange\|16:sourceId\|17:userStatus\|18:owner\|19:impactedServices\|20:propertyCount\|propcount\*2\|scriptNamevt0:alarmId\|1:agentId\|2:elementId\|3:parameterId\|4:parameterIdx\|5:rootAlarmId\|6:previousAlarmId\|7:severity\|8:type\|9:status\|10:alarmvalue\|11:alarmTime\|12:serviceRca\|13:elementRca\|14:parameterRca\|15:severityRange\|16:sourceId\|17:userStatus\|18:owner\|19:impactedServices\|20:propertyCount\|propcount\*2\|scriptName*<br> For an example of how to parse the information in this string, see [How do I parse Correlation Alarm Info data?](xref:How_do_I_parse_Correlation_Alarm_Info_data) |

> [!NOTE]
> For more information on how to retrieve the value of a parameter in a script, see [How do I retrieve the current value of a script parameter?](xref:How_do_I_retrieve_the_current_value_of_a_script_parameter)

---
uid: Alarm_Storm_How_To_Handle
---

# What is an Alarm Storm?
When the system gets flooded with alarms, this is not a normal situation and it can potentially block the entire system. To prevent this, Cube will trigger the [alarm storm protection](xref:Alarm_storm_protection).
This is a protective measure to keep the system operational, but it needs to be dealt with.
  
[Alarm storm prevention](xref:Configuring_alarm_storm_prevention_for_notifications) can be configured on 3 levels.

# How do I know there's an Alarm Storm
If there's an alarm storm on the system, it should be quite straight-forward to know, as it's shown in several ways:  
![Alarm Storm Visuals](~/dataminer/images/AlarmStorm_Visuals.jpg)  

1. Alarm popup  
This shows a brief explanation of the alarms coming in
2. Alarm entry  
The column _Parameter Description_ will indicate "Alarm storm" and column _Value_ will tell you how many alarms were generated
3. Alarm Console - visual marker bottom left

# What to do
It's important to understand what triggered the alarm storm, only then you can resolve it.

1. Based on the previous visuals, you already get a direction of the issue. We need to look a bit closer to find the root cause.
   Right-click the entry in the Alarm Console and open the [Alarm Card](xref:Alarm_Cards).  
   ![Alarm Storm Details](~/dataminer/images/AlarmStorm_Details.jpg
   
2. Based on the details in the alarm card, answering the following questions can provide valuable insight to the situation:
   * Which alarm events are recurring the most?  
   * Over what period of time where the alarms accumulated?  
      * Short time period?  
        Then this is most likely due to a specific action.  Some examples:
        A new agent was added, but with an incorrect server configuration, this might generate a large number of sync notices, causing an alarm storm.
      * Recurring or over an extended time period?  
        Most likely a configuration can be improved. Some examples:  
        It's possible that alarms never clear, these stack up and cause an alarm storm. This can have different reasons, like badly written table logic in a connector or having the option [_AutoClear set to false_](xref:MaintenanceSettings.AlarmSettings.AutoClear) in the MaintenanceSettings.xml.
        
  The alarm card in our exampe doesn't provide us much information. We can tell the issue is with Cisco DCM elements, specifically with the colums _Current Severity_ in the _Alarm Overview_ table, but that's about it.  
  
  3. You can gain additional insight by looking at the alarms present in the alarm card of the alarm storm.  
     ![Alarm Storm Results](~/dataminer/images/AlarmStorm_Results.jpg)  
     Here there are recurring alarm updates due to "_Properties Changed_". In our example, a property was recurringly getting updated, causing new alarm events. We don't need this for this property, so we disable the feature ["_Update alarms on value changed_"](xref:Changing_custom_alarm_properties) to avoid these unnecessary alarm updates.


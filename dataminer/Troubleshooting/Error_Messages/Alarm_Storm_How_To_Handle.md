---
uid: Alarm_Storm_How_To_Handle
---

# What is an Alarm Storm?
When the system gets flooded with alarms, this will trigger the [alarm storm protection](xref:Alarm_storm_protection).
In short, it's a protective measure to avoiding the system to get stuck.  
  
[Alarm storm prevention](xref:Configuring_alarm_storm_prevention_for_notifications) can be configured on 3 levels.

# How do I know there's an Alarm Storm
If there's an alarm storm on the system, it should be quite straight-forward to know, as it's shown in several ways:  
![Alarm Storm Visuals](images/AlarmStorm_Visuals.jpg)  

1. Alarm popup  
This shows a brief explanation of the alarms coming in
2. Alarm entry
The column _Parameter Description_ will indicate "Alarm storm" and column _Value_ will tell you how many alarms were generated
3. Alarm Console - visual marker bottom left

# What to do
It's important to understand what triggered the alarm storm, only then you can resolve it.

1. Based on the previous visuals, you already get a direction of the issue. We need to look a bit closer to find the root cause.
   Right-click the entry in the Alarm Console and open the [Alarm Details](xref:Alarm_Cards).
   ![Alarm Storm Details](images/AlarmStorm_Details.jpg)
2. Based on the alarm details you see, you can gain valuable insights:
   * Which alarm events do you find the most?
   * Over what period of time did this alarm event occur?  
      * Short time period 
        Then this is most likely due to a specific action.  Some examples:
        A new agent was added, but with an incorrect server configuration, this might generate a large number of sync notices, causing an alarm storm.
      * Recurring or over an extended time period  
        This is most likely due to a misconfiguration. Some examples:
        If alarms don't clear, they stack up and can cause an alarm storm, this can be due to [_AutoClear=false_](xref:MaintenanceSettings.AlarmSettings.AutoClear) or even because a table parameter was wrongly written in the driver.
        If certain entries fail to sync, this will generate recurring notices and eventually an alarm storm will trigger.
  3. You can also open every alarm present in the Alarm Storm. This can give you additional insight.  
     ![Alarm Storm Results](images/AlarmStorm_Results.jpg)
     Here there are recurring alarm updates due to "_Properties Changed_". This happens when the feature "_Update alarms on value changed_" is enabled. his typically only needs to be enabled when using

have a look at the alarm details to figure out what alarm events are causing the alarm storm. 
The description in the popup gives an indication, but there could still be various alarm events found within the alarm storm itself.


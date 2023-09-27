---
uid: How_do_I_parse_Correlation_Alarm_Info_data
---

# How do I parse Correlation Alarm Info data?

The following sample code shows how you can parse the information in a *\<Correlation Alarm Info>* string:

```cs
ScriptParam paramCorrelationAlarmInfo = engine.GetScriptParam(65006);
string alarmInfo = paramCorrelationAlarmInfo.Value;
string[] parts = alarmInfo.Split('|');
int alarmID = Tools.ToInt32(parts[0]);
int dmaID = Tools.ToInt32(parts[1]);
int elementID = Tools.ToInt32(parts[2]);
int parameterID = Tools.ToInt32(parts[3]);
string parameterIdx = parts[4];
int rootAlarmID = Tools.ToInt32(parts[5]);
int prevAlarmID = Tools.ToInt32(parts[6]);
int severity = Tools.ToInt32(parts[7]);
int type = Tools.ToInt32(parts[8]);
int status = Tools.ToInt32(parts[9]);
string alarmValue = parts[10];
DateTime alarmTime = DateTime.Parse(parts[11]);
int serviceRCA = Tools.ToInt32(parts[12]);
int elementRCA = Tools.ToInt32(parts[13]);
int parameterRCA = Tools.ToInt32(parts[14]);
int severityRange = Tools.ToInt32(parts[15]);
int sourceID = Tools.ToInt32(parts[16]);
int userStatus = Tools.ToInt32(parts[17]);
string owner = parts[18];
string impactedServices = parts[19];
int amountProperties = Tools.ToInt32(parts[20]);
for (int i=0; i<amountProperties; i++)
{
    string propertyName = parts[21 + i*2];
    string propertyValue = parts[21 + i*2 + 1];
    engine.GenerateInformation("Property " + propertyName + " == " + propertyValue);
}
```

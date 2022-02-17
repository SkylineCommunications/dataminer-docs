---
uid: NT_ADD_FILE
---

# NT_ADD_FILE (99)

Adds a new alarm or trend template or updates an existing alarm or trend template.

```csharp
string templateName = "Custom Template";
string protocolName = protocol.ProtocolName;
string protocolVersion = protocol.ProtocolVersion;
string baseTemplateName = "Base Template";
string sFilePath = @"C:\Skyline DataMiner\Protocols\" + protocolName + @"\" + protocolVersion + @"\" + baseTemplateName + ".xml";

XDocument alarmTemplate = XDocument.Load(sFilePath);

// Manipulate alarmTemplate to obtain a new template.
/////....

string[] protocolDetails = new string[3];

protocolDetails[0] = protocolName;
protocolDetails[1] = protocolVersion;
protocolDetails[2] = templateName;

object[] templateDetails = new object[2];

templateDetails[0] = 1; //1 for alarm | 6 for trend
templateDetails[1] = Convert.ToString(alarmTemplate);

protocol.NotifyDataMiner(99 /*NT_ADD_FILE*/, protocolDetails, templateDetails);
```

## Parameters

- protocolDetails (string[]):
  - protocolDetails[0]: Protocol name.
  - protocolDetails[1]: Protocol version.
  - protocolDetails[2]: Template name.
- templateDetails (object[]):
  - templateDetails[0] (int): Type of file to add. 1 = Alarm template, 6 = Trend template.
  - templateDetails[1] (string): Template content.

## Return Value

- Does not return an object.

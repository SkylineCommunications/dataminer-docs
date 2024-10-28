---
uid: NT_EDIT_PROPERTY
---

# NT_EDIT_PROPERTY (62)

Edits a property.

## Parameters

Editing a **single property**:

```csharp
int elementId = 669;
int agentId = 346;
string propertyLocation = "element:"+ elementId + ":" + agentId;

string[] propertyDetails = new string[3];

propertyDetails[0] = "Device Key";
propertyDetails[1] = "read-write";
propertyDetails[2] = "2100";

protocol.NotifyDataMinerQueued(62/*NT_EDIT_PROPERTY*/ , propertyLocation, propertyDetails);
```

- propertyLocation (string): The expected format of the string depends on the type of property:
  - Element property: "element:" + elementId + ":" + agentId
  - View property: "view:" + viewId
  - Service property: "service:" + agentId + ":" + serviceId
  - Alarm property: "alarm:" + id + ":" + agentId + ":" + elementId
- propertyDetails (string[]):
  - propertyDetails[0]: Property name.
  - propertyDetails[1]: Property type. Possible values: read-only, generic, read-write.
  - propertyDetails[2]: Property value.

Editing **multiple properties**:

```csharp
string[] viewIDs = new string[] { "element:669", "element:669" };

object[] propertyValues = new object[]
{
    new string[] { "Site", "read-write", "A" },
    new string[] { "Device Key", "read-write", "2100" }
};

protocol.NotifyDataMiner(62 /*NT_EDIT_PROPERTY*/, viewIDs , propertyValues);
```

- viewIDs (string[]): Array of string formatted as follows: (element|view|service|alarm):ID
- propertyValues (object[]): Array holding a string array for every property that needs to be updated.
  - propertyValues[0…n]: propertyDetails (string[]).

## Return Value

- Does not return an object.

## Remarks

- When you edit properties of alarms that have already been closed, this will create a new alarm entry with the updated properties in the alarm tree of the closed alarm.<!-- RN 23067 -->
- The following method can be used to edit custom properties:

    ````csharp
    private static void EditCustomProperty(SLProtocol protocol, IDType idType, int id, string propertyName, PropertyType propertyType, string propertyValue)
    {
        string sourceType = string.Empty;
        string sPropertyType = string.Empty;
    
        switch (idType)
        {
            case IDType.Element:
               sourceType = "element:";
              break;
            case IDType.View:
               sourceType = "view:";
              break;
            case IDType.Service:
               sourceType = "service:";
              break;
            case IDType.Alarm:
               sourceType = "alarm:";
              break;
        }
    
        switch (propertyType)
        {
            case PropertyType.ReadOnly:
              sPropertyType = "read-only";
              break;
            case PropertyType.Generic:
              sPropertyType = "generic";
              break;
            case PropertyType.ReadWrite:
               sPropertyType = "read-write";
              break;
        }
    
        if (!string.IsNullOrEmpty(sourceType) && !string.IsNullOrEmpty(sPropertyType))
        {
            string propertyLocation = sourceType + id;
            string[] propertyDetails = new string[3];
            
            propertyDetails[0] = propertyName;
            propertyDetails[1] = sPropertyType;
            propertyDetails[2] = propertyValue;
            
            protocol.NotifyDataMinerQueued(62/*NT_EDIT_PROPERTY*/ , propertyLocation, propertyDetails);
        }
        else
        {
            if (string.IsNullOrEmpty(sourceType))
            {
                protocol.Log("QA" + protocol.QActionID + "|Invalid sourceIDType value: " + idType, LogType.Error, LogLevel.NoLogging);
            }
            else
            {
                protocol.Log("QA" + protocol.QActionID + "|Invalid propertyType value: " + propertyType, LogType.Error, LogLevel.NoLogging);
            }
        }
    }
    
    
    public enum IDType
    {
        Element = 0,
        View,
        Service,
        Alarm
    }
    
    public enum PropertyType
    {
        ReadOnly = 0,
        Generic,
        ReadWrite
    }
    ```

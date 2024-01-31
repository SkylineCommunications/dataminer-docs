---
uid: DMS_SET_PARAMETER
---

# DMS_SET_PARAMETER (28)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the[Class Library](xref:ClassLibraryIntroduction) instead.

Sets the value of a specified parameter.

```csharp
DMS dms = new DMS();
object result = new object();

string value = "value";
string user = protocol.UserCookie;

uint dmaID = (uint)protocol.DataMinerID;
uint elementID = (uint)protocol.ElementID;
uint parameterID = 10;
int type = 28;
int subType = 0;

uint[] parameterDetails = { dmaID, elementID, parameterID };
object[] valueDetails = new object[] { user, value };

try
{
    dms.Notify(type/*DMS_SET_PARAMETER*/, subType, parameterDetails, valueDetails, out result);
    
    if (result != null)
    {
        protocol.Log("DMS Notify: " + result.ToString(), LogType.Allways, LogLevel.NoLogging);
    }
}
catch (Exception ex)
{
    protocol.Log("Error: " + ex.Message + "\n\n" + ex.StackTrace, LogType.Allways, LogLevel.NoLogging);
}
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_SET_PARAMETER call, set this to 28.
- subType (int): Specifies the sub type. Not applicable for DMS_SET_PARAMETER calls. Set this to 0.
- parameterDetails (uint[]): Array containing following items:

  - parameterDetails [0]: DataMiner Agent ID
  - parameterDetails [1]: Element ID
  - parameterDetails [2]: Parameter ID

- valueDetails (object[]): Array containing following items:

  - valueDetails[0]: User cookie string
  - valueDetails[1]: Parameter value to set

- result (object): Holds the returned element

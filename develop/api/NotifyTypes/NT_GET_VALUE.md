---
uid: NT_GET_VALUE
---

# NT_GET_VALUE (69)

Gets the value of the specified parameter.

```csharp
uint agentId = 400;
uint elementId = 200;
uint[] elementDetails = new uint[] { agentId, elementId };
int parameterId = 120;

object[] result = (object[]) protocol.NotifyDataMiner(69 /*NT_GET_VALUE*/, elementDetails, parameterId);

if (result != null && result.Length > 4)
{
   // string result = Convert.ToString(result[4]);
}
```

## Parameters

- elementDetails (int[]):
  - elementDetails[0]: The agent ID
  - elementDetails[1]: The element ID
- parameterId (int): The parameter ID.

## Return Value

- (object[]): The parameter details. The parameter value is found in result[4].
  - In case a standalone parameter was retrieved, the returned object is an object array containing the following information:
    - result[0] (int): Parameter ID
    - result[1] (string): Parameter description
    - result[2] (string):
    - result[3] (string): Unit
    - result[4] (type depends on parameter): Parameter value
    - result[5] (int):
    - result[6] (string):
    - result[7] (DateTime): Deprecated
    - result[8] (DateTime): Last change time
    - result[9] (string): Name of the user who last changed the parameter.
    - result[10] (int): Alarm status (1: Normal, 2: Warning, 3: Minor, 4: Major, 5: Critical)
    - result[11] (int):
    - result[12] (int):
  - In case a table or matrix was retrieved, the returned object is an object array. result[4] will hold the table data and be of type object[]. Each element from this array represents a column.

Example retrieving table:

```csharp
uint agentId = 400;
uint elementId = 200;
uint[] elementDetails = new uint[] { agentId, elementId };
int parameterId = 1000;
object[] result = (object[]) protocol.NotifyDataMiner(69 /*NT_GET_VALUE*/, elementDetails, parameterId);

if (result != null && result.Length > 4)
{
    object[] tableColumns = ((object[])result[4]);

    for (int j = 0; j < tableColumns.Length; j++)
    {
        object[] tableColumn = (object[])tableColumns[j];
        
        for (int k = 0; k < tableColumn.Length; k++)
        {
            object[] tableCell = (object[])tableColumn[k];
            
            protocol.Log("QA" + protocol.QActionID + "|table["+j+","+k+"]: " + tableCell[0], LogType.Error, LogLevel.NoLogging);
        }      
    }         
}
```

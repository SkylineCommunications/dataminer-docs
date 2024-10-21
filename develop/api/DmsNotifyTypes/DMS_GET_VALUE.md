---
uid: DMS_GET_VALUE
---

# DMS_GET_VALUE (87)

> [!WARNING]
> The use of DMS Notify types has been deprecated. Use types from the [Class Library](xref:ClassLibraryIntroduction) instead.

Retrieves details about a parameter (including the value).

```csharp
uint dmaID = 346;
uint elementID = 115;

int type = 87;
int subType = 0;

uint[] ids = new uint[] { dmaID, elementID };
int parameterID = 5;

DMS dms = new DMS();
object result = new object();
dms.Notify(type/*DMS_GET_VALUE*/ , subType, ids, parameterID, out result);

object[] parameterDetails = (object[])result;
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_VALUE call, set this to 87.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_VALUE calls. Set this to 0.

  - ids (uint[]):

    - ids[0]: DataMiner Agent ID
    - ids[1]: element ID

  - parameterID (int): ID of the requested parameter.
  - result (object):

    - In case a standalone parameter was retrieved, the returned object is an object array containing the following information:

      - result[0] (int): parameter ID
      - result[1] (string): parameter description
      - result[2] (string):
      - result[3] (string): unit
      - result[4]: Parameter value, type depends on parameter type.
      - result[5] (int):
      - result[6] (string):
      - result[7] (DateTime):
      - result[8] (DateTime):
      - result[9] (string): Name of the user who last changed the parameter.
      - result[10] (int): Alarm status (1: Normal, 2: Warning, 3: Minor, 4: Major, 5: Critical)
      - result[11] (int):
      - result[12] (int):

    - In case a table or matrix was retrieved, the returned object is an object array. result[4] will hold the table data and be of type object[]. Each element from this array represents a column.

## Remarks

- This call only works for parameters that have RTDisplay set to true. If you want to be able to use this call but do not want the parameter to be visible in the connector, set RTDisplay to true but do not specify a position.
- When you call any of the protocol get methods to retrieve a value of a parameter on the same element, the value will be retrieved from the SLProtocol process. When you call a DMS_GET_VALUE (dms.Notify(87)) to retrieve a value of a parameter on another element of the DMS, the value will be retrieved from the SLElement process.

## Examples

Standalone parameter:

```csharp
uint dmaID = 346;
uint elementID = 1632;

uint[] ids = new uint[] { dmaID, elementID };
int parameterID = 110;

DMS dms = new DMS();
object result = new object();
dms.Notify(87/*DMS_GET_VALUE*/ , 0, ids, parameterID, out result);

if (result != null)
{
    object[] parameterDetails = (object[])result;
    string value = Convert.ToString(parameterDetails[4]);

    ////...
}
```

Table or matrix parameter:

```csharp
uint dmaID = 346;
uint elementID = 1632;

uint[] ids = new uint[] { dmaID, elementID };

int parameterID = 1000;

DMS dms = new DMS();
object result = new object();
dms.Notify(87/*DMS_GET_VALUE*/ , 0, ids, parameterID, out result);

object[] table = (object[])result;
object[] columns = (object[])table[4];

if (columns != null)
{
    for (int c = 0; c < columns.Length; c++)
    {
        object[] rows = (object[])columns[c];

        for (int r = 0; r < rows.Length; r++)
        {
            if (rows[r] != null) // Check if cell not initialized.
            {
                object[] indexID = (object[])rows[r];
                
                ////...
            }
            else
            {
                ////...
            }
        }
    }
}
```

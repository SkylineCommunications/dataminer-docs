---
uid: NT_GET_DATA
---

# NT_GET_DATA (60)

Gets the raw data of the specified item.

```csharp
string itemType = "parameter";
int itemID = 110;
object data = protocol.NotifyProtocol(60, itemType, itemID);

if (data != null)
{
    object[] dataBytes = (object[])data;
    byte[] bytes = new byte[dataBytes.Length];

    Array.Copy(dataBytes, bytes, bytes.Length);

    ////...
}
else
{
    ////...
}
```

## Parameters

- itemType (string): The type of the item. Currently only "parameter" is supported.
- itemID (int): The ID of the item.

## Return Value

- (object): An object array where each item is a byte. In case the specified item does not exist, a null reference is returned.

## Remarks

- The SLProtocol interface defines a wrapper method "GetData" for this call. See [SLProtocol.GetData](xref:Skyline.DataMiner.Scripting.SLProtocol.GetData*) method and [SLProtocol.IsEmpty](xref:Skyline.DataMiner.Scripting.SLProtocol.IsEmpty*) method.

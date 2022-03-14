---
uid: NT_GET_AVAILABLE_FILES
---

# NT_GET_AVAILABLE_FILES (98)

Retrieves available protocols.

```csharp
int fileType = 0; // Protocols
int versionType = 0;

object[] protocols = (object[])protocol.NotifyDataMiner(98 /*NT_GET_AVAILABLE_FILES*/, fileType, versionType);

if (protocols.Length > 0)
{
    for (int i = 0; i < protocols.Length; i++)
    {
        string[] protocolInfo = (string[])protocols[i];

        if (protocolInfo.Length > 0)
        {
            string protocolName = protocolInfo[0];
            string protocolType = protocolInfo[1];
            string protocolSignedVersions = protocolInfo[2];
            string protocolParentProtocol = protocolInfo[3];

            for (int j = 4; j < protocolInfo.Length; j++)
            {
                string protocolVersion = protocolInfo[j];
            }
        }
    }
}
```

## Parameters

- (int) fileType: 0 for protocols.
- (int) version: Specifies the version of the info to be returned.

## Return Value

- protocols (object[]): Array of string arrays containing information about every protocol on the DMA. For version 0, the return value is structured as follows:
  - protocols[0….n]: protocolInfo (string[])
    - protocolInfo[0]: Protocol name.
    - protocolInfo[1]: Protocol type (Enumeration).
    - protocolInfo[2]: List of signed protocols.
    - protocolInfo[3]: Parent protocol (DVE child protocols).
    - protocolInfo[4…i]: Protocol versions (Production version: "Production:a.b.c.d".

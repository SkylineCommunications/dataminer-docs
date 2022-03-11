---
uid: NT_SNMP_GET
---

# NT_SNMP_GET (295)

Performs SNMP get operation(s).

Retrieving a **standalone parameter**:

```csharp
int elementId = protocol.ElementID;
string ipPort = "127.0.0.1";
int multipleGet = 0;
string instance = string.Empty;
int connectionId = 0;
string getCommunityString = null;
bool splitErrors = false;
int agentId = protocol.DataMinerID; // For DELT compatibility.

object[] elementInfo = new object[] { elementId, ipPort, multipleGet, instance, connectionId, getCommunityString, splitErrors, agentId };

string systemContactOid = "1.3.6.1.2.1.1.4.0";
string[] oidInfo = new string[] { systemContactOid };

object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);
```

Retrieving a *single column and its instance*:

```csharp
int elementID = 117;
string ipPort = "127.0.0.1:161";
int multipleGet = 0;
string instancePart = ".1"; // Instance (not total instance but used like subtable), value must start with "."
int connectionID = 0;
string getCommunityString = null;
bool splitErrors = false;
int agentId = protocol.DataMinerID; // For DELT compatibility.

object[] elementInfo = new object[] { elementID, ipPort, multipleGet, instancePart, connectionID, getCommunityString, splitErrors, agentId };

string[] oidInfo = new string[] { "1.3.6.1.2.1.10.127.7.1.11.1.3:tablev2" };
object[] response = (object[]) protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);
object[] result = null;

if (response.Length == 1)
{
    result = (object[])response[0];

    if (result.Length > 1)
    {
        object[] instances = (object[])result[0];
        object[] values = (object[])result[1];

        for (int i = 0; i < instances.Length; i++)
        {
            string instance = Convert.ToString(instances[i]);
            string value = Convert.ToString(values[i]);
        }
    }
}
```

## Parameters

- elementInfo (object[]): Array containing information about the element. The array must at least contain the first 5 entries. The remaining entries are optional. Non-mandatory fields can be left uninitialized (null) to fall back to the default value.
  - elementInfo[0] (int): Element ID.
  - elementInfo[1] (string): Destination IP address (optionally with the destination port).
  - elementInfo[2] (int): multipleGet: 0=False, 1=True.
  - elementInfo[3] (string): Instance.
  - elementInfo[4] (int): Connection ID (default 0).

    > [!NOTE]
    > Since DataMiner 9.5.0 [CU7]/9.5.10 (RN 17917), it is possible to specify the ID of an SNMPv3 interface.

  - elementInfo[5] (string): Get community (Feature introduced in DataMiner 7.5.0 RN 4048)
  - elementInfo[6] (bool): Split errors from values. Default: False.
  - elementInfo[7] (int): DataMiner Agent ID. Default: local DataMiner Agent ID.
  - elementInfo[8] (int): Dynamic poll type.

    Possible values:
    - 0: Fallback
    - 1: MultipleGet
    - 2: SingleGets

    Default: 2 (SingleGets).
  - elementInfo[9] (string): Destination port. Default: The interface port value.

    Request array must be of length 11 or lower. When a port is specified in the Destination address field, this port value will not be overwritten by the value specified here.

  - elementInfo[10] (int): Timeout. Default: The interface port value.

    Request array must be of length 11 or lower.

  - elementInfo[11] (int): Retries. Default: The interface retry count.
  - elementInfo[12] (object[] of length 6): SNMPv3 authentication and encryption settings.
    - [0]: (string) Username. Default: empty string ("").
    - [1] (int): Security level. Possible values:
      - 1: No authentication, no encryption
      - 2: Authentication, no encryption
      - 3: Authentication, Encryption
      
      Default: 1 (No authentication, no encryption)

    - [2] (int): Authentication algorithm. Possible values:
      - 1: None
      - 2: HMAC-MD5
      - 3: HMAC-SHA

      Default: 1 (None)
    - [3] (string): Authentication password. Default: empty string ("").
    - [4] (int): Encryption algorithm. Possible values:
      - 1: None
      - 2: DES
      - 3: N/A, deprecated
      - 4: AES128

      Default: 1 (None)
    - [5] (string): Encryption passphrase. Default: empty string ("")

  - elementInfo[13]: (int) Specifies the value for the max-repetitions field in the BulkPDU. Default: 6. Should be a value of at least 1. (If no value is specified, or if the specified value is 0 or less, the default number of repetitions (6) will be passed along.

  Supported from DataMiner 10.0.2 onwards (RN 23888).

  > [!NOTE]
  > Apart from the maximum value of an Int32 (2^31-1), there are no constraints as to the maximum value you can specify. You should therefore use this option with caution. The higher this value is set, the higher the stress on the network and the device in question.

  - elementInfo[14] (string): Optional. GUID of entry in credentials library. Supported from DataMiner 10.0.11 (RN 27275) onwards.

    If you pass a GUID, you do not need to pass any credentials.

    If you do not pass a GUID or you pass an empty string instead of a GUID, you must pass credentials in plain text. When you pass neither a GUID nor plain-text credentials, the request will be considered invalid.

    > [!NOTE]
    >
    > - Library credentials take precedence over plain-text credentials.
    > - If you pass an invalid GUID (either a non-existing GUID or a GUID of an incorrect type), the request will be considered invalid. There will be no fallback to plain-text credentials.

- oidInfo (string[]): Array containing the OIDs that need to be retrieved.

  Format: "OID:TYPE:METHOD", where TYPE and METHOD are optional.

  - Possible values for TYPE:
    - ASCII
    - UTF8
    - HEX
    - DECIMAL
    - STRING
  
    Default value for TYPE: Double

  - Possible values for METHOD:
    - SINGLE
    - TABLE
    - TABLEv2
    - INSTANCE
    - GETNEXT

    Default value for METHOD: Multiple get

## Return Value

- (object[]): Array containing the values of the requested OIDs. The size of the object array equals the number of SNMP sets that were issued (i.e. the size of the oidInfo array).

## Remarks

- Supported since DataMiner version 7.5.0. The optional entries in the elementInfo array are introduced in DataMiner 9.5.12 (RN 18077).
- For SNMPv2, in case the variable binding could not be retrieved, one of the following values can be returned:
  - 128: noSuchObject
  - 129: noSuchInstance
- From DataMiner 9.6.3 (RN 20727) onwards, if the “multiple get” flag (elementInfo[2]) is 0, separate SNMP messages will be used to poll each OID, and if the “multiple get” flag (elementInfo[2]) is 1, a single SNMP message will be used to poll the OIDs.
- To perform an SNMP Get request in protocol that has no SNMP connection defined, refer to <xref:NT_SNMP_RAW_GET>.

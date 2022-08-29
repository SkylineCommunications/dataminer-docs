---
uid: NT_SNMP_GET
---

# NT_SNMP_GET (295)

Performs SNMP get operation(s).

In the following example, a single OID is retrieved. The result object will be an object array of size 1 that contains the value of the specified OID.

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

string oidValue = Convert.ToString(result[0]);
```

In the following example, a column and the instance are retrieved.

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

- **elementInfo** (object[]): Array containing information about the element. The array must at least contain the first 5 entries. The remaining entries are optional. Non-mandatory fields can be left uninitialized (null) to fall back to the default value.
  - elementInfo[0] (int): Element ID.
  - elementInfo[1] (string): Destination IP address (optionally with the destination port).
  - elementInfo[2] (int): multipleGet: 0=False, 1=True. When set to True, the OIDs specified in oidInfo will be combined in a single SNMP getRequest that contains multiple variable bindings. If set to False, each OID results in a separate getRequest with a single variable binding.
  - elementInfo[3] (string): Instance.
  - elementInfo[4] (int): Connection ID (default 0).
  - elementInfo[5] (string): Get community string (Feature introduced in DataMiner 7.5.0 RN 4048)
  - elementInfo[6] (bool): Split errors from values. Default: False.
  - elementInfo[7] (int): DataMiner Agent ID. Default: local DataMiner Agent ID.
  - elementInfo[8] (int): Dynamic poll type. Default: 2 (SingleGets).

    Possible values:
    - 0: Fallback
    - 1: MultipleGet
    - 2: SingleGets
  
  - elementInfo[9] (string): Destination port. Default: The interface port value.

    Request array must be of length 11 or lower. When a port is specified in the Destination address field, this port value will not be overwritten by the value specified here.

  - elementInfo[10] (int): Timeout. Default: The interface port value.

    Request array must be of length 11 or lower.

  - elementInfo[11] (int): Retries. Default: The interface retry count.
  - elementInfo[12] (object[] of length 6): SNMPv3 authentication and encryption settings.
    - [0]: (string) Username. Default: empty string ("").
    - [1] (int): Security level. Default: 1 (No authentication, no encryption). Possible values:
      - 1: No authentication, no encryption
      - 2: Authentication, no encryption
      - 3: Authentication, Encryption
    - [2] (int): Authentication algorithm. Default: 1 (None). Possible values:
      - 1: None
      - 2: HMAC-MD5
      - 3: HMAC-SHA
    - [3] (string): Authentication password. Default: empty string ("").
    - [4] (int): Encryption algorithm. Default: 1 (None). Possible values:
      - 1: None
      - 2: DES
      - 3: N/A, deprecated
      - 4: AES128
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

- **oidInfo** (string[]): Array containing the OIDs that need to be retrieved.

  Format: "OID:TYPE:METHOD", where TYPE and METHOD are optional.

  - Possible values for TYPE:
    - ASCII
    - UTF8
    - HEX
    - DECIMAL
    - STRING
  
    Default: Double

  - Possible values for METHOD:
    - SINGLE: If ":single" is appended after the OID, this will be retrieved via a separate SNMP Get request.
    - TABLE: (Deprecated.) Indicates that the requested parameter represents a table. Use tablev2 instead.
    - TABLEv2: Indicates that the requested parameter represents a table.
    - INSTANCE: Indicates that is an instance value.
    - GETNEXT: Performs a GetNext request.

## Methods

### SINGLE

In the following example, three OIDs are requested. The multipleGet setting in the elementInfo object has been set to true, meaning that the OIDs should be requested using a GetRequest with multiple variable bindings. However, note that the last OID has the "SINGLE" suffix. As a result, the OID will be requested using a separate SNMP getRequest.

> [!NOTE]
> We recommend that you always put the parameters with the ":single" suffix at the end of the group so the other parameters get grouped into one request.

The result object is an object array with size equal to the number of requested OIDs.

```csharp
int elementId = protocol.ElementID;
string ipPort = "127.0.0.1";
int multipleGet = 1;
string instance = string.Empty;
int connectionId = 0;
string getCommunityString = null;
bool splitErrors = false;
int agentId = protocol.DataMinerID; // For DELT compatibility.

object[] elementInfo = new object[] { elementId, ipPort, multipleGet, instance, connectionId, getCommunityString, splitErrors, agentId };

string sysContactOid = "1.3.6.1.2.1.1.4.0";
string sysNameOid = "1.3.6.1.2.1.1.5.0";
string sysLocationOid = "1.3.6.1.2.1.1.6.0:SINGLE";

string[] oidInfo = new[] { sysContactOid, sysNameOid, sysLocationOid };

object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);

string sysContactOidValue = Convert.ToString(result[0]);
string sysNameOidValue = Convert.ToString(result[1]);
string sysLocationOidValue = Convert.ToString(result[2]);
```

### TABLE

(Deprecated, use tablev2 instead.)

To retrieve a table via the TABLE method, the entry in oidInfo should be a semicolon-separated list of OIDs where the first entry specifies the OID of the table and the subsequent OIDs specify the OIDs of the columns that should be retrieved (e.g. `1.3.6.1.2.1.2.2.1;1.3.6.1.2.1.2.2.1.2;1.3.6.1.2.1.2.2.1.3:TABLE`).

This will result in GetNextRequest PDUs being sent out (to retrieve the instance values) followed by multiple GetRequest PDUs containing multiple variable bindings (to retrieve the column values). The result object is a table that has as its first column the instance values. The remaining columns are the values of the columns specified in the request.

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

string ifEntry = "1.3.6.1.2.1.2.2.1";
string ifDescr = "1.3.6.1.2.1.2.2.1.2";
string ifType = "1.3.6.1.2.1.2.2.1.3";

string[] oidInfo = new string[] { $"{ifEntry};{ifDescr};{ifType}:TABLE" };

var result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);

object[] table = (object[])result[0];

for(int i=0; i<table.Length; i++)
{
  var column = (object[])table[i];

  for(int j=0; j<column.Length; j++)
  {
    var cellValue = Convert.ToString(column[j]);
    //// ...
  }
}
```

### TABLEV2

To retrieve a table via the TABLEV2 method, the entry in oidInfo should be a semicolon-separated list of OIDs of the columns that should be retrieved (e.g. `1.3.6.1.2.1.2.2.1.2;1.3.6.1.2.1.2.2.1.3:TABLEV2`).

This will result in GetBulkRequest PDUs being sent out. The number of maxRepetitions to use in the GetBulkRequest can be specified in the elementInfo object. The default value is 6.
The result object is a table that has as its first column the instance values. The remaining columns are the values of the columns specified in the request.

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

string ifDescr = "1.3.6.1.2.1.2.2.1.2";
string ifType = "1.3.6.1.2.1.2.2.1.3";

string[] oidInfo = new string[] { $"{ifDescr};{ifType}:TABLEV2" };

var result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);

object[] table = (object[])result[0];

for(int i=0; i<table.Length; i++)
{
  var column = (object[])table[i];

  for(int j=0; j<column.Length; j++)
  {
    var cellValue = Convert.ToString(column[j]);
    //// ...
  }
}
```

### INSTANCE

The "INSTANCE" suffix can be used to indicate that the value from this OID should be used as the instance value for the next OID specified in the oidInfo object.

For example, consider the following oidInfo object:

```csharp
string instanceOid = "1.9.9.9.9.9.9.9.0:instance";
string columnOid = "1.3.6.1.2.1.2.2.1.7"; // ifAdminStatus

string[] oidInfo = new[] { instanceOid, columnOid };
```

The first entry specifies the OID of the item that holds the value that should be used as the instance value for the next OID specified in oidInfo. Suppose the value of the instanceOid is 4, then the resulting OID for the second item in oidInfo will be `1.3.6.1.2.1.2.2.1.7.4`.

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

string instanceOid = "1.9.9.9.9.9.9.9.0:INSTANCE";
string columnOid = "1.3.6.1.2.1.2.2.1.7"; // ifAdminStatus column.

string[] oidInfo = new[] { instanceOid, columnOid };

object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);

string instanceValue = Convert.ToString(result[0]);
string ifAdminStatusValue = Convert.ToString(result[1]);
```

### GETNEXT

When the "GETNEXT" suffix is added, a GetNextRequest will be performed. The result will contain the value of the OID that is lexicographically next to the specified OID in the request. In the example below, the oidInfo object contains `1.3.6.1.2.1.1.4.0:GETNEXT`. The result object will contain the value of OID `1.3.6.1.2.1.1.5.0`.

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

string sysContactOid = "1.3.6.1.2.1.1.4.0:GETNEXT";

string[] oidInfo = new[] { sysContactOid };

object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, oidInfo);

string sysNameOidValue = Convert.ToString(result[0]);
```

> [!NOTE]
> A returned value of 130 could indicate "endOfMibView". This value is returned if the specified OID does not lexicographically precede any variable accessible by this request (i.e. there is no lexicographic successor).

## Remarks

- For SNMPv2, in case the variable binding could not be retrieved, one of the following values can be returned:
  - 128: noSuchObject
  - 129: noSuchInstance
- From DataMiner 9.6.3 (RN 20727) onwards, if the “multiple get” flag (elementInfo[2]) is 0, separate SNMP messages will be used to poll each OID, and if the “multiple get” flag (elementInfo[2]) is 1, a single SNMP message will be used to poll the OIDs.
- To perform an SNMP Get request in protocol that has no SNMP connection defined, refer to <xref:NT_SNMP_RAW_GET>.

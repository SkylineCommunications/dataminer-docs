---
uid: NT_SNMP_SET
---

# NT_SNMP_SET (292)

Performs SNMP set operation(s).

```csharp
int elementId = protocol.ElementID;
string ipPort = "127.0.0.1";
int multipleSet = 0;
string instance = string.Empty;
int connectionId = 0;
string setCommunityString = null;
bool enableRetries = false;
int agentId = protocol.DataMinerID; // For DELT compatibility.

object[] elementInfo = new object[] { elementId, ipPort, multipleSet, instance, connectionId, setCommunityString, enableRetries, agentId };

string oid = "1.3.6.1.2.1.1.4.0";
string value = "john.doe@foo.com";
int snmpType = 2;

object[] systemContactInfo = new object[] { oid, value, snmpType };

object[] oidInfo = new object[] { systemContactInfo };

object[] result = (object[])protocol.NotifyProtocol(292/*NT_SNMP_SET*/, elementInfo, oidInfo);
```

## Parameters

- elementInfo (object[]): Array containing information about the element. The first five fields are mandatory. Non-mandatory fields can be left uninitialized (null) to fall back to the default value.
  - elementInfo[0] (int): Element ID.
  - elementInfo[1] (string): Destination IP address (optionally with the destination port).
  - elementInfo[2] (int): Multipleset: 0 = False, 1 = True.
  - elementInfo[3] (string): Instance.
  - elementInfo[4] (int): Connection ID (default 0).

    > [!NOTE]
    >
    > - If a connection ID of a connection defined in the protocol is specified, all the settings that are set on that interface (IP, community string, credentials, timeout, etc.) will be used. If you override some (or all) of these values with their dedicated field, they will override the interface setting for that specific GET/SET.
    > - Since DataMiner 9.5.0 [CU7]/9.5.10 (RN 17917), it is possible to specify the ID of an SNMPv3 interface.

  - elementInfo[5] (string): Set community string. Default: interface set community string.
  - elementInfo[6] (boolean): False = no retries, true = interface retry count. Default: false.
  - elementInfo[7] (int): DataMiner Agent ID. Default: Local DataMiner Agent ID.
  - elementInfo[8] (object[] of length 6): SNMPv3 authentication and encryption settings.
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
  - elementInfo[9] (uint): port number

    > [!NOTE]
    > If a port is specified in elementInfo[1], then the value specified elementInfo[1] will have precedence over the one passed along in the dedicated field.
  - elementInfo[10] (int): timeout
  - elementInfo[11] (string): (Optional. GUID of entry in credentials library. Supported from DataMiner 10.0.11 (RN 27275) onwards.

    If you pass a GUID, you do not need to pass any credentials.

    If you do not pass a GUID or you pass an empty string instead of a GUID, you must pass credentials in plain text. When you pass neither a GUID nor plain-text credentials, the request will be considered invalid.

    > [!NOTE]
    >
    > - Library credentials take precedence over plain-text credentials.
    > - If you pass an invalid GUID (either a non-existing GUID or a GUID of an incorrect type), the request will be considered invalid. There will be no fallback to plain-text credentials.

    - oidInfo (object[]): Array containing object arrays for all sets that need to be performed.
      - oidInfo[0…n] (object[]): SNMP set details
        - oidInfoN[0] (string): OID that needs to be set.
        - oidInfoN[1] (string/double): Value that needs to be set.

          > [!NOTE]
          > From DataMiner 9.5.0 [CU7]/9.5.10 (RN 18034) onwards, it is also possible to set integer values for SNMPv3.
        - oidInfoN[2] (int): SNMP type indication.

          SNMP types:
          - 0 = null
          - 1 = integer
          - 2 = octetstring
          - 3 = objectid
          - 4 = ipaddress
          - 5 = counter32
          - 6 = gauge32
          - 7 = timeticks
          - 8 = opaque
          - 9 = nsapaddress
          - 10 = uint32
          - 11 = counter64
          - 100 = octetstringascii
          - 101 = octetstringhex
          - 102 = octetstringdecimal
          - 103 = octetstringutf8

## Return Value

- (object[]): Array containing strings that indicate whether the SNMP set succeeded. An empty string means the set succeeded; the string "TIMEOUT" indicates that the set went into timeout. The size of the object array equals the number of SNMP sets that were issued (i.e. the size of the oidInfo array).

## Remarks

- Supported since DataMiner version 7.5.0. The optional entries in the elementInfo array are introduced in DataMiner 9.5.12 (RN 18077).
- To perform an SNMP Set request in a protocol that has no SNMP connection defined, refer to <xref:NT_SNMP_RAW_SET>.

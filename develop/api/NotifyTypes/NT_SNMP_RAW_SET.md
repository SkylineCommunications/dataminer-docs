---
uid: NT_SNMP_RAW_SET
---

# NT_SNMP_RAW_SET (425)

Performs an SNMP SET request without requiring an SNMP connection to be defined in the protocol.<!-- RN 18369 -->

```csharp
object[] versionSpecificSettings = new object[2];

versionSpecificSettings[0] = 3; // SNMP version.

versionSpecificSettings[1] =
    new object[] {
       "User1",         // Username (String)
        3,               // Security Level (Int32)
        3,               // Authentication Algorithm (Int32)
       "AuthAuth1",     // Authentication Password (String)
        2,               // Encryption Algorithm (Int32)
       "PrivPriv1" };   // Encryption Passphrase (String)

object[] settings = new object[7];     // Object array, minimum length = 2

settings[0] = versionSpecificSettings; // Version specific settings.
settings[1] = "127.0.0.2";             // Destination address (String, port is optional).
// Settings: Values with a default fallback when not provided.
settings[2] = 1614;                    // Destination Port (String or Int32, will not overwrite the port specified with the IP address)
settings[3] = 1490;                    // Timeout (Int32)
settings[4] = 1;                       // Retries (Int32)
settings[5] = false;                   // Multiple Set (Boolean)
settings[6] = "";                      // Instance  (String)

object[] oidToSet = new object[3];

oidToSet[0] = "1.3.6.1.2.1.1.8.1.6.1";  // OID.
oidToSet[1] = Convert.ToDouble(20);     // Value to set.
oidToSet[2] = 1;                        // SNMP type indication (1: integer).

object[] oidInfo = new object[] { oidToSet };

var result = (object[])protocol.NotifyDataMiner(425 /*NT_SNMP_RAW_SET*/, settings, oidInfo);

protocol.Log("QA" + protocol.QActionID + "|result: " + result.Length, LogType.Error, LogLevel.NoLogging);

if (result != null && result.Length >= 1)
{
   if(result[0].Equals(""))
   {
        // Set request succeeded.
   }
   else
   {
        // Set request failed.
   }
}
else
{
   protocol.Log("QA" + protocol.QActionID + "|Run|Retrieval failed.", LogType.Error, LogLevel.NoLogging);
   protocol.SetParameter(20, "Failed");
}
```

## Parameters

- settings (object[]): Request info. At least the first two entries must be present.

  - settings[0] (object[]): (Required.) Version-specific information.

    This array (referred to as versionSpecificSettings[] below) contains the SNMP version and information that only applies for specific SNMP versions.

    - versionSpecificSettings[0]: (int) SNMP version. Possible values:

      - 1: SNMPv1
      - 2: SNMPv2
      - 3: SNMPv3

    - versionSpecificSettings[1]:

      - SNMPv1 and SNMPv2: (string) Set community string. Default: "public"
      - SNMPv3: (object[]): Authentication and encryption settings.
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
          - 4: HMAC128-SHA-224
          - 5: HMAC192-SHA-256
          - 6: HMAC256-SHA-384
          - 7: HMAC384-SHA-512

          Default: 1 (None)
        - [3] (string): Authentication password. Default: empty string ("").
        - [4] (int): Encryption algorithm. Possible values:
          - 1: None
          - 2: DES
          - 3: N/A, deprecated
          - 4: AES128
          - 20: AES192
          - 21: AES256

          Default: 1 (None)
        - [5] (string): Encryption passphrase. Default: empty string ("")

          > [!NOTE]
          > Default is used when the object in the array is null or of the wrong type.

  - settings[1] (string): (Required.) Specifies the destination address, which can optionally include the port.

  - settings[2] (string or int): (Optional.) Specifies the destination port. Default: 161.

    > [!NOTE]
    > In case a port is specified in requestSettings[1], that port will be used instead of the one specified here.

  - settings[3] (int): (Optional.) Specifies the timeout in ms. Default: 1500 ms.

    > [!NOTE]
    > The resolution of the timeout is 10 ms.

  - settings[4] (int): (Optional.) Specifies the number of retries. Default: 3.

  - settings[5] (bool): (Optional.) Specifies whether multiple variable bindings is used.

    Default: false.

  - settings[6] (string): (Optional.) Instance. Default: Empty string ("").

    > [!NOTE]
    > Values not provisioned or left null will be initialized with their default value.

  - settings[7] (string): Optional. GUID of entry in credentials library.<!-- RN 27275 -->

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
    - oidInfoN[2] (int): SNMP type indication. SNMP types:
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

- (object[]): Array holding strings indicating whether the SNMP set succeeded or not. An empty string means the set succeeded; the string "TIMEOUT" indicates the set went into timeout. The size of the object array equals the number of SNMP sets that were issued (i.e., the size of the oidInfo array).

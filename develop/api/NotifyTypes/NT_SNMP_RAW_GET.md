---
uid: NT_SNMP_RAW_GET
---

# NT_SNMP_RAW_GET (424)

Performs an SNMP GET request without requiring an SNMP connection to be defined in the protocol.<!-- RN 18369 -->

```csharp
var settings = new object[9];    // Minimum length: 2
var versionSpecificSettings = new object[2];

versionSpecificSettings[0] = 2; // SNMPv2
versionSpecificSettings[1] = "myGetCommunityString";    // Get community string

settings[0] = versionSpecificSettings;    // Version specific settings
settings[1] = "127.0.0.1";         // Destination IP address
settings[2] = 1611;              // Destination port (String or Int32, will not overwrite the port specified with the IP address)
settings[3] = 1490;              // Timeout (ms) (Int32)
settings[4] = 2;                 // Retries (Int32)
settings[5] = false;             // Multiple Get (Boolean)
settings[6] = "";                // Instance (String)
settings[7] = 2;                 // Dynamic poll type: SingleGets (Int32)
settings[8] = false;             // Split errors from values (Boolean)

string[] oidInfo = new string[1];       // String array of OIDs.

oidInfo[0] = "1.3.6.1.2.1.1.8.1.6.1";

object[] result = (object[])protocol.NotifyDataMiner(424 /*NT_SNMP_RAW_GET*/, settings, oidInfo);

if (result != null && result.Length >= 1)
{
   // Request succeeded, process result.
    int value = Convert.ToInt32(result[0]);
   // ...
}
else
{
   // Request failed.
}
```

## Parameters

- settings (object[]): Request info. At least the first two entries must be present.

  - settings[0] (object[]): (Required.) Version-specific information.

    This array (referred to as versionSpecificSettings[] below) contains the SNMP version and information that only applies for specific SNMP versions.

    versionSpecificSettings[0]: (int) SNMP version. Possible values:

    - 1: SNMPv1
    - 2: SNMPv2
    - 3: SNMPv3

    versionSpecificSettings[1]:

    - SNMPv1 and SNMPv2: (string) Get community string. Default: "public"
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

    - settings[7] (int): (Optional.) Dynamic Poll Type. Possible values:

      - 0: Fallback
      - 1: MultipleGet
      - 2: SingleGets

      Default: 2 (SingleGets)

    - settings[8] (bool): (Optional.) Split errors from values. Default: false.

    - settings[9] (string): Optional. GUID of entry in credentials library.<!-- RN 27275 -->

      If you pass a GUID, you do not need to pass any credentials.

      If you do not pass a GUID or you pass an empty string instead of a GUID, you must pass credentials in plain text. When you pass neither a GUID nor plain-text credentials, the request will be considered invalid.

      > [!NOTE]
      >
      > - Library credentials take precedence over plain-text credentials.
      > - If you pass an invalid GUID (either a non-existing GUID or a GUID of an incorrect type), the request will be considered invalid. There will be no fallback to plain-text credentials.

    > [!NOTE]
    > Values not provisioned or left null will be initialized with their default value.

- oidInfo (string[]): Array containing the OIDs that need to be retrieved.

## Return Value

- (object[]): Array holding the values of the requested OIDs. The size of the object array equals the number of items requested.

## Remarks

- If the "multiple get" Boolean (settings[5]) is false, separate SNMP messages will be used to poll each OID, and if the "multiple get" Boolean (settings[5]) is true, a single SNMP message will be used to poll the OIDs.<!-- RN 20727 -->
- Retrieving SNMP data using this method does not affect the timeout state of the element.
- From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43273-->, infinite loop protection is available for NT_SNMP_RAW_GET.

  When an infinite loop is detected, the following will be returned:

  - When the `splitErrors` option is set to false, the error message `INFINITE LOOP` will be returned.

  - When the `splitErrors` option is set to true, the values will be returned.
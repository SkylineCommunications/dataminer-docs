---
uid: Discovery_profiles
---

# Discovery profiles

The following mechanisms are supported for discovery:

- SNMP (see [SNMP discovery](#snmp-discovery))

- HTTP and HTTPS (see [HTTP discovery](#http-discovery))

- Serial (see [Serial discovery](#serial-discovery))

- Telnet (see [Telnet discovery](#telnet-discovery))

- WMI (see [WMI discovery](#wmi-discovery))

Discovery profiles are defined in JSON format and define which information should be retrieved from the device. A discovery profile does not define how to identify a CI Type. This is defined in the conditions of a CI Type.

To make sure discovery profiles can be loaded into DataMiner IDP, they must be stored in the DataMiner Documents folder *Skyline IDP Discovery* > *Discovery*. See [Discovery](xref:Discovery).

> [!NOTE]
> Prior to IDP 1.2.0, if there are CI Types in the system, devices will only be found if a CI Type is linked to the corresponding discovery profile. From IDP 1.2.0 onwards, you can discover devices even if no existing CI Types are linked to the discovery profile.

In general, every profile contains a list of discovery actions. Such an action consists of the following components:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **ProtocolType**: The discovery mechanism. Possible values include:

    - SNMP

    - SNMPv2

    - SNMPv3

    - HTTP

    - HTTPS

    - Serial

    - Telnet

    - WMI

- **Method**: The method to be used. The possible values depend on the value of the *ProtocolType*.

- **Parameter**: The value to get from the device during discovery.

- **Port**: The destination port on the device to send the request to.

- **Options**: This is an optional attribute. Its meaning depends on the value of the *ProtocolType*.

> [!NOTE]
> In a given discovery profile, the *ProtocolType* in the actions has to be the same. In other words, the actions need to use the same discovery mechanism.

## SNMP discovery

SNMP discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **ProtocolType**: This defines the discovery mechanism and is set to *SNMP*, *SNMPv2* or *SNMPv3*.

- **Method**: The method to be used. The supported value for SNMP is *GetRequest*.

- **Parameter**: The value to get from the device during discovery. For SNMP, this contains the OID that needs to be polled from the device.

- **Port**: The destination port on the device to send the request to.

> [!NOTE]
> The “Options” field is not supported for an SNMP discovery action.

In addition to the discovery actions, the discovery profile also needs to contain credentials:

- For **SNMP** or **SNMPv2**, only a get community string has to be configured in the field *getCommunity*.

    The example below illustrates a discovery profile with SNMPv2 discovery actions.

    ```json
    {
     "Actions": [{
     "Method": "GetRequest",
     "Name": "sysDescr",
     "Parameter": "1.3.6.1.2.1.1.1.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysObjectID",
     "Parameter": "1.3.6.1.2.1.1.2.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysUpTime",
     "Parameter": "1.3.6.1.2.1.1.3.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysContact",
     "Parameter": "1.3.6.1.2.1.1.4.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysName",
     "Parameter": "1.3.6.1.2.1.1.5.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysLocation",
     "Parameter": "1.3.6.1.2.1.1.6.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     },
     {
     "Method": "GetRequest",
     "Name": "sysServices",
     "Parameter": "1.3.6.1.2.1.1.7.0",
     "Port": 161,
     "ProtocolType": "SNMPv2"
     }
     ],
     "Credentials": {
     "CommunitySettings": {
     "GetCommunity": "public"

     }
     }
    }
    ```

- For **SNMPv3**, more extensive credentials are needed, as illustrated below:

    ```json
    {
     "Actions": [{
     "Method": "GetRequest",
     "Name": "sysDescr",
     "Parameter": "1.3.6.1.2.1.1.1.0",
     "Port": 16102,
     "ProtocolType": "SNMPv3"
     }
     ],
     "Credentials": {
     "SnmpV3Settings": {
     "Username": "user",
    "SecurityLevel":"AuthPriv",
     "AuthenticationPassword": "public",
     "EncryptionPassword" : "private",
     "AuthenticationAlgorithm" : "HMAC_MD5",
     "EncryptionAlgorithm" : "AES128"
     }
     }
    }
    ```

    The following values are supported for “SecurityLevel”:

    - "None" or "1": No authentication and no privacy.

    - "AuthNoPriv" or "2": Authentication without privacy. This means that authentication is required, but data are not encrypted. An encryption password is not necessary in this case.

    - "AuthPriv" or "3": Authentication with privacy. This means that authentication is required and data are encrypted, so that both an authentication password and an encryption password must be specified.

    The following values are supported for “AuthenticationAlgorithm”:

    - "None" or "1"

    - "HMAC_MD5" or "2"

    - "HMAC_SHA" or "3"

    - "HMAC128_SHA224" or "4"

    - "HMAC192_SHA256" or "5"

    - "HMAC256_SHA384" or "6"

    - "HMAC384_SHA512" or "7"

    The following values are supported for “EncryptionAlgorithm”:

    - "None" or "1"

    - "DES" or "2"

    - "AES128" or "4"

    - "AES192" or "20"

    - "AES256" or "21"

    The following restrictions apply:

    - It is not possible to assign an authentication algorithm when the security level is set to "None".

    - It is not possible to assign an encryption algorithm when the security level is set to "None" or "AuthNoPriv".

    - Up to DataMiner 9.6.11, only "HMAC-SHA" or "HMAC-MD5" are supported for authentication, and only "DES" and "AES128" are supported for encryption.

    - The following combinations of authentication and encryption algorithm are not supported:

        - MD5/SHA-1 and AES192

        - MD5/SHA-1/SHA-224 and AES256

## HTTP discovery

HTTP discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **ProtocolType**: This defines the discovery mechanism and is set to *HTTP*.

    > [!NOTE]
    > To use HTTPS, set *ProtocolType* to *HTTPS* instead. However, in that case the DMA hosting the DataMiner IDP Discovery element must to trust the certificate issued by the device in order to successfully process the response of the device over HTTPS.

- **Method**: The method to be used. The supported value for HTTP is *GET*.

- **Parameter**: The value to get from the device during discovery. For HTTP, this contains the path component of the URI to request.

- **Port**: The destination port on the device to send the request to.

- **Options**: This is an optional attribute. For HTTP, it contains the sequence of attribute-value pairs in the query component of URI

The example below illustrates a discovery profile with one HTTP discovery action.

```json
{
 "Actions": [{
 "Method": "GET",
 "Name": "GET_80",
 "Parameter": "about/index.html",
 "Port": 80,
 "ProtocolType": "HTTP",
 "Options": [{
 "q=version",
 "src=client"
 }
 ]

 }
 ]
}
```

In the example above, the discovery action will perform an HTTP GET towards the device on port 80 using the path and query component */about/index.html?q=version&src=client*.

## Serial discovery

Serial discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **ProtocolType**: This defines the discovery mechanism and is set to *Serial*.

- **Method**: The method to be used. The supported value for serial discovery actions is *GET*.

- **Parameter**: The value to get from the device during discovery. For serial discovery actions, this contains the commands to be sent to the device, which must be in hexadecimal format.

- **Port**: The destination port on the device to send the request to.

> [!NOTE]
> The “Options” field is not supported for a serial discovery action.

The example below illustrates a discovery profile with one serial discovery action.

```json
{
 "Actions": [
 {
 "Method": "GET",
 "Name": "GetModel",
 "Parameter": "030B534F4E59000100B000000D53544154676574204D4F44454C",
 "Port": 53484,
 "ProtocolType": "Serial"
 }
 ]
}
```

> [!NOTE]
> During serial discovery, the command will first be sent via UDP. If the device does not respond in 5 seconds, the command will be sent via TCP.

## Telnet discovery

Telnet discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **Method**: If set to *Welcome*, IDP will only connect to the device and read the first message without sending any command. If set to *Command*, IDP will connect and send the commands specified next to *Parameter*.

- **Parameter**: The commands to be sent if the method is *Command*. If additional steps are required to get to the commands, these must be specified in the *Options* field.

- **Port**: The destination port on the device to connect to.

- **ProtocolType**: This defines the discovery mechanism and is set to *Telnet*.

- **Options**: Any additional steps that are required to get to the commands, in case the method is *Command*. For example, for a Cisco device, before commands can be sent, first an enable command or configure terminal command must be sent.

Credentials can be specified by adding username and password under *GenericSettings*.

For example:

```json
{
 "Actions": [
 {
 "Name": "CheckPrompt",
 "Method": "welcome",
 "Parameter": "",
 "Port": 23,
 "ProtocolType": "Telnet"
 },
 {
 "Name": "Command",
 "Method": "command",
 "Parameter": "cat /etc/os-release",
 "Port": 23,
 "ProtocolType": "Telnet"

 },
 {
 "Name": "Commands",
 "Method": "command",
 "Parameter": "show version",
 "Port": 23,
 "ProtocolType": "Telnet",
 "Options": [
 {
 "Option": "enable"
 },
 {
 "Option": "terminal length 0"
 }
 ]
 }
 ],
 "Credentials": {
 "GenericSettings": {
 "Username": "test",
 "Password": "test123"
 }
 }
}
```

## WMI discovery

WMI discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI Types.

- **ProtocolType**: This defines the discovery mechanism and is set to *WMI*.

- **Method**: The namespace, e.g. *root\\\\cimv2*.

- **Parameter**: The class and the name, e.g. *Win32_Service\\\\Name*.

- **Port**: The destination port on the device to send the request to, by default 135. However, this needs to be checked as WMI has a fixed port and the port cannot be specified when doing WMI queries.

- **Options**: Contains the WQL syntax for instances filtering. Wildcards are supported.

Credentials can be specified by adding username and password under *GenericSettings*.

> [!NOTE]
> - When fields contain a backslash (“\\”), an additional backslash must be placed before it. For example, when the namespace is *root\\cimv2*, the discovery profile should contain *root\\\\cimv2*. - In case the WMI query returns multiple instances, the value of the first instance will be used to evaluate the discovery conditions of a CI Type.

For example:

```json
{
 "Actions": [
 {
 "Name": "System Name",
 "Method": "root\\cimv2",
 "Parameter": "Win32_OperatingSystem\\Name",
 "Port": 135,
 "ProtocolType": "WMI"

 },
 {
 "Name": "SLDataMiner Active",
 "Method": "root\\cimv2",
 "Parameter": "Win32_Service\\Name",
 "Port": 135,
 "ProtocolType": "WMI",
 "Options": [
 {
 "Option": "Name like 'SLDataM%"
 },
 {
 "Option": "Status='OK'"
 }
 ]
 }
 ],
 "Credentials": {
 "GenericSettings": {
 "Username": "JohnD",
 "Password": "ThisIsMyPa$$w0rd"
 }
 }
}
```

In the example above, the first action corresponds to WMI query "SELECT Name from Win32_OperatingSystem". The second action is a query with instance filtering and translates into "SELECT Name FROM Win32_Service WHERE Name like 'SLDataM%' and Status = 'OK'".

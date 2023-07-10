---
uid: CI_Types1
---

# CI Types

CI Types are defined in JSON format and consist of:

- **Conditions**: An array of conditions. A condition defines how, during discovery, a response from the device can be used to identify the device type. The conditions are logically combined in the *ConditionOptions*. See [Conditions](#conditions).

- **ConditionOptions**: Defines how the above conditions are logically combined in order to identify the device type of a discovered device. The condition is referenced by its order in the *Conditions* array. A value "1 or 2" for *ConditionOptions* means that the first condition or the second condition needs to evaluate to true. See [ConditionsOptions](#conditionsoptions).

- **Configurations**: An array of parameter sets. Once the element is created, an ordered sequence of parameter sets can be executed on it. This can be used to fill in a username and a password, or to perform a set on a button. See [Configurations](#configurations).

- **Provisioning**: Contains all information required to create an element. See [Provisioning](#provisioning).

- **SoftwareUpgrades**: An array of software upgrade information, defining which script should be used when a software upgrade needs to be performed on a specific element. See [SoftwareUpgrades](#softwareupgrades).

In addition, the CI Type can also contain the following fields:

- AutoCreate (see [Autocreate](#autocreate))

- SoftwareUpgrade (see [SoftwareUpgrade](#softwareupgrade))

- SoftwareVersionPID (see [SoftwareVersionPID](#softwareversionpid))

The example below illustrates a CI Type with SNMPv2 discovery actions.

```json
{
 "Conditions": [{
 "ActionName": "sysObjectID",
 "DiscoveryTemplate": "SNMP_MIB_II",
 "Match": "StartsWith",
 "Value": "1.3.6.1.4.1.8813.1.1.1.1.1."
 }, {
 "ActionName": "sysObjectID",
 "DiscoveryTemplate": "SNMP_MIB_II",
 "Match": "contains",
 "Value": "1.3.6.1.4.1.8813.1.1.1.1.2"
 }
 ],
 "ConditionsOptions": "1 or 2",

 "Configurations": [{
 "Order": 1,
 "Pid": 2041,
 "Value": "2"
 }, {
 "Order": 2,
 "Pid": 102,
 "Value": "C:\\Skyline DataMiner\\Documents\\RAD Data Communications LA-210\\RegexFlowNames.txt"
 }
 ],
 "AutoCreate": true,
 "Provisioning": {
 "Configuration": {
 "AlarmTemplate": "Template",
 "CreateDVEs": true,
 "Description": "[DNSName]",
 "EnableSnmpAgent": false,
 "EnableTelnet": false,
 "ForceAgent": "",
 "IsHidden": false,
 "IsReadOnly": false,
 "KeepOnline": true,
 "NameSchema": "[$.Provisioning.Configuration.ProtocolName]-[$.Provisioning.Configuration.ProtocolVersion]-[IPAddress]",
 "Ports": [{
 "DMAElementSnmpPortInfo": [{
 "DeviceAddress": "",
 "GetCommunity": "public",
 "IPAddress": "[IPAddress]",
 "LocalPort": null,
 "Network": "",
 "PortId": 0,
 "PortNumber": 161,
 "SetCommunity": "private",
 "Type": "IP",
 "TypeConnection": "SnmpV2"
 }
 ],
 "DMAElementSnmpV3PortInfo": [],
 "DMASerialPortInfo": [],
 "ElementTimeoutTime": 30000,
 "Retries": 3,
 "TimeoutTime": 1500
 }
 ],
 "Properties": [{
 "Name": "IDP CI Type",
 "Value": ""
 }, {
 "Name": "Location Name",
 "Value": "L1"
 }, {
 "Name": "Location Building",
 "Value": "B1"
 }, {
 "Name": "Location Floor",
 "Value": "F1"
 }, {
 "Name": "Location Room",
 "Value": "RM1"
 }, {
 "Name": "Location Aisle",
 "Value": "A1"
 }, {
 "Name": "Location Rack",
 "Value": "R1"
 }, {
 "Name": "Location Rack Position",
 "Value": "5"
 }, {
 "Name": "Location Rack Units",
 "Value": "2"
 }
 ],
 "ProtocolName": "CISCO Manager",
 "ProtocolVersion": "Production",
 "SlowPoll": [{
 "Base": "NO",
 "PingInterval": 30000,
 "Value": 2147483647
 }
 ],
 "SnmpReadCommunityString": "",
 "SnmpWriteCommunityString": "",
 "State": "Active",
 "TimeoutTime": 0,
 "TrendTemplate": "Template",
 "Type": ""
 },
 "DmaId": 0,
 "UpdatePropertyScript": "IDP_Example_Custom_UpdateProperties (2)",
 "View": [-1],
 "ViewName": ["Devices"]
 },
 "ConfigurationMgmt": {
 "AutoDefaultConfiguration": false,
 "AutoDefaultConfigurationDirectory": "c:\\files",
 "AutoDefaultConfigurationScript": "Automation script (3)",
 "BackupConfigurationScript": "ConfigurationBackup",
 "ChecksumParameter": 102,
 "SetChecksumAlarmTemplate": false,
 },
 "Connectivity": {
 "ConnectivityDiscoveryScript": "IDP_Test_Custom_ConnectivityDiscovery"
 },
 "RackManagement": {
 "RackAssignmentScript": "IDP_Example_Custom_RackAssignment (2)"
 },
 "SetBaselineAlarmTemplate": true,
 "SoftwareUpgrade": false,
 "SoftwareUpgrades": [{
 "ImageFileLocation": "C:\\images\\mylocation",
 "ScriptName": "Cisco Nexus Update",
 "Version": "Version 12.2(55)SE3"
 }
 ],
 "SoftwareVersionPID": 5
}
```

## Conditions

This is an array of conditions. A condition references a discovery action and defines how the response of the device can be used to identify the device type.

A condition contains the following mandatory fields:

- **DiscoveryTemplate**: The name of the discovery profile.

- **ActionName**: The name of the action in the discovery profile.

- **Match**: The match operator that will be used to check if the value matches the response of the device. The following values are supported:

    - *Equals*

    - *notEquals*

    - *Contains*

    - *notContains*

    - *startsWith*

    - *endsWith*

- **Value**: The value that will be checked using the match operator against the response of the device.

A conditions evaluates to *True* when the value matches with the response from the device on the referenced discovery action.

> [!NOTE]
> The conditions need to be logically combined in the *ConditionOptions* in order for the device type to be identified. If there is just a single condition, the *ConditionOptions* should be "1".

## ConditionsOptions

This string defines how the conditions are logically combined to identify the device type of a discovered device. The condition is referenced by its order in the *Conditions* array. A value "1 or 2" in the *ConditionOptions* means that the first condition or the second condition needs to evaluate to true.

The following logical operands can be used in the *ConditionsOptions*.

| Operand | Purpose               |
|---------|-----------------------|
| Not     | Logical negation.     |
| !       |                       |
| And     | Logical AND operator. |
| &       |                       |
| &&      |                       |
| Or      | Logical OR operator.  |
| \|      |                       |
| \|\|    |                       |

> [!NOTE]
> - The precedence of the logical operators is as follows: the priority of *Not* is the highest, followed by *And*, followed by *Or*.
> - Parentheses are not supported in the *ConditionsOptions*.

## Configurations

This section allows you to configure parameter sets on the newly created element. It is typically used in case an element requires more configuration than what is available during regular element creation. This can for example be when an element requires that a username or password are configured in dedicated parameters, when a button needs to clicked to connect or to log on to the device, etc.

The *Configurations* item contains an array of parameter sets. The following fields are required:

- **Order**: This integer represents the order in which the parameter set will be executed.

- **Pid**: This integer is the parameter ID of the parameter that needs to be set.

- **Value**: This string is the value that will be set on the parameter.

The example below configures *Administrator* as a username in PID 300, configures the password in PID 311 and clicks a *Login* button by setting value 1 to PID 321.

```json
"Configurations": [
{
 "Order": 1,
 "Pid": 300,
 "Value": "Administrator"
 },
 {
 "Order": 2,
 "Pid": 311,
 "Value": "P@s$w0rd"
 },
{
 "Order": 3,
 "Pid": 321,
 "Value": "1"
 }
]
```

## Provisioning

The provisioning part of the JSON contains all the information required to create an element in DataMiner. It contains the following sections:

- Configuration (see [Configuration](#configuration))

- DmaID (see [DmaID](#dmaid))

- View (see [View](#view))

- ViewName (see [ViewName](#viewname))

> [!NOTE]
> The provisioning part supports the use of keywords (see [Using keywords or placeholders](#using-keywords-or-placeholders)). At runtime, these placeholders are filled in with values.

### Configuration

The *Configuration* section contains the following fields:

| Field name | Description |
|--|--|
| NameSchema | The name of the element. |
| Description | The description of the element. |
| ProtocolName | The name of the protocol. This is case-sensitive. |
| ProtocolVersion | The version of the protocol. Use *Production* to indicate the production version of the protocol. |
| AlarmTemplate | The name of the alarm template for the element. |
| TrendTemplate | The name of the trend template for the element. |
| Ports | Allows you to configure all connections for the element (see [Ports](#ports)) |
| SlowPoll | Allows you to configure the slow poll settings for the element (see [Slowpoll](#slowpoll)). |
| State | The state of the element should be in when it is created. Possible values are *Active*, *Stopped* and *Paused*. |
| IsHidden | Set this field to *True* if you want the element to be hidden. Otherwise, set it to *False*. |
| IsReadOnly | Set this field to *True* if you want the element to be read-only. Otherwise, set it to *False*. |
| CreateDVEs | Indicates whether DVEs should be created for the element |
| Properties | Allows you to configure all properties for the element (see [Properties](#properties)) |
| Type | Deprecated. Set this field to the Element Type specified in the protocol. |
| EnableTelnet | Deprecated. Set this field to *False*. |
| ForceAgent | Deprecated. Can be used on systems before 9.6.0 to link elements to a fixed DMA in a Failover setup. |
| KeepOnline | Deprecated. Set this field to *False*. |
| EnableSnmpAgent | Deprecated. Set this field to *False*. |
| SnmpReadCommunityString | Deprecated. Specify an empty string "". |
| SnmpWriteCommunityString | Deprecated. Specify an empty string "". |
| TimeoutTime | Deprecated. Specify the integer value 0. |

#### Ports

This section allows you to configure all the connections for the element.

The following fields should be configured for each connection:

- **TimeoutTime**: Similar to the *Timeout of a single command (ms)* setting during element creation. It is the period (in milliseconds) during which a DMA will wait for a response after sending a command to the element. This period must be between 10 and 120 000 ms. If there is no response within the specified period, the DMA will send the same command again.

- **Retries**: Similar to the *Number of retries* setting during element creation. This represents the total number of times a DMA is allowed to send the same command again in case it does not receive a response. This number must be between 0 and 10. If, after sending the command the indicated number of times, the DMA still has not received a response from the element, it will move on and continue with the next command to be executed.

- **ElementTimeoutTime**: Similar to the *The element goes into timeout state when it is not responding for (sec)* setting during element creation. When the element fails to respond to commands for longer than the number of seconds specified in this setting, the DMA will put the element in a timeout state. The specified number must be between 0 and 120. Retries

For each connection, this section also has to contain one of the following arrays:

- **DMAElementSNMPPortInfo**: An array of items that allows you to configure the following types of ports:

    - SNMP connections

    - Serial connections using TCP/IP or UDP/IP

    - HTTP(S) connections

    This array consists of the following fields:

    - **TypeConnection**: Represents the type of the connection. The following values are supported:

        - **Snmp** or **SnmpV2**: Indicates an SNMPv1 or SNMPv2 connection, respectively.

        - **Serial** or **SmartSerial**: Indicates a serial or smart-serial connection, respectively.

        - **Http**: Indicates an HTTP(S) connection.

    - **Type**: Allows you to further specify the protocol to be used for the connection. The following values are supported:

        - **IP**: Use this value when the *TypeConnection* is *Snmp*, *SnmpV2* or *Http*, or when it is *Serial* or *SmartSerial* and TCP/IP communication is required.

        - **udp**: Use this value when the *TypeConnection* is *Serial* or *SmartSerial* and UDP/IP communication is required.

    - **IPAddress**: Contains the polling IP of the device. Typically configured with the keyword *\[IPAddress\]* (see [Using keywords or placeholders](#using-keywords-or-placeholders)). This can also be configured in combination with prefixes, e.g. *wss://\[IPAddress\]* or *https://\[IPAddress\]*.

    - **Network**: Allows you to specify a specific network interface (NIC) on the DMA where the element has to communicate with the device. If you specify an empty string, the DMA will automatically select a NIC based on the local IP address configuration.

    - **PortNumber**: Allows you to specify the port number of the device (e.g. 161, 80, etc.).

    - **GetCommunity**: Contains the SNMP get community string and is only relevant when the *TypeConnection* equals *Snmp* or *Snmpv2*. In all other cases, an empty string has to be supplied.

    - **SetCommunity**: Contains the SNMP set community string and is only relevant when the *TypeConnection* equals *Snmp* or *Snmpv2*. In all other cases, an empty string has to be supplied.

    - **DeviceAddress**: Contains the device address and can be relevant for specific protocols. For example, for an HTTP connection, this field could contain *bypassproxy*.

    - **PortID**: Indicates the order of the connection in the element. The first connection in the element needs to be assigned value 1, the second connection needs to have value 2, etc. You can easily verify the order of the connections by editing or creating an element using the protocol in question (see [Adding elements](xref:Adding_elements)).

    - **IsSslTlsEnabled**: Indicates whether SSL/TLS encryption should be enabled, similar to the SSL/TLS checkbox in the element editor in DataMiner Cube (see [Adding elements](xref:Adding_elements)). This is only relevant when *TypeConnection* is *Serial* or *SmartSerial* and *Type* is *IP*. This also requires DataMiner version 10.0.3 or higher. The default value is false.

    - **IsServerModeEnabled**: If this is set to true, the accepted IP addresses (cf. below) can be configured. Otherwise, this is not possible. This boolean is only relevant if *TypeConnection* is *SmartSerial*, *Type* is *IP* and the IP address is "any" or "127.0.0.1".

    - **AcceptedIpAddresses**: Represents the accepted IP addresses. Only relevant if *IsServerModeEnabled* is *true*. Allows you to specify one or more allowed IP addresses for the connection. The element will then only communicate with those IP addresses. This serves the same purpose as the *Accepted IP address* field in the element editor in DataMiner Cube (see [Adding elements](xref:Adding_elements)).

    Below is an example of four connections that are required to create an element.

    - The first connection is an SNMP connection with community strings.

    - The second connection is an HTTP connection.

    - The third connection is a serial connection over TCP/IP.

    - The last connection is a serial connection over UDP/IP.

    ```json
    "Ports": [{
     "DMAElementSnmpPortInfo": [{
     "DeviceAddress": "",
     "GetCommunity": "public",
     "IPAddress": "[IPAddress]",
     "Network": "",
     "PortId": 1,
     "PortNumber": 161,
     "SetCommunity ": "private",
     "Type": "IP",
     "TypeConnection ": "snmp"
     }
     ],
     "DMAElementSnmpV3PortInfo": [],
     "DMASerialPortInfo": [],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     }, {
     "DMAElementSnmpPortInfo": [{
     "DeviceAddress": "",
     "GetCommunity": "",
     "IPAddress": "[IPAddress]",
     "Network": " ",
     "PortId": 2,
     "PortNumber": 80,
     "SetCommunity": "",
     "Type": "IP",
     "TypeConnection": "Http"
     }
     ],
     "DMAElementSnmpV3PortInfo": [],
     "DMASerialPortInfo": [],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     }, {
     "DMAElementSnmpPortInfo": [{
     "DeviceAddress": "",
     "GetCommunity": "",
     "IPAddress": "[IPAddress]",
     "Network": "",
     "PortId": 3,
     "PortNumber": 514,
     "SetCommunity": "",
     "Type": "IP",
     "TypeConnection": "Serial"
     }
     ],
     "DMAElementSnmpV3PortInfo": [],
     "DMASerialPortInfo": [],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     }, {
     "DMAElementSnmpPortInfo": [{
     "DeviceAddress": "",
     "GetCommunity": "",
     "IPAddress": "[IPAddress]",
     "Network": "",
     "PortId": 4,
     "PortNumber": 514,
     "SetCommunity": "",
     "Type": "udp",
     "TypeConnection": "Serial"
     }
     ],
     "DMAElementSnmpV3PortInfo": [],
     "DMASerialPortInfo": [],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     }
    ]
    ```

- **DMAElementSnmpV3PortInfo**: An array of items that allows you to configure SNMPv3 type ports.

    This array consists of the following fields:

    - **TypeConnection**: Represents the type of the connection. Must be set to *SNMPV3*.

    - **IPAddress**: Contains the polling IP of the device. Typically configured with the keyword *\[IPAddress\]* (see [Using keywords or placeholders](#using-keywords-or-placeholders)).

    - **Network**: Allows you to specify a specific network interface (NIC) on the DMA where the element has to communicate with the device. If you specify an empty string, the DMA will automatically select a NIC based on the local IP address configuration.

    - **PortNumber**: Allows you to specify the port number of the device (e.g. 161, 80, etc.).

    - **PortID**: Indicates the order of the connection in the element. The first connection in the element needs to be assigned value 1, the second connection needs to have value 2, etc. You can easily verify the order of the connections by editing or creating an element using the protocol in question (see [Adding elements](xref:Adding_elements)).

    - **DeviceAddress**: Contains the device address, which can be relevant for specific protocols.

    - **SecurityLevel**: Specifies the SNMPV3 security level. The following values are supported:

        - **authNoPriv**: The SNMP requests are authenticated with an MD5 or SHA hash authentication of the password. The fields *Username*, *AuthPassword* and *AuthType* are mandatory.

        - **authPriv**: The SNMP requests are authenticated and encrypted using the specified authentication and encryption algorithm, respectively. The fields *Username*, *AuthPassword*, *AuthType, EncryptionAlgorithm* and *PrivPassword* are mandatory.

        - **noAuthNoPriv**: SNMP requests are authorized based on a simple string match with the username. The field *Username* is mandatory.

    - **Username**: The username in the SNMP requests.

    - **AuthPassword**: The password required for authentication. A value has to be supplied when the *SecurityLevel* is *authNoPriv* or *authPriv*.

    - **AuthType**: The authentication algorithm. A value has to be supplied when the *SecurityLevel* is *authNoPriv* or *authPriv*. All values supported for SNMPv3 discovery are also supported here. See [SNMP discovery](xref:Discovery_profiles#snmp-discovery).

    - **PrivPassword**: The password required for encryption. A value has to be supplied when the *SecurityLevel* is *authPriv*.

    - **EncryptionAlgorithm**: The encryption algorithm. A value has to be supplied when the *SecurityLevel* is *authPriv*. All values supported for SNMPv3 discovery are also supported here. See [SNMP discovery](xref:Discovery_profiles#snmp-discovery).

    Example:

    ```json
    "Ports": [{
     "DMAElementSnmpPortInfo": [],
     "DMAElementSnmpV3PortInfo": [{
     "AuthPassword": "myAuthPassWord",
     "AuthType": "HMAC384_SHA512",
     "DeviceAddress": "",
     "EncryptionAlgorithm": "AES256",
     "IPAddress": "[IPAddress]",
     "Network": "",
     "PortId": 0,
     "PortNumber": 161,
     "PrivPassword": "myEncrPassWord",
     "SecurityLevel": "AuthPriv",
     "TypeConnection": "SnmpV3",
     "Username": "TestUser"
     }
     ],
     "DMASerialPortInfo": [],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     }
    ]
    ```

- **DMASerialPortInfo**: An array of items that allows you to configure Serial COM type ports.

    To configure this type of port, specify the following information:

    - **TypeConnection**: Represents the type of the connection. Must be set to *Serial*.

    - **Type**: The protocol to be used for the connection. Must be set to *rs232*.

    - **IPAddress**: The polling IP of the device. Typically configured with the keyword *\[IPAddress\]* (see [Using keywords or placeholders](#using-keywords-or-placeholders)).

    - **PortNumber**: The port number of the device (e.g. 161, 80, etc.).

    - **PortID**: Indicates the order of the connection in the element. The first connection in the element needs to be assigned value 1, the second connection needs to have value 2, etc. You can easily verify the order of the connections by editing or creating an element using the protocol in question (see [Adding elements](xref:Adding_elements)).

    Example:

    ```json
    "Ports": [{
     "DMAElementSnmpPortInfo": [],
     "DMAElementSnmpV3PortInfo": [],
     "DMASerialPortInfo": [{
     "DeviceAddress": "",
     "GetCommunity": "",
     "IPAddress": "[IPAddress]",
     "Network": "",
     "PortId": 5,
     "PortNumber": 514,
     "SetCommunity": "",
     "Type": "rs232",
     "TypeConnection": "Serial"
     }
     ],
     "ElementTimeoutTime": 30000,
     "Retries": 3,
     "TimeoutTime": 1500
     },
    ]
    ```

#### Slowpoll

This section allows you to configure the slow poll settings of the element. When an element is in a timeout state, the DMA can force it to go into so-called slow poll mode. While the element is in that special poll mode, the DMA will not send any commands to the element. Instead, it will just send a simple ping command at regular intervals. As soon as the element responds to that ping command, the DMA will start polling the element the normal way again.

The *slowpoll* field contains the following fields:

- **Base**: Supports the following values:

    - **No**: Slow poll mode is not used. The values for *Value* and *PingInterval* are not relevant.

    - **Time**: Slow poll mode will be enabled after a number of milliseconds. The number of milliseconds is configured in *Value*.

    - **Number**: Slow poll mode will be enabled after a number of timeout alarms. The number is configured in *Value*.

- **Value**: If *Base* is set to *Time*, this contains the number of milliseconds. When the *Base* is set to *Number*, it contains the number of timeouts after which the slow poll mode will be enabled.

- **PingInterval**: The ping interval is the interval (in milliseconds) between two ping commands. This must be between 1 and 300 milliseconds.

The example below will activate slow poll mode after 5 timeouts, with an ping internal of 30 seconds:

```json
"SlowPoll": [
 {
 "Base": "Number",
 "PingInterval": 30000,
 "Value": 5
 }
]
```

#### Properties

This section allows you to configure the element properties. The properties item is an array of names and values.

The example below specifies values for the element properties *Source* and *Platform*.

```json
"Properties " : [
 {
 "Name" : "Source",
 "Value" : "Discovered with IDP"
 },{
 "Name" : "Platform",
 "Value" : "Video"
 }
]
```

### DmaID

In this field, specify the DataMiner ID of the DMA where the element must be created.

> [!NOTE]
> If you specify 0, the element will be created based on the configured IP ranges. If no IP ranges are specified, the fallback Agent will be used. See [Provisioning](xref:Provisioning).

### View

This field is an array of integers. The integers identify the view ID of the DataMiner views to which the element will be assigned after creation.

If the fields *View* and *ViewName* are not specified, if they are empty arrays or if they have the value null, the element will be created under the root view.

> [!NOTE]
> An element can be assigned to multiple views, but an element cannot appear directly under a view and a child view of that view. For example, when View B is under View A and the *View* field refers to View A and View B, the element will be created under View B (the child view) only.

### ViewName

This field is an array of strings. The strings identify the view name of the DataMiner views to which the element will be assigned after creation. If a view with this name does not exist, a view with this name will be created under the Root view.

If the fields *View* and *ViewName* are not specified, if they are empty arrays or if they have the value null, the element will be created under the root view.

> [!NOTE]
> An element can be assigned to multiple views, but an element cannot appear directly under a view and a child view of that view. For example, when View B is under View A and the *ViewName* field refers to View A and View B, the element will be created under View B (the child view) only.

### Using keywords or placeholders

The provisioning item in the CI Type supports the following keywords and placeholders:

- *DNSName*: Will be replaced by the DNS name. In case this keyword cannot be resolved, it will not be replaced and the provisioned element will contain the string *\[DNSName\]* in the places corresponding to the location of the keyword in the CI Type definition. In case *\[DNSName\]* is used as the Polling IP and cannot be resolved, the following status message is returned when the element is manually provisioned: *The element cannot be provisioned because \[DNSName\] cannot be resolved in the Polling IP*.

- *IPAddress*: Will be replaced by the IP address of the device.

- Placeholders in the following format, to refer to the discovery response from a device:

    ```txt
    [IDP_DR_<discovery profile name>/<discovery profile action name>]
    ```

    For example:

    ```txt
    [IDP_DR_SNMP_MIB_II/sysDescr]
    ```

    IDP will poll each \[IDP_DR\_\*\] placeholder and try to resolve it when provisioning a discovered element. These placeholders can be used in the element name, element description, properties, etc. In case a placeholder cannot be polled (e.g. an HTTP placeholder on an SNMP-only device), the placeholder will not be resolved during provisioning and the text of the placeholder will be filled in instead of a value.

    > [!NOTE]
    > Prior to IDP version 1.1.17, these keywords are case sensitive.

- Placeholders referring to fields in the Provisioning JSON code. For example:

    | Placeholder                                    | Description                                                                                                                              |
    |--------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
    | \[$.Provisioning.Configuration.ProtocolName\]    | Will be replaced by the name of the protocol, as specified in the field *ProtocolName* of the CI Type.    |
    | \[$.Provisioning.Configuration.ProtocolVersion\] | Will be replaced by the name of the protocol, as specified in the field *ProtocolVersion* of the CI Type. |

    The following restrictions apply:

    - Cyclic references are not allowed (e.g. using a protocol placeholder in a description field and referring to this description field with a description placeholder in the corresponding protocol field).

    - These keywords can only be placed in string fields in the JSON code.

When provisioning is done via **Process Automation**, the token can contain metadata that can replace the CI Type fields. For this to work, the name of the metadata must consist of the *IDP\_* prefix followed by the relevant JSON object from the CI Type. For example, to overwrite the element description from the CI Type, use the metadata name *IDP\_$.Provisioning.Configuration.Description* and place the new element description in the metadata value. If the metadata value contains special characters, e.g. double quotation marks, place a backslash in front of these to make sure they are not misinterpreted (e.g. \[*\\"Test\\", \\"Test 123\\"\]*).

Other metadata examples:

- Providing a custom keyword (only “IPAddress” is currently supported):

    - Metadata name: *IDP_IPAddress*

    - Metadata value: “10.10.10.10”

- Providing a keyword to override an integer:

    - Metadata name: *IDP\_$.Provisioning.Configuration.TimeoutTime*

    - Metadata value: “2500”

- Providing a keyword to override a string:

    - Metadata name: *IDP\_$.Provisioning.Configuration.Description*

    - Metadata value: "This is a test of keywords."

- Providing a keyword to override the value of a property:

    - Metadata name: *IDP\_$.Provisioning.Configuration.Properties\[?(@.Name == 'MyProperty2')\].Value*

    - Metadata value: "MyNewPropertyValue"

- Providing a keyword to override the first item in a string array (not adding, only updating):

    - Metadata name: *IDP\_$.Provisioning.ViewName\[0\]*

    - Metadata value: "newViewName"

- Providing a keyword to override a string array:

    - Metadata name: *IDP\_$.Provisioning.ViewName*

    - Metadata value: "\[\\"Test\\", \\"Test 123\\"\]"

- Providing a keyword to override the GetCommunity string of the first connection:

    - Metadata name: *IDP\_$.Provisioning.Configuration.Ports\[0\].DMAElementSnmpPortInfo\[0\].GetCommunity*

    - Metadata value: "customGetCommunity"

## SoftwareUpgrades

This is an array of software upgrade information. This information is used when a software upgrade needs to be performed on an element.

The following mandatory fields need to be specified for a software upgrade:

- **ScriptName**: The script that needs to be run to perform a software upgrade on an element.

- **ImageFileLocation**: The location of the folder where the software is available.

    > [!NOTE]
    > If the path contains a backslash (“\\”) character, an additional backslash character must be specified. For example: “*C:\\\\Images\\\\MyLocation*”.

- **Version**: The version of the software that will be deployed on the element.

## Autocreate

This field indicates whether elements for this CI Type can be automatically created or not. This field supports boolean values.

- If this field is set to *True*, the elements will be created automatically when using auto discovery.

- If this field is set to *False*, the element will not be created automatically when using auto discovery.

> [!NOTE]
> If you set this field to *True* but *Create Completeness* is not 100%, the field will automatically be set to *False*.

## SoftwareUpgrade

This field indicates whether a software upgrade is available for the elements. The fields supports boolean values:

- If this field is set to *True*, the software upgrade is supported.

- If this field is set to *False*, the software upgrade is not supported.

> [!NOTE]
> If you set this field to *True* but neither *Software Update Completeness* nor *Software Compliance Completeness* is 100%, the field will automatically be set to *False*.

## SoftwareVersionPID

This fields indicates the parameter ID of the selected protocol where it is possible to see information about the software version the element is running. This is a numeric field.

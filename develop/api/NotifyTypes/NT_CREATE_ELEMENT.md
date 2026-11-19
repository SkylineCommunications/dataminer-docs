---
uid: NT_CREATE_ELEMENT
---

# NT_CREATE_ELEMENT (160)

Creates an element on the specified DMA.

```csharp
string elementName = "CISCO Meraki Main";
int dmaId = 400;
object[] elementDetails = new object[] { elementName, dmaId };
string elementSettings = "…";

int result = (int)protocol.NotifyDataMinerQueued(160 /* NT_CREATE_ELEMENT */, elementDetails, elementSettings);
```

## Parameters

- elementDetails (object[]):
  - elementDetails[0]: (string) Name of the element to be created.
  - elementDetails[1]: (int) ID of the DataMiner Agent on which the element has to be created.
- elementSettings (string): String defining the element configuration options.

## Return Value

- (int): 0 indicates the operation succeeded.

## Remarks

- Instead of providing elementDetails (object[), it is also possible to only specify the element name:

  ```csharp
  string elementName = "CISCO Meraki Main";
  string elementSettings = "…";

  int result = (int)protocol.NotifyDataMinerQueued(160 /* NT_CREATE_ELEMENT */, elementName, elementSettings);
  ```

- Before DVE functionality existed, elements were created from within a QAction using different protocols. To create an element, you can pass several element options to the NotifyDataMinerQueued type 160 method call as a pipe-separated (`|`) string. The following table contains an overview of the different settings that can be provided along with the position in the string.

    |Position|Description|
    |--- |--- |
    |0|Name|
    |1|State (supported values: "Active", "Inactive", "Stop")|
    |2|Data|
    |3|Unique|
    |4|Protocol name|
    |5|Protocol version|
    |6|Template name|
    |7|Port type*: None, IP, UDP or Serial|
    |8|Port number*|
    |9|Port baud rate*|
    |10|Port parity* (In case of an SNMPv3 connection, this field denotes the authentication algorithm, e.g., "HMAC-SHA".)|
    |11|Port data bits* (In case of an SNMPv3 connection, this field denotes the user name.)|
    |12|Port stop bits* (In case of an SNMPv3 connection, this field denotes whether authentication and privacy is enabled, e.g., "authPriv".)|
    |13|Port flow control* (In case of an SNMPv3 connection, this field denotes the privacy algorithm.)|
    |14|Port bus*|
    |15|Retries*|
    |16|Slow poll base*|
    |17|Timeout*|
    |18|Slow poll value*|
    |19|Polling IP*|
    |20|Polling IP port*|
    |21|Ping interval*|
    |22|SNMP Agent IP Address|
    |23|SNMP Agent subnet mask|
    |24|Telnet|
    |25|SNMP Agent|
    |26|Description|
    |27|Element timeout* **Note**: Set this to -1 in case you want to exclude the timeout state of this connection from the overall element state.|
    |28|Get community* (In case of an SNMPv3 connection, this field denotes the authentication password.)|
    |29|Set community* (In case of an SNMPv3 connection, this field denotes the privacy password.)|
    |30|Type|
    |31|Hidden|
    |32|Trend template|
    |33|Service|
    |34|Local IP port*|
    |35|read only|
    |36|Replication: active|
    |37|Replication: options|
    |38|Replication: remote element|
    |39|Replication: DataMiner IP|
    |40|Replication: user name|
    |41|Replication: password|
    |42|Replication: domain|
    |43|Keep online: true/false (Failover)|
    |44|Force agent: empty/IP address (Failover)|
    |45|Replication: DMP manager populated|
    |46|DMA SNMP Agent get community string|
    |47|DMA SNMP Agent set community string|
    |48|DVE creation flag|
    |49|Replication: max messages to buffer|
    |50|Replication: max minutes to buffer|
    |51|Protocol type*, **|
    |52|Library credential*|

  \*:  Indicates a connection setting field. When an element is created from a protocol that has multiple connections defined, these fields contain multiple values separated by tabs ("\t").

  \*\*: Protocol types:
  - 1: SNMP
  - 2: Serial
  - 3: Smart-serial
  - 4: Virtual
  - 5: GPIB
  - 6: ~~OPC~~ ([End of Life](xref:Software_support_life_cycles#end-of-life))
  - 7: SLA
  - 8: SNMPv2
  - 9: SNMPv3
  - 10: HTTP
  - 11: Service
  - 12: Serial single
  - 13: Smart-serial single
  - 16: WebSocket

  Example: creating an element with two HTTP connections will require a protocol type field value of "10\t10".

  The following example creates an element running an SNMPv3 protocol:

    ```csharp
    private static void CreateElement(SLProtocol protocol, string elementName, string protocolName, string protocolVersion, string pollingIP, string pollingPort, string busAddress)
    {
       string[] settings = new string[]
       {
          elementName,      // 0: Element name
          "Active",         // 1: State
          String.Empty,     // 2: data
          String.Empty,     // 3: unique
          protocolName,     // 4: protocol name
          protocolVersion,  // 5: protocol version
          String.Empty,     // 6: template name
          "IP",             // 7: port type
          "0",              // 8: port number
          String.Empty,     // 9: port Baud rate
          "HMAC-SHA",       // 10: parity
          "User0",          // 11: data bits
          "authPriv",       // 12: stop bits
          "DES",            // 13: flow control
          busAddress,       // 14: port bus
          "3",              // 15: retries
          String.Empty,     // 16: slowPollBase
          "1500",           // 17: timeout
          "30000",          // 18: Slow poll value.
          pollingIP,        // 19: Polling IP
          pollingPort,      // 20: Polling IP port
          "30000",          // 21: Ping interval.
          "127.0.0.2",      // 22: SNMP Agent IP address
          String.Empty,     // 23: SNMP Agent subnet mask
          "0",              // 24: Telnet
          "0",              // 25: SNMP Agent
          String.Empty,     // 26: Description
          "-1",             // 27: Element timeout
          "AuthAuth0",      // 28: Get community
          "PrivPriv0",      // 29: Set community
          String.Empty,     // 30: Type
          "False",          // 31: Hidden
          String.Empty,     // 32: Trend template
          "False",          // 33: Service
          String.Empty,     // 34: Local IP port
          String.Empty,     // 35: read only
          String.Empty,     // 36: Replication: active
          String.Empty,     // 37: Replication: options
          String.Empty,     // 38: Replication: remote element
          String.Empty,     // 39: Replication: DataMiner IP
          String.Empty,     // 40: Replication: user name
          String.Empty,     // 41: Replication: password
          String.Empty,     // 42: Replication: domain
          String.Empty,     // 43: Keep online: true/false (failover)
          String.Empty,     // 44: Force agent: empty/IP address (failover)
          String.Empty,     // 45: Replication: DMP manager populated
          String.Empty,     // 46: DMA SNMP Agent get community string
          String.Empty,     // 47: DMA SNMP Agent set community string
          String.Empty,     // 48: DVE creation flag
          String.Empty,     // 49: Replication: max messages to buffer
          String.Empty,     // 50: Replication: max minutes to buffer
          "9",              // 51: Protocol type
          String.Empty,     // 52: Library credential
       };

       string elementConfigurationSettings = String.Join("|", settings);

       protocol.NotifyDataMinerQueued(160 /* NT_CREATE_ELEMENT */, elementName, elementConfigurationSettings);
    }
    ```

- Before creating an element, make sure the element name is not already used and that there is not already an element using the same polling IP/bus.

  - Check if the element name is already used:

    ```csharp
    object elementID = null;
    DMSClass dms = new DMSClass();

    dms.Notify(72 /* DMS_GET_ELEMENT_ID */, 0, elementName, null, out elementID);

    protocol.Log($"QA{protocol.QActionID}|ID of element with name {elementName}: {elementID}", LogType.Error, LogLevel.NoLogging);
    ```

  - Check if there is already an element that is using the same polling IP/bus:

    ```csharp
    object elementID = null;
    string[] connectionSettings = new string[] { ipAddress, busAddress };

    dms.Notify(76, 0, connectionSettings, null, out elementID);
    protocol.Log($"QA{protocol.QActionID}|Element that has the same IP and bus: {elementID}", LogType.Error, LogLevel.NoLogging);
    ```

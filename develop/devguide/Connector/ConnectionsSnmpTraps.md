---
uid: ConnectionsSnmpTraps
---

# Traps

SNMP traps enable a device to notify the NMS of significant events via unsolicited messages. The rationale behind traps is that if an NMS is responsible for a large number of devices where each device exposes a large number of objects, it is impractical for the NMS to poll or request information from every object on every device.

Therefore, a device can notify the NMS of an important event without solicitation. It does this by sending a message known as a trap.

A protocol implementing trap functionality can choose what actions should be taken when a trap is received. For instance, the protocol can poll the device sending the trap, or poll other associated devices to get a better understanding of the event.

> [!NOTE]
>
> - A difference between SNMP traps and other SNMP message types is that the agent sends traps to the NMS using port 162 whereas other SNMP message types use port 161.
> - The Trap-PDU is defined in RFC1157. The SNMPv2-Trap-PDU is defined in RFC3416.

## Capturing traps in a protocol

In order to capture traps in a protocol, define a parameter that will capture the traps.

```xml
<Param id="21">
   <Name>TrapReceiver</Name>
   <Description>TrapReceiver</Description>
   <Type>dummy</Type>
   <Display>
      <RTDisplay>false</RTDisplay>
   </Display>
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID setBindings="1,250" type="wildcard" ipid="100">1.2.3.4.*</TrapOID>
   </SNMP>
</Param>
```

The OID of the traps that should be captured is specified in the TrapOID tag. This can either be a specific OID (in which case type should be set to "complete"), or an OID containing a wildcard (in which case type should be set to "wildcard").

By default, only traps received from the polling IP address of the main connection of an element will be captured. Using the ipid attribute, you can refer to a parameter containing the IP addresses from which traps should be captured.

The checkBindings attribute allows you to prevent traps from being processed further unless the specified binding checks succeed. The following example specifies that binding 2 of the trap must contain *display* and binding 3 must match the value of parameter 102 (which can also contain wildcards). Only if both conditions are met, DataMiner will process the trap.

```xml
checkBindings="2=*display*|3=id:102"
```

The setBindings attribute allows you to set a specified parameter with the value of a specified binding. The following example states that parameter with ID 250 should be set with the value of the first binding.

```xml
setBindings="1,250"
```

> [!NOTE]
>
> - For more examples, see setBindings example.
> - When you set the log level to "Log Everything", information about incoming traps is logged in the SLSNMPManager log file.
> - An example protocol "SLC SDF SNMP - Traps" is available in the Protocol Development Guide Companion Files.

> [!IMPORTANT]
> A Trigger 'on change' on a trap receiver parameter will never trigger. Because of the way the trap data is received, stored and forwarded, the actual value of the trap receiver parameter will not change. In case you want to trigger an operation upon receiving a trap (e.g. poll a table), you need to either:
>
> - map one of the bindings to a parameter and then trigger on a change of that parameter, or
> - trigger a QAction using 'allbindinginfo' and trigger the operation (e.g. poll a table) from that QAction (e.g. using CheckTrigger or SetParameter).

### See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.SNMP.TrapOID@checkBindings](xref:Protocol.Params.Param.SNMP.TrapOID-checkBindings)
- [Protocol.Params.Param.SNMP.TrapOID@setBindings](xref:Protocol.Params.Param.SNMP.TrapOID-setBindings)

## Generating alarms upon receiving traps

It is possible to specify that alarms should be generated when a trap is received. This is done using the mapAlarm attribute.

> [!NOTE]
>
> - For more information about alarm mapping, see [mapAlarm](xref:Protocol.Params.Param.SNMP.TrapOID-mapAlarm).
> - The trap parameter does not need to be activated in the alarm template for the alarms to be generated.

Consider the following example:

```xml
<TrapOID mapAlarm="TRUE|Severity:1:Critical,1;Normal,2|Value:Trap Received '[1]' [2]' '[3]'|Link:2,3" type="wildcard">1.3.6.1.4.1.31961.0.1.*</TrapOID>
```

In this example, binding 1 determines the severity of the alarm:

- If binding 1 has value "1", the generated alarm will have severity "Critical".
- If binding 1 has value "2", the generated alarm will have severity "Normal".

The contents of binding 1, 2 and 3 will be displayed in the value.

Linking is done on binding 2 and 3. Traps of which these bindings have identical values are linked to each other. For example, if you have two trap receivers with the same linking conditions, those traps can be linked to each other.

In case this behavior is not desired, the use of a group ID (negative number) before the linking values is required. In the following example, parameter 1 can be linked to parameter 2, but not to parameter 3 as this parameter contains a negative group number.

```xml
<Param id="1">
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID mapAlarm="TRUE|Severity:1:Critical,1;Normal,2|Value:Trap Received '[1]' [2]' '[3]'|Link:2,3" type="wildcard">1.3.6.1.4.1.31961.0.1.*</TrapOID>
   </SNMP>
  ...
</Param>
<Param id="2">
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID mapAlarm="TRUE|Severity:1:Critical,1;Normal,2|Value:Trap Received2 '[1]' [2]' '[3]'|Link:2,3" type="wildcard">1.3.6.1.4.1.31961.0.2.*</TrapOID>
   </SNMP>
  ...
</Param>
<Param id="3">
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID mapAlarm="TRUE|Severity:1:Critical,1;Normal,2|Value:Trap Received2 '[1]' [2]' '[3]'|Link:-1,2,3" type="wildcard">1.3.6.1.4.1.31961.0.3.*</TrapOID>
   </SNMP>
  ...
</Param>
```

In case the mapAlarm attribute is too limited, it is possible to use the TrapMappings tag to make more advanced alarm mappings.

When a trap is received, all TrapMappings are checked top down until a bindingMatch is found. The parameter does not need to be activated in the alarm template.

```xml
<Param id="10" trending="false">
   <Name>TrapMapping Trap Receiver</Name>
   <Description>TrapMapping Trap Receiver</Description>
   <Type>dummy</Type>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Alarm>
      <Monitored>true</Monitored>
   </Alarm>
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID  mapAlarm="TRUE|Link:3,4,5" type="wildcard" checkBindings="1=id:2">1.3.6.1.4.1.31961.0.10.*</TrapOID>
      <TrapMappings>
         <TrapMapping bindingMatch="1:5" severity="Normal"></TrapMapping>
         <TrapMapping bindingMatch="3:TS Sync Loss" severity="Critical" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="3:Sync Byte Error" severity="Major" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="3:CC Error" severity="Warning" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="*" severity="information" value="Unknown trap:[4]-[3]-[5]"></TrapMapping>
      </TrapMappings>
   </SNMP>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

The user can choose the traps for which alarms have to be generated. Also, the severity of those alarms can be specified.

In the following example, the severity is user-definable. The severity attribute links to a discrete value. This discrete value will be visible in the alarm template allowing the user to select the severity.

```xml
<Param id="20" trending="false">
   <Name>TrapMapping Custom Trap Receiver</Name>
   <Description>TrapMapping Custom Trap Receiver</Description>
   <Type>dummy</Type>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Alarm>
      <Monitored>true</Monitored>
   </Alarm>
   <SNMP>
      <Enabled>true</Enabled>
      <TrapOID mapAlarm="TRUE|Link:3,4,5" type="wildcard">1.3.6.1.4.1.31961.0.20.*</TrapOID>
      <TrapMappings>
         <TrapMapping bindingMatch="1:5" severity="id:0"></TrapMapping>
         <TrapMapping bindingMatch="3:TS Sync Loss" severity="id:1" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="3:Sync Byte Error" severity="id:2" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="3:CC Error" severity="id:3" value="[4]:[3]:[5]"></TrapMapping>
         <TrapMapping bindingMatch="*" severity="NoTrap" value="Unknown trap:[4]-[3]-[5]"></TrapMapping>
      </TrapMappings>
   </SNMP>
   <Measurement>
      <Type>discreet</Type>
      <Discreets>
         <Discreet>
            <Display>Ok</Display>
            <Value>0</Value>
         </Discreet>
         <Discreet>
            <Display>TS Sync Loss</Display>
            <Value>1</Value>
         </Discreet>
         <Discreet>
            <Display>Sync Byte Error</Display>
            <Value>2</Value>
         </Discreet>
         <Discreet>
            <Display>CC Error</Display>
            <Value>3</Value>
         </Discreet>
      </Discreets>
   </Measurement>
</Param>
```

## Processing traps in a QAction

It is possible that a QAction is required to process an incoming trap. When the setBindings attribute is set to "allBindingInfo", an object holding the trap information will be available in the QAction.

```xml
<Param id="1">
  <Name>Trap Receiver</Name>
  <Description>Trap Received</Description>
  <Type>read</Type>
  <Interprete>
     <Type>string</Type>
  </Interprete>
  <SNMP>
     <Enabled>true</Enabled>
     <TrapOID setBindings="allBindingInfo" type="wildcard" ipid="100">...</TrapOID>
  </SNMP>
</Param>
```

The QAction triggers on the trap receiver parameter and the trap information is available in the trapInfo object.

```csharp
public class QAction
{
   public static void Run(SLProtocol protocol, object trapInfo)
  {
      // ...
  }
```

trapInfo (object[]):

- trapInfo[0]: object array containing general trap information.
  - object[] generalTrapInfo = (object[]) trapInfo[0], where
    - generalTrapInfo[0] (string): Trap OID.
    - generalTrapInfo[1] (string): Trap source (IP address).
    - generalTrapInfo[2] (int): Tick count indicating when the trap was received by SLSNMPManager. This is the number of milliseconds that have elapsed since the system was started. Note that this is a 32-bit number, so it wraps around every 49.7 days
- trapInfo[1...n]: the trap bindings
  - object[] binding = (object[]) trapInfo[i] (i=1...n), where
    - binding[0] (string): Binding OID
    - binding[1] (string): Binding value

Note that the [Skyline.DataMiner.Utils.SNMP.Traps.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.SNMP.Traps.Protocol) NuGet package can be used to parse the trap: The TrapInfo class (see TrapInfo class) allows the creation of a TrapInfo object from the raw trap info object.

```csharp
TrapInfo trap = TrapInfo.FromTrapData(trapInfo);

string trapOid = trap.Oid; // The trap OID.
DateTime receivedTime = trap.ReceivedTime; // The time when the trap was received in the SLSNMPManager process.
IPAddress source = trap.Source; // The source IP address.
var bindings = trap.VariableBindings; // Trap variable bindings.

TrapInfoVariableBinding binding = bindings[0]; // Retrieves the first binding.
TrapInfoVariableBinding anotherBinding = bindings["1.1.1.1"]; // Retrieves the binding that corresponds with the specified binding OID.

string bindingOid = binding.Oid;
string bindingValue = binding.Value;
```

## Creating and sending traps from a QAction

A DataMiner protocol can send SNMP traps independently from any alarms that are received. For this, the Notify method of the DMS class can be used. (For more information on this method, see DMS_SNMP_NOTIFICATION (73).) This will send a message to the SLDMS process, which in turn will instruct the SLSNMPAgent process to send the trap.

Note that if you use custom traps in a protocol, you need to update the MIB for that protocol. As it is nearly impossible to auto-generate this custom MIB data, you can add a Mib tag to the protocol. The contents of that tag will then be added to the auto-generated MIB.

```xml
<Mib>
  <![CDATA[
           traps
           OBJECT IDENTIFIER ::= {
           1.3.6.1.4.1.8813.2.vendorOID.deviveOID.100 }
           permLnkCfgPermanentLinkChange NOTIFICATION-TYPE
           OBJECTS
           {
           permanentLinkChange
           }
           STATUS current
           DESCRIPTION
           "Trap generated when modifying, adding an entry in the
           PAMA link table"
           ::= { traps 1 }
           permanentLinkChange OBJECT-TYPE
           SYNTAX  INTEGER
           ACCESS  read-only
           STATUS  mandatory
           DESCRIPTION
           "ID of the PAMA link."
           ::= { permLnkCfgPermanentLinkChange 1 }
   ]]>
</Mib>
```

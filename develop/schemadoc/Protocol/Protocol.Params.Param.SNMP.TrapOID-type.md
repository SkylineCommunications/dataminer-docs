---
uid: Protocol.Params.Param.SNMP.TrapOID-type
---

# type attribute

Specifies how the trap OID is constructed.

## Content Type

[EnumTrapOIDType](xref:Protocol-EnumTrapOIDType)

## Parent

[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)

## Remarks

The following values are supported:

|Type|Description
|--- |--- |
|auto|The resulting OID is the combination of VendorOID + DeviceOID + Param ID.|
|complete|The complete trap OID is specified in TrapOID.|
|composed|The resulting OID is the combination of VendorOID + DeviceOID + the value specified in TrapOID.|
|wildcard|When set to wildcard, you can use an asterisk (*) in the OID in order to capture all traps that match this OID.|

### auto

The resulting OID is the combination of VendorOID + DeviceOID + Param ID.

Examples:

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
    <VendorOID>1.3.6.1.4.1.8813.2.1</VendorOID>
    <DeviceOID>1000</DeviceOID>
    <Params>
    <Param id="5000">
    	<Name>Trap Receiver</Name>
    	<Description>Trap Received</Description>
    	<Type>dummy</Type>
    	<Display>
    		<RTDisplay>false</RTDisplay>
    	</Display>
    	<SNMP>
    		<Enabled>true</Enabled>
    		<TrapOID setBindings="allBindingInfo" type="composed" ipid="4998">20</TrapOID>
    	</SNMP>
    </Param>
    …
</Protocol>
```

In the example above, traps with OID "1.3.6.1.4.1.8813.2.1.1000.5000" will be captured.

### complete

The complete trap OID is specified.

Examples:

```xml
<OID type="complete">1.3.6.1.4.1.1773.1.1.1.1.0</OID>
```

### composed

The resulting OID is the combination of VendorOID + DeviceOID + the value specified.

Examples:

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
    <VendorOID>1.3.6.1.4.1.8813.2.1</VendorOID>
    <DeviceOID>1000</DeviceOID>
    <Params>
    	<Param id="5000">
    		<Name>Trap Receiver</Name>
    		<Description>Trap Received</Description>
    		<Type>dummy</Type>
    		<Display>
    			<RTDisplay>false</RTDisplay>
    		</Display>
    		<SNMP>
    			<Enabled>true</Enabled>
    			<TrapOID setBindings="allBindingInfo" type="composed" ipid="4998">20</TrapOID>
    		</SNMP>
    	</Param>
    	...
    </Params>
    ...
</Protocol>
```

In the example above, traps with OID “1.3.6.1.4.1.8813.2.1.1000.20” are captured.

### wildcard

When set to wildcard, you can use an wildcard (*) in the OID in order to capture all traps that match this OID.

Examples:

```xml
<TrapOID checkBindings="2=*display*|3=id:102" setBindings="1,1012;2,1045" ipid="205" mapAlarm="TRUE|Severity:4:Normal,Normal;Warning,Warning*;Minor,Minor,Minor low,minor high;Major,Major*;Critical,Critica*;Timeout,Timeout;Information,Information|Value:A trap is received from '[1]': Parameter '[2]' has value '[3]'|Link:1,2" type="wildcard">1.3.6.1.4.1.8813.*</TrapOID>
```

---
uid: Protocol.Params.Param.SNMP.TrapOID-setBindings
---

# setBindings attribute

Specifies that the value of a certain binding should be set as the value of another parameter.

## Content Type

string

## Parent

[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)

## Remarks

Use this attribute to take the value of a certain binding and immediately set (copy) it to another parameter.

Set pairs have to be separated by semicolons. Every set pair consists of a binding position (1-based) containing the value to be set and the ID of the parameter to set, separated by a comma. If you want to set a dynamic table parameter, you can add more items to the set pair (which will then be concatenated with a "." to build an index).

Syntax:

```xml
<Param id="1000">
    <Name>Trap Receiver</Name>
    ...
    <SNMP>
        <Enabled>true</Enabled>
        <TrapOID setBindings="A,B,C,D,..." mapAlarm="TRUE|Severity:1:Information,*" type="wildcard">*</TrapOID>
    </SNMP>
    ...
</Param>
```

It is also possible to specify full OIDs instead of positions:<!-- RN 13794 -->

```xml
<TrapOID checkBindings="1.3.6.1.2=*value*|1.3.6.1.3=id:101" setBindings="1.3.6.1.2,102;1.3.6.1.3,103;1.3.6.1.4,104;1.3.6.1.5,105;1.3.6.1.6,106" ipid="100" mapAlarm="TRUE|Severity:1.3.6.1.4:Normal,Normal;Warning,Warning*;Minor,Minor,Minor low,minor high;Major,Major*;Critical,Critica*;Timeout,Timeout;Information,Information|Value:A trap is received: '[1.3.6.1.2]' and '[1.3.6.1.3]' and '[1.3.6.1.4]'|Link:1.3.6.1.5,1.3.6.1.6" type="complete">*</TrapOID>
```

### setBindings example

Incoming trap:

- binding 1 = newValue
- binding 2 = Hello
- binding 3 = World

If you specify setBindings="1,250", parameter 250 will be filled with "newValue".

If you specify setBindings="1,250,2", the cell in column (parameter) 250 and index "Hello" will be filled with "newValue".

If you specify setBindings="1,250,2,3", the cell in column (parameter) 250 and index "Hello.World" will be filled with "newValue".

In order to convert a binding to a hexadecimal number, add HEX: setBinding="1,250,HEX".

If binding 2 contains "RDV", then parameter 12502 will display "524456":<!-- RN 3250 -->

```xml
<SNMP>
    <Enabled>true</Enabled>
    <TrapOID setBindings="2,12502,HEX" ipid="*">1.3.6.1.4.1.4981.2.4.0.2</TrapOID>
</SNMP>
```

In order to copy the OID of a binding to a specified parameter, add OID: setBinding="1,12502,OID".

If binding 2 contains an OID "1.2.3.4.1", it will be copied to parameter 12502:<!-- RN 1727 -->

```xml
<SNMP>
    <Enabled>true</Enabled>
    <TrapOID setBindings="2,12502,OID" ipid="*">1.3.6.1.4.1.4981.2.4.0.2</TrapOID>
</SNMP>
```

### allBindingInfo

If you set the setBindings attribute to "allBindingInfo", all bindings of the trap will be stored as an array in the parameter specified in the Param tag.

- The first array entry will contain the general trap info (receive timestamp, trap OID, trap source).
- All other array entries will contain the data found in the different bindings (binding OID and binding value).

In the QAction linked to the parameter, you can then process the bindings and make the information appear on the element’s Data Display.

In the trap receiver, you will have to specify the following:

```xml
<Param id="1">
    ...
    <SNMP>
        ...
        <TrapOID setBindings="allBindingInfo" type="wildcard" ipid="100">*</TrapOID>
    </SNMP>
    ...
</Param>
```

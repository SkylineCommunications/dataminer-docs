---
uid: ConnectionsSnmpAlteringAVariable
---

# Altering a variable

Devices running an SNMP agent typically not only allow the inspecting of variables but also the altering of variables (i.e., some OIDs in the MIB will be of type "read-write"). In order to allow a user to set variables via the DataMiner element running the protocol, a parameter of type "write" can be defined in the protocol.

For example, the following parameter allows you to set the sysContact (OID "1.3.6.1.2.1.1.4.0") variable.

There are two ways to implement an SNMP set request for a standalone parameter.

1. If you use the `options="snmpSet"` attribute on the write parameter, the set will be executed.

   ```xml
   <Param id="13" options="snmpSet">
       <Name>sysContact</Name>
       <Description>System Contact</Description>
       <Type>write</Type>
       <Interprete>
           <RawType>other</RawType>
           <LengthType>next param</LengthType>
           <Type>string</Type>
       </Interprete>
       <SNMP>
           <Enabled>true</Enabled>
           <OID type="complete">1.3.6.1.2.1.1.4.0</OID>
           <Type>octetstring</Type>
       </SNMP>
       <Display>
           <RTDisplay>true</RTDisplay>
           <Positions>
               <Position>
                   <Page>System Info</Page>
                   <Row>2</Row>
                   <Column>0</Column>
               </Position>
           </Positions>
       </Display>
       <Measurement>
           <Type>string</Type>
       </Measurement>
   </Param>
   ```

1. Using a trigger and a "set parameter" action, you can perform a set via a write parameter.

   ```xml
   <Param id="13">
       <Name>sysContact</Name>
       <Description>System Contact</Description>
       <Type>write</Type>
       <Interprete>
           <RawType>other</RawType>
           <LengthType>next param</LengthType>
           <Type>string</Type>
       </Interprete>
       <SNMP>
           <Enabled>true</Enabled>
           <OID type="complete">1.3.6.1.2.1.1.4.0</OID>
           <Type>octetstring</Type>
       </SNMP>
       <Display>
           <RTDisplay>true</RTDisplay>
           <Positions>
               <Position>
                   <Page>System Info</Page>
                   <Row>2</Row>
                   <Column>0</Column>
               </Position>
           </Positions>
       </Display>
       <Measurement>
           <Type>string</Type>
       </Measurement>
   </Param>
   <Trigger id="13">
       <Name>onWriteSysContact</Name>
       <On id="13">parameter</On>
       <Time>change</Time>
       <Type>action</Type>
       <Content>
           <Id>13</Id>
       </Content>
   </Trigger>
   <Action id="13">
       <Name>setSysContact</Name>
       <On id="13">parameter</On>
       <Type>set</Type>
   </Action>
   ```

The method using the `snmpSet` option is generally preferred, as it does not require an action and trigger to be defined.

It is important to note that when an SNMP parameter (i.e., a parameter containing an SNMP tag) of type "write" is set, the corresponding read parameter is immediately set to this new value (even if the actual value set still needs to be sent to the device). As it is possible that an SNMP set fails, it is important to always perform an additional SNMP get operation to retrieve the value. This way, when a set failed, the value of the read parameter will eventually be set back to the correct value upon completion of the SNMP get request.

The reason why SNMP parameters of type "write" immediately set the corresponding read parameter is because the probability that an SNMP set will fail is low (in normal operation) and therefore in most cases we can assume the set will succeed. Therefore, the read parameter can already be updated so the user already sees the new value. Because a get is always performed afterwards, the correct value will eventually always be displayed, even if it failed (meaning that when the set failed, the read parameter will show the wrong value until the get request has been completely processed).

To perform this get request, a trigger on the write parameter is needed. This trigger needs to add a group to the group execution queue that will poll the read parameter that corresponds to the write parameter that has been set. The get request needs to be executed as quickly as possible. Therefore, an action of type "execute next" should be used so that the group gets added to the queue just after the group that is currently being executed.

```XML
<Trigger id="1">
    <Name>onWriteSysContact</Name>
    <On id="13">parameter</On>
    <Time>change</Time>
    <Type>action</Type>
    <Content>
        <Id>1</Id>
    </Content>
</Trigger>
<Action id="1">
    <Name>refresh SysInfo</Name>
    <On id="1">group</On>
    <Type>execute next</Type>
</Action>
<Group id="1">
    <Name>sysInfo</Name>
    <Description>System Info</Description>
    <Content multipleGet="true">
        <Param>1</Param>
        <Param>2</Param>
        <Param>3</Param><!-- System Contact (read parameter) -->
        <Param>4</Param>
        <Param>5</Param>
    </Content>
</Group>
```

You can use the options `snmpSetWithWait` and `snmpSetAndGetWithWait` as attributes on parameters (see [options attribute](xref:Protocol.Params.Param-options)):

- The `snmpSetWithWait` option will perform a set and wait until the set has succeeded (i.e., when the SNMP manager has received a "noError" from the device). In this case, a group to perform the set is added to the group execution queue.
- The `snmpSetAndGetWithWait` option will perform a set, wait until the set has succeeded and then perform a get of the read parameter and wait until the get has succeeded. Note that there is no verification of the get/set value.

The same options can be used for write parameters on a column: use a wildcard on the set parameter and the "instance" option on the table.

```XML
<Param id="20" options="snmpSetAndGetwithwait">
    <Name>IP Address</Name>
    <Description>IP Address</Description>
    <Type>write</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1.3.*</OID>
    </SNMP>
    ...
```

Table parameter:

```XML
<Param id="15" trending="false">
    <Name>Accessible IP List</Name>
    <Type id="16;17;18;19">array</Type>
    <ArrayOptions index="0"/>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options="instance;multipleGetNext"></OID>
    </SNMP>
```

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param@options](xref:Protocol.Params.Param-options)

> [!NOTE]
> You can also perform a set and get on a write parameter using the [snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet) attribute.

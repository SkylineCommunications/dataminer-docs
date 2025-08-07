---
uid: ConnectionsSnmpAlteringATableCell
---

# Altering a table cell

Different approaches are possible to implement this functionality in a protocol.

> [!NOTE]
>
> - This section assumes some knowledge about Quick Actions. For more information, see [QActions](xref:LogicQActions).
> - The [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/) include example protocols illustrating the different methods to alter a table cell discussed next.

## snmpSetAndGet

To implement an SNMP table set using [snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet), you must use the "instance" option. This way, DataMiner will be able to know which row and column have been set. The table must also be displayed, as a user interaction is needed to perform the write (performing a set via a QAction will not work as the corresponding primary key will not be found).

Define a write parameter for the column and use the `snmpSetAndGet` attribute by setting it to `true`.

```xml
<Param id="157" snmpSetAndGet="true">
   <Name>ifAdminStatus</Name>
   <Description>Admin Status (Interface)</Description>
   <Type>write</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
  <SNMP>
     <Enabled>true</Enabled>
     <OID type="complete">1.3.6.1.2.1.2.2.1.7</OID>
      <Type>integer</Type>
  </SNMP>
  <Display>
     <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
     <Type>discreet</Type>
     <Discreets>
        <Discreet>
           <Display>Up</Display>
           <Value>1</Value>
        </Discreet>
        <Discreet>
           <Display>Down</Display>
           <Value>2</Value>
        </Discreet>
        <Discreet>
           <Display>Testing</Display>
           <Value>3</Value>
        </Discreet>
     </Discreets>
  </Measurement>
</Param>
```

## Using a parameter holding the instance

This approach requires that you implement logic in the protocol to know which row has been selected. Perform the following steps:

1. Create a write parameter for the column that should support altering the value.

    ```xml
    <Param id="117">
       <Name>ifAdminStatus</Name>
       <Description>Admin Status (Interface)</Description>
       <Type>write</Type>
       <Interprete>
          <RawType>numeric text</RawType>
          <LengthType>next param</LengthType>
          <Type>double</Type>
       </Interprete>
      <Display>
         <RTDisplay>true</RTDisplay>
      </Display>
      <Measurement>
         <Type>discreet</Type>
         <Discreets>
            <Discreet>
               <Display>Up</Display>
               <Value>1</Value>
            </Discreet>
            <Discreet>
               <Display>Down</Display>
               <Value>2</Value>
            </Discreet>
            <Discreet>
               <Display>Testing</Display>
               <Value>3</Value>
            </Discreet>
         </Discreets>
      </Measurement>
    </Param>
    ```

    This write parameter will trigger the execution of a QAction (see step 4).

    > [!NOTE]
    > Do not provide an SNMP tag on the write parameter.

1. Create a parameter of type "write" to execute the SET with a dynamic OID (Note: this parameter should not be displayed on a page).

     ```xml
    <Param id="127" options="snmpSet">
       <Name>ifAdminStatusSNMPSet</Name>
       <Description>Interface Admin Status SNMP Set</Description>
       <Type>write</Type>
       <Interprete>
          <RawType>numeric text</RawType>
          <LengthType>next param</LengthType>
          <Type>double</Type>
       </Interprete>
       <SNMP>
          <Enabled>true</Enabled>
          <OID type="complete" id="99">1.3.6.1.2.1.2.2.1.7.*</OID>
          <Type>integer</Type>
       </SNMP>
    </Param>
    ```

    This parameter has the option "snmpSet" and an SNMP tag specifying an OID with a wildcard (`*`). Provide a link to another parameter (parameter with ID 99 in this example), which will hold the instance value. This is done via the id attribute.

1. Create a parameter of type "read" that will contain the dynamic part of the OID. This is the parameter that the write parameter defined in step 2 will link to. (Note that this parameter should not be displayed on a page.)

     ```xml
    <Param id="99">
       <Name>ifTableInstance</Name>
       <Description>Interface Table Instance</Description>
       <Type>read</Type>
       <Interprete>
          <RawType>other</RawType>
          <LengthType>next param</LengthType>
          <Type>string</Type>
       </Interprete>
       <Measurement>
          <Type>string</Type>
       </Measurement>
    </Param>
    ```

1. Create a QAction with the row attribute set to "true". This QAction will set the value of the parameter containing the dynamic part of the OID to the primary key of the row that triggered this QAction. (The primary key of the row that triggered the QAction is obtained via the RowKey method). The value that has been set in the write parameter (parameter with ID 117) is copied to the write parameter that will perform the SNMP set request (parameter with ID 127).

     ```xml
    <QAction id="117" name="Set Cell" encoding="csharp" triggers="117" row="true">
    <![CDATA[
       using Skyline.DataMiner.Scripting;
    
       public class QAction{
          public static void Run (SLProtocol protocol)
          {
             object value = protocol.GetParameter(117);
             string primaryKey = protocol.RowKey();
    
            // Set instance parameter.
            protocol.SetParameter(99, primaryKey);
            protocol.SetParameter(127, value);
    
            // Refresh table.
            protocol.CheckTrigger(1);
         }
      }
    ]]>
    </QAction>
    ```

    After the SET, a GET is required. In the example, a trigger is checked to refresh the table contents from the QAction.

    You can also use the option `snmpSetAndGetWithWait` to automatically perform a get of the cell that has been set (see [options attribute](xref:Protocol.Params.Param-options)). In order to use this, the instance option needs to be defined on the table. The column write parameter needs to have a wildcard but there is no need to specify another parameter containing the dynamic part of the OID.

## Via SLScripting

It is possible to perform an SNMP SET from a Quick Action using the NotifyProtocol method (type 292, [NT_SNMP_SET](xref:NT_SNMP_SET)).

To perform an SNMP set via the SLScripting process (i.e. in a QAction), perform the following steps:

1. Create a parameter of type "write" for the column.
1. Create a Quick Action that triggers on this parameter and executes the SNMP SET and the SNMP GET.

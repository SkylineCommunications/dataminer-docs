---
uid: AdvancedInterElementCommunicationDataDistribution
---

# Data distribution

Data distribution allows the distribution of the values of standalone parameters or table column parameters from one element to other elements. By using data distribution, you can prevent data being retrieved more than once, and also ensure that the data in the parent and child element are the same.

In a protocol, these data distribution parameters can be defined in either a fixed or a dynamic way. To use data distribution, add the *distribution* attribute to the parameter of the parent element you want to distribute. (For an overview of all possibilities, see [distribution](xref:Protocol.Params.Param.Type-distribution).) This parameter can be a standalone parameter or a column parameter from a table.

For example, the following parameter, defined on the parent element, will send the value of this parameter to parameter 100 of every element executing the protocol "Tandberg" on the DMA that runs the master element.

```xml
<Param id="100" trending="false">
   <Name>distributedParameter</Name>
   <Description>DistributedParameter</Description>
   <Information>
      <Subtext />
      <Includes>
         <Include>time</Include>
         <Include>range</Include>
         <Include>steps</Include>
         <Include>units</Include>
      </Includes>
   </Information>
   <Type distribution="protocol:Tandberg;pid:100;remote:true">read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>…</Display>
   <Measurement>
      <Type>number</Type>
   </Measurement>
</Param>
```

> [!NOTE]
> By default, data distribution is enabled only for elements on the same DMA. In case data distribution of a parameter should be performed on the entire DMS, set the remote setting in the distribution attribute to true (;remote:true).

In the following example, the data will be sent to parameter 100 of every element using the production version of the "Tandberg" protocol. Note that when you specify "production" and version 1.1.0.1 is the production version, the elements explicitly using version 1.1.0.1 instead of "production" will also receive the data. When you explicitly specify "1.1.0.1" in the distribution attribute, elements using "production" will receive the data.

```xml
distribution="protocol:Tandberg;version:production;pid:100"
```

In the following example, the data will be sent to parameter 100 of every element on this DMA executing the "Tandberg" protocol and using polling IP address 127.0.0.1:

```xml
distribution="protocol:Tandberg;pollingip:127.0.0.1;pid:100"
```

Distribution settings can have dynamic values. To specify a dynamic value, provide an asterisk (*), followed by the ID of the parameter containing the value. In the following example, the data will be sent to parameter 100 of every element that uses version x of the "Tandberg" protocol (on this DMA) and that has a polling IP address equal to the value specified in parameter 300 of the master element.

```xml
distribution="protocol:Tandberg;version:x;pid:100;pollingip:*300"
```

> [!NOTE]
>
> - Source parameters need RTDisplay set to true in order to function.
> - Information events containing "Set by SLProtocol - to [parameter value]" will be generated when a parameter set via data distribution has its RTDisplay option set to "true". A large number of sets will cause a large number of information events to be generated. To avoid this, if the receiving parameter does not have to be displayed, set the RTDisplay option of the receiving parameter to "false". In addition, make sure that the parameter is not monitorable (Alarm.Monitored false) as setting Alarm.Monitored to true on a parameter that has RTDisplay set to false will still generate this information event.

## Tables

Table data can also be distributed from one element to another element (or multiple elements) using data distribution.

In case you want to distribute data from a table, you have to specify the distribution attribute on the column parameter(s) you want to distribute.

- When the value of a cell is changed in the master table, the cell change is forwarded to the child element(s).
- The only cell that is updated in the child element(s) is the cell that corresponds with the cell of the table in the master element.

> [!NOTE]
>
> - When used on column parameters, the row in the receiving elements should already exist. In order to do this automatically it is possible to add the option "autoAdd" on the receiving table. This way, a row is created when a cell value is distributed.
> - When a row is removed, this removal is not pushed to the receiving element. Instead, you have to add an additional column that indicates if the row is to be deleted. The receiving element can then see if the row can be removed, and use a QAction to do so. (Similar to the usage of a 'state' column as is often done for SNMP tables).

---
uid: Protocol.Params.Param.Type-distribution
---

# distribution attribute

Used in situations in which elements of a certain type are linked to each other as parent and child.

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Remarks

By using data distribution, you can prevent data from being retrieved more than once, and also make sure that the data in your master and child are the same. In a protocol, these data distribution parameters can be defined in either a fixed or a dynamic way.

To use data distribution, you have to add the distribution attribute to a parameter in your master element. This parameter can be a “simple” parameter, or a column parameter from a table.

The distribution attribute can contain the following settings:

|Setting|Description
|--- |--- |
|Protocol @|The data will be sent to all elements with the specified protocol.|
|Version|The data will be sent to all elements with the specified protocol version.|
|PollingIP|The data will be sent to all elements with the specified polling IP address.|
|PollingIPPort|The data will be sent to all elements with the specified polling IP port.|
|BusAddress|The data will be sent to all elements with the specified bus address.|
|Pid @|The ID of the element parameter to which the data will be sent.|
|Remote|If you specify `distribution=remote:true`, then the data will be sent to all DMAs in the DataMiner system.|

In the following example, the data will be sent to parameter 100 of every element using the protocol called “Tandberg”:

```xml
distribution="protocol:Tandberg;pid:100"
```

In the following example, the data will be sent to parameter 100 of every element using the production version of the “Tandberg” protocol. Note that when you specify “production”, and for example version 1.1.0.1 is “production”, the elements explicitly using version 1.1.0.1 instead of “production” will also receive the data. When you explicitly specify “1.1.0.1” in your distribution attribute, elements using “production” will receive the data.

```xml
distribution="protocol:Tandberg;version:production;pid:100"
```

In the following example, the data will be sent to parameter 100 of every element using the “Tandberg” protocol and polling IP address 127.0.0.1:

```xml
distribution="protocol:Tandberg;pollingip:127.0.0.1;pid:100"
```

Distribution settings can have dynamic values. To specify a dynamic value, just enter an asterisk (*), followed by the ID of the parameter containing the value.

In the following example, the data will be sent to parameter 100 of every element that uses version X of the “Tandberg” protocol and that has a pollingip equal to the value specified in parameter 300 of the master element. In the example above, the pollingip will be retrieved from parameter 300 of the master element.

```xml
distribution="protocol:Tandberg;version:x;pid:100;pollingip:*300"
```

> [!NOTE]
>
> - When used on column parameters, the row in the receiving elements should already exist. In order to do this automatically it is possible to add the autoAdd option in the table. This way a row is created when a cell value is distributed.
> - When a row is removed, this removal is not pushed to the receiving element. Instead, you have to add an extra column that indicates if the row is to be deleted. The receiving element can then see if the row can be removed, and use a QAction to do so. (Similar to the usage of a “state” column often used on SNMP tables)
> - Information events containing “Set by SLProtocol - to parametervalue” will be generated when a parameter set via data distribution has its RTDisplay option set to true. A large number of sets will cause a large number of information events to be generated. To avoid this, and if the receiving parameter does not have to be displayed, set the RTDisplay option of the receiving parameter to false. Data
distribution will continue to work.

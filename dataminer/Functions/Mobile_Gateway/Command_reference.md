---
uid: Command_reference
---

# Command reference

Below, you can find a list of commands that can be used to interact with DataMiner elements (even Dynamic Virtual Elements) using text messages.

- [Getting a value](#getting-a-value)

- [Getting a value (including information about last update)](#getting-a-value-including-information-about-last-update)

- [Setting a value](#setting-a-value)

- [Executing a command](#executing-a-command)

### Getting a value

Send the following command to the DMS to retrieve the current value of a read parameter.

```txt
GET:ElementName:ParameterName|TableIndex
```

or

```txt
G:ElementName:ParameterName|TableIndex
```

For example, to get the value stored in the row with primary key 10113 of parameter “MyParam” of element “MyElement”:

```txt
GET:MyElement:MyParam|10113
```

> [!NOTE]
> - The table index (i.e. the primary key) should only be included for table column parameters. This is supported from DataMiner 10.2.0/10.1.10 onwards.
> - Getting the value from parameters with a pipe character ("\|") in the parameter name is no longer supported from DataMiner 10.2.0/10.1.10 onwards.
> - If an argument contains a colon (“:”) or a table index contains a pipe character (“\|”), this character must be preceded by a backslash (“\\”). For example, the command “GET:MyElement:MyParam\|a\\:b” will get the value stored in row a:b.

### Getting a value (including information about last update)

Send the following command to the DMS to retrieve the current value of a read parameter, as well as the following update information:

- time of last update

- user who performed the last update

```txt
GETX:ElementName:ParameterName|TableIndex
```

> [!NOTE]
> - The table index (i.e. the primary key) should only be included for table column parameters. This is supported from DataMiner 10.2.0/10.1.10 onwards.
> - Getting the value from parameters with a pipe character ("\|") in the parameter name is no longer supported from DataMiner 10.2.0/10.1.10 onwards.
> - If an argument contains a colon (“:”) or a table index contains a pipe character (“\|”), this character must be preceded by a backslash (“\\”).

### Setting a value

Send the following command to the DMS to update the value of a write parameter.

```txt
SET:ElementName:ParameterName|TableIndex:Value
```

or

```txt
S:ElementName:ParameterName|TableIndex:Value
```

For example, to set the value stored in the row with primary key 10113 of parameter “MyParam” of element “MyElement” to 100:

```txt
SET:MyElement:MyParam|10113:100
```

> [!NOTE]
> - The table index (i.e. the primary key) should only be included for table column parameters. This is supported from DataMiner 10.2.0/10.1.10 onwards.
> - Setting the value from parameters with a pipe character ("\|") in the parameter name is no longer supported from DataMiner 10.2.0/10.1.10 onwards.
> - If an argument contains a colon (“:”) or a table index contains a pipe character (“\|”), this character must be preceded by a backslash (“\\”). For example, the command “SET:MyElement:MyParam\|a\\:b\\\|c:100” will set the value stored in row a:b\|c to value 100.

### Executing a command

Send the following command to the DMS to execute a predefined command (i.e. a combination of gets and sets).

```txt
CMD:COMMANDNAME:VALUE1:VALUE2:...
```

or

```txt
C:COMMANDNAME:VALUE1:VALUE2:...
```

> [!NOTE]
> Value1, Value2, ... replace the default values in the set statements.

> [!TIP]
> See also:
> [Commands](xref:Configuring_Mobile_Gateway_in_DataMiner_Cube#commands)

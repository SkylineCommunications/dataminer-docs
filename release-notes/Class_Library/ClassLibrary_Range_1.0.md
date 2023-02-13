---
uid: ClassLibrary_Range_1.0
---

# Class Library Range 1.0

> [!NOTE]
> Range 1.0.x.x is supported as from DataMiner version 9.0.0

### 1.0.1.3

#### Matrix Helper: Serialized matrix status information \[ID_25127\]

The Matrix Helper classes now have an extra constructor that allows passing the ID of the serialized parameter, a single displayed read parameter of which the measurement type is set to string. The Matrix Helper object will then fill this parameter with the entire matrix status (labels, locks, crosspoints, etc.) in JSON format.

This matrix status information can then be read by, for example, the Generic Matrix Virtualization protocol or any other external element that is able to deserialize the JSON content to an object of the MatrixStatus class, which can be found in the same namespace as the Matrix Helper.

### 1.0.1.2

#### Problem recreating the monitor after an element restart \[ID_24756\]

When an element was restart, in some rare cases, an error could occur when recreating the Class Library monitor.

#### Enhanced handling of errors occurring while parsing element information returned by a GetElements method \[ID_24934\]

From now on, the Class Library will no longer throw an exception when an error occurs while parsing element information returned by a GetElements method.

- When element replication is not enabled for a particular element, then the replication properties of that element will no longer be parsed.

- When element replication is enabled for a particular element, and an error occurs while parsing the replicated remote element, then the incorrect ID will be logged, and the default remote element ID "-1/-1" will be used instead. This will make sure the element is included in the list of elements returned by the GetElements method.

- When a general error occurs while parsing the information of an element, then an entry will be added to the log, and the GetElements method will return all elements of which the information was parsed successfully.

### 1.0.1.1

#### New Rates namespace \[ID_24283\]

A new Rates namespace has been added. This namespace contains classes and methods that can be used to calculate all kind of rates, including bit rates for SNMP interface tables.

#### element.IsStartupComplete method would throw an exception when executed on an element that had been stopped \[ID_24290\]

In some cases, the IDmsElement IsStartupComplete method would throw an exception when it was executed on an element that had been stopped.

#### Problem when updating properties \[ID_24291\]

In some cases, it would not be possible to update properties that had a value equal to NULL.

#### Problem when requesting an element with duplicate properties \[ID_24293\]

When an element was requested via IDms, in some cases, an exception could be thrown when the element had duplicate properties.

From now on, when an element has duplicate properties, no exception will be thrown, but an entry will be added to the `C:\Skyline DataMiner\Logging\ClassLibrary.txt` log file.

#### GetAlarmTemplates() and GetTrendTemplates() would not work when the protocol was a production protocol \[ID_24357\]

In some cases, it would not be possible to retrieve the alarm template or the trend template of a protocol via IDms when that protocol was a production protocol.

Also, the IDmsProtocol interface now has a new "ReferencedVersion" property.

### 1.0.0.3

#### View name would be retrieved when it was already known \[ID_22303\]

Up to now, in some cases, the name of a view would be retrieved when it was already known. From now on, when the name of a view is already known, it will no longer be retrieved a second time.

#### Element properties will only be retrieved when needed \[ID_23514\]

From now on, element properties will only be retrieved when needed.

#### Exception thrown after detecting an element with duplicate properties will now also contain the name of the ID of the element \[ID_23515\]

The exception that is thrown when an element with duplicate properties is detected will now also contain the name and the ID of the element in question.

### 1.0.0.2

#### New matrix classes added to facilitate matrix and router control implementations \[ID_23075\]

Under Skyline.DataMiner.Library.Protocol.Matrix, the Class Library now contains a collection of classes that will help you develop matrix and router control implementations.

Also, in the DIS Macros tool window, a new CreateMatrix macro was added. This macro will help you initiate a new matrix and/or router control.

### 1.0.0.1

#### SetParameterMessage messages will no longer generate information events \[ID_22296\]

From now on, SetParameterMessage messages will no longer generate information events.

#### GetAgents (IDms) would fail if the response contained a DataMiner Agent ID equal to 0 \[ID_22297\]

In some cases, the GetAgents (IDms) method would fail if the response contained a DataMiner Agent ID equal to 0.

#### Property type is now passed along when updating element properties \[ID_22299\]

When an SLNet message is sent to update the value of a writable element property, from now on, the property type will be passed along.

#### ‘Name’ and ‘HostName’ properties added to IDma interface \[ID_22301\]

Two new properties have been added to the IDma interface:

- Name
- HostName

#### New classes to easily parse trap information \[ID_22302\]

The class library now includes classes to easily parse the trap information when using the allbindinginfo option.

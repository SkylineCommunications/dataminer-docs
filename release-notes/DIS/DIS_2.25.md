---
uid: DIS_2.25
---

# DIS 2.25

## New features

### Validator

#### New checks and error messages \[ID_24721\]

The following checks and error messages have been added.

| ID    | Check                  | Error message                                                                                                         |
|-------|------------------------|-----------------------------------------------------------------------------------------------------------------------|
| 3.3.1 | NonExistingTrigger     | Method 'SLProtocol.CheckTrigger' references a non-existing 'Trigger' with ID '{triggerId}'. QAction ID '{qactionId}'. |
| 3.4.1 | CompilationFailure     | C# compilation errors. QAction ID '{qactionId}'.                                                                      |
| 3.4.2 | CompilationFailure_Sub | {errorMessage}                                                                                                        |

### XML Schema

#### Protocol Schema: Updated/removed attributes \[ID_24481\]\[ID_24506\]\[ID_24761\]

The following changes have been made to the Protocol XML Schema:

Added:

- Protocol.Params.Param.Mediation.LinkTo.ValueMapping
- Protocol.PortSettings.FlowControl.Range
- Protocol.PortSettings.Parity.Range

Updated:

- Protocol.Params.Param.Alarm@activeTime now only accepts multiples of 1,000

Removed:

- Protocol.Params.Param.Alarm.Monitored@activeTime was removed.
- Protocol.PortSettings.SlowPollBase.Value

### Class Library

#### Enhanced handling of errors occurring while parsing element information returned by a GetElements method \[ID_24934\]

From now on, the Class Library will no longer throw an exception when an error occurs while parsing element information returned by a GetElements method.

- When element replication is not enabled for a particular element, then the replication properties of that element will no longer be parsed.
- When element replication is enabled for a particular element, and an error occurs while parsing the replicated remote element, then the incorrect ID will be logged, and the default remote element ID “-1/-1” will be used instead. This will make sure the element is included in the list of elements returned by the GetElements method.
- When a general error occurs while parsing the information of an element, then an entry will be added to the log, and the GetElements method will return all elements of which the information was parsed successfully.

## Changes

### Enhancements

#### IDE: DMA connection enhancements \[ID_24452\]

Up to now, when you clicked *Publish* (in a file tab header) or *Connect* (in the *DIS Inject* tool window), DIS would always publish or connect to the DMA that was set as default in the *DIS* tab of the *DIS Settings* window. However, it would also do so when you clicked either one of those buttons after having been disconnected from a DMA other than the default DMA.

From now on, DIS will remember the DMA to which you were last connected. Whenever it needs to reconnect, it will now reconnect to that DMA instead of to the default DMA.

> [!NOTE]
>
> - When you click *Publish* or *Connect* either for the first time after starting Visual Studio or after a manual disconnect, DIS will always connect to the default DMA.
> - Up to now, the settings for remote debugging were only configurable on a global level. In other words, the same settings were applicable to all DMAs defined in the *DIS* tab of the *DIS Settings* window. Now, you can configure those settings per DMA.

#### Automation Schema updated and reorganized \[ID_24520\]

The Automation Schema has been updated and reorganized.

#### IDE: Enhanced virtual comments \[ID_24571\]

The following protocol XML tags now have new or updated virtual comments:

| Tag | Virtual comment |
|-----|-----------------|
| Protocol.Params.Param.Interprete.Value | The length of the tag content. If the value is a correctly formatted hexadecimal string, it will be converted to a more readable format. |
| Protocol.Commands.Command.Content.Id<br>Protocol.Responses.Response.Content.Id | The virtual comments next to these tags now also contain a summary of the parameter content (length and fixed value when available). |

#### Validator: Error message enhancements \[ID_24635\]

A number of enhancements have been made with regard to the following error messages.

| ID     | Error message name | Enhancement                                                                                                                                                                                                                                       |
|--------|--------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 12.1.2 | MissingAttribute   | Severity lowered from Major to Minor.                                                                                                                                                                                                             |
| 12.1.3 | EmptyAttribute     | Severity lowered from Major to Minor.                                                                                                                                                                                                             |
| 12.1.4 | UntrimmedAttribute | Severity lowered from Major to Minor.                                                                                                                                                                                                             |
| 19.1.1 | MissingAttribute   | \-  Severity lowered from Major to Minor.<br> -  In some cases, a false positive was thrown on virtual connections. |
| 19.1.2 | EmptyAttribute     | Severity lowered from Major to Minor.                                                                                                                                                                                                             |
| 19.1.3 | UntrimmedAttribute | Severity lowered from Major to Minor.                                                                                                                                                                                                             |

### Fixes

#### Class Library: Problem recreating the monitor after an element restart \[ID_24756\]

When an element was restart, in some rare cases, an error could occur when recreating the Class Library monitor.

#### IDE - Function editor: Problem when moving parameters \[ID_24768\]

When you moved multiple parameters to another location on the page, in some cases, the parameters that were already situated on that location would be shifted incorrectly. As a result, multiple parameters would end up sharing the same location.

Also, in some cases, a Read parameter would get separated from its Write parameter after applying the export rules configured for the function in question.

#### IDE: Various minor fixes \[ID_24879\]

A number of minor issues have been fixed:

- Up to now, the table editor would incorrectly indicate the “separator” option of the ColumnOption tag as unknown.
- In some cases, compilations errors could be thrown when running Automation scripts with automatically generated Class Library EXE blocks.
- When, in the *Class Library* tab of the *DIS Settings* window, the *Automatically generate Class Library code* option was not selected, it would not be possible to manually generate Class Library code for Automation scripts by clicking *Code Helpers \> Generate Class Library Code* in the DIS menu.

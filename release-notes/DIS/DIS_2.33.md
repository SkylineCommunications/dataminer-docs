---
uid: DIS_2.33
---

# DIS 2.33

## New features

### IDE

#### New 'DIS Comparer' tool window \[ID_29124\]

The *Major Change Check* window has been replaced by a new *DIS Comparer* tool window. Also, the *Validate and compare* option has been removed.

When you click *Compare* at the top of an XML editor tab containing a protocol.xml file, the DIS Comparer tool window will now allow you to compare a base protocol (on the left) with another protocol (on the right).

1. Select two protocols by either clicking *Select* and selecting one of the protocols currently opened in the XML editor or clicking *File* and opening a protocol.xml file located in a file folder. If you do the latter when working inside a solution, the protocol.xml file you select will not be added to the solution.
1. Click *Compare* to have the two protocols compared.
1. If necessary, click *Export* to have the result of the comparison exported to a CSV file.

When you right-click an error in the list, a shortcut menu offers you the following options:

| Command | Function |
|--|--|
| Navigate | Go to the line in the protocol that triggered the error. |
| Copy | Copy the error to the Windows Clipboard. |
| Show Details... | Show all details of the error in a separate window. |
| Suppress... | Suppress the error. Note: Click the *Show/hide suppressed results* button to include/exclude the suppressed errors in/from the list. |

#### Class Library errors will now be shown in a banner instead of a popup window \[ID_29609\]

When an error occurred in a class library package (base or community) or if that package was not compatible with the current DataMiner version, up to now, a popup window would appear each time a change was made to the protocol. That popup window will now be replaced by a banner.

#### XML editor: Changing a QAction ID \[ID_29699\]

When editing a protocol in the XML editor, it is now possible to change the ID of a QAction.

To do so, proceed as follows:

1. Click the small *Down* arrow in front of the \<QAction> tag, and select *Change ID...* from the shortcut menu.
2. In the *Change QAction ID* window, enter the new QAction ID and click *OK*.

When you change the ID of a QAction, the following items will be updated:

- The id attribute of the \<QAction> tag
- The name of the C# project ("QAction_ID")
- The name of the main C# file ("QAction_ID.cs")
- The name of the default namespace ("QAction_ID")
- The AssemblyInfo.cs file
- The name of the project folder on disk

### Validator

#### Extended checks \[ID_29088\]

The following checks have been extended:

- Param.CheckDescriptionTag
- Param.Display.Positions.Position.CheckPageTag
- Param.Interprete.Exceptions.Exception.CheckDisplayTag
- Param.Measurement.Discreets.Discreet.CheckDisplayTag

From now on, these can all return the following error messages:

- DuplicateValue
- EmptyTag
- MissingTag
- UntrimmedTag
- WrongCasing

#### New checks and error messages \[ID_29597\]

The following checks and error messages have been added.

| Check ID | Error message name         | Error message                                                            |
|----------|----------------------------|--------------------------------------------------------------------------|
| 3.32.1   | ChangedClassLibraryVersion | Changed Class Library branch from '{previousVersion}' to '{newVersion}'. |

### XML Schema

#### Protocol Schema: New elements and element attributes \[ID_29018\] \[ID_29359\] \[ID_29819\]

The following elements and element attributes have been added to the Protocol XML Schema:

- Protocol.Chains.Chain@defaultSelectionField
- Protocol.Chains.Chain@groupingName
- Protocol.ParameterGroups.Group@isInternal
- Protocol.PortSettings.FlushPerDatagram
- Protocol.Ports.PortSettings.FlushPerDatagram

#### UOM Schema: New units added \[ID_29159\]

The following units have been added to the UOM Schema:

- Alarms (Alarms)
- Wh (Watt hour)

#### Protocol Schema: New syntax to conditionally show/hide chains and chain fields \[ID_29827\]

New syntax has been added to allow chains and chain fields to be shown or hidden based on parameter values.

See the following examples:

```xml
<Chain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</Chain>
```

```xml
<Chain>
  <Field>
    <Display>
      <Selection>
        <Visibility default=”false”>
          <Standalone pid=”18”>
            <Value>1</Value>
            <Value>2</Value>
          </Standalone>
        </Visibility>
      </Selection>
    </Display>
  </Field>
</Chain>
```

```xml
<SearchChain>
  <Display>
    <Visibility default=”false”>
      <Standalone pid=”8”>
        <Value>1</Value>
        <Value>2</Value>
      </Standalone>
    </Visibility>
  </Display>
</SearchChain>
```

### Class Library

#### IElementCollection now implements IEnumerable \[ID_29442\]

The IElementConnectionCollection interface, which is implemented by the ElementConnectionCollection class, now extends IEnumberable\<T>, allowing it to be used, for example, in a foreach loop to iterate over the connections.

#### DmsService class can now be used to manage DataMiner services \[ID_29513\]

The class library now includes a DmsService class that can be used to manage DataMiner services.

#### Monitors added to subscribe to service alarm level and service state \[ID_29515\]

Monitors have been added to subscribe to service alarm level and service state.

#### Monitors that subscribe to a table can now execute code whenever data in that table is updated \[ID_30055\]

Monitors that subscribe to a table can now execute code whenever data in that table is updated.

## Changes

### Enhancements

#### IDE: No longer possible to open a DIS macro in a protocol or Automation script solution \[ID_29093\]

Each time you open a DIS macro, a hidden C# project is created. Up to now, when you did so while working inside a protocol or Automation script solution, that hidden C# project would also be added to the solution. As this is unwanted behavior, from now on, when you try to open a DIS macro while working inside a solution, a message will appear, asking whether you want to open the DIS macro in a new Visual Studio instance.

#### Class Library: Additional check to prevent elements to restart after being updated \[ID_29777\]

When an element is updated, it will be restarted whenever its port settings have been changed. Now, an additional check has been added to make sure an element is not restarted when, during an update, its port settings have not been changed.

### Fixes

#### Class Library: IsSslTlsEnabled property of all ports of an element would incorrectly be reset to false when an element port had been updated \[ID_29440\]

When an element port was updated, up to now, the IsSslTlsEnabled property of all ports of that element would incorrectly be reset to false.

#### IDE - XML editor: Problems with the QAction option 'dllName' \[ID_29587\]

When you had specified the *dllName* option in the *Protocol.QActions.QAction@options* attribute, up to now, the following issues could occur:

- When a solution-based protocol was compiled, QActions would incorrectly be referred to using the default DLL name "QAction.ID.dll", even when a custom DLL name had been specified.
- When, in a non-solution-based protocol, a custom DLL name was specified in a \<QAction> tag, the Validator would incorrectly thrown a "Could not find DLL: \[ProtocolName\].\[protocolVersion\].Test.dll" error.

#### Class Library: RemotePort would throw 'null reference' exceptions when trying to retrieve a replicated element \[ID_30053\]

RemotePort would throw "null reference" exceptions when trying to retrieve a replicated element.

#### Class Library: SLSpectrum wrappers were missing a GetMonitor call with the correct return format \[ID_30056\]

The SLSpectrum wrappers were missing a GetMonitor call with the correct return format.

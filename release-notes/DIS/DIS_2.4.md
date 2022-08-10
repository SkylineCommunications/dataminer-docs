---
uid: DIS_2.4
---

# DIS 2.4

## New features

### IDE

#### Protocol editor: Generating parameters from XML and JSON files \[ID_13073\]

Up to now, when you right-clicked in the protocol editor, the *Generate Parameters from MIB* command allowed you to import parameter data from a MIB file.

Now, this command has been renamed to *Generate Parameters*, and allows you to import parameter data not only from a MIB file, but also from an XML file or a JSON file.

#### Table editor: Creating a new table \[ID_13089\]

In the table editor, the *New Table* button now allows you to create an entirely new table.

To create a new table:

1. Click the *New Table* button.
1. Specify a parameter ID, a table name, and a table description, and click *OK*.
1. In the *Parameters* list, select the parameters that you want to assign to the columns of the table, and drag them onto the *All Columns* or the *Displayed Columns Layout* section.
1. Click *Apply Changes*.

### Validator

#### Additional result codes for 'Command Response Pair Group' and 'Attribute Contents' checks \[ID_13856\]

The ‘Command Response Pair Group’ and ‘Attribute Contents’ checks can now throw a number of additional errors.

| Result code | Class | Description                                                                     |
|-------------|-------|---------------------------------------------------------------------------------|
| 2524        | Error | Group with id \[Group ID\] in Timer \[Timer ID\] does not exist.                |
| 2525        | Error | Trigger on \[‘on’ type\] uses \[‘on’ type\] with id \[ID\] that does not exist. |
| 2526        | Error | Action on \[‘on’ type\] uses \[‘on’ type\] with id \[ID\] that does not exist.  |
| 2970        | Error | Trigger parameter \[Parameter ID\] does not exist.                              |
| 2971        | Error | InputParameter parameter \[Parameter ID\] does not exist.                       |
| 2972        | Error | Non existing QAction DLL reference \[DLL Reference\].                           |

#### New 'Check Interprete Measurement' check \[ID_13862\]

A new check has been added that will throw a warning whenever a parameter does not have matching Interprete and Measurement types.

| Result code | Class       | Description                                                    |
|-------------|-------------|----------------------------------------------------------------|
| 5000        | Information | All parameters have matching Interprete and Measurement types. |
| 5001        | Warning     | Verify Measurement - Interprete Combination for {0} : {1}      |
| 5002        | Warning     | Verify Interprete RawType - Type Combination: {0} - {1}        |

#### 'Main display tag integrity' check now also checks the content of the defaultPage attribute of the Display tag \[ID_13863\]

The ‘Main display tag integrity’ check now also checks the content of the defaultPage attribute of the main Display tag. As a result, the text of warning 1101 has been updated.

| Result code | Class   | Description                                                              |
|-------------|---------|--------------------------------------------------------------------------|
| 1101        | Warning | Main Display tag attribute “defaultPage” is missing, malformed or empty. |

#### New 'Check Protocol Names' check \[ID_13864\]

A new check has been added that will throw an error whenever an exported DVE protocol has an incorrect protocol name.

| Result code | Class | Description |
|-------------|-------|-------------|
| 4900 | Information | Protocol names OK |
| 4901 | Error | Protocol name contains illegal characters. |
| 4902 | Error | Exported protocol name \[Protocol Name\] contains illegal characters. |
| 4903 | Error | Exported protocol name \[Protocol Name\] has an incorrect format. Expected format is “\[Parent Protocol Name\] - \[Name\]” |

#### 'Check Trend Alarm' check: New return codes \[ID_13872\]

The ‘Check Trend Alarm’ check can now thrown two additional errors:

| Result code | Class | Description |
|-------------|-------|-------------|
| 2405 | Error | Write parameter is trended and monitored. |
| 2406 | Error | Parameter {0} has trending="true" and is monitored. However, it is not displayed on any page, which is inconsistent. Please verify. |

#### 'Check RTDisplay True' check: New return code \[ID_15136\]

The ‘Check RTDisplay True’ check can now thrown the following additional error when a table without export attribute and without ‘RTDisplay=”true”’ setting has a column with an export attribute.

| Result code | Class | Description                                                                                           |
|-------------|-------|-------------------------------------------------------------------------------------------------------|
| 4424        | Error | RTDisplay="true" is required on table \[Parameter ID\]. Column with pid \[Parameter ID\] is exported. |

#### Triggers: \<on id=”each”> allowed when contents of \<on> tag is command, response, pair or group \[ID_15244\]

When a \<Trigger>\<On>...\</On>\</Trigger> tag contains “command”, “response”, “pair” or “group”, then the id attribute of the \<on> tag can now be set to “each”. See the following example:

```xml
<Trigger id=”200”>
  ...
  <On id=”each”>response</On>
  ...
</Trigger>
```

### XML Schema

#### Compliancies tags \[ID_13853\]

You can now use the following compliance subtags inside a *Protocol.Compliancies* tag:

```xml
<Compliancies>
    <CassandraReady>true</CassandraReady>
    <CassandraRequired>true</CassandraRequired>
    <MinimumRequiredVersion>9.0.3.7-5687</MinimumRequiredVersion>
</Compliancies>
```

> [!NOTE]
> The version number specified in the *MinimumRequiredVersion* tag has to have the following syntax:
>
> - major.minor.month.week, or
> - major.minor.month.week-xxxx (in which xxxx is the four-digit build number)
>
> Examples: 9.0.3.7 or 9.0.3.7-5687

#### XML Schema now allows multiple DVEProtocol tags \[ID_15137\]

The XML Schema now allows the use of multiple DVEs.DVEProtocols.DVEProtocol tags.

## Changes

### Enhancements

#### New DIS installation packages will now be compatible with Visual Studio 2017 \[ID_15050\]

New DIS installation packages will now be fully compatible with Microsoft Visual Studio 2017.

> [!NOTE]
> In order to make the installation packages compatible with Visual Studio 2017, their manifest had to be upgraded from v1 to v3. This means, that all installation packages as from DIS v2.4.1 will require at least Visual Studio 2012.
> If you want to install DIS on top of a Visual Studio version prior to 2012, then you will have to install DIS v2.0.3.

#### Improved handling of DVE protocols \[ID_15136\]

Due to a number of enhancements, handling of DVE protocols has improved.

Using the syntax `<DVEs><DVEProtocols><DVEProtocol></DVEs>` is now also supported.

### Fixes

#### Error when validating a protocol without a namespace \[ID_13865\]

In some cases, an error could occur when DIS was trying to validate a protocol without a namespace.

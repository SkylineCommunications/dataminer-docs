---
uid: DIS_2.21
---

# DIS 2.21

## New features

### IDE

#### Multiple DMA connections \[ID_22933\]

In the *DMA* tab of the *DIS Settings* window, it is now possible to configure multiple DMA connections and to organize them in groups. That way, developers will be able to quickly connect to another DMA without having to change any of the settings.

##### Default connection

After having configured a number of DMA connections in the *DMA* tab of the *DIS Settings* window, you can set one of them as default connection by right-clicking it and selecting *Set as Default*.

- To publish a protocol or an Automation script to the default DMA, at the top of the XML editor, click the *Publish* button. To publish a protocol or an Automation script to a non-default DMA, at the top of the XML editor, click the drop-down button at the right of the *Publish* button, and click the DMA to which you want the file to be published.
- When, in the *DIS Inject* tool window, you want to connect to the default DMA, click the *Connect* button. When, in the *DIS Inject* tool window, you want to connect to a non-default DMA, click the drop-down button at the right of the *Connect* button, and click the DMA to which you want to connect.

> [!NOTE]
> The title of the *DIS Inject* tool window now includes the name of the DMA to which DIS is connected (between brackets). When DIS is not connected to any DMA, the tool window title will include “(not connected)”.

##### Production DMA

When configuring a DMA connection, you can now indicate whether this DMA is a production DMA. When you try to publish a protocol or an Automation script to a production DMA, a confirmation box will appear to prevent you from accidentally publishing that file to it.

#### Suppressing results in the DIS Validator window \[ID_23233\]

In the *DIS Validator* tool window, it is now possible to suppress validation and protocol comparison results.

##### Suppressing a result in the DIS Validator tool window

To suppress a result, right-click it, choose *Suppress...*, enter a (mandatory) reason of at least 5 characters, and click *OK*.

Suppressed results will, by default, not be displayed in the *DIS Validator* tool window. If you want suppressed results to be displayed, then click the *Show/hide suppressed results* toggle button at the top of the window.

> [!NOTE]
>
> - When you choose to display suppressed results, they will appear in gray.
> - When you right-click a suppressed result and choose *Show details...*, the reason why this result was suppressed will be shown in red.

##### How suppressed items are marked in a protocol.xml file

When you suppress a result in the *DIS Validator* tool window, the following comment tags are added to the protocol.xml file.

- In case of a protocol validation result:

    ```xml
    <!-- SuppressValidator <code> <reason> -->
    ...
    <!-- /SuppressValidator <code> -->
    ```

- In case of a protocol comparison result:

    ```xml
    <!-- SuppressMajorChange <code> <reason> -->
    ...
    <!-- /SuppressMajorChange <code> -->
    ```

When, for example, you suppress a validation result that warns you about unknown unit “abc” (error 2.9.4), the following comment tags will be added to the protocol.xml file:

```xml
...
<Display>
    <!-- SuppressValidator 2.9.4 Not yet added to the list of units -->
    <Units>abc</Units>
    <!-- /SuppressValidator 2.9.4 -->
</Display>
...
```

### Validator

#### New and updated checks and error messages \[ID_22334\]

The following checks and error messages have been added or updated.

| ID     | Check                        | Error message                                                                                             |
|--------|------------------------------|-----------------------------------------------------------------------------------------------------------|
| 2.47.1 | Param.CheckOidTagIdAttrCombo | Excessive attribute 'SNMP/OID@id' in Param '{pid}'.                                                       |
| 2.47.2 | Param.CheckOidTagIdAttrCombo | Invalid combination of OID value '{oidValue}' and SNMP/OID@id value '{idValue}' in Param '{pid}'.         |
| 2.48.1 | Param.CheckIdAttribute       | Empty attribute 'SNMP/OID@id' in Param '{pid}'.                                                           |
| 2.48.2 | Param.CheckIdAttribute       | Invalid attribute 'SNMP/OID@id' in Param '{pid}'. Current value '{currentValue}'.                      |
| 2.48.3 | Param.CheckIdAttribute       | Attribute 'SNMP/OID@id' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'. |
| 2.48.4 | Param.CheckIdAttribute       | Unsupported Param '{idAttributeValue}' reference in attribute 'SNMP/OID@id' in Param '{pid}'.             |
| 2.48.5 | Param.CheckIdAttribute       | Untrimmed attribute 'SNMP/OID@id' in Param '{pid}'. Current value '{untrimmedValue}'.                     |

### XML Schema

#### Protocol Schema: New icons added to Icons enum \[22880\]

In the Protocol XML Schema, a number of new icons have been added to the Icons enum:

- 4 IDP Solution icons (IDP-OK, IDP-NOK, IDP-Running, IDP-Unknown)
- 141 .NET Framework color icons (RECT-AliceBlue, RECT-AntiqueWhite, etc.)

### Class Library

#### New matrix classes added to facilitate matrix and router control implementations \[ID_23075\]

Under Skyline.DataMiner.Library.Protocol.Matrix, the Class Library now contains a collection of classes that will help you develop matrix and router control implementations.

Also, in the *DIS Macros* tool window, a new *CreateMatrix* macro was added. This macro will help you initiate a new matrix and/or router control.

#### New InterApp classes now provide a C# message/response architecture \[ID_23298\]

A collection of InterApp classes now provides a C# message/response architecture that will allow for easier communication

- among elements,
- between elements and Automation scripts, and
- between elements and external applications.

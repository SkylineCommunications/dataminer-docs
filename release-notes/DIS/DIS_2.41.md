---
uid: DIS_2.41
---

# DIS 2.41

## New features

### IDE

#### XML editor: Clicking 'Validate' will now also validate exported DVE protocols [ID_33618]

When, in the XML editor, you open a main DVE protocol and click *Validate*, from now on, DIS will not only validate the main protocol but also all its exported child DVE protocols.

#### Support for Microsoft Visual Studio 2017 has been dropped [ID_35770]

Support for Microsoft Visual Studio 2017 has been dropped. The last DIS version supporting Visual Studio 2017 is DIS v2.40.

> [!NOTE]
> The minimum supported DataMiner version is now DataMiner v10.1.0.

#### Class Library generation feature has been removed in favor of NuGet packages [ID_35819] [ID_35827]

The Class Library generation feature has been removed in favor of NuGet packages.

- If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, see [Class library introduction](xref:ClassLibraryIntroduction).

- If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package. For more information on how to create a NuGet package, see [Producing NuGet packages](xref:Producing_NuGet). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

Also, an information bar will allow you to convert existing solutions that make use of the Class Library generation feature.

This information bar will appear when a Class Library project (i.e. a project named "QAction_ClassLibrary" or "AutomationScript_ClassLibrary") is detected in a protocol or Automation script solution. As soon as you click *Fix*, the Class Library project will be removed and the references to the project will be replaced by references to the automatically generated Class Library project (which, by default, will have ID 63000).

#### C# editor: New snippet [ID_35991]

In the C# editor, the following snippet now allows you to generate an `OnApiTrigger` entrypoint method in an Automation script. This entrypoint method will be used to create an API from an Automation script.

- DIS \> Automation Script \> CreateUserDefinedApi (Automation)

#### XML editor: Protocols will now be allowed to use SLManagedAutomation DLL files [ID_36099]

Up to now, DIS would filter out any development packs or Skyline.DataMiner.Files NuGet packages. From now on, when it detects that a reference to such a SLManagedAutomation DLL file is needed for a particular QAction to run, it will add the reference to the `dllImport` attribute of the QAction. However, the file itself will not be included.

#### XML editor: Referring to a library script Exe from another Automation script [ID_36117]

​Up to now, it was only possible to refer to a library script Exe from within the same Automation script. From now on, in a Visual Studio solution, you can also add a reference to a project from another Automation script in the solution. DIS will then automatically add a `scriptRef`.

See the following example, in which `{SCRIPTNAME}` is the name of the other script containing the library and `{LIBRARYNAME}` is the name of the library:

```xml
<Param type="scriptRef">{SCRIPTNAME}:{LIBRARYNAME}</Param>
```

As DIS will automatically add a `scriptRef`, developers will only need to add a reference to the project that represents the library.

### Validator

#### New checks and error messages [ID_35384] [ID_35558]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 2.72.1 | EmptyAttribute | Empty attribute 'Monitored@disabledIf' in Param '{pid}'. |
| 2.72.2 | UntrimmedAttribute | Untrimmed attribute 'Monitored@disabledIf' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.72.3 | InvalidValue | Invalid value '{attributeValue}' in attribute 'Monitored@disabledIf'. Param ID '{pid}'. |
| 2.72.4 | NonExistingId | Attribute 'Monitored@disabledIf' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'. |
| 2.72.5 | ReferencedParamWrongType | Invalid Param Type '{referencedParamType}' on Param referenced by a 'Monitored@disabledIf' attribute. Param ID '{referencedPid}'. |
| 2.72.6 | ReferencedParamRTDisplayExpected | RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Monitored@disabledIf' attribute. Param ID '{referencingPid}'. |
| 3.36.1 | UnrecommendedXmlSerializerConstructor | Constructor '{typeUnrecommendedConstructor}' ('{constructorNamespace}') is unrecommended. QAction ID {qactionId}. |

### XML Schema

#### Protocol Schema: New element & new element value [ID_35350]

The following element has been added to the protocol schema:

- New element: `Protocol.Params.Param.Matrix`
- New `Protocol.Params.Param.Type` value: "Matrix"

#### UOM Schema: New units added [ID_36032]

The following units have been added to the UOM Schema:

- cd/m^2 (Candela per square meter)
- nt (Nit, the non-SI name for cd/m<sup>2</sup>)

## Changes

### Enhancements

#### Changes made to the Microsoft Visual Studio UI [ID_35566]

The following changes have been made to the Microsoft Visual Studio UI:

- In the *About Microsoft Visual Studio* window (*Help > About Microsoft Visual Studio*), the *Installed products* list will now show the correct version of the installed DIS package.

- When, in the *Manage Extensions* window, you select the *DataMiner Integration Studio* extension, you will now find two additional links in the details pane on the right:

  - *Release Notes* (pointing to the release notes of the installed DIS version on <https://docs.dataminer.services/>)
  - *Getting Started* (pointing to [Installing and configuring the software](xref:Installing_and_configuring_the_software))

  Also, the *More Information* link will now point to [DataMiner Integration Studio](xref:DIS).

### Fixes

#### Validator: False positive thrown when a column was added to a table that contained a column of type displayKey [ID_35266]

When a column was added to a table that contained a column of type *displayKey*, the *CheckOptionsAttribute* (2.31) check would thrown a false positive *ColumnOrderChanged* (2.31.1) error.

> [!NOTE]
> From now on, error messages related to table columns will refer to column parameter IDs instead of column indices.

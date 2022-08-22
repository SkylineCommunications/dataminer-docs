---
uid: DIS_2.20
---

# DIS 2.20

## New features

### IDE

#### MIB Browser now also supports adding parameters of type Gauge32, Integer32, TimeTicks and Unsigned32 \[ID_22474\]

Up to now, the MIB Browser only supported adding parameters of type Integer. From now on, it will also support adding parameters of type Gauge32, Integer32, TimeTicks and Unsigned32.

#### Class library enhancements \[ID_22481\]

Instead of loading individual C# files, DIS will now load packages containing a number of C# files and a manifest.xml file. The latter will contain the name and the version of the package as well as any dependencies to other packages.

In *DIS Settings \> Class Library*, users will now be able to select a base package (shipped with DIS) and specify the location of one or more custom/community packages, which contain code written specifically for a particular vendor or project and maintained by a dedicated team of developers.

When a QAction is generated, all information about the packages that were used to build the class library packages used by that QAction will be added to it. This will allow DIS to check the included packages each time it generates a QAction, alert the user whenever it notices package inconsistencies (different base package, updated community packages, etc.), and offer the user the opportunity to either allow or block the QAction update.

DIS will automatically reload the class library packages when packages have been modified on disk or when the class library settings have been changed in *DIS Settings \> Class Library*.

#### New module to manage the connections between DIS and DataMiner \[ID_22532\]

An entirely new module will now be managing the connections between DIS and DataMiner.

#### DIS is now fully compatible with Microsoft Visual Studio 2019 \[ID_22579\]

DIS is now fully compatible with Microsoft Visual Studio version 2019.

> [!NOTE]
> As, from now on, DIS will be using a new version of the Visual Studio API, DIS versions as from v2.20 will require at least Microsoft Visual Studio 2015 Professional Edition.

### Validator

#### New and updated checks and error messages \[ID_22108\]\[ID_22313\]\[ID_22569\]

The following checks and error messages have been added or updated.

| ID      | Check                       | Error message                                                                                                                                                                                   |
|---------|-----------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 2.21.8  | Param.CheckOptionsAttribute | Matrix option '{columnTypes}' not inline with option '{dimensions}'. Matrix PID '{matrixPid}'.                                                                                                  |
| 2.21.9  | Param.CheckOptionsAttribute | Invalid Interprete/RawType '{rawType}' for 'Matrix ColumnType Param'. ColumnType PID '{columnTypePid}'. Matrix PID '{matrixPid}'. Possible values 'numeric text, unsigned number'.              |
| 2.21.11 | Param.CheckOptionsAttribute | Missing '{optionName}' option for matrix. Param ID '{matrixPid}'.                                                                                                                               |
| 2.21.12 | Param.CheckOptionsAttribute | Missing attribute 'Param/Type@options' in Matrix '{matrixPid}'.                                                                                                                                 |
| 2.21.13 | Param.CheckOptionsAttribute | Invalid Param Type '{paramType}' on matrix. Matrix PID '{matrixPid}'.                                                                                                                           |
| 2.21.14 | Param.CheckOptionsAttribute | Invalid syntax for the '{optionName}' option. Matrix PID '{matrixPid}'.                                                                                                                         |
| 2.21.15 | Param.CheckOptionsAttribute | Invalid Interprete/LengthType '{lengthType}' for 'Matrix ColumnType Param'. ColumnType PID '{columnTypePid}'. Matrix PID '{matrixPid}'. Possible values 'next param, fixed'.                    |
| 2.21.16 | Param.CheckOptionsAttribute | Invalid Interprete/Type '{type}' for 'Matrix ColumnType Param'. ColumnType PID '{columnTypePid}'. Matrix PID '{matrixPid}'. Possible values 'double'.                                           |
| 2.21.17 | Param.CheckOptionsAttribute | Missing 'columntypes' Param with ID '{missingColumnTypePid}' for matrix Param with ID '{matrixPid}'.                                                                                            |
| 2.21.18 | Param.CheckOptionsAttribute | Missing 'Interprete' Tag on matrix ColumnType Param with ID '{missingColumnTypePid}' for matrix Param with ID '{matrixPid}'.                                                                    |
| 2.31.3  | Param.CheckOptionsAttribute | {badValue}': Invalid '{minOrMax}' number of connections for one {inputOrOutput} for matrix '{matrixPid}'.                                                                                       |
| 2.31.4  | Param.CheckOptionsAttribute | Matrix Param '{matrixPid}' Measurement/Type@options - matrix:outputCount of '{measurementOutputCount}' does not match Param/Type@options - dimensions: columnCount of '{dimensionColumnCount}'. |
| 2.31.5  | Param.CheckOptionsAttribute | Matrix Param '{matrixPid}' Measurement/Type@options - matrix:inputCount of '{measurementInputCount}' does not match Param/Type@options - dimensions: rowCount of '{dimensionRowCount}'.         |
| 2.31.6  | Param.CheckOptionsAttribute | Invalid syntax for the '{optionName}' option. Matrix PID '{matrixPid}'.                                                                                                                         |
| 2.31.7  | Param.CheckOptionsAttribute | Missing '{optionName}' option for matrix Param. Matrix PID '{matrixPid}'.                                                                                                                       |
| 2.31.8  | Param.CheckOptionsAttribute | Missing attribute 'Measurement/Type@Options' in Matrix '{matrixPid}'.                                                                                                                           |
| 2.31.9  | Param.CheckOptionsAttribute | Table not mainly sorted on one of its date(time) column(s). Table PID '{tablePid}'. Date(time) column PIDs '{columnPids}'.                                                                      |
| 2.37.2  | Param.CheckTypeTag          | Invalid RawType '{rawType}' for matrix Param '{matrixPid}'. Expected RawType 'other'.                                                                                                           |
| 2.37.3  | Param.CheckTypeTag          | Invalid Interprete/Type '{interpreteType}' for matrix Param '{matrixPid}'. Expected Type '{expectedInterpreteType}'.                                                                            |
| 2.37.4  | Param.CheckTypeTag          | Invalid LengthType '{lengthType}' for matrix Param '{matrixPid}'. Expected LengthType 'next param'.                                                                                             |
| 2.37.5  | Param.CheckTypeTag          | Matrix Param '{matrixPid}' should be alarmed.                                                                                                                                                   |
| 2.37.6  | Param.CheckTypeTag          | Matrix Param '{matrixPid}' should not be trended.                                                                                                                                               |
| 2.37.7  | Param.CheckTypeTag          | Invalid attribute 'setter' in Matrix '{matrixPid}'. Current value 'true'.                                                                                                                       |
| 2.41.1  | Param.CheckMatrixDiscreets  | Invalid number of Discreets '{discreetCount}' for matrix Param. Expected count '{expectedDiscreetCount}'. Param ID '{matrixPid}'.                                                               |
| 2.41.2  | Param.CheckMatrixDiscreets  | Missing matrix Discreet values '{missingValues}'. Param ID '{matrixPid}'.                                                                                                                       |
| 2.41.3  | Param.CheckMatrixDiscreets  | Matrix Discreet values should be one-based. Param ID '{matrixPid}'.                                                                                                                             |
| 2.42.1  | Param.CheckLinkAttribute    | Invalid syntax for 'Measurement/Type@link' attribute on matrix Param. Matrix PID '{matrixPid}'.                                                                                                 |
| 2.42.2  | Param.CheckLinkAttribute    | Missing attribute 'Measurement/Type@link' in matrix '{matrixPid}'.                                                                                                                              |
| 2.45.1  | Param.CheckOthersTag        | Id attribute '{oldId}' has been changed to '{newId}' for Other tag with Value tag '{valueTag}'. Param ID '{paramPid}'.                                                                          |
| 2.45.2  | Param.CheckOthersTag        | Display tag '{oldDisplayTag}' has been changed to '{newDisplayTag}' for Other tag with Value tag '{valueTag}'. Param ID '{paramPid}'.                                                           |
| 2.45.3  | Param.CheckOthersTag        | Other with Value tag '{oldValue}' has been deleted. Param '{paramPid}'.                                                                                                                         |
| 2.45.4  | Param.CheckOthersTag        | Other with Value tag '{newValue}' has been added. Param '{paramPid}'.                                                                                                                           |

---
uid: DIS_2.5
---

# DIS 2.5

## New features

### IDE

#### Compilation of C# projects in language version 4 \[ID_16096\]

Up to now, when DIS opened a QAction and created the necessary C# projects, it used the default C# compiler of the Visual Studio version that was installed. As DataMiner does not yet support all new features of the C# compiler shipped with Visual Studio 2015 and 2017, DIS will now compile all C# projects in language version 4.0.

#### Automatic injection of referenced QActions when debugging \[ID_16097\]

When a QAction refers to another QAction in a DllImport attribute, then that referenced QAction will now also automatically be injected when you debug a protocol in DIS.

#### Table editor: New 'Header', 'Histogram' and 'Heatmap' options \[ID_16098\]

If, in the table editor, you add a monitored parameter of Interprete type “double” and measurement type “number” or “analog”, you can now set three additional options in the *Displayed Columns Layout* section.

- In the *Header* column, you can indicate the type of aggregated information you want to have displayed in the column header: None, Sum, Avg, Min or Max.
- In the *Histogram* column, you can disable or enable the histogram of all rows in the column header.
- In the *Heatmap* column, you can disable or enable the heatmap in all rows in the column header.

Also, from now on, the *Extra Options* column in the *All Columns* section will only display options that do not have a dedicated UI component in the table editor. When unknown options are defined, a warning will now be generated. In the protocol.xml file, the options will be sorted as follows: save, foreignKey, indexColumn, header, histogram, heatmap, and then all other options.

### Fixes

#### IDE: Could not find DLL Import \[ID_16099\]

When you added a new DLL import to a QAction that had already been opened in Visual Studio (i.e. a QAction for which a C# project had already been created), in some cases, the new DLL import was not applied correctly. Also, “\\\\?\\” was added in front of the DLL file path. As a result, the QAction could not be built and an error was added to the error list.

This issue would only occur if the DLL file was located in the `C:\Skyline DataMiner\ProtocolScripts` folder or the `C:\Skyline DataMiner\Files` folder, not if the DLL file was a .NET framework assembly.

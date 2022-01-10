# Developing DataMiner protocols and Automation scripts as Visual Studio solutions

## Developing DataMiner protocols as Visual Studio solutions

By default, a DataMiner protocol developed using DIS is a ready-to-use XML file that contains all necessary information, including QActions with integrated C# code. As from v2.26, DIS also allows you to develop a DataMiner protocol as a Visual Studio solution. That solution will then contain the protocol XML file and as many C# projects as there are QActions in the protocol (each containing the C# code of their associated QAction).

### Creating a new protocol solution

To create a new protocol solution containing a basic protocol with one precompiled, basic QAction, select *File \> New \> DataMiner Protocol Solution…*

### Converting an existing protocol XML file to a protocol solution

To convert an existing protocol XML file to a protocol solution, select *DIS \> Protocol \> Convert to Solution...*

A new protocol solution will be created, and the existing protocol XML file will be added. However, the \<QAction> tags will not contain any C# code. For each of the QActions in the original protocol XML file, a new C# project will be created, and any DLL imports specified in the original QActions will be converted to references on the C# projects (pointing either to other C# projects or to DLL files).

> [!NOTE]
> When you open a protocol, DIS will automatically detect whether the protocol is solution-based. A protocol will be considered solution-based when the solution has a “Solution Items” folder containing a “protocol.xml” file and a “QActions” folder containing at least one C# project named “QAction\_\<id>”.

### Managing QActions

#### Adding a QAction

To add a QAction to a protocol solution, do the following:

1. Add a new Protocol.QActions.QAction tag to the protocol XML file (manually or via a snippet), assign a unique ID to it, and optionally add the necessary C# code.

2. Click the *Edit QAction* icon next to the \<QAction> tag.

DIS will automatically generate a new C# project, add it to the solution, and open the QAction in a new editor tab. If you have already added some C# code, that code will be moved to the QAction\_\<id>.cs file in the new C# project.

#### Editing a QAction

To edit a QAction, you have two options:

- Click the *Edit QAction* icon next to the \<QAction> tag in the protocol XML file (as before).

- Open Visual Studio’s Solution Explorer window, go to the QAction\_\<id> project and open the QAction\_\<id>.cs file.

> [!NOTE]
> -  A QAction project can contain several \*.cs files. These files will then be combined when the protocol is compiled.
> -  It is recommended to place all “using” directives inside the namespace instead of at the top of the file.
> -  DLL imports now need to be configured by adding references on the C# project itself. Those references can either refer to external DLL files (in C:\\DataMiner\\ProtocolScripts or C:\\DataMiner\\Files) or to other QActions in the solution. The latter will be translated at compilation to “\[ProtocolName\].\[ProtocolVersion\].QAction.\<id>.dll” imports in the protocol.

#### Removing a QAction

To remove a QAction, remove the \<QAction> tag in the protocol XML file as well as the C# project.

### Uploading a protocol to a DataMiner Agent

Because, in a protocol solution, the QActions in the protocol XML file do not contain any C# code, the protocol first needs to be compiled before it can be uploaded to a DataMiner Agent. Only at compilation will the code in all QAction projects and files found in the solution be copied to the correct \<QAction> tags in the protocol XML file.

A protocol will automatically be compiled when you click the *Publish* button at the top of the file tab, or when you right-click and select *Copy Protocol to Clipboard*.

### Saving a compiled protocol to a file

To save a compiled protocol to a file, select *File \> Save Compiled Protocol As...*

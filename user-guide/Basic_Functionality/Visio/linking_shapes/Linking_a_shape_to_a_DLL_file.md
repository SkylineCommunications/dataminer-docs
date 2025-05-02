---
uid: Linking_a_shape_to_a_DLL_file
---

# Linking a shape to a DLL file

Using a shape data field of type **Execute**, you can link a shape to one or more DLL files.

When you link a shape to one or more DLL files, the DLL file(s) will be executed each time a user clicks that shape. This way, you can allow users to start e.g. WFM modules.

## Configuring the shape data field

Add a shape data field of type **Execute** to the shape, and set its value to:

```txt
Dll|ExtraDllFile1\ExtraDllFile2\...\ExtraDllFileX\DllFile/Class/Method/ExtraData
```

In the syntax above, “ExtraData” indicates the location of the DLL file.

| If ExtraData contains ...                 | then DataMiner will look for the DLL file ...                                |
|-------------------------------------------|------------------------------------------------------------------------------|
| ProtocolName/ProtocolName/ProtocolVersion | in the folder of the specified protocol version.                             |
| Protocol/DataMinerID/ElementID            | in the folder of the protocol version associated with the specified element. |

> [!NOTE]
> If you specify extra DLL files (see *ExtraDllFile1\\ExtraDllFile2\\...\\ExtraDllFileX* in the syntax above), these files have to be located in `C:\Skyline DataMiner\Files`.

## Examples

```txt
Dll|WFMTest/WFMTest.WFMTestLauncher/LaunchWFM/protocolname/Philips TCL/Production
```

When users click the shape, DataMiner will look for a DLL file named “WFMTest” in the folder of the production version of the Philips TCL protocol, and run the “LaunchWFM” method from the class named “WFMTest.WFMTestLauncher”.

```txt
Dll|WFMTest/WFMTest.WFMTestLauncher/LaunchWFM/protocol/6/9507
```

When users click the shape, DataMiner will look for a DLL file named “WFMTest” in the folder of the protocol version associated with element 6/9507, and run the “LaunchWFM” method from the class named “WFMTest.WFMTestLauncher”.

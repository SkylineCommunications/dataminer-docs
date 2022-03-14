---
uid: NT_VDX_CHANGE_VIEWS
---

# NT_VDX_CHANGE_VIEWS (27)

Sets a Visio file on a view.

```csharp
string[] viewIDs = new string[] { "10046" };
string vdxName = "View_10046.vsdx";

protocol.NotifyDataMiner(27/*NT_VDX_CHANGE_VIEWS*/ , viewIDs, vdxName);
```

## Parameters

- viewIDs (string[]): ID(s) of the view(s) to which the specified Visio file will be assigned to.
- vdxName (string): Name of the Visio file that will be assigned to the specified views.

## Return Value

- Does not return an object.

## Remarks

- To set the default general default Visio file, provide an empty string for vdxName.
- Visio files with the legacy ".vdx" extension were provided as a .zip file in the folder C:\Skyline DataMiner\Views. Visio files with the ".vsdx" extension no longer need to be provided as a .zip file; you can immediately provide the ".vsdx" file in the folder. However, note that in this case the extension ".vsdx" must be provided in the vdxName argument.

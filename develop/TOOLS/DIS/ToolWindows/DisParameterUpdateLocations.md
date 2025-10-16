---
uid: DisParameterUpdateLocationsToolWindow
---

# DIS Parameter Update Locations

Starting from DIS 3.1.6, you can use the *DIS Parameter Update Locations* tool window to check from which locations parameters get updated.

To do so, select *Tool Windows* > *DIS Parameter Update Locations*, and then select a parameter in the dropdown. The *Confirmed Update locations* pane will then show the locations from which this parameter gets updated.

For example, if the pane lists an Action, this means that the action, when executed, performs a set on this parameter. When a QAction is listed, it means that the QAction invokes a method (the line number is mentioned in the result window) that results in the update of the parameter.

The *Confirmed Update locations* will also mark an update location in red in case an update location is wrong, for example in case a method is called that should be executed on a table parameter but is executed on a standalone parameter.

The *Possible Update locations* gives an overview of possible locations where this parameter **might** be updated. This could for example be a QAction that contains a `protocol.SetParameter()` call, in case DIS cannot determine which parameter gets updated. This is for example the case when the ID of the parameter that is set is calculated at runtime.

To trigger a recalculation of the update locations, use the *Refresh* button above the parameter dropdown at the top of the window.

![DIS Parameter update locations tool window](~/develop/images/DisParameterUpdateLocationsToolWindow.png)

> [!TIP]
> This window can also be opened via the parameter dropdown menu in the protocol.xml.

> [!NOTE]
> The following update locations are currently not recognized by DIS:
>
> - The actions Aggregate, Merge, Normalize, ReadFile, Set, SetAndGetWithWait, SetWithWait, SwapColumn, and Wmi.
> - In SLProtocolExt, the generated parameter property setters.

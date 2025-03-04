---
uid: DisParameterUpdateLocationsToolWindow
---

# DIS Parameter Update Locations

If you click *Tool Windows > DIS Parameter Update Locations*, the *DIS Parameter Update Locations* window will appear.

This window provides a dropdown that contains the different parameters of the connector.
When selecting a parameter, in the *Confirmed Update locations* pane, the locations are shown where this parameter gets updated from.

For example, if the pane lists an Action, this means that the action, when executed, performs a set on this parameter.
When a QAction is listed, it means that the QAction invokes a method (the line number is mentioned in the result window) that results in the update of the parameter.

The *Confirmed Update locations* will also mark an update location in red in case an update location is wrong.
For example, in case a method is called that should be executed on a table parameter but is executed on a standalone parameter.

The *Possible Update locations* gives an overview of possible locations where this parameter **might** be updated.
For example, a QAction contains a `protocol.SetParameter()` call but it could not be determined which parameter gets updated. This is for example the case when the ID of the parameter that is set is calculated at runtime.

To trigger a recalculation of the update locations, press the *Refresh* button above the parameter dropdown at the top of the window.

![DIS Parameter update locations tool window](~/develop/images/DisParameterUpdateLocationsToolWindow.png)

> [!TIP]
> This window can also be opened via the parameter dropdown menu in the protocol.xml

> [!NOTE]
> The following update locations are currently not recognized by DIS:
>
> - HTTP Sessions are not yet supported.
> - Actions Aggregate, Merge, Normalize, ReadFile, Set, SetAndGetWithWait, SetWithWait, SwapColumn and Wmi
> - In SLProtocolExt, the generated parameter property setters.

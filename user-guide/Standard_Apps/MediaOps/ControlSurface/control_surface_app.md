---
uid: control_surface_app
---

# Control Surface

The dataminer.MediaOps control surfaces allow operators to perform their day-to-day activities, such as setting up connections between sources and destinations, doing configuration parameter control on devices and view monitoring information coming from the devices. The MediaOps installation package comes with an out-of-the-box example control surface with the following functionality:

* Connecting a source to a destination.
* Disconnecting a destination.
* Locking a destination. By locking a destination, users can prevent other users from making changes to the destination without explicitly unlocking the destination first.
* Smart filtering: control surface eliminates invalid connection attempts by filtering out sources & destinations that can't be connected.
* Customization made easy: users can use the sample control surface as-is, but they are encouraged to take it as a starting point and further customize it or even build their own control surface from scratch.

![screenshot](~/user-guide/images/mediaops_cs_overview.png)

## Connecting a source to a destination

When clicking the connect button, the control surface will make sure that the correct workflow is executed in the background, based on the type of the selected source and destination, to connect them. The default workflow that comes with the dataminer.MediaOps install package will send a connection request to [Flow Engineering](xref:flow_engineering_app) to connect the senders and receivers on every level that is present on both the source and the destination. If for example the selected source has a sender on levels V01 and A01, and the selected source has a receiver on levels V01, A01 and A02, the default connection workflow will connect the V01 sender to the V01 receiver and the A01 sender to the A02 receiver. The A03 receiver will not be connected to anything, as there is no sender in the source on that level. For more information on how to configure which workflow gets executed for a combination of a source and a destination, see: [Virtual signal group types & workflow mapping](xref:virtual_signal_groups_app#virtual-signal-group-types-and-workflow-mapping).

In case the destination selected by the user to be connected is already connected to another destination at the time of clicking the connect button, the system will first execute a disconnect on that destination and then connect it to the new destination. The logic executed to disconnect a destination is described below.

## Disconnecting a destination

When the user has selected at least one destination, they can click the disconnect button. In the background, the control surface will also trigger the correct 'disconnect' workflow just like for the connect. What exactly happens then depends on that workflow, for IP 2110 workflows the flows would typically be removed in order to free up bandwidth, for others, like SDI, disconnecting could mean changing the connected source to a 'park' source. The default workflow will send a 'disconnect' request to Flow Engineering for every connected receiver on the destination, letting the element(s) handle the details of what to execute for a disconnect.

## Locking a destination

Users can lock a destination to prevent other users (or themselves) from overwriting the destination's connection state. Both destinations that are connected to a source and destinations that aren't can be locked. When trying to change the connection status of a locked destination, users will get a pop-up message warning them that the destination is locked and also mentioning who locked the destination. However, unlocking the destination can be done by anyone, not only the user that locked it.

## Filtering of sources & destinations

When a source is selected on the control surface, destinations of a type that has no workflow defined to be connected to the type of the selected source will automatically be filtered out. The opposite also applies when selecting a destination. This prevents operators from trying to set up connections that are not supported by the system.

Other filtering that the control surface provides is filtering on area and domain, and on name. These filters are provided to help operators more easily find the correct source & destination in a large-scale operation.

## Changing the lay-out of the control surface

The control surface app included in the dataminer.MediaOps package is, just like the other out-of-the-box apps, built with the DataMiner Low-Code Apps framework. This allows DevOps Engineers to easily tweak the content, functionality and the look and feel of the app.

The source and destination buttons on the control surface are populated using DataMiner's Generic Query Interface (GQI). By using GQI, users can easily create queries that retrieve sources and destinations from the system using their own filtering criteria, which allows to easily build tailored panels for specific audiences or situations.

Being built with the DataMiner Low-Code Apps also easily allows users to tweak the look-and-feel of the apps. Using the 'template editor' UI, users can configure their own conditional button lay-out with specific labels, colors, icons etc. By editing the app itself, they can go even further and any other component from the Low-Code Apps component library to the control surface to visualize any data that operators need at hand.

Finally, they can go even further and also change the behavior of the control surface. The Low-Code Apps editor allows to tweak or add any button on the control surface, and plug in any DataMiner automation script.

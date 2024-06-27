---
uid: Overview_MediaOps_Control_Surface
---

# Control Surface app

The Control Surface app allows operators to perform their day-to-day activities, such as setting up connections between sources and destinations, doing configuration parameter control on devices, and viewing monitoring information coming from the devices. The MediaOps installation package<!-- TBD: add link when package is available --> comes with an out-of-the-box example control surface with the following functionality:

- [Connecting a source to a destination](#connecting-a-source-to-a-destination).

- [Disconnecting a destination](#disconnecting-a-destination).

- [Locking a destination](#locking-a-destination), to prevent other users from making changes to the destination without explicitly unlocking the destination first.

- [Smart filtering](#filtering-sources-and-destinations), i.e. the app eliminates invalid connection attempts by filtering out sources and destinations that cannot be connected.

![Control Surface UI](~/dataminer-overview/images/control_surface1.png)

## Connecting a source to a destination

When a user selects a source and destination and then clicks the connect button, the Control Surface app will make sure that the correct workflow is executed in the background to connect them, based on the type of the selected source and destination.

The default workflow that comes with the dataminer.MediaOps install package will send a connection request to Flow Engineering to connect the senders and receivers on every level that is present on both the source and the destination. If, for example, the selected source has a sender on levels V01 and A01, and the selected destination has a receiver on levels V01, A01, and A02, the default connection workflow will connect the V01 sender to the V01 receiver and the A01 sender to the A02 receiver. The A03 receiver will not be connected to anything, as there is no sender in the source on that level. For more information on how to configure which workflow gets executed for a combination of a source and a destination, see [Virtual signal group types and workflow mapping](xref:Overview_MediaOps_Virtual_Signal_Groups#virtual-signal-group-types-and-workflow-mapping).

In case the user selects a source that is already connected to another destination, when the connect button is clicked, the system will first execute a disconnect on that destination and then connect the source to the new destination.

## Disconnecting a destination

When a user has selected at least one destination, they can click the disconnect button. In the background, the Control Surface app will trigger the correct disconnect workflow, in the same way as for a connect. What exactly happens then depends on that workflow. For IP 2110 workflows, the flows will typically be removed in order to free up bandwidth. For others, e.g. SDI, disconnecting could mean changing the connected source to a "park" source. The default workflow will send a disconnect request to Flow Engineering for every connected receiver on the destination, letting the elements handle the details of what to execute for a disconnect.

## Locking a destination

Users can lock a destination to prevent anyone from overwriting the destination's connection state. This is possible both with destinations that are connected to a source and destinations that are not connected. When trying to change the connection status of a locked destination, users will get a pop-up message warning them that the destination is locked and also mentioning who locked the destination. However, anyone can unlock a destination, not only the user who locked it.

## Filtering sources and destinations

When a source is selected, the Control Surface app will automatically filter out any destinations of a type that has no workflow defined to connect it to the selected source. The same also applies when a destination is selected. This prevents operators from trying to set up connections that are not supported by the system.

The app also allows filtering on area and domain, and on name. These filters help operators find the correct source and destination more easily in a large-scale operation.

## Customizing the layout of the control surface

You can use the sample control surface as is, but you can also easily customize it further or even use it as a starting point to build your own control surface. Like the other out-of-the-box apps in the MediaOps package, this app is built using the DataMiner Low-Code Apps framework. This allows DevOps engineers to easily tweak the content, functionality, and look and feel of the app.

The source and destination buttons on the control surface are populated using DataMiner's [Generic Query Interface (GQI)](xref:About_GQI). With GQI, you can easily create queries that retrieve sources and destinations from the system using your own filtering criteria, which allows you to build tailored panels for specific audiences or situations.

Within the Low-Code Apps framework, you can use the [template editor](xref:Template_Editor) to tweak the look and feel of the app. You can for instance configure your own own conditional button layout with specific labels, colors, icons etc. You can also edit the app itself and add any other component from the Low-Code Apps component library to the control surface to visualize data operators need at hand, or you can even change the behavior of the control surface. The Low-Code Apps editor allows you to tweak or add any button in the app and plug in any DataMiner Automation script.

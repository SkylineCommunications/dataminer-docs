---
uid: MO_Control_Surface
---

# Control Surface app

The Control Surface app is a fully software-defined button panel that allows to connect or disconnect sources and destinations defined in the [Virtual Signal Groups app](xref:MO_Virtual_Signal_Groups). It allows operators to manage connections in the network without having to worry about the specifics of the underlying technology and/or devices. The control surface is synced with all scheduled connections created by [Jobs](xref:MO_Scheduling), avoiding operators to unknowingly overwrite scheduled connections, while keeping them in control to change scheduled connections ad-hoc if they really need to.

The app shows two main panels, one on the left with all sources defined in the system, and one on the right with the destinations. Once the user has correctly configured sources and destinations in the [Virtual Signal Groups app](xref:MO_Virtual_Signal_Groups), and set up the [Mediation Layer](xref:MediaOps.Live.Mediation) for the DataMiner elements associated with these sources and destinations, the Control Surface app provides the following functionality:

- [Connecting a source to 1 or multiple destinations](#connecting-a-source-to-1-or-multiple-destinations)
- [Disconnecting destinations](#disconnecting-destinations)
- [Locking & unlocking of destinations](#locking-and-unlocking-of-destinations)
- [Filtering sources & destinations](#filtering-sources-and-destinations)

## Connecting a source to 1 or multiple destinations

Connections can be created between a source and 1 or multiple destinations by selecting the source and destination(s) and clicking the 'Connect' button.

> [!TIP]
> Selecting or unselecting 1 or multiple buttons can be done by using CTRL + Click.

When the 'Connect' button is clicked, the [mediation layer](xref:MediaOps.Live.Mediation) is triggered to connect the selected source to each selected destination. When the connection is successfully made, then the destination button will reflect the connect source. An additional icon will be visible on the button in case multiple sources are connected or when certain levels are shuffled.

It's also possible to only connect a subset of a source to a destination by selecting the individual levels at the bottom of the app and clicking the 'Connect Level' button.

> [!NOTE]
> Connecting a subset of a source can only be done to a single destination, and also allows to shuffle a specific level.

## Disconnecting destinations

Disconnecting 1 or multiple destinations is done by selecting the relevant destinations and clicking the 'Disconnect' button. For disconnections, no source needs to be selected and the selected source (if any) is irrelevant.
Same as when creating connections, when the 'Disconnect' button is clicked, the [mediation layer](xref:MediaOps.Live.Mediation) is triggered to handle the disconnect.

It's also possible to only disconnect 1 or multiple specific levels of a destination by selecting the levels of the selected destination and clicking the 'Disconnect Level' button.

## Locking and unlocking of destinations

Users can lock a destination to prevent anyone from overwriting the destination's connection state. This is possible both with destinations that have an active connection and destinations that don’t. When locking a destination, the user can (optionally) provide a reason for the lock. The Control Surface app allows selecting multiple destinations and locking them all at once (with a single reason).

When a user tries to change the connection state of a locked destination, they get a pop-up message warning them that the destination is locked, who locked the destination and the reason they provided. However, anyone can unlock a locked destination, not only the user who locked it, and then proceed to change the connection state of that destination.

> [!IMPORTANT]
> Connections created from a [Job](xref:MO_Scheduling) will ignore (and overwrite) any lock present on the destination and add a reference to the job on the destination lock.

## Filtering sources and destinations

The Control Surface app provides a filter control for both the sources and the destinations using [categories](xref:MO_Virtual_Signal_Groups#categories).

When opening the Control Surface app, the filter shows the top-level categories defined for the sources and the destinations. When clicking one of the categories, the buttons on the panel will be filtered to only show sources or destinations part of that category, or any of its child categories. The filter control will now display the child categories of the first selected category, allowing the user to further refine the selection of sources or destinations they want to see. This can be used to navigate all the way down the categories tree structure. The filter control always shows the currently selected filter path. The user can at all times return to one of the higher-level categories by clicking it in the filter path. Clicking on ‘Root’ will completely reset the filter to its default state.

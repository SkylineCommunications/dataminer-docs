---
uid: SRM_1.2.12
---

# SRM 1.2.12

## New features

#### Possibility to sort resources in Booking Wizard by capacity \[ID_29107\]

The list of resources in the Booking Wizard can now be sorted according to the available capacity of each resource. To activate this feature, set the *Resources Order Rule* parameter on the *General* data page of the Booking Manager to the value *Capacity*. In addition, the property *Resource Sorting Capacity* should be defined on the service definition nodes, with the name of the capacity that should be used for sorting as its value. If this property is not defined, the first capacity will be used for sorting.

#### Generic Booking Log: Improved behavior path configuration \[ID_29313\]

When an element is created using the *Generic Bookings Log* protocol, now no path for the log files will be configured by default.

As long as this path still needs to be configured, the *Path Status* will now indicate *Needs Configuration*. New log entries will be discarded until the path is configured. When a path has been configured, the *Path Status* will indicate *Collecting*, which means that new log entries will be buffered and offloaded.

> [!NOTE]
> It is not recommended to select *Cluster Mode* for the path, as this can cause an extra load during synchronization.

#### Option to export SRM statistics \[ID_29354\]

The Booking Manager parameter *Statistics Files Status* can now be enabled in order to export statistics related to the SRM setup. This is intended for debug purposes only. This option should never be enabled in a Production environment, as it can affect the system's performance.

#### Settings on Bookings page now saved across sessions \[ID_29415\]

On the *Bookings* page of the Booking Manager app, the following settings will now be saved across sessions:

- Show/Hide Filter Pane
- Show/Hide Bookings List
- Show/Hide Contributing
- Booking State filter (checkboxes)

#### Option to disable logger element \[ID_29426\]

A new option is now available in the Booking Manager app that allows you to disable the logger element, so that no logging is generated for the app.

## Changes

### Enhancements

#### Resource export/import improvements \[ID_28899\]

The following improvements have been implemented to the export and import of resources:

- If resources based on a function with an entry point were incorrectly linked, up to now it could occur that these were not included in an export. Now they will be included but marked as invalid. Missing resources will also be exported but will not be marked as to be created. In both cases, these resources will not be added or updated during an import.

- Capacities will now be exported as numeric values.
- Numeric capability ranges will now be exported as invariant culture.
- The check for duplicate resource names during an import has been enhanced.

#### SRM_ExportFunctions and SRM_ImportFunctions updated with mediated function support \[ID_29101\]

The *SRM_ExportFunctions* and *SRM_ImportFunctions* scripts have been updated to also support mediated functions.

When you export virtual functions, you will be able to create a .dmapp package for each protocol linked to a virtual function.

When you import virtual functions:

- If the protocol linked to a virtual function does not exist yet, the virtual function and its associated components will be imported without any reference to the protocol.
- In case a virtual function already exists, the import script will add the new content to the existing virtual function and increment its version.
- If a virtual function does not exist yet in the system, it will be imported with its version set to 1.
- All associated components will also be imported, and any conflicts will be resolved.
- A protocol will also be generated for the new virtual function version.

#### Improved performance when loading SRM_CreateNewBooking \[ID_29177\]

Performance has improved when the script to create a new booking is loaded.

#### Numeric parameter value range now only checked if minimum/maximum is defined \[ID_29194\]

To avoid unnecessary exceptions, when numeric parameter values are converted, their range will now only be checked if a minimum or maximum value is defined. In addition, it is now possible to only define a maximum capacity value.

#### Improved performance when interacting with Profile Manager \[ID_29197\]

Performance has been improved when interacting with the Profile Manager. In addition, the cache mechanism implemented in the SRM framework has been improved.

#### Natural sorting in Booking Wizard drop-down boxes \[ID_29217\]

Natural sorting is now used in several drop-down boxes in the Booking Wizard (containing service definitions, profiles instances, resources, and discrete parameter values in case resource pool inheritance is used).

#### Booking Manager settings retrieved more efficiently \[ID_29273\]

To improve performance, Booking Manager settings are now retrieved more efficiently.

#### Source Resource Pool parameter removed from Booking Manager \[ID_29276\]

The *Source Resource Pool* parameter is no longer displayed in the Booking Manager, as this parameter has become obsolete.

#### Prevention of deletion contributing booking when used by another booking \[ID_29284\]

When a contributing booking is removed via the Booking Manager app, the corresponding resource will now be deleted first. If this step does not succeed, for instance because the resource is still assigned to a booking, deleting the contributing booking will fail.

#### Different resource elements for functions that have same resource assigned in booking \[ID_29430\]

Previously, when functions had the same resource assigned within a booking, the corresponding resource element would only be added in the booking service once. Now, when the node labels of the service definition are used as the element alias for the resource elements, for each function a resource element will be added in the booking service.

#### Log removal sync requests only sent in cluster mode \[ID_29474\]

When log files are removed, either manually or automatically, the cluster will now only be informed of this if *Path* is set to *Cluster*.

### Fixes

#### SRM Manager failed to load after initial loading failed \[ID_29180\]

If an SRM Manager failed to load initially, e.g. because a script timed out, any subsequent calls to the manager would also fail.

#### Problem when duplicating finished permanent booking \[ID_29220\]

If the Booking Manager app was configured to only allow the creation of permanent bookings, and a finished permanent booking was duplicated, an exception could be thrown.

#### Not possible to load Profile Load scripts with virtual resources \[ID_29254\]

When Profile Load scripts were used with virtual resources, it could occur that it was not possible to load the scripts.

#### DTR triggered twice when running script in silent mode \[ID_29300\]

When a script was run in silent mode and a value was provided to a profile instance or parameter with a data transfer rule (DTR), it could occur that the DTR was triggered twice.

#### Pre-roll/post-roll stage not correctly added during booking edit \[ID_29457\]

If a booking was edited and a pre-roll or post-roll stage was added to a booking that did not previously have this stage, it could occur that the corresponding events were not added to the booking.

#### BREAKING CHANGE: Logging of SRM Manager displayed for other bookings \[ID_29545\]

In some cases, logging of a specific SRM Manager could be displayed for bookings it was not relevant for. To prevent this, when creating SRM scripts, instead of initializing a new Logger instance, you should now use *SrmLogHandler.Create* (from *Skyline.DataMiner.Library.Solutions.SRM.Logging*) and dispose it when it is no longer used.

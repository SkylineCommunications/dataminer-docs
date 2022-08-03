---
uid: PA_1.1.2
---

# PA 1.1.2

## New features

#### New mechanism implemented in case resource DVE is stopped \[ID_28838\]

When there are tokens to process but the resource DVE is stopped and cannot execute the Profile Load script, the first token to be processed with the resource will go into the error state *Error_Process*, and the resource will be flagged as not usable.

On a regular basis, the queue will check the state of the flagged resource. If the element is active again, the flag will be removed. The default interval for this is 5 minutes, but this can be customized with the *Function Check* parameter of the *Skyline Queue Manager* driver.

Unusable resources will not be included in the list of possible resources to swap for a pool resource. The new *Resource Check* parameter of the *Skyline Queue Manager* driver allows you to determine the interval at which the driver will check if the resources can be included in the list again.

#### Skyline Queue Manager: New parameters to indicate readiness of Resource/Profile Manager \[ID_28954\]

Two new parameters were added in the Skyline Queue Manager, which indicate whether the Resource Manager and Profile Manager are ready to be used by Process Automation:

- *Queue Operational Status*: Indicates "Up" if Resource Manager and Profile Manager are ready, "Down" in case they are not, and "Admin Down" in case Admin State is "Down.
- *Queue Engine Info*: Indicates "Initializing" before checking if Resource Manager and Profile Manager are ready, "Ready" if the check reveals that they are ready and "Not Ready (retrying later)" if the check reveals that they are not. In this last case, the queue will check again every minute.

Note that the queue will accept any incoming registration or token even if the Resource Manager and Profile Manager are not ready, but refresh actions will not be possible in that case.

## Changes

### Enhancements

#### PA_TokenHandler script now passes Reservation GUID to Profile Load script \[ID_28621\]

The *PA_TokenHandler* script will now pass the Reservation GUID to the Profile Load script. This information is available in the Profile Load script in the object *InputData.Info.ReservationGuid*.

#### Skyline Queue Manager enhancements \[ID_28682\]

A number of enhancements have been implemented to the Skyline Queue Manager:

- *Total Customers* has been renamed to *Total Resources*. This parameter represents all resources from the resource pool selected with the *Resource Pool* parameter (pool resources not included).
- *Queue Fill Rate* is now initialized.
- The *Resource Pool* drop-down box now only contains resource pool names. It longer contains GUIDs.
- The *Refresh Pool Info* button will now also update the *Total Resources* parameter.

#### Reduced number of ProfileHelper calls \[ID_28699\]

Process Automation has been made more efficient through the caching of returned objects, so that fewer ProfileHelper calls are needed.

#### Number of sync messages sent by Skyline Queue Manager reduced \[ID_28747\]

To improve performance, the Skyline Queue Manager will now reduce the number of messages it sends to find other queue elements.

#### Logic to execute Profile Load script moved to Queue Manager driver \[ID_28754\]

To improve performance, the logic to execute a Profile Load script has been moved from a separate script to the Queue Manager driver.

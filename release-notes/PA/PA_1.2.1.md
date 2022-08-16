---
uid: PA_1.2.1
---

# PA 1.2.1

## New features

#### Skyline Queue Manager timers reviewed \[ID_29373\]

The timers of the *Skyline Queue Manager* protocol have been reviewed. It now has 3 timers: a fast timer that triggers every second, a medium timer that triggers every minute, and a slow timer that triggers every hour.

The forwarding of outgoing tokens now happens based on the fast timer. Processing duration, token error state, maximum empty duration and maximum activity duration happens with the medium timer.

This timer change will result in improved performance when tokens need to be processed or sent to another queue.

#### Total Resources parameter now updated based on interval of Resource Check parameter \[ID_29395\]

The interval defined for the *Resource Check* parameter (which is now a value in minutes) will now also define how often the queue will update the *Total Resources* parameter to indicate the number of resources for the registered resource pool. The default value for this interval is now 10 minutes.

## Changes

### Enhancements

#### PA_TokenHandler script no longer executed during callback operations \[ID_29268\]

The *PA_TokenHandler* script will no longer be executed during callback operations. When the method *ProcessAutomationManager.ExecuteTokenHandler* is used in a Profile Load script, the Process Automation framework will call the queue directly and perform the corresponding operation.

> [!WARNING]
> Instead of calling the *PA_TokenHandler* script, you should now always use the method mentioned above.

#### Improved pool resource swapping \[ID_29309\]

The mechanism to replace a pool resource in a booking with a regular resource has been improved.

#### SRM Setup script improvements \[ID_29404\]

When setting up pool resources, pool functions and pool elements, the SRM Setup script will now take the virtual platform into account that has been configured in the Booking Manager. In addition, it will append new functions to existing Skyline Resource Pool functions, increasing the functions file version.

### Fixes

#### Repeat gateway did not pass first token to activity immediately \[ID_28857\]

When it detected an entry in the Repeat Rules table, it could occur that the repeat gateway did not immediately pass the first token to the relevant activity, but instead waited until the first interval had passed.

#### Incorrect Queue Operational Status \[ID_29349\]

When the *Queue Admin State* was set to *Up*, it could occur that the *Queue Operational Status* was incorrectly set to *Down*.

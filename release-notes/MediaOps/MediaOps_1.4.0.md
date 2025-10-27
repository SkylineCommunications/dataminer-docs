---
uid: MediaOps_1.4.0
---

# MediaOps 1.4.0

> [!NOTE]
> This version requires DataMiner 10.5.9/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

#### Scheduling: Creating a job in the tentative state [ID 43448]

While previously new jobs were always created in the draft state, now it is also possible to create a job in the tentative state. This has the advantage that the resources are immediately assigned to the job and checked for conflicts.

#### Resource Studio: Time-dependent capabilities [ID 43606]

When you create a new capability in the Resource Studio app, you can now make it time-dependent, which means that it will only be available during a specific time frame. These time-dependent capabilities can be assigned to resources and resource pools like other capabilities.

#### Scheduling: Job can now transition to Tentative state with empty capacity or capability parameters [ID 43751]

It is now possible to transition a job to the Tentative state even if it has empty capacity or capability parameters configured.

## Changes

### Enhancements

#### Scheduling: Improved capability and capacity filtering when manipulating nodes [ID 43553]

When resources are added, picked, or swapped, the capability and capacity filters used will now take effect the moment the add, pick, or swap action is executed. In the past, configuration and node manipulations had to happen separately, which could lead to challenges when swapping resources while changing capabilities. Now it is possible to swap resources while changing the capabilities at the same time.

#### Cleanup of objects created by older MediaOps versions [ID 43566]

When a MediaOps upgrade package is installed, a number of predefined existing scripts and DOM definitions created by older versions of MediaOps will now first be cleaned up.

For each major version, this predefined list will be reset. Consequently, when you upgrade across major versions (e.g. from 1.x.x to 2.x.x), we recommend upgrading to the latest version of the current major version first before moving to the next major version, to ensure that these cleanup actions have taken place at least once.

#### Scheduling: Scheduling_CRUD_Extension script now triggered on job configuration updates [ID 43615]

The *Scheduling_CRUD_Extension* script will now also trigger for updates of the configuration of jobs. Note that this may affect existing Scheduling extension scripts.

#### Resource Studio: Improved exception messages [ID 43627]

In Resource Studio, several exception messages have been improved to be more clear to the user.

#### Resource Studio: Icon indicating whether capability is provided by resource pool [ID 43629]

In Resource Studio, an icon has been added that indicates whether a capability on a resource is provided by a resource pool.

#### Scheduling: Client time visualized on job and resource timeline [ID 43639]

Though by default the time zone of the client machine is applied in the Scheduling app, this can be customized through user settings. Therefore, to ensure that operators have good visibility on the current time used in the Scheduling application, a clock has been added to both the *Job View* and *Resource View* pages.

#### Scheduling: Sorting on Resources page now case-insensitive [ID 43721]

On the *Resources* page of the Scheduling app, sorting of resources now ignores case. This way, the order of the resources will be more intuitive, preventing situations where, for example, "Ch6" is shown before "CH1".

### Fixes

#### Resource Studio: Incorrect step size after change to number of decimals of capacity or configuration parameter of type number [ID_43580]

When capacity or configuration parameters of type number were defined, it could occur that the step size did not update after the number of decimals was changed, which could lead to unwanted behavior when the parameter was used in the Scheduler app. The UI has now been improved to prevent this: other fields that are affected by changes will now be updated or highlighted.

#### People & Organizations: Organization count included deprecated people [ID 43628]

Up to now, on the Organizations and Teams pages, the member count also included deprecated people. These are now no longer included.

#### Scheduling: Jobs visualized twice in resource view [ID 43643]

When many resources and jobs were visualized on the timeline on the Resource View page, it could occur that jobs were visualized twice.

#### GetLinks method caused exception [ID 43650]

When the GetLinks method was used, it could occur that an exception was thrown stating "an instance does not have the correct DOM Definition ID." This method has now been fixed to prevent this. This issue did not affect the out-of-the-box MediaOps Solution but could have been encountered with custom scripts.

#### Not possible to configure domain on resource pool [ID 43651]

Since MediaOps 1.3.1, it was no longer possible to configure a domain on a resource pool within the MediaOps Solution. This is now possible again for systems where domains are available in DOM. However, note that this is not currently by default supported by the MediaOps Solution. A different application must be used to create these domains.

#### Installation shown as successful despite partial failure [ID 43694]

When updates to DOM definitions failed during MediaOps installation, it could occur that the installation script incorrectly reported a successful installation, even though critical components were not fully installed. Now the installation script will correctly report a failure in case an issue occurs with any of the following calls:

- CreateDomInstance
- CreateDomDefinition
- CreateSectionDefinition
- CreateDomBehaviorDefinition

#### Confirmed jobs could have unconfigured mandatory parameters [ID 43709]

In some cases, it could occur that a job was in the Confirmed state even though mandatory parameters were not configured yet. This will now be prevented.

---
uid: SRM_1.2.3
---

# SRM 1.2.3

## New features

#### Filtering profile instances based on the capacities of the selected resource \[ID_24193\]

While up to now, it was possible to filter the available resources per node based on the currently selected profile instance in the Booking Wizard, now the opposite way of filtering can also be applied.

If a node is configured with the property *FilterProfileInstance* set to the value *Yes*, the list of available profile instances is filtered based on the capabilities of the selected resource.

#### New option to delete unlocked contributing resources \[ID_25723\]

A new option, *Delete Unlocked Contributing Resources*, is now available on the *General* data page of the Booking Manager element. This option can be used to configure whether unlocked contributing resources should automatically be deleted if specific conditions are met, so that these do not put an unnecessary load on the system. The option is by default enabled.

When the option is enabled, a contributing resource is deleted when:

- A contributing booking ends and the contributing resource is no longer used by an active booking.
- A main booking ends and the contributing booking for which the contributing resource was generated has also ended.
- A contributing booking is canceled and the resource has been removed from the main booking that made use of it.

## Changes

### Enhancements

#### Unlocked contributing booking removed when timing becomes incompatible \[ID_25730\]

When a main booking that has an unlocked contributing booking is finished before the contributing booking has started, the contributing booking is now removed from the main booking, as the timing of the main and contributing booking is no longer compatible.

#### Improved performance when updating properties during booking creation \[ID_25737\]

The way properties are updated when a new booking is created has been made more efficient, resulting in improved performance.

#### Support for multiple generic source nodes in a service definition \[ID_25858\]

It is now possible to have multiple generic source nodes in a service definition. In the Booking Wizard, the generic resource selection has been moved from the initial step to the step where resources are selected.

> [!NOTE]
>
> - Version 1.1.0.12 or higher of the *Skyline Generic Source* driver is required for this.
> - If the properties *Logo* and *Tag* are needed in the generated service, a data transfer rule must be configured to trigger the script *SRM_GenericSourceCopyLogoAndTag*.

#### Interface mapping now optional for conversion to contributing booking \[ID_25893\]

Up to now, to be able to convert a booking to a contributing booking, a mapping had to be defined between each interface of the system function and the contributing booking. In order to support more generic system functions, this is now no longer required.

However, note that not having this mapping may cause some parameters or interfaces not to be available in the generated function protocol. Note also that if two interfaces are configured with the same *ExposedParentID* property value, the conversion will not be possible.

#### Element validation in BookingManager class \[ID_25944\]

When an element is passed in the *BookingManager* class, it must now use a protocol with the name *Skyline Booking Manager*.

If a wrong element is passed in the *BookingManager* class, an exception will now be thrown. If the element does not exist, this will be an *ElementNotFoundException*. If the element does not use the correct protocol, this will be an *InvalidOperationException*.

#### DTR script now executed as soon as resource is assigned \[ID_25970\]

To prevent possible issues, data transfer rule (DTR) scripts are now executed as soon as a resource is assigned, while previously they were only triggered after all resources were assigned.

#### Naming of virtual functions for contributing bookings adjusted \[ID_26003\]

The naming of virtual functions that are created for contributing bookings has been adjusted.

Previously, the name was generated in the following format: \<service definition name>.SRMFunction\_\<service definition name>. If the service definition name was more than 20 characters long, it was cropped to 20 characters. However, this could cause issues, as the final character of the name could be a space, which is not allowed.

The naming format has now been adjusted to allow longer names and avoid trailing spaces. Now, the format \<service definition name>.SRMFunction\_\<parent system function name> will be used, and the character limit of the virtual function name has been increased to a total of 110 characters. In the unlikely case that the service definition name part of the name is longer than 92 characters, it will be cropped to 92 characters, followed by 3 random characters. Any trailing spaces will always be removed.

#### Improved performance SrmUtilities.LoadServiceDefinition method \[ID_26024\]

The performance of the *SrmUtilities.LoadServiceDefinition* method has been improved, so that service definitions should now be loaded more quickly when this method is used. Depending on the setup, this can improve booking creation time.

#### InheritScriptOutput=false flag added to methods that trigger scripts \[ID_26088\]

To avoid possible exceptions with scripts that rely on the *AddScriptOutput* method, the flag *InheritScriptOutput=false* has been added to all methods that trigger a script to run.

### Fixes

#### Enhanced service placed in incorrect view if service group was specified \[ID_25722\]

If a service group was specified in the booking wizard, it could occur that the enhanced elements and enhanced service for a contributing service were not placed in the correct view.

#### Parameter value set by data transfer rule removed when profile instance was assigned \[ID_25866\]

When a parameter value had been set for a particular node by a data transfer rule, it could occur that the parameter value was removed again when a profile instance was selected for that node that did not contain a value for the parameter.

#### Problem when importing resources \[ID_26029\]

In case the name of a worksheet in an import file contained a period ("."), a problem could occur when resources were imported

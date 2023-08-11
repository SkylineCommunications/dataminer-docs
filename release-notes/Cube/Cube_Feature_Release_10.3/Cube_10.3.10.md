---
uid: Cube_Feature_Release_10.3.10
---

# DataMiner Cube Feature Release 10.3.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.10](xref:General_Feature_Release_10.3.10).

## Highlights

*No highlights have been added to this release yet.*

## Other new features

*No other features have been added to this release yet.*

## Changes

### Enhancements

#### Trending - Pattern matching: Loading indication around light bulb icon while loading time-scoped related parameters [ID_36831]

<!-- MR 10.4.0 - FR 10.3.10 -->

When time-scoped related parameters are being loaded in a trend graph, now the light bulb icon will be shown with rotating ring dots to indicate the ongoing loading process. Previously, the light bulb was only shown when a response had been received from the server.

#### Tooltip added for 'Edit Visio drawing' user permission [ID_37095]

<!-- MR 10.4.0 - FR 10.3.10 -->

On the Users/Groups page in System Center, a tooltip has been added to the *Edit Visio drawing* user permission with the information that the *Config* right also has to be enabled for views, elements, or services for the user to be able to edit the respective assigned Visio drawing.

### Fixes

#### Visual Overview: Viewport variable also set in code when set by user [ID_37011]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a user set the *Viewport* variable on a Resource Manager timeline component in Visual Overview, DataMiner set the variable again in the code, which caused the value to change to serialized format. While this did not cause functional changes, it could potentially cause unpredictable behavior, for example in case a condition was configured based on the value of the variable. This will now be prevented.

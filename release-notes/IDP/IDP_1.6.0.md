---
uid: IDP_1.6.0
---

# IDP 1.6.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This IDP version requires that DataMiner 10.4.0 [CU0] or higher is installed.

## New features

#### Discovery and provisioning via API [ID 43704] [ID 43811]

It is now possible to perform a discovery and provisioning through a REST API. The following endpoints are available:

- `/api/custom/idp/discoveries`: Start a discovery.
- `/api/custom/idp/discoveries/status`: Check the status of a discovery.
- `/api/custom/idp/discoveries/devices`: Retrieve the devices that were discovered.
- `/api/custom/idp/provision`: Provision an element.

Note that this feature requires DataMiner 10.4.1/10.5.0 or higher.

#### Support for interactivity in custom restore scripts [ID 43920]

IDP now supports custom restore scripts with interactive UI, allowing users to provide input or control the restore as it is being executed.

Note that such scripts will need to call *IEngine.FindInteractiveClient* to make sure that their UI is shown to the user (see [Launching and attaching interactive Automation scripts](xref:Launching_and_attaching_interactive_Automation_scripts#launching-a-script-from-non-ui-contexts-scheduler-correlation-qaction-other-non-interactive-scripts)).

#### Added support for Skip SSL/TLS certificate verification in CI Types [ID 44110]

The IDP CI Type now includes a new property called `SkipCertificateVerification` to indicate whether the SSL/TLS certificate should be skipped for a specific HTTP port on the element configuration.

Currently, this property can only be configured via the CI Type JSON definition.
The IDP CI Type Management script and the IDP Visual Overview support are currently not available and will be added in a future release.

Note that this feature requires DataMiner 10.4.12/10.5.0 or higher.

## Changes

### Enhancements

#### Limit the number of authentication attempts for the IDP Configuration Management [ID 43910]

To avoid user accounts from being locked out at the Operating System level due to multiple failed authentication attempts, a failed authentication tracker has been introduced.

This tracker limits the maximum number of failed authentication attempts to 10 during a 6 minutes rolling window. After reaching this limit, further authentication attempts will be blocked for a duration of 15 minutes.

A manual attempt to login via the UI will allow 1 extra authentication attempt and clear the lockout if successful.

Rectifying the credentials in DataMiner will reset the failed authentication tracker.

#### Increased minimum DataMiner version [ID 44271]

The minimum DataMiner version for the IDP app has now been increased to DataMiner 10.4.0 [CU0].

### Fixes

#### IDP Application Visual Overview does not set the Embed Comparison URL correctly [ID 43577]

The Embed Comparison URL in the IDP Application Visual Overview is now set correctly when navigating to the overview from the `Configuration > Compare` tab.

The user will need to introduce credentials the first time they access the overview, however, subsequent accesses will be automatically logged in.

#### Improve null checks in IDP Reapply and Reassign scripts [ID 44006]

Adapted the script to log when the elements provided as input do not exist.
Improved the code to handle `null` references better and to prevent `NullReferenceException` from being thrown.
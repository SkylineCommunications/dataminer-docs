---
uid: IDP_1.6.0
---

# IDP 1.6.0

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

Note that such scripts will need to call *IEngine.FindInteractiveClient* to make sure that their UI is shown to the user (see [Launching and attaching interactive automation scripts](xref:Launching_and_attaching_interactive_Automation_scripts#launching-a-script-from-non-ui-contexts-scheduler-correlation-qaction-other-non-interactive-scripts)).

#### Support for skipping SSL/TLS certificate verification in CI Types [ID 44110]

The IDP CI Type now includes a new property, *SkipCertificateVerification*, which allows you to skip SSL/TLS certificate verification for a specific HTTP port in the element configuration.

Currently, this property can only be configured via the CI Type JSON definition. Support in the IDP CI Type Management script and the IDP Visual Overview will be added in a future release.

Note that this feature requires DataMiner 10.4.12/10.5.0 or higher.

## Changes

### Enhancements

#### Number of authentication attempts for IDP Configuration Management limited [ID 43910]

To prevent user accounts from being locked out at the operating system level because of multiple failed authentication attempts, an authentication failure tracker has been added. This tracker limits the maximum number of failed authentication attempts for IDP Configuration Management to 10 within a 6-minute rolling window. When this limit is reached, further authentication attempts are blocked for 15 minutes.

A manual login attempt via the UI allows one extra authentication attempt and clears the lockout if successful.

Updating the credentials in DataMiner resets the failed authentication tracker.

#### Alarm monitoring of availability of recent IDP configuration backup files [ID 44129]

Administrators can now monitor the availability of recent configuration backup files and have an alarm triggered if no recent backup files are found. This can be achieved by enabling monitoring of the newly added **Latest Backup** column in an alarm template and leveraging the flatline detection functionality.

> [!IMPORTANT]
> To fully leverage this feature, the DataMiner Agent needs to run DataMiner 10.7.0/10.6.2 or higher. See [Augmented Operations: Server-side support for new flatline detection modes [ID 44094]](xref:General_Feature_Release_10.6.2#augmented-operations-server-side-support-for-new-flatline-detection-modes-id-44094).

#### Increased minimum DataMiner version [ID 44271]

The minimum required DataMiner version for the IDP app is now 10.4.0 [CU0].

### Fixes

#### Incorrect URL configuration for Comparison tool in IDP visual overview [ID 43577]

The URL configured for the embedded Comparison tool on the *Configuration* > *Compare* tab of the IDP visual overview was not correct, causing users to be asked to provide credentials whenever they navigated to the tab.

Now users will only need to enter credentials the first time they access the overview; after this, they will be automatically logged in.

#### Null reference exceptions when reapplying or reassigning CI Types [ID 44006]

When input elements did not exist, reapplying or reassigning CI Types could cause null reference exceptions to be thrown.

Now the script will log when the input elements do not exist and handle null references more robustly.

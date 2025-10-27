---
uid: IDP_1.5.4
---

# IDP 1.5.4 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

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

#### Changes

*No enhancements or fixes have been added to this release yet.*

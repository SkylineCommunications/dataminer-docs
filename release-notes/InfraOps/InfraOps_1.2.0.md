---
uid: InfraOps_1.2.0
---

# InfraOps 1.2.0

## New features

#### Asset Manager: Network discovery and IDP provisioning [ID 45803]

The Network Discovery wizard now supports device discovery and direct provisioning via the IDP Provisioning API. Operators can scan an IP range, review discovered devices, and provision DataMiner elements in a single guided workflow.

A new token helper manages authentication against IDP API endpoints and will automatically attempt to install missing API definitions if they are not yet present on the DataMiner System.

The legacy *Link IPs To Assets* sub-wizard has been removed. Its functionality has now fully been integrated into the Network Discovery wizard, providing a single end-to-end discovery and onboarding flow.

#### Facility Manager: Site management [ID 45800]

Site management has now been added to the Facility Manager app. A site represents a top-level geographical or organizational location to which facilities can be linked, enabling a richer location hierarchy. Sites are visible on the map and can be created, edited, and linked to facilities through new dedicated scripts.

#### Plan and Build: Job type management [ID 45802]

It is now possible to create, edit, and delete job types in the Plan and Build application. Job types allow organizations to categorize jobs (e.g., installation, maintenance), improving filtering and workflow consistency.

## Changes

### Breaking changes

#### Shared library namespace redesign [ID 45699]

The InfraOps shared library has been redesigned with a unified namespace structure. All shared classes are now consolidated under `Skyline.DataMiner.Utils.InfraOps.Common.DOM_Classes.DOM.Applications.*`.

> [!IMPORTANT]
> Custom scripts or connectors referencing the old `InfraOpsShared.DOM_Classes.*` namespaces will need to be updated.

#### Asset Manager: Import/export migrated to Excel format [ID 45796]

Importing and exporting of assets, data ports, and power ports now happens using Excel (.xlsx) workbooks instead of CSV files. Assets, data ports, and power ports each have a dedicated worksheet within a single workbook, named *Main Asset*, *Data Ports*, and *Power Ports* respectively.

Port fields have been expanded to include port number, name, label, port type, exposure type, output type, hostname, IPv4/IPv6 address, and DNS. This provides more granular control over port configuration during import.

> [!IMPORTANT]
> Existing CSV import files are no longer compatible and must be converted to the new Excel format.

### Enhancements

#### Automatic SDM registration on installation [ID 45558]

InfraOps now automatically registers itself with the DataMiner Software-Defined Management (SDM) catalog each time the solution is installed or upgraded. A new Automation script, i.e. *InfraOps - Register Solutions*, is invoked as part of the standard installation flow and records the solution's unique catalog identifier, display name, and current version in the SDM system.

The installed version of InfraOps is reported to the SDM registry automatically upon deployment, enabling consistent version visibility and catalog management across all DataMiner environments.

No configuration changes or manual steps are required by operators. The registration runs transparently during installation using the Skyline.DataMiner.SDM.Registration.Automation library, and it correctly handles both fresh installations and upgrades by creating a new registration entry or updating an existing one.

#### Plan and Build job types removed from default data generation [ID 45698]

The *InfraOps - Generate Default Data* script no longer imports Plan and Build job types as part of the default data installation process. Previously, running this script would automatically populate Plan and Build job types alongside other default data such as cable types, port types, and device types. This step has been removed so that Plan and Build job type data is decoupled from the general default data setup.

Environments that rely on this script to generate initial data will no longer receive Plan and Build job types automatically. If Plan and Build job types are required, they must be set up separately through the dedicated Plan and Build tooling.

#### Asset Manager: Conditional ticketing integration in query filters [ID 45798]

The Asset Manager app query filters now conditionally integrate with the DataMiner Ticketing module. The *Ticket Flags* filter section will only be displayed when the Ticketing and Object Linking modules are installed, preventing errors on systems without Ticketing.

This is powered by a dynamic library loader that checks module availability at runtime. No configuration changes are required.

### Fixes

#### Asset Manager: Incorrect default date for asset class lifecycle fields [ID 45697]

Up to now, the End of Life and End of Service fields in the asset class lifecycle editor by default showed a minimum date value when no value had been previously set. These fields now correctly show the current UTC date and time by default.

#### Asset Manager: Incorrect duplicate holder detection during import [ID 45799]

When there were two distinct holders at the same slot but with different hierarchy roles, it could occur that these were incorrectly identified as duplicates during import. The holder identifier now includes the hierarchy role, ensuring each unique combination is processed correctly.

#### Asset Manager: Query filters timeout error [ID 45801]

In case the Query Filters dialog timed out or was aborted, a technical error message with a stack trace was displayed. The script now detects the abort condition and handles it gracefully, preserving previously configured filter values so the workflow that includes the dialog continues uninterrupted.

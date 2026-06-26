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

#### Asset Manager: Import/export improvements [ID 45797]

JSON-based import/export scripts have been added for assets and asset classes, providing a machine-readable alternative to the existing Excel format for integration scenarios.

The Excel export has also been improved: holders and linked elements are now written to dedicated worksheet tabs instead of inline columns on the main asset sheet, improving readability for assets with multiple holders or linked elements.

Additionally, the holder *SlotNumber* field has been renamed to *Number* across all scripts and editors.

> [!IMPORTANT]
> These improvements include breaking changes:
>
> - Existing integrations that parse the previous inline column layout must be updated to read from the new dedicated *Holders* and *Linked Elements* tabs.
> - Custom scripts referencing the *SlotNumber* field on the holder model must be updated to use *Number* instead.

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

#### Asset Manager: Primary IP columns added to import/export [ID 45804]

Two new columns are now supported in asset imports and exports: *Is Primary IPv4* and *Is Primary IPv6*. This will allow you to designate primary IP addresses directly in the file, so that manual configuration is no longer needed after the import.

The columns accept boolean values (*True*/*False*).

To ensure backwards-compatibility with existing files, the fields are left unchanged if the columns are omitted.

#### Asset Manager: DOM wrapper field handling improvements [ID 45806]

The internal field accessors on DOM wrapper classes have been changed from public to internal, reducing the public API surface and preventing unintended direct field manipulation from external code. In addition, numeric properties (e.g., *Height*, *Depth*, and *Width*) now apply consistent rounding at the property setter level to ensure uniform value handling.

#### Asset Manager: Automatic correction of duplicate port numbers [ID 45807]

A new port number migration tool has been introduced in the Asset Manager app. During installation or upgrade, this tool scans all assets and asset classes, identifies duplicate port numbers within each port category, and reassigns them to ensure uniqueness. After the migration, a summary report is generated listing the applied changes.

The migration runs as part of the Asset Manager general setup and requires no manual intervention. Existing environments are updated automatically, with all port numbers corrected to prevent conflicts.

#### Facility Manager: Improved rack capacity validation [ID 45810]

When creating or editing a rack, leaving the *Maximum Rack Capacity (U)* field empty will now result in a clear validation error indicating the required field. Previously, this triggered a generic error message.

#### Asset Manager: Improved query filter performance [ID 45811]

Query filters in the Asset Manager app now load faster. Previously, the script initialized the full ticketing library to check module availability, which increased load times. This has been replaced with a lightweight check that verifies the presence of the required DOM modules, resulting in improved performance.

### Fixes

#### Asset Manager: Incorrect default date for asset class lifecycle fields [ID 45697]

Up to now, the End of Life and End of Service fields in the asset class lifecycle editor by default showed a minimum date value when no value had been previously set. These fields now correctly show the current UTC date and time by default.

#### Asset Manager: Incorrect duplicate holder detection during import [ID 45799]

When there were two distinct holders at the same slot but with different hierarchy roles, it could occur that these were incorrectly identified as duplicates during import. The holder identifier now includes the hierarchy role, ensuring each unique combination is processed correctly.

#### Asset Manager: Query filters timeout error [ID 45801]

In case the Query Filters dialog timed out or was aborted, a technical error message with a stack trace was displayed. The script now detects the abort condition and handles it gracefully, preserving previously configured filter values so the workflow that includes the dialog continues uninterrupted.

#### Asset Manager: Incorrect rack position conflict for non-rack-consuming assets [ID 45805]

When non-rack-consuming assets (e.g., patch panels and cable management units) were imported, an incorrect rack position conflict could occur. To prevent this, the rack position validation has been adjusted to only apply to assets with the *RackUnitConsumer* device type.

#### Plan and Build: Cabling plan export failed because of incorrect file path construction [ID 45808]

When exporting cabling plans upon job completion, the process could fail because the export file path was constructed incorrectly. This resulted in failed exports.

This issue has now been resolved. The export destination and local save paths are correctly determined, ensuring cabling plans are successfully exported.

#### Asset Manager: 'In Transit' state set before destination location assignment [ID 45809]

Previously, when an asset was set to "In Transit", the state change would occur before the destination location was assigned. If the location assignment failed, the asset could end up in an inconsistent state.

Assets now transition to "In Transit" only after the destination location has been successfully assigned. This change affects the *Set Available*, *Plan*, *Build*, and *Install* actions.

#### Asset Manager: Error when assigning asset to holder if child asset information was missing [ID 45812]

Previously, assigning an asset to a holder in the edit and delete holder dialogs could result in an error when information about a related child asset was missing. This issue has now been resolved, ensuring the dialogs function correctly in all scenarios.

#### Facility Manager: Owner and team dropdowns incorrectly defaulted to first available value when unset [ID 45813]

When editing a room in the Facility Manager app, the *Owner* and *Team* dropdowns would incorrectly preselect the first available person or team when no owner or team was assigned. These fields now remain empty in such cases, accurately reflecting the room's configuration.

#### Asset Manager: Import scripts froze in silent mode when errors triggered interactive dialog [ID 45814]

Previously, when running an asset or asset class import script in silent (non-interactive) mode, the script could freeze if an error occurred, because it attempted to display an interactive error dialog. This prevented automated processes such as regression tests or scheduled runs from completing.

In silent mode, import scripts now log failed items to the script output and exit cleanly. This ensures they can be safely used in non-interactive contexts, such as regression tests or scheduled automation, without additional configuration.

#### Asset Manager: JSON import could skip assets with cross-references [ID 45815]

When importing multiple assets via JSON, some assets could be silently skipped if they referenced each other. This was caused by an inverted condition that prevented newly created assets from being recognized while the import was still in progress.

The import process now first creates all assets and then processes their updates in a second step. As a result, all assets are recognized before their relationships are applied, ensuring that cross-references are handled correctly.

#### Facility Manager: Rack usage metrics displayed negative values when data was unavailable [ID 45816]

On the Racks page in the Facility Manager app, certain rack usage metrics in the overview, such as *Power usage (%)* and *Space usage (%)*, displayed negative values when data was unavailable. These columns now show "N/A" in such cases.

#### Asset Manager: Dates could change after saving lifecycle or custody details [ID 45817]

When editing lifecycle or custody information in the Asset Manager app, dates could shift because of UTC offset handling when the asset was saved. As a result, users might see a different date than the one they originally entered.

This issue has been fixed by ensuring that all date fields are consistently handled as UTC. Date values are now correctly interpreted when read, and the date/time picker explicitly marks all dates as UTC. This improvement applies to all interactive scripts used to edit lifecycle and custody date fields.

#### Asset Manager: Incorrect default date values in lifecycle editors [ID 45818]

Previously, the *Edit Asset Lifecycle* editor used local time instead of UTC when setting default dates, such as the *First-Use* and *Modification Date* fields, which could result in incorrect date values.

Additionally, the *Edit Asset Class Lifecycle* editor initialized empty *End of Life* and *End of Service* date fields with the minimum possible date value instead of the current UTC time, resulting in unrealistic default dates.

Both issues have now been resolved.

#### Plan and Build: Duplicate asset entries [ID 45819]

Previously, it was possible to add the same asset multiple times to a job, resulting in duplicate entries in the job's asset list. This occurred because the system did not check whether an asset was already linked before adding it. Now, assets that are already linked to the job are automatically excluded when adding new ones, ensuring each asset can only be linked once.

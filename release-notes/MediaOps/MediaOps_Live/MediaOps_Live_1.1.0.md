---
uid: MediaOps_Live_1.1.0
---

# MediaOps Live 1.1.0

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

#### Control Surface: Direct access to job details [ID 45745]

A number of changes have been introduced to make it possible to see the job information associated with a destination directly from the Control Surface app, making it easier to understand what each destination is currently being used for:

- **Job details on destination tiles**: When a destination has job information available, an info icon is shown on its tile.

  ![Info icon shown on destination tile](~/release-notes/images/MediaOps_Live_Job_info_icon.png)

  Selecting the icon opens a context menu with a *Show Details* option, which opens a dialog showing the job reference, name, description, and (when configured) a link to the full job details.

  ![Context menu shown when the info icon is selected](~/release-notes/images/MediaOps_Live_Job_info_context_menu.png)

  ![Job details dialog](~/release-notes/images/MediaOps_Live_Job_details_window.png)

- **Direct access to the job details link**: From the job details dialog you can click a link to the configured job details, taking you straight to the relevant job information.

- **Configuration page in the Control Surface app**: A new Configuration page in the Control Surface app lets administrators enable the job details link and define the URL used to reach an external job system. The URL is set up as a template containing a placeholder (`[JOBREFERENCE]`), which is automatically replaced with the actual job reference when a link is opened. This means a single template works for every destination, always pointing to the correct job.

- **Automatic job information on destinations**: Job details are automatically shown on a destination while it is in use by a job, and they are cleared again once the job ends, so that the Control Surface app always reflects the current situation without any manual upkeep.

In addition, the MediaOps Live API has been extended so that job information (job reference, name, and description) can be associated with a destination and cleared again from your own orchestration setup. This is what populates the job details shown in the Control Surface app.

## Changes

### Enhancements

#### Improved visualization of pending connections [ID 45594]

While a connection or disconnection is still in progress, an hourglass icon is now shown in front of the source name. This provides clearer feedback to the user about the current connection state.

### Fixes

#### Discrete parameters with numeric values caused orchestration events to fail [ID 45773]

When discrete parameters were used with numeric values (e.g., to indicate video formats), it could occur that orchestration events failed. Now the validation correctly supports both numeric and string discrete parameters.

#### CSV import could include the wrong endpoint when source and destination endpoints had the same name [ID 45959]

When a source and destination endpoint in a virtual signal group shared the same name, a CSV import could include the wrong endpoint because matching was based on name only.

When you import a virtual signal group from CSV, endpoints will now be resolved by both role and name, preventing mismatches when source and destination endpoints share the same name.

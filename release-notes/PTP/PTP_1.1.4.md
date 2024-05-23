---
uid: PTP_1.1.4
---

# PTP 1.1.4 (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

#### New status in PTP devices overview to identify clocks syncing with local clock [ID_39724]

The *Status* column in the PTP devices overview (accessible via the table icon in the *Summary* tab) has been extended with a new option. The status will now be set to *Synced With Local Clock* when the device reports its local clock ID as the grandmaster clock ID it synchronizes with. This happens regardless of the configured role for the device and applies for grandmaster, boundary, transparent, and slave clocks.

## Changes

### Enhancements

#### Skyline PTP visual overview now delivered as protocol default [ID_39570]

The visual overviews used by the PTP application will now be delivered as protocol default Visio files instead of custom Visio files. This affects the Visio files for the *Skyline PTP* connector.

When you upgrade to this PTP version, the existing custom Visio file will stay in the system, but PTP will now use the protocol default Visio files instead. If the custom Visio file has any custom changes, you can go back to using it by [making it the active Visio file](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files). If you no longer need the custom Visio file, you can [delete it](xref:Managing_Visio_files_linked_to_protocols#removing-a-microsoft-visio-file-assigned-to-a-protocol).

### Fixes

#### SLProtocol RTEs triggered by initialization DMS Monitors on systems with high SLNet load [ID_39726]

When PTP devices begin synchronizing with a different grandmaster, the PTP app detects these changes using the DMS Monitor library. Up to now, if the DMS Monitor library was initialized on a system with a high SLNet load, it could occur that the initialization for a PTP device was not completed within one minute. The PTP app would then try to initialize the DMS Monitor library for the next PTP device, leading to SLProtocol RTEs.

To prevent these SLProtocol RTEs, if the initialization for a PTP device cannot be completed within 30 seconds, the PTP app will now no longer attempt to initialize the DMS Monitor library for the next PTP device.

In addition, the *PTP Devices* data page of the PTP app now includes two parameters to indicate the initialization state and initialization progress. In a healthy setup, *Initialization State* should indicate *Completed* and *Initialization Progress* should be at 100%. If this is not the case, you can manually trigger the initialization again by clicking the *Refresh* button on the same page. As with the previous version, the PTP app will also automatically attempt reinitialization after 30 minutes.

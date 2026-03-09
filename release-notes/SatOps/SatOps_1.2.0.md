---
uid: SatOps_1.2.0
---

# SatOps 1.2.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.1](xref:MediaOps_Plan_1.5.1) or higher.

## New features

#### New Antenna Inventory app [ID 44953]

This version of the SatOps solution introduces a new Antenna Inventory app, which allows satellite operators to model and manage their ground segment assets, including antennas, earth stations, and frequency bands, within the SatOps ecosystem.

With this initial release of this app, you can:

- Create and manage earth stations through an interactive automation script with automatic string-to-coordinates mapping for geographic positioning.
- Create and edit antennas and their properties (whether they are fixed or steerable).
- Browse and manage frequency band configurations associated with these antennas.
- Detect potential sun outage interference when setting up satellite links between antennas and geostationary satellites, with automatic warnings within the scheduled time window.

The app supports specific features concerning steerable antennas. Among others, the antenna move time between satellites is calculated and taken into account for the transition time between two bookings.

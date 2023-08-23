---
uid: EPM_1.0.4_VSAT
---

# EPM 1.0.4 VSAT - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### VSAT dashboards: Optimized default settings + improved total remote count calculation [ID_37116]

In all EPM VSAT dashboards, the default settings have been optimized:

- The default time period for all time range feeds has been set to the last 24 hours.
- All line charts now show the legend by default.
- The default line colors in line charts have been improved so that there is a more distinct color distribution for the lines.
- The min/max shading for line charts is now hidden by default.

In addition, to achieve more accurate percentages, the Carrier Performance dashboard now calculates the total remote count based on the iDirect Hub Return Carrier table instead of the Hub Return Overview table.

#### Security enhancements [ID_37133]

A number of security enhancements have been made.

### Fixes

#### Verizon ETMS Platform: Message not displayed at top Activity Log [ID_37132]

If a ticket with power issues needed additional investigation, the message "Further Investigation Required" could incorrectly appear at the bottom of its Activity Log, instead of at the top.

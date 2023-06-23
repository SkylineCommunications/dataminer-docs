---
uid: MbgNMS_1.2.1
---

# MbgNMS 1.2.1

## New features

#### Integration LANTIME M150, M250, M320, M350, and M450 [ID_36704]

MbgNMS now also supports the LANTIME M150, M250, M320, M350, and M450.

#### Firmware upgrade reflection [ID_36706]

If a device has had a firmware upgrade and MbgNMS detects that the API version now matches a different connector, from now on, the corresponding element will automatically be updated to use the correct connector.

## Changes

### Enhancements

#### Integration REST API V10 for Meinberg LANTIME IMS FDM [ID_36696]

The Meinberg LANTIME IMS FDM API V10 has been integrated into the mbgNMS solution.

#### Integration REST API V10 for Meinberg LANTIME IMS PIO [ID_36697]

The Meinberg LANTIME IMS PIO API V10 has been integrated into the mbgNMS solution.

#### Integration REST API V10 for Meinberg LANTIME IMS VSG [ID_36698]

The Meinberg LANTIME IMS VSG API V10 has been integrated into the mbgNMS solution.

#### Integration REST API V10 for Meinberg LANTIME IMS VSI [ID_36699]

The Meinberg LANTIME IMS VSI API V10 has been integrated into the mbgNMS solution.

#### Integration REST API V10 for Meinberg LANTIME IMS REL [ID_36700]

The Meinberg LANTIME IMS REL API V10 has been integrated into the mbgNMS solution.

### Fixes

#### MbgNMS Validation: Incorrect warning about missing Visio files [ID_36701]

It could occur that the MbgNMS Validation script showed incorrect warnings about the Visio files of the API V10 connectors not being available, while these were in fact available. This issue has now been resolved.

#### Maps not displayed or LANTIME devices not shown on maps [ID_36705]

In some cases it could occur that mbgNMS maps were not displayed in Visual Overview or that LANTIME devices were not shown on maps.

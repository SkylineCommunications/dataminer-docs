---
uid: EPM_6.0.0_D-DOCSIS
---

# EPM 6.0.0 D-DOCSIS

## New features

#### Ceeview Interface connector \[ID_31110\]

The Cox Ceeview Platform connector now communicates with COX's Ceeview Apigee API to fetch information on managed remote PHY devices.

## Changes

### Enhancements

#### Ping, Trace and other pop-up pages adjusted to EPM Topology Visual Overview \[ID_30955\]

The Ping, Trace and other pop-up pages have been adjusted to work with the EPM Topology Visual Overview.

#### Navigation through topology now stays within EPM environment \[ID_31107\]

When you navigate through the topology in the EPM visual overview, you will now always remain within the EPM environment instead of going to elements in the Surveyor.

#### Alarm monitoring for over-utilized DPA links \[ID_31109\]

Alarm monitoring and trending has been added for DPA links that are over-utilized in Visual Overview. In addition, N/A will now be shown if these are not applicable.

### Fixes

#### DCF link filtering not correctly creating/removing corrections \[ID_30833\]\[ID_30834\]

When DCF link filtering was used, it could occur that this did not show the right connections. The DCF logic in the Automation script for connectivity discovery and in the Cox IDP EPM Connectivity connector has now been improved to prevent this.

#### 'Connected RPDs' links updated \[ID_30954\]

The *Connected RPDs* links in the topology have been updated to lead to the Node Leaf RPD Association pages.

#### Cisco Manager CIN Platform: Missing/incomplete data in Spine Temperature table \[ID_31108\]

It could occur that data was missing or incomplete in the Spine Temperature table.

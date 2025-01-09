---
uid: MbgNMS_1.4.0
---

# MbgNMS 1.4.0

## New features

#### Meinberg LANTIME IMS-BPE API V17 integration [ID 41773]

The Meinberg LANTIME IMS-BPE API V17 connector has been integrated into the mbgNMS solution. The IMS-BPE (Basic Port Expansion) has eight different BNC and ST connection combinations, on which output signals can be configured.

#### Meinberg LANTIME IMS-LSG API V17 integration [ID 41774]

The Meinberg LANTIME IMS-LSG API V17 connector has been integrated into the mbgNMS solution. The IMS-LSG (Line Signal Generator) generates different reference signals (Clock/BITS), which are derived from the GNSS-locked master oscillator of a preconnected satellite receiver.

## Enhancements

#### Deploying Meinberg NMS package now automatically runs setup wizard [ID 41775]

The *Meinberg_SetupWizard* script will now run automatically when the Meinberg Element Manager package is deployed, while previously this script had to be executed manually by the user. The settings that were previously configured with this script can now be configured on the *Settings* page of the Meinberg Element Manager app.

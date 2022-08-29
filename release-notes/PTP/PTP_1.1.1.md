---
uid: PTP_1.1.1
---

# PTP 1.1.1

## New features

#### Help tab now displays PTP version information \[ID_28553\]

Version information for DataMiner PTP is now available on the *Help* tab of the PTP app.

## Changes

### Enhancements

#### Support for different grandmaster clock ID formats \[ID_28641\]

DataMiner PTP now supports more different PTP grandmaster clock identifier formats. An identifier can now be any string consisting of hexadecimal groups of two characters, separated by anything that is not hexadecimal, e.g. *ac:46:70:ff:fe:00:80:59* or *AC 46 70 FF FE 00 80 59* or *AC-46-70-FF-FE-00-80-59*.

### Fixes

#### Incorrect alarm state displayed in Visual Overview for Arista and Cisco drivers \[ID_28375\]

The PTP Visual Overview for Arista and Cisco drivers could display an incorrect alarm state for "Steps removed". It showed the overall alarm state instead of the parameter alarm state.

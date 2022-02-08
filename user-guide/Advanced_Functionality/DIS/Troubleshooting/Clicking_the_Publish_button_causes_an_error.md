---
uid: Clicking_the_Publish_button_causes_an_error
---

# Clicking the Publish button causes an error

## Problem

An error occurs when you click the *Publish* button in the XML editor.

## Cause

The DataMiner Agent to which DataMiner Integration Studio is connected does not have a *ClientApps.lic* file.

## Resolution

1. Send an email to dataminer.licensing@skyline.be to request a *ClientApps.lic* file.
1. When you receive a reply from Skyline with an attached *ClientApps.lic* file, do the following:

    1. Place the ClientApps.lic file in the C:\\Skyline DataMiner directory of the DataMiner Agent.
    1. Restart the DataMiner Agent.

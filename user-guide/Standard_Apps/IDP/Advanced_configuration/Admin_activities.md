---
uid: Admin_activities
---

# Activities

The *Activities* subtab of the *Admin* tab consists of the pages detailed below.

## Overview

On this page, you can enable or disable different IDP activities: discovery, provisioning, connectivity discovery, taking configuration backups, configuration updates, software updates, software compliancy and/or automatic rack assignment.

## Default Behavior

The toggle buttons on this page allow you to determine the default behavior of the activities settings.

If a toggle button is set to *Manual*, users will need to manually enable automation for the relevant activity when completeness is 100%. If a toggle button is set to *Automatic*, automation will be enabled automatically as soon as completeness is 100% for the activity.

With the buttons at the bottom of the page, you can set all activities to *Automatic* or *Manual* in one go.

> [!NOTE]
>
> - From IDP 1.2.0 onwards, these toggle buttons are by default set to *Automatic* in a new IDP installation. Upgrading to IDP 1.2.0 will also set the toggle buttons to *Automatic*.
> - Prior to DataMiner 1.1.20, the default behavior is configured on the *Admin* > *CI Types* > *Activity Management* page.

---
uid: DIS_2.48
---

# DIS 2.48

> [!IMPORTANT]
> This will be the last DIS version that supports Visual Studio 2019.
> Microsoft ended support for Visual Studio 2019 on April 9, 2024. See [Visual Studio 2019 support dates](https://learn.microsoft.com/en-us/lifecycle/products/visual-studio-2019).

## New features

### IDE

#### A message will now be shown when a connector or an automation script package is being uploaded [ID 38846]

When a connector or an automation script is being published, a message will now be shown to indicate that the package is being uploaded.

### Validator

DIS is currently using [Validator version 1.1.4](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.4).

## Changes

### Enhancements

#### DIS settings - Account: More detailed status information [ID 39419]

In the *Account* tab of the *DIS settings* window, you can now check the following statuses if something went wrong when you tried to log in to DIS.

- *Skyline API status*: Can <https://api.skyline.be> be reached?
- *Account login status*: Can you log in to <https://api.skyline.be>?
- *Account status*: Do you have a correct DIS license?

> [!NOTE]
> All occurrences of the word "license" have been replaced by either "account" or "authorization".

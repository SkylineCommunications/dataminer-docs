---
uid: DIS_2.47
---

# DIS 2.47

## New features

### IDE

#### XML editor: New 'As Development' option [ID_38033]

To the right of the *Publish* button, you can now find the *As Development* option, which will be enabled by default.

When this option is enabled, a `_DIS` suffix will be added to the connector version when performing the following actions:

- *Publish*
- *Copy Protocol to Clipboard*
- *Save Compiled Protocol As...*

#### Support for external authentication when connecting to DataMiner [ID_38479]

DIS now supports external authentication when connecting to a DataMiner System on which external authentication is configured.

Supported authentication methods:

- SAML
- RADIUS (or similar methods that use a challenge)

### Validator

#### Validator has been extracted from DIS [ID_37844] [ID_38345]

The Validator and its relevant projects have been extracted from DIS and can now be found in a separate, public GitHub repository:

<https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators>

Currently, DIS is using [Validator version 1.1.1](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.1).

## Changes

### Enhancements

#### MIB Browser: Enhanced processing of MIBs containing hyphens inside comments [ID_37962]

According to the ASN.1 specification, a comment in a MIB starts with a pair of adjacent hyphens ("--") and ends with the next pair of adjacent hyphens or at the end of the line, whichever occurs first.

However, some MIBs create comments that contain a pair of hyphens in a line of comment. In other words, they overlook the fact that a second occurrence of a pair of adjacent hyphens in a line denotes the end of a comment.

DIS will try to load a MIB module as is. When it fails to do so, it will first correct the lines that contain "--" and then try again to parse the MIB. If this second attempt also fails, this means that there is another syntax issue. In that case, the original errors will be shown (i.e. the errors thrown when parsing the original, unaltered MIB).

#### DVE validation results will be indicated clearer [ID_38582]

​When the Validator returns the result of a DVE child protocol validation, it will now add 'DVE | ' in front of the description.

### Fixes

#### Version history editor: Changes without actions to take in MajorVersion/Changes would incorrectly be duplicated [ID_38175]

When no "actions to take" were defined for a change in MajorVersion/Changes, then that change would incorrectly be duplicated each time you clicked *Apply changes*.

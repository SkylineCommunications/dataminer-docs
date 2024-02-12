---
uid: DIS_2.47
---

# DIS 2.47

## New features

### IDE

#### Add suffix when creating connector package [ID_38033]

A checkbox has been added to the right of the 'Publish' button. Upon opening a connector XML file, it will be enabled by default.

When this is checked it will add the '_DIS' suffix to the connector version when using the following actions:

- 'Publish'
- 'Copy Protocol to Clipboard'
- 'Save Compiled Protocol As...'

#### Support external authentication when connecting to DataMiner [ID_38479]

DIS now supports external authentication for DataMiner systems that support it. If external authentication is configured on the DataMiner, you can only log in via that authentication.

Supported authentication methods:

- SAML
- RADIUS (or similar methods that use a challenge)

### Validator

#### Validator extraction [ID_37844] [ID_38345]

The validator with it's relevant projects have been extracted and put in their own [repository](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators). This repository is publicly available and open to contributions.

Current version of the validator in use within DIS: [v1.1.1](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.1)

## Changes

### Enhancements

#### Clearer indication of DVE validation results [ID_38582]

​When the validator returns a result from a DVE child protocol, it will add 'DVE | ' in front of the description. This makes it clearer for users if they don't have the 'DVE' column visible.

### Fixes

#### MIB Browser: Support hyphens inside comment [ID_37962]

According to the ASN.1 specification, a comment in a MIB starts with a pair of adjacent hyphens ("--") and end with the next pair of adjacent hyphens or at the end of the line, whichever occurs first.

Some MIBs creates comments that contain a pair of hyphens in a line of comment (i.e. they overlook the fact that a second occurrence of a pair of adjacent hypens in a line denotes the end of a comment), DIS has been updated with a fallback mechanism:

DIS will try to load a MIB module as is. When that fails, a fallback is tried where the MIB is parsed after some preprocessing has been performed. If it still fails, this means another syntax issue is present and the original errors are shown (i.e. the errors from parsing the originial unaltered MIB).

#### Version History Editor: Fixed duplication on MajorVersion/Changes [ID_38175]

If there were no 'Actions to take' defined for a change in MajorVersion/Changes, then it would be duplicated each time the 'Apply Changes' button was pressed. This has been changed to ignore the missing 'Actions to take'.

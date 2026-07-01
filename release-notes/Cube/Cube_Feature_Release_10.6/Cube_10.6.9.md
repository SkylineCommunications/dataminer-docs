---
uid: Cube_Feature_Release_10.6.9
---

# DataMiner Cube Feature Release 10.6.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU6].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.9](xref:General_Feature_Release_10.6.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.9](xref:Web_apps_Feature_Release_10.6.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Cube sidebar: New 'Report an issue' command added to 'Community' menu [ID 45741]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When, in the sidebar, you click the *Community* button, a menu will open. This menu now also includes a command that will allow you to [report an issue](https://aka.dataminer.services/ReportAnIssue).

## Changes

### Enhancements






#### Credential library: Token credential and credential library enhancements [ID 45670]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the credential library, you can now add token credentials, i.e., credentials that consist only of a single token.

Also, 



Foreach credential a limit of the length of the fieds has been added. All fields must be smaller than 5012 bytes. In case a field is longer the credential can not be saved.

The following fields can now be left empty:

* Community credential : * Get community string
                                     * Set community string

* Token credential : * Authentication password

* SNMPv3 credential : * Authentication password
                                 * Encryption password

* Username and password credential : * password

As the loading of the credentials can take a bit longer, a loading overlay is shown when the credential library is initialized.

Only 5000 credentials can be created. Once we reache this limit the user will no longer be able to create a new credential. A warning will be shown that the limit has been reached.






### Fixes

#### Problem when logging out right after having logged in [ID 45756] [ID 45761]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When you logged out of DataMiner Cube immediately after you had logged in, in some cases, an exception could be thrown related to either the Alarm Console light bulb feature or the Correlation feature.

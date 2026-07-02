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

#### System Center - User-Defined APIs: Viewing and configuring rate limits for API tokens [ID 45751]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the *User-Defined APIs* section of *System Center*, you can now view and configure rate limits for user-defined API tokens.

When creating or editing a token, you can configure the following settings:

- *Limit*: Maximum number of requests allowed within the configured window (from 1 to 100).
- *Window*: Sliding time window during which the limit applies (from 1 second to 1 day).

New tokens will be created with a default rate limit of 60 requests per minute.

The *Tokens* table includes a *Rate limit* column, showing the configured rate limit for each token.

> [!NOTE]
>
> - A configured rate limit restricts the number of requests a client can make within a specified time window. However, it does not guarantee that the server can process all requests up to that limit. Actual throughput depends on several factors, including the execution time of the API script, the number of concurrently active tokens, and overall server load.
> - This feature will only work when DataMiner Cube is connected to a DataMiner Agent running Main Release version 10.7.0, Feature Release 10.6.7, or above.

## Changes

### Enhancements

#### Credential library: Token credentials added and credential library enhancements [ID 45670]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the credential library, you can now add token credentials, i.e., credentials that consist only of a single token.

Also, all credential fields now have a maximum length of 5012 bytes, and the following fields can be left empty:

| Type of credential | Field |
|---|---|
| Community credential | Get community string<br>Set community string |
| SNMPv3 credential    | Authentication password<br>Encryption password |
| Token credential     | Authentication password |
| Username and password credential | Password |

> [!NOTE]
> The credential library can contain a maximum of 5000 credentials. When this limit is reached, users who want to add a new credential will receive a warning.

### Fixes

#### Visual Overview - Spectrum analysis component: 'ShowRibbon' option no longer worked [ID 45725]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When a spectrum analysis component was configured with `ShowRibbon=true` or `ShowRibbon=false`, in some cases, the setting was not applied correctly.

Now, the `ShowRibbon` option works again, so you can use it to show or hide the ribbon.

> [!NOTE]
> In existing shapes, this option cannot be toggled on the fly.

#### Problem when logging out right after having logged in [ID 45756] [ID 45761]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When you logged out of DataMiner Cube immediately after you had logged in, in some cases, an exception could be thrown related to either the Alarm Console light bulb feature or the Correlation feature.

---
uid: General_Main_Release_10.4.0_CU1
---

# General Main Release 10.4.0 CU1 - Preview

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: New prerequisite will check whether ASP.NET 8.0 Hosting Bundle is installed [ID_37969]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you upgrade a DataMiner System, a new prerequisite will now block the upgrade when the server does not have [Microsoft ASP.NET 8.0 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer) installed.

#### Service & Resource Management: Booking name validation now case-insensitive [ID_38556]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

The validation of the name of a booking is now case-insensitive. This means that when the SRM Framework checks if there are future bookings with the same name, the casing is now no longer taken into account.

### Fixes

#### Problem with database offload mechanism [ID_38542]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

In some cases, the database offload mechanism could end up in an unrecoverable state due to a threading issue.

#### SLAnalytics - Pattern matching: A match of one subpattern would incorrectly be considered a match of the entire multivariate pattern [ID_38587]

<!-- MR 10.4.0 [CU1] - FR 10.4.3 -->

When the streaming method was being used, a match detected for one subpattern of a multivariate pattern would incorrectly be considered a match of that entire multivariate pattern.

Although the suggestion events were generated correctly, the pattern matches would not be indicated correctly on the trend graphs.

#### SLAnalytics - Automatic incident tracking: Problem when updating alarm groups [ID_38629]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Each time the focus score of an alarm is updated, incident tracking has to update its alarm groups. In some cases, incident tracking would incorrectly update its groups twice, causing the groups to be set to an undefined state.

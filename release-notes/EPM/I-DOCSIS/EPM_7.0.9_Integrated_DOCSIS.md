---
uid: EPM_7.0.9_Integrated_DOCSIS
---

# EPM 7.0.9 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### New downstream dashboard for fiber node utilization reporting [ID 40110]

A new dashboard has been implemented to generate a report containing the fiber node name, the maximum utilization of SC-QAM channels within a specific time range, the maximum utilization of OFDM channels within a specific time range, and the number of CMs belonging to that fiber node. Each column in the dashboard can be filtered using a query filter. The time range for the dashboard can be specified with a time range selector.

The dashboard uses an ad hoc data source script, which in turn executes another script that obtains files provided by Data Aggregator.

#### New  CISCO CBR-8 CCAP UTSC connector [ID 42045]

A new connector, *CISCO CBR-8 CCAP UTSC*, is now available, which makes it possible to monitor the spectrum traces for the CISCO CBR-8. This makes use of the native feature of the CBR-8 to offload files to SFTP server. The new connector allows the user to configure and request the offload of the spectrum files, and it will ingest those files and display the spectrum trace data in the Spectrum Analysis UI.

#### New spectrum monitoring elements provisioning script [ID 42366]

A new script, *EPM_I_DOCSIS_AddSpectrumCcap*, is available, which streamlines the provisioning of spectrum monitoring elements for CCAP elements.

The script allows users to define SNMP community strings and specify provisioning locations either by selecting a specific view or distributing elements across DMAs. It ensures automated naming by appending "_utsc" to the original CCAP element name.

The script includes validation checks to prevent errors, ensuring accurate and efficient deployment of spectrum analyzer elements.

## Changes

### Enhancements

#### US FN Peak Utilization dashboard [ID 42143]

In the US FN Peak Utilization dashboard, when there is no OFDMA channel (OFDMA column = N/A) and the column SC-QAM 65-204 Peak Utilization is set to 0%, then the result in the column OFDMA + Low Split SC-QAM Peak will now be set to N/A instead of 0%. The execution time of calculations in the background for this has also been improved.

### Fixes

#### Huawei MA5800-MA5633: Various fixes [ID 39872]

In some cases, the Huawei MA5800-MA5633 connector could throw the exception "System.OverflowException: Arithmetic operation resulted in an overflow". This issue has been resolved. In addition, a fix has been implemented to handle incorrect keys being used in a dictionary. Also, when an error occurs involving the local storage path, additional information is now available in the logging, including instructions on how to resolve the issue if an incorrect path has been specified.

#### CISCO CBR-8 CCAP Platform: various issues fixed [ID 42211]

In the CISCO CBR-8 CCAP Platform, several fixes have been implemented in the Modules Overview table:

- Not initialized values will now be shown as "N/A".
- The calculation of the values in the Bandwidth and Utilization columns has been corrected.
- Modules and interfaces are now correctly linked.

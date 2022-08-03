---
uid: EPM_6.1.3_I-DOCSIS
---

# EPM 6.1.3 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### Multi-threaded timer polling rate adjusted \[ID_33570\]

To improve performance, the multi-threaded timer polling rate has been adjusted for the CCAPs and CM collectors. This will also prevent possible run-time errors.

#### Downstream QAM Channel Post-FEC Uncorrectable Error Ratio parameter adjusted \[ID_33572\]

The step size of the Downstream QAM Channel Post-FEC Uncorrectable Error Ratio parameter has been adjusted. In addition, the parameter no longer uses decimals.

#### Upstream QAM Channel Post-FEC Uncorrectable Error Ratio parameter adjusted \[ID_33574\]

The step size of the Upstream QAM Channel Post-FEC Uncorrectable Error Ratio parameter has been adjusted. In addition, the parameter no longer uses decimals.

#### Upstream/Downstream QAM Channel SNR limits adjusted \[ID_33687\]

The threshold limits of the Upstream/Downstream QAM Channel SNR setting have been adjusted to a minimum of 10.0 dB and a maximum of 60.0 dB.

### Fixes

#### Various issues in Generic DOCSIS CM Collector connector \[ID_33425\]

The following issues have been resolved in the Generic DOCSIS CM Collector connector:

- In the CM QAM DS and US Channels tables, it could occur that columns remained empty because they were not initialized when the tables were filled in.
- It could occur that DOCSIS 2.0 cable modems had empty Tx power values, because the values were not being calculated.

In addition, the polling rate of multi-threaded timers has been adjusted.

#### Large difference between SNR and MER in CCAP table \[ID_33568\]

In some cases, it could occur that there was a large difference (over 30 dB) between the SNR and MER in the CM QAM US channels CCAP table.

#### US QAM CH Time Offset calculated incorrectly \[ID_33569\]

The US QAM CH Time Offset could display incorrect values. The calculation of this parameter has now been adjusted for all CCAPs.

#### Linecard and Modules Overview tables not showing the correct information \[ID_33598\]

It could occur that the Linecard and Modules Overview tables did not show the correct information. The issue with the Modules Overview table was fixed by processing the data that goes in the table right after this data was polled. This in turn fixes the issue in the Linecard table.

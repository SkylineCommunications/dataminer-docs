---
uid: EPM_7.0.5_I-DOCSIS
---

# EPM 7.0.5 I-DOCSIS

## New features

#### New dashboards for fiber node utilization reporting [ID 40111]

New dashboards have been implemented to generate a report for both the upstream and downstream peak channel utilization for the fiber nodes over a large period of time.

The **Upstream** dashboard shows the fiber node name, the maximum utilization of SC-QAM of the low channels, the maximum utilization of SC-QAM  of the high channels, the maximum utilization of OFDM channels, and the number of CMs belonging to that fiber node.

The **Downstream** dashboard shows the fiber node name, the maximum utilization of SC-QAM channels within a specific time range, the maximum utilization of OFDM channels within a specific time range, and the number of CMs belonging to that fiber node.

You can filter each column using a query filter located on the left side of the dashboard, and you can select the desired time range for the dashboard in the top-left corner.

These dashboards use an ad hoc data source script, which in turn executes another script that obtains the files provided by Data Aggregator.

## Changes

### Enhancements

#### Add_New_CCAP_Pair script now only shows DMAs with back-end element for selection as CCAP element host [ID 40025]

When a single CCAP pair is added using the *Add_New_CCAP_Pair* script, only DMAs where back-end elements are running will now be shown as possible hosts for the CCAP element, since this is a requirement in the EPM I-DOCSIS architecture.

#### Improved back end CCAP cleanup [ID 40026]

The back-end elements will now wait for 24 hours before they begin to perform their daily CCAP registration cleanup.

#### Generic DOCSIS CM Collector: Enhanced debug logging [ID 40137]

In the Generic DOCSIS CM Collector connector, logging of QAction 1700 will now also include the number of rows that are to be deleted.

### Fixes

#### Service group visuals not loading [ID 40160]

Some service group names had trailing spaces, which caused parsing issues that could keep visuals from loading correctly. These trailing spaces have been removed.

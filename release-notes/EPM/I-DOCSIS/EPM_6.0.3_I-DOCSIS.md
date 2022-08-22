---
uid: EPM_6.0.3_I-DOCSIS
---

# EPM 6.0.3 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### DOCSIS and GPON configuration files separated \[ID_32087\]

The configuration files of the DOCSIS and GPON technologies have been separated so that the EPM front end can now ingest them independently.

### Fixes

#### DS Power status aggregated based on incorrect column \[ID_32086\]

The DS Power status was aggregated based on the wrong column. It was based on the US Tx Power column (which used to be the DS Power column) instead of the new DS RX Power column in the CM Overview table.

#### Incorrect Reflection Distance calculation \[ID_32088\]

In some cases, the Reflection Distance calculation in the CM overview table could be incorrect.

#### Incorrect KPI calculation at service group level \[ID_32089\]

At service group level, it could occur that the % CM Group Delay OOS, % CM Reflection OOS, % CM Group Delay and Reflection OOS KPIs were not calculated correctly.

#### Run-time errors caused by Arris E6000 CCAP Platform elements \[ID_32090\]

In some cases, elements using the Arris E6000 CCAP Platform connector could cause run-time errors.

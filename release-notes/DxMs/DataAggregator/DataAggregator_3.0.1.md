---
uid: DataAggregator_3.0.1
---

# Data Aggregator 3.0.1

## New features

#### Include bs4 Python library with DataAggregator installer [ID_38654]

The installer has been extended to include the bs4 pip package (and its dependencies) by default in the DataAggregator installer.

## Changes

### Enhancements

#### Improve DataAggregator Migrator [ID_38682]

Improvements have been made to the [migrator tool](xref:Data_Aggregator_Migrator) to better allow converting GQI queries from the [previous syntax to the new one](xref:Data_Aggregator_settings#gqi-queries).

This includes:
- Extra information added to the Help command (_-h_ or _--help_)
- Change how the [DataAPI soft launch](xref:Overview_of_Soft_Launch_Options#dataapi) verification is applied in order to facilitate the migration process for users yet using it.
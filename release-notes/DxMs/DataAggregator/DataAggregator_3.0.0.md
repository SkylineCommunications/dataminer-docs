---
uid: DataAggregator_3.0.0
---

# Data Aggregator 3.0.0

## Highlights

#### Support for Data Sources and integration with DataAPI [ID_38307] [ID_38404] [ID_38234] [ID_38496] [ID_38560]

Data Aggregator has been extended with support for [Data Sources](xref:Data_Sources) and Scripted connectors.
This module offers an easy solution to access data from diverse sources and swiftly integrate new products with DataMiner.

This feature is behind the [DataAPI soft launch](xref:Overview_of_Soft_Launch_Options#dataapi) option and will display an alphabetically sorted list of your Data Sources.

## New Features

#### Include Python environment with Data Aggregator installer [ID_38064]

Python environment and libraries come with Data Aggregator's installer so no need to configure that after installation.
Making it possible to start using the feature out of the box.

In addition, several Python libraries come pre-installed but more can be installed following [these steps](xref:Data_Sources_Setup#installing-extra-python-packages).

#### Enforce authentication when accessing Data Aggregator DxM web interface via reverse proxy [ID_38275]

To ensure better security, access to Data Aggregator's web interface now requires the user to authenticate itself.

#### API Gateway module registration [ID_38570]

Data Aggregator will now register itself with API Gateway allowing for an overview of all node instances.

## Changes

### Enhancements

#### Extend Data Aggregator to have a CRUD API for Data Sources [ID_37309]

Data Aggregator API has been extended from the ability control the Jobs flow (start, stop and check status) to a full CRUD.
This has been done for both Jobs and Data Sources, allowing for configuration with less manual steps.

#### Allow Data Aggregator to run Python and PowerShell scripts [ID_37272]

Previously Data Aggregator could only run GQI queries, but this has now been extended to support Python and PowerShell as well.
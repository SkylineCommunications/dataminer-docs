---
uid: VSAT_deployment
---

# EPM VSAT deployment

## Overview
This document outlines the procedure for deploying the DataMiner EPM VSAT package in an empty DataMiner system. It provides step-by-step guidance for configuring VSAT collectors, EPM setup, and peripheral integrations to ensure a fully operational VSAT management system.
For more information about DataMiner EPM VSAT click here.

## Package Deployment
Before configuring collector elements, deploy the DataMiner EPM VSAT package to the system. This will install the necessary protocols, automation scripts and visio needed to create and configure the DataMiner EPM VSAT solution.
The package can be found here.

## Collectors Configuration
### iDirect Evolution Collector
1. Initial Setup 
- Create an element using the "iDirect Evolution Platform VSAT" protocol.
2.	Configuration Setup
- Database Configuration: Fill in the Database Configuration table.
- DB Polling Config: Adjust polling parameters as necessary.
3.	Collector Setup
- File Import: Enable "File import" and “File Export” if CMDB (Customer Data) is available.
- ID Import/Export: Enable this feature and specify the paths to the CA and CR folder.
- System Credentials: Enter the system credentials.
- Entity Removal File Path: Specify the path for the entity removal file.
4.	Custom Properties
- Right-click on the element and add the NETWORK custom property.

### Newtec Dialog Collectors
1.	Initial Setup:
- Elements Creation: Use the "Newtec Dialog Platform VSAT" protocol to create these collectors.
- HTTP Connections: Input the same HTTPS URL for all three required HTTP connections during the element creation.
2. Configuration Setup:
- User Authentication: Input usernames and passwords.
3.	Polling Configuration:
- TSDB Polling Status: Enable TSDB polling status, adjust TSDB parameters as needed, and click on "Auto Configure."
- Adjust Polling Parameters: Modify polling parameters as required.
4.	Collector Setup: Follow the same steps as outlined in the iDirect Evolution collectors section.
5.	Custom Properties: Right-click on the element and add the NETWORK custom property.

### EPM Configuration
#### Front End and Back End Setup
1.	Element Creation: Use the "Skyline EPM Platform VSAT GEO" protocol for creating FE and BE elements.
2.	Element IDs: Note all IDs of collectors, FE, and BE elements in the format "DMAID/ElementID" for use in configuration tables.
3. Configuration Methods
   ##### Visual Overview (Visio UI):
   Automatically assigned with the package installation.
   Access and configure through the Surveyor in the Cube by selecting FE or BE and navigating to the configuration page under "Visual".
   ##### Monitoring Web Application (Web UI):
   Navigate to the root URL of your DMS, select the elements, and access the configuration pages directly.
4.	FE Configuration
Role: Set the Role parameter to "Frontend".
System Credentials and File Handling: Configure system credentials and EPM file paths.
Backup and Tables: Configure backup settings and populate tables with collector and backend IDs.
5.	BE Configuration
Role: Set the Role parameter to "Backend".
File Handling: EPM file paths must point to the FE server.
Collectors Table: Include only local collector IDs.
Additional Recommendations
- Enable Debug Parameter: Activate debugging for all elements (collectors, FE, BE) to assist in troubleshooting and ensure efficient system communication.
- The collectors and the EPM elements may need to be restarted after the initial configuration to start working properly

### Peripheral Configuration
The DataMiner EPM VSAT package includes optional protocols that can be installed upon customer request. These peripherals enhance the system's functionality by integrating additional external data sources and tools.
#### Skyline Universal Weather
- Description: This protocol provides weather data integration into the DataMiner system.
- API Key Requirement: An API key for the OpenWeather REST API is necessary to create the weather element and retrieve weather data.
#### Generic Sun Outage
- Description: This protocol calculates and forecasts sun interference for satellite communications.
- Setup: Simply create an element using the Generic Sun Outage protocol if sun outage predictions are required for the system.
#### DataMiner Planned Maintenance Tool
- While not included in the DataMiner EPM VSAT package, the DataMiner Planned Maintenance Tool is often installed alongside the EPM system to enhance operational maintenance capabilities.
- Package Information: For more details please refer to  https://docs.dataminer.services/user-guide/Standard_Apps/Monitoring_Solutions/PLM_Tool/DataMiner_PLM_Tool_Overview.html
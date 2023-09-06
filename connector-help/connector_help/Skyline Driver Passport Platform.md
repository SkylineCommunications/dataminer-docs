---
uid: Connector_help_Skyline_Driver_Passport_Platform
---

# Skyline Driver Passport Platform

The Skyline Driver Passport Platform allows you to schedule remote installations of a DMAPP and will measure the performance impact.

You can define and create any test. The only requirement is that the test should be included in a DMT and the intent should be to obtain performance KPIs from that test.

The primary goal of the platform is to obtain performance scaling results for a connector and performance indicators for a DataMiner Solution in an automated flow.

The information can for example be used to have an educated estimation of how many elements using a specific connector can run on a DMA, to know what the performance impact is of a connector, to detect anomalies and to take action if needed to improve a connector.

You can configure and schedule remote installations of a DataMiner Package on the platform (with and without simulation), and results will automatically be stored in Test Management Platform TestLink.

The Skyline Driver Passport Platform uses:

- A **Skyline Driver Passport Health Check** element to obtain CPU and memory values and to detect leaks on the remote DMA.
- The **Skyline Device Simulator** to simulate behavior of real devices.
- A **Microsoft Platform** element to verify the needed resources to be able to run a simulation.
- **TestLink** to store the results on.
- A **Custom Reporter Template** to generate PDF files with trend graphs.

## About

### Version Info

| **Range**            | **Key Features**                                                | **Based on** | **System Impact**                                                                                                                                                                      |
|----------------------|-----------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                | \-           | \-                                                                                                                                                                                     |
| 1.0.1.x \[SLC Main\] | Improved scheduling functionality.Supports dynamic simulations. | 1.0.0.9      | Tables Tests (PID 2000) and Simulations (PID 2200) were removed. Check for references to these parameters in the DMS (Visio drawings, Automation scripts, DMS filters, reports, etc.). |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When the element has been created, extra configuration is required on the **Configuration** page and its subpages, as detailed below.

#### General configuration

- **Stabilization Period**: It will take some time before all parameters are filled in when test elements are created. This parameter defines after how long the test setup will be considered stable.
- **Leak Detector Element**: link to the element of the **Skyline Driver Passport Health Check** driver.

#### Test DMA

The Configuration - DMA page contains parameters that need to be configured to establish a connection with the remote test DMA and retrieve KPIs from the DMA.

- **DMA IP** contains the host name.
- **DMA Credentials** need to be specified for the application to properly upload a test and retrieve results.

#### TestLink

The Configuration-TestLink page contains parameters that need to be configured to upload test results to the TestLink test management platform.

- **TestLink URL:** https://serverHostName/testlink/lib/api/xmlrpc/v1/xmlrpc.php
- **TestLink Project**: The name under which test results will be stored.
- **TestLink API Key**: The key used to upload results to the TestLink management system. This key can be found in TestLink under Test Project Management - Project Name.

#### Device Simulator

The Configuration-QA Simulator page contains parameters that need to be configured to correctly start a simulation using the Skyline Device Simulator.

- **Simulator Path**: The path to the device simulator executable.
- **Simulations Folder**: The folder on the DMA where device simulations can be stored.
- **Max simulations per Instance**: The maximum number of simulations for each test.
- **Simulator Device Address**: The address that test elements can communicate with.
- **Simulator SNMPv3**: Credentials that will be used in case of SNMPv3 simulations.
- When scaling tests are executed, after running the first test, the system will check the configured **Simulator Microsoft Platform Element** and extrapolate the memory usage for the number of running elements for the next test(s). If that memory usage exceeds the allowed **Total Simulation Memory Limit**, the number of created elements in the next test(s) will be limited to make sure the simulator does not take up all resources and cause issues.

#### Simulation Database

The Configuration-Sim. Database page contains parameters that need to be configured to store the dynamic simulations in the database.

- The credentials to connect to the MySQL simulation database need to be configured,
- The **Database Upload Location** defines the folder where the simulation file to be uploaded is stored. This is because the MySQL database could be using the secure-file-priv option. That means that inserting data from a file is only allowed from a specific folder, so this parameter specifies which folder this is. To figure out this location, execute the MySQL query *show variables like "secure_file_priv"*.

#### Reporter

The Configuration-Reporter page contains parameters that need to be configured to connect to the Reporter module. These are the credentials to log in to the DataMiner Agent itself. If the Driver Passport Platform element detects that there are processes that have a leak, the trend graphs are requested, and this is then attached as a PDF file to the TestLink result. The custom reporter template is used to be able to generate this PDF file.

- The credentials to connect to the MySQL simulation database need to be configured.
- The **Database Upload Location** defines the folder where the simulation file to be uploaded is stored. This is because the MySQL database could be using the secure-file-priv option. That means that inserting data from a file is only allowed from a specific folder, so this parameter specifies which folder this is. To figure out this location, execute the MySQL query *show variables like "secure_file_priv".*

#### Network

The Configuration-Network page credential parameters that need to be configured to connect to the shared folder containing the simulation files.

## How to use

### Creating a new test

To configure a test:

1.  Upload the .dmt package to the **Packages** documents folder.
2.  Go to the **Controller** page and select the package via **New Test Package**.
3.  Click the **Schedule** button.

The test will then be added to the **Queue** table to be executed.

### Overview

The Tests page contains the **Running Tests** table that are currently being executed and the **Tests Results** table with previously executed tests, containing the link to the TestLink report.

### TestLink Report

Once a test has run its course, a test plan will automatically be created by the Skyline Driver Passport Platform using the defined test name in the defined test project.

For each test plan build, test cases are inserted corresponding to each DMAPP used for this test.

#### Test Case - Execution Steps

Below you can find an overview of all execution steps that are executed by the generated TestLink test plan.

| **Execution Step**       | **Category** | **KPI**                                                                                                                                                                    |
|--------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1\. CPU Info             | Server       | Processor Load Average                                                                                                                                                     |
| 2\. CPU Info (SL)        | DMA          | Processor Load Average                                                                                                                                                     |
| 3\. Average Info         | DMA          | Process Average CPU Info                                                                                                                                                   |
| 3\. Average Info         | DMA          | Process Average VM Size                                                                                                                                                    |
| 3\. Average Info         | DMA          | Process Average Threads                                                                                                                                                    |
| 3\. Average Info         | DMA          | Process Average Handles                                                                                                                                                    |
| 3\. Average Info         | DMA          | Process Average IO Data Rate                                                                                                                                               |
| 3\. Average Info         | DMA          | Process Average IO Other Rate                                                                                                                                              |
| 3\. Average Info         | DMA          | Process Average IO Read Rate                                                                                                                                               |
| 3\. Average Info         | DMA          | Process Average IO Write Rate                                                                                                                                              |
| 4.Max Info               | DMA          | Process Max CPU Info                                                                                                                                                       |
| 4.Max Info               | DMA          | Process Max VM Size                                                                                                                                                        |
| 4.Max Info               | DMA          | Process Max Threads                                                                                                                                                        |
| 4.Max Info               | DMA          | Process Max Handles                                                                                                                                                        |
| 4.Max Info               | DMA          | Process Max IO Data Rate                                                                                                                                                   |
| 4.Max Info               | DMA          | Process Max IO Other Rate                                                                                                                                                  |
| 4.Max Info               | DMA          | Process Max IO Read Rate                                                                                                                                                   |
| 4.Max Info               | DMA          | Process Max IO Write Rate                                                                                                                                                  |
| 4.Max Info               | DMA          | Process Max IO Data Bytes                                                                                                                                                  |
| 4.Max Info               | DMA          | Process Max IO Other Bytes                                                                                                                                                 |
| 4.Max Info               | DMA          | Process Max IO read Bytes                                                                                                                                                  |
| 4.Max Info               | DMA          | Process Max IO Write Bytes                                                                                                                                                 |
| 5\. Processor Cores Info | Server       | Cores CPU                                                                                                                                                                  |
| 6\. Disk Busy Time       | Server       | Disk Busy Time                                                                                                                                                             |
| 6\. Disk Latency         | Server       | Disk Latency                                                                                                                                                               |
| 7\. Leak                 | Server       | Memory Leak                                                                                                                                                                |
| 7\. Leak                 | Server       | Handle Leak                                                                                                                                                                |
| 7\. Leak                 | Server       | Threads Leak                                                                                                                                                               |
| 7\. Leak                 | Server       | CPU Leak                                                                                                                                                                   |
| 8\. Alarms               | DMA          | Contains alarms that were created during the execution of the test on DMA level, such as RTEs, notices, etc. This will not contain alarms created by monitored parameters. |
| 9\. Errors In Protocol   | DMA          | Contains generated errors in the log file.                                                                                                                                 |
| 10\. Database Size       | DMA          | Gives an overview of all tables in the database and what the number of rows and occupied size is.                                                                          |

#### Test Case - Execution Notes

The following information is included in the execution notes:

- Test Name
- Test Start DateTime
- Test End DateTime
- Package Name
- Elements Count
- Server Name
- Server Model
- Operating System
- Operating System Architecture
- Passmark Rating
- CPU Mark Rating
- Disk Mark Rating
- CPU Type
- Amount of Cores
- Total Physical Memory
- Total Virtual Memory
- DataMiner Version
- Database Type

### Package Structure

A test .dmt package consists of a *config.xml* file and one or more *.dmapp* packages.

#### Config.xml

The config.xml file defines which .dmapp packages should be executed and which simulations need to be started.

The structure of the config.xml looks like this:

\<?xml version="1.0" encoding="utf-8"?\>\<ConfigurationFile xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"\> \<Name\>driver_name\</Name\> \<Version\>driver_version\</Version\> \<Notification\>example@skyline.be\</Notification\> \<SimulationFilesInfo\> \<!-- for every connection that the element has, there needs to be a SimulationFileInfo item present that points to where the simulations can be found --\> \<SimulationFileInfo\> \<LinkedDatabaseDataFile\>shared_location_to_dynamic_simulation_file\Connection_0.txt\</LinkedDatabaseDataFile\> \<ConnectionNumber\>0\</ConnectionNumber\> \<Name\>shared_location_to_static_simulation_file\Connection_0.xml\</Name\> \<DatabaseName\>name_of_the_simulation_database\</DatabaseName\> \<Type\>SnmpV2\</Type\> \</SimulationFileInfo\> \</SimulationFilesInfo\> \<Tests\> \<!-- for every test that needs to be executed there needs to be a Test item present that points to the .dmapp package; it defines which simulations need to be started and for how long the test should be executed --\> \<Test\> \<Package\>GeneratedDPP_1.dmapp\</Package\> \<Simulator\> \<SNMP\> \<Simulation\> \<Name\>Connection_0.xml\</Name\> \<Port\>50000\</Port\> \</Simulation\> \</SNMP\> \</Simulator\> \<Time\> \<Duration\>90000\</Duration\> \<Interval\>600\</Interval\> \</Time\> \</Test\> \<Test\> \<Package\>GeneratedDPP_2.dmapp\</Package\> \<Simulator\> \<SNMP\> \<Simulation\> \<Name\>Connection_0.xml\</Name\> \<Port\>50000\</Port\> \</Simulation\> \<Simulation\> \<Name\>Connection_0.xml\</Name\> \<Port\>50001\</Port\> \</Simulation\> \</SNMP\> \</Simulator\> \<Time\> \<Duration\>90000\</Duration\> \<Interval\>600\</Interval\> \</Time\> \</Test\> \</Tests\>\</ConfigurationFile\>

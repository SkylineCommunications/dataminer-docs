---
uid: Deploying_and_Configuring_the_PA_Framework
---

# Deploying and Configuring the PA Framework

## Checking and installing the prerequisites

Before you start to work on the PA development and deployment, make sure your DataMiner platform has the necessary resources and specifications for a smooth execution of SRM workflows, as SRM is an essential prerequisite for the PA Framework. You can find the expected requirements on the [DataMiner Compute Requirements page](https://community.dataminer.services/dataminer-compute-requirements/).

Your DataMiner System will also need to use an [Elasticsearch database](xref:Elasticsearch_database).

For more information on how to install Elasticsearch on your DMA, click [here](xref:Installing_Elasticsearch_via_DataMiner).

## Enabling DOM

To make sure DOM data are available in dashboards and applications, make sure the [DOMManager soft-launch option](xref:SoftLaunchOptions#dommanager) is enabled.

## Installing the SRM framework

Process Automation requires the creation of a [booking manager element](xref:SolSRM) named *Process Automation instances*, configured with the *Process Automation virtual platform*. To allow us to create this element, we first need to install the SRM framework on the DataMiner System.

<!-- Comment: More info on how to make this booking manager element and configure it? -->

> [!NOTE]
> In case SRM is already installed on your system, the procedure below is not required to proceed.

To install the SRM Framework:

1. Ensure that a DataMiner version is installed that is compatible with the SRM Framework, and the platform meets the hardware requirements.

   - Make sure the DataMiner System uses an Elasticsearch database.

   - Check the SRM release notes to see which minimum DataMiner version is required.

   - Contact Skyline Communications to check if any additional components need to be installed in your system.

1. Download the latest SRM package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Double-click the SRM package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

## Installing the process automation framework

To install the PA Framework:

1. Ensure that a DataMiner version is installed that is compatible with the PA Framework, and the platform meets the hardware requirements.

   - Make sure the DataMiner System uses an Elasticsearch database.

   - Check the Process Automation release notes to see which minimum DataMiner version is required.

   - Contact Skyline Communications to check if any additional components need to be installed in your system.

1. Download the latest PA package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

<!-- Comment: If ZIP, mention in help that you need to unzip first before installing. -->

1. Double-click the PA package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

## Configuring the PA framework

To set up the initial configuration of the PA Framework go to *Automation* and run the *SRM_Setup* Automation script that can be found in the *PA* subfolder in the *automation scripts* tab and eponymous folder.

To do so, double-click *SRM_Setup* and then select *Execute*.

This script requires one input argument, *Booking Manager Element Info*. For this input argument, specify the value "{}". Click *Execute now*.

![SRM Setup](~/user-guide/images/SRM_setup.png)

> [!NOTE]
> If the script execution fails, wait a few minutes and try again. If the problem persists, contact Skyline Communications.

The script will configure the framework and create all relevant components to get started with the development of a process.

## Upgrading the PA framework

If you already have an existing version of the PA Framework installed, update it to the latest version available on DataMiner Dojo.

1. If you upgraded from a PA Framework version older than 1.3.0 (the current officially supported minimum version) to version 1.3.0 or later, run the *PA_MigratePoolsAndQueues* script.

   > [!TIP]
   > See also: [Running Automation scripts](xref:Running_Automation_scripts)

   > [!WARNING]
   > It is essential you run this script first before moving on to the next steps.

   Also make sure that the files *ProcessAutomation.dll* and *SLSRMLibrary.dll* cannot be found in the following location of the Skyline DataMiner folder: `c:\Skyline DataMiner\Files\DLLImport\` and `c:\Skyline DataMiner\ProtocolScripts\DLLImport\`.

    If these files *are* present, delete them and restart the DMAs involved.

1. Check the Process Automation release notes to see which minimum DataMiner version is required.

1. Download the latest PA package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Double-click the PA package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

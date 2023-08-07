---
uid: Deploying_and_Configuring_the_PA_Framework
---

# Deploying and configuring the PA framework

## Checking and installing the prerequisites

Before you move on to the PA development and deployment, make sure your DataMiner platform has the necessary resources and specifications for a smooth execution of SRM workflows, as SRM is an essential prerequisite for the PA framework. You can find the expected requirements on the [DataMiner Compute Requirements page](xref:DataMiner_Compute_Requirements).

Your DataMiner System will also need to use an [Elasticsearch database](xref:Elasticsearch_database).

> [!TIP]
> For more information on how to install Elasticsearch on your DMA, click [here](xref:Installing_Elasticsearch_via_DataMiner).

## Making DOM data available

To make sure DOM data are available, make sure the [DOMManager soft-launch option](xref:Overview_of_Soft_Launch_Options#dommanager) is enabled.

## Installing the SRM framework

Process Automation requires the creation of a [Booking Manager element](xref:Booking_Manager_user_interface) named *Process Automation instances*, configured with the *Process Automation* virtual platform. To allow us to create this element, we first need to install the SRM framework on the DataMiner System.

> [!NOTE]
> In case SRM is already installed on your system, the procedure below is not required to proceed.

To install the SRM framework:

1. Ensure that a DataMiner version is installed that is compatible with the SRM framework, and the platform meets the hardware requirements.

   - Make sure the DataMiner System uses an Elasticsearch database.

   - Check the SRM release notes to see which minimum DataMiner version is required.

   - Contact Skyline Communications to check if any additional components need to be installed in your system.

1. Download the latest SRM package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Double-click the SRM package, and install the package in the same manner as a DataMiner upgrade.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

## Installing the Process Automation framework

To install the PA framework:

1. Ensure that a DataMiner version is installed that is compatible with the PA framework, and the platform meets the hardware requirements.

   - Make sure the DataMiner System uses an Elasticsearch database.

   - Check the Process Automation release notes to see which minimum DataMiner version is required and make sure this version is installed.

   - Contact Skyline Communications to check if any additional components need to be installed in your system.

1. Contact Skyline Communications to receive the latest PA package.

1. Double-click the PA package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

## Upgrading the PA framework

1. If you upgraded from a PA framework version older than 1.3.0 (the current officially supported minimum version) to version 1.3.0 or later, run the *PA_MigratePoolsAndQueues* script.

   > [!WARNING]
   > It is essential that you run this script first before moving on to the next steps.

   > [!TIP]
   > See also: [Running Automation scripts](xref:Running_Automation_scripts)

   Also make sure that the files *ProcessAutomation.dll* and *SLSRMLibrary.dll* are not present in the following subfolders of the Skyline DataMiner folder: `C:\Skyline DataMiner\Files\DLLImport\` and `C:\Skyline DataMiner\ProtocolScripts\DLLImport\`.

   If these files *are* present, delete them, and restart the DMAs involved.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

## Configuring the PA framework

To set up the initial configuration of the PA framework or to upgrade to a more recent version of the PA framework:

1. Go to *Automation* module in DataMiner Cube and select the *SRM_Setup* Automation script.

1. In the lower right corner, select *Execute*.

1. In the *Booking Manager Element Info* box, specify the value `{}`.

1. Click *Execute now*.

![SRM Setup](~/user-guide/images/SRM_setup.png)

> [!NOTE]
> If the script execution fails, wait a few minutes and try again. If the problem persists, contact Skyline Communications.

The script will configure the framework and create all relevant components to get started with the development of a process.

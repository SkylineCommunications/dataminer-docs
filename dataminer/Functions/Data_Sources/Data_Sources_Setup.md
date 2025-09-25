---
uid: Data_Sources_Setup
---

# Getting started with the Data Sources module

## Prerequisites

- A DataMiner Agent that has been [configured to use HTTPS connections](xref:Setting_up_HTTPS_on_a_DMA).

- DataMiner version 10.4.0/10.4.2 or higher.

- Depending on your DataMiner version, you may need to enable the [*DataAPI* soft-launch option](xref:Overview_of_Soft_Launch_Options#dataapi).

  > [!NOTE]
  > To check whether this soft-launch option is required in your DataMiner version, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

## Installing the necessary DxMs

The [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) and [DataAggregator](xref:Data_Aggregator_DxM) DxMs must be deployed on the same DMA. From DataMiner 10.5.11/10.6.0 onwards<!-- RN 43677 -->, *DataAPI* is automatically installed, so only *DataAggregator* still needs to be added manually.

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *DxMs* page.

1. Locate the node (i.e. the DMA) you want to install the DxMs on.

   - If your system uses a DataMiner version prior to 10.5.11/10.6.0, next to the *DataAPI* module, click *Deploy* to start the automatic installation process.

   - Next to the *DataAggregator* module, click *Deploy* to start the automatic installation process.

     > [!NOTE]
     > If the *DataAggregator* module is installed on your DMA already, click *Upgrade*.

## Installing extra Python packages

When you install the *DataAggregator* module, Python 3.12.0 is automatically installed as well. You can find the dedicated *Python* folder at `C:\Program Files\Skyline Communications\DataMiner DataAggregator\python`.<!-- RN 38064 -->

The `Scripts` folder contains `pip.exe`, which can be used to install Python packages. Installed packages are added to the `Lib\site-packages` folder.

In the event that a scripted connector requires additional Python packages, you can install these using `pip.exe`:

Execute the following command from the command line (when in the Python folder):

```bat
 .\Scripts\pip.exe install <packageName>
```

In the above command, replace `<packageName>` with the name of the desired package. For example, `.\Scripts\pip.exe install html5lib` to install the [html5lib](https://pypi.org/project/html5lib/) package.

> [!NOTE]
> Make sure you run the command-line tool as an administrator.

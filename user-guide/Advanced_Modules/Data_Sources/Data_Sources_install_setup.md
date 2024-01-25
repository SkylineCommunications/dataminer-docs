---
uid: Data_Sources_install_setup
---

# Installation and Setup

## Installation

### Prerequisites

To use the Scripted Connectors, ensure that you're running either DataMiner main release 10.4 or DataMiner feature release 10.4.2 (or later).

### Activate soft-launch option

Activate the soft-launch [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) by following the procedures in [Activating Soft Launch Options](xref:Activating_Soft_Launch_Options). This requires a DataMiner restart.

### Installing necessary DxMs

The Data API & Data Aggregator DxM need to be deployed on the same DMA.

1. Open the dataminer.services Admin app. See [Accessing the Admin app](xref:Accessing_the_Admin_app).
1. In the Admin app, check whether the correct organization is mentioned in the header bar.
1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.
1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.
1. If necessary, scroll to find the node (the DMA) you want to install the DxMs on.
   1. Next to *Data API*, click Deploy to install this DxM.
   1. Next to *DataMiner DataAggregator*, click Deploy to install this DxM. When the *DataMiner DataAggregator* has already been installed, Upgrade the DataMiner DataAggregator to version xxx or higher.

## Setup

### Installing extra Python packages

The DataAggregator installer installs Python 3.12.0 in the `C:\Program Files\Skyline Communications\DataMiner DataAggregator\python` folder.
The `Scripts` folder contains `pip.exe`, which can be used install Python packages. When installing a package, the package will get added to the `Lib\site-packages` folder.

To install a Python package using pip, you can use the following command from the command line (when in the Python folder):

```bat
 .\Scripts\pip.exe install <packageName>
```

In the above, \<packageName\> is the name of the package (e.g; `.\Scripts\pip.exe install html5lib` to install the [html5lib](https://pypi.org/project/html5lib/) package).

> [!NOTE]
> The cmd window needs to be run with administrator privileges.

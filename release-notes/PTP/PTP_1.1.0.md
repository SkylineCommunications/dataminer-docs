---
uid: PTP_1.1.0
---

# PTP 1.1.0

## New features

#### Redesign of PTP app visual overview \[ID_26179\]\[ID_27433\]\[ID_27560\]\[ID_27607\]

The visual overview of the PTP app has been redesigned to be more user-friendly while continuing to visualize everything that is needed to effectively manage the PTP system.

The tab structure of the app has been adjusted. There are now only five main tabs: *Summary*, *Nodes*, *Topology*, *Admin* and *Help*.

- On the *Summary* tab, you can find similar information as before, but presented in a more user-friendly manner.
- The *Nodes* tab now consists of several subtabs: a *Summary* subtab listing all nodes with alarm information, and a subtab for each type of device, allowing you to compare devices of the same type.
- The *Topology* and *Admin* tabs remain largely unchanged.
- On the *Help* tab, you can find links to the DataMiner PTP section of the DataMiner Help and to a page with more information about PTP in general.

In several locations, tooltips have been added or improved.

The setup wizard has also been updated so that you can hide the new tab pages in the PTP app if you want to.

#### Support for setups without slave devices \[ID_26191\]

The DataMiner PTP app now supports setups without slave devices.

#### Unicode support \[ID_27514\]

The DataMiner PTP app now has Unicode support.

This is a breaking change. Existing deployments can be migrated to this version of PTP with the following steps:

1. Before you upgrade, in the existing PTP app:

    - On the *Admin* tab, run the *Role Assignment Wizard* and accept all existing role assignments.
    - Go to the *DATA* > *Configuration* page (you may first need to select *Show card side panel* in the hamburger menu of the card), and copy the value of the parameter *ExternalRequests* to a separate file in order to retrieve it later.
    - On the *DATA* > *PTP Devices* page, export the *PTP Devices* table to a CSV file. Make sure columns are separated using commas (“,”), not semicolons (“;”).

2. Delete the DataMiner PTP element.

3. Deploy the new .dmapp package in your DataMiner System. DataMiner will need to restart.

4. Create a new element with the name “DataMiner PTP” using the production version (1.0.1.1) of the protocol *Skyline PTP*.

5. In the new PTP app:

    - On the *DATA* > *Configuration* page, paste the value of the parameter *ExternalRequests* which you copied earlier.
    - On the *Admin* tab of the app, click the *Initial Setup* button to run the setup wizard.

6. Run the *Import_PTP_Device_Positions* script to update the positions of the PTP devices. To do so:

    - Move the CSV export you made of the *PTP Devices* table to a location in the DMA file system, then fill in the path to this file in the script parameter *CSV File Path*.
    - Fill in the *DataMiner ID* and *Element ID* script parameters with the relevant information for the *DataMiner PTP* element created in step 4.

## Changes

### Enhancements

#### PTP setup wizard updated to match new PTP app design \[ID_27753\]

The PTP setup wizard has been updated to reflect the new design of the PTP app.

#### Cisco Nexus and Arista Manager visual overviews updated \[ID_27748\]

The visual overviews for the Cisco Nexus and Arista Manager drivers were updated to be in line with the new style of the DataMiner PTP app.

### Fixes

#### Incorrect parameters displayed for Profile and PTP Time \[ID_27340\]

On the *Analyzer* tab page of the PTP app, incorrect parameters were displayed for the *Profile* and *PTP Time*.

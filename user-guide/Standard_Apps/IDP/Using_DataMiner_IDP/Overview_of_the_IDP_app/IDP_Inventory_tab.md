---
uid: IDP_Inventory_tab
---

# Inventory tab

This tab consists of several subtabs, as detailed below.

## Managed

This tab displays an overview of the elements managed by DataMiner IDP.

At the top of the overview, you can find the following buttons:

- **Open**: Navigates to the card of the selected managed element.

- **Remove**: Allows you to remove a selected managed element, if a *CI Removal Script* has been configured on the *Admin* > *Settings* page.

- **Reapply**: Allows you to apply a CI Type again, for example to revert the element to its original configuration in case changes were made or to make the element reflect an update to the CI Type. Clicking the button will open a wizard where you can select which parts of the CI Type should be reapplied. The *Show details* button in this wizard will show an overview of what all selected replacements look like and what the end result will be.

- **Reassign**: Allows you to reassign the CI Type of the element, for example in case previously one generic CI Type was used for a family of devices but now more specific CI Types are available. Clicking the button opens a wizard where you can select the new CI Type and then select which parts of the CI Type should be applied. The *Show details* button in this wizard will show an overview of what all selected replacements look like and what the end result will be.

## Unmanaged

This tab displays an overview of the elements available in the system but not yet managed by DataMiner IDP. The information in this tab is particularly useful if IDP is deployed in an existing DMS, or in the rare case that managed elements cannot be discovered or imported, but need to be manually created.

At the top of the overview, you can find the following buttons:

- **Refresh**: Refreshes the displayed data.

- **Manage**: If the detected IP address and CI Type are filled in for an element in the overview, click this button to add the element to the managed elements.

## Discovered

This tab allows you to start a device discovery and manage the discovered elements. It consists of the following sections:

- **Actions**: Allows you to start a discovery action. You can either select a scan range and click the *Discover* button on the right, or click the *Discover* page button to start a custom discovery. The section also contains the following options:

  - *Identify Unknown devices*: Disable this option if you do not want devices to be displayed if no matching CI Type is found.

  - *Identify All Matching CI Types*: Enable this option if you want the discovery process to try to match all possible CI Types configured in the scan range. Otherwise, the process will stop trying to match a device with other CI Types once a CI Type has been identified for it.

  > [!NOTE]
  >
  > - It is only possible to complete a discovery action for a specific CI Type if the *Discovery* activity setting is enabled on the tab *Processes* > *Activities*.
  > - When a discovery has been initiated, the *Provisioning Status* column in the table will display the status *Provisioning Started*. As long as this status is displayed, you will not be able to start another provisioning activity for the same device.

- **Most recent discoveries**: Displays information on the 6 most recent discovery operations.

- **Discovered elements**: Lists all discovered elements with detailed information, including the provisioning status. The buttons above the table allow you to show the responses returned by the selected device during discovery, provision the element or remove the device from the list. The toggle button on the right determines if all discovered elements are displayed, or only managed elements.

  > [!NOTE]
  > Depending on the *Discovery Results to Show* setting, either all discoveries are shown in the *Discovered Elements* table, or only the most recent discoveries. This setting can be found on the *Settings* data page of the IDP app. To access this page, click the hamburger button in the top-left corner, select *Show card side* *panel* and then go to *DATA* > *Settings*.

## Deleted

This tab displays an overview of the elements that have been deleted from the DMS. At the top of the overview, you can find three buttons:

- *Provision*: Recreates the selected deleted element(s).

- *Clean*: Removes the selected element(s) from the *Deleted Elements* table.

- *Clean All*: Removes all entries from the *Deleted Elements* table.

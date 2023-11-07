---
uid: EPM_1.0.5_VSAT
---

# EPM 1.0.5 VSAT

## New features

#### Intelsat Flex Platform VSAT added [ID_37326]

The EPM VSAT Solution now includes the Intelsat Flex Platform VSAT connector, which is a virtual connector designed to streamline the presentation of critical data sourced from Intelsat terminals.

## Changes

### Enhancements

#### New Expiration Date column in PLM Overview table [ID_37327]

<!-- See fixes for other part of RN -->

A new *Expiration Date* column has been added to the PLM Overview table. This will allow users to easily see when recurrent PLM activities are set to expire.

#### Verizon WM DCAT improvements [ID_37330]

The Verizon WM DCAT connector has been adjusted so that DCAT KPIs are now based on trend data if possible. If it is not possible to retrieve the data from trending, the connector will try to retrieve it from the relevant table. Performance of the connector has also been improved. In addition, parameters have been added to control multiple message sizes.

#### Contact and Phone for infrastructure tickets changed [ID_37342]

The Verizon WM Ticketing connector has been updated so that the Contact and Phone for infrastructure tickets are now set to "VSATNMC" and "None", respectively, instead of "N/A".

#### Email for infrastructure tickets changed [ID_37343]

The Verizon WM Ticketing connector has been updated so that the Email for infrastructure tickets is now set to "None" instead of "N/A".

#### New file read/write logic to prevent file access conflicts [ID_37387]

The file read/write logic of the EPM VSAT solution has been updated to use filestream. This will prevent possible file access conflicts when files are used by multiple elements.

### Fixes

#### Generic Trap Processor: Security issue related to BinaryFormatter [ID_37310]

A security issue related to the use of the BinaryFormatter type has been addressed in the *Generic Trap Processor* connector.

#### PLM date stuck in the past [ID_37327]

<!-- See enhancements for other part of RN -->

When an element was stopped, and a recurrent PLM activity was missed, it could occur that the system failed to calculate the next run date, causing the PLM date to become stuck in the past.

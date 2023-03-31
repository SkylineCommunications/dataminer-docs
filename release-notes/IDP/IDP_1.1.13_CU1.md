---
uid: IDP_1.1.13_CU1
---

# IDP 1.1.13 CU1

## Enhancements

#### Last Provisioning Time column now displays local time \[ID_29686\]

To improve consistency, the *Last Provisioning Time* column in the *Discovered Elements* table (available in the IDP app via *Inventory* > *Discovered*), now displays the local time of the server, just like other columns of the app that show a date and time. Previously, it showed the UTC time.

#### Improved import UI \[ID_29701\]

The UI of the IDP app has been made more consistent with respect to the import of CI types and discovery profiles. In addition, when you import all CI types, you will now see similar feedback as when you import discovery profiles or a single CI type.

## Fixes

#### Selecting DMA for provisioning not possible for previously deleted element \[ID_29687\]

In the IDP app, in the *Discovered Elements* table on the *Inventory* > *Discovered* tab, it is possible to select the DMA on which an element has to be provisioned. When you do so, the app checks if the element has been provisioned already, and if it has, it warns the user that the DMA cannot be selected. However, it could occur that IDP incorrectly assumed that an element had been provisioned, because it checked the *Last Provisioning Time* column for this, which is not cleared when an element is deleted. Now the *Element ID* column will be checked instead.

#### Rack Layout Manager: Latitude and longitude not loaded correctly \[ID_29709\]

In some cases, it could occur that latitude and longitude values in the Rack Layout Manager could not be loaded correctly from the view properties.

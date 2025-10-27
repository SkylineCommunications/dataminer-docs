---
uid: I-DOCSIS_Delete_CCAP_CM_pair
---

# Deleting a CCAP/CM pair manually

To delete a CCAP/CM pair manually:

1. In the Cube Surveyor, locate the CCAP element to be removed.

1. Right-click the element, and select *Edit*.

1. Note down the ID of the element (indicated in green below) and the DMA name (indicated in yellow below).

   ![Element editor](~/dataminer/images/Delete_propertiesOfElement.png)

1. In the Surveyor, select the *EPM BE* view.

   ![EPM BE view](~/dataminer/images/Delete_BEFind.png)

1. On the view card, navigate to *Below this view* > *Elements*.

1. Use the filter box above the elements table to search for the DMA name you noted down earlier (indicated in yellow below).

   ![Find BE element host](~/dataminer/images/Delete_SearchHost.png)

1. Right-click the first row, and select *Open in new card*.

1. On the newly opened element card, click the *CCAP Collectors* tab.

1. In the table, look up the element ID you noted down earlier (indicated in green below), and click *Delete*.

   ![Delete BE registration](~/dataminer/images/Delete_BEDeleteRegistration.png)

1. In the Surveyor, select the *EPM FE* element

1. On the element card, go to *Configuration* > *CCAP Collectors*.

1. In the table, look up the element ID you noted down earlier (indicated in green below), and click *Delete*.

   ![Delete FE registration](~/dataminer/images/Delete_FEDeleteRegistration.png)

1. In the Surveyor, right-click the element you want to remove, and select *Delete*.

   This should be the same element as in step 1.

1. Locate the associated collector element.

   This element has the same name as the CCAP element, but with the `_COLLECTOR` suffix. It should be right below the deleted element. If it is not there, search for it manually.

1. Right-click the collector element, and select *Delete*.

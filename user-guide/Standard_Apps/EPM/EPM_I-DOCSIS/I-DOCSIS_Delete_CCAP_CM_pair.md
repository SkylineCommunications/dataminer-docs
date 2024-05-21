---
uid: I-DOCSIS_Delete_CCAP_CM_pair
---

# Deleting a CCAP/CM pair manually

To delete a CCAP/CM pair manually, follow these steps:

1. In Cube's Surveyor, locate the CCAP element to be removed.

1. Right-click the element, and click *Edit*.

1. Note the ID of the element (in green) and the DMA name (in yellow).

   ![Element Properties](~/user-guide/images/Delete_propertiesOfElement.png)

1. In the Surveyor, click *EPM BE*.

   ![Find BE View](~/user-guide/images/Delete_BEFind.png)

1. Look for the elements table on the card side panel, and click it. In the table, search for the DMA name (in yellow) noted in the previous step.

   ![Find BE element host](~/user-guide/images/Delete_SearchHost.png)

1. Right-click the first row, and click *Open in New Card*.

1. In the newly opened element, click the *CCAP Collectors* tab, find the element ID (in green) noted earlier in the table, and click *Delete*.

   ![Delete BE Registration](~/user-guide/images/Delete_BEDeleteRegistration.png)

1. Go to the *EPM FE* element, and click the *Configuration* tab. Then, in the *CCAP Collectors* tab, find the element ID (in green) noted earlier in the table, and click *Delete*.

   ![Delete FE Registration](~/user-guide/images/Delete_FEDeleteRegistration.png)

1. In Cube, return to the Surveyor, locate the element to be removed, right-click it again, and click *Delete*. It is the same element from step 1.

1. Locate the associated Collector element, which has the same name as the CCAP but with the _COLLECTOR suffix. It should be right below the deleted element. If it is not under the element, search for it manually.

1. Right-click the Collector element, and click *Delete*.

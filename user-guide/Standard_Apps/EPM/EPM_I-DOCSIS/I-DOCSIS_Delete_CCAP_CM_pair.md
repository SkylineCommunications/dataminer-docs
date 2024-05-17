---
uid: I-DOCSIS_Delete_CCAP_CM_pair
---

# Deleting a CCAP/CM Pair Manually

To delete a CCAP/CM pair manually, follow these steps:

1. In the Surveyor inside Cube, locate the element to be removed.

1. Right-click the element and select *Edit*.

1. Note the ID of the element (in green) and the DMA name (in yellow).

![Element Properties](~/user-guide/images/Delete_propertiesOfElement.png)

4. In the Surveyor, click *EPM BE* and in the left panel, look for the elements row,

![Find BE View](~/user-guide/images/Delete_BEFind.png)

5. Look for the elements row,  click it and  in the table search for the DMA name (in yellow) noted in the previous step.

![Find BE element host](~/user-guide/images/Delete_SearchHost.png)

6. Right-click the first row and select *Open in New Card*.

7. In the newly opened element, click the *CCAP Collectors* tab, find the element ID (in green) noted earlier in the table, and click delete.

![Delete BE Registration](~/user-guide/images/Delete_BEDeleteRegistration.png)

8. Go to the *EPM FE* element, click the *Configuration* tab, then the *CCAP Collectors* tab, find the element ID (in green) noted earlier in the table, and click delete.

![Delete FE Registration](~/user-guide/images/Delete_FEDeleteRegistration.png)

9. Return to the Surveyor inside Cube, locate the element to be removed, right-click it again, and select delete.

10. Locate the associated Collector element, which has the same name as the CCAP but with the _COLLECTOR suffix. If it is not under the element, search for it manually.

11. Right-click the Collector element and select *Delete*.
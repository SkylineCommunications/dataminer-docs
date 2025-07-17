---
uid: PLM_Records
---

# Planned Maintenance records

A PLM item can have 5 different statuses:

| Status | Description |
|--|--|
| Scheduled | One-time activities that were created but have not occurred yet. |
| Completed | One-time PLM activities that have been completed. |
| Active | Recurrent PLM activities currently in progress within the specified range of recurrence. |
| Inactive | Recurrent PLM activities not currently active within the specified range of recurrence. |
| Expired | Recurrent PLM activities with a current date outside the range of recurrence. |

When a one-time PLM activity transitions from the *Active* status to *Completed*, or a recurrent PLM activity transitions from *Active* to *Inactive*, a new PLM record is automatically generated in the *PLM Records* table.

This dedicated table acts as a repository, storing information and providing a comprehensive historical record of completed or inactive maintenance events. This functionality ensures that each significant status change is accurately recorded and tracked within the PLM system.

![Planned Maintenance records](~/dataminer/images/Planned_Maintenance_Records.png)

---
uid: Checking_the_current_state_of_a_redundancy_group
---

# Checking the current state of a redundancy group

The *State and mode* section of a redundancy group card shows its current state:

- **Available**: All primary elements are operational and all backup elements are available and ready to take over.
- **Error**: A backup element should have taken over from a primary element, but was unable to do so because it had already taken over from another primary element.
- **Operational**: At least one backup element has taken over from a primary element.
- **Unavailable**: The primary element failed and no backup element is currently available.
- **Undefined**: One or more switch conditions do not have a value yet. This can for instance be the case when the value for a trigger parameter is not initialized. A redundancy group can also enter this state if switching detection is unresolved.

> [!NOTE]
> If a redundancy group has more primary elements than backup elements, at the moment when all backups are in use, an alarm with severity level "Notice" will appear in the Alarm Console mentioning that all redundancy resources are in use. As soon as one of the backup elements is available again, the alarm will be cleared.

## Checking the current state of a virtual primary element

In the *Operational elements* section of a redundancy group card, you can see the virtual primary elements in the redundancy group and their current state.

| State                  | Description                                                                                                                                         |
|------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------|
| Primary is operational | A primary element is currently linked to the virtual primary element.                                                                               |
| Backup is operational  | A backup element is currently linked to the virtual primary element.                                                                                |
| Error                  | A backup element should have been linked to the virtual primary element, but DataMiner was not able to do this.                                     |
| Undefined              | One or more switch conditions do not have a value yet. This can for instance be the case when the value for a trigger parameter is not initialized. |

## Checking the current state of a primary or backup element

To check the current state of primary or backup elements of a redundancy group, expand the *Advanced* section on the redundancy group card.

| State                                   | Description                                                                                                                                         |
|-----------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------|
| Available                               | The backup element is not operational, but ready to take over from a primary element if necessary.                                                  |
| Operational                             | The primary or backup element is operational (i.e., linked to the virtual primary element).                                                          |
| Failed                                  | The primary element has been taken over by a backup element.                                                                                        |
| Error                                   | A primary element should have been taken over by a backup element, but DataMiner was not able to do so.                                             |
| Unavailable                             | The backup element cannot take over from a primary element.                                                                                         |
| Operational for another primary element | The backup element, which should normally be ready to take over from the primary element, has taken over from another primary element.              |
| Undefined                               | One or more switch conditions do not have a value yet. This can for instance be the case when the value for a trigger parameter is not initialized. |

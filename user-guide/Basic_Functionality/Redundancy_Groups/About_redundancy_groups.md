---
uid: About_redundancy_groups
---

# About redundancy groups

In DataMiner, you can set up redundant device architectures by simply combining primary and backup elements into so-called redundancy groups.

In DataMiner Cube, redundancy groups are listed in the Surveyor with a specific icon: ![redundancy group icon](~/user-guide/images/IconRG00054.PNG)

Redundancy groups have specific context menu options in the Surveyor. They also have corresponding redundancy group cards, which contain both status information and configuration options.

> [!NOTE]
> To quickly find a redundancy group in the Surveyor, search with the term “redundancy”, followed by a space and part of the redundancy group name. See [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube).

> [!IMPORTANT]
> Redundancy groups cannot be integrated with DataMiner Service and Resource Management (SRM).

### Primary elements, backup elements and virtual primary elements

A DataMiner redundancy group consists of a number of primary elements, which are operational in normal conditions, and a number of backup elements, which can take over in case primary elements fail.

When the redundancy group is configured, a new virtual element is created for each primary element. The virtual element is linked to the primary element under normal conditions, and linked to the backup element in case the backup takes over from the primary element. This means that the virtual primary element will always represent the operational unit, if any.

In short, when creating a redundancy group, you have to do the following:

- Add the primary and the backup elements to the redundancy group.

- Specify (for every primary element) when to switch from primary to backup, i.e. when to link the virtual primary element to the backup element.

- Specify (for every primary element) when to switch back from backup to primary, i.e. when to link the virtual primary element to the primary element again.

> [!NOTE]
>
> - Virtual primary elements “inherit” their parameter values from the primary element or backup element to which they are linked. However, they have their own alarm history and trend data.
> - Virtual primary elements can be included in services. That way, physical devices in a service can be automatically swapped when necessary without affecting the service itself.

### Software redundancy

In DataMiner, you can set up redundancy groups that include devices without native redundancy features.

To do so, you have to use an optional extra layer of redundancy logic called “software redundancy”, which is based on Automation scripts.

> [!TIP]
> See also:
> [Creating a redundancy group](xref:Creating_a_redundancy_group)

### Priority in a redundancy group

- **Priority among primary elements**: When a backup element is configured to take over from a number of primary elements, and more than one primary element is failing, the backup element will take over from the element with the highest priority.

- **Priority among backup elements**: When a redundancy group is configured so that any of the backup elements can take over when a primary element fails, the backup element with the highest priority will take over when a primary element fails.

> [!TIP]
> See also: [Setting the priority of a primary or backup element](xref:Setting_the_priority_of_a_primary_or_backup_element)

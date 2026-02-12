---
uid: Alarm_filters
---

# Alarm filters

While it is possible to filter the Alarm Console on the fly, for example by [using the quick filter box](xref:UsingTheQuickFilterBox) or [the quick filter buttons](xref:UsingTheQuickFilterButtons), or by [dragging an item onto the Alarm Console](xref:ApplyingAnAlarmFilterByDragging), DataMiner also also allows the use of permanent, [saved alarm filters](xref:WorkingWithSavedAlarmFilters).

Such alarm filters are stored in the DMS. They are always available, no matter which app you use to access the system. These filters can be used in several ways throughout the system:

- To define the contents of alarm tabs in the Alarm Console.

- To define which alarms need to be forwarded to SNMP Managers.

- To define for which alarms notifications are triggered.

- Etc.

Three types of saved alarm filters are available:

- **Private**: A private filter is not available/visible to other users. This private filter is linked to your user account, and only available when you log on with that user account.

- **Public**: A public filter is available to other users and anybody can change this type of filter.

- **Protected**: A protected filter is available to other users, but only the user who created the filter can change it.

> [!NOTE]
>
> - If you have not been granted the user permission *Security* > *View users from other groups*, you will not have access to public and protected alarm filters from other groups.
> - If you have been granted the user permission *Edit/delete protected filters*, you will be able to make changes to protected filters even if you were not the one who created them.

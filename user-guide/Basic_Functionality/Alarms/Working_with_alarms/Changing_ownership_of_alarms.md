---
uid: Changing_ownership_of_alarms
---

# Changing ownership of alarms

The Alarm Ownership feature allows unambiguous assignment of responsibility for individual alarm events, as well as tracking of those responsibilities.

When the DataMiner System generates a new alarm event, the *Alarm Type* property is set to "New Alarm", the *Owner* property is set to "System", and the *User Status* property is set to "Not Assigned".

## Taking ownership of an alarm

To indicate to other users that you are aware of an issue and working on a resolution, you can take responsibility for an alarm record by taking ownership of it.

To do so:

1. In the *Active Alarms* tab of the Alarm Console in DataMiner Cube, right-click the alarm event and select *Take Ownership*.

1. In the *Take Ownership* window, enter a comment explaining why you are taking ownership of the alarm event.

When you take ownership of an alarm event, a new alarm record is added to the life cycle of that alarm event, where the *Alarm Type* property has been set to "Acknowledged". The *Owner* property of the new alarm records that are added to the life cycle of that alarm will contain your user name.

> [!NOTE]
>
> - If you want to query the historical database for all alarm events of which users took ownership, select all alarm events where the *Alarm Type* property is "Acknowledged".
> - You cannot take ownership of alarm events that are owned by someone else. In that case, ownership will first need to be released.

## Releasing ownership of an alarm

After you have taken ownership of an alarm event, it is possible to release ownership again in case you cannot resolve the alarm situation or your motivation to take ownership no longer stands.

To do so:

- In the Alarm Console in DataMiner Cube, right-click the alarm you currently own and select *Release Ownership*.

> [!NOTE]
> By default, you can only release ownership of alarm events that you currently own. However, if you have been granted the permission *Release ownership of another user*, you are also allowed to release ownership of alarms that are owned by other users.

When you release ownership of an alarm event, an alarm record will be added to the life cycle of that alarm event. Both the Alarm Type property and the User Status property of that record will be set to "Unresolved". The Owner property of that record and all subsequent records added to the life cycle of the alarm will be set to "System" until someone else takes ownership of the alarm.

## Example of ownership transitions

The following example illustrates how the *Alarm Type*, *Owner* and *User Status* properties of alarm records reflect ownership transitions.

| Event                                                                                          | Alarm type   | Owner         | User Status  |
|------------------------------------------------------------------------------------------------|--------------|---------------|--------------|
| The DataMiner System generates a new alarm event.                                              | New Alarm    | System        | Not assigned |
| The user "Administrator" takes ownership of the alarm event.                                   | Acknowledged | Administrator | Acknowledged |
| The alarm, being owned by the user "Administrator", escalates to a higher severity level.      | Escalated    | Administrator | Acknowledged |
| The user "Administrator" releases ownership of the alarm event.                                | Unresolved   | Administrator | Unresolved   |
| The alarm event drops to a lower severity level while remaining unresolved.                    | Dropped      | Administrator | Unresolved   |
| The user "NOC Engineer" takes ownership of the alarm event.                                    | Acknowledged | NOC Engineer  | Acknowledged |
| The alarm, being owned by the user "NOC Engineer", again escalates to a higher severity level. | Escalated    | NOC Engineer  | Acknowledged |
| The alarm event is cleared while being owned by the user "NOC Engineer".                       | Clear        | NOC Engineer  | Acknowledged |

> [!NOTE]
> Whenever users take or release ownership of alarm events, they are invited to add a comment. Whether they do so or not, the DataMiner System will automatically add a comment as well. This automatically added comment will reveal who took or released ownership and when this was done.

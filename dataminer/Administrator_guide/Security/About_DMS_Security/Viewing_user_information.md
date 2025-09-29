---
uid: Viewing_user_information
---

# Viewing user information

In DataMiner Cube, you can view various detailed information about users, provided that you have the necessary user permissions to do so (i.e. [Administrator](xref:DataMiner_user_permissions#modules--system-configuration--security--administrator) or [Limited administrator](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator), with or without [View users from other groups](xref:DataMiner_user_permissions#modules--system-configuration--security--view-users-from-other-groups), depending on whether access to user information from other groups should be available).

There are two ways you can view this information:

- Go to System Center > *Users / Groups* > *users* and select the user.
- Look up the user in the search box at the top of the Cube UI, and double-click the search result to open the user card.

The information is shown on different tabs:

- **Details**: The user's contact details, security level, dataminer.services credentials (indicated as *DCP username* and *DCP password*), and last login.
- **Group membership**: The groups the user is a member of.
- **Permissions**: The user permissions that have been assigned to the user. These are inherited from the user groups the user is a member of.
- **Alerts**: The notifications that have been configured for the user.
- **Activity** > **Recent sessions**: Log detailing when the user logged on and which client application was used for this.
- **Activity** > **Actions**: The recent activity of the user on the DataMiner Agent.

![Recent activity](~/dataminer/images/Recent_Activity.png)<br>
*Recent activity on a user card in DataMiner Cube 10.5.10*

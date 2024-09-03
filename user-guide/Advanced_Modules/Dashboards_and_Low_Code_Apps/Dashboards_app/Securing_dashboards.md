---
uid: Dashboards_permissions
---

# Permissions

Permissions can be customized for both folders and individual dashboards, allowing you to restrict access or prevent unauthorized modifications.

With 'parent' in the below document, we refer to the parent folder of a dashboard or sub folder. In case we’re talking about a folder under the root, the parent is the root itself.

> [!IMPORTANT]
> Restricting access to dashboards does not imply any restrictions on the underlying data. For this, the access rights on the corresponding data sources should be configured.

## Different permissions

1. No Access
    - Users are unaware of the dashboard or folder’s existence.
    - The dashboard/folder is hidden from the overview.
    - Direct navigation via URL yields the same result as attempting to access a non-existent resource.

2. View Access
    - Users can view and open the dashboard or folder.
    - They can interact with its contents but cannot make modifications.
    - Creation of new dashboards or folders is not permitted.
    - They have no access to the Settings on the resource on which they have view access.

3. Edit Access
    - Users can view and open the dashboard or folder.
    - Dashboard:
        - Users can modify its contents.
    - Folder:
        - Users can manage its contents, including creating and removing subfolders or dashboards.
        - They cannot alter the folder itself (e.g., rename or move it); this requires ‘Edit Access’ on the parent.

> [!NOTE]
> If a folder is inaccessible, all its subfolders and dashboards are also hidden recursively. This recursive nature only applies to the ‘View Access’ privilege. The ‘Edit Access’ privilege applies only to the current folder or dashboard and does not propagate to subfolders or dashboards.

> [!NOTE]
> The built-in Administrator account always has full access to all dashboards.

### Special Combinations of Privileges

  1. View Access to Parent + Edit Access to Child Folder:
     - Users can create new dashboards or folders within the child folder.
  2. View Access to Parent + Edit Access to Dashboards:
     - Users can edit specific dashboards within the parent.
  3. View Access to Parent + No View Access on Certain Dashboards:
     - Users cannot see the restricted dashboards.
  4. Edit Access to Parent + View Access on Dashboards:
     - Users can view the dashboards without making changes. They also can’t rename, move or delete the dashboards.
     - They can create and edit new dashboards within the parent.
  5. Edit Access to Parent + View Access on Child Folder:
     - Users cannot create new dashboards or subfolders in the child folder.
     - They can delete, move, or rename the child folder and all dashboards directly within the parent.

## Types of assignees

 1. Everyone
    - Privileges apply to every DataMiner user.
 2. User group
    - Privileges apply to all users within a specific user group.
 3. User
    - Privileges apply to an individual user.

> [!IMPORTANT]
> Conflict Resolution: If privileges are assigned directly to a user and to a group the user belongs to, the broader privilege will be applied.

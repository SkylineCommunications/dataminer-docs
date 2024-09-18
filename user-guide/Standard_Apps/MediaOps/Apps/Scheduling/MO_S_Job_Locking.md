---
uid: MO_S_Job_Locking
---

# Locking job editing

The *Locking job editing* feature is designed to prevent conflicts and ensure data integrity when multiple users are editing the same job simultaneously. By locking a job, a user can prevent others from making changes until they release the lock.

## How Locking job editing feature works

To better understand the *Locking job editing* feature, check these steps:

1. User initiates edit:
    - A user clicks on the "Edit Job" button for a specific job.
    - The system checks if the job is currently locked.
    - If the job is unlocked, the system places a lock on the job and allows the user to edit it.
1. Other user attempts to edit:
   - If another user tries to edit the same job while it's locked, the system will display a notification informing them that the job is already locked.
1. Taking ownership of locked job:
   - If a user needs to take control of the job even if it's locked by someone else, they can choose the "Confirm" option on notification which is displayed and take lock from another user.
   - Once another user has lock, the user who had the original lock will receive a notification once they click on *Save* option that their lock has been overridden.
   - The original user will no longer be able to save their changes to the job.
1. Opening job in *View only* mode
   - If a user selects "View only" mode, he will have an access to edit job panel, but only with read-only privilege. In that case, user can read every information about job, but the original user can still edit and save his changes to the job.

## Key features

- Automatic Locking: Jobs are automatically locked when a user starts editing them.
- Lock Notifications: Users receive notifications when a job they were editing is locked by another user.
- Taking Lock from another user: Users can forcibly take control of a locked job under certain circumstances.
- Conflict Prevention: The feature helps prevent conflicts and ensures data consistency.

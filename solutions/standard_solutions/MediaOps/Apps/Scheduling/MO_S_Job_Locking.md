---
uid: MO_S_Job_Locking
---

# Job locking

To prevent conflicts and ensure data integrity of jobs, the Scheduling app makes use of an **automatic locking mechanism**, preventing multiple users from making changes to the same job at the same time.

When a user starts editing a job, the system will check if the job is currently locked. If it is not, the system will place a lock on the job and allow the user to edit it. If another user then tries to edit that same job, the system will display a **notification** informing them that the job is already locked.

If a user needs to take control of a job that has been locked by someone else, they can choose the *Confirm* option in the notification that is displayed and **take ownership** of the locked job instead. In that case, the user who originally had the lock will receive a notification when they save the job, informing them that their lock has been overridden. The **original user will no longer be able to save their changes** to the job.

When a job is locked, it can be opened in **view only** mode instead. If you select to open a job in this mode, you will have access to the *Edit job* panel, but you will not be able to make any changes to it. This way, you can still check detailed information for a job, but the original user can still continue editing and save their changes.

<!-- TODO: Add screenshots illustrating these options -->
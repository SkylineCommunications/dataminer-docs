---
uid: MO_S_Job_Locking
description: "Explore the automatic locking mechanism used by the Scheduling app. This prevents multiple users from making changes to the same job at the same time."
---

# Job locking

To prevent conflicts and ensure data integrity of jobs, the Scheduling app makes use of an **automatic locking mechanism**, preventing multiple users from making changes to the same job at the same time.

When you start editing a job, the system will check if the job is currently locked. If it is not, the system will place a lock on the job and allow you to edit it. If another user then tries to edit that same job, the system will display a **notification** informing them that the job is already locked.

If you need to take control of a job that has been locked by someone else, you can choose the *Confirm* option in the notification that is displayed and **take ownership** of the locked job instead. In that case, the user who originally had the lock will receive a notification when they save the job, informing them that their lock has been overridden. That **original user will no longer be able to save their changes** to the job.

In addition to this, in case you already have a job open for editing in another browser session or tab, and you try to edit the same job in a different tab, you will also get a notification indicating that the job is locked in another session.<!-- RN 46489 -->

When a job is locked, it can be opened in **view only** mode instead. If you select to open a job in this mode, you will have access to the *Edit job* panel, but you will not be able to make any changes to it. This way, you can still check detailed information for a job, while the active session can continue editing and save its changes.

If the current lock state cannot be retrieved (for example, in case of temporary connectivity issues), the item is automatically opened in **read-only mode**, ensuring that you can safely view it.<!-- RN 46489 -->

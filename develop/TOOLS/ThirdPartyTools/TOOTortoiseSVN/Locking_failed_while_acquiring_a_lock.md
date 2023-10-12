---
uid: Locking_failed_while_acquiring_a_lock
---

# Locking failed while acquiring a lock

In case a file is not up to date with changes from others, you will receive a "Locking Failed" error message when trying to acquire a lock.

![](~/develop/images/SVN_locking_failed.png)<br>
*TortoiseSVN locking error message*

This basically means that your local file is not up to date with the version found on the repository. To solve this, you can either press the *Update* button in the error message or perform an SVN update via the right-click menu, which will sync the files again.

It is also possible that files get a red icon overlay, for example when changes are made locally but not pushed to the repository. This means that your file is not in sync with the repository, which can be solved by performing an update. While it is normal for the icon to be red while you are working on a protocol, if it is red because of a change that you did not make yourself, you should perform an update.

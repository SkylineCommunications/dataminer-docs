---
uid: Locking_files
---

# Locking files

Files under version control are read-only by default. This means that after you get a protocol version from the repository, you will not be able to start working on it right away. In order to perform changes, you have to request a lock to the repository, which makes the file read-write.

To do so, right-click the item you wish to change.

> [!NOTE]
> Never change the read-only flag of a file manually.

![](~/develop/images/SVN_get_lock.png)<br>
*TortoiseSVN SVN Get lock context menu item*

When you wish to change the protocol.xml file, you have to request a lock first. Requesting the lock is an automatic commit in the background. Upon requiring the lock, you can start making changes to the file.

![](~/develop/images/SVN_locked_file.png)<br>
*TortoiseSVN locked item*

> [!NOTE]
> Though there is an option available to steal a lock, you should avoid using this. Instead, inform the person holding the lock first.

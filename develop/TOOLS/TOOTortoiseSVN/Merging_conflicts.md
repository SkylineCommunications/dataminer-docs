---
uid: Merging_conflicts
---

# Merging conflicts

In case multiple users perform changes on the same file at the same time, a merge conflict can occur when changes are committed to the repository.

If a merge conflict occurs during a commit, the changes in both files should be merged. If you encounter a situation like this, **contact the person who made the changes**. Do not throw away their changes without asking, because they might have forgotten to push a piece of important code. If you were to merge over this, the changes would be **gone forever**.

![](~/develop/images/SVN_conflict.png)<br>
*TortoiseSVN merge conflict*

To solve a merge conflict, right-click the file and select *TortoiseSVN* > *Edit conflicts*. A new UI will open, showing the differences between both files. You can then choose which changes should be kept and which discarded.

![](~/develop/images/SVN_solve_conflict.png)<br>
*TortoiseSVN merge window*

When you are done with the merge, save the file and commit.

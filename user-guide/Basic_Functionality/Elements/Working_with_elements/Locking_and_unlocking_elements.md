---
uid: Locking_and_unlocking_elements
---

# Locking and unlocking elements

If a DataMiner element is locked, only the user who locked the element is able to implement any parameter changes on it. In some cases, an element lock can be applied automatically, in particular by the DataMiner Automation module, but elements can also be locked manually by a user.

> [!NOTE]
> Locking an element only protects against parameter updates. Users who have the appropriate permissions to do so will still be able to delete an element or edit the element configuration of an element while it is locked by another user.

## Locking an element

1. Click the element in the Surveyor to open the element card.

1. Go to the *General parameters* page.

1. Click the hamburger button in the top left corner of the card and select *Lock element*.

   At the bottom of the card, a notice will be displayed detailing the name of the element and the user who locked the element.

> [!NOTE]
> Locking a replicated element is only possible via the source element, not via the replicated element.

## Unlocking an element

- In the element card menu, select *Unlock element*, or

- Right-click the notice at the bottom of the card and select *Unlock element*.

> [!NOTE]
> You can only use the *Unlock element* option if you were the user who locked the element. If a different user locked the element, and you have the appropriate permissions to do so, right-click the notice and select *Force unlock element* instead.

---
uid: Masking_or_unmasking_an_element
---

# Masking or unmasking an element

It is possible to mask an element, so that any alarms on that element will not show in the active alarms. This can for instance be done to avoid unnecessary follow-up when an element is being tested.

> [!TIP]
> See also: [Masking and unmasking alarms](xref:Masking_and_unmasking_alarms)

## Masking an element

1. Right-click the element in the Surveyor and select *Mask*.

   The *Mask* dialog box will appear.

1. Select a masking method:

   - If you want the element to automatically unmask after a fixed duration, select the option *Mask element for a limited period of time*, then specify the time period.

     > [!NOTE]
     > The maximum masking duration if you mask an element for a limited period of time is 30 days.

   - If you want the element to remain masked until a user unmasks it, select *Mask element until unmasked*.

   - If you want the element to remain masked until all alarms on the element have been cleared, select *Mask element until cleared*.

   > [!NOTE]
   >
   > - Regardless of the option you have chosen, it is always possible to manually unmask the element.
   > - Elements that have been stopped cannot be masked.

1. Optionally, fill in a comment.

1. Click *Mask*.

## Unmasking an element

1. Right-click a masked element in the Surveyor, and select *Unmask*.

1. Optionally, enter a comment in the dialog box.

1. Click *Unmask*.

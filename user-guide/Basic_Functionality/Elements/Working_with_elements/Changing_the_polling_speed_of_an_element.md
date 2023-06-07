---
uid: Changing_the_polling_speed_of_an_element
---

# Changing the polling speed of an element

The polling speed of an element is determined by the timers specified in the element protocol. You can slow down or speed up these timers by changing the value of the element’s \[Timer base\] parameter.

## Required protocol settings to allow timer base changes

The \[Timer base\] parameter will only affect so-called relative timers. As such, it can only be used in conjunction with element protocols where the *relativeTimers* attribute of the *Protocol.Type* tag has been set to “*true*” or “*true with reset*”.

- If *Protocol.Type* is set to “*true*”, the timers will not immediately be reset when the \[Timer base\] parameter is changed. Running timers will continue and will be reset at the next iteration.

- If *Protocol.Type* is set to “*true with reset*”, all timers will immediately be reset when the \[Timer base\] parameter is changed.

> [!NOTE]
> If you set the *relativeTimers* attribute of the *Protocol.Type* tag to “*true*” or “*true with reset*”, all timers specified in that protocol will be relative timers. If, however, you want one or more specific timers to be fixed timers (i.e. timers with a fixed frequency, whatever the value of the \[Timer Base\] Parameter), you can set the *fixedTimer* attribute of their *Protocol.Timers.Timer* tag to “*true*”.

## \[Timer Base\] parameter functionality

If you specify a value in the \[Timer base\] parameter of an element, all timer values specified in the element protocol will be multiplied by that \[Timer base\] value.

### Example

In an element protocol, three different timers have been specified:

- a 2-second timer

- a 1-minute timer

- a 1-hour timer

If you set the element’s \[Timer base\] parameter to 3.00, the polling periods of those three timers will all be multiplied by 3.00.

- The 2-second timer will now be a 6-second timer.

- The 1-minute timer will now be a 3-minute timer.

- The 1-hour timer will now be a 3-hour timer.

### Allowed \[Timer base\] values

The \[Timer base\] parameter can be set to a value ranging from 0.01 to 10.00.

- A value between 0.01 and 0.99 will cause timer frequencies to rise (result: polling will speed up).

- A value between 1.01 and 10.00 will cause timer frequencies to drop (result: polling will slow down).

> [!NOTE]
> A value of 0.00 or 1.00 will not affect the timer frequencies specified in the protocol.

## Changing the \[Timer base\] of one element

1. Open the relevant element card. See [Element cards](xref:Element_cards).

1. Go to the page *General parameters*.

1. Enter the desired value next to *\[Timer base\]* and click the green check mark icon.

## Changing the \[Timer base\] of several elements at once

1. In the Surveyor, right-click one of the elements in question and select *Multiple Set*.

1. In the *Multiple Set* dialog box, set the *Parameter* selection box to *\[Timer base\]*.

1. Below this, in the box next to *Value*, enter the new \[Timer base\] value or use the slider to select the value.

1. In the list on the right, select all elements for which you want the \[Timer base\] parameter to be changed.

1. Click the *SET* button.

> [!NOTE]
> This is only possible with elements that use the same protocol and protocol version.

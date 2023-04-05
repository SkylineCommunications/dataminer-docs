---
uid: Clear_Table_Data_on_Polling_Disable
---

# Clear Table Data on Polling Disable

As a rule, table data should be cleared when an operator disables the polling for a particular table, because the user is most likely no longer interested in the data when polling is disabled.
This has the following advantages:

- The startup time of the element will be reduced, as less data will need to be loaded from the database.

- No outdated data will be shown, which could otherwise cause confusion.

- There is no loss of trending/alarm history, as it is the element data that gets deleted.

  The operator cannot access that history via the element itself (the keys are gone) but could use other DataMiner alternatives if they really want to access the history. In case they enable the polling of the table again, they will have access to the history again via the element (the keys need to be the same).

- Sticky alarms are avoided.

  Otherwise, if certain table values cause an alarm and the operator disables the polling, those parameters will still show alarms, even after an element restart. What is worse, after an element restart those parameters will show “Not initialized” until polling is enabled again, so there will be sticky alarms without any visual reference in the element as to which parameters are in alarm.

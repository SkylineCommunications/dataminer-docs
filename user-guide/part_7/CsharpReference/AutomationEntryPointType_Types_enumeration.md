# AutomationEntryPointType.Types enumeration

This enumeration specifies the entry point method type.

| Member name                     | Value      | Description                           |
|---------------------------------|------------|---------------------------------------|
| Default                         | 0          | Default.                              |
| SRMServiceInfoStateChanges      | 1          | SRM service info state change.        |
| OnSrmQuarantineTrigger          | 2          | On SRM quarantine trigger.            |
| OnSrmStartActionsFailure        | 3          | On SRM start actions failure.         |
| InstallAppPackage               | 4          | Install App package.                  |
| ConfigureApp                    | 5          | Configure App package.                |
| UninstallApp                    | 6          | Uninstall App package.                |
| OnSrmBookingsUpdatedByReference | 7          | On SFM bookings updated by reference. |
| OnDomInstanceCrud               | 8          | On DOM instance CRUD.                 |
| OnTicketCrud                    | 9          | On ticket CRUD.                       |
| AutomationEntryPointTest        | 2147483647 | Automation test entry point.          |

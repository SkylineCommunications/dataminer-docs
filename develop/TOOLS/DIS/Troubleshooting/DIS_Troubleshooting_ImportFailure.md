---
uid: DIS_Troubleshooting_ImportFailure
keywords: dis import issue
---

# Importing problems

## Problem

Importing a dashboard or low-code app fails with an error when connected to an Agent via an on.dataminer.services cloud connection.

## Possible causes

- The account you are signed in with in DIS is **not part of the dataminer.services organization**.

- Your DIS **sign-in session/token has expired**.

- The DataMiner user you use to connect to the Agent is **not linked** to your dataminer.services account.

## Possible solution

1. Verify your DIS sign-in status:

   1. In DIS, open the settings and go to the **Account** tab.
   1. Check whether **Login status** is **Connected**.
   1. Check whether **Account status** is **OK**.
   1. If either of these statuses has a different value, sign in again.

1. Go to [admin.dataminer.services](https://admin.dataminer.services) and confirm that the signed-in account is part of the expected organization.

1. Make sure that your DataMiner user account is linked to your dataminer.services account:

   1. On [admin.dataminer.services](https://admin.dataminer.services), open your DataMiner System and go to the **Users** page.

   1. Check whether the DataMiner user account (the one used to log in to the Agent) is linked to your dataminer.services account.

      If it is not, [link your DataMiner account to your dataminer.services account](xref:Linking_your_DataMiner_and_dataminer_services_account).

1. Sign out and sign back in again in DIS to refresh your authentication, and then retry the import.

If the issue still persists after you have tried the steps above, report the issue to the DIS team, making sure to include the Visual Studio output logging. For more info, see [Retrieving information in case a problem occurs](xref:DIS_Troubleshooting_RetrieveInformation).

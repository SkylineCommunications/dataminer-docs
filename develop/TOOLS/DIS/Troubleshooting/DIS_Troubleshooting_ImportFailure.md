---
uid: DIS_Troubleshooting_ImportFailure
keywords: dis import issue
---

# Import problems

## Problem

Importing a Dashboard or Low Code App fails with an error when connected to an Agent via an on.dataminer.services cloud connection.

## Possible causes

- The account you are signed in with in DIS is **not part of the dataminer.services organization**.

- Your DIS **sign-in session/token has expired**.

- The DataMiner user you use to connect to the Agent is **not linked** to your dataminer.services account.

## Possible solutions

1. Verify your DIS sign-in status.

   In DIS, open the settings and go to the **Account** tab.

    - Make sure **Login status** is **Connected**.
    - Make sure **Account status** is **OK**.

   If either status is not OK, sign in again.

1. Verify that your signed-in account is part of the correct organization.

   Go to [admin.dataminer.services](https://admin.dataminer.services) and confirm that the signed-in account is part of the expected organization.

1. Verify that your DataMiner user is linked to your dataminer.services account.

   On [admin.dataminer.services](https://admin.dataminer.services), open your DataMiner System and go to the **Users** page.

   Confirm that the DataMiner user account (the one used to log in to the Agent) is linked to your dataminer.services account.

1. Refresh the authentication in DIS.

   Sign out and sign back in again in DIS, and then retry the import.

If the issue still persists after you have tried the solutions above, report the issue to the DIS team, making sure to include the Visual Studio output logging. For more info, see [Retrieving information in case a problem occurs](xref:DIS_Troubleshooting_RetrieveInformation).
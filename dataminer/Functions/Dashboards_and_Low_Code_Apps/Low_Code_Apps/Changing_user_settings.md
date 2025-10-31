---
uid: LCA_User_Settings
---

# Configuring user settings

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43803-->, you can change certain user-specific settings directly from the Low-Code Apps interface. As of now, this allows users with the appropriate user permissions to change their password from within an app, without needing to access Cube.

## Prerequisites

A user can only access the user settings if the following conditions are met:

- In *System Center* > *Users*, the user's *User cannot change password* setting must be disabled.

- The user must have the [*Modules* > *System configuration* > *Security* > *Specific* > *Limited administrator* permission](xref:DataMiner_user_permissions#modules--system-configuration--security--specific--limited-administrator).

- The user must not be logged in with external or delegated authentication.

## Changing your password

To change your password directly from the Low-Code Apps interface:

1. Click the user button in the top-right corner.

1. Select *User settings*.

1. In the *User settings* pop-up window, enter your old password and then enter your new password twice.

1. Select *Update password* to confirm the new password.

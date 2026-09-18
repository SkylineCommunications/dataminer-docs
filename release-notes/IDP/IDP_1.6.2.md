---
uid: IDP_1.6.2
---

# IDP 1.6.2

## New features

#### New Purge History table [ID 45176]

Under *Admin* > *Configuration* > *Purge Settings* in the IDP app, you can now find a new *Purge History* table. This will allow you to track the files that were deleted by each purge setting.

In Data Display, a new *Clear Purge Result* button is also available to clear the new table, and a new *Purge History Max Rows* parameter allows you to configure how many rows the table is allowed to contain (default: 100). However, note that these parameters are not shown in the IDP visual overview.

## Changes

### Enhancements

#### Setup wizard installs discovery and provisioning user-defined API [ID 45101]

The IDP setup wizard will now also install user-defined APIs for discovery and provisioning.

#### Configuration Manager connector refactored [ID 45194]

The Configuration Manager connector has been refactored:

- The *RemoteAuthentication* and *LocalAuthentication* have been removed and refactored into new classes:

  - RemoteAuthenticator
  - LocalAuthenticator
  - RemoteAuthenticationInfo
  - LocalAuthenticationInfo

  *LocalAuthenticationInfo* and *RemoteAuthenticationInfo* contain the information needed to authenticate. *LocalAuthenticator* and *RemoteAuthenticator* are used to do the actual authentication. *RemoteAuthenticator* and *LocalAuthenticator* implement *IDisposable*.

- While previously the cleanup happened when the *Logout* method was called, cleanup now happens when the *RemoteAuthenticator* or *LocalAuthenticator* object is disposed of.

- *LocalAuthenticator* now uses *SafeAccessTokenHandle* to store the *userToken* instead of storing it as *IntPtr*.

### Fixes

#### IDP Connectivity no longer working when mapping table contains non-existing elements [ID 45352]

When the mapping table contained elements that no longer existed in the system, it could occur that IDP Connectivity stopped working. This issue has been resolved.

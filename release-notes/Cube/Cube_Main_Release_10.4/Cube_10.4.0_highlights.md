---
uid: Cube_Main_Release_10.4.0_highlights
---

# DataMiner Cube Main Release 10.4.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Automation: New user/group setting to specify whether users have to confirm program executions launched from interactive Automation scripts [ID_35418]

<!-- MR 10.4.0 - FR 10.3.3 -->

A new user/group setting named *Do not confirm program executions from scripts*, found in the *User > Cube* tab of the *Settings* window, now allows you to specify whether users will have to explicitly confirm each program execution that is launched from an interactive Automation script.

By default, this option will be disabled, meaning that users will have to give their consent each time an interactive Automation script wants to launch a program. The confirmation box will also allow users to change the setting by selecting the *Don't show this confirmation again. Always launch program executions.* checkbox.

Each time a program is launched, a start entry and an end entry will be added to the Cube logging as well as to the *SLClient.txt* log file on the DataMiner Agent.

- The start entry will contain the following data:

  - the name of the Automation script
  - the ID of the Automation script
  - the user's login data (full name, client machine name, client app name and last login date)
  - the program that will be launched
  - the arguments that will be passed to the program (if any)

- The end entry will contain the following data:

  - the user's login data (full name, client machine name, client app name and last login date)
  - the process ID of the program
  - the time at which the process ended
  - the name of the program that ended
  - the arguments that were passed to the program (if any)

<!-- 

#### DataMiner User-Defined APIs: Official release [ID_36273]

<!-- MR 10.4.0 - FR 10.3.6 -->

-->

<!-- 

With the DataMiner User-Defined APIs, you can define API calls that will be made available on DataMiner Agents hosting the *UserDefinableApiEndpoint* DxM. These APIs can be secured using API tokens, which can be generated on the fly and linked to the API definitions.

##### Configuring APIs and tokens

in System Center

##### Defining new APIs

"Configure API" button in Automation module

##### Granting User-Defined API permissions

In *System Center > Users/Groups*, you can grant users a number of permissions related to User-Defined APIs.

In the *Modules > User-Defined APIs* section, you can find the following user permissions:

- *Tokens > UI available*: Permission to view API tokens
- *Tokens > Add/Edit*: Permission to create and update API tokens
- *Tokens > Delete*: Permission to delete API tokens
- *APIs > UI available*: Permission to view API definitions
- *APIs > Add/Edit*: Permission to create and update API definitions. Note that users will also need to be granted the *Automation > Execute* permission.
- *APIs > Delete*: Permission to delete API definitions

##### Consult logging regarding User-Defined APIs

- User-defined API server logging in Logging module

-->

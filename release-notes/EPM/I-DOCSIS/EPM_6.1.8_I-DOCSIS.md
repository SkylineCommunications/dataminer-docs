---
uid: EPM_6.1.8_I-DOCSIS
---

# EPM 6.1.8 I-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Elements in EPM Solution now use inter-app calls [ID_36326]

Inter-app calls will now be used for the communication between elements used in the EPM Solution, such as the back end and the Workflow Manager (WM), resulting in faster and more efficient communication. This way, the solution no longer needs to rely on information events and alarms triggered by Automation scripts and Correlation rules.

The following changes have been done to the Skyline EPM Platform DOCSIS connector (back end):

- The connector no longer uses calls to information events to pass information.
- Inter-app calls are now aggregated to send information to the WM.
- Information from the WM is now processed through inter-app communication.

The following changes have been done to the Skyline EPM Platform DOCSIS WM connector:

- The connector no longer uses calls to information events to pass information.
- Parameters that are used to capture information events are no longer used.
- Inter-app calls are now aggregated to send information to the back end.
- Information from the back end is now processed through inter-app communication.

### Fixes

#### Incorrect -1 values in Nodes, Amplifier Overview, and Subscribers Overview tables [ID_36197]

In the Nodes, Amplifier Overview, and Subscribers Overview tables, it could occur that the Node ID, Amplifiers ID, and Subscribers ID columns displayed the value "-1" where they were supposed to show "N/A".

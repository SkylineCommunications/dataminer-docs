---
uid: DisTutorials_MibBrowser
---

# Tutorial: Exploring the DIS MIB Browser

In this tutorial, you familiarize yourself with the DIS MIB Browser's functionalities by loading a MIB file, generating parameters, and comparing them to a sample protocol.

> [!TIP]
> You can follow along with this [step-by-step video tutorial](https://skyline.be/).

> [!NOTE]
> This tutorial uses DataMiner Integration Studio version 2.44.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

- Carefully read [Using the DIS MIB Browser](xref:DIS_MIB_Browser)

- Download the MIB Browser tutorial file [from GitHub](https://github.com/SkylineCommunications/Tutorials-DIS-MIB_Browser/tree/main/Documentation)

- Download the *protocol.xml* file [from GitHub](https://github.com/SkylineCommunications/Tutorials-DIS-MIB_Browser)

## Step 1: Exploring the DIS MIB Browser functionalities

1. Load a MIB file:

   1. Launch the DIS MIB Browser from Visual Studio.

   1. Go to the *Files* tab and select *Add*.

   1. After selecting the MIB file, click *Load files* to start the loading process.

1. Go to the *MIB Tree* tab, and explore the MIB Tree by identifying the newly added parameters (i.e. "1.3.6.1.4.1.9999").

1. Generate a parameter:

   1. Find the *cpuLoad* parameter in the MIB Tree.

   1. Drag and drop it into the sample protocol (i.e. *protocol.xml*) to see how the parameter details are automatically filled.

1. Generate parameters in bulk:

   1. Right-click your protocol and select *Generate Parameters*.

   1. In the second window, select *systemDateTime*, *moduleName*, and *logTable* to generate multiple parameters simultaneously, and observe the process.

1. Compare the loaded MIB file with the protocol:

   1. Navigate to the *Compare* tab.

   1. Click *Refresh*.

   1. Create a list of any discrepancies between the MIB file and the protocol.

1. If there are parameters in the MIB file not in the protocol, use the *drag and drop* feature to integrate them into the protocol.

   > [!NOTE]
   > Because of how we define tables, the comparison will always show the first column of a table, even if it is already included in the protocol.

## Step 2: Submitting your protocol.xml file

Once you have successfully navigated the steps under [Exploring the DIS MIB Browser](#step-1-exploring-the-dis-mib-browser-functionalities), forward your updated *protocol.xml* file to [Team Data Acquisition](mailto:domain.create.data-acquisition@skyline.be).

Adhere to the following email format:

- **Subject**: Tutorial - DIS - MIB Browser

- **Attachment**: Add your XML file

- **Body**:

  - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to submit the XML file.

    > [!IMPORTANT]
    > Successfully submitting your updated *protocol.xml* file will earn you DevOps Points. These points can only be rewarded if you specify your Dojo account.

  - Feedback (optionally): We value your feedback! Please share any thoughts or suggestions regarding the tutorial.

Skyline will review your submission. Upon successful validation, you are awarded the appropriate DevOps Points as a token of your accomplishment!

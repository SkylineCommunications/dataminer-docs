---
uid: DisTutorials_MibBrowser
---

# Hands-on Tutorial: Explore and Modify with the DIS MIB Browser

## Objective

Familiarize yourself with the DIS MIB Browser's functionalities by loading a MIB file, generating parameters, and comparing them to a sample connector.

You can follow along with the [step-by-step video](https://skyline.be/) for this tutorial.

## Prerequisites

- Ensure you've gone through the [DIS MIB Browser Guide](xref:DisGuides_MibBrowser).
- You can download the tutorial files [here](https://github.com/SkylineCommunications/Tutorials-DIS-MIB_Browser).
  - The MIB file can be found in the 'Documentation' folder on GitHub.

## Steps

1. **Load a MIB File**:
   - Launch the DIS MIB Browser from Visual Studio.
   - Navigate to *Files* > *Add* and click *Load files* to initiate the loading process.

2. **Explore the MIB Tree**:
   - Browse through the MIB tree. Identify the newly added parameters (1.3.6.1.4.1.9999).

3. **Generate a Parameter**:
   - Find the 'cpuLoad' parameter in the MIB Tree.
   - Drag and drop it into the sample connector. Observe how the parameter details get filled automatically.

4. **Bulk Parameter Generation**:
   - Try the 'Generate Parameters...' feature by right-clicking in your connector. Select 'systemDateTime', 'moduleName' and the 'logTable' to generate in bulk and observe the process.

5. **Comparison**:
   - After generating parameters, navigate to the *Compare* tab.
   - Click on *Refresh* and compare the loaded MIB file with the connector.
   - Identify any discrepancies between the two and make a list.

6. **Integration**:
   - If there are parameters in the MIB file that aren't in the connector (from the comparison step), use the drag & drop feature to integrate them into the connector.
   > [!NOTE]
   > Due to how we define tables, the comparison will always show the first column of a table even though it is already in the connector.

## Review and Submission

Once you've successfully navigated the steps provided, please forward your completed connector XML to [Data-Acquisition](mailto:domain.create.data-acquisition@skyline.be). Our team will review your submission.
Upon successful validation, we'll credit your account with well-deserved DevOps points as a token of your accomplishment!

### Email Submission Template

To streamline the review process, please adhere to the following email format:

- **Subject**: 'Tutorial - DIS - MIB Browser'
- **Attachments**: Your completed XML file
- **Body**:
  - Clearly state your Dojo account (especially if you're using a different email address for submission).
  - We value your feedback! Please share any thoughts or suggestions regarding the tutorial.

Thank you for your dedication and commitment to continuous learning!

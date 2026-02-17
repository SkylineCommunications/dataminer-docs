---
uid: Support_Level_Roles
---

# Support level roles

The responsibilities as a partner when providing DataMiner Support Services are similar to those of Skyline staff members: offering both proactive and reactive support.

Within reactive support, there are two major levels that can be executed either by the same or by different members.

Key responsibilities:

- **Ensure cloud connectivity**: Make sure that the end customer DMA(s) are properly connected to the cloud.

- **Maintain remote access**: Ensure that, as a partner, you have remote access to the customer's system for effective troubleshooting and support.

## Proactive support

- Keep setups healthy and up to date.
- Guide and motivate end users to resolve any setup-specific problems.

  > [!TIP]
  > Running the [DataMiner BPAs](xref:Running_BPA_tests) can assist in this process.

## Reactive support

### Level 1 - Identification

- Determine the impact and severity of the issue.
- Determine (as much as possible) whether the issue is not the result of a configuration change, an infrastructure issue or an external issue (e.g., network connection, external data source no longer sending expected data, etc.).
- Determine the general health of the setup. Is there enough disk space? Is there something that is consuming the processing time? Etc.
- Determine (as much as possible) when the problem occurred. What actions were taken? At what frequency does the problem occur? Have any changes been made recently? Etc.
- Define (as much as possible) how the issue can be reproduced.
- Determine the type of the issue. Is the issue integration-specific (custom) or related to a DataMiner component provided by Skyline?
- Collect basic information/logs based on the type of issue and component.

#### Minimum required skills and knowledge for Level 1

- DataMiner knowledge:

  - Certification – [DataMiner Fundamentals](https://community.dataminer.services/learning/certification/dataminer-operator/)
  - Certification – [DataMiner Configurator](https://community.dataminer.services/learning/certification/dataminer-administrator/)

- Guides:
  
  - [Collecting data to report an issue to Technical Support](xref:Collecting_data_to_report_an_issue_to_TechSupport)
  - Health check: [Troubleshooting: Where to start?](xref:Troubleshooting_Where_to_Start)

- Extra tools:

  - [DataMiner Collaboration](https://collaboration.dataminer.services/)
  - [DataMiner Dojo community - Q&A](https://community.dataminer.services/questions/)
  - Log collector: [Collecting data to report an issue to Technical Support](xref:Collecting_data_to_report_an_issue_to_TechSupport)

### Level 2 - Investigation

- Check whether the latest version is being used.
- Check whether the issue is known and/or already solved in a newer version.
- Navigate through the log files associated with the solution or DataMiner component.
- Determine what is still working and what fails. Follow any clues you find in the log files.
- ...
- When required, and when a support contract exists, report what has already been investigated and hand over the investigation to Skyline.

  - A good and effective communication flow is expected between the different parties in order to get to a solution as fast as possible.
  - When applicable, provide documentation on the usage and architecture (i.e., inner workings) of the custom solution.

#### Minimum required skills and knowledge for Level 2

All [minimum required skills and knowledge for Level 1](#minimum-required-skills-and-knowledge-for-level-1), with the addition of the following:

- DataMiner Knowledge:

  - Keep up to date with the DataMiner documentation and the DataMiner Community. For example, use the Q&A section on Dojo to reach out to an expert.
  - High level knowledge of the DataMiner architecture (What is the purpose of the different modules and processes?)
  - High level knowledge of the advanced functionalities of DataMiner. See [Administrator guide](xref:Administrator_guide)

- Guides:

  - [Consulting the DataMiner logs in DataMiner Cube](xref:Consulting_the_DataMiner_logs_in_DataMiner_Cube)
  - [Troubleshooting flowcharts](xref:Troubleshooting_Flowcharts)
  - [Troubleshooting procedures](xref:Troubleshooting_procedures)
  - [Known issues](xref:Known_issues)

- (Custom) Solution:

  - High level (custom) solution architecture and usage

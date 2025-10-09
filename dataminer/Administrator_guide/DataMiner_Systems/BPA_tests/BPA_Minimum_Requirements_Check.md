---
uid: BPA_Minimum_Requirements_Check
---

# DataMiner Agent Minimum Requirements

Prior to DataMiner 10.4.12/10.5.0<!--RN 40751-->, this BPA test is called "Minimum Requirements Check".

This BPA test checks if the following minimum hardware requirements are met or exceeded, via local WMI queries using .NET Libraries:

- CPU cores (physical): 4
- Disk size:

  - Main installation (C:\\): 128 GB
  - Cassandra installation (D:\\ or other): 600 GB

- Disk usage: Less than 50% on Cassandra drive.
- System memory: 16 GB

This BPA test is available by default from DataMiner 10.1.0 [CU4]/10.1.7 onwards.

 > [!NOTE]
  > From DataMiner 10.6.0 [CU0]/10.5.12 onwards, this BPA test its disk and RAM requirements have been reduced. Prior to DataMiner 10.6.0 [CU0]/10.5.12, this BPA test required 300GB Disk size for the main installation and 32GB of system memory.

For more information on system requirements, see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

If you are using a [DaaS system](xref:Creating_a_DMS_in_the_cloud), your entire DataMiner setup is automatically configured for optimal performance. As such, this BPA test cannot be run on a DaaS system. From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards<!--RN 39929-->, this BPA test will by default have the status *Not applicable* on a DaaS system.

## Metadata

- Name: DataMiner Agent Minimum Requirements
- Description: Uses WMI queries to verify that the system meets the minimum requirements for DataMiner.
- Author: Skyline Communications
- Default schedule: Every hour

## Results

### Success

`Test succeeded: System meets all minimum requirements.`

The system meets or exceeds all minimum requirements.

### Error

`X of 5 minimum requirements were not met. See detailed result to obtain more information.`

One or more of the minimum requirements is not met.

The detailed JSON output of the BPA will contain the following possible messages, depending on which requirements are not met:

- CPU cores: `Failed CPU Check: X cores available, 4 are required.` or `Passed CPU Check: X cores available, 4 are required.` (where X is the number of physical cores in the system).

- Disk size (main): `Failed Main Installation Disk Size Check: Disk X has Y GB, 128 GB is required.` or `Passed Main Installation Disk Size Check: Disk X has Y GB, 128 GB is required.` (where X is the installed disk and Y is the total volume of the disk).

- Disk size (database): `Failed Database Disk Size Check: Disk X has Y GB, 600 GB is required.` or `Passed Database Disk Size Check: Disk X has Y GB, 600 GB is required.` (where X is the disk on which DataMiner is installed and Y is the total volume of the disk).

- Disk free space: `Failed Database Disk Free Space Check: Disk X has Y % Available Free Space. 50% or more is required.` or `Passed Database Disk Free Space Check: Disk X has Y % Available Free Space. 50% or more is required.` (where X is the disk on which Cassandra is installed, and Y is its free space).

- Memory: `Failed Memory Check: The system has X GB Total Visible Memory, 16 GB is required.` or `Passed Memory Check: The system has X GB Total Visible Memory, 16 GB is required.` (where X is the visible memory, as seen in the control panel).

### Warning

This BPA does not generate warnings.

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

## Limitations

- The BPA only checks if the minimum requirements to run a DataMiner Agent are met. It only checks if the system has the bare minimum to be able to operate, not if it has adequate resources for its load.
- The BPA uses standard WMI querying in order to retrieve information. This must be enabled and functional in order for the test to run.

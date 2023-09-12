---
uid: Connector_help_ATT_Job_Manager
---

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<tbody>
<tr class="header">
<th></th>
</tr>
&#10;<tr class="odd">
<td><h1 id="att-job-manager">ATT Job Manager</h1>
<p>The <strong>ATT Job Manager</strong> protocol is a virtual driver used to execute <strong>Automation Scripts (Jobs)</strong> when certain conditions are met. It works together with the <strong>ATT Channel Manager</strong> protocol (version 1.0.1.9 and later). <strong>The ATT Job Manager</strong> listens for notifications from the <strong>ATT Channel Manager</strong> and executes <strong>Automation Scripts</strong> in response.</p>
<h2 id="about">About</h2>
<p>The <strong>ATT Job Manager</strong> allows registering <strong>Automation Scripts (Jobs)</strong> that accept at least three input parameters: <strong>Command</strong>, <strong>Result</strong> and <strong>Feedback</strong>. It's possible to create a wide variety of jobs and assign them to a specific trigger. The driver will automatically execute the registered <strong>Jobs</strong> when a matching notification is received.</p>
<p>The <strong>Command</strong> parameter is used to send information to the Automation Script.</p>
<p>The <strong>Result</strong> parameter is a numeric value used to notify the ATT Job Manager about execution result of the Automation Script and can be:</p>
<p><strong>Failed</strong> = 2, <strong>Succeeded</strong> = 3</p>
<p>The <strong>Feedback</strong> parameter is used to send information from the Script to the ATT Job Manager about the possible cause of the Automation Script failure, and it will be displayed in the Queue Table.</p>
<h3 id="ranges-of-the-driver">Ranges of the driver</h3>
<table>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td>Initial version</td>
<td>No</td>
<td>Yes</td>
</tr>
</tbody>
</table>
<h2 id="installation-and-configuration">Installation and configuration</h2>
<h3 id="creation">Creation</h3>
<h4 id="virtual-connection">Virtual connection</h4>
<p>This driver uses a virtual connection and does not require any input during element creation.</p>
<h2 id="usage">Usage</h2>
<h3 id="jobs">Jobs</h3>
<p>The <strong>Jobs</strong> <em></em> page contains a table with all of the available <strong>Jobs</strong>. Using a context menu it's possible to add new <strong>Jobs</strong> or remove existing <strong>Jobs</strong>.</p>
<h3 id="queue">Queue</h3>
<p>The <strong>Queue</strong> page contains a table with all of the enqueued <strong>Jobs</strong> to be executed. <strong>Jobs</strong> in the queue are executed sequentially. The time interval between the execution of two jobs can be configured. Using the buttons <strong>Remove</strong> and <strong>Execute Now</strong> it is possible to delete <strong>Jobs</strong> from the queue or execute them without waiting for the execution interval.</p>
<h3 id="executed-jobs">Executed Jobs</h3>
<p>The <strong>Executed Jobs</strong> page contains a table with all of the enqueued <strong>Jobs</strong> that were executed with success. <strong>Jobs</strong> in this table can be removed manually. This table implements an <strong>Auto Cleanup</strong> functionality that can be configured using a pop-up page.</p>
<h3 id="failed-jobs">Failed Jobs</h3>
<p>The <strong>Failed Jobs</strong> page contains a table with all of the enqueued <strong>Jobs</strong> that failed to execute. <strong>Jobs</strong> in this table can be executed manually or permanently deleted. This table implements an <strong>Auto Cleanup</strong> functionality that can be configured using a pop-up page.</p>
<h2 id="notes">Notes</h2>
The <strong>ATT Job Manager</strong> works together with the <strong>ATT Channel Manager</strong> protocol and certain <strong>Automation Scripts</strong>, for example: <strong>Script_ATT IPX Update_V2</strong></td>
</tr>
</tbody>
</table>

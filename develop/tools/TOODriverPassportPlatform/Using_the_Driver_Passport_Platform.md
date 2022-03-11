---
uid: Using_the_Driver_Passport_Platform
---

# Using the Driver Passport Platform

To access the platform, go to <cube://slc-h57-g02.skyline.local?element=%22Driver%20Passport%20Platform%22> and log on using your domain credentials. Then go to DataMiner Apps in the Cube sidebar and select *Driver Passport Platform*.

The *Overview* page of the platform contains two tabs, *Overview* and *Finished*.

- On the *Overview* tab, a table provides an overview of all currently running tests.

    The *Platform Health* parameter indicates the state of the platform. When tests can be executed properly, the state is *OK*. When for example the test server is not reachable, the state is *Blocked*. In case the state is *Blocked*, no new executions will be started until the platform health is OK again.     To get an idea of how much content is available in the queue, you can check the *Queue Count* and *Queue Expected Duration* parameters. These indicate the number of tests included and the amount of time before the queue will be empty, respectively.

- On the *Finished* tab, two tables provide an overview of the successfully executed tests and of the tests that encountered an execution error (e.g. server restarted, elements not active).

    The parameters *Tests Executed Pass Count* and *Tests Executed Failure Count* indicate how many tests have been executed where all execution steps passed, and how many tests have failed.     *Test Execution Error Count* indicates the number of tests that could not be executed because of an error during execution.

The *Scheduler* page allows you to create tests. To do so:

1. Create a DMT package (for a scaling test) and upload it via DataMiner Documents in the folder *Skyline Driver Passport Platform\\Packages*.

    DMT packages should be created according to these guidelines:

    - Number of Packages: 2

    - Element Scaling Increment: 50 (depending on the number of connections)

    - Duration: 25h

    - Interval: 10m.

    For more information on how to create a DMT package with these settings, refer to [DataMiner Application Package Builder](xref:TOODataMinerPackageBuilder#dataminer-application-package-builder).

2. In the *Driver Passport Platform* app, go to *Scheduler*.

3. In the *New Test Package* drop-down list, select *Refresh List*. This will update the drop-down list with the most recently uploaded packages.

4. In the *New Test Package* drop-down list, select your package.

5. Specify your email address in the *Notification E-Mail Address* box. (See [Notifications](xref:Notifications).)

6. Click the *Schedule* button. The test will now be added to the queue.

> [!NOTE]
> When you schedule a test, keep the limitations of the platform capabilities in mind. See [Platform capabilities](xref:Platform_capabilities).
>

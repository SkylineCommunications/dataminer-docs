---
uid: Connector_help_UPC_Nederland_Witbe_Management_System
---

# UPC Nederland Witbe Management System

The UPC Nederland Witbe Management System is a **virtual** element that does not connect to a device, but manages other elements on the DMA.

## About

This connector was designed to work closely together with the **SmartRec App** and **Witbe Robot** connectors. Its main function is to queue tests on different **Witbe Robots** depending on **Assets** that were added from different connectors in one of five **Carousels** (tables holding assets). The results of the tests, which are run simultaneously on separate Robots, are correlated and sent to the **SmartRec App**.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any user information.

### Configuration of the Manager

Go to the **Robots** page:

1. Check that all **Robots** and the **SmartRec App** have been detected in the system and added. If not, click **Retrieve Elements.**

1. **Enable** or **Disable** the **Robots** that need to be available to the Manager with the **In Use** column.

1. **Group** all **Robots** with the same tests together in a **Test Set**.

   Note: You always need to define a **Test Set**, as otherwise the Manager will **ignore** the Robot. A **Set ID** must always be provided, even if there is only a single Robot in a particular set.

1. Either wait a few minutes until all the **Robots** have sent back an **OK**, or force the process to go more quickly by clicking **Check Elements**, waiting a few seconds, and then clicking **Check Elements** again.

1. Enter the **SmartRec Return PID**. This is the parameter used on the **SmartRec** that will receive **Correlated Responses** sent by the Manager.

Go to the **Tests** Page:

- Click **Get Set Tests**.

  > [!NOTE]
  >
  > - This table can only be filled in if **Robots** have been added to **Sets**.
  > - Only the **first 'OK' Robot** in a **Set Group** is asked to return its available **Tests**. Make sure all Robots in a set have the same tests.

Go to **Test Configuration**:

1. Select a specific test for each **Generic Test** on this page (*1A, 1B, 1C*, ...).

1. **Enable** or **Disable** each **Cyclic SET Check**.

## Usage

### Commands

This page contains the **Current State** of the **SET 1**, **SET 2** and **SET 3** cycles, and displays if **Debug Logging** is *Enabled* or *Disabled*. If the latter is *Enabled*, additional logging will be added to the **Element Log** so that it is possible to follow every step the connector goes through.

The **Received Commands table** contains every command that is received from an external element and needs to wait for a response to be sent back. This table also contains a row for the **SET 1** and **SET 2** test cycles. In the case of SET 1 and SET 2, the **Command Parameters** column will hold the current **Running Test** of the **Cyclic Test.**

The **Sent Commands table** contains every command that is sent to the **Witbe Robots**. The **Status** indicates if the Manager is *Waiting* for a response*,* if the response has been *Received*, if there was an *Error* or *Timeout,* and finally, if all processing is *Finished* for this command.

### Test Configuration

This page displays every **Test Cycle**, with information related to it. It also indicates whether each **Cycle** is *Running*.

### Robots

This page contains every **Detected Robot in** the system. It displays whether the element is in *Time-Out* or *Not Responding* to Keep Alives (**Element Stopped, Paused** or **Crashed**). It also contains information about the **SmartRec App** and shows if it is present in the system.

If **Remote ElementPolling** is *Disabled*, the **Robots** will no longer get polled with **Keep Alive Messages** and the DataMiner System will not get polled for the **SmartRec App** and **all Robot connectors**.

### Tests

The **Tests Table** contains every detected test of every single **Robot Set** (Group) selected in the **Robots Table.** It also contains all **Error Tracking Information**, indicating if a script has failed multiple times for different assets in the same step.

### Carousels

**Carousel Alpha, Bravo, Charley, Delta, Echo** will contain every **Asset** that was received from **External Elements.**

Carousel **Alpha** also contains the **Asset (A) Selection Interval**, indicating the maximum amount of time to wait before an asset from the same channel can be used in a test again.

Carousel **Bravo** also contains the **Asset (B) Deletion Interval**, indicating the maximum lifetime of an asset. If it exceeds this configured time, the asset will be removed from Carousel Bravo.

Carousel **Delta** also contains the **Asset D Return Address**. If you fill in a string with the format "DataMinerID/ElementID/ParameterID" all results coming from Delta assets will return to this address instead of the default SmartRec address.

Carousel **Echo** is the only collection of assets that is **directly** **polled** from the **SmartRec App** and does not require commands to be filled in. It contains the complete **OTT Channel Lineup** and is used for the tests in **SET 3.** **Test 3A** is run on all OTT Channels one by one. You can force test 3C to run on an asset in Echo Carousel by clicking the **Force Test 3C button.**

## Notes

This connector was created to communicate with multiple other elements using a special **API** containing commands that can be found in ***QA 63900.***
The Valid **Commands** are:

- **RefreshChannels**
- **QueueTest3B**
- **AddToCarouselAlpha**
- **AddToCarouselBravo**
- **AddToCarouselCharley**
- **AddToCarouselDelta**
- **AddToCarouselEcho**
- **RemoveFromCarousel**
- **MoveToCarousel**

Because **XML-Serialization** is used for internal buffering and inter-element communication, it is recommended to use .**NET4.5** on the system running this connector.

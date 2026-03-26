---
uid: Debugging_an_Automation_script
---

# Debugging an automation script

When you have finished configuring all necessary settings, you can start debugging.

1. In the *DIS* menu, go to *DMA \> Connect*, and select the DataMiner Agent to which you want DIS to connect.

1. Import the automation script. In the *DIS* menu, select *DMA \> Import Automation script*, select an automation script, and click *Import*.

1. In the XML editor, go to the Exe block that you want to debug, and click the *Edit C#* button in front of it to open the Exe block in a C# editor.

1. In the C# editor, set the necessary breakpoints.

1. In the *DIS* menu, select *Tool Windows \> DIS Inject* to open the *DIS Inject* window.

1. Select the *Automation script* tab.

1. Open the large selection box at the top of the window, and select the automation script that you want to debug.

1. In the Exe blocks list:

    1. Go to the row of which the Exe ID matches that of the Exe block you have opened.

    1. If necessary, in the *Project* column, select another temporary Exe block project.

1. In the script parameters list, assign a value to each of the script parameters in the list.

1. In the script dummies list, link a DataMiner element to each of the script dummies in the list.

1. Click the *Attach* button to build all temporary Exe block projects and attach the Microsoft Visual Studio Debugger to the DataMiner SLAutomation process.

1. In the *DIS Inject* window, click Execute to manually trigger the automation script.

> [!NOTE]
> Automation script debugging currently does not support memory files yet.

> [!TIP]
> Debugging is often not possible for [third-party libraries](xref:TOONuGet). [dotPeek](xref:dotPeek) can serve as a handy tool to overcome this.

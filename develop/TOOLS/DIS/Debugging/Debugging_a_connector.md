---
uid: Debugging_a_connector
---

# Debugging a connector

When you have finished configuring all necessary settings, you can start debugging.

1. In the *DIS* menu, go to *DMA \> Connect*, and select the DataMiner Agent to which you want DIS to connect.
1. Import the protocol. In the *DIS* menu, select *DMA \> Import Protocol*, select a protocol and a version, and click *Import*.
1. In the XML editor, go to the QAction that you want to debug, and click the *Edit C#* button in front of it to open the QAction in a C# editor.
1. In the C# editor, set the necessary breakpoints.
1. In the *DIS* menu, select *Tool Windows \> DIS Inject* to open the *DIS Inject* window.
1. Select the *Protocol* tab.
1. Open the large selection box at the top of the window, and select an element that uses the exact same protocol as the one you are currently editing.
1. In the QAction list:

    1. Go to the row of which the QAction ID matches that of the QAction you have opened.
    1. If necessary, in the *Project* column, select another temporary QAction project.
    1. Click the green plus to replace (i.e. inject) the element's QAction.dll file (compiled in Release mode) with its counterpart found in the temporary QAction project (compiled in Debug mode).

1. Click the *Attach* button to build all temporary QAction projects and attach the Microsoft Visual Studio Debugger to the DataMiner SLScripting process.
1. In the *DIS Inject* window, click the yellow lightning bolt to manually trigger the QAction by simulating a change of the parameter selected in the *Trigger ID* box (in case of a dynamic table parameter, use the *Trigger Key* box to specify the table row).

    > [!NOTE]
    > - Instead of clicking the yellow lightning bolt, you can also open DataMiner Cube, connect to the DataMiner Agent to which DIS is connected, and perform an action in the user interface that triggers the QAction you are debugging.
    > - When a QAction refers to another QAction in a DllImport attribute, then that referenced QAction will now also automatically be injected when you debug a protocol in DIS.

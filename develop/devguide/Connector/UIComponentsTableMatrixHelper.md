---
uid: UIComponentsTableMatrixHelper
---

# Matrix Helper

To manipulate the inputs and outputs tables, we recommend using the matrix helper, especially for bigger matrices. This is a helper in DataMiner Integration Studio that you can add to the protocol by running the Matrix macro in DIS. With the helper, you can manipulate the matrix in an easy and consistent manner without having to do the table manipulations yourself.

In the generated macro, use the *TableMatrixHelper* class. This class can read out the mappings of the dummy parameter.

To create an instance of the helper, fill in the following parameters in the constructor:

```csharp
public TableMatrixHelper(SLProtocol protocol, int matrixDummyParameterId,
   int matrixTablesVirtualSetsParameterId, int matrixTablesSerializedSetsParameterId,
   int matrixConnectionsBufferParameterId = -2, int matrixSerializedParameterID = -2,
   int maxInputCount = 0, int maxOutputCount = 0)
```

Once an instance has been created, you can manipulate the matrix with the helper instance as follows:

```csharp
matrix.Inputs[i].Label = "Input " + (i + 1);
matrix.Inputs[i].IsEnabled = true;
matrix.Inputs[i].IsLocked = false;
matrix.Inputs[i].Page = "Page" + (i / 10 + 1);

matrix.Outputs[i].Label = "Output " + (i + 1);
matrix.Outputs[i].IsEnabled = true;
matrix.Outputs[i].IsLocked = false;
matrix.Outputs[i].Page = "Page" + (i / 10 + 1);
matrix.Outputs[i].ToolTip = "Tooltip " + (i + 1);

matrix.Outputs[i].Connect(i);

matrix.ApplyChanges(protocol);
```

Every time a user makes a change to the matrix in the UI, this will trigger one of the override methods, depending on the action. This way, data can be sent to the device.

Example:

```csharp
/// <summary>
/// Gets triggered when crosspoint connections are changed.
/// </summary>
/// <param name = "set">Information about the changed crosspoint connections.</param>
protected override void OnCrossPointsSetFromUI(MatrixCrossPointsSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when the label of an input or output is changed.
/// </summary>
/// <param name = "set">Information about the changed label.</param>
protected override void OnLabelSetFromUI(MatrixLabelSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input or output is locked or unlocked.
/// </summary>
/// <param name = "set">Information about the changed lock.</param>
protected override void OnLockSetFromUI(MatrixLockSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input or output is enabled or disabled.
/// </summary>
/// <param name = "set">Information about the changed state.</param>
protected override void OnStateSetFromUI(MatrixIOStateSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when a crosspoint tooltip is changed
/// </summary>
/// <param name = "set">Information about the changed tooltip.</param>
protected override void OnToolTipSetFromUI(MatrixToolTipSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when an input/output page is changed
/// </summary>
/// <param name = "set">Information about the changed page.</param>
protected override void OnPageSetFromUI(MatrixPageSetFromUIMessage set)
{
}

/// <summary>
/// Gets triggered when crosspoint connections are changed via the lockOverride parameter.
/// </summary>
/// <param name = "set">Information about the changed crosspoint connections.</param>
protected override void OnCrossPointsSetViaLockOverrideFromUI(MatrixCrossPointsSetFromUIMessage set)
{
}
```

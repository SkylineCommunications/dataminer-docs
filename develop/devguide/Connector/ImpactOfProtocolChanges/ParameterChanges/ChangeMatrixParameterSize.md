---
uid: ChangeMatrixParameterSize
---

# Change matrix parameter size

Changing the size of a matrix is considered a major change.

> [!NOTE]
> When the goal is to reduce the size, you should do this via the existing implemented calls (Matrix Helper).
> In case you want to increase the size, there will be impact (Discreets are shifting). See [Actions to be taken](#actions-to-be-taken).

*DIS MCC*

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 2.21.2  | MatrixDimensionsChanged | Matrix Dimensions on Param '{matrixPid}' was changed from '{oldDimensions}' to '{newDimensions}'. |
| 2.21.3  | MatrixDimensionsRemoved | Matrix Dimensions '{matrixDimensions}' on Param '{matrixPid}' were removed. |

## Impact

Saved labels can get shifted when the number of input changes. The output labels could appear now as input label in this case.

The highest added discreet values that did not exist before will not be added to the XML file, so it will not be possible to modify those label values.

Remote sets from other elements will fail (using discreet).

Performance impact for a bigger matrix.

## Actions to be taken

Change the name of the *label.xml* file so the old file will not be overwritten.

It is advised to keep standard naming format like *matrixconfigV1.xml*, *matrixconfigV2.xml* and so on.

Remote sets from other elements will still fail (using discreet).

For settings (e.g. labels) that are read out from the device all updates will be done automatically. But for those that are not read out from the device (e.g. locking) a manual action will be needed to recover the previous settings.

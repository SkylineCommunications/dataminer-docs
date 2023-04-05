---
uid: UIComponentsMatrixComposingCrosspoints
---

# Composing crosspoints on matrix parameters

To set the matrix crosspoints, a QAction is used.

- SetParameterIndex(matrixPid, input number, output number, value) to set or remove a crosspoint.
- SendToDisplay(matrixID) to update the matrix on the display.

The current crosspoint configuration of the matrix needs to be stored into a buffer parameter in order to easily capture changes by the matrix device. This is to prevent wrong crosspoint indications on the display. The buffer is composed of a semicolon-separated string containing e.g. the input values, and the position is then the corresponding output. (This might be vice versa depending on how the device returns data.)

This buffer is then processed in combination with the current status returned by the device to remove old invalid crosspoints from the matrix (by setting these to 0).

Try to reduce the number of SendToDisplay method calls when writing a matrix, as this has a big impact on the SLElement process. If not handled carefully, you may encounter issues as a consequence of the number of sets being increased drastically (e.g. the VM size of SLElement may increase drastically).

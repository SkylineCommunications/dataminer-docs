---
uid: UIComponentsMatrixDis
---

# Matrix development using DIS

DIS provides ways to more easily handle a matrix and/or router control table.

The Matrix macros can be used to quick-start a new matrix.

The Matrix class in the class library can be used to more easily communicate with an existing matrix.

## Matrix macros

There is a new macro "CreateMatrix" in the DIS Macros folder: Protocols.Matrix.

This macro will generate all the necessary parameters and QActions to get you started. Together with the Matrix class in the Class Library, this should create an initial framework to quickly build a matrix.

The macro can create:

- A matrix and tables showing inputs and outputs, all synced with each other.
- A matrix only.
- The input and output tables only.

It has a small wizard that asks for specific configuration data, such as:

- Maximum number of inputs and outputs.
- Start parameter ID for matrix.
- Matrix description tag value.
- Start parameter ID for input table.
- Input table description tag value.
- Start parameter ID for output table.
- Output table description tag value.

It will then generate the matrix and tables alongside two QActions (depending on the configuration):

- Matrix Modifications
- Writes on Router Control Tables

> [!NOTE]
> The Matrix Modifications QAction requires the class library to function, so make sure you generate the correct class library classes or have the Automatically generate Class Library code option enabled under DIS Settings.

The Modifications QAction provides an initial framework that now needs to be completed based on your requirements.

Anything that needs to access the matrix or router tables should now go to this QAction. It contains a Matrix instance stored in SLScripting memory that will keep track of changes and makes sure all sets and gets are happening as efficiently as possible. This class comes from the class library and more information about this can be found in the section Class library - Matrix class .

Detailed examples of how to use this on a real device can be found in the Protocol Development Guide Companion Files.

- Matrix + tables: SLC SDF Matrix, range 1.0.0.X.
- Only matrix: SLC SDF Matrix, range 1.0.1.X.
- Only tables: SLC SDF Matrix, range 1.0.2.X.

A few key items to remember:

- Overridden methods in the Matrix class are called based on the incoming trigger. This is handled automatically within the method ProcessParameterSetFromUI.
- Crosspoint connections can only be made on the outputs.
- Any changes you make to the matrix have to be applied by calling "ApplyChanges".
- Remember to check for every TODO command and apply any logic you need.
- Remember that you can add triggers and switch-cases to parse incoming data from device communication if it needs to be applied to the matrix or router control tables.

## Class library - Matrix class

The matrix library provides 3 classes that a developer can inherit from:

- MatrixHelperForTables
- MatrixHelperForMatrix
- MatrixHelperForMatrixAndTables

See also:

Skyline.DataMiner.Core.Matrix namespace

Depending on the user requirements, you will likely create your own class inheriting from one of these.

The instance of this class has to be saved through the use of an instanced QAction.

> [!NOTE]
>
> - Do not save your instance as a static field. Its correct function is dependent on the instanced QAction functionality.
> - If you add the SLProtocol object as a field or property in your child class, it is extremely important that this is overwritten by the correct SLProtocol object as provided by the run method every time. It is not allowed to store the SLProtocol object in memory and re-use it.

A recommended way of working is to create a MatrixStorage class that will internally handle creating a new Matrix class instance and always updates the SLProtocol object.

```csharp
public sealed class MatrixStorage
{
    private Matrix matrix;

    /// <summary>
    /// Gets the Matrix object. Calls the constructor if needed and makes sure the SLProtocol object is up to date.
    /// </summary>
    /// <param name="protocol">Link with Skyline DataMiner.</param>
    /// <returns>Matrix object.</returns>
    public Matrix GetMatrix(SLProtocol protocol)
    {
      if (matrix == null)
      {
          matrix = new Matrix(protocol);
      }
      else
      {
        matrix.SetProtocol(protocol);
      }
    
      return matrix;
    }
}
```

### Constructors

The constructors can be provided with detailed parameter information that links to the right discreet info parameter, matrix parameter, input/output table parameters, etc.

Alternatively, you can use a less detailed constructor that has fewer arguments. This will automatically try to find the right parameters in the protocol.xml.

It is recommended to only use this when generating the tables using the DIS macro, as the automatic search has strict naming requirements.

Automatic ID searching will be done by checking the last parts of the Name tag value in:

- All string measurement parameters for:
  - "connectedinput"
  - "label"
- All write string measurement parameters for:
  - "virtualsets"
  - "serializedsets"
- All read parameters with measurement type discreet or toggle button for:
  - "isenabled"
  - "islocked"

These will indicate all the columns holding input or output labels, locks and states. The combinations of these are used to find the correct input and output tables.

Within the constructor for the MatrixHelperForMatrixAndTables, it is also possible to adjust the DisplayType to choose if you are only displaying the matrix or only the tables or both. By default, this is set to use MatrixAndTables. It is advisable to link this property to a parameter, so that the operator has the choice if they want to display the matrix and/or tables, and link this parameter to display a page or not. This way, the page with the component that is not used will be automatically hidden (see also SDF for the practical implementation of this).

### Override methods

Every child class should override and provide logic for the following methods:

- OnCrossPointsSetFromUI
- OnLabelSetFromUI
- OnLockSetFromUI
- OnStateSetFromUI

These methods are automatically called from the method ProcessParameterSetFromUI.

ProcessParameterSetFromUI should be called after the virtualsets, serializedsets, discreetInfo or matrix write parameters are triggered.

```csharp
switch (triggerParameter)
{
    case Parameter.Write.matrix_101:
    case 103:   // DiscreetInfo
    case Parameter.Write.routercontroloutputsvirtualsets_1160:
    case Parameter.Write.routercontroloutputsserializedsets_1161:
        _matrixStorage.GetMatrix(protocol).ProcessParameterSetFromUI(protocol, triggerParameter);
    break;
```

The overridden methods will handle all logic from crosspoint, label, lock or state sets from either the table or the matrix parameter.

### Available properties

The Matrix class you inherit from provides several properties that display the status of the matrix. You will find a collection of Outputs and a collection of Inputs to both get and pre-set data. (Pre-set because you need to call ApplyChanges before any actual sets happen.)

Every output and input will show the state, lock state and label.

Every output also shows the connected input and provides the ability to connect or disconnect.

### Connecting an input to an output

Connecting an input to an output can be done by calling the Connect method on the output. By default, the currently connected input will be replaced with the new input.

Connecting multiple inputs to one output can be done by specifying MatrixEditMode.Add in the Connect method. This way currently connected inputs will stay connected with the output. Note that connecting multiple inputs to one output can only be done when using the MatrixHelperForMatrix object. This is because Router Control tables only support one input per output. Using MatrixEditMode.Add on the Connect method of a MatrixHelperForMatrixAndTables object or on a MatrixHelperForTables object will throw an exception.

### Important notes

- Crosspoint connections can only be made on the outputs.
- Any changes you make to the matrix or tables have to be applied by calling ApplyChanges.
- When there are multiple matrix parameters in one protocol:
  - There can be only one "discreet info" parameter in a protocol, which means that the ProcessParameterSetFromUI method needs to be called on both MatrixHelper objects.
  - The constructor to provide the detailed parameter information needs to be used. As there are multiple matrix parameters in this case, the MatrixHelper object cannot be automatically linked to a matrix parameter and this needs to be linked through the constructor.

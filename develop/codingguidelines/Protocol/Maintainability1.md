---
uid: Maintainability1
---

# Maintainability

- In order to keep code maintainable, code that is reused in different QActions should be moved to a general QAction. The ID of this generic QAction should be 1.

    > [!NOTE]
    >
    > - Use the option "precompile", so the general QAction is compiled immediately. When using the code from QAction 1 in another QAction, the dllImport attribute value should have the following format: <br>*\[ProtocolName\].\[ProtocolVersion\].QAction.1.dll;*
    > - When a general QAction is used, consider using different namespaces to create logical groups of related functionality.

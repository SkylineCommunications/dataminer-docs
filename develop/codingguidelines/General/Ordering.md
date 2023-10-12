---
uid: Ordering
---

# Ordering

- Using directives must be placed within a namespace ([SA1200](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1200)).

- Elements at the file root level or within a namespace must be positioned in the following order ([SA1201](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1201)):

    1. extern alias directives

    2. using directives

    3. namespaces

    4. delegates

    5. enumerations

    6. interfaces

    7. structs

    8. classes

    Within a class, struct or interface, the following positioning must be applied:

    1. fields

    2. constructors

    3. finalizers (destructors)

    4. delegates

    5. events

    6. enumerations

    7. interfaces

    8. properties

    9. indexers

    10. methods

    11. structs

    12. classes

- Elements must be ordered by accessibility ([SA1202](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1202)). Adjacent elements of the same type must adhere to the following positioning:

    1. public

    2. internal

    3. protected internal

    4. protected

    5. private

- Constants must appear before fields ([SA1203](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1203)).

- Static elements must appear before instance elements ([SA1204](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1204)).

- Partial elements must declare access ([SA1205](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1205)).

- Declaration keywords must adhere to the following ordering scheme ([SA1206](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1206)):

    1. access modifiers

    2. static

    3. all other keywords

- The keyword *protected* must be positioned before the keyword *internal* when declaring a protected internal C# element ([SA1207](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1207)).

- Property accessors must adhere to the following ordering scheme ([SA1212](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1212)):

    1. get accessors

    2. set accessors

- Event accessors must adhere to the following ordering scheme ([SA123](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1213)):

    1. add accessor

    2. remove accessor

- Static read-only elements must appear before static non-read-only elements ([SA1214](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1214)).

- Instance read-only elements must appear before instance non-read-only elements ([SA1215](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1215)).

- System using directives must be placed before other using directives ([SA1208](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1208)).

- Using alias directives must be placed after other using directives ([SA1209](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1209)).

- Using directives must be ordered alphabetically by namespace ([SA1210](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1210)).

- Using alias directives must be ordered alphabetically by alias name ([SA1211](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1211)).

    > [!NOTE]
    >
    > -  In Visual Studio, you can easily sort the using directives by positioning the cursor on a using directive in the code editor and selecting *Organize Usings* > *Sort Usings* from the context menu. In case you want to also remove unnecessary using directives, select *Organize Usings* > *Remove and Sort Usings* from the context menu.
    > -  In order to let Visual Studio put System directives first when sorting namespaces, go to *Tools* > *Options*. In the list on the left, go to *Text Editor* > *C#* > *Advanced* and select the checkbox *Place 'System' directives first when sorting usings*.
    > -  If "#define" preprocessor directives are used, make sure they are present and not commented out when using the above. Failing to do so can cause quick action build failures.

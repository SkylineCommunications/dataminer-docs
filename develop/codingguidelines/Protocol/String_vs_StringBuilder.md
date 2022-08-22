---
uid: String_vs_StringBuilder
---

# String vs. StringBuilder

String objects are immutable (i.e. they cannot be modified after they have been created). This means that all String methods and C# operators, while appearing to modify a string, actually return the result in a new string object.

Therefore, when a String object will be modified frequently, the use of a StringBuilder instance should be considered. The MSDN documentation for the StringBuilder class states the following:

Although the StringBuilder class generally offers better performance than the String class, String should not automatically be replaced with StringBuilder whenever a string manipulation is needed. Performance depends on the size of the string, the amount of memory to be allocated for the new string, the system on which the application is executing, and the type of operation. You should be prepared to test your app to determine whether StringBuilder actually offers a significant performance improvement.

> [!TIP]
> See also:
> <https://msdn.microsoft.com/En-Us/library/system.text.stringbuilder(v=vs.110).aspx>

Consider using the String class under the following conditions:

- When the number of changes that the application will make to a string is small. In these cases, StringBuilder might offer negligible or no performance improvement over String.

- When a fixed number of concatenation operations are performed, particularly with string literals. In this case, the compiler might combine the concatenation operations into a single operation.

- When extensive search operations have to be performed while building the string. The StringBuilder class lacks search methods such as IndexOf or StartsWith. For these operations, the StringBuilder object has to be converted to a String, and this can negate the performance benefit from using StringBuilder. For more information, see the section "Searching the text in a StringBuilder object" in the above-mentioned MSDN documentation.

Consider using the StringBuilder class under the following conditions:

- When the application is expected to make an unknown number of changes to a string at design time (e.g. when a loop is used to concatenate a random number of strings that contain user input).

- When the application is expected to make a significant number of changes to a string.

Also note that string literals can be split in order to improve readability. The compiler will concatenate the parts into a single string, so there is no runtime performance cost.

> [!NOTE]
> Often, code is needed in a protocol to generate a string that represents a list of items that are separated by a character or string (e.g. when using a parameter that uses the dependencyId attribute). An alternative implementation is to collect all items in a list (List\<T>) and then use the String.Join method (e.g. *string sDevices = string.Join(";", lsDevices);* ).
>

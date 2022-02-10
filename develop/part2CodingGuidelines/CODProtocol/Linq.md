---
uid: Linq
---

# Linq

- LINQ allows you to write compact and readable code. Though in some cases an alternative implementation can perform even better, LINQ is generally preferred as it will typically result in more readable and maintainable code than the alternative implementation. Only use other specific implementations when these outperform LIQ and the performance of the implementation has a major impact on the overall performance.

- A query is a set of instructions on how to retrieve and organize data. To execute the query, a call to its GetEnumerator method is required (deferred execution). This call is made when a foreach loop is used to iterate over the elements. To evaluate a query and store its results without executing a foreach loop, a ToList, ToArray, ToDictionary, or ToLookup should be called on the query variable.

    When looping over an IENumerable, a value is received from the source data one at a time. This can be very positive on total memory usage in case the data source is large and the data first needs to be filtered before being used.

	```cs
	XDocument xDocument = XDocument.Load(@"C:\...\Response.xml");
	var loopData = xDocument.Descendants().Where(p =>
	(p.Attribute("id")).Contains("i8"));

	foreach (var v in loopData)
	{
	   // Do something.
	   string x = v.TryGetAttribute("id");
	   int leng = x.Length;
	}
	```

    This is very efficient as the variable loopData will not contain a separate list with all filtered values. This means the data that is already loaded in the xDoc will not be saved somewhere else. This also means that the line below should in theory have no noticeable effect on memory or CPU when loopData is never called:

	```cs
	var loopData = xDocument.Descendants().Where(p =>
	(p.Attribute("id")).Contains("i8"));
	```

    However, this can have a negative impact on execution time in case the IEnumerable is used multiple times. The following example illustrates this:

	```cs
	IEnumerable<string> allKeysInXML = xDocument.Descendants("MonitorGroup").Select(p =>
	p.Attribute("DISPLAYNAME")).Distinct();

	var keysToRemove = keysInOriginal.Except(allKeysInXML);
	var keysToAdd = allKeysInXML.Except(keysInOriginal);
	```

    The excerpt above retrieves all the keys in the original that are not in the XML document and all the keys in the XML document that are not present in the original. The keys in the XML document are retrieved using LINQ. However, the IEnumerable is used twice in the statements following the LINQ query. Therefore, the following filter gets executed twice:

	```cs
	Descendants("MonitorGroup").Select(p => p.Attribute("DISPLAYNAME")).Distinct();
	```

    When a ToList() call is added, the filter will only be executed once, increasing performance (and, as already mentioned, increased memory usage).

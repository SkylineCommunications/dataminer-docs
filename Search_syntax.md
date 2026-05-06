---
uid: Advanced_Search_Syntax
---

# Advanced search syntax

The search functionality in the DataMiner documentation is powered by Azure AI Search. By default, it is configured to help you find relevant results even when your search terms are incomplete or slightly different from the indexed content.

The search uses [wildcard-based matching](https://learn.microsoft.com/en-us/azure/search/query-lucene-syntax#bkmk_wildcard) by default. However, it is still possible to use other types of syntax:

- Proximity search: Find terms that are near each other in a document by inserting a tilde `~` symbol at the end of a phrase followed by the number of words that create the proximity boundary.

  ```txt
  "updating time"~3
  ```

- Fuzzy search: Find matches in terms that have a similar construction by using the tilde `~` symbol at the end of a single word.

  ```txt
  connectr~
  ```

- ...

> [!TIP]
> See [Lucene query syntax in Azure AI Search](https://learn.microsoft.com/en-us/azure/search/query-lucene-syntax).

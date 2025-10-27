---
uid: Img_tags_referring_to_ASP_pages
---

# Img tags referring to ASP pages

On your website, you can show DataMiner report graphs by means of \<img> tags.

In those tags, you simply have to refer to ASP pages on your web server that will then request a report graph from the DataMiner Agent.

![](~/dataminer/images/reporter_graph_include.jpg)



A secret string shared by the DataMiner Agent and the web server is used as a means of authentication. The secret is passed along with every graph request, but only from web server to DataMiner Agent. It is never exposed on the public internet.

---
uid: Visual_overview_page_priority
---

# Visual overview page priority

When a visual overview is (re)loaded in DataMiner, the page to be displayed is determined in the following way (top-down):

1. If a visual overview is reloaded automatically (for example, after a save operation), the displayed page is the one that was last selected before the reload.

1. During a forward/back operation between visual overviews (for example, when navigating from one element to another), the displayed page is the page that was selected the last time a particular drawing was displayed.

1. If a visual overview is opened after you click a shape containing a link in which a particular page has been specified, then that particular page is displayed.

1. If a visual overview is opened after you click a shape containing a link in which no particular page has been specified, DataMiner will try to find a page in the current visual overview that has the same name as the page where the link was clicked.

1. If a default page selection was enforced when the Visio drawing was assigned, the default page is always displayed. See [Setting the active Visio file for an element, service, or view](xref:Set_as_active_Visio_file).

1. If no specific page could be determined by means of the above-mentioned rules, the first page of the visual overview is displayed.

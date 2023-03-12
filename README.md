# ThuyTienNguyen_C968_InventoryManagement
Assignment for WGU Software 1

WGU - C968 Software One - Inventory Management System

Inventory Management program in C#. The requirements are below.

I. User Interface

A C# application with a graphical user interface (GUI) based on the attached “GUI Mock-Up.”:

GUI Mock Up.docx

A. A Main Form, showing the following controls:

• buttons for “Add,” “Modify,” “Delete,” “Search” for parts and products, and “Exit”

• lists for parts and products

• text boxes for searching for parts and products

• title labels for parts, products, and the application title

B. An addPart form, showing the following controls:

• radio buttons for “In-House” and “Outsourced” parts

• buttons for “Save” and “Cancel”

• text boxes for ID, name, inventory level, price, max and min values, and company name or machine ID

• labels for ID, name, inventory level, price/cost, max and min values, the application title, and company name or machine ID

C. A modify part form, with fields that populate with data from an existing Part, showing the following controls:

• radio buttons for “In-House” and “Outsourced” parts

• buttons for “Save” and “Cancel”

• text boxes for ID, name, inventory level, price, max and min values, and company name or machine ID

• labels for ID, name, inventory level, price, max and min values, the application title, and company name or machine ID

D . Product form, showing the following controls:

• buttons for “Save,” “Cancel,” “Add” part, and “Delete” part

• text boxes for ID, name, inventory level, price, and max and min values

• labels for ID, name, inventory level, price, max and min values, and the application

• a grid view for all parts

• a grid view for parts associated with the product

• a “Search” button and a text field with an associated list for displaying the results of the search

E. A modify product form, with fields that populate with data from an existing product, showing the following controls:

• buttons for “Save,” “Cancel,” “Add” part, and “Delete” part

• text boxes for ID, name, inventory level, price, and max and min values

• labels for ID, name, inventory level, price, max and min values, and the application “all candidate parts”

• a grid view for parts associated with the product

• a “Search” button and a text box with associated list for displaying the results of the search

II. Application

F. classes and instance variables with the following criteria:

• five classes with the all associated properties

• variables are accessible/modifiable through properties

G. Functionalities to the main form:

• redirect the user to the “Add Part,” “Modify Part,” “Add Product,” or “Modify Product” forms

• delete a selected part or product from the grid view

• search for a part or product and display matching results

• exit the main form

H. Functionalities to the part forms:

“Add Part” form
• select “In-House” or “Outsourced”

• enter name, inventory level, price, max and min values, and company name or machine ID

• save the data and then redirect to the main form

• cancel or exit out of this form and go back to the main form

“Modify Part” form
• select “In-House” or “Outsourced”

• modify or change data values

• save modifications to the data and then redirect to the main form

• cancel or exit out of this form and go back to the main form

I. Functionalities to the product forms:

“Add Product” form
• enter name, inventory level, price, and max and min values

• save the data and then redirect to the main form

• associate one or more parts with a product

• remove or disassociate a part from a product

• cancel or exit out of this form and go back to the main form

“Modify Product” form
• modify or change data values

• save modifications to the data and then redirect to the main form

• associate one or more parts with a product

• remove or disassociate a part from a product

• cancel or exit out of this form and go back to the main form

J. Exception handling code:

• Detect non-numeric values in textboxes that expect numeric values

• Min should be less than Max; and Inv should be between those two values

• Prevent the user from deleting a product that has a Part associated with it

• Confirm “Delete” actions

UML Class Diagram.pdf

Toddler.Core
===============

Toddler currently exists as a Microsoft Access application operating on a local network Access Database.
Toddler.Core is the project concerned with implementing the .Net Core framework.  Toddler.Database is the only other module currently
in existence.  Currently Toddler.Core also contains the UI but that may eventually be broken out into it's own project.
Possibly after the finalization of Blazor.  The goal of Toddler is to re-create the functionality (and improve it) in a hosted
web application operating on a hosted SQL Server.  This will allow collaborative access to the database as well as the ability
to access and oeprate the application remotely.

Usage
----------------

The Toddler.Core project will essentially consists of three Single Page Applications each contributing a single track of business logic.
	*Clients
	*Data Entry
	*Planning

**Clients**

This sectionw will allow a user to add or remove client companies.  It will also allow the addition or modification
of Divisions, Stores, Departments and Classifications to those companies.  Some company metadata will also
be accessible and modifiable from this module including default product markup and fiscal year.

**Data Entry**

Here a user will be able to enter historic and current client records such as sales, receivings, markdowns, etc.  From
this module it will also be possible to input company expenses and company on order.

**Planning**

This module will provide an interface through which individual classification data will be displayed, allowing the user
to analyze trends and forecast sales, stock ratios and markdowns.
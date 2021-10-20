# ship-keep-co

*Various notes created during week of interview project development*

## Design Decisions/Challenges
* Challenges/Adaptations (for IRL project)
  * Striking balance between compact structure for getting functional code / segregating so that each class has single responsibility 
  * Spend additional time in the planning stage.
  * Deciding on project structure 
* Used CQRS pattern for a clear distinction between fetching and sending data.
* Separated projects in the API to denote clear segregation of responsibilities.
  * API holds controllers and initial app startup
  * Application project holds application logic.
  * Domain contains entities.
  * Infrastructure contains data interactions and integration with sql server.
* Each project handles its own dependency injection to clearly denote where dependencies are required.
* Implements hashIds package to provide the end user with a confirmation number which could be used in the future to import bookings once the user is registered and to mask the entity id from the end user
* Entity Framework Core is used as the ORM (Object-Relational Mapper) allowing interaction with the database through .net objects, improving readability as well as allowing for migration tracking and seeding of the database.
* Table structure prevents repeated data for items such as location and voyage.
* Store Latitude and Longitude in the locations table to indicate precise destinations and assist with future Google Maps integration.
  * Structure in anticipation of add/updating locations, voyages
* Imported the PrimeNG package for reusable and styled components.
* Angular routing implemented in conjunction with the confirmation number to allow customers to view old booking confirmations.
* Spare documentation & comments
  * Chose naming to be clear and indicate purpose

## Future Changes
* Most immediate objectives
  * Thorough unit test coverage.
  * Additional backend validation.
  * Add error text under invalid fields in the form.
  * Add a package for global error toasts.
  * Better experience for browsing destination/dates; analyze existing cruise line or other destination booking sites
* Add styling/guess brand theming
* Interception of data for handling common transformations
* Add base classes like BaseServiceAPI.ts
* Indicate the available locations when hovering over a calendar day.
* Additional configuration of database, such as string column size limits.
* Creating user account
  * With ability to link bookings to accounts by confirmation number
* Google maps integration
  * To display the possible departure and arrival locations
  * to display the trip the user will take on the confirmation page.
  * Indicate/group locations by voyage
* Booking confirmation list view
* Cleaner CSS organization for reuse
* Thorough documentation / commenting

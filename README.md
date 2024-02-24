# Customer Database API
## 0.0.5
### NOTE
- Reinitialed migration with more data
- Made Customer and Person have a 1 - 1 relationship

### REQUIREMENTS
Front end 
- Clear out the app.component html and typescript of anything involving weatherforecasting
 Add in a a new component called CustomerList
- Show the new component on the app.component.html
- Create a new angular service (information about services are found here in the documentation: Angular Dependency Injection OverviewLinks to an external site.)
- Add in methods for Create, Read, Update, and Delete. These methods require you to use an HttpClient (which may or may not be included in your module imports).
- Use the methods to populate a customer array property on the CustomerList component
- In the CustomerList component, display the first and last names of all customers in the database (a simple unordered html list is fine).

Backend:
- In your customer model backend project:
- Add a migration to capture your changes to the database structure.
- Update your database
- Manually add a few pieces of data to your database for testing
- Alternatively, I will add 25 points extra credit for adding a working seed data to the project.
- Scaffold a new controller for Customers
# 📰 Advertisement Storage Service

A robust and elegant service for storing and serving advertisements, architectured using the **Clean Architecture** principles. Developed using ASP.NET Core Web API, integrated with Entity Framework for seamless database operations, and complemented with a sleek client interface built on Vue3.

## 🏛 Clean Architecture:

Adhering to the principles of Clean Architecture, the solution is structured into separate layers with defined responsibilities. This ensures a high degree of maintainability, testability, and scalability, leading to a decoupled and agile system.

## 🌟 Features:

- **Efficient Pagination**: Ensures a clutter-free user experience by displaying 10 advertisements per page.
- **Advanced Sorting**: Offers sorting options for advertisements - by price (ascending/descending) or by creation date (ascending/descending).
- **Detailed View**: Provides complete advertisement details, highlighting the title, price, and the main image link.
- **Seamless Creation**: Facilitates effortless creation of new advertisements. Accepts multiple fields and swiftly returns the unique ID of the newly minted advertisement.

## 🛠 API Endpoints:

1. **Fetch List of Advertisements**: 
   - Pagination support, presenting 10 ads per page.
   - Options to sort by price or creation date.
2. **Fetch Specific Advertisement**: 
   - Retrieves essential information like the title, price, and main photo link of the chosen advertisement.
3. **Create a New Advertisement**:
   - Endpoints to submit details like the title, description, multiple image links, and price.
   - Responds with the ID of the freshly created advertisement and a status indicating success or an error.

## 📚 Tech Stack:

- **Backend**: 🌐 ASP.NET Core Web API
- **Database Operations**: 💽 Entity Framework
- **Frontend**: 🖥 Vue3

## 💡 Contributions:

Contributions are more than welcome! Feel free to fork this repository and open a pull request to suggest any changes. Every piece of feedback, whether it's about a bug or an enhancement, is invaluable to us!


# UdemyNLayerProject  

I prepared this project by watching Fatih Çakıroğlu's "[AspNet Core Web/API+Çok Katmanlı Mimari|Best Practices-Net6
](https://www.udemy.com/course/asp-net-core-api-web-cok-katmanli-mimari-api-best-practices/)" course on Udemy.  

 * The project was prepared with "Multi-layered architecture". The layers are sorted as "Core -> Repository -> Service/Caching -> API -> MVC" and each project references the previous layer.  
  
 * Designed models, DTOs to be used in the responses to the API, and Interfaces to be used for Repository, Service and UnitOfWork are located in the Core layer. Core is the starting layer, the central elements to be used in other layers are located in this layer.  
  
 * The repository layer is the layer used to manage interactions with the database. The database is designed with a code-first approach. In this layer, we have the DatabaseContext, Database configuration, migration, configuration files of the models, repository and UnitOfWork classes, and the files in which the initial data (Seed) we want to have as an example when the database is first created.  
  
 * In the Service layer, there are specific exceptions that we will use in our API project, the MapProfile class we created because we use Automapper, the Service classes that implement the IService interfaces in the Core, and the classes we created with FluentValidation for the validation of DTOs.


***
The project was organized in 3 different ways and saved as separate branches.

  1. In the main branch: (AspNetAPI-MVC) In the MVC project, the necessary information was transferred by communicating with the API and the information was successfully transferred to the frontend.

  2. In the AspNetAPI branch: It communicates with the API service layer and returns standardized answers from api controllers to endpoints. MVC project or a different frontend is not used in this branch.

  3. In the AspNetMVC branch: A basic front-end was created by communicating with the service layer in the MVC project and sending the necessary responses to the view from the MVC controllers.

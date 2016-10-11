Open Online Video Platform
=> ASP.NET MVC fundamental
=> Entity Framework(Code-first)
=> Forms
=> Validation
=> Build RESTful services(using web api)
=> Client side development(jQuery and ReactJS)
=> Authentication and Authorization(using identity framework)
=> Performance optimization(in the three tire)
=> Building and deployment
 


01. Add packages 
    => productivity power tools
    => web essentials
	
02. Add the model => Movie, add its controller and view 

// Adding a theme

03.  Go to http://bootswatch.com
      => select lumen theme 
	  => select bootstrap.css
	  => add it to the project
	  => rename it like as bootstrap-lumen.css
	  
04. ActionResult: An ActionResult is a return type of a controller method, also 
    called an action method, and serves as the base class for *Result classes. 
	Action methods return models to views, file streams, redirect to other controllers,
	or whatever is necessary for the task at hand 
	,,,
    	 public ActionResult Random()
        {
            var movie = new Movie() {Name = "Something"};
            return View(movie);
            //return new ViewResult(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new{page=1, sortBy="name"});
        }
    ,,,
	
	
05. Action Parameters: Which are the inputs for actions. When a request comes in an
    application, asp.net mvc automatically maps request data to parameter values for 
	action methods. If an action method takes a parameter, the mvc framework looks 
    for parameter with the same name with the request data. 	
	
	=> to make a parameter optional, make it null-able in the action method. In movies
	   controller
	   ```
	    public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Default text";
            return Content(String.Format("PageIndex= {0} & sortBy = {1}", pageIndex, sortBy));
        }
	    ```
		
		
06. Convention based routing/custom route: 
	    we want a url like this -> movies/Released/12/2
        in the RouteConfig.cs 
		
        ```
		 routes.MapRoute(
                "MoviesByReleaseDate",
                "Movies/Released/{year}/{month}",   // url pattern
                new { Controller = "Movies", action = "ByReleaseDate"}  
                );
        ``` 
		
		in the movies controller
		
		```
		   public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
		```
		
		Add constraint/regular expression to route
		
		```
		    routes.MapRoute(
                "MoviesByReleaseDate",
                "Movies/Released/{year}/{month}",
                new { Controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"}
				//  new { year = @"2015|2016", month = @"\d{2}" } // only for 2015 or 2016
                );
		```   
		
		
07. Attribute routing: 		
		a. For the case of custom routing in the RouteConfig.cs, if the application is large than the file will
		   be a mess. 
		b. You have to go back and forth between your custom routes and actions. 
        c. Third issue is that, when you rename an action in the controller, you have to go back to the route file 
           to rename it. 
    To resolve this issue, asp.net mvc5 introduced a cleaner and embeded way for custom routing, that is attribute 
	routing. 
    ***Enabling Attribute Routing
    To enable Attribute Routing, we need to call the MapMvcAttributeRoutes method of the route collection class 
	during configuration in the RouteConfig.cs file like as
	  
	  ```
	     routes.MapMvcAttributeRoutes();
	  ```
   
    And than define the route at the top of the action method like as 
    
      ```
	    [Route("Users/about")]
		
		[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
	  
      ``` 	  
    	
08. Passing data to view: 

    Following are the available options to pass data from a Controller to View in ASP.NET MVC:

		a. ViewBag
		b. ViewData
		c. TempData	

    i) If we want to maintain state between a Controller and corresponding View- ViewData 
	  and ViewBag are the available options but both of these options are limited to a single 
	  server call (meaning it’s value will be null if a redirect occurs). But if we need to 
	  maintain state from one Controller to another (redirect case), then TempData is the 
	  other available option. 
    
 	ii) ViewBag: 
         1. ViewBag transfers data from the controller to the view, ideally temporary data which 
		    in not included in a model.
         2. ViewBag is a dynamic property that takes advantage of the new dynamic features in C# 4.0
            You can assign any number of propertes and values to ViewBag
         3. The ViewBag's life only lasts during the current http request. ViewBag values will be 
		    null if redirection occurs.	
			
    ViewBag Example
	
```
public class EmployeeController : Controller
{
          // GET: /Employee/
         public ActionResult Index()
        {
                    ViewBag.EmployeeName = “Muhammad Hamza”;
                    ViewBag.Company = “Web Development Company”;
                    ViewBag.Address = “Dubai, United Arab Emirates”;
                    return View();
        }
 }
 
 
And to get Employee details passed from Controller using ViewBag, View code will be as follows: 

<body>
  <div>
        <h1>Employee (ViewBag Data Example)</h1>
        <div>
			<b>Employee Name:</b> @ViewBag.EmployeeName<br />
			<b>Company Name:</b> @ViewBag.Company<br />
			<b>Address:</b> @ViewBag.Address<br />
        </div>
  </div>
</body>

```

    iii) ViewData:   
	     1. ViewData transfers data from the Controller to View, not vice-versa.
         2. ViewData is derived from ViewDataDictionary which is a dictionary type.
		 3. ViewData's life only lasts during current http request. ViewData values will be 
		    cleared if redirection occurs.
		 4. ViewData value must be type cast before use.
		 5. ViewBag internally inserts data into ViewData dictionary. So the key of ViewData 
		    and property of ViewBag must NOT match.
			
	ViewData Example



```

   public class EmployeeController : Controller
	{
			  // GET: /Employee/
			 public ActionResult Index()
			{
						ViewData["EmployeeName"] = “Muhammad Hamza”;
						ViewData["Company"] = “Web Development Company”;
						ViewData["Address"] = “Dubai, United Arab Emirates”;
						return View();
			}
	 }
	And to get Employee details passed from Controller using ViewBag, View code will be as follows:

	<body>
	  <div>
		<h1>Employee (ViewBag Data Example)</h1>
		<div>
			<b>Employee Name:</b> @ViewData["EmployeeName"]<br />
			<b>Company Name:</b> @ViewData["Company"]<br />
			<b>Address:</b> @ViewData["Address"]<br />
		</div>
	  </div>
	</body>
	
```			


    iv) TempData: 
         1. TempData can be used to store data between two consecutive requests. TempData values will 
		    be retained during redirection.
		 2.	TemData is a TempDataDictionary type.
		 3.	TempData internaly use Session to store the data. So think of it as a short lived session.
		 4.	TempData value must be type cast before use. Check for null values to avoid runtime error.
		 5.	TempData can be used to store only one time messages like error messages, validation messages.
		 6.	Call TempData.Keep() to keep all the values of TempData in a third request.	
		 
	TempData example

```
  public ActionResult Index()
    {
        TempData["myData"] = "Test data";
        return View();
    }

    public ActionResult About()
    {
        string data;
        
        if(TempData["myData"] != null)
            data = TempData["myData"] as string;
        
        TempData.Keep();
        
        return View();
    }

```	


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
07. 		
		
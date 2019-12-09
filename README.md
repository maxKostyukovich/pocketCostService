**Expenses API**
----

* **URL**

  /api/expenses - returns all expenses. Сan be used with filters

* **Method:**

  `GET`
  
* **Filtering data with query string:**

   `Title=[string]`
   
   `Money=[double]` - can be used with `<` and `>` signs 

   `DateOfCreate=[DateTime]` - used in format `mm/dd/yyyy`. Can be used with `<` and `>` signs 
* **Example:**
    
    ``http://localhost:8080/api/expenses`` - will return all expenses
    
    ``http://localhost:8080/api/expenses?Money=<200.65&DateOfCreate=>08/10/2019`` - will return all expenses, where money less then `200.65` and date after `08/10/2019` 
 
 * **URL**

    `/api/expenses/:id` - return expense where id = :id.

* **Method:**

  `GET`

* **URL Params:**

   `id=[integer]`

* **Example:**
    
    ``http://localhost:8080/api/expenses/1`` - will return expense with id = 1
    
* **URL**

  `/api/expenses` - return expense that you created 

* **Method:**

  `POST`

* **Required data:**
  
  **Data format JSON**
  
  ```json
  {
	"Title":"Shop expenses",
	"Description":"Water, meat, coca-cola",
	"Money": 200.5,
	"DateOfCreate": "12/09/2019"
  }

* **URL**

  `/api/expenses/:id` - modified expense where id = :id

* **Method:**

  `PUT`

* **URL Params:**

   `id=[integer]`
   
* **Required data:**
  
  **Data format JSON**
  
  ```json
  {
	"Title":"Shop expenses",
	"Description":"Water, meat, coca-cola",
	"Money": 130.2,
	"DateOfCreate": "12/09/2019"
  }

 * **URL**

    `/api/expenses/:id` - delete expense with id = :id and return it.

* **Method:**

  `DELETE`

* **URL Params:**

   `id=[integer]`

* **Example:**
    
    ``http://localhost:8080/api/expenses/1`` - will delete and return  expense with id = 1
    

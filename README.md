This project demonstrates the use of NUnit and Moq for testing and validating different aspects of a .NET application. 
It includes testing CRUD operations in an in-memory database using Entity Framework, as well as validating the behavior of a controller's view.

The project features unit tests for methods like CreateAsync and UpdateAsync to ensure that business logic and database interactions function as expected.
Using NUnit assertions like ClassicAssert.AreEqual and ClassicAssert.NotNull, the tests confirm the correctness of the code.

Additionally, I tested the Index view in the CategoryController by using the Moq library to mock the ICategoryRepositories interface. For example,
a test was created to verify that the Index action returns the correct view with a list of categories.
By setting up the mock repository to return a predefined list of categories, I ensured that the controller properly retrieves and displays the data.

This project highlights the effectiveness of NUnit and Moq in catching issues early, improving code quality, and ensuring reliability.
It serves as a practical example of how unit tests can streamline development and reduce the likelihood of bugs in a .NET application.

![CategoryNTest](https://github.com/user-attachments/assets/af55a270-e088-4bd8-ad89-35be6789ecb5)
![CategoryRepositories](https://github.com/user-attachments/assets/cd71386d-b9b4-4122-b951-91683edbc64d)
![public interface ICategoryRepositories](https://github.com/user-attachments/assets/78a2e327-daa5-4732-8775-e9c5a4b48d24)
![testResults](https://github.com/user-attachments/assets/4cf33c50-44a8-41b5-b1ce-16159fdfb7a5)
![Screenshot 2025-01-15 170820](https://github.com/user-attachments/assets/21b79a6d-a41a-40fe-ba7f-ba14318c17d6)
![viewTest](https://github.com/user-attachments/assets/b4f3608f-2c12-410c-8ccd-cb0dab351f02)

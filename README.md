# DependencyInjectionDemo
This project demostrate how dependency work in dotnet core application.

#### Steps
* Create ServiceCollection class object
This class is responsible to create metadata container for all your dependency injected classes.
It acts as bucket for all your DI classes.

Due to single responsibility principle, ServiceCollection class doesn't create object of DI classes.

* Create instance of ServiceProvider from serviceCollection.BuildServiceProvider()
By creating single platform / instance of this class we can access the instance DI classes.

* Create instance of your DI classes.
var yourclassInstance = builder.GetService<yourclass>()
Debugging PayPal Instant Payment Notification solutions can be tricky. This is a project to offer some components for easier testing of IPN by letting you experiment with a lot of settings and see what works.

Work in progress! Includes/will include

- [PayNowButton](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/PayPalComponents.RCL/Components/PayNowButton.razor), which uses this [Settings](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/PayPalComponents.RCL/Models/Settings.cs) model
- depends on [PayPalExtensions](https://github.com/adamfoneil/PayPal.Extensions) for backend support via [NuGet package](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/PayPalComponents.RCL/PayPalComponents.RCL.csproj#L24)
- has a [test component](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/PayPalComponents.RCL/Components/IPNTest.razor) for embedding test features in your target application
- this repo has a test app using the [test dashboard](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/TestApp/Pages/Index.razor#L6) with a [sample listener](https://github.com/adamfoneil/PayPalComponents.RCL/blob/master/TestApp/Controllers/PayPalController.cs).

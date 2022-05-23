# TensorFlow Lite

TensorFlow Lite bindings for Xamarin.Android

**Current code will bind TensorFlow.Lite 2.9.0**

This codebase originates from: https://github.com/xamarin/XamarinComponents
but is updated to bind tensorflow lite 2.9.0


 * GitHub project: https://github.com/tensorflow/tensorflow/ 
 * License: https://github.com/tensorflow/tensorflow/blob/master/LICENSE 
 * Acknowledgements: https://github.com/tensorflow/tensorflow/blob/master/ACKNOWLEDGMENTS


## Build nugets

The build script for this project uses [Cake](http://cakebuild.net). Make sure you have installed latest cake build tools.

To install Cake:

```
dotnet tool install -g Cake.Tool	
```

In the terminal navigate to the root folder where build.cake script exists.
Run command: 

```
dotnet cake
```

It will download dependencies from Maven (to /externals directory), compile the code and package the nugets.

Output will be 3 nugets (in /output directory):

* Xamarin.TensorFlow.Lite
* Xamarin.TensorFlow.Lite.Api
* Xamarin.TensorFlow.Lite.Gpu

Install nugets to your Xamarin Android project.

## Acknowledgements
This repo is based on https://github.com/xamarin/XamarinComponents

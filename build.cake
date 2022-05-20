
var TARGET = Argument("t", Argument("target", "ci"));

var TENSOR_FLOW_LITE_NUGET_VERSION = "2.8.12";
var TENSOR_FLOW_LITE_AAR_VERSION = "2.8.0";

var TENSOR_FLOW_LITE_GPU_NUGET_VERSION = "2.8.12";
var TENSOR_FLOW_LITE_GPU_AAR_VERSION = "2.8.0";

var TENSOR_FLOW_LITE_API_NUGET_VERSION = "2.8.12";

var TENSOR_FLOW_LITE_API_URL_AAR_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite-api/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-api-{TENSOR_FLOW_LITE_AAR_VERSION}.aar";
var TENSOR_FLOW_LITE_API_URL_POM_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite-api/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-api-{TENSOR_FLOW_LITE_AAR_VERSION}.pom";
var TENSOR_FLOW_LITE_API_JAVADOC_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite-api/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-api-{TENSOR_FLOW_LITE_AAR_VERSION}-javadoc.aar";
var TENSOR_FLOW_LITE_API_SOURCES_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite-api/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-api-{TENSOR_FLOW_LITE_AAR_VERSION}-sources.aar";


var TENSOR_FLOW_LITE_URL_AAR_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}.aar";
var TENSOR_FLOW_LITE_URL_POM_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}.pom";
var TENSOR_FLOW_LITE_URL_JAVADOC_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}-javadoc.aar";
var TENSOR_FLOW_LITE_URL_SOURCES_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/{TENSOR_FLOW_LITE_AAR_VERSION}/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}-sources.aar";

var TENSOR_FLOW_LITE_GPU_URL_AAR_VERSION = $"https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite-gpu/{TENSOR_FLOW_LITE_GPU_AAR_VERSION}/tensorflow-lite-gpu-{TENSOR_FLOW_LITE_GPU_AAR_VERSION}.aar";

Task("externals")
	.WithCriteria(!FileExists($"./externals/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}.aar"))
	.WithCriteria(!FileExists($"./externals/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}.pom"))
	.WithCriteria(!FileExists($"./externals/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}-javadoc.aar"))
	.WithCriteria(!FileExists($"./externals/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}-sources.aar"))

	.WithCriteria(!FileExists($"./externals/tensorflow-lite-gpu-{TENSOR_FLOW_LITE_GPU_AAR_VERSION}.aar"))
	.WithCriteria(!FileExists($"./externals/tensorflow-lite-gpu-{TENSOR_FLOW_LITE_GPU_AAR_VERSION}.pom"))
	.Does(() => 
{
	EnsureDirectoryExists("./externals/");
	
	DownloadFile(TENSOR_FLOW_LITE_API_URL_AAR_VERSION, $"./externals/tensorflow-lite-api-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");
	DownloadFile(TENSOR_FLOW_LITE_API_URL_POM_VERSION, "./externals/tensorflow-lite-api.pom");
	DownloadFile(TENSOR_FLOW_LITE_API_JAVADOC_VERSION, $"./externals/tensorflow-lite-api-javadoc-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");
	DownloadFile(TENSOR_FLOW_LITE_API_SOURCES_VERSION, $"./externals/tensorflow-lite-api-sources-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");
	
	
	DownloadFile(TENSOR_FLOW_LITE_URL_AAR_VERSION, $"./externals/tensorflow-lite-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");
	DownloadFile(TENSOR_FLOW_LITE_URL_POM_VERSION, "./externals/tensorflow-lite.pom");
	DownloadFile(TENSOR_FLOW_LITE_URL_JAVADOC_VERSION, $"./externals/tensorflow-lite-javadoc-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");
	DownloadFile(TENSOR_FLOW_LITE_URL_SOURCES_VERSION, $"./externals/tensorflow-lite-sources-{TENSOR_FLOW_LITE_AAR_VERSION}.aar");

	DownloadFile(TENSOR_FLOW_LITE_GPU_URL_AAR_VERSION, $"./externals/tensorflow-lite-gpu-{TENSOR_FLOW_LITE_GPU_AAR_VERSION}.aar");


	Unzip ($"./externals/tensorflow-lite-api-javadoc-{TENSOR_FLOW_LITE_AAR_VERSION}.aar", "./externals/tensorflow-lite-api-javadoc/");
	Unzip ($"./externals/tensorflow-lite-api-sources-{TENSOR_FLOW_LITE_AAR_VERSION}.aar", "./externals/tensorflow-lite-api-sources/");

	Unzip ($"./externals/tensorflow-lite-javadoc-{TENSOR_FLOW_LITE_AAR_VERSION}.aar", "./externals/tensorflow-lite-javadoc/");
	Unzip ($"./externals/tensorflow-lite-sources-{TENSOR_FLOW_LITE_AAR_VERSION}.aar", "./externals/tensorflow-lite-sources/");

	var csproj_01 = "./source/Xamarin.TensorFlow.Lite.Bindings.XamarinAndroid/Xamarin.TensorFlow.Lite.Bindings.XamarinAndroid.csproj";
	var csproj_02 = "./source/Xamarin.TensorFlow.Lite.Gpu.Bindings.XamarinAndroid/Xamarin.TensorFlow.Lite.Gpu.Bindings.XamarinAndroid.csproj";
	var csproj_03 = "./source/Xamarin.TensorFlow.Lite.Api.Bindings.XamarinAndroid/Xamarin.TensorFlow.Lite.Api.Bindings.XamarinAndroid.csproj";
	XmlPoke(csproj_01, "/Project/PropertyGroup/PackageVersion", TENSOR_FLOW_LITE_NUGET_VERSION);
	XmlPoke(csproj_02, "/Project/PropertyGroup/PackageVersion", TENSOR_FLOW_LITE_GPU_NUGET_VERSION);
	XmlPoke(csproj_03, "/Project/PropertyGroup/PackageVersion", TENSOR_FLOW_LITE_API_NUGET_VERSION);
});

Task("libs")
	.IsDependentOn("externals")
	.Does(() =>
{
	MSBuild("./source/Xamarin.TensorFlow.Lite.sln", c => {
		c.Configuration = "Release";
		c.Restore = true;
		//c.ToolVersion = MSBuildToolVersion.VS2022;
		c.Properties.Add("PackageOutputPath", new [] { MakeAbsolute(new FilePath("./output")).FullPath });
		c.Properties.Add("DesignTimeBuild", new [] { "false" });
	});
});

// stub because we pack on build
Task("nuget")
	.IsDependentOn("libs");

Task("clean")
	.Does(() =>
{
	if (DirectoryExists("./externals/"))
		DeleteDirectory("./externals", new DeleteDirectorySettings 
												{
													Recursive = true,
													Force = true
												}
											);
});

Task("ci")
	.IsDependentOn("libs")
	.IsDependentOn("nuget");

RunTarget(TARGET);
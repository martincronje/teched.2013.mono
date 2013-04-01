%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe RestSharp.Mono.sln /t:Clean,Rebuild /p:Configuration=Release /fileLogger

if not exist RestSharp\Download\MonoDroid mkdir RestSharp\Download\MonoDroid\
if not exist RestSharp\Download\MonoTouch mkdir RestSharp\Download\MonoTouch\

copy RestSharp\RestSharp.MonoDroid\bin\Release\RestSharp.MonoDroid.dll RestSharp\Download\MonoDroid\
copy RestSharp\RestSharp.MonoTouch\bin\iPhone\Release\RestSharp.MonoTouch.dll RestSharp\Download\MonoTouch\

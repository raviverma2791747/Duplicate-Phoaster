# Duplicate-Phoaster
![](https://github.com/raviverma2791747/Duplicate-Phoaster/blob/master/Duplicate/Icon.ico)</br>
Current Version : 1.5<br>

Development Environment Visual Studio 2019<br>

Add Nuget Packages windowsAPICodePack-Shell and windowsAPICodePack-Core<br>
For this code to work <br>
```C#
ShellFile shellFile = ShellFile.FromFilePath(listFiles[i]);
Bitmap shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
```
```C#
ShellFile shellFile = ShellFile.FromFilePath(listFiles[j]);
Bitmap shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
```

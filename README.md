# Duplicate-Phoaster

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

# Treenamer 
Recursively finds and replaces strings on file and directory names based on a root directory.
Optionally finds and replaces in file contents.

Useful for renaming projects items including directory, file names and contents based on file name like classes, package names, namespaces, configuration and so on.


# Usage

    trename {directory} {string} {replacement} [-c]



## Parameters:

- directory: directory to run this tool
- string: string to be replaced
- replacement: replacement for the string
- -c (optional): also finds and replaces file contents

# Example
    trename "C:\Projects\MyProjectName" "MyProjectName" "SuperProject" -c
Note that "C:\Projects\MyProjectName" will also be renamed to "C:\Projects\SuperProject" currently there's no way to turn off this behavior.
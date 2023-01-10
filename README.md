# Ekeel.Interop.Python

A wrapper around PythonNet that allows for execution of Python code.

```csharp
using Ekeel.Interop.Python;

var pythonHandler = new Handler();

var variables = new Dictionary<string, object>();
variables.Add("test_var", "test_var_val");

pythonHandler.RunFromFile(@"C:\tmp\test.py", "sysversion", variables);
```

- [Ekeel.Interop.Python](#ekeelinteroppython)
	- [`Handler`](#handler)
		- [Constructors](#constructors)
			- [`Handler()`](#handler-1)
			- [`Handler(string pythonDllPath)`](#handlerstring-pythondllpath)
			- [`Handler(string pythonDllPath, string pythonHome)`](#handlerstring-pythondllpath-string-pythonhome)
		- [Instance Methods](#instance-methods)
			- [`void RunFromString(string code)`](#void-runfromstringstring-code)
			- [`void RunFromString(string code, Dictionary<string, object> variables)`](#void-runfromstringstring-code-dictionarystring-object-variables)
			- [`TResult RunFromString<TResult>(string code, string returnVariable)`](#tresult-runfromstringtresultstring-code-string-returnvariable)
			- [`TResult RunFromString<TResult>(string code, string returnVariable, Dictionary<string, object> variables)`](#tresult-runfromstringtresultstring-code-string-returnvariable-dictionarystring-object-variables)
			- [`void RunFromFile(string scriptFile)`](#void-runfromfilestring-scriptfile)
			- [`void RunFromFile(string scriptFile, Dictionary<string, object> variables)`](#void-runfromfilestring-scriptfile-dictionarystring-object-variables)
			- [`TResult RunFromFile<TResult>(string scriptFile, string returnVariable)`](#tresult-runfromfiletresultstring-scriptfile-string-returnvariable)
			- [`TResult RunFromFile<TResult>(string scriptFile, string returnVariable, Dictionary<string, object> variables)`](#tresult-runfromfiletresultstring-scriptfile-string-returnvariable-dictionarystring-object-variables)


## `Handler`

Class `Handler` handles execution of Python scripts using a local Python setup.

### Constructors

#### `Handler()`

> *This constructor initializes a new `Handler` using a .env file.*
> 
> Notes:
> - Read required variables from a local `.env` file.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
> ```

#### `Handler(string pythonDllPath)`

> This constructor initializes a new `Handler` using a .env file.
>
> Parameters:
> - `pythonDllPath`
>   - The local path of the Python DLL to use for the runtime.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler(@"C:\tmp\test.dll");
> ```

#### `Handler(string pythonDllPath, string pythonHome)`

> This constructor initializes a new `Handler` using a .env file.
>
> Parameters:
> - `pythonDllPath`
>   - The local path of the Python DLL to use for the runtime.
> - `pythonHome`
>   - The path to the python home directory.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler(@"C:\tmp\test.dll", @"C:\python\");
> ```

### Instance Methods

#### `void RunFromString(string code)`

> This method runs a string of Python code.
>
> Parameters:
> - `code`
>   - The Python string to execute.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> pythonHandler.RunFromString("import sys; sysversion = sys.version");
> ```

#### `void RunFromString(string code, Dictionary<string, object> variables)`

> This method runs a string of Python code.
>
> Parameters:
> - `code`
>   - The Python string to execute.
> - `variables`
>   - Dictionary containing the key/values of variables to set.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> var variables = new Dictionary<string, object>();
> variables.Add("test_var", "test_var_val");
>
> pythonHandler.RunFromString("import sys; sysversion = sys.version; print('test_var')", variables);
> ```

#### `TResult RunFromString<TResult>(string code, string returnVariable)`

> This method runs a string of Python code.
>
> Parameters:
> - `code`
>   - The Python string to execute.
> - `returnVariable`
>   - The variable to read from the scope.
>
> Returns:
> - The value of the `returnVariable` from the scope.
>
> Exceptions:
> - `KeyNotFoundException`
>   - The `returnVariable` was not found.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> var retVal = pythonHandler.RunFromString("import sys; sysversion = sys.version", "sysversion");
> ```

#### `TResult RunFromString<TResult>(string code, string returnVariable, Dictionary<string, object> variables)`

> This method runs a string of Python code.
>
> Parameters:
> - `code`
>   - The Python string to execute.
> - `returnVariable`
>   - The variable to read from the scope.
> - `variables`
>   - Dictionary containing the key/values of variables to set.
>
> Returns:
> - The value of the `returnVariable` from the scope.
>
> Exceptions:
> - `KeyNotFoundException`
>   - The `returnVariable` was not found.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> var variables = new Dictionary<string, object>();
> variables.Add("test_var", "test_var_val");
>
> var retVal = pythonHandler.RunFromString("import sys; sysversion = sys.version", "sysversion", variables);
> ```

#### `void RunFromFile(string scriptFile)`

> This method runs a Python script.
>
> Parameters:
> - `scriptFile`
>   - he path to the Python script to execute.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> pythonHandler.RunFromFile(@"C:\tmp\test.py");
> ```

#### `void RunFromFile(string scriptFile, Dictionary<string, object> variables)`

> This method runs a Python script.
>
> Parameters:
> - `scriptFile`
>   - he path to the Python script to execute.
> - `variables`
>   - Dictionary containing the key/values of variables to set.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> var variables = new Dictionary<string, object>();
> variables.Add("test_var", "test_var_val");
>
> pythonHandler.RunFromFile(@"C:\tmp\test.py", variables);
> ```

#### `TResult RunFromFile<TResult>(string scriptFile, string returnVariable)`

> This method runs a Python script.
>
> Parameters:
> - `scriptFile`
>   - he path to the Python script to execute.
> - `returnVariable`
>   - The variable to read from the scope.
> 
> Returns:
> - The value of the `returnVariable` from the scope.
>
> Exceptions:
> - `KeyNotFoundException`
>   - The `returnVariable` was not found.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> pythonHandler.RunFromFile(@"C:\tmp\test.py", "sysversion");
> ```

#### `TResult RunFromFile<TResult>(string scriptFile, string returnVariable, Dictionary<string, object> variables)`

> This method runs a Python script.
>
> Parameters:
> - `scriptFile`
>   - he path to the Python script to execute.
> - `returnVariable`
>   - The variable to read from the scope.
> - `variables`
>   - Dictionary containing the key/values of variables to set.
> 
> Returns:
> - The value of the `returnVariable` from the scope.
>
> Exceptions:
> - `KeyNotFoundException`
>   - The `returnVariable` was not found.
>
> Examples:
> ```csharp
> var pythonHandler = new Ekeel.Interop.Python.Handler();
>
> var variables = new Dictionary<string, object>();
> variables.Add("test_var", "test_var_val");
>
> pythonHandler.RunFromFile(@"C:\tmp\test.py", "sysversion", variables);
> ```
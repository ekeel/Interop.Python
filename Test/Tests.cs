using Ekeel.Interop.Stdlib;
using Ekeel.Interop.Python;
using System.Runtime.InteropServices;

namespace Test;

public class Tests
{
    string testScriptString, testFilePath;
    Handler pythonHandler;

    [SetUp]
    public void Setup()
    {
        testScriptString = "import sys; sysversion = sys.version";
        testFilePath = Path.Join("Resources", "Scripts", "test_file.py");

        Env.LoadEnvFile(Path.Join("Resources", "Env", "python.env"));

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            pythonHandler = new Handler(Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_DLL"), Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_HOME"));
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            pythonHandler = new Handler(Environment.GetEnvironmentVariable("PY_HANDLER_LIN_PYTHON_DLL"));
    }

    [Test]
    public void PythonRunFromStringWithoutReturn()
    {
        pythonHandler.RunFromString(testScriptString);

        Assert.Pass();
    }

    [Test]
    public void PythonRunFromStringWithReturn()
    {
        var result = pythonHandler.RunFromString<string>(testScriptString, "sysversion");

        Assert.IsNotEmpty(result);
    }

    [Test]
    public void PythonRunFromStringWithAdditionalVariablesTest()
    {
        var tdict = new Dictionary<string, object>();
        tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

        var result = pythonHandler.RunFromString<string>(testScriptString, "testvar", tdict);

        Assert.IsNotEmpty(result);
        Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
    }


    [Test]
    public void PythonRunFromFileWithoutReturn()
    {
        pythonHandler.RunFromFile(testFilePath);

        Assert.Pass();
    }

    [Test]
    public void PythonRunFromFileWithReturn()
    {
        var result = pythonHandler.RunFromFile<string>(testFilePath, "sysversion");

        Assert.IsNotEmpty(result);
    }

    [Test]
    public void PythonRunFromFileWithAdditionalVariablesTest()
    {
        var tdict = new Dictionary<string, object>
            {
                { "testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932" }
            };

        var result = pythonHandler.RunFromFile<string>(testFilePath, "testvar", tdict);

        Assert.IsNotEmpty(result);
        Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
    }
}

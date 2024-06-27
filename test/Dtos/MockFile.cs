using System.IO;
using Soenneker.Utils.Test.Tests.Dtos.Abstract;

namespace Soenneker.Utils.Test.Tests.Dtos;

public class MockFile : IFile
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}
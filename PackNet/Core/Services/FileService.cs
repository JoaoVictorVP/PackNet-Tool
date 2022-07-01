using PackNet.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNet.Core.Services;

public class FileService : IFileService
{
    public string Search(string pattern, string inDir = "./", bool deep = false)
    {
        return DoSearch(pattern, inDir, deep).FirstOrDefault() ?? "";
    }

    public IEnumerable<string> SearchMany(string pattern, string inDir = "./", bool deep = false)
    {
        return DoSearch(pattern, inDir, deep);
    }

    static IEnumerable<string> DoSearch(string pattern, string inDir, bool deep)
    {
        var files = Directory.EnumerateFiles(inDir, pattern, deep ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        return files;
    }
}

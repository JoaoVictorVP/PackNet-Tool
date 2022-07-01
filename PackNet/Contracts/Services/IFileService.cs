using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackNet.Contracts.Services;

public interface IFileService
{
    string Search(string pattern, string inDir = "./", bool deep = false);
    IEnumerable<string> SearchMany(string pattern, string inDir = "./", bool deep = false);
}

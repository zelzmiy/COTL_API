using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace COTL_API.Helpers;

public static class PluginPaths
{
    public static string ResolvePath(params string[] paths)
    {
        return Path.Combine((new List<string> { Plugin.PluginPath }).Concat(paths).ToArray());
    }

    public static string ResolveAssetPath(params string[] paths)
    {
        return ResolvePath("APIAssets", Path.Combine(paths));
    }
}
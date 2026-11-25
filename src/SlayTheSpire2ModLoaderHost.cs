using System;
using System.IO;
using System.Threading;

namespace SlayTheSpire2ModLoader
{
    public sealed class SlayTheSpire2ModLoaderHost : IDisposable
    {
        public const string BuildSalt = "d868d3c21f493866";
        public const string TargetModule = "slay-the-spire-2-mod-loader";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[{TargetModule}] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new SlayTheSpire2ModLoaderHost();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}

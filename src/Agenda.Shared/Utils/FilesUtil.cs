
namespace Agenda.Shared.Utils
{
    public static class FilesUtil
    {
        public static string LoadTemplateEmail(string name)
        {
            var bundleAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .First(x => x.FullName.Contains("Agenda.Shared"));

            var htmlFile = bundleAssembly.GetManifestResourceNames()
                .First(x => x.EndsWith($"{name}.html"));

            using var stream = bundleAssembly.GetManifestResourceStream(htmlFile);
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}

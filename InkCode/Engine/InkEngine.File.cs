namespace InkCode.Engine
{
    public partial class InkEngine
    {
        static string FileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}");
            }

            if (Path.GetExtension(path) != ".pw")
            {
                throw new InvalidDataException("Only .pw files are supported.");
            }

            string content = File.ReadAllText(path);

            return content;
        }
    }
}
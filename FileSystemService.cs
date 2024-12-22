using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSGradesMini.Services;

public static class FileSystemService
{
    private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "qualifications.json");

    public static ObservableCollection<Qualification> LoadQualifications()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<ObservableCollection<Qualification>>(json);
        }

        return new ObservableCollection<Qualification>();
    }

    public static void SaveQualifications(ObservableCollection<Qualification> qualifications)
    {
        var json = JsonSerializer.Serialize(qualifications);
        File.WriteAllText(FilePath, json);
    }
}

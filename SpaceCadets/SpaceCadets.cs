using Newtonsoft.Json; 
using Newtonsoft.Json.Linq; 

namespace SpaceCadets { 
class Student 
{ 
    public string Cadet = ""; 
    public string Group = ""; 
    public string Discipline = ""; 
    public double Mark { get; set; } 
} 

public class SpaceCadets 
{ 
    public static void Main(string[] args) 
    { 
        string inputPath = args[0], outputPath = args[1]; 

        string json = File.ReadAllText(inputPath); 
        dynamic data = JsonConvert.DeserializeObject(json) ?? new JObject(); 

        List<Student> students = data.data.ToObject<List<Student>>(); 
        string name = data.taskName; 
        List<dynamic> answer; 
        switch(name) 
        { 
            case "GetStudentsWithHighestGPA": 
            var maxResult = students 
            .GroupBy(x => x.Cadet) 
            .Select(x => new 
            { 
                Cadet = x.Key, GPA = Math.Round(x.Average(s => s.Mark), 2) 
            }) 
            .OrderByDescending(x => x.GPA) 
            .First(); 
            answer = students 
            .GroupBy(x => x.Cadet) 
            .Select(x => new 
            { 
                Cadet = x.Key, GPA = Math.Round(x.Average(s => s.Mark), 2) 
            }) 
            .OrderByDescending(x => x.GPA) 
            .TakeWhile(x => x.GPA == maxResult.GPA) 
            .ToList<dynamic>(); 
            break;

            case "CalculateGPAByDiscipline": 
            answer = students 
            .GroupBy(x => x.Discipline) 
            .Select(x => new {Response = Math.Round(x.Average(s => s.Mark), 2)}) 
            .ToList<dynamic>(); 
            break;

            case "GetBestGroupsByDiscipline": 
            answer = students 
            .GroupBy(x => x.Discipline) 
            .Select(x => new { 
            Discipline = x.Key, 
            Group = x.GroupBy(s => s.Group) 
            .Select(s => new { 
            Group = s.Key, 
            GPA = Math.Round(s.Average(y => y.Mark), 2) 
            }) 
            .OrderByDescending(x => x.GPA) 
            .FirstOrDefault() 
            }).ToList<dynamic>(); 
            break;
            
            default: 
            answer = new List<dynamic>(); 
            break; 
        } 
        var result = new { Response = answer }; 

        string outputJson = JsonConvert.SerializeObject(result, Formatting.Indented); 

        File.WriteAllText(outputPath, outputJson); 
        } 
    } 
}
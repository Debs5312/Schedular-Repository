using System.Text.Json.Serialization;

namespace Models.API.ProcessAPI
{
    public class ProcessDTO
    {
        public string? Id { get; set; }
        
        public string? Project { get; set; }
        
        public string? ProcessName { get; set; }
        
        public string? ProcessDescription { get; set; }
        
        public string? Author { get; set; }
    }
}
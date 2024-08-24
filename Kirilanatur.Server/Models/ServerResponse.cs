namespace Kirilanatur.Server.Models {
    
    public class ServerResponse {
        
        public object? Data { get; set; }
        public bool IsError { get; set; } = false;
        public string[] Messages { get; set; } = [];

    }
    
}

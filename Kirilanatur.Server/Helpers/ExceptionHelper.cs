using Kirilanatur.Server.Models;

namespace Kirilanatur.Server.Helpers {
    
    public static class ExceptionHelper {
        
        private static string[] FormErrorMessage(Exception? ex)
        {
            List<string> errorMessages = [];
            while (ex != null)
            {
                errorMessages.Add(ex.Message);
                ex = ex.InnerException;
            }

            return errorMessages.ToArray();
        }

        public static ServerResponse ErrorResponse(Exception ex) {
            return new ServerResponse {
                IsError = true,
                Messages = FormErrorMessage(ex)
            };
        }
        
    }
    
}
